#pragma checksum "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fdce25fbf7cba208e3ffe30fe920551f3520495"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BitsaFundingSystem.Pages.KimCoin.Users.Pages_KimCoin_Users_Users), @"mvc.1.0.razor-page", @"/Pages/KimCoin/Users/Users.cshtml")]
namespace BitsaFundingSystem.Pages.KimCoin.Users
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
#line 1 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\_ViewImports.cshtml"
using BitsaFundingSystem;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fdce25fbf7cba208e3ffe30fe920551f3520495", @"/Pages/KimCoin/Users/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09935f09b2f479a5d106a7bd082a459aae2570c0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_KimCoin_Users_Users : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
  
    ViewData["Title"] = "Users";
    Layout = "~/Pages/Shared/AdminLTE/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header row\">\r\n        <h3 class=\"card-title col-md-10\">Users</h3>\r\n        <span class=\"col-md-2\">\r\n");
            WriteLiteral(@"        </span>
    </div>
    <!-- /.card-header -->
    <div class=""card-body"">
        <table id=""datatable"" class=""table table-bordered table-hover"">
            <thead class=""thead-dark"">
                <tr>
                    <th>
                        ");
#nullable restore
#line 22 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].First_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 28 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Middle_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 31 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Last_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 34 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 37 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 40 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 43 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayNameFor(model => model.BitsaFundingSystemUsers[0].WalletId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        Action\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 51 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                 foreach (var item in Model.BitsaFundingSystemUsers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.First_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Middle_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Last_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 67 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 70 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 73 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                   Write(Html.DisplayFor(modelItem => item.WalletId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fdce25fbf7cba208e3ffe30fe920551f352049510686", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-email", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                                                     WriteLiteral(item.Email);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-email", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 82 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 90 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\KimCoin\Users\Users.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BitsaFundingSystem.Pages.KimCoin.Users.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BitsaFundingSystem.Pages.KimCoin.Users.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BitsaFundingSystem.Pages.KimCoin.Users.IndexModel>)PageContext?.ViewData;
        public BitsaFundingSystem.Pages.KimCoin.Users.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
