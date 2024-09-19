<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="TS.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                            <h2>Task History</h2>
                                            <asp:GridView ID="GridViewHistory" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewHistory_RowCommand" DataKeyNames="TaskID">
                                                <Columns>
                                                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                                                    <asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="FinishedDate" HeaderText="Finished Date" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="Score" HeaderText="Score" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonDownload" runat="server" Text="Download" CommandName="DownloadAttachment" CommandArgument='<%# Eval("TaskID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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
