#pragma checksum "D:\github\Application\Views\Member\_GuardianTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1fbf3b9168c72091715a00443bf5b72b084271d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member__GuardianTable), @"mvc.1.0.view", @"/Views/Member/_GuardianTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Member/_GuardianTable.cshtml", typeof(AspNetCore.Views_Member__GuardianTable))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1fbf3b9168c72091715a00443bf5b72b084271d", @"/Views/Member/_GuardianTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ea476b5db410d4405042b0a5ed991b4e6710c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Member__GuardianTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JuniorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 57, true);
            WriteLiteral("\r\n<table id=\"GuardianTable\" class=\"table mt-1\" data-url=\"");
            EndContext();
            BeginContext(82, 28, false);
#line 3 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                  Write(Url.Action("ModalFillTable"));

#line default
#line hidden
            EndContext();
            BeginContext(110, 178, true);
            WriteLiteral("\">\r\n    <thead>\r\n    <tr>\r\n        <th>Guardian</th>\r\n        <th>Signature Date</th>\r\n        <th>Edit</th>\r\n        <th>Delete</th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n   \r\n");
            EndContext();
#line 14 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
     for (var i = 0; i < Model.Guardians.Count; i++)
    {

#line default
#line hidden
            BeginContext(349, 32, true);
            WriteLiteral("        <tr>\r\n            <input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 381, "\'", 420, 3);
            WriteAttributeValue("", 388, "Player.Junior.Guardians[", 388, 24, true);
#line 17 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 412, i, 412, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 416, "].Id", 416, 4, true);
            EndWriteAttribute();
            BeginContext(421, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 435, "\'", 465, 1);
#line 17 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 443, Model.Guardians[i].Id, 443, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(466, 26, true);
            WriteLiteral("/>\r\n            <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 492, "\'", 533, 3);
            WriteAttributeValue("", 499, "Player.Junior.Guardians[", 499, 24, true);
#line 18 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 523, i, 523, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 527, "].Name", 527, 6, true);
            EndWriteAttribute();
            BeginContext(534, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 548, "\'", 580, 1);
#line 18 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 556, Model.Guardians[i].Name, 556, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(581, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(584, 23, false);
#line 18 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                            Write(Model.Guardians[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(607, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(609, 26, false);
#line 18 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                                                     Write(Model.Guardians[i].Surname);

#line default
#line hidden
            EndContext();
            BeginContext(635, 51, true);
            WriteLiteral("</td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 686, "\'", 730, 3);
            WriteAttributeValue("", 693, "Player.Junior.Guardians[", 693, 24, true);
#line 19 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 717, i, 717, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 721, "].Surname", 721, 9, true);
            EndWriteAttribute();
            BeginContext(731, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 745, "\'", 780, 1);
#line 19 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 753, Model.Guardians[i].Surname, 753, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(781, 53, true);
            WriteLiteral("/></td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 834, "\'", 876, 3);
            WriteAttributeValue("", 841, "Player.Junior.Guardians[", 841, 24, true);
#line 20 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 865, i, 865, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 869, "].Phone", 869, 7, true);
            EndWriteAttribute();
            BeginContext(877, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 891, "\'", 924, 1);
#line 20 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 899, Model.Guardians[i].Phone, 899, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(925, 53, true);
            WriteLiteral("/></td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 978, "\'", 1027, 3);
            WriteAttributeValue("", 985, "Player.Junior.Guardians[", 985, 24, true);
#line 21 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1009, i, 1009, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1013, "].Relationship", 1013, 14, true);
            EndWriteAttribute();
            BeginContext(1028, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1042, "\'", 1082, 1);
#line 21 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1050, Model.Guardians[i].Relationship, 1050, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1083, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(1086, 31, false);
#line 21 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                                                                  Write(Model.Guardians[i].Relationship);

#line default
#line hidden
            EndContext();
            BeginContext(1117, 29, true);
            WriteLiteral("</td>\r\n            <td><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1146, "\'", 1192, 3);
            WriteAttributeValue("", 1153, "Player.Junior.Guardians[", 1153, 24, true);
#line 22 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1177, i, 1177, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1181, "].Signature", 1181, 11, true);
            EndWriteAttribute();
            BeginContext(1193, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1207, "\'", 1244, 1);
#line 22 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1215, Model.Guardians[i].Signature, 1215, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1245, 2, true);
            WriteLiteral("/>");
            EndContext();
            BeginContext(1248, 51, false);
#line 22 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                                      Write(Model.Guardians[i].Signature.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 51, true);
            WriteLiteral("</td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1350, "\'", 1399, 3);
            WriteAttributeValue("", 1357, "Player.Junior.Guardians[", 1357, 24, true);
#line 23 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1381, i, 1381, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1385, "].Address.Flat", 1385, 14, true);
            EndWriteAttribute();
            BeginContext(1400, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1414, "\'", 1454, 1);
#line 23 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1422, Model.Guardians[i].Address.Flat, 1422, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1455, 53, true);
            WriteLiteral("/></td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1508, "\'", 1559, 3);
            WriteAttributeValue("", 1515, "Player.Junior.Guardians[", 1515, 24, true);
#line 24 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1539, i, 1539, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1543, "].Address.Street", 1543, 16, true);
            EndWriteAttribute();
            BeginContext(1560, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1574, "\'", 1616, 1);
#line 24 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1582, Model.Guardians[i].Address.Street, 1582, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1617, 53, true);
            WriteLiteral("/></td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1670, "\'", 1719, 3);
            WriteAttributeValue("", 1677, "Player.Junior.Guardians[", 1677, 24, true);
#line 25 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1701, i, 1701, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1705, "].Address.City", 1705, 14, true);
            EndWriteAttribute();
            BeginContext(1720, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1734, "\'", 1774, 1);
#line 25 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1742, Model.Guardians[i].Address.City, 1742, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1775, 53, true);
            WriteLiteral("/></td>\r\n            <td style=\'display: none\'><input");
            EndContext();
            BeginWriteAttribute("name", " name=\'", 1828, "\'", 1881, 3);
            WriteAttributeValue("", 1835, "Player.Junior.Guardians[", 1835, 24, true);
#line 26 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1859, i, 1859, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1863, "].Address.Postcode", 1863, 18, true);
            EndWriteAttribute();
            BeginContext(1882, 14, true);
            WriteLiteral(" type=\'hidden\'");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1896, "\'", 1940, 1);
#line 26 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 1904, Model.Guardians[i].Address.Postcode, 1904, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1941, 82, true);
            WriteLiteral("/></td>\r\n\r\n\r\n            <!-- Buttons -->\r\n\r\n            <td><button type=\"button\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2023, "\"", 2050, 3);
            WriteAttributeValue("", 2028, "Guardian[", 2028, 9, true);
#line 31 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
WriteAttributeValue("", 2037, i, 2037, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 2041, "]_editBtn", 2041, 9, true);
            EndWriteAttribute();
            BeginContext(2051, 57, true);
            WriteLiteral(" class=\"btn btn-link\" data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(2109, 39, false);
#line 31 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                                     Write(Url.Action("AddGuardian", new {id = i}));

#line default
#line hidden
            EndContext();
            BeginContext(2148, 84, true);
            WriteLiteral("\"><i class=\"fas fa-edit\"></i></button></td>\r\n            <td><button data-deleteid=\"");
            EndContext();
            BeginContext(2234, 1, false);
#line 32 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                   Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(2236, 74, true);
            WriteLiteral("\" class=\'btn btn-link text-danger\' data-toggle=\"GuardianDelete\" data-url=\"");
            EndContext();
            BeginContext(2311, 38, false);
#line 32 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
                                                                                                                Write(Url.Action("DeleteGuardian", "Member"));

#line default
#line hidden
            EndContext();
            BeginContext(2349, 65, true);
            WriteLiteral("\"><i class=\'fas fa-trash-alt\'></i></button></td>\r\n        </tr>\r\n");
            EndContext();
#line 34 "D:\github\Application\Views\Member\_GuardianTable.cshtml"
    }

#line default
#line hidden
            BeginContext(2421, 36, true);
            WriteLiteral("    \r\n\r\n\r\n\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JuniorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591