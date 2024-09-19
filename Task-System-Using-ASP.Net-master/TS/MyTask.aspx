<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MyTask.aspx.cs" Inherits="TS.MyTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .center-wrapper {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; 
        }
        .grid-view-container {
            width: 80%; 
            margin: 0 auto;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 1em;
            text-align: left;
        }
        .grid-view th, .grid-view td {
            padding: 12px 15px;
            border: 1px solid #ddd;
        }
        .grid-view th {
            background-color: #f4f4f4;
        }
        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .grid-view tr:hover {
            background-color: #f1f1f1;
        }
        .btn {
            padding: 8px 16px;
            margin: 4px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn-ontime {
            background-color: #4CAF50;
            color: white;
        }
        .btn-late {
            background-color: #f44336;
            color: white;
        }
        .btn-upload {
            background-color: #008CBA;
            color: white;
        }
        .btn:disabled {
            background-color: #ccc;
            cursor: not-allowed;
        }
        .file-upload {
            margin-top: 8px;
        }
    </style>

    <script type="text/javascript">
        function checkOnTimeButton() {
            var gridView = document.getElementById('<%= TaskGridView.ClientID %>');
            var rows = gridView.getElementsByTagName('tr');

            for (var i = 1; i < rows.length; i++) {
                var assignDate = new Date(rows[i].cells[2].innerText);
                var now = new Date();
                var diffHours = Math.abs(now - assignDate) / 36e5;

                if (diffHours > 48) {
                    var onTimeButton = rows[i].getElementsByTagName('input')[0];
                    onTimeButton.disabled = true;
                }
            }
        }
    </script>
    <script>
        function updateStatusOptions() {
            var gridView = document.getElementById('<%= TaskGridView.ClientID %>');
            var rows = gridView.getElementsBylTagName('tr');
            for (var i = 1; i < rows.length; i++) {
                var assignedDate = new Date(rows[i].cells[2].innerText);
                var currentDate = new Date();
                var timeDiff = currentDate - assignedDate;
                var hoursDiff = timeDiff / (1000 * 3600);

                var radioList = rows[i].getElementsByTagName('input');
                if (hoursDiff > 48) {
                    radioList[0].disabled = true;
                    radioList[1].checked = true;
                }
            }
        }
        window.onload = updateStatusOptions;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-inner-content d-flex justify-content-center">
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 col-xl-8">
                            <div class="card">
                                <div class="card-header">
                                    <div class="center-wrapper">
                                        <div class="grid-view-container">
                                            <asp:GridView ID="TaskGridView" runat="server" AutoGenerateColumns="False" class="grid-view" OnRowDataBound="TaskGridView_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
<%--                                                    <asp:BoundField DataField="AssignDate" HeaderText="Assign Date" />--%>

                                                    <asp:TemplateField HeaderText="Attachment">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="AttachmentLink" runat="server"
                                                                NavigateUrl='<%# "DownloadSolution.ashx?file=" + Eval("Attachment") %>' Text="Download" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Solution Upload">
                                                        <ItemTemplate>
                                                            <asp:FileUpload ID="SolutionUpload" runat="server" class="file-upload" />
                                                            <asp:Button ID="UploadSolutionButton" runat="server" Text="Upload" class="btn btn-upload" CommandArgument='<%# Eval("TaskId") %>' OnClick="UploadSolutionButton_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

<%--                                                    <asp:TemplateField HeaderText="Solution">
                                                        <ItemTemplate>
                                                            <asp:FileUpload ID="FileUploadSolution" runat="server" CommandArgument='<%#Eval("solution")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

<%--                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Button ID="OntimeButton" runat="server" Text="Ontime" class="btn btn-ontime" CommandArgument='<%# Eval("TaskId") %>' OnClick="OntimeButton_Click" />
                                                            <asp:Button ID="LateButton" runat="server" Text="Late" class="btn btn-late" CommandArgument='<%# Eval("TaskId") %>' OnClick="LateButton_Click" />
                                                            <script type="text/javascript">
                                                                checkOnTimeButton();
                                                            </script>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:RadioButtonList ID="RadioButtonListStatus" runat="server">
                                                                <asp:ListItem Text="On Time" Value="On Time" />
                                                                <asp:ListItem Text="Late" Value="Late" />
                                                            </asp:RadioButtonList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Submit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        <asp:Label ID="lblNoTasks" runat="server" Text="No tasks assigned yet." CssClass="text-muted" Visible="false"></asp:Label>
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
