#pragma checksum "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a3a3307c4acfb8f9fd9aea3e340524fce0eb94e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
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
#line 1 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\_ViewImports.cshtml"
using BoothackForum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\_ViewImports.cshtml"
using BoothackForum.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a3a3307c4acfb8f9fd9aea3e340524fce0eb94e", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556adb8890c9d4d5fdce9554c71826827cd60737", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BoothackForum.Models.PostModel.PostIndexModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n <div>\r\n     Author: ");
#nullable restore
#line 6 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
        Write(Model.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 6 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
                           Write(Model.AuthorRating);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n     Created: ");
#nullable restore
#line 7 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
         Write(Model.Created);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n </div>\r\n\r\n<div class=\"postContent\">\r\n    ");
#nullable restore
#line 11 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
Write(Model.PostContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 14 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
 foreach (var reply in Model.Replies){ 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div>\r\n        Author: ");
#nullable restore
#line 17 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
           Write(reply.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 17 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
                              Write(reply.AuthorRating);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        Created: ");
#nullable restore
#line 18 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
            Write(reply.Created);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"replyContent\">\r\n        ");
#nullable restore
#line 22 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
   Write(reply.ReplyContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 25 "E:\facultate\BoothackForum\mainProject\BoothackForum\BoothackForum\Views\Post\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoothackForum.Models.PostModel.PostIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
