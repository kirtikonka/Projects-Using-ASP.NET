<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCalender.aspx.cs" Inherits="calender.UserCalender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 3px solid black;padding: 50px; width: 30%; margin-left: 33%; margin-top: 60px">
            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" BackColor="White" BorderColor="#660033"></asp:Calendar>
            <br />
            <asp:Label ID="lblEventDetails" runat="server"></asp:Label>
        </div>
    </form>

    <div id="calendar"></div>

<script>
    $(document).ready(function() {
        $('#calendar').fullCalendar({
            // Options for FullCalendar
            events: '/GetEvents.ashx'  // Endpoint to fetch events
        });
    });
</script>

</body>
</html>
