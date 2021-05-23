using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RazorRenderer.Lambda;
using RazorRenderer.Lambda.Models;
using RazorRenderer.Templates.Models;

namespace RazorRenderer.Debug
{
    class Program
    {
        static async Task Main()
        {
            await DebugExampleSingleTemplateAsync();
            await DebugExampleMultipleTemplatesAsync();
        }

        private static async Task DebugExampleSingleTemplateAsync()
        {
            var model = new ExampleSingleTemplateModel
            {
                PlainText = "Test single template"
            };
            var request = new RenderRequest
            {
                ModelJson = JsonConvert.SerializeObject(model),
                TemplateType = TemplateType.ExampleSingleTemplate,
                Culture = "es-ES"
            };
            var result = await new RazorRendererFunction().Handler(request);
            Console.Write(result);
        }

        private static async Task DebugExampleMultipleTemplatesAsync()
        {
            var model = new ExampleMultipleTemplatesModel
            {
                PlainText = "Test multiple template",
                HtmlContent = "<hi>Html content for multiple template</h1>"
            };
            var request = new RenderRequest
            {
                ModelJson = JsonConvert.SerializeObject(model),
                TemplateType = TemplateType.ExampleMultipleTemplates,
                Culture = "es-ES"
            };
            var result = await new RazorRendererFunction().Handler(request);
            Console.Write(result);
        }
    }
}
