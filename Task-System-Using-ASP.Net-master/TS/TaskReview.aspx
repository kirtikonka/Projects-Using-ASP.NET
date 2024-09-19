<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TaskReview.aspx.cs" Inherits="TS.TaskReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" type="text/css" href="styles.css" />
    <style>
        .center-content {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

            .grid-view th, .grid-view td {
                padding: 12px 15px;
                border: 1px solid #ddd;
                text-align: center;
            }

        .btn {
            padding: 5px 10px;
            text-align: center;
            border-radius: 5px;
            cursor: pointer;
            margin: 2px;
        }

        .btn-ontime {
            background-color: #4CAF50;
            color: white;
        }

        .btn-late {
            background-color: #f44336;
            color: white;
        }

        .btn-approve {
            background-color: #008CBA;
            color: white;
        }

        .btn-reject {
            background-color: #e7e7e7;
            color: black;
        }

        .card-header {
            font-size: 1.5em;
            margin-bottom: 10px;
        }
    </style>

    <div class="pcoded-inner-content">
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 col-xl-8">
                            <div class="card">
                                <div class="card-header">
                                    <div>
                                        <h2>Task Review</h2>
                                        <asp:Label ID="lblMessage" runat="server" class="text-danger"></asp:Label>
                                        <asp:GridView ID="gvTasks" class="grid-view" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                                                <asp:BoundField DataField="Name" HeaderText="User Name" />
                                                <asp:BoundField DataField="TaskID" HeaderText="Task ID" Visible="False" />

                                                <asp:TemplateField HeaderText="Solution">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="SolutionLink" runat="server" NavigateUrl='<%# "DownloadSolution.ashx?file=" + Eval("Solution") %>' Text="Download" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Status" HeaderText="Status" />

                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:Button ID="ApproveButton" runat="server" Text="Approve" class="btn btn-approve" CommandName="Approve" CommandArgument='<%# Eval("TaskID") %>' OnClick="ApproveButton_Click" />
                                                        <asp:Button ID="RejectButton" runat="server" Text="Reject" class="btn btn-reject" CommandName="Reject" CommandArgument='<%# Eval(" TaskID") %>' OnClick="RejectButton_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
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
</asp:Content>
