<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="Payslip.ApplyLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        
        Select:
        <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="107px">
            <asp:ListItem>pl</asp:ListItem>
            <asp:ListItem>cl</asp:ListItem>
            <asp:ListItem>sl</asp:ListItem>
        </asp:DropDownList>

        <br />
        <br />

        <div style="display: flex; gap: 10px;">
            From 
            <asp:TextBox ID="TextBox1" class="form-control" Style="width: 200px" runat="server" TextMode="Date"></asp:TextBox>
            To 
            <asp:TextBox ID="TextBox2" class="form-control" Style="width: 200px" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
        </div>

        Reason:<br />
        &nbsp;<asp:TextBox ID="TextBox3" runat="server" Height="146px" Width="475px"></asp:TextBox>

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Style="display: flex; align-items: center;" Text="Apply" OnClick="Button1_Click1" />
        <br />
        <br />
        <div>
            Balanced Leaves<br />
            <br />
            PL:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            CL:
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            SL:
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        </div>

    </div>

</asp:Content>
