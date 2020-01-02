<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="LobbyLog4.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator</title>
<style type="text/css">
 .text {
font-family:Calibri;
font-size:22px;
height:40px;
 }

</style>

</head>
<body>
    <form id="form1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

<asp:Label ID="LblLogin_Name" runat="server" Visible="false" />
<asp:Label ID="LblLogin_NETID" runat="server" Visible="false" />
<asp:Label ID="LblLogin_EMPLID" runat="server" Visible="false" />
<asp:Label ID="LblLobbyist_NETID" runat="server" Visible="false" /> 
<asp:Label ID="LblLobbyist_EMPLID" runat="server" Visible="false" />


<table width="60%" align="center" border="0" style="border-color: silver; border-collapse:collapse; border-spacing:0;">
    <tr><td>

<table width="100%" align="center" border="0">

<tr><td style="width:200px; height:50px; vertical-align:top; font-family:Calibri; font-size:18px; font-weight:500; text-align:right;" nowrap="nowrap"><br />
    &nbsp;<asp:Label id="UserName" runat="server"/>&nbsp;</td>
    <td align="center"><font style="font-family:Calibri; font-size:xx-large;">LobbyLog4</font><br />
                       <font style="font-family:Calibri; font-size:medium;">Consumer Reports</font></td>
    <td style="width:200px;">&nbsp;&nbsp;</td></tr>

<tr><td style="text-align:center; height:40px; font-family:Calibri; font-weight:bold; font-size:xx-large; color:#DAA520;" colspan="3">Administration</td></tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="MaintainLobbyist.aspx">Maintain Lobbyist Profiles</asp:HyperLink>&nbsp;&nbsp;</td>
    </tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="MimicLobbyist.aspx">Delegate a Lobbyist</asp:HyperLink></td>
</tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2"> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="UnlockLobbyist.aspx">Unlock a week that is requested by a Lobbyist</asp:HyperLink></td>
</tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="RecordingTimeLobbyist.aspx">Lobbyist Time Recording</asp:HyperLink></td>
</tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text">Reports</td>
    <td>&nbsp;&nbsp;</td></tr>

<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IRS Report&nbsp;&nbsp;</td>
    </tr>
<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;State Report&nbsp;&nbsp;</td>
    </tr>
<tr><td>&nbsp;&nbsp;</td>
    <td class="text" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To be Determined&nbsp;&nbsp;</td>
    </tr>


</table>

</td></tr></table>




    </form>
</body>
</html>
