namespace Velyo.AspNet.Markdown
{
    public abstract class MarkdownProvider
    {
        public static MarkdownProvider Current = new DefaultMarkdownProvider();

        public abstract string GetMarkdownContent(string path);
    }
}
