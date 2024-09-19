<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_21June2024_WebFormProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Website</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div style ="border:2px solid blue;margin:20%; padding:20px;">   
                  <div class="form-group">
                        <label for="ProductName">Product Name</label>                        
                        <asp:TextBox Placeholder="Enter Product Name" ID="ProductNameID" runat="server" class="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group">
                      <label for="ProductCat">Product Category</label>                                       
                      <asp:DropDownList ID="ListProductCatID" runat="server">
                         <asp:ListItem>Electronics</asp:ListItem>
                         <asp:ListItem>Clothes</asp:ListItem>
                         <asp:ListItem>Foods</asp:ListItem>
                         <asp:ListItem>Bottle</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                  <div class="form-group">
                          <label for="ProductImg">Product Image</label>
                         <asp:FileUpload ID="FileUploadProductImgID" runat="server" class="form-control" />
                  </div>

                  <div class="form-group">
                          <label for="ProductPrice">Product Price</label> 
                          <asp:TextBox Placeholder="Enter Product Price" ID="ProductPriceID" runat="server" class="form-control"></asp:TextBox>
                  </div>

                  <asp:Button ID="SubmitButton" runat="server" Text="Submit" class="btn btn-primary" OnClick="SubmitButton_Click"/>     
        </div>
    </form>

</body>
</html>
