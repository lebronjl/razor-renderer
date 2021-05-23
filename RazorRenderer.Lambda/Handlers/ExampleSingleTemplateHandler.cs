using System.Threading.Tasks;
using Newtonsoft.Json;
using Razor.Templating.Core;
using RazorRenderer.Lambda.Models;
using RazorRenderer.Templates.Models;

namespace RazorRenderer.Lambda.Handlers
{
    public class ExampleSingleTemplateHandler : ITemplateHandler
    {
        const string ViewPath = "/Views/ExampleSingleView.cshtml";

        public TemplateType TemplateType { get; private set; }

        public ExampleSingleTemplateHandler()
        {
            TemplateType = TemplateType.ExampleSingleTemplate;
        }

        public async Task<string> HandleAsync(string modelJson)
        {
            var model = JsonConvert.DeserializeObject<ExampleSingleTemplateModel>(modelJson);
            var html = await RazorTemplateEngine.RenderAsync(ViewPath, model);
            return html;
        }
    }
}