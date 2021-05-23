namespace RazorRenderer.Lambda.Models
{
    public sealed class RenderRequest
    {
        public string ModelJson { get; set; }

        public TemplateType TemplateType { get; set; }

        public string Culture { get; set; }
    }
}