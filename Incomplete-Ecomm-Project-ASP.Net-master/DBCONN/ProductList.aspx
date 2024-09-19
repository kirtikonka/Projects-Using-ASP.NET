<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="DBCONN.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">
              <img class="card-img-top" src="<%#Eval("pimg")%>" height="100" width="100" alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title"><%#Eval("pname") %></h5>
              </div>
              <ul class="list-group list-group-flush">
                <li class="list-group-item">Product Category: <%#Eval("pcat") %></li>
                <li class="list-group-item">Product Price: <%#Eval("price") %></li>
              </ul>
              <div class="card-body">
                  <asp:Button ID="Button1" runat="server" Text="Add To Cart" />
              </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
