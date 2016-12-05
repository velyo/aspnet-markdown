<%@ Page Language="C#" MasterPageFile="~/Samples/SamplesMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Velyo.AspNet.Markdown.Samples.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="SampleContent" runat="server">
    <velyo:MarkdownContent ID="sample1"  runat="server">
# ASP.NET Markdown

ASP.NET Markdown control to embed and render markdown content in your ASP.NET application.

## Features


## Contribute

Check out the [contribution guidelines](https://github.com/velyo/aspnet-markdown/blob/master/CONTRIBUTING.md) if you want to contribute to this project.

## License

[MIT](https://github.com/velyo/aspnet-markdown/blob/master/LICENSE)

```cs
public class Test {
}
```
    </velyo:MarkdownContent>
</asp:Content>