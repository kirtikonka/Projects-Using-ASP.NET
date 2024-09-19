<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRCalender.aspx.cs" Inherits="calender.HRCalender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 3px solid black; padding: 50px; width: 30%; margin-left: 35%; margin-top: 60px">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            <asp:DropDownList ID="ddlEvents" runat="server" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged">
                <asp:ListItem Text="Holiday" Value="Holiday"></asp:ListItem>
                <asp:ListItem Text="Birthday" Value="Birthday"></asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            <asp:TextBox ID="txtEventName" runat="server" placeholder="Event Name"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Event" OnClick="btnAdd_Click" />
            
            <asp:Button ID="btnDelete" runat="server" Text="Delete Event" OnClick="btnDelete_Click" />
        </div>



        <%--<asp:DropDownList ID="ddlEventType" runat="server">
                <asp:ListItem Text="Holiday" Value="Holiday"></asp:ListItem>
                <asp:ListItem Text="Birthday" Value="Birthday"></asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="txtEventDate" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Calendar ID="Calendar2" runat="server" Visible="false"></asp:Calendar>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" OnClick="btnAddEvent_Click" />--%>

        <%--<asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <div>
                    <span><%# Eval("EventType") %></span>
                    <span><%# Eval("EventDate", "{0:dd/MM/yyyy}") %></span>
                    <span><%# Eval("Description") %></span>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteEvent" CommandArgument='<%# Eval("EventID") %>' OnCommand="btnDelete_Command" />
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>
    </form>
</body>
</html>
