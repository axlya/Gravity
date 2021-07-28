using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GravityWebExt.Models;  
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using GravityCalc;
using GravityData;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GravityWebExt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string authConnection = Configuration.GetConnectionString("AuthConnection");
            string dataConnection = Configuration.GetConnectionString("DefaultConnection");

            //�������� ��������
            services.AddDbContext<DataContext>(options => options.UseSqlServer(dataConnection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            })
            );
            //�������� �����������
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(authConnection));

            services.AddIdentity<User, IdentityRole>(
                opts =>
            {
                opts.Password.RequiredLength = 3;   // ����������� ����� ������
                opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                opts.Password.RequireDigit = false; // ��������� �� �����
            }
            )
                .AddEntityFrameworkStores<ApplicationContext>();

            //����������
            services.AddSingleton<WebDataProvider>(); //��������� ������ Web(PassportData)
            services.AddSingleton<WebNSPDataProvider>(); //��������� ������ Web (NSPData)
            services.AddSingleton<DataProvider>(); // ��������� ������ ����������� (ControllerData)
            services.AddSingleton<CalcDataProvider>(); // ��������� ������ ������������ (CalculatedData)
            //����������
            services.AddSingleton<WebDataReporter>(); //���������� ������ �� ����������� (Web)
            services.AddSingleton<WebCalcDataReporter>(); //���������� ������ �� ������������ (Web)
            services.AddSingleton<CalcWebReporter>(); // ���������� ������ ������������ (Web - PassportData)
            services.AddSingleton<CalcWebNSPReporter>(); // ���������� ������ ������������ (Web - NSP Data)
            services.AddSingleton<CalcDataReporter>(); // ���������� ������ ����������� (�����������)
            //
            services.AddSingleton<Emulator>(); // �������� �����������
            services.AddSingleton<MainCalc>(); // ��������� ����� ������������
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(ILogger<Startup> logger, IApplicationBuilder app, IHostApplicationLifetime applicationLifetime, IWebHostEnvironment env, WebDataProvider webDataProvider, WebNSPDataProvider webNSPDataProvider, CalcDataProvider calcDataProvider,CalcWebReporter calcReporter, CalcWebNSPReporter calcNspReporter, WebCalcDataReporter webCalcDataReporter,Emulator emu, MainCalc mainCalc, DataContext db, WebDataReporter webDataReporter, DataProvider dataProvider, CalcDataReporter calcDataReporter)
        {
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                emu.Stop();

                calcReporter.Unsubscribe();
                webDataReporter.Unsubscribe();
                calcDataReporter.Unsubscribe();
                calcNspReporter.Unsubscribe();
                webCalcDataReporter.Unsubscribe();

                dataProvider.EndTransmission();
                webDataProvider.EndTransmission();
                webNSPDataProvider.EndTransmission();
                calcDataProvider.EndTransmission();

                logger.LogInformation("���������� ������...");

                System.Diagnostics.Process.GetCurrentProcess().Kill();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();     

            //������ ��������� ��������� ������ �����������
            emu.SetCalcFunc(mainCalc);
            emu.SetDataProvider(dataProvider);
            logger.LogInformation("������ ���������");
            //��������� ���������� ������
            mainCalc.SetDataProvider(calcDataProvider);
            //��������� ���������� ������
            calcReporter.SetCalcFunc(mainCalc);
            calcNspReporter.SetCalcFunc(mainCalc);
            calcDataReporter.SetCalcFunc(mainCalc);
            // �������� �� ��������� ������
            calcReporter.Subscribe(webDataProvider);
            calcNspReporter.Subscribe(webNSPDataProvider);
            webDataReporter.Subscribe(dataProvider);          
            calcDataReporter.Subscribe(dataProvider);
            webCalcDataReporter.Subscribe(calcDataProvider);
            logger.LogInformation("������ �����������");

            webDataProvider.SendData(db.Options.ToList().ElementAt(0).SetDataForCalculate());
           // webNSPDataProvider.SendData(db.NSP.ToList().ElementAt(0).SetDataForCalculate());
            emu.SetPassportData(db.Options.ToList().ElementAt(0).SetDataForCalculate());

            emu.Start();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
