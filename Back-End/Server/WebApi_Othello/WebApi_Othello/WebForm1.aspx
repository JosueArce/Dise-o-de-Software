<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApi_Othello.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="hitCount" style="font-size:200px;"></div>
        </div>
    </form>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.2.min.js"></script>

    <script type="text/javascript">
        $(function(){
            var con = $.hubConnection();
            var hub = con.createHubProxy('hitCounter');
            hub.on('onHitRecorded', function (i) {
                $('#hitCount').text(i);
            });
            con.start(function () {
                hub.invoke('recordHit');
            });
            
        })
    </script>

</body>
</html>
