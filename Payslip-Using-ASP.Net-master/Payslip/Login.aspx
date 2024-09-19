<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Payslip.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <title>Pay Slip</title>
</head>
<body>
    <form id="form1" runat="server">
            <div style="border: 3px solid black; padding: 50px; width: 30%; margin-left: 40%; margin-top: 60px">
                <%--<div style="width: 367px">
                    <asp:Image ID="Image1" runat="server" Height="145px" ImageUrl="~/img/Login.jpg" Width="361px" />
                    <br />
                    <br />
                </div>--%>
                <div class="form-group">
                    <label for="exampleInputEmail1">Email ID </label>
                    <asp:TextBox ID="TextBox1" placeholder="Enter Email ID" class="form-control" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    &nbsp;
                </div>


                <div class="form-group">
                    <label for="exampleInputEmail1">Password</label>
                    <asp:TextBox ID="TextBox2" placeholder="Enter Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Width="100%" Text="Login" OnClick="Button1_Click" />
                <br />
                <br />
                <%--<a href="" data-toggle="modal" data-target="#exampleModal" style="background: none; color: black; border: none; position: relative; left: 110px; text-decoration: underline">Create New Account</a>--%>
            </div>





            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">

                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <%-- <div style="width: 367px">
                            <asp:Image ID="Image2" runat="server" Height="155px" ImageUrl="~/img/41XVmLzks3L._AC_UY1100.jpg" Width="320px" />
                            <br />
                            <br />
                        </div>--%>
                        <div class="modal-header">
                            <center>
                                <h5 class="modal-title" id="exampleModalLabel">Create an Account</h5>
                            </center>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="login-container">


                                <div class="form-group">
                                    <label for="exampleInputEmail1">First Name</label>
                                    <asp:TextBox ID="TextBox3" placeholder="Enter First Name" class="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Last Name</label>
                                    <asp:TextBox ID="TextBox4" placeholder="optinal" class="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">91+Mobile</label>
                                    <asp:TextBox ID="TextBox5" placeholder="Enter MObile Number" class="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email</label>
                                    <asp:TextBox ID="TextBox6" placeholder="Enter Email ID" class="form-control" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group">
                                    <label for="exampleInputEmail1">Password</label>
                                    <asp:TextBox ID="TextBox7" placeholder="Enter Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Profile</label>
                                    <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                                </div>
                                <asp:Button ID="Button3" class="btn btn-primary" runat="server" Width="100%" Text="Registration" OnClick="Button3_Click" />


                            </div>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
            </div>
        </form>
</body>
</html>
