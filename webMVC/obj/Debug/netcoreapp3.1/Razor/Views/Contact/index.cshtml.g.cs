#pragma checksum "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc3864b0cdea26e240464d9be80a1d6089d1a753"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_index), @"mvc.1.0.view", @"/Views/Contact/index.cshtml")]
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
#line 1 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/_ViewImports.cshtml"
using webMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/_ViewImports.cshtml"
using webMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc3864b0cdea26e240464d9be80a1d6089d1a753", @"/Views/Contact/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568279c93ba1454296bd850f1d7a34de6612925f", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<webMVC.Models.ContactData>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
      
    ViewBag.Title = "Contact";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Contacts</h2>

<a class=""btn btn-primary"" href=""/Contact/Create"" role=""button"">Create</a>

<table class=""table"">
    <tr>
        <th scope=""col"">#</th>
        <th scope=""col"">Id</th>
        <th scope=""col"">FirstName</th>
        <th scope=""col"">LastName</th>
        <th scope=""col"">Email</th>
        <th scope=""col"">Mobile</th>
        <th scope=""col"">Action</th>
    </tr>
");
#nullable restore
#line 23 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
     for(int i = 0; i < Model.Count; i++)
    {
        var item = Model[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 27 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
            Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 28 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 29 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 30 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 31 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 32 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
           Write(item.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 835, "\"", 855, 2);
            WriteAttributeValue("", 842, "Edit/", 842, 5, true);
#nullable restore
#line 33 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
WriteAttributeValue("", 847, item.Id, 847, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pen\"></i></a> <a");
            BeginWriteAttribute("href", " href=\"", 889, "\"", 911, 2);
            WriteAttributeValue("", 896, "Delete/", 896, 7, true);
#nullable restore
#line 33 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
WriteAttributeValue("", 903, item.Id, 903, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash\"></i></a></td>\n        </tr>\n");
#nullable restore
#line 35 "/Volumes/Data/Work/outsource/indentity_server/webMVC/Views/Contact/index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<webMVC.Models.ContactData>> Html { get; private set; }
    }
}
#pragma warning restore 1591
