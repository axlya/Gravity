#pragma checksum "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "639aa8a7fb0947fa85a1f0b56943ca57ae20fa17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ControlPanel), @"mvc.1.0.view", @"/Views/Home/ControlPanel.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "X:\GRAVITY\GravityWebExt\Views\_ViewImports.cshtml"
using GravityWebExt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "X:\GRAVITY\GravityWebExt\Views\_ViewImports.cshtml"
using GravityWebExt.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"639aa8a7fb0947fa85a1f0b56943ca57ae20fa17", @"/Views/Home/ControlPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42eadbc6a0f8ae91347cfc0d245b4ed3d67b1fe6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ControlPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ControlPanelDataWeb>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.6.0.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
  
    ViewData["Title"] = "Контрольная панель";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<meta charset=""utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">

<style>
    
    /*/Кнопка ВКЛ и ВЫКЛ/*/
    .checkbox-green {
        display: inline-block;
        height: 20px;
        line-height: 50%;
        margin-right: 5px;
        position: relative;
        vertical-align: middle;
        font-size: 20px;
        user-select: none;
    }

        .checkbox-green .checkbox-green-switch {
            display: inline-block;
            height: 30px;
            width: 150px;
            box-sizing: border-box;
            position: relative;
            border-radius: 3px;
            background: #848484;
            transition: background-color 0.3s cubic-bezier(0, 1, 0.5, 1);
        }

            .checkbox-green .checkbox-green-switch:before {
                content: attr(data-label-on);
                display: inline-block;
                box-sizing: border-box;
                width: 50%;
                padding: 0 12px;
         ");
            WriteLiteral(@"       position: absolute;
                top: 0;
                left: 50%;
                text-transform: uppercase;
                text-align: center;
                color: #848484;
                font-size: 15px;
                line-height: 28px;
            }

            .checkbox-green .checkbox-green-switch:after {
                content: attr(data-label-off);
                display: inline-block;
                box-sizing: border-box;
                width: 90px;
                border-radius: 1px;
                position: absolute;
                top: 2px;
                left: 1px;
                z-index: 5;
                text-transform: uppercase;
                text-align: center;
                background: white;
                line-height: 26px;
                font-size: 18px;
                color: #848484;
                transition: transform 0.3s cubic-bezier(0, 1, 0.5, 1);
            }

        .checkbox-green input[type=""checkbox""] {
      ");
            WriteLiteral(@"      display: block;
            width: 0;
            height: 0;
            position: absolute;
            z-index: -1;
            opacity: 0;
        }

            .checkbox-green input[type=""checkbox""]:checked + .checkbox-green-switch {
                background-color: #007BFF;
                color: #007BFF;
            }

                .checkbox-green input[type=""checkbox""]:checked + .checkbox-green-switch:before {
                    content: attr(data-label-off);
                    left: 0;
                    color: #007BFF;
                }

                .checkbox-green input[type=""checkbox""]:checked + .checkbox-green-switch:after {
                    content: attr(data-label-on);
                    color: #007BFF;
                    transform: translate3d(54px, 0, 0);
                }

            /* Hover */
            .checkbox-green input[type=""checkbox""]:not(:disabled) + .checkbox-green-switch:hover {
                cursor: pointer;
            }
");
            WriteLiteral(@"
        .col {
            border: 2px solid #DEE2E6;
        }
    
        .col:hover {
            border: 2px solid #1E90FF;       
        }
</style>


<div class=""container"">
    <div class=""row"">
        <div class=""col"" style=""background: #F2F2F2;"">
            <h5 align=""center"">Ход домкрата</h5><br />
            <table class=""table table-striped"" style=""margin-left: 0px; margin-right: 0px "">
                <tr>
                    <td>
                        <button type=""button"" class=""btn btn-primary"" onclick=""this.blur();"" style=""margin-bottom: 10px; background: #1E90FF;"" id=""jackUp""><h3>&nbsp;&nbsp;&nbsp;↑&nbsp;&nbsp;&nbsp;</h3></button>
                    </td>
                    <td>
                        <button type=""button"" class=""btn btn-primary"" onclick=""this.blur();"" style=""margin-bottom:10px; background: #1E90FF;"" id=""jackDown""><h3>&nbsp;&nbsp;&nbsp;↓&nbsp;&nbsp;&nbsp;</h3></button>
                    </td>
                    <td>
                       ");
            WriteLiteral(" <span>&nbsp;&nbsp;&nbsp;<label id=\"jackPos\">");
#nullable restore
#line 124 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                                                               Write(Model.JackPos.ToString("N3"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></span>
                    </td>
                    <td>
                        <input type=""text"" class=""form-control input"" id=""speedJack"" value=""1"" style=""width: 80px"" />
                    </td>
                    <td>
                        <input type=""button"" class=""btn btn-primary"" value=""▲"" style=""margin-bottom:10px; background: #1E90FF;"" id=""buttonspeedJack"" />
                    </td>                  
                </tr>
            </table>               
        </div>
        <div class=""col"" style=""background: #F2F2F2; "">
            <h5 align=""center"">Перемещение подвижного груза</h5><br />
            <table class=""table table-striped"" style=""margin-left: 0px; margin-right: 0px "">
                <tr>
                    <td>
                        <button type=""button"" class=""btn btn-primary"" onclick=""this.blur();"" style=""margin-bottom: 10px; background: #1E90FF;"" id=""cargoLeft""><h3>&nbsp;&nbsp;←&nbsp;&nbsp;</h3></button>
                    </td>
       ");
            WriteLiteral(@"             <td>
                        <button type=""button"" class=""btn btn-primary"" onclick=""this.blur();"" style=""margin-bottom: 10px; background: #1E90FF;"" id=""cargoRight""><h3>&nbsp;&nbsp;→&nbsp;&nbsp;</h3></button>
                    </td>
                    <td>
                        <span>&nbsp;&nbsp;&nbsp;<label id=""cargoPos"">");
#nullable restore
#line 146 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                                                                Write(Model.CargoPos.ToString("N3"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></span>
                    </td>
                    <td>
                        <input type=""text"" class=""form-control input"" id=""speedCargo"" value=""1"" style=""width: 80px"" />
                    </td>
                    <td>
                        <input type=""button"" class=""btn btn-primary"" value=""▲"" style=""margin-bottom:10px; background: #1E90FF;"" id=""buttonspeedCargo"" />
                    </td>                    
                </tr>
            </table>                  
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">           
                        <table class=""table table-striped"" style=""margin-top: 40px; margin-left: 0px; margin-right: 0px "">
                            <thead>
                                <tr style=""background:#F2F2F2;"">
                                    <th colspan=""6"" align=""center""><h5>Показания датчиков</h5></th>
                                    <th colspan=""8""></th>
                                    <th c");
            WriteLiteral(@"olspan=""6"" align=""center""><h5>Двигатель трения</h5></th>
                                </tr>
                                <tr>
                                    <th colspan=""3"">Наименование</th>
                                    <th>Обозначение</th>
                                    <th>Значение</th>
                                    <th></th>
                                    <th colspan=""2""></th>
                                    <th colspan=""6""></th>
                                    <th colspan=""2"">№1</th>
                                    <th colspan=""2"">№2</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td colspan=""3"">Датчик угловых перемещений</td>
                                    <td>α<sub>Σ</sub></td>
                                    <td><span><label id=""sensorAngle"">");
#nullable restore
#line 182 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                                                                 Write(Model.SensorAngle.ToString("N3"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></span></td>\r\n");
            WriteLiteral(@"                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2"">
                                        <label class=""checkbox-green"">
                                            <input type=""checkbox"">
                                            <span class=""checkbox-green-switch"" data-label-on=""Вкл"" data-label-off=""Выкл""></span>
                                        </label>
                                    </td>
                                    <td colspan=""2"">
                                        <label class=""checkbox-green"">
                                            <input type=""checkbox"">
                                            <span class=""checkbox-green-switch"" data-label-on=""Вкл"" data-label-off=""Выкл""></span>
                                        </l");
            WriteLiteral(@"abel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan=""3"">Датчик дисбаланса </td>
                                    <td>P<sub>α</sub></td>
                                    <td><span><label id=""sensorDisbalance"">");
#nullable restore
#line 204 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                                                                      Write(Model.SensorDisbalance.ToString("N3"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></span></td>\r\n");
            WriteLiteral(@"                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2"" >
                                        <div class=""btn-group-vertical"" style="" background:#1E90FF; border-radius: 5px"">
                                            <div class=""seldiv"" style=""margin: 5px; "">
                                                <label> <font color=""white"">Скорость:</font></label><select id=""selectvalue"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1714973", async() => {
                WriteLiteral("&nbsp;1&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1715997", async() => {
                WriteLiteral("&nbsp;2&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1717021", async() => {
                WriteLiteral("&nbsp;3&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1718045", async() => {
                WriteLiteral("&nbsp;4&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1719069", async() => {
                WriteLiteral("&nbsp;5&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </select>
                                            </div>
                                        </div>
                                    </td>
                                    <td colspan=""2"" >
                                        <div class=""btn-group-vertical"" style="" background:#1E90FF; border-radius: 5px"">
                                            <div class=""seldiv"" style=""margin: 5px;  "">
                                                <label> <font color=""white"">Скорость:</font></label><select id=""selectvalue"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1720701", async() => {
                WriteLiteral("&nbsp;1&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1721725", async() => {
                WriteLiteral("&nbsp;2&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1722749", async() => {
                WriteLiteral("&nbsp;3&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1723773", async() => {
                WriteLiteral("&nbsp;4&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1724797", async() => {
                WriteLiteral("&nbsp;5&nbsp;&nbsp;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </select>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>");
            WriteLiteral("                                <tr>\r\n                                    <td colspan=\"3\">Датчик силы</td>\r\n                                    <td>P</td>\r\n                                    <td><span><label id=\"sensorPower\">");
#nullable restore
#line 240 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                                                                 Write(Model.SensorPower.ToString("N3"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></span></td>\r\n");
            WriteLiteral(@"                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2""></td>
                                    <td colspan=""2"">
                                        <div class=""btn-group-vertical"" style="" background:#1E90FF; border-radius: 5px;"">
                                            <div class=""seldiv"" style=""margin: 5px; "">
                                                <label> <font color=""white"">Закон:</font></label><select id=""selectvalue"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1727314", async() => {
                WriteLiteral("p=m/V");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1728324", async() => {
                WriteLiteral("I=q/t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </select>
                                            </div>
                                        </div>
                                    </td>
                                    <td colspan=""2"">
                                        <div class=""btn-group-vertical"" style="" background:#1E90FF; border-radius: 5px;"">
                                            <div class=""seldiv"" style=""margin:5px; "">
                                                <label> <font color=""white"">Закон:</font></label><select id=""selectvalue"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1729937", async() => {
                WriteLiteral("p=m/V");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1730947", async() => {
                WriteLiteral("I=q/t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </select>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n    \r\n\r\n   \r\n\r\n    <br />\r\n");
            WriteLiteral("    \r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639aa8a7fb0947fa85a1f0b56943ca57ae20fa1732397", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            //var timerId = setInterval(setControllerData, timeSendToControllerInterval);
            timerId = setTimeout(function tick() { //рекурсивный setTimeout вызов более точный чем setInterval
                setControllerData();
                timerId = setTimeout(tick, timeSendToControllerInterval);
            }, timeSendToControllerInterval);
            //$(""#stopUpdating"").click(function () { clearInterval(timeInterval); });
            //$(""#startUpdating"").click(function () { timeInterval = setInterval(getData, $(""#intervalValue"").val()); });
            //домкрат
            $(""#jackUp"").mousedown(function () { jackUp = 1;setControllerData();});
            $(""#jackUp"").mouseup(function () { jackUp = 0; setControllerData();});
            $(""#jackDown"").mousedown(function () { jackDown = 1; setControllerData();});
            $(""#jackDown"").mouseup(function () { jackDown = 0; setControllerData();});
 ");
            WriteLiteral(@"           $(""#cargoLeft"").mousedown(function () { cargoLeft = 1; setControllerData(); });
            $(""#cargoLeft"").mouseup(function () { cargoLeft = 0; setControllerData();});
            $(""#cargoRight"").mousedown(function () { cargoRight = 1; setControllerData();});
            $(""#cargoRight"").mouseup(function () { cargoRight = 0; setControllerData(); });

            $(""#buttonspeedJack"").click(function () { alert(""Значение:""); speedJack = $('#speedJack').val(), setControllerData(); });
            $(""#buttonspeedCargo"").click(function () { alert(""Значение:""); speedJack = $('#speedCargo').val(), setControllerData(); });
        });

        //var timeInterval;
        var timeSendToControllerInterval = 1000; //дискретное время посылки сигнала в контроллер, мс
        var jackUp = 0;
        var jackDown = 0;
        var cargoLeft = 0;
        var cargoRight = 0;

        var speedJack = 0;
        var speedCargo = 0;

        var timerId;

        function setControllerData() {
 ");
            WriteLiteral("           $.ajax({\r\n                method: \"GET\",\r\n                url: \"");
#nullable restore
#line 337 "X:\GRAVITY\GravityWebExt\Views\Home\ControlPanel.cshtml"
                 Write(Url.Action("SetControllerData", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?random="" + Math.random(),
                data: { jackUp: jackUp, jackDown: jackDown, cargoLeft: cargoLeft, cargoRight: cargoRight, speedJack: speedJack, speedCargo: speedCargo},
                dataType: ""json"",
                success: function (result) {
                    $(""#jackPos"").text(parseFloat(result.jackPos).toFixed(3));
                    $(""#cargoPos"").text(parseFloat(result.cargoPos).toFixed(3));
                    $(""#sensorAngle"").text(parseFloat(result.sensorAngle).toFixed(3));
                    $(""#sensorDisbalance"").text(parseFloat(result.sensorDisbalance).toFixed(3));
                    $(""#sensorPower"").text(parseFloat(result.sensorPower).toFixed(3));

                    
                },
                error: function (result) {
                }
            });
        }
    </script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ControlPanelDataWeb> Html { get; private set; }
    }
}
#pragma warning restore 1591
