<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="TS.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js" integrity="sha384-+sLIOodYLS7CIrQpBjl+C7nPvqq+FbNUBDunl/OZv93DB7Ln/533i8e/mZXLi/P+" crossorigin="anonymous"></script>
    <title>Registeration</title>
</head>
<body>
<form id="form1" runat="server">
        <div class="vh-100 gradient-custom">
            <div class="container py-5 h-100">
                <div class="row justify-content-center align-items-center h-100">
                    <div class="col-12 col-lg-9 col-xl-7">
                        <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                            <div class="card-body p-4 p-md-5">
                                <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Registration Form</h3>

                                <div class="row">
                                    <div class="col-md-6 mb-4">
                                        <div data-mdb-input-init="" class="form-outline">
                                            <asp:Label ID="Label1" runat="server" Text="First Name" class="form-label"></asp:Label>
                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <div data-mdb-input-init="" class="form-outline">
                                            <asp:Label ID="Label2" runat="server" Text="Last Name" class="form-label"></asp:Label>
                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 mb-4 d-flex align-items-center">
                                        <div data-mdb-input-init="" class="form-outline datepicker w-100">
                                            <asp:Label ID="Label3" runat="server" Text="Email ID" class="form-label"></asp:Label>
                                            <asp:TextBox ID="TextBox3" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4 d-flex align-items-center">
                                        <div data-mdb-input-init="" class="form-outline datepicker w-100">
                                            <asp:Label ID="Label4" runat="server" Text="Password" class="form-label"></asp:Label>
                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 mb-4 d-flex align-items-center">
                                        <div data-mdb-input-init="" class="form-outline datepicker w-100">
                                            <asp:Label ID="Label5" runat="server" Text="Select your Batch" class="form-label"></asp:Label><br />
                                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Height="50px" Width="150px" class="form-control form-control-lg">
                                                <asp:ListItem>Batch 1</asp:ListItem>
                                                <asp:ListItem>Batch 2</asp:ListItem>
                                                <asp:ListItem>Batch 3</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="d-flex align-items-center" style="align-content: center; left: 35%">
                                    <asp:Button ID="Button1" runat="server" Text="Submit" data-mdb-ripple-init="" class="btn btn-primary btn-lg btn btn-dark btn-lg btn-block" OnClick="Button1_Click" />
                                </div>
                                <br />
                                <p class="mb-5 pb-lg-2 d-flex align-items-center" style="color: #393f81;">
                                    Back to <a href="Login.aspx">Login page</a>
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
