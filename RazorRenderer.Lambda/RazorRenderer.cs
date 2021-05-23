using System;
using System.Globalization;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using RazorRenderer.Lambda.Handlers;
using RazorRenderer.Lambda.Models;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RazorRenderer.Lambda
{
    public class RazorRendererFunction
    {
        public async Task<RenderResponse> Handler(RenderRequest request)
        {
            var response = new RenderResponse();

            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();

                var templateStrategyProvider = new TemplateStrategyProvider(serviceProvider);
                var strategy = templateStrategyProvider.GetStrategy(request.TemplateType);

                CultureInfo.CurrentUICulture = new CultureInfo(request.Culture, true);
                var htmlSource = await strategy.HandleAsync(request.ModelJson);
                var premailerResult = PreMailer.Net.PreMailer.MoveCssInline(htmlSource, true);

                response.HtmlResult = premailerResult.Html;
            }
            catch (Exception e)
            {
                response.Exception = e;
            }

            return response;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddViewLocalization();
            services.AddLocalization();

            services.AddTransient<ITemplateHandler, ExampleSingleTemplateHandler>();
            services.AddTransient<ITemplateHandler, ExampleMultipleTemplatesHandler>();

            services.AddRazorTemplating();
        }
    }
}