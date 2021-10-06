#pragma checksum "D:\github\Application\Views\Training\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ca5e1db16e68f6de3ff200e40de43dfd20290bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Training_Index), @"mvc.1.0.view", @"/Views/Training/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Training/Index.cshtml", typeof(AspNetCore.Views_Training_Index))]
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
#line 1 "D:\github\Application\Views\Training\Index.cshtml"
using Application.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ca5e1db16e68f6de3ff200e40de43dfd20290bc", @"/Views/Training/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ea476b5db410d4405042b0a5ed991b4e6710c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Training_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TrainingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\github\Application\Views\Training\Index.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(123, 146, true);
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-title text-center mt-4\"><h4 class=\"\">Trainings list</h4></div>\r\n    <div class=\"card-body\">\r\n\r\n        ");
            EndContext();
            BeginContext(269, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ca5e1db16e68f6de3ff200e40de43dfd20290bc4135", async() => {
                BeginContext(293, 7, true);
                WriteLiteral("Add new");
                EndContext();
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
            EndContext();
            BeginContext(304, 314, true);
            WriteLiteral(@"
        <table id=""TrainingsList"" class=""table mt-1"">
            <thead>
            <tr>
                <th>Date</th>
                <th>Time</th>
                <th>Coach</th>
                <th>Location</th>
                <th></th>
            </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 25 "D:\github\Application\Views\Training\Index.cshtml"
             if (Model != null)
            {
                foreach (var item in Model) {

#line default
#line hidden
            BeginContext(713, 94, true);
            WriteLiteral("                     <tr>\r\n                         <td>\r\n                             <label>");
            EndContext();
            BeginContext(808, 32, false);
#line 30 "D:\github\Application\Views\Training\Index.cshtml"
                               Write(item.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(840, 120, true);
            WriteLiteral("</label>           \r\n                         </td>\r\n                         <td>\r\n                             <label>");
            EndContext();
            BeginContext(961, 27, false);
#line 33 "D:\github\Application\Views\Training\Index.cshtml"
                               Write(item.Time.ToString("HH:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(988, 109, true);
            WriteLiteral("</label>\r\n                         </td>\r\n                         <td>\r\n                             <label>");
            EndContext();
#line 36 "D:\github\Application\Views\Training\Index.cshtml"
                                     if(item.Coach!=null) {

#line default
#line hidden
            BeginContext(1121, 19, false);
#line 36 "D:\github\Application\Views\Training\Index.cshtml"
                                                      Write(item.Coach.Fullname);

#line default
#line hidden
            EndContext();
#line 36 "D:\github\Application\Views\Training\Index.cshtml"
                                                                               }

#line default
#line hidden
            BeginContext(1141, 109, true);
            WriteLiteral("</label>\r\n                         </td>\r\n                         <td>\r\n                             <label>");
            EndContext();
            BeginContext(1251, 13, false);
#line 39 "D:\github\Application\Views\Training\Index.cshtml"
                               Write(item.Location);

#line default
#line hidden
            EndContext();
            BeginContext(1264, 155, true);
            WriteLiteral("</label>\r\n                         </td>\r\n                   \r\n           \r\n                         <td class=\"text-right\">\r\n                             ");
            EndContext();
            BeginContext(1419, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ca5e1db16e68f6de3ff200e40de43dfd20290bc8399", async() => {
                BeginContext(1464, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 44 "D:\github\Application\Views\Training\Index.cshtml"
                                                    WriteLiteral(item.Id);

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
            BeginContext(1472, 35, true);
            WriteLiteral(" |\r\n                             <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1507, "\"", 1566, 1);
#line 45 "D:\github\Application\Views\Training\Index.cshtml"
WriteAttributeValue("", 1514, Url.Action("Details","Training", new{id = item.Id}), 1514, 52, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1567, 47, true);
            WriteLiteral(">Details</a> |\r\n                             <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1614, "\"", 1673, 1);
#line 46 "D:\github\Application\Views\Training\Index.cshtml"
WriteAttributeValue("", 1621, Url.Action("Delete","Training", new{id  = item.Id}), 1621, 52, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1674, 75, true);
            WriteLiteral(">Delete</a> |\r\n                         </td>\r\n                     </tr>\r\n");
            EndContext();
#line 49 "D:\github\Application\Views\Training\Index.cshtml"
                 }
            }

#line default
#line hidden
            BeginContext(1784, 81, true);
            WriteLiteral("           \r\n    \r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TrainingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
