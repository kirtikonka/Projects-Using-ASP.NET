<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ReTask.aspx.cs" Inherits="TS.ReTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Re-Assign Task</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="pcoded-inner-content">
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 col-xl-8">
                            <div class="card">
                                <div class="card-header">
                                    <h2>Assign Task</h2>
                                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                                    <div class="form-group">
                                        <label for="txtTaskName">Task Name:</label>
                                        <asp:TextBox ID="txtTaskName" CssClass="form-control" runat="server"></asp:TextBox><br />
                                    </div>
                                    <div class="form-group">
                                        <label for="fileAttachment">Attachment:</label>
                                        <asp:FileUpload ID="fileAttachment" CssClass="form-control" runat="server" /><br />

                                        <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
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
    </div>
</asp:Content>
