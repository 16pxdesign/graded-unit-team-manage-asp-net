#pragma checksum "D:\github\Application\Views\Partial\Display\Attendance.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38a57852abd48b8b7adb37baf3933e9f260e45ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partial_Display_Attendance), @"mvc.1.0.view", @"/Views/Partial/Display/Attendance.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Partial/Display/Attendance.cshtml", typeof(AspNetCore.Views_Partial_Display_Attendance))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38a57852abd48b8b7adb37baf3933e9f260e45ff", @"/Views/Partial/Display/Attendance.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ea476b5db410d4405042b0a5ed991b4e6710c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Partial_Display_Attendance : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MemberViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
 if (Model != null && Model.Count > 0)
{

#line default
#line hidden
            BeginContext(75, 62, true);
            WriteLiteral("    <div class=\"card mt-3\">\r\n        <div class=\"card-body\">\r\n");
            EndContext();
#line 7 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(194, 103, true);
            WriteLiteral("                <dl class=\"row\">\r\n\r\n                    <dd class=\"col-sm-3\">\r\n                        ");
            EndContext();
            BeginContext(298, 13, false);
#line 12 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
                   Write(item.Fullname);

#line default
#line hidden
            EndContext();
            BeginContext(311, 54, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                </dl>\r\n");
            EndContext();
#line 16 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
            }

#line default
#line hidden
            BeginContext(380, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
#line 19 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
}
else
{
    

#line default
#line hidden
            BeginContext(426, 23, false);
#line 22 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
Write("Nobody been attendant");

#line default
#line hidden
            EndContext();
#line 22 "D:\github\Application\Views\Partial\Display\Attendance.cshtml"
                              
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MemberViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
