<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_21June2024_WebFormProject.Calculator" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
</head>
<body>
    <form id="form2" runat="server">
        <div style ="border:2px solid blue;margin:10%; padding:50px;">
            <h2>Calculator</h2>
            <label for="txtNumber1">Number 1:</label>
            <asp:TextBox ID="txtNumber1" runat="server"></asp:TextBox>
            <br /><br />
            <label for="txtNumber2">Number 2:</label>
            <asp:TextBox ID="txtNumber2" runat="server"></asp:TextBox>
            <br /><br />
            <label for="ddlOperation">Operation:</label>
            <asp:DropDownList ID="ddlOperation" runat="server">
                <asp:ListItem Text="Addition (+)" Value="add"></asp:ListItem>
                <asp:ListItem Text="Subtraction (-)" Value="subtract"></asp:ListItem>
                <asp:ListItem Text="Multiplication (*)" Value="multiply"></asp:ListItem>
                <asp:ListItem Text="Division (/)" Value="divide"></asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" BackColor="Lime" ForeColor="Black" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" Text="Result:"></asp:Label>
        </div>
    </form>
</body>
</html>
