<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="test.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" style="text-align:center" AutoGenerateColumns="False" DataKeyNames="pid" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
        <Columns>
            <asp:ImageField DataImageUrlField="pic" HeaderText="Image">
                <ControlStyle Height="100px" Width="100px"></ControlStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ImageField>

            <asp:BoundField DataField="pid" HeaderText="Product ID" ReadOnly="True" InsertVisible="False" SortExpression="pid">
                <ControlStyle BackColor="#FFCC00" BorderColor="Red"></ControlStyle>

                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pname" HeaderText="Product Name" SortExpression="pname">
                <ControlStyle BackColor="#FFCC00" BorderColor="Red"></ControlStyle>

                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pcat" HeaderText="Product Category" SortExpression="pcat">
                <ControlStyle BackColor="#FFCC00" BorderColor="Red"></ControlStyle>

                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pdesc" HeaderText="Product Description" SortExpression="pdesc">
                <ControlStyle BackColor="#FFCC00" BorderColor="Red"></ControlStyle>

                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price">
                <ControlStyle BackColor="#FFCC00" BorderColor="Red"></ControlStyle>

                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
                <ControlStyle BackColor="White" BorderColor="Red"></ControlStyle>
                <ItemStyle HorizontalAlign="Center" ForeColor="Red"></ItemStyle>
            </asp:CommandField>

        </Columns>
        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbconn %>' DeleteCommand="DELETE FROM [product] WHERE [pid] = @pid" InsertCommand="INSERT INTO [product] ([pname], [pcat], [pic], [pdesc], [price]) VALUES (@pname, @pcat, @pic, @pdesc, @price)" SelectCommand="SELECT * FROM [product]" UpdateCommand="UPDATE [product] SET [pname] = @pname, [pcat] = @pcat, [pic] = @pic, [pdesc] = @pdesc, [price] = @price WHERE [pid] = @pid">
        <DeleteParameters>
            <asp:Parameter Name="pid" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="pname" Type="String"></asp:Parameter>
            <asp:Parameter Name="pcat" Type="String"></asp:Parameter>
            <asp:Parameter Name="pic" Type="String"></asp:Parameter>
            <asp:Parameter Name="pdesc" Type="String"></asp:Parameter>
            <asp:Parameter Name="price" Type="Decimal"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="pname" Type="String"></asp:Parameter>
            <asp:Parameter Name="pcat" Type="String"></asp:Parameter>
            <asp:Parameter Name="pic" Type="String"></asp:Parameter>
            <asp:Parameter Name="pdesc" Type="String"></asp:Parameter>
            <asp:Parameter Name="price" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="pid" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>