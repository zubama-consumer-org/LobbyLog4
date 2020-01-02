Public Class _Default
    Inherits System.Web.UI.Page
    Dim SQL, SQL1, SQL2, ReturnValue As String
    Dim LocalClass As New GetData
    'Dim DS, DS1, DS3, DS4 As SqlDataReader
    Dim DT, DT1, DT2 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        txtNETID.Focus()

        If IsPostBack Then

        Else

        End If

        Cursor()


    End Sub

    Sub Cursor()
        btnLogin.Attributes.Add("onMouseOver", "this.style.cursor='pointer'; this.style.color='blue';")
        btnLogin.Attributes.Add("onMouseOut", "this.style.cursor='pointer'; this.style.color='black';")
    End Sub


    Sub RightsDisplay()

        SQL = "select ADV_ADM,ADV_SAL,ADV_USER,ADV_ADM+ADV_USER+ADV_SAL Rights,E.* from"
        SQL &= "(select count(*)ADV_ADM from ID_tbl where rights like '%ADVCATEADMIN%' and NETID ='" & Trim(txtNETID.Text) & "' and PSWRD='" & Trim(txtPSWRD.Text) & "')A,"
        SQL &= "(select count(*)ADV_USER from ID_tbl where rights like '%ADVCATEUSER%' and NETID ='" & Trim(txtNETID.Text) & "' and PSWRD='" & Trim(txtPSWRD.Text) & "')B,"
        SQL &= "(select count(*)ADV_SAL from ID_tbl where rights like '%ADVCATEACCSAL%' and NETID ='" & Trim(txtNETID.Text) & "' and PSWRD='" & Trim(txtPSWRD.Text) & "')D,"
        SQL &= "(select * from id_tbl where NETID ='" & Trim(txtNETID.Text) & "' and PSWRD='" & Trim(txtPSWRD.Text) & "')E"

        DT = LocalClass.ExecuteSQLDataSet(SQL)

        If CDbl(DT.Rows(0)("Rights").ToString) = 0 Then
            Response.Write("<table width=100%><tr><td height=200px></td></tr><tr><td>")
            Response.Write("<p align=center><img src=/Images/Top3.png></p></p></p>")
            Response.Write("<p align=center><font color=blue><b>Thank you For your interest In accessing LobbyLog application.<br/><br/>However, you are Not eligible to use this feature of CRNet.</b></p></p></p>")
            Response.Write("<p align=center><a href='https://sites.google.com/a/consumer.org/crnet/'><img src=/Images/Bottom3_Back.png></a></p></td></tr></table>")
            Response.End()
        Else
            Session("EMPLID") = DT.Rows(0)("EMPLID").ToString
            Session("NETID") = DT.Rows(0)("NETID").ToString
            Session("PSWRD") = DT.Rows(0)("PSWRD").ToString
            Session("First") = DT.Rows(0)("First").ToString
            Session("Last") = DT.Rows(0)("Last").ToString

            Session("ADV_ADM") = DT.Rows(0)("ADV_ADM").ToString
            Session("ADV_SAL") = DT.Rows(0)("ADV_SAL").ToString
            Session("ADV_USER") = DT.Rows(0)("ADV_USER").ToString

            lblNAME.Text = "Welcome " & Session("First") & " " & Session("Last")

            If Session("ADV_ADM") = 1 Then
                Response.Redirect("./Admin/Admin.aspx")
            Else
                'ADMIN.Visible = False
            End If



        End If

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Session("EMPLID") = ""

        If Session("EMPLID") = Nothing Then
            SQL = "select count(*)CNT_Rights from ID_tbl where status='A' and rights like '%ADVCAT%' and NETID='" & Trim(txtNETID.Text) & "'"
            'Response.Write(SQL) : Response.End()
        End If
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        If Len(Trim(txtNETID.Text)) = 0 Or Len(Trim(txtPSWRD.Text)) = 0 Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Login", "<script language='JavaScript'> alert('Login ID or Password field is empty.'); </script>")
            Return
        End If


        If CDbl(DT.Rows(0)("CNT_Rights").ToString) = 0 Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Login", "<script language='JavaScript'> alert('You do not have rights to view this application.'); </script>")
        Else
            SQL1 = "select count(*)CNT_LOGON from ID_tbl where status='A' and rights like '%ADVCAT%'"
            SQL1 &= " and NETID ='" & Trim(txtNETID.Text) & "' and PSWRD='" & Trim(txtPSWRD.Text) & "'"
            DT1 = LocalClass.ExecuteSQLDataSet(SQL1)

            If DT1.Rows(0)("CNT_LOGON").ToString = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Login", "<script language='JavaScript'> alert('Your NETID or Password is incorrect.'); </script>")
                Return
            Else
                RightsDisplay()
            End If
        End If



    End Sub

End Class