
<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewSlip.aspx.cs" Inherits="Payslip.ViewSlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="10" HorizontalAlign="Center" Width="100%">
        <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <Columns>
            <asp:BoundField DataField="pl" HeaderText="pl" SortExpression="pl" />
            <asp:BoundField DataField="cl" HeaderText="cl" SortExpression="cl" />
            <asp:BoundField DataField="sl" HeaderText="sl" SortExpression="sl" />
            <asp:BoundField DataField="Extra" HeaderText="Extra" SortExpression="Extra" />
            <asp:BoundField DataField="EmpId" HeaderText="EmpId" SortExpression="EmpId" />
            <asp:BoundField DataField="Remaining" HeaderText="Remaining" SortExpression="Remaining" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Download" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payslip;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [pl], [cl], [sl], [Extra], [EmpId], [Remaining] FROM [Leave] WHERE ([EmpId] = @EmpId)">
        <SelectParameters>
            <asp:SessionParameter Name="EmpId" SessionField="Emp" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
