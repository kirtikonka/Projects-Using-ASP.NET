<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="test.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>

            <div class="card" style="width: 18rem;">
              <img src='<%Eval("acc_profile");%>' class="card-img-top" height="100" width="100">
              <div class="card-body">
                <h5 class="card-title"><%Eval("acc_user");%></h5>
              </div>
              <ul class="list-group list-group-flush">
                <li class="list-group-item">Email ID: <%Eval ("acc_email");%></li>

                <li class="list-group-item">Role: <%Eval("acc_role");%></li>
              </ul>
              <div class="card-body">
                <asp:Button ID="Button1" CommandName="Delete" CommandArgument='<%Eval("id") %>' class="btn btn-danger" runat="server" Text="Delete Account?" />
              </div>
            </div>

        </ItemTemplate>
    </asp:DataList>

</asp:Content>
