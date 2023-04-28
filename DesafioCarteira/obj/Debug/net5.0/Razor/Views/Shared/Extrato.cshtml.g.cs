#pragma checksum "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee3dc086858925b87c91c2de49fe8dde13c08a40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Extrato), @"mvc.1.0.view", @"/Views/Shared/Extrato.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee3dc086858925b87c91c2de49fe8dde13c08a40", @"/Views/Shared/Extrato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e273800c13becfda4783946e14044bd993bbf914", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Extrato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Object>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
  
    double? saldo = ViewBag.Saldo;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
 if (TempData["TagSaldoAnteior"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h6>Saldo anterior: ");
#nullable restore
#line 10 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                       Write(ViewBag.Saldo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-bordered"">
    <thead class=""thead-light"">
        <tr>
            <th class=""col-2 text-center"">Data Movimento</th>
            <th class=""col-5 text-center"">Descrição</th>
            <th class=""col-1 text-center"">Tipo(E/S)</th>
            <th class=""col-2 text-center"">Valor</th>
            <th class=""col-2 text-center"">Saldo</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 25 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
         foreach (var obj in Model)
        {
            if (obj is MovimentoEntrada)
            {
                MovimentoEntrada o = (MovimentoEntrada)obj;
                saldo += o.Valor;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"text-center\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                   Write(Html.DisplayFor(modelItem => o.DataEntrada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                   Write(Html.DisplayFor(modelItem => o.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        E\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        R$ ");
#nullable restore
#line 42 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                      Write(Html.DisplayFor(modelItem => o.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        R$ ");
#nullable restore
#line 45 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                      Write(Html.DisplayFor(modelItem => saldo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
            }
            else if (obj is MovimentoSaida)
            {
                MovimentoSaida o = (MovimentoSaida)obj;
                saldo -= o.Valor;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"text-center\">\r\n                        ");
#nullable restore
#line 55 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                   Write(Html.DisplayFor(modelItem => o.DataSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                   Write(Html.DisplayFor(modelItem => o.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        S\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        R$ ");
#nullable restore
#line 64 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                      Write(Html.DisplayFor(modelItem => o.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        R$ ");
#nullable restore
#line 67 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                      Write(Html.DisplayFor(modelItem => saldo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 70 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"d-flex justify-content-end\">\r\n    <h6>Saldo final: R$ ");
#nullable restore
#line 76 "C:\Users\Multisoftware Nstech\Documents\GitHub\CarteiraDigital\DesafioCarteira\Views\Shared\Extrato.cshtml"
                   Write(saldo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Object>> Html { get; private set; }
    }
}
#pragma warning restore 1591
