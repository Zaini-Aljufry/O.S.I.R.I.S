#pragma checksum "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a9089f4f6f749d986f0ffd24224ce5f01e6351b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GUI.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage__ManageNav), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/Manage/_ManageNav.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Identity/Pages/Account/Manage/_ManageNav.cshtml", typeof(GUI.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage__ManageNav))]
namespace GUI.Areas.Identity.Pages.Account.Manage
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\_ViewImports.cshtml"
using GUI.Areas.Identity;

#line default
#line hidden
#line 3 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\_ViewImports.cshtml"
using GUI.Models;

#line default
#line hidden
#line 1 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using GUI.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using GUI.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a9089f4f6f749d986f0ffd24224ce5f01e6351b", @"/Areas/Identity/Pages/Account/Manage/_ManageNav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0cdad8b4576b4f804f2326266c2d156e7a39153", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ded5d49465a3d8ef0cae21b5ece3ecad9fc19c0", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4035e861b5eae03075c010399e547d740f440b9c", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage__ManageNav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("change-password"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./PersonalData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml"
  
    var hasExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).Any();

#line default
#line hidden
            BeginContext(159, 47, true);
            WriteLiteral("<ul class=\"nav nav-pills nav-stacked\">\r\n    <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 206, "\"", 256, 1);
#line 6 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml"
WriteAttributeValue("", 214, ManageNavPages.IndexNavClass(ViewContext), 214, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(257, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(258, 33, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d53d97c3025a436886ecab49b84574c9", async() => {
                BeginContext(280, 7, true);
                WriteLiteral("Profile");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(291, 14, true);
            WriteLiteral("</li>\r\n    <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 305, "\"", 364, 1);
#line 7 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml"
WriteAttributeValue("", 313, ManageNavPages.ChangePasswordNavClass(ViewContext), 313, 51, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(365, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(366, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5d1fc61e27a452682b0fb8c070d69b7", async() => {
                BeginContext(418, 8, true);
                WriteLiteral("Password");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(430, 14, true);
            WriteLiteral("</li>\r\n    <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 444, "\"", 501, 1);
#line 8 "C:\Users\dream\Desktop\Bitbucket\5-Integration\GUI\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml"
WriteAttributeValue("", 452, ManageNavPages.PersonalDataNavClass(ViewContext), 452, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(502, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(503, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c72bfe6e5ea458b947c78281781217c", async() => {
                BeginContext(532, 13, true);
                WriteLiteral("Personal data");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(549, 12, true);
            WriteLiteral("</li>\r\n</ul>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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