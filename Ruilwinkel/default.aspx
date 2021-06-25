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
    <div style="position:absolute; top: 15%; left: 10px">
        <h1>
            Producten</h1>
        <div style="padding: 10px;">
            <h2>Filter Status</h2>
            <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true" DataMember="SqlDataSource1"
                DataTextField="Status" DataValueField="Status" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownListStatus_SelectedIndexChanged">
                <asp:ListItem class="dropdown-item" Text="Alle" Value="" />
                <asp:ListItem class="dropdown-item" Text="Beschikbaar" Value="True" />
                <asp:ListItem class="dropdown-item" Text="Uitgeleend" Value="False"></asp:ListItem>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RuilwinkelDBConnectionString %>" SelectCommand="SELECT [CATEGORYNAME] FROM [CATEGORY]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RuilwinkelDBConnectionString %>" SelectCommand="SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, CATEGORY.POINTS, ARTICLE.NAAM FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID"
            FilterExpression="STATUS = '{0}'">
            <FilterParameters>
                <asp:ControlParameter Name="STATUS" ControlID="DropDownListStatus" PropertyName="SelectedValue" />
            </FilterParameters>
        </asp:SqlDataSource>     
        <asp:Button ID="Button1" class="buttons" runat="server" Text="OK" OnClick="Button1_Click" />
    </div>
    <div style="position: absolute; top: 15%; left: 25%;">
        <asp:GridView ID="GridView1" CssClass="productGridview" HeaderStyle-CssClass="categoryGridviewHeader" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="3" GridLines="Horizontal" DataKeyNames="ID" NullDisplayText="-NA-" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="PRODUCTNAME" HeaderText="PRODUCTNAME" SortExpression="PRODUCTNAME" />
                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" />
                <asp:BoundField DataField="CATEGORYNAME" HeaderText="CATEGORYNAME" SortExpression="CATEGORYNAME" />
                <asp:CheckBoxField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                <asp:BoundField DataField="POINTS" HeaderText="POINTS" SortExpression="POINTS" />
                <asp:BoundField DataField="NAAM" HeaderText="NAAM" SortExpression="NAAM"/>          
            </Columns>           
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </div>
    
    
    
    
    
</asp:Content>
