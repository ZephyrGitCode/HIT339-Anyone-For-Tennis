#pragma checksum "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5463fb1dad97940ea03e62a97b6fff4757fd02f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schedules_Details), @"mvc.1.0.view", @"/Views/Schedules/Details.cshtml")]
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
#line 1 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\_ViewImports.cshtml"
using HIT339_Assign2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\_ViewImports.cshtml"
using HIT339_Assign2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5463fb1dad97940ea03e62a97b6fff4757fd02f4", @"/Views/Schedules/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87fab082d0cd1ae432fc47b1807ed2b1d0d01214", @"/Views/_ViewImports.cshtml")]
    public class Views_Schedules_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HIT339_Assign2.Models.ScheduleViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Schedule</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SingleSchedule.Eventname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayFor(model => model.SingleSchedule.Eventname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SingleSchedule.Coach));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n           Myself\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SingleSchedule.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayFor(model => model.SingleSchedule.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SingleSchedule.Eventdatetime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
       Write(Html.DisplayFor(model => model.SingleSchedule.Eventdatetime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<h3>Enroled Members</h3>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>First Name</th>\r\n            <th>Last Name</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n");
#nullable restore
#line 52 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
             foreach (var user in Model.Members)
            {
                foreach (var enrol in Model.Enrolments)
                {
                    if (enrol.ScheduleId == Model.SingleSchedule.Id)
                    {
                        if (user.Id == enrol.UserId)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 60 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
                           Write(user.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 61 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
                           Write(user.Lname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\zephy\Documents\SemesterTwo\HIT339 Distributed Dev\Assignment2\Assignment2_App\HIT339_Assign2\Views\Schedules\Details.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HIT339_Assign2.Models.ScheduleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
