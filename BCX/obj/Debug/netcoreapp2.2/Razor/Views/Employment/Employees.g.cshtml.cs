#pragma checksum "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2b8503fd0c92761ce77b35d817d2dd900050216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employment_Employees), @"mvc.1.0.view", @"/Views/Employment/Employees.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employment/Employees.cshtml", typeof(AspNetCore.Views_Employment_Employees))]
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
#line 1 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\_ViewImports.cshtml"
using BCX;

#line default
#line hidden
#line 2 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\_ViewImports.cshtml"
using BCX.Models;

#line default
#line hidden
#line 3 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\_ViewImports.cshtml"
using BCX.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2b8503fd0c92761ce77b35d817d2dd900050216", @"/Views/Employment/Employees.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eae20351b3b6075c4baa4ce42fb5c022459ca9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Employment_Employees : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BCX.Models.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdatePerson", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(60, 663, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        function displayModal(id) {
            console.log(""tesing"")
            $.ajax({
                type: ""GET"",
                url: ""/Task/GetTaskModal"",
                data: { employeeId: id },
                success: function (data) {

                    $(""#emp"").empty().html(data);
                    console.log(data);
                    $(""#exampleModal"").modal('show');
                    //  $(""#EmployeeId"").val(id);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }

    </script>
    
");
                EndContext();
#line 26 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
          await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(795, 10, true);
                WriteLiteral("    \r\n\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(808, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 32 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.ErrorMessage))
{

#line default
#line hidden
            BeginContext(864, 54, true);
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        <strong>");
            EndContext();
            BeginContext(919, 20, false);
#line 35 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
           Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(939, 23, true);
            WriteLiteral("</strong>\r\n    </div>\r\n");
            EndContext();
#line 37 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
}

#line default
#line hidden
            BeginContext(965, 530, true);
            WriteLiteral(@"
<div class=""jumbotron "">
    <h2>Employees </h2>
</div>

<div class=""col-sm-10"">
    <table class=""table "">
        <thead>
            <tr>
                <th scope=""col"">Employee Code</th>
                <th scope=""col"">First Name</th>
                <th scope=""col"">Last Name</th>
                <th scope=""col"">Email Address</th>
                <th scope=""col"">Level</th>
                <th scope=""col""></th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 58 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
             foreach (var employee in Model)
            {
                if(employee.EmployeeId > 0)
                {

#line default
#line hidden
            BeginContext(1620, 58, true);
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
            EndContext();
            BeginContext(1679, 17, false);
#line 63 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                               Write(employee?.EmpCode);

#line default
#line hidden
            EndContext();
            BeginContext(1696, 31, true);
            WriteLiteral("</th>\r\n                    <td>");
            EndContext();
            BeginContext(1728, 26, false);
#line 64 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                   Write(employee.Person?.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1754, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1786, 25, false);
#line 65 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                   Write(employee.Person?.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1811, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1843, 38, false);
#line 66 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                   Write(employee.Person.ApplicationUser?.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1881, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1913, 31, false);
#line 67 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                   Write(employee?.LevelType.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1944, 57, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2001, 133, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2b8503fd0c92761ce77b35d817d2dd9000502169368", async() => {
                BeginContext(2124, 6, true);
                WriteLiteral("Update");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-personId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 69 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                                                                                      WriteLiteral(employee.Person.PersonId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["personId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-personId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["personId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2134, 105, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2239, "\"", 2284, 3);
            WriteAttributeValue("", 2249, "displayModal(", 2249, 13, true);
#line 72 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
WriteAttributeValue("", 2262, employee.EmployeeId, 2262, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2282, ");", 2282, 2, true);
            EndWriteAttribute();
            BeginContext(2285, 127, true);
            WriteLiteral(">\r\n                            Manange Task\r\n                        </a>\r\n\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 78 "C:\Users\Vuyiswa\source\repos\BCX\BCX\Views\Employment\Employees.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(2446, 76, true);
            WriteLiteral("\r\n            <div id=\"emp\"></div>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BCX.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591