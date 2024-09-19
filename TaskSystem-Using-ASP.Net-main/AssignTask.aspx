<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="TS.AssignTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script type="text/javascript">
        function LoadUsers() {
            var batchDropDown = document.getElementById('<%= DropDownList1.ClientID %>');
            var userDropDown = document.getElementById('<%= CheckBoxList1.ClientID %>');

            userDropDown.options.length = 0;

            var selectedBatch = batchDropDown.options[batchDropDown.selectedIndex].value;
            var xhr = new XMLHttpRequest();

            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var users = JSON.parse(xhr.responseText);
                    users.forEach(function (user) {
                        var option = document.createElement('option');
                        option.text = user.Name;
                        option.value = user.ID;
                        userDropDown.add(option);
                    });
                }
            };
            xhr.open("GET", "AssignTask.aspx?batch=" + batch, true);
            xhr.send();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-inner-content">
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 col-xl-8 vh-100 container py-5 h-100 row d-flex justify-content-center align-items-center col col-xl-10 row g-0">
                            <div class="card" style="border-radius: 1rem;">
                                <div class="card-header">

                                    <div class="d-flex align-items-center col-md-6 mb-6 p-4 p-md-5">
                                        <div class="card-body text-black">
                                            <div class="d-flex align-items-center mb-6 pb-3">
                                                <i class="fas fa-cubes fa-2x me-3" style="color: #ff6219;"></i>
                                                <span class="h1 fw-bold mb-0">Assign Task</span>
                                            </div>
                                            <br />
                                            <div data-mdb-input-init="" class="form-outline mb-6">
                                                <asp:Label ID="Label2" runat="server" Text="Task Name:"></asp:Label>
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div data-mdb-input-init="" class="form-outline mb-6">
                                                <label for="fileAttachment" runat="server" text="Attachment:"></label>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </div>
                                            <br />
                                            <div data-mdb-input-init="" class="form-outline mb-6">
                                                <label id="Label3" runat="server" for="ddlBatch" text="Batch:"></label>
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Batch" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Batch1" Value="Batch1"></asp:ListItem>
                                                    <asp:ListItem Text="Batch2" Value="Batch2"></asp:ListItem>
                                                    <asp:ListItem Text="Batch3" Value="Batch3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <br />
                                            <div data-mdb-input-init="" class="form-outline mb-6">
                                                <label id="Label4" runat="server" text="User:"></label>
                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                                            </div>
                                            <br />
                                            <div class="pt-3 mb-6">
                                                <asp:Button ID="Button1" runat="server" class="btn btn-primary pt-1 mb-6" Text="Assign" OnClick="btnAssign_Click" />
                                            </div>
                                            <br />
                                            <asp:Label ID="lblMessage" runat="server" class="text-danger"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="card-body">
                                        <h3 class="mb-4">Your Assigned Tasks</h3>
                                        <asp:GridView ID="GridViewTasks" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                                                <asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date"
                                                    DataFormatString="{0:yyyy-MM-dd}" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblNoTasks" runat="server" Text="No tasks assigned yet."
                                            CssClass="text-muted" Visible="false"></asp:Label>
                                    </div>


                                    <div class="card-block">
                                        <div class="row">
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
