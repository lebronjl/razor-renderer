using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using RazorRenderer.Lambda.Handlers;
using RazorRenderer.Lambda.Models;

namespace RazorRenderer.Lambda
{
    public sealed class TemplateStrategyProvider
    {
        private readonly ServiceProvider _serviceProvider;

        public TemplateStrategyProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITemplateHandler GetStrategy(TemplateType templateType)
        {
            var services = _serviceProvider.GetServices<ITemplateHandler>();
            return services.FirstOrDefault(i => i.TemplateType == templateType);
        }
    }
}