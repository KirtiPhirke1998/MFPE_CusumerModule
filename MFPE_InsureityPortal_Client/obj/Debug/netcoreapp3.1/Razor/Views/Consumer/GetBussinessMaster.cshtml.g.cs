#pragma checksum "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b28646f3408acd7391855152b13e3c1784bf547"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consumer_GetBussinessMaster), @"mvc.1.0.view", @"/Views/Consumer/GetBussinessMaster.cshtml")]
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
#line 1 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\_ViewImports.cshtml"
using MFPE_InsureityPortal_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\_ViewImports.cshtml"
using MFPE_InsureityPortal_Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b28646f3408acd7391855152b13e3c1784bf547", @"/Views/Consumer/GetBussinessMaster.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b65d483d29ce25ef6be73050c63dd65859bf1e51", @"/Views/_ViewImports.cshtml")]
    public class Views_Consumer_GetBussinessMaster : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MFPE_InsureityPortal_Client.Models.BusinessMaster>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
  
    ViewData["Title"] = "GetBussinessMaster";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetBussinessMaster</h1>\r\n\r\n<div>\r\n    <h4>BusinessMaster</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayNameFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayNameFor(model => model.HasBusinessTypes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayFor(model => model.HasBusinessTypes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayNameFor(model => model.AnnualTurnover));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayFor(model => model.AnnualTurnover));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayNameFor(model => model.capitalInvested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayFor(model => model.capitalInvested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayNameFor(model => model.BussinessValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
       Write(Html.DisplayFor(model => model.BussinessValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 46 "G:\Ctsfiles\Project_MFPE\MFPE_CusumerModule\MFPE_InsureityPortal_Client\Views\Consumer\GetBussinessMaster.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b28646f3408acd7391855152b13e3c1784bf5477906", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MFPE_InsureityPortal_Client.Models.BusinessMaster> Html { get; private set; }
    }
}
#pragma warning restore 1591
