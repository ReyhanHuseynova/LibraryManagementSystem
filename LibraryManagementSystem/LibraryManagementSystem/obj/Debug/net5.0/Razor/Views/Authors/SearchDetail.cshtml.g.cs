#pragma checksum "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d03a271f640999dcbd4b9e1119a2205c83138fe4c14f4c977451dde0892f5c53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authors_SearchDetail), @"mvc.1.0.view", @"/Views/Authors/SearchDetail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\_ViewImports.cshtml"
using LibraryManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\_ViewImports.cshtml"
using LibraryManagementSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\_ViewImports.cshtml"
using LibraryManagementSystem.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d03a271f640999dcbd4b9e1119a2205c83138fe4c14f4c977451dde0892f5c53", @"/Views/Authors/SearchDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"2f94f05e96772f5cce9e800f7f12b961575fbe9e2f9e6f1c4485a4b5be0dd2bd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Authors_SearchDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Author>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
  
    ViewData["Title"] = "SearchDetail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-dark"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Book Name</th>
            <th scope=""col"">Author Name</th>
            <th scope=""col"">Author Last Name</th>
         
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 19 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
         foreach (var author in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 22 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
                           Write(author.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
               Write(author.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
               Write(author.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
               Write(author.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\ACER\OneDrive\İş masası\GitProjects\LibraryGit\LibraryManagementSystem\LibraryManagementSystem\LibraryManagementSystem\Views\Authors\SearchDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Author>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
