#pragma checksum "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e18a1ba398230c30d6e5d5e952f9de6187dad9bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admins_Views_BillManages_Index), @"mvc.1.0.view", @"/Areas/Admins/Views/BillManages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admins/Views/BillManages/Index.cshtml", typeof(AspNetCore.Areas_Admins_Views_BillManages_Index))]
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
#line 1 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\_ViewImports.cshtml"
using EProjectSEMIII;

#line default
#line hidden
#line 2 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\_ViewImports.cshtml"
using EProjectSEMIII.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e18a1ba398230c30d6e5d5e952f9de6187dad9bf", @"/Areas/Admins/Views/BillManages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b85ed855baca39a3ff4011573ba2567ae6f6660", @"/Areas/Admins/Views/_ViewImports.cshtml")]
    public class Areas_Admins_Views_BillManages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EProjectSEMIII.Models.BillingInformation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Click here to view information or activate insurance for customer!!"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admins/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(170, 114, true);
            WriteLiteral("\r\n<h2>Billing Manager</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(285, 48, false);
#line 14 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(333, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(389, 48, false);
#line 17 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PolicyNumber));

#line default
#line hidden
            EndContext();
            BeginContext(437, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(493, 47, false);
#line 20 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleName));

#line default
#line hidden
            EndContext();
            BeginContext(540, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(596, 48, false);
#line 23 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleModel));

#line default
#line hidden
            EndContext();
            BeginContext(644, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(700, 47, false);
#line 26 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleRate));

#line default
#line hidden
            EndContext();
            BeginContext(747, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(803, 40, false);
#line 29 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(843, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(899, 42, false);
#line 32 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(941, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(997, 42, false);
#line 35 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1039, 93, true);
            WriteLiteral("\r\n            </th>\r\n            <th>Funcion</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 41 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1181, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1242, 47, false);
#line 45 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(1289, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1357, 47, false);
#line 48 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PolicyNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1404, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1472, 46, false);
#line 51 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleName));

#line default
#line hidden
            EndContext();
            BeginContext(1518, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1586, 47, false);
#line 54 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleModel));

#line default
#line hidden
            EndContext();
            BeginContext(1633, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1701, 46, false);
#line 57 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleRate));

#line default
#line hidden
            EndContext();
            BeginContext(1747, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1815, 39, false);
#line 60 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1854, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1922, 41, false);
#line 63 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1963, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 65 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
                 if (item.Status == 0)
                {

#line default
#line hidden
            BeginContext(2047, 58, true);
            WriteLiteral("                    <td style=\"color:red\">In Active</td>\r\n");
            EndContext();
#line 68 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2165, 60, true);
            WriteLiteral("                    <td style=\"color:green\">Activated</td>\r\n");
            EndContext();
#line 72 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2244, 42, true);
            WriteLiteral("                <td>\r\n                    ");
            EndContext();
            BeginContext(2286, 158, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b5393c905a04be3b7e0bb2e3a23ffd1", async() => {
                BeginContext(2428, 12, true);
                WriteLiteral("View Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 74 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
                                                                                                                          WriteLiteral(item.BillingInformationId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2444, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2547, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 78 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Areas\Admins\Views\BillManages\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2600, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EProjectSEMIII.Models.BillingInformation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
