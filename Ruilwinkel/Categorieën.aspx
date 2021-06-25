<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categorieën.aspx.cs" Inherits="Ruilwinkel.Categorieën" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position:absolute; top: 15%">
        <asp:GridView ID="GridView2" CssClass="categoryGridview" HeaderStyle-CssClass="categoryGridviewHeader" RowStyle-CssClass="categoryGridviewRows" runat="server" AutoGenerateColumns="False" CellPadding="3" DataSourceID="SqlDataSource3" GridLines="Horizontal" AutoGenerateEditButton="True" DataKeyNames="ID" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="CATEGORYNAME" HeaderText="CATEGORYNAME" SortExpression="CATEGORYNAME" />
                <asp:BoundField DataField="POINTS" HeaderText="POINTS" SortExpression="POINTS" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RuilwinkelDBConnectionString %>" SelectCommand="SELECT [ID], [CATEGORYNAME], [POINTS] FROM [CATEGORY]" UpdateCommand="UPDATE [CATEGORY] SET [CATEGORYNAME] = @CATEGORYNAME, [POINTS] = @POINTS WHERE [ID] = @ID" DeleteCommand="DELETE FROM [CATEGORY] WHERE [ID] = @ID" InsertCommand="INSERT INTO [CATEGORY] ([CATEGORYNAME], [POINTS]) VALUES (@CATEGORYNAME, @POINTS)">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CATEGORYNAME" Type="String" />
                <asp:Parameter Name="POINTS" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
            <asp:Parameter Name="CATEGORYNAME" Type="String" />
            <asp:Parameter Name="POINTS" Type="Int32" />
            <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        <div class="nieuweCategorieAanmaken" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Maak een nieuwe categorie:"></asp:Label>
            <asp:TextBox ID="TextBoxCategorieNaam" runat="server" placeholder="Naam"></asp:TextBox>
            <asp:TextBox ID="TextBoxCategoriePunten" runat="server" placeholder="Punten"></asp:TextBox>
            <asp:Button ID="ButtonAddCategory" CssClass="buttonVoegtoe" runat="server" Text="Voeg toe" OnClick="ButtonAddCategory_Click" />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/delete.png" Width="20px" Height="20px" OnClick="ImageButton1_Click" />
        </div>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ruilwinkelConnectionString %>" SelectCommand="SELECT * FROM [CATEGORY]" UpdateCommand="UPDATE [CATEGORY] SET [CATEGORYNAME]=@CATEGORYNAME, [POINTS]=@POINTS WHERE [ID]=@ID" DeleteCommand="DELETE FROM [CATEGORY] WHERE [ID]=@ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="CATEGORYNAME" />
            <asp:Parameter Name="POINTS" />
            <asp:Parameter Name="ID" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </div> 

</asp:Content>


