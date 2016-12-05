using System;
using System.IO;
using System.Web.Hosting;

namespace Velyo.AspNet.Markdown
{
    public class DefaultMarkdownProvider : MarkdownProvider
    {
        public override string GetMarkdownContent(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var file = HostingEnvironment.MapPath(path);
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }
            return null;
        }
    }
}
