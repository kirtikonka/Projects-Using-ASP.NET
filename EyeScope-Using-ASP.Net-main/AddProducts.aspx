<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="test.AddProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1 class="fonts size text-bold" style="text-align:center; color:purple; text-decoration-line:underline;text-transform: uppercase;">Add Products</h1>
  <div style="width:30%; padding:40px; border: 5px solid purple;position:relative; left:35%;">
      <div class="form-group text-bold">
        <label for="exampleInputEmail1">Product Name: </label>
          <asp:TextBox ID="TextBox1" class="form-control" placeholder="Add Product Name" runat="server"></asp:TextBox>
      </div>
      <br />
      <style>
         .custom{
            background-color: purple;
        }
         .custom .navbar-text{
            color:white;
        }
         .text-bold{
            font-weight:bold;
        }
         .fonts{
            font-family: "Times New Roman", Times, serif;
        }
         .size{
            font-size:50px;
        }
    </style>
      <!--
      <div class="form-group">
        <label for="exampleInputEmail1">Product Category</label>
        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
            <asp:ListItem>EyeGlasses</asp:ListItem>
            <asp:ListItem>Sunglasses/ Goggles</asp:ListItem>
            <asp:ListItem>UV Protection</asp:ListItem>
        </asp:DropDownList>
      </div>
      -->
      <div class="form-group text-bold">
        <label for="exampleInputEmail1">Product Price: </label>
        <asp:TextBox ID="TextBox3" class="form-control" placeholder="Add Product Price" runat="server"></asp:TextBox>
      </div>
      <br />

      <div class="form-group text-bold">
        <label for="exampleInputEmail1">Product Picture: </label>
        <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
      </div>
      <br />

      <div class="form-group text-bold">
          <label for="exampleInputEmail1">Product Description: </label><br />
      </div>
      <asp:TextBox ID="TextBox4" class="form-control" placeholder="Add Product Description" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
      <br />
      <br />
      <asp:Button ID="Button1" class="btn btn-info text-bold custom" runat="server" Text="Add Product" OnClick="Button1_Click1" />
</div>
</asp:Content>
