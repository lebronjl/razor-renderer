using System.Threading.Tasks;
using Newtonsoft.Json;
using Razor.Templating.Core;
using RazorRenderer.Lambda.Models;
using RazorRenderer.Templates.Models;

namespace RazorRenderer.Lambda.Handlers
{
    public class ExampleMultipleTemplatesHandler : ITemplateHandler
    {
        const string ViewPath = "/Views/ExampleMultipleView.cshtml";

        public TemplateType TemplateType { get; private set; }

        public ExampleMultipleTemplatesHandler()
        {
            TemplateType = TemplateType.ExampleMultipleTemplates;
        }

        public async Task<string> HandleAsync(string modelJson)
        {
            var model = JsonConvert.DeserializeObject<ExampleMultipleTemplatesModel>(modelJson);
            var html = await RazorTemplateEngine.RenderAsync(ViewPath, model);
            return html;
        }
    }
}