<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ReTaskUser.aspx.cs" Inherits="TS.ReTaskUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="d-flex justify-content-center">
        <h2>Rejected Tasks</h2>
        <asp:GridView ID="GridViewRejectedTasks" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewRejectedTasks_RowCommand" DataKeyNames="ID,TaskID">
            <Columns>
                <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                <asp:BoundField DataField="OriginalSubmission" HeaderText="Original Submission Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="RejectedOn" HeaderText="Rejected On" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Re-Submit Solution">
                    <ItemTemplate>
                        <asp:FileUpload ID="FileUploadSolution" runat="server" />
                        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CommandName="SubmitTask" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
