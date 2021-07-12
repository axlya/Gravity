using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            })
            );
            services.AddSingleton<WebDataProvider>(); //��������� ������ ��� ������������ (Web)
            services.AddSingleton<WebDataReporter>(); //��������� ������ �� ����������� (Web)
            services.AddSingleton<CalcWebReporter>(); // ���������� ������ ������������ (Web)
            services.AddSingleton<CalcDataReporter>(); // ���������� ������ ����������� (�����������)
            services.AddSingleton<DataProvider>(); // ��������� ������ �����������
            services.AddSingleton<Emulator>(); // �������� �����������
            services.AddSingleton<MainCalc>(); // ��������� ����� ������������
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(ILogger<Startup> logger, IApplicationBuilder app, IHostApplicationLifetime applicationLifetime, IWebHostEnvironment env, WebDataProvider webDataProvider, CalcWebReporter calcReporter, Emulator emu, MainCalc mainCalc, DataContext db, WebDataReporter webDataReporter, DataProvider dataProvider, CalcDataReporter calcDataReporter)
        {
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                emu.Stop();

                calcReporter.Unsubscribe();
                webDataReporter.Unsubscribe();
                calcDataReporter.Unsubscribe();
                dataProvider.EndTransmission();
                webDataProvider.EndTransmission();

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

            app.UseAuthorization();

            //������ ��������� ��������� ������ �����������
            emu.SetCalcFunc(mainCalc);
            emu.SetDataProvider(dataProvider);

            logger.LogInformation("������ ���������");
            //��������� ���������� ������
            calcReporter.SetCalcFunc(mainCalc);
            // �������� ������������ �� ��������� ������
            calcReporter.Subscribe(webDataProvider);
            //�������� �� ��������� ������ �����������
            webDataReporter.Subscribe(dataProvider);
            calcDataReporter.SetCalcFunc(mainCalc);
            calcDataReporter.Subscribe(dataProvider);

            webDataProvider.SendData(db.Options.ToList().ElementAt(0).SetDataForCalculate());
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
