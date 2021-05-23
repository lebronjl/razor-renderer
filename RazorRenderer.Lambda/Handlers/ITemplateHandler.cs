using System.Threading.Tasks;
using RazorRenderer.Lambda.Models;

namespace RazorRenderer.Lambda.Handlers
{
    public interface ITemplateHandler
    {
        TemplateType TemplateType { get; }
        Task<string> HandleAsync(string modelJson);
    }
}