#pragma checksum "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc05f013bceb13d80a263f5eb3a9ccf5a9798a4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authenication_SignIn), @"mvc.1.0.view", @"/Views/Authenication/SignIn.cshtml")]
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
#line 1 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc05f013bceb13d80a263f5eb3a9ccf5a9798a4d", @"/Views/Authenication/SignIn.cshtml")]
    public class Views_Authenication_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuthenticationScheme[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n    <h1>Authentication</h1>\r\n    <p class=\"lead text-left\">Sign in using one of these external providers:</p>\r\n\r\n");
#nullable restore
#line 8 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
     foreach (var scheme in Model.OrderBy(p => p.DisplayName))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <form action=\"/signin\" method=\"post\">\r\n            <input type=\"hidden\" name=\"Provider\"");
            BeginWriteAttribute("value", " value=\"", 381, "\"", 401, 1);
#nullable restore
#line 11 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
WriteAttributeValue("", 389, scheme.Name, 389, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <input type=\"hidden\" name=\"ReturnUrl\"");
            BeginWriteAttribute("value", " value=\"", 456, "\"", 482, 1);
#nullable restore
#line 12 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
WriteAttributeValue("", 464, ViewBag.ReturnUrl, 464, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            <button class=\"btn btn-lg btn-success m-1\" type=\"submit\">Connect using ");
#nullable restore
#line 14 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
                                                                              Write(scheme.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        </form>\r\n");
#nullable restore
#line 16 "E:\code\projects\Demo\Mvclient\MvcClient\MvcClient\Views\Authenication\SignIn.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuthenticationScheme[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
