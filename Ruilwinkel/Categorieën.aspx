<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categorieën.aspx.cs" Inherits="Ruilwinkel.Categorieën" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    </p>
    <div style="position:absolute; top: 15%">
        <asp:GridView ID="GridView2" CssClass="categoryGridview" HeaderStyle-CssClass="categoryGridviewHeader" RowStyle-CssClass="categoryGridviewRows" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CATEGORYNAME" HeaderText="CATEGORYNAME" SortExpression="CATEGORYNAME" />
                <asp:BoundField DataField="POINTS" HeaderText="POINTS" SortExpression="POINTS" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RuilwinkelDBConnectionString %>" SelectCommand="SELECT [CATEGORYNAME], [POINTS] FROM [CATEGORY]"></asp:SqlDataSource>
        <div class="nieuweCategorieAanmaken" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Maak een nieuwe categorie:"></asp:Label>
            <asp:TextBox ID="TextBoxCategorieNaam" runat="server" placeholder="Naam"></asp:TextBox>
            <asp:TextBox ID="TextBoxCategoriePunten" runat="server" placeholder="Punten"></asp:TextBox>
            <asp:Button ID="ButtonAddCategory" runat="server" Text="Voeg toe" OnClick="ButtonAddCategory_Click" />
        </div>
    </div> 
</asp:Content>
