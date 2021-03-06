#pragma checksum "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1cb48d45e6eacbe04e0d7ffa4b444fd994a6869"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Student_Views_Student_Profile), @"mvc.1.0.view", @"/Areas/Student/Views/Student/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1cb48d45e6eacbe04e0d7ffa4b444fd994a6869", @"/Areas/Student/Views/Student/Profile.cshtml")]
    public class Areas_Student_Views_Student_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TimeTable.Models.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UnFollow", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
  
    ViewData["Style"] = "~/css/Profile.css";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card w-75\">\r\n    <ul class=\"list-group list-group-flush\">\r\n        <li class=\"list-group-item\">??????????????: ");
#nullable restore
#line 10 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                        Write(Model.Student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                 Write(Model.Student.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li class=\"list-group-item\">??????????: ");
#nullable restore
#line 11 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                      Write(Model.Student.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ul>\r\n</div>\r\n<h3 class=\" mt-2 text-white\">???? ???????????????? ????:</h3>\r\n<div class=\"d-flex flex-row\">\r\n");
#nullable restore
#line 16 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
     if (Model.FollowedLessons != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
         for (int i = 0; i < Model.FollowedLessons.Count; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card w-50\" style=\"max-width: 300px;\">\r\n                <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 727, "\"", 826, 1);
#nullable restore
#line 21 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
WriteAttributeValue("", 733, Model.FollowedCourses.FirstOrDefault(x => x.ID == Model.FollowedLessons[i].CourseID).ImgPath, 733, 93, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 23 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                      Write(Model.FollowedCourses.FirstOrDefault(x => x.ID == Model.FollowedLessons[i].CourseID).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 24 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                    Write(Model.FollowedLessons[i].Datetime.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 24 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                           Write(Model.FollowedLessons[i].Datetime.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 24 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                                                                    Write(Model.FollowedLessons[i].Datetime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 24 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                                                                                                            Write(Model.FollowedLessons[i].Datetime.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 24 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                                                                                                                                                    Write(Model.FollowedLessons[i].Datetime.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b1cb48d45e6eacbe04e0d7ffa4b444fd994a68698429", async() => {
                WriteLiteral("???????????????????? ???? ??????????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
                                                                                           WriteLiteral(Model.FollowedLessons[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 28 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\programming\c# ASP\TimeTables\TimeTable\TimeTable\Areas\Student\Views\Student\Profile.cshtml"
         
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TimeTable.Models.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
