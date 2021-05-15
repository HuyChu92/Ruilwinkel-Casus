<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ruilwinkel.AllProductsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="position:absolute; top: 50%">
        
        Producten</h1>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ruilwinkelConnectionString %>" SelectCommand="SELECT * FROM [ARTICLE]"></asp:SqlDataSource>
    <asp:GridView style="position:absolute; top: 70%" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="PRODUCTID" HeaderText="PRODUCTID" SortExpression="PRODUCTID" />
            <asp:BoundField DataField="STATUSID" HeaderText="STATUSID" SortExpression="STATUSID" />
            <asp:BoundField DataField="PROVIDERID" HeaderText="PROVIDERID" SortExpression="PROVIDERID" />
            <asp:BoundField DataField="RENTERID" HeaderText="RENTERID" SortExpression="RENTERID" />
            <asp:BoundField DataField="LOANDATE" HeaderText="LOANDATE" SortExpression="LOANDATE" />
            <asp:BoundField DataField="EXPIRATIONDATE" HeaderText="EXPIRATIONDATE" SortExpression="EXPIRATIONDATE" />
            <asp:BoundField DataField="COMMENTARY" HeaderText="COMMENTARY" SortExpression="COMMENTARY" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
