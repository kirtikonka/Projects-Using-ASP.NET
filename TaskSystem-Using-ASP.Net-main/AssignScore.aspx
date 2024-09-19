<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AssignScore.aspx.cs" Inherits="TS.AssignScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .pcoded-inner-content {
            padding: 20px;
        }

        .card {
            margin: 20px 0;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .card-header {
            background-color: #f8f9fa;
            padding: 10px 20px;
            border-bottom: 1px solid #dee2e6;
        }

        .custom-gridview {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

            .custom-gridview th, .custom-gridview td {
                padding: 10px;
                border: 1px solid #ddd;
                text-align: left;
            }

            .custom-gridview th {
                background-color: #f4f4f4;
            }

            .custom-gridview tr:nth-child(even) {
                background-color: #f9f9f9;
            }

            .custom-gridview tr:hover {
                background-color: #f1f1f1;
            }

        .custom-score-textbox {
            width: 60px;
            padding: 6px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .custom-assign-button {
            padding: 6px 12px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            .custom-assign-button:hover {
                background-color: #0056b3;
            }

        .main-body {
            padding: 20px;
        }
    </style>

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

                                        <h2>Assign Score</h2>
                                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                                        <asp:GridView ID="AssignScoreGridView" runat="server" AutoGenerateColumns="True" CssClass="custom-gridview" Width="100%" Height="100%">
                                            <Columns>

<%--                                                <asp:BoundField DataField="TaskID" HeaderText="Task ID" />
                                                <asp:BoundField DataField="fname" HeaderText="Name" />--%>
                                                <asp:BoundField DataField="UserEmail" HeaderText="Email" />
                                                <asp:BoundField DataField="FinishedDate" HeaderText="Finish Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                <asp:BoundField DataField="Status" HeaderText="Status"/>
                                                
                                                <asp:TemplateField HeaderText="Score">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="ScoreTextBox" runat="server" CssClass="custom-score-textbox"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="AssignScoreButton" runat="server" Text="Assign Score" CommandArgument='<%# Eval("TaskID") %>' OnClick="AssignScoreButton_Click" CssClass="custom-assign-button" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            
                                            </Columns>
                                        </asp:GridView>
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
        </div>
</asp:Content>
