<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="LobbyLog4._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LobbyLog4</title>
    <style type="text/css">
  

    </style>
</head>
<body>
  	<form id="Form1" method="post" runat="server">
		 
<table width="100%" align="center" border="0">
    <tr><td align="center"><font style="font-family:Calibri; font-size:xx-large;">LobbyLog4</font><br />
                          <font style="font-family:Calibri; font-size:medium;">Consumer Reports</font></td></tr>
    <tr><td style="text-align:center; font-size:larger; font-weight:bolder; color:darkgreen;">
            <asp:Label ID="lblNAME" runat="server" CssClass="Label_StyleSheet"/></td></tr>

    <tr><td align="center">
     <table align=center style="width: 430px;" border="0">
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td style="width: 130px; height: 26px; font-weight:bold; font-family:Calibri; text-align:right;">Login ID&nbsp;</td>
             <td style="height: 26px; width: 170px;"><asp:TextBox ID="txtNETID" runat="server" Width="160px" /></td>
             <td style="width: 130px;">&nbsp;</td></tr>
         
         <tr><td style="width: 130px; height: 26px; font-weight:bold; font-family:Calibri; text-align:right;">Password&nbsp;</td>
             <td style="width: 170px"><asp:TextBox ID="txtPSWRD" runat="server" Width="160px" TextMode="Password"></asp:TextBox></td>
             <td style="width: 130px;">&nbsp;</td></tr>
         
         <tr><td style="width: 130px; height: 30px;">&nbsp;&nbsp;&nbsp;</td>
             <td style="width: 170px; height: 30px; text-align:center;">
                 <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="#EAE5D1" BorderStyle="None" Width="80px" Font-Size="Medium" /></td>
             <td style="width: 130px;">&nbsp;</td></tr>
         <tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td></tr>
         <tr><td colspan="3" style="font-family: Calibri; text-align:center;">
             <a style="text-decoration:none; color:blue;" onmouseover="this.style.color='red';" onmouseout="this.style.color='blue';" 
                 target="_blank" href="http://cu-ykvm-ars/QPM/User/Identification/">Forgot, Change or Unlock my Password</a></td></tr>

     
     
     
     </table>


                            

             </td></tr>

         <tr><td align="center">
						 

             </td></tr>
				
</table>
			 
  </form>
 </body>
</html>