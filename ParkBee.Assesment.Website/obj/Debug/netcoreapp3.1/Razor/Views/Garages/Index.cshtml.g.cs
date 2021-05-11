#pragma checksum "C:\Dev\GarageChecker\backend\ParkBee.Assesment.Website\Views\Garages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "632259322951b970960b46678558edd4bdcff8a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Garages_Index), @"mvc.1.0.view", @"/Views/Garages/Index.cshtml")]
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
#line 1 "C:\Dev\GarageChecker\backend\ParkBee.Assesment.Website\Views\_ViewImports.cshtml"
using ParkBee.Assesment.Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dev\GarageChecker\backend\ParkBee.Assesment.Website\Views\_ViewImports.cshtml"
using ParkBee.Assesment.Website.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"632259322951b970960b46678558edd4bdcff8a1", @"/Views/Garages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59d9593886a909c78e9441d6b6cf586071fef23f", @"/Views/_ViewImports.cshtml")]
    public class Views_Garages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Dev\GarageChecker\backend\ParkBee.Assesment.Website\Views\Garages\Index.cshtml"
  
    ViewBag.Title = "Garages";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "632259322951b970960b46678558edd4bdcff8a13749", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<table class=""table table-responsive table-borderless "" id=""tblGarage"">
    <thead>
        <tr>
            <td>
                Status
            </td>
            <td>
                Name
            </td>
            <td>
                Address
            </td>
            <td>
                Refresh
            </td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                Loading...
            </td>
            <td>
                Loading...
            </td>
            <td>
                Loading...
            </td>
            <td>
                Loading...
            </td>
        </tr>
    </tbody>
</table>

<script type=""text/javascript"">
    $(document).ready(function () {

        $.getJSON(""/Garages/GetUserGarageInformation"", function (garage) {
            $('#tblGarage tbody tr').remove();
            SetGarageInformation(garage);
        });

        $(document).on('click', '#tblGarage button[name=refreshGara");
            WriteLiteral(@"ge]', function (e) {
            var $tableBody = $(this).parents('table tbody');
            var garageID = $(this).closest('tr').data('id');

            $tableBody.find('tr:gt(0)').remove();
            $tableBody.find('tr').find('td').text('Loading...');

            $.getJSON(""/Garages/RefreshGarage/"" + garageID, function (garage) {
                SetGarageInformation(garage);
                $tableBody.find('tr:first').remove();
            });
        });

        $(document).on('click', '#tblGarage button[name=refreshDoor]', function (e) {
            var $tr = $(this).closest('tr');
            var doorID = $tr.data('id');
            var $doorName = $tr.find('span[name=doorName]');
            var $doorStatus = $tr.find('i[name=doorStatus]');

            $doorStatus.replaceWith(""<i class='fa fa-spinner fa-spin' aria-hidden='true'></i>"");

            $.getJSON(""/Door/PingDoor/"" + doorID, function (doorResult) {
                RefreshDoor(doorID, $tr, $doorName.text(), doorRe");
            WriteLiteral(@"sult);
            });
        });

        function SetGarageInformation(garage) {
            var text = """";
            var garageStatusHtml = """";
            var isGarageOnline = garage.isOnline;

            garage.doors.forEach(element => {
                var doorStatusHtml = """";
                var isDoorOnline = element.isOnline;

                if (isDoorOnline) {
                    doorStatusHtml = ""<i name='doorStatus' class='fa fa-circle text-success' aria-hidden='true'></i>"";
                } else {
                    doorStatusHtml = ""<i name='doorStatus' class='fa fa-circle text-danger' aria-hidden='true'></i>"";
                }

                text += "" <tr name='door' data-id="" + element.id + "">""
                    + ""<td></td>""
                    + "" <td colspan='2'>""
                    + "" <div id='collapseOne' class='collapse in'>""
                    + doorStatusHtml
                    + ""<span style='padding-left: 10px;' name='doorName'>"" + element.name");
            WriteLiteral(@" + ""</span>""
                    + ""<button name='refreshDoor' class='btn-primary' style='border-radius: 10px; float: right;'><i class='fa fa-refresh' aria-hidden='true'></i></button>""
                    + "" </div>""
                    + "" </td>""
                    + "" <br />""
                    + "" </tr>"";
            });

            if (isGarageOnline) {
                garageStatusHtml = ""<i name='garageStatus' class='fa fa-circle text-success' aria-hidden='true'></i>"";
            }
            else {
                garageStatusHtml = ""<i name='garageStatus' class='fa fa-circle text-danger' aria-hidden='true'></i>"";
            }

            $('#tblGarage tbody').append(""<tr name='garage' class='accordion-toggle' data-toggle='collapse' data-target='#collapseOne' data-id="" + garage.id + "">""
                + "" <td>"" + garageStatusHtml + ""</td>""
                + "" <td>"" + garage.name + ""</td>""
                + "" <td>"" + garage.address + ""</td>""
                + "" <td><button name");
            WriteLiteral(@"='refreshGarage' class='btn-primary' style='border-radius: 10px;'><i class='fa fa-refresh' aria-hidden='true'></i></button></td>""
                + "" </tr>""
                + text);
        };

        function RefreshDoor(doorID, $tr, doorName, doorResult) {
            var text = """";
            var doorStatusHtml = """";
            var isDoorOnline = doorResult.isOnline;

            if (isDoorOnline) {
                doorStatusHtml = ""<i name='doorStatus' class='fa fa-circle text-success' aria-hidden='true'></i>"";
            }
            else {
                doorStatusHtml = ""<i name='doorStatus' class='fa fa-circle text-danger' aria-hidden='true'></i>"";
            }

            text = "" <tr name='door' data-id="" + doorID + "">""
                + ""<td></td>""
                + "" <td colspan='2'>""
                + "" <div id='collapseOne' class='in collapse show'>""
                + doorStatusHtml
                + ""<span style='padding-left: 10px;' name='doorName'>"" + doorName + ");
            WriteLiteral(@"""</span>""
                + ""<button name='refreshDoor' class='btn-primary' style='border-radius: 10px; float: right;'><i class='fa fa-refresh' aria-hidden='true'></i></button>""
                + "" <br />""
                + "" </div>""
                + "" </td>""
                + "" </tr>"";

            $tr.replaceWith(text);
        };
    });

</script>");
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
