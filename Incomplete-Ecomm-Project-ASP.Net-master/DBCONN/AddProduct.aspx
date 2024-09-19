<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="DBCONN.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Product Name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Product Category:<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Cars</asp:ListItem>
            <asp:ListItem>Motorcycle</asp:ListItem>
            <asp:ListItem>BiCycle</asp:ListItem>
            <asp:ListItem>Trucks</asp:ListItem>
            <asp:ListItem>Tempo</asp:ListItem>
            <asp:ListItem>Thar</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Product Price:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    Image:<asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Add Product" OnClick="Button2_Click" />
    <br />
</asp:Content>
