#pragma checksum "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "059d76474c469204be305f3d833913daf5466d78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Pagination), @"mvc.1.0.view", @"/Views/Shared/Pagination.cshtml")]
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
#line 1 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
using ModelsCoreProject;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"059d76474c469204be305f3d833913daf5466d78", @"/Views/Shared/Pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba526bbe728d410ec56656a1a72ab617e2e1523a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
  

    Pagination pagination = ViewBag.pagination;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination\">\r\n\r\n");
#nullable restore
#line 10 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
         if (pagination.CurrentPage <= 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li disabled class=\"page-item\"><a disabled");
            BeginWriteAttribute("onclick", " onclick=\"", 270, "\"", 323, 3);
            WriteAttributeValue("", 280, "goToPageDisable(", 280, 16, true);
#nullable restore
#line 12 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 296, pagination.CurrentPage, 296, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 319, "-1)", 320, 4, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">Previous</a></li>\r\n");
#nullable restore
#line 13 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a");
            BeginWriteAttribute("onclick", " onclick=\"", 443, "\"", 489, 3);
            WriteAttributeValue("", 453, "goToPage(", 453, 9, true);
#nullable restore
#line 16 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 462, pagination.CurrentPage, 462, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 485, "-1)", 486, 4, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">Previous</a></li>\r\n");
#nullable restore
#line 17 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
         foreach (var item in pagination.Pages)
        {
            if (item == pagination.CurrentPage)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item active\"><a");
            BeginWriteAttribute("onclick", " onclick=\"", 723, "\"", 748, 3);
            WriteAttributeValue("", 733, "goToPage(", 733, 9, true);
#nullable restore
#line 24 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 742, item, 742, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 747, ")", 747, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">");
#nullable restore
#line 24 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
                                                                                                Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 25 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\"><a");
            BeginWriteAttribute("onclick", " onclick=\"", 881, "\"", 906, 3);
            WriteAttributeValue("", 891, "goToPage(", 891, 9, true);
#nullable restore
#line 28 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 900, item, 900, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 905, ")", 905, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">");
#nullable restore
#line 28 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
                                                                                         Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 29 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 33 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
         if (pagination.CurrentPage >= pagination.Pages.Count)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li disabled class=\"page-item\"><a disabled");
            BeginWriteAttribute("onclick", " onclick=\"", 1110, "\"", 1162, 3);
            WriteAttributeValue("", 1120, "goToPageDisable(", 1120, 16, true);
#nullable restore
#line 35 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 1136, pagination.CurrentPage, 1136, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1159, "+1)", 1159, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">Next</a></li>\r\n");
#nullable restore
#line 36 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1278, "\"", 1323, 3);
            WriteAttributeValue("", 1288, "goToPage(", 1288, 9, true);
#nullable restore
#line 39 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"
WriteAttributeValue("", 1297, pagination.CurrentPage, 1297, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1320, "+1)", 1320, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"page-link\" href=\"#\">Next</a></li>\r\n");
#nullable restore
#line 40 "D:\Ayushi\demo\WebCore\WebCore\Views\Shared\Pagination.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </ul>\r\n</nav>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
