#pragma checksum "X:\GRAVITY\GravityWebExt\Views\Shared\_ConnectPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c34030b938fd14151bab3e8c269b6d3b8566e00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ConnectPartial), @"mvc.1.0.view", @"/Views/Shared/_ConnectPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c34030b938fd14151bab3e8c269b6d3b8566e00", @"/Views/Shared/_ConnectPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42eadbc6a0f8ae91347cfc0d245b4ed3d67b1fe6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ConnectPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<ul class=""navbar-nav flex-grow-1"">
    <li class=""nav-item"">
        <span class=""ConnectLamp"" id=""connectLamp"" title=""Соединение с контроллером""></span>
    </li>
    <li class=""nav-item"">
        <button class=""Errorbutton"" id=""errorsButton"" data-toggle=""modal"" data-target=""#errorsModal"" title=""Ошибки контроллера""></button>
    </li>
</ul>

<!-- Modal -->
<div class=""modal fade"" id=""errorsModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Ошибки контроллера</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
");
            WriteLiteral(@"                    
                        <div id=""errorsContainer""></div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Закрыть</button>
                <button type=""button"" class=""btn btn-primary"" id=""sumbitButton"">Сбросить ошибки</button>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c34030b938fd14151bab3e8c269b6d3b8566e004888", async() => {
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
        var timerId = setTimeout(function tick() { //рекурсивный setTimeout вызов более точный чем setInterval
            getOnlineData();
            timerId = setTimeout(tick, timeUpdateInterval);
        }, timeUpdateInterval);

        $('#errorsModal').appendTo(""body"");
        $('[data-toggle=""tooltip""]').tooltip();

        $(""#errorsButton"").click(function () { //вывести на экран список ошибок
            if (errorsList != null) {
                $('#errorsContainer').empty();
                var table = $('<table class=""table table-striped""></table>').addClass('foo');
                $.each(errorsList, function (index, value) {
                    var row = $('<tr></tr>');
                    var col1 = $('<td></td>').addClass('bar').text(index);
                    var col2 = $('<td></td>').addClass('bar').text(value);
                    table.append(row);
                    row.append(col1);
               ");
            WriteLiteral(@"     row.append(col2);
                });
                $('#errorsContainer').append(table);
            }
        });
        $(""#sumbitButton"").click(function () { //сбросить ошибки
            setResetErrors();
        });
    });

    var timeUpdateInterval = 500;
    var errorsList = null;

    function setResetErrors() {
            $.ajax({
                method: ""GET"",
                url: """);
#nullable restore
#line 81 "X:\GRAVITY\GravityWebExt\Views\Shared\_ConnectPartial.cshtml"
                 Write(Url.Action("SetResetErrors", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?random="" + Math.random(),
                //data: { jackUp: jackUp, jackDown: jackDown, cargoLeft: cargoLeft, cargoRight: cargoRight, speedJack: speedJack, speedCargo: speedCargo},
                dataType: ""json"",
                success: function (result) {
                },
                error: function (result) {
                }
            });
        }

    function getOnlineData() {
        $.ajax({
            type: ""GET"",
            url: """);
#nullable restore
#line 94 "X:\GRAVITY\GravityWebExt\Views\Shared\_ConnectPartial.cshtml"
             Write(Url.Action("GetControllerDataRepeat", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?random="" + Math.random(),
            dataType: ""json"",
            success: function (result) {

                //console.log(result);

                if (result.connectDevice == 1) {
                   $(""#connectLamp"").css(""background-color"", ""green"");
                }
                else {
                    $(""#connectLamp"").css(""background-color"", ""red"");
                }
                if (Object.keys(result.errorsList).length == 0) {
                    $(""#errorsButton"").css(""background-color"", ""green"");
                }
                else {
                    $(""#errorsButton"").css(""background-color"", ""red"");
                }
                $(""#errorsButton"").text(Object.keys(result.errorsList).length.toString());
                errorsList = result.errorsList;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
