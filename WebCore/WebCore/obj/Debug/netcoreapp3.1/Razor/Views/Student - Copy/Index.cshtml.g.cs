#pragma checksum "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0accb997ce640eefcd620755d20cfb7e6df6114"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student___Copy_Index), @"mvc.1.0.view", @"/Views/Student - Copy/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Ayushi\demo\WebCore\WebCore\Views\_ViewImports.cshtml"
using WebCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Ayushi\demo\WebCore\WebCore\Views\_ViewImports.cshtml"
using WebCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Ayushi\demo\WebCore\WebCore\Views\_ViewImports.cshtml"
using WebCore.Filters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
using ModelsCoreProject;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0accb997ce640eefcd620755d20cfb7e6df6114", @"/Views/Student - Copy/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba526bbe728d410ec56656a1a72ab617e2e1523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Student___Copy_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebCoreEntities.Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
  
    List<WebCoreEntities.Student> lStudent = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"section\">\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            User List\r\n        </div>\r\n        <div class=\"card-body\">\r\n          ");
#nullable restore
#line 19 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
     Write(Html.Partial("search"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            ");
#nullable restore
#line 21 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
       Write(Html.ActionLink("Create","Add"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <table class=\"table table-striped\" id=\"table1\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Edit </th>\r\n\r\n                        <th><a id=\"a1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 607, "\"", 647, 3);
            WriteAttributeValue("", 617, "gotTo(\'id\',\'", 617, 12, true);
#nullable restore
#line 27 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 629, ViewBag.orderBy, 629, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 645, "\')", 645, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 648, "\"", 708, 2);
            WriteAttributeValue("", 655, "/student/Index?columnName=id&orderBy=", 655, 37, true);
#nullable restore
#line 27 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 692, ViewBag.orderBy, 692, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Id</a>  </th>\r\n                        <th><a");
            BeginWriteAttribute("onclick", " onclick=\"", 755, "\"", 802, 3);
            WriteAttributeValue("", 765, "gotTo(\'FirstName\',\'", 765, 19, true);
#nullable restore
#line 28 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 784, ViewBag.orderBy, 784, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 800, "\')", 800, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 803, "\"", 870, 2);
            WriteAttributeValue("", 810, "/student/Index?columnName=firstName&orderBy=", 810, 44, true);
#nullable restore
#line 28 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 854, ViewBag.orderBy, 854, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">First Name</a>  </th>\r\n\r\n\r\n                        <th><a");
            BeginWriteAttribute("onclick", " onclick=\"", 929, "\"", 975, 3);
            WriteAttributeValue("", 939, "gotTo(\'LastName\',\'", 939, 18, true);
#nullable restore
#line 31 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 957, ViewBag.orderBy, 957, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 973, "\')", 973, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 976, "\"", 1042, 2);
            WriteAttributeValue("", 983, "/student/Index?columnName=lastName&orderBy=", 983, 43, true);
#nullable restore
#line 31 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1026, ViewBag.orderBy, 1026, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Last Name</a>  </th>\r\n\r\n                        <th><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1098, "\"", 1147, 3);
            WriteAttributeValue("", 1108, "gotTo(\'SubjectName\',\'", 1108, 21, true);
#nullable restore
#line 33 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1129, ViewBag.orderBy, 1129, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1145, "\')", 1145, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1148, "\"", 1213, 2);
            WriteAttributeValue("", 1155, "/student/Index?columnName=subject&orderBy=", 1155, 42, true);
#nullable restore
#line 33 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1197, ViewBag.orderBy, 1197, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Subject</a>  </th>\r\n\r\n                        <th><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1267, "\"", 1308, 3);
            WriteAttributeValue("", 1277, "gotTo(\'age\',\'", 1277, 13, true);
#nullable restore
#line 35 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1290, ViewBag.orderBy, 1290, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1306, "\')", 1306, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1309, "\"", 1369, 2);
            WriteAttributeValue("", 1316, "/student/Index?columnName=id&orderBy=", 1316, 37, true);
#nullable restore
#line 35 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1353, ViewBag.orderBy, 1353, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Age</a>  </th>\r\n\r\n                        <th>Fees</th>\r\n                        <th>Active</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n\r\n");
#nullable restore
#line 43 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                     for (int i = 0; i < lStudent.Count; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 1691, "\"", 1727, 2);
            WriteAttributeValue("", 1698, "/student/edit/", 1698, 14, true);
#nullable restore
#line 46 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
WriteAttributeValue("", 1712, lStudent[i].Id, 1712, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                        <td>");
#nullable restore
#line 47 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i].FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 49 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i].LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 50 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i]?.Subject?.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 51 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i].Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 52 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                       Write(lStudent[i].Fees);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 54 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                         if (lStudent[i].Active.HasValue && lStudent[i].Active.Value)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <span class=\"badge bg-success\">Active</span>\r\n                            </td>\r\n");
#nullable restore
#line 59 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <span class=\"badge bg-danger\">In-active</span>\r\n                            </td>\r\n");
#nullable restore
#line 65 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tr>\r\n");
#nullable restore
#line 68 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n\r\n         ");
#nullable restore
#line 75 "D:\Ayushi\demo\WebCore\WebCore\Views\Student - Copy\Index.cshtml"
    Write(Html.Partial("Pagination"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n</section>\r\n\r\n \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebCoreEntities.Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
