#pragma checksum "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ee08b95d90b221e415cf3ffc8d65bea4d5fe544"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pessoa_AreaPessoal), @"mvc.1.0.view", @"/Views/Pessoa/AreaPessoal.cshtml")]
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
#line 1 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\_ViewImports.cshtml"
using DesafioCarteira;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\_ViewImports.cshtml"
using DesafioCarteira.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ee08b95d90b221e415cf3ffc8d65bea4d5fe544", @"/Views/Pessoa/AreaPessoal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e273800c13becfda4783946e14044bd993bbf914", @"/Views/_ViewImports.cshtml")]
    public class Views_Pessoa_AreaPessoal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DesafioCarteira.Models.Pessoa>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
  
    ViewData["Title"] = "AreaPessoal";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>AreaPessoal</h1>\r\n\r\n<div>\r\n    <h4>Pessoa</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.PessoaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.PessoaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Limite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Limite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Minimo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Minimo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Saldo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Saldo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.Senha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.Senha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayNameFor(model => model.TipoPessoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
       Write(Html.DisplayFor(model => model.TipoPessoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 70 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Pessoa\AreaPessoal.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ee08b95d90b221e415cf3ffc8d65bea4d5fe54410538", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DesafioCarteira.Models.Pessoa> Html { get; private set; }
    }
}
#pragma warning restore 1591