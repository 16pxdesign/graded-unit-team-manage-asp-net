#pragma checksum "D:\github\Application\Views\Partial\Display\Player.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1757e04dbaa528f43935873d09a5a7bba2b1f0e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partial_Display_Player), @"mvc.1.0.view", @"/Views/Partial/Display/Player.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Partial/Display/Player.cshtml", typeof(AspNetCore.Views_Partial_Display_Player))]
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
#line 1 "D:\github\Application\Views\_ViewImports.cshtml"
using Application;

#line default
#line hidden
#line 2 "D:\github\Application\Views\_ViewImports.cshtml"
using Application.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1757e04dbaa528f43935873d09a5a7bba2b1f0e1", @"/Views/Partial/Display/Player.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ea476b5db410d4405042b0a5ed991b4e6710c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Partial_Display_Player : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PlayerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 55, true);
            WriteLiteral("\r\n<dl class=\"row\">\r\n    <dt class=\"col-sm-3\">\r\n        ");
            EndContext();
            BeginContext(80, 30, false);
#line 5 "D:\github\Application\Views\Partial\Display\Player.cshtml"
   Write(Html.LabelFor(m => m.Position));

#line default
#line hidden
            EndContext();
            BeginContext(110, 48, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-9\">\r\n        ");
            EndContext();
            BeginContext(159, 40, false);
#line 8 "D:\github\Application\Views\Partial\Display\Player.cshtml"
   Write(Html.DisplayFor(model => model.Position));

#line default
#line hidden
            EndContext();
            BeginContext(199, 20, true);
            WriteLiteral("\r\n    </dd>\r\n\r\n</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PlayerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
