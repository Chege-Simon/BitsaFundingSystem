#pragma checksum "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Stop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2fb29193c804084b767fb7a52e3360b1b8c0b38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BitsaFundingSystem.Pages.Pages_Stop), @"mvc.1.0.razor-page", @"/Pages/Stop.cshtml")]
namespace BitsaFundingSystem.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2fb29193c804084b767fb7a52e3360b1b8c0b38", @"/Pages/Stop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09935f09b2f479a5d106a7bd082a459aae2570c0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Stop : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Stop.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n\r\n\r\n\r\n\r\n<br />\r\n\r\n<br />\r\n\r\n<br />\r\n\r\n<br />\r\n");
#nullable restore
#line 22 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Stop.cshtml"
Write(Model.StopServer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StopModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StopModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StopModel>)PageContext?.ViewData;
        public StopModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591