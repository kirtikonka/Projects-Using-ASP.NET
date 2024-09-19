<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Raise_Ticket.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js" integrity="sha384-+sLIOodYLS7CIrQpBjl+C7nPvqq+FbNUBDunl/OZv93DB7Ln/533i8e/mZXLi/P+" crossorigin="anonymous"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="padding: 10px;">
        <div style="border: 5px solid blue; padding: 30px; width: 30%; margin-left: 35%; align-self:center">
            <div>
                <asp:Label ID="Label1" class="form-label" runat="server" Text="Email Address:"></asp:Label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server" Width="388px"></asp:TextBox>
                <br />
            </div>
            <div class="mb-3">
                <asp:Label ID="Label2" class="form-label" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server" Width="386px"></asp:TextBox>
                <br />
            </div>
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
   
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" style="width: 269px">
                Create new account?</button>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">User Registration</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email ID</label>
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Username</label>
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Password</label>
                            <asp:TextBox ID="TextBox5" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button3" class="btn btn-primary" runat="server" Text="Register" OnClick="Button3_Click" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
