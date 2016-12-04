using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Markdig;

namespace Velyo.AspNet
{
    [ToolboxData("<{0}:Markdown runat=\"server\"></{0}:Markdown>")]
    [ParseChildren(true, nameof(Content))]
    public class Markdown : WebControl
    {
        [Browsable(false)]
        [Bindable(true)]
        [Category("Markdown")]
        [DefaultValue("")]
        [Description("Markdown content")]
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        public virtual string Content { get; set; }

        public int Indent { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                var content = Content;//.Trim();

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

                // TODO cache this
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                var result = Markdig.Markdown.ToHtml(content, pipeline);

                writer.Write(result);
            }
        }
    }
}
