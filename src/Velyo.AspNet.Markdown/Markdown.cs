using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Velyo.AspNet
{
    [ToolboxData("<{0}:Markdown runat=\"server\"></{0}:Markdown>")]
    public class Markdown : WebControl
    {
        [Browsable(false)]
        [Category("Markdown")]
        [DefaultValue(null)]
        [Description("Markdown content")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate Content { get; set; }
    }
}
