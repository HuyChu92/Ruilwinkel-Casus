<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categorieën.aspx.cs" Inherits="Ruilwinkel.Categorieën" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <p>
    </p>
    <asp:GridView style="position:absolute; top: 15%" ID="GridView1" runat="server">
    </asp:GridView>
    <asp:TextBox style="position:absolute; top: 50%" ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button style="position:absolute; top: 70%" ID="Button1" runat="server" Text="Button" />
</asp:Content>
