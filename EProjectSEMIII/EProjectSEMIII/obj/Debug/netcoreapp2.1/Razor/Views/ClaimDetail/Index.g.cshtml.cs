#pragma checksum "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1e4217d4b4ccffc7022e6c8587d75b8d95dc770"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClaimDetail_Index), @"mvc.1.0.view", @"/Views/ClaimDetail/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ClaimDetail/Index.cshtml", typeof(AspNetCore.Views_ClaimDetail_Index))]
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
#line 1 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\_ViewImports.cshtml"
using EProjectSEMIII;

#line default
#line hidden
#line 2 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\_ViewImports.cshtml"
using EProjectSEMIII.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1e4217d4b4ccffc7022e6c8587d75b8d95dc770", @"/Views/ClaimDetail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b85ed855baca39a3ff4011573ba2567ae6f6660", @"/Views/_ViewImports.cshtml")]
    public class Views_ClaimDetail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EProjectSEMIII.Models.ClaimDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(145, 511, true);
            WriteLiteral(@"
<section class=""page-title-section bg-img cover-background left-overlay-dark"" data-overlay-dark=""6"" data-background=""/Client/img/banner/slide-05.jpg"">
    <div class=""container position-unset"">
        <div class=""page-title mx-1-6 mx-lg-2-0 mx-xl-2-6 mx-xxl-2-9"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <h1>Claims</h1>
                </div>
                <div class=""col-md-12"">
                    <ul class=""ps-0"">
                        <li>");
            EndContext();
            BeginContext(656, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9534970c06514382ba496462c1a9afc2", async() => {
                BeginContext(700, 4, true);
                WriteLiteral("Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(708, 428, true);
            WriteLiteral(@"</li>
                        <li><a href=""#!"">Claims</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>
<section>
    <div class=""container"">
        <table class=""table mb-0"">
            
           
        </table>

        <table class=""table mb-0"">
            <thead>
                <tr>
                    <th>
                        ");
            EndContext();
            BeginContext(1137, 48, false);
#line 36 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.PolicyNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1185, 105, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1291, 48, false);
#line 40 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(1339, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1419, 51, false);
#line 43 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.PlaceOfAccident));

#line default
#line hidden
            EndContext();
            BeginContext(1470, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1550, 50, false);
#line 46 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.DateOfAccident));

#line default
#line hidden
            EndContext();
            BeginContext(1600, 253, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        Insured\r\n                    </th>\r\n                    <th>\r\n                        Claimable\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1854, 50, false);
#line 55 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.CustomerPolicy));

#line default
#line hidden
            EndContext();
            BeginContext(1904, 303, true);
            WriteLiteral(@"
                    </th>
                    <th>
                        Claim Handler
                    </th>
                    <th>
                        Status
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 67 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(2272, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2357, 47, false);
#line 71 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PolicyNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2404, 121, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2526, 47, false);
#line 75 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(2573, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2665, 50, false);
#line 78 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PlaceOfAccident));

#line default
#line hidden
            EndContext();
            BeginContext(2715, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2807, 43, false);
#line 81 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(item.DateOfAccident.ToString("dd MMM yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(2850, 92, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            $");
            EndContext();
            BeginContext(2943, 47, false);
#line 84 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                        Write(Html.DisplayFor(modelItem => item.InsuredAmout));

#line default
#line hidden
            EndContext();
            BeginContext(2990, 92, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            $");
            EndContext();
            BeginContext(3083, 49, false);
#line 87 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                        Write(Html.DisplayFor(modelItem => item.ClaimableAmout));

#line default
#line hidden
            EndContext();
            BeginContext(3132, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3224, 66, false);
#line 90 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CustomerPolicy.CustomerPolicyId));

#line default
#line hidden
            EndContext();
            BeginContext(3290, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3382, 50, false);
#line 93 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Admin.AdminName));

#line default
#line hidden
            EndContext();
            BeginContext(3432, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 96 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                             if (item.Status == 0)
                            {

#line default
#line hidden
            BeginContext(3578, 54, true);
            WriteLiteral("                                <span>Pending</span>\r\n");
            EndContext();
#line 99 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                            }
                            else if (item.Status == 1)
                            {

#line default
#line hidden
            BeginContext(3750, 59, true);
            WriteLiteral("                                <span>Progressing </span>\r\n");
            EndContext();
#line 103 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(3905, 56, true);
            WriteLiteral("                                <span>Completed</span>\r\n");
            EndContext();
#line 107 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(3992, 58, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 110 "C:\Users\KyThuat88\Downloads\EProjectSEMIII (4)\EProjectSEMIII\EProjectSEMIII\Views\ClaimDetail\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(4069, 76, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</section>\r\n        \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EProjectSEMIII.Models.ClaimDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
