#pragma checksum "C:\Users\Decagon001\source\repos\MyBlog\MyBlog\Views\Blog\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdca46ab8202a5b8a9863dd5e0ced0f77f4789e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Contact), @"mvc.1.0.view", @"/Views/Blog/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/Contact.cshtml", typeof(AspNetCore.Views_Blog_Contact))]
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
#line 1 "C:\Users\Decagon001\source\repos\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog;

#line default
#line hidden
#line 2 "C:\Users\Decagon001\source\repos\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdca46ab8202a5b8a9863dd5e0ced0f77f4789e5", @"/Views/Blog/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b889b3f4308041dc292b61010b9c4781c7386c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Decagon001\source\repos\MyBlog\MyBlog\Views\Blog\Contact.cshtml"
  
    Layout = "_BlogLayout";

#line default
#line hidden
            BeginContext(36, 1111, true);
            WriteLiteral(@"
<!-- Page Content -->
<!-- Banner Starts Here -->
<div class=""heading-page header-text"">
    <section class=""page-heading"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""text-content"">
                        <h4>contact us</h4>
                        <h2>let’s stay in touch!</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>

<!-- Banner Ends Here -->


<section class=""contact-us"">
    <div class=""container"">
        <div class=""row"">

            <div class=""col-lg-12"">
                <div class=""down-contact"">
                    <div class=""row"">
                        <div class=""col-lg-8"">
                            <div class=""sidebar-item contact-form"">
                                <div class=""sidebar-heading"">
                                    <h2>Send us a message</h2>
                                </div>
    ");
            WriteLiteral("                            <div class=\"content\">\r\n                                    ");
            EndContext();
            BeginContext(1147, 2106, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdca46ab8202a5b8a9863dd5e0ced0f77f4789e55685", async() => {
                BeginContext(1190, 315, true);
                WriteLiteral(@"
                                        <div class=""row"">
                                            <div class=""col-md-6 col-sm-12"">
                                                <fieldset>
                                                    <input name=""name"" type=""text"" id=""name"" placeholder=""Your name""");
                EndContext();
                BeginWriteAttribute("required", " required=\"", 1505, "\"", 1516, 0);
                EndWriteAttribute();
                BeginContext(1517, 373, true);
                WriteLiteral(@">
                                                </fieldset>
                                            </div>
                                            <div class=""col-md-6 col-sm-12"">
                                                <fieldset>
                                                    <input name=""email"" type=""text"" id=""email"" placeholder=""Your email""");
                EndContext();
                BeginWriteAttribute("required", " required=\"", 1890, "\"", 1901, 0);
                EndWriteAttribute();
                BeginContext(1902, 745, true);
                WriteLiteral(@">
                                                </fieldset>
                                            </div>
                                            <div class=""col-md-12 col-sm-12"">
                                                <fieldset>
                                                    <input name=""subject"" type=""text"" id=""subject"" placeholder=""Subject"">
                                                </fieldset>
                                            </div>
                                            <div class=""col-lg-12"">
                                                <fieldset>
                                                    <textarea name=""message"" rows=""6"" id=""message"" placeholder=""Your Message""");
                EndContext();
                BeginWriteAttribute("required", " required=\"", 2647, "\"", 2658, 0);
                EndWriteAttribute();
                BeginContext(2659, 587, true);
                WriteLiteral(@"></textarea>
                                                </fieldset>
                                            </div>
                                            <div class=""col-lg-12"">
                                                <fieldset>
                                                    <button type=""submit"" id=""form-submit"" class=""main-button"">Send Message</button>
                                                </fieldset>
                                            </div>
                                        </div>
                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3253, 2003, true);
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-4"">
                            <div class=""sidebar-item contact-information"">
                                <div class=""sidebar-heading"">
                                    <h2>contact information</h2>
                                </div>
                                <div class=""content"">
                                    <ul>
                                        <li>
                                            <h5>090-484-8080</h5>
                                            <span>PHONE NUMBER</span>
                                        </li>
                                        <li>
                                            <h5>info@company.com</h5>
                                            <span>EMAIL ADDRESS</span>
                                        </li>
                                        <li>
           ");
            WriteLiteral(@"                                 <h5>
                                                123 Aenean id posuere dui,
                                                <br>Praesent laoreet 10660
                                            </h5>
                                            <span>STREET ADDRESS</span>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""col-lg-12"">
                <div id=""map"">
                    <iframe src=""https://maps.google.com/maps?q=Av.+L%C3%BAcio+Costa,+Rio+de+Janeiro+-+RJ,+Brazil&t=&z=13&ie=UTF8&iwloc=&output=embed"" width=""100%"" height=""450px"" frameborder=""0"" style=""border:0"" allowfullscreen></iframe>
                </div>
            </div>

        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
