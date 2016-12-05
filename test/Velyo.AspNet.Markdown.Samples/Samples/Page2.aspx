<%@ Page Title="" Language="C#" MasterPageFile="~/Samples/SamplesMaster.master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="Velyo.AspNet.Markdown.Samples.Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="server">
    <velyo:MarkdownContent ID="sample2" runat="server" Path="~/docs/page2.md">
    </velyo:MarkdownContent>
</asp:Content>
