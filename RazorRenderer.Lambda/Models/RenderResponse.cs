using System;

namespace RazorRenderer.Lambda.Models
{
    public sealed class RenderResponse
    {
        public string HtmlResult {get;set;}
        public Exception Exception {get;set;}
    }
}