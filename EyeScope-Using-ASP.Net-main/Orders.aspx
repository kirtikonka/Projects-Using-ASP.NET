<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="test.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <header>
        <style>
            .myclass{
                visibility:hidden;
            }
        </style>
    </header>
    
    <br />
    <br />
   <div style="display:flex; gap:10px;align-items:center">
    From <asp:TextBox ID="TextBox1" class="form-control" style="width:200px" runat="server" TextMode="Date"></asp:TextBox>
    To <asp:TextBox ID="TextBox2" class="form-control" style="width:200px" runat="server" TextMode="Date"></asp:TextBox>
    <asp:Button ID="Button1" class="btn btn-primary"  runat="server" Text="Search" OnClick="Button1_Click" />
        </div>
    <br/>
    <br/>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

        <AlternatingRowStyle BackColor="White" ForeColor="#BF40BF"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="pid" HeaderText="ID Number" ReadOnly="True" InsertVisible="False" SortExpression="pid">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pname" HeaderText="Name" SortExpression="pname">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pcat" HeaderText="Category" SortExpression="pcat">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="suser" HeaderText="User Name" SortExpression="suser">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            
            <asp:BoundField DataField="perprice" HeaderText="Per Price" SortExpression="perprice">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="pstatus" HeaderText="Product Status" SortExpression="pstatus">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <!-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CommandName="Status" CommandArgument="<%Eval("pid") %>" class="btn btn-warning" Text="Approved"/>
                </ItemTemplate>
            </asp:TemplateField> -->
        </Columns>
        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#BF40BF" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
    </asp:GridView>


    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbconn %>' SelectCommand="SELECT * FROM [placeorder]"></asp:SqlDataSource>
        <!--
        <asp:GridView ID="GridView2" style="position:relative; bottom:400px;" runat="server" AutoGenerateColumns="False" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

            <AlternatingRowStyle BackColor="White" ForeColor="#BF40BF"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="pid" HeaderText="ID Number" ReadOnly="True" InsertVisible="False" SortExpression="pid">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="pname" HeaderText="Name" SortExpression="pname">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="pcat" HeaderText="Category" SortExpression="pcat">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="suser" HeaderText="User Name" SortExpression="suser">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
                <asp:BoundField DataField="perprice" HeaderText="Per Price" SortExpression="perprice">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
                <asp:BoundField DataField="pstatus" HeaderText="Product Status" SortExpression="pstatus">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>


            </Columns>
            <EditRowStyle BackColor="#999999"></EditRowStyle>

            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

            <HeaderStyle BackColor="#BF40BF" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
        </asp:GridView>
    -->
</asp:Content>
