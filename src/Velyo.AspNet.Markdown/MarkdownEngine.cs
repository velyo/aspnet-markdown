using System;

namespace Velyo.AspNet.Markdown
{
    public abstract class MarkdownEngine
    {
        public static MarkdownEngine Current = new DefaultMarkdownEngine();

        public abstract string GetHtml(string markdown);
        public abstract string GetHtml(string key, Func<string> fetch);

    }
}
