#pragma checksum "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a65bd7a779d308a203816e54a90dbe3a902a4856"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ScientificName_Detail), @"mvc.1.0.view", @"/Views/ScientificName/Detail.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\_ViewImports.cshtml"
using TYP.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\_ViewImports.cshtml"
using TYP.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\_ViewImports.cshtml"
using TYP.Service.DTOs.ScientificDegreeDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
using TYP.Service.DTOs.ScientificNameDTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a65bd7a779d308a203816e54a90dbe3a902a4856", @"/Views/ScientificName/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efa55f3b0142ef0e143aa342969bf67b2e070ee7", @"/Views/_ViewImports.cshtml")]
    public class Views_ScientificName_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ScientificNameGetDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-6"">
    <div class=""card mb-4"">
        <div class=""card-header"">
            <div class=""d-flex justify-content-between align-items-center"">
                <div>
                    <h6 class=""fs-17 font-weight-600 mb-0"">Todo list</h6>
                </div>
            </div>
        </div>
        <div class=""card-body"">
            <div class=""dd"" id=""nestable2"">
                <ol class=""dd-list"">
");
#nullable restore
#line 19 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                     if (Model.Teachers.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"text-danger\">Bu Elmi Adda Muellim Yoxdur</h4>\r\n");
#nullable restore
#line 22 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                        
                    }else{
                        int num =1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                         foreach (var item in Model.Teachers)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"dd-item\" data-id=\"13\">\r\n                                <div class=\"dd-handle\"><strong>");
#nullable restore
#line 28 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                                                          Write(num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> - ");
#nullable restore
#line 28 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                                                                                     Write(item.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                                                                                                   Write(item.Fathername);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </li>\r\n");
#nullable restore
#line 30 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                        num++;
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\HP\Desktop\TYP_API\TYP.MVC\Views\ScientificName\Detail.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                    \r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ScientificNameGetDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591