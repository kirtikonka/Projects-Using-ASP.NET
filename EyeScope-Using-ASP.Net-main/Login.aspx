<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="test.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js" integrity="sha384-+sLIOodYLS7CIrQpBjl+C7nPvqq+FbNUBDunl/OZv93DB7Ln/533i8e/mZXLi/P+" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:20px; border:2px blue solid; position:absolute;" > 
            <!-- Step 3: Create a Login Page-->
              <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server" Placeholder="Enter Email ID" TextMode="Email"></asp:TextBox>
              </div>

              <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server" Placeholder="Enter Password" TextMode="Password"></asp:TextBox>
              </div>

            <asp:Button ID="Button1" runat="server" class="btn btn-success" Style="width: 100%;" Text="Login" OnClick="Button1_Click1" /> <br />
              <a href="#" data-toggle="modal" data-target="#exampleModal" style="background:none; color:green; border:none; position:relative; left:70px; top:10px;outline:none;text-decoration:underline;">Create a new account?</a>
        </div>


        <!-- Step 4: Add Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Sign Up Page</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div> 
                    <!-- Step 5: Create a Register Page-->
                      <div class="form-group">
                        <label for="exampleInputEmail1">Username</label>
                        <asp:TextBox ID="TextBox5" class="form-control" runat="server" Placeholder="Enter Username"></asp:TextBox>
                      </div>

                      <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="TextBox3" class="form-control" runat="server" Placeholder="Enter Email ID" TextMode="Email"></asp:TextBox>
                      </div>

                      <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <asp:TextBox ID="TextBox4" class="form-control" runat="server" Placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                      </div>
                      
                      <div class="form-group">
                        <label for="exampleInputPassword1">Upload Profile Photo</label>
                        <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                      </div>

                      <asp:Button ID="Button2" runat="server" class="btn btn-success" style="width:100%;" Text="Register" />
                </div>
              </div>
            </div>
          </div>
        </div>
    </form>
</body>
</html>
