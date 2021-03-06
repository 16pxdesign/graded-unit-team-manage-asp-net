#pragma checksum "D:\github\Application\Views\Game\_ScoreTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93fc8a4cb1553d48011ff78275e8494bb232237e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game__ScoreTable), @"mvc.1.0.view", @"/Views/Game/_ScoreTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/_ScoreTable.cshtml", typeof(AspNetCore.Views_Game__ScoreTable))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93fc8a4cb1553d48011ff78275e8494bb232237e", @"/Views/Game/_ScoreTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ea476b5db410d4405042b0a5ed991b4e6710c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Game__ScoreTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 56, true);
            WriteLiteral("\r\n <table id=\"ScoresTable\" class=\"table mt-1\" data-url=\"");
            EndContext();
            BeginContext(79, 28, false);
#line 3 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                 Write(Url.Action("ModalFillTable"));

#line default
#line hidden
            EndContext();
            BeginContext(107, 241, true);
            WriteLiteral("\">\r\n        <thead>\r\n        <tr>\r\n            <th>Half</th>\r\n            <th>Time</th>\r\n            <th>Team</th>\r\n            <th>Points</th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 15 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
         for (var i = 0; i < Model.Scores.Count; i++)
        {

#line default
#line hidden
            BeginContext(414, 40, true);
            WriteLiteral("            <tr>\r\n                <input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 454, "\'", 476, 3);
            WriteAttributeValue("", 461, "Scores[", 461, 7, true);
#line 18 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 468, i, 468, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 472, "].Id", 472, 4, true);
            EndWriteAttribute();
            BeginContext(477, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 491, "\'", 518, 1);
#line 18 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 499, Model.Scores[i].Id, 499, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(519, 48, true);
            WriteLiteral("/>\r\n                \r\n                <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 567, "\'", 591, 3);
            WriteAttributeValue("", 574, "Scores[", 574, 7, true);
#line 20 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 581, i, 581, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 585, "].Half", 585, 6, true);
            EndWriteAttribute();
            BeginContext(592, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 606, "\'", 635, 1);
#line 20 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 614, Model.Scores[i].Half, 614, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(636, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(639, 20, false);
#line 20 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                            Write(Model.Scores[i].Half);

#line default
#line hidden
            EndContext();
            BeginContext(659, 33, true);
            WriteLiteral("</td>\r\n                <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 692, "\'", 716, 3);
            WriteAttributeValue("", 699, "Scores[", 699, 7, true);
#line 21 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 706, i, 706, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 710, "].Time", 710, 6, true);
            EndWriteAttribute();
            BeginContext(717, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 731, "\'", 760, 1);
#line 21 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 739, Model.Scores[i].Time, 739, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(761, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(764, 34, false);
#line 21 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                            Write(Model.Scores[i].Time.ToString("t"));

#line default
#line hidden
            EndContext();
            BeginContext(798, 33, true);
            WriteLiteral("</td>\r\n                <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 831, "\'", 855, 3);
            WriteAttributeValue("", 838, "Scores[", 838, 7, true);
#line 22 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 845, i, 845, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 849, "].Team", 849, 6, true);
            EndWriteAttribute();
            BeginContext(856, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 870, "\'", 899, 1);
#line 22 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 878, Model.Scores[i].Team, 878, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(900, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(903, 20, false);
#line 22 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                            Write(Model.Scores[i].Team);

#line default
#line hidden
            EndContext();
            BeginContext(923, 33, true);
            WriteLiteral("</td>\r\n                <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 956, "\'", 982, 3);
            WriteAttributeValue("", 963, "Scores[", 963, 7, true);
#line 23 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 970, i, 970, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 974, "].Points", 974, 8, true);
            EndWriteAttribute();
            BeginContext(983, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 997, "\'", 1028, 1);
#line 23 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 1005, Model.Scores[i].Points, 1005, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1029, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(1032, 22, false);
#line 23 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                                Write(Model.Scores[i].Points);

#line default
#line hidden
            EndContext();
            BeginContext(1054, 158, true);
            WriteLiteral("</td>\r\n                \r\n            \r\n                \r\n\r\n                <!-- Buttons -->\r\n\r\n                <td>\r\n                    <button type=\"button\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1212, "\"", 1237, 3);
            WriteAttributeValue("", 1217, "Scores[", 1217, 7, true);
#line 31 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 1224, i, 1224, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1228, "]_editBtn", 1228, 9, true);
            EndWriteAttribute();
            BeginContext(1238, 57, true);
            WriteLiteral(" class=\"btn btn-link\" data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(1296, 36, false);
#line 31 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                                                       Write(Url.Action("AddScore", new {id = i}));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 176, true);
            WriteLiteral("\">\r\n                        <i class=\"fas fa-edit\"></i>\r\n                    </button>\r\n                </td>\r\n                <td>\r\n                    <button data-deleteid=\"");
            EndContext();
            BeginContext(1510, 1, false);
#line 36 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                       Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1512, 72, true);
            WriteLiteral("\" class=\'btn btn-link text-danger\' data-toggle=\"ScoresDelete\" data-url=\"");
            EndContext();
            BeginContext(1585, 25, false);
#line 36 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                                                  Write(Url.Action("DeleteScore"));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 135, true);
            WriteLiteral("\">\r\n                        <i class=\'fas fa-trash-alt\'></i>\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 41 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
            
            if (Model.Scores[i].Comment != null)
             {

#line default
#line hidden
            BeginContext(1825, 39, true);
            WriteLiteral("             <tr><td colspan=\"4\"><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1864, "\'", 1891, 3);
            WriteAttributeValue("", 1871, "Scores[", 1871, 7, true);
#line 44 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 1878, i, 1878, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1882, "].Comment", 1882, 9, true);
            EndWriteAttribute();
            BeginContext(1892, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1906, "\'", 1938, 1);
#line 44 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
WriteAttributeValue("", 1914, Model.Scores[i].Comment, 1914, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1939, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(1942, 23, false);
#line 44 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
                                                                                                               Write(Model.Scores[i].Comment);

#line default
#line hidden
            EndContext();
            BeginContext(1965, 12, true);
            WriteLiteral("</td></tr>\r\n");
            EndContext();
#line 45 "D:\github\Application\Views\Game\_ScoreTable.cshtml"
             }
        }

#line default
#line hidden
            BeginContext(2004, 26, true);
            WriteLiteral("\r\n        </tbody></table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
