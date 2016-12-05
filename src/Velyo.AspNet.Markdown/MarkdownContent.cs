using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Velyo.AspNet.Markdown
{
    [ToolboxData("<{0}:Markdown runat=\"server\"></{0}:Markdown>")]
    [ParseChildren(true, nameof(Content))]
    public class MarkdownContent : WebControl
    {
        [Bindable(true)]
        [Category("Markdown")]
        [DefaultValue(null)]
        [Description("Markdown content")]
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        public virtual string Content { get; set; }

        [Category("Markdown")]
        [DefaultValue(0)]
        [Description("Markdown content indent")]
        public int Indent { get; set; }

        [Category("Markdown")]
        [DefaultValue(null)]
        [Description("Markdown content resource path")]
        public virtual string Path { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            var content = GetHtml();
            if (content != null)
            {
                writer.Write(content);
            }
        }

        protected virtual string GetHtml()
        {
            return MarkdownEngine.Current.GetHtml(UniqueID, GetContent);
        }

        protected virtual string GetContent()
        {
            var content = Content;

            if (content != null)
            {
                if (Indent > 0)
                {
                    var buffer = new StringBuilder();

                    using (var reader = new StringReader(content))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Length > Indent)
                            {
                                buffer.AppendLine(line.Substring(Indent));
                            }
                            else
                            {
                                buffer.AppendLine(line);
                            }
                        }
                    }

                    content = buffer.ToString();
                }
            }
            else if (Path != null)
            {
                content = MarkdownProvider.Current.GetMarkdownContent(Path);
            }

            return content;
        }
    }
}
