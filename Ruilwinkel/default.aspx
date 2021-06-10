<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ruilwinkel.AllProductsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        //function ShowHideDiv(CheckBox2) {
        //    var dvCategorie = document.getElementById("dvCategorie");
        //    dvCategorie.style.display = CheckBox2.checked ? "block" : "none";
        //}
    </script>
    <div style="position:absolute; top: 15%">
        <h1>
            Producten</h1>
        <div style="padding: 10px;">
            <h2>Filter Status</h2>
            <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true" DataMember="SqlDataSource1"
                DataTextField="Status" DataValueField="Status" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownListStatus_SelectedIndexChanged">
                <asp:ListItem Text="Alle" Value="" />
                <asp:ListItem Text="Beschikbaar" Value="True" />
                <asp:ListItem Text="Uitgeleend" Value="False"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="padding: 10px";>
            <label for="CheckBox2" style="font-size: large; text-decoration: solid" >
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Filter Categorie" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true"/>
            </label>
            <hr style="width: 200px;"/>
            <div id="dvCategorie"  runat="server" >
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="CATEGORYNAME" DataValueField="CATEGORYNAME" AutoPostBack="true" OnSelectedIndexChanged="DropDownListStatus_SelectedIndexChanged">
                </asp:CheckBoxList>
            </div>  
        </div>
        <div style="padding: 10px";>
            <h2>Punten</h2>
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox> <p> tot </p> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ruilwinkelConnectionString %>" SelectCommand="SELECT [CATEGORYNAME] FROM [CATEGORY]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ruilwinkelConnectionString %>" SelectCommand="SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID"
            FilterExpression="STATUS = '{0}'">
            <FilterParameters>
                <asp:ControlParameter Name="STATUS" ControlID="DropDownListStatus" PropertyName="SelectedValue" />
            </FilterParameters>
        </asp:SqlDataSource>     
        <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PRODUCTNAME" HeaderText="PRODUCTNAME" SortExpression="PRODUCTNAME" />
                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" />
                <asp:BoundField DataField="CATEGORYNAME" HeaderText="CATEGORYNAME" SortExpression="CATEGORYNAME" />
                <asp:CheckBoxField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" SortExpression="FIRSTNAME" />
                <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME" />
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
    </div>
    
    
    
    
    
</asp:Content>
