#pragma checksum "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1175b22004c585003ff15f48dae6d8261076f044"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BitsaFundingSystem.Pages.Pages_Connect), @"mvc.1.0.razor-page", @"/Pages/Connect.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1175b22004c585003ff15f48dae6d8261076f044", @"/Pages/Connect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09935f09b2f479a5d106a7bd082a459aae2570c0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Connect : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
  
    ViewData["Title"] = "Connect";
    Layout = "~/Pages/Shared/AdminLTE/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 8 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
 foreach (var server in Model.ConnectedServers)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 10 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
  Write(server);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 11 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 14 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
 foreach (var block in Model.Chain.Chain)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>**********************************************</p>\r\n");
#nullable restore
#line 17 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
Write(block.Index);

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
Write(block.Hash);

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
Write(block.PreviousHash);

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
Write(block.TimeStamp);

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
     foreach (var transaction in block.Transactions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>>>>></p>\r\n");
#nullable restore
#line 24 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
   Write(transaction.FromAddress);

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
   Write(transaction.ToAddress);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
   Write(transaction.Amount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
                           
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>**********************************************</p>\r\n");
#nullable restore
#line 30 "C:\Users\geneva\source\repos\BitsaFundingSystem\BitsaFundingSystem\Pages\Connect.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BitsaFundingSystem.Pages.KimCoin.ConnectModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BitsaFundingSystem.Pages.KimCoin.ConnectModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BitsaFundingSystem.Pages.KimCoin.ConnectModel>)PageContext?.ViewData;
        public BitsaFundingSystem.Pages.KimCoin.ConnectModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
