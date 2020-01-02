<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MaintainLobbyist.aspx.vb" Inherits="LobbyLog4.MaintainLobbyist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain Lobbyist Profiles</title>
<style type="text/css">
 .text {
 font-family:Calibri;
 font-size:22px;
 height:40px;
 }
.Lobbyist{
 width:400px; 
 font-family:Calibri; 
 font-size:large; 
 text-align:left;
 vertical-align:top;
}
.Federal{
  width:400px; 
  font-family:Calibri; 
  font-size:large; 
  text-align:right;
  vertical-align:top;
}

.State {
  font-family:Calibri; 
  font-weight:normal; 
  color:blue; 
  width:200px;
  font-size:smaller; 
  word-wrap: break-word; 
  display: inline-block; 
  text-align:left;
  vertical-align:top;
    }

.StateRequested {
  font-size:medium; 
  color:black; 
  font-family:Calibri;
  text-align:center;
  font-weight:bold;
  text-decoration:underline;

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

<tr><td style="width:200px; height:50px; vertical-align:top; font-family:Calibri; font-size:18px; font-weight:500; text-align:right;" nowrap="nowrap" ><br />
    &nbsp;<asp:Label id="UserName" runat="server"/>&nbsp;</td>
    <td align="center"><font style="font-family:Calibri; font-size:xx-large;">LobbyLog4</font><br />
                       <font style="font-family:Calibri; font-size:medium;">Consumer Reports</font></td>
    <td style="width:200px; vertical-align:top; text-align:left;"><a href="Admin.aspx" title="Home"><br />
        <img src="../Images/Home.png" height="20" width="20" alt=""/></a>&nbsp;</td></tr>
<tr><td style="text-align:center; height:40px; font-family:Calibri; font-weight:bold; font-size:xx-large; color:#DAA520;" colspan="3">Administration</td></tr>
<tr><td style="text-align:center; height:40px; font-family:Calibri; font-weight:bold; font-size:x-large; color:black;" colspan="3">Maintain Lobbyist Profiles</td></tr>


<tr><td>&nbsp;&nbsp;</td>
    <td style="text-align:center; height:50px;">
        <table style="width:100%;">
            <tr><td style="width:30%; font-family:Calibri; font-size:large; text-align:right;">Existing User </td>
                <td><asp:DropDownList ID="DDLEmployees" runat="server"  AutoPostBack="true" 
                    OnSelectedIndexChanged="DDLEmployees_SelectedIndexChanged" Width="200px"></asp:DropDownList></td>
                <td style="width:30%;">&nbsp;&nbsp;</td></tr></table>
        <hr/>
    </td>
    <td>&nbsp;&nbsp;</td></tr>

<tr><td colspan="3" style="text-align:center; height:30px;">
    <asp:Label ID="LblLobbyist_NAME" runat="server" style="font-family:Calibri; font-size:x-large;"></asp:Label></td></tr>

<tr><td>&nbsp;&nbsp;</td>
    <td><table style="width:100%;" border="0">
            <tr><td class="Lobbyist"><asp:CheckBox ID="CB1" runat="server"/>Lobbyist</td>
                
                <td class="Federal"><asp:CheckBox ID="CB4" runat="server"/>Federal Lobbyist</td></tr>

            <tr><td class="Lobbyist"><asp:CheckBox ID="CB2" runat="server"/>Administrator</td>
                <td class="Federal"><asp:CheckBox ID="CB5" runat="server"/>State Lobbyist&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>

           <tr><td class="Lobbyist"><asp:CheckBox ID="CB3" runat="server" />Receive Email</td><td>&nbsp;&nbsp;</td></tr> 

            <tr><td class="Lobbyist">&nbsp;&nbsp;</td>
                <td style="font-size:small; text-align:right;">Hold Ctrl-key to select multiple states&nbsp;&nbsp;</td></tr>

            <tr><td class="Lobbyist"> </td>
                
                <td class="Federal">

                    <table border="0" width="100%"><tr>
                       <td class="State"><div class="StateRequested">State Requested</div><br /><%= Session("StateName") %></td>
                       <td>
                           <asp:ListBox ID="LBoxStateList" runat="server" Rows="25" SelectionMode="Multiple" 
                               OnSelectedIndexChanged="LBoxState_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                           </td>
                       
                    </tr></table>
               
                </td></tr>


</table>

    </td>
    <td>&nbsp;&nbsp;</td></tr>

<tr><td>&nbsp;&nbsp;</td>
    <td >&nbsp;&nbsp;</td>
    <td>&nbsp;&nbsp;</td></tr>
<tr><td colspan="3" style="text-align:center;"><asp:Button ID="BtnSaveData" runat="server" Text="Save" 
    BackColor="#EAE5D1" BorderStyle="None" Width="80px" Font-Size="Medium" /></td></tr>

<tr><td>&nbsp;&nbsp;</td>
    <td >&nbsp;&nbsp;</td>
    <td>&nbsp;&nbsp;</td></tr>

</table>

</td></tr></table>


    </form>
</body>
</html>
