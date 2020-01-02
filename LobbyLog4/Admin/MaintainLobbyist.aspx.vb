Public Class MaintainLobbyist
    Inherits System.Web.UI.Page
    Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, ReturnValue As String
    Dim LocalClass As New GetData
    Dim LogonClass As New LogonClass
    Dim DT, DT1, DT2, DT3, DT4, DT5 As New DataTable
    Dim A, B, C, D As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserName.Text = "Welcome " & Session("First") '& " " & Session("Last")
        LblLogin_Name.Text = Session("First") & " " & Session("Last")
        LblLogin_NETID.Text = Session("NETID")
        LblLogin_EMPLID.Text = Session("EMPLID")

        If IsPostBack Then
            'Response.Write("IsPostBack")
        Else
            LoadState()
            LoadEmployees()
        End If

    End Sub

    Protected Sub LoadEmployees()

        DDLEmployees.Items.Clear()
        SQL = "select * from ps_employees order by name"
        DT = LocalClass.ExecuteSQLDataSet(SQL)
        DDLEmployees.Items.Clear()
        DDLEmployees.Items.Add(New ListItem("  Choose Employee  ", "0"))
        For i = 0 To DT.Rows.Count - 1
            DDLEmployees.Items.Add(New ListItem(DT.Rows(i)("name").ToString, DT.Rows(i)("emplid").ToString))
        Next
        LocalClass.CloseSQLServerConnection()

    End Sub
    Protected Sub DDLEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLEmployees.SelectedIndexChanged
        If DDLEmployees.SelectedValue = 0 Then
            DDLEmployees.SelectedValue = 0
            LblLobbyist_NAME.Text = ""
            LblLobbyist_EMPLID.Text = ""
            LblLobbyist_NETID.Text = ""
        Else
            SQL = "select NETID from ps_employees where emplid=" & DDLEmployees.SelectedValue
            DT = LocalClass.ExecuteSQLDataSet(SQL)
            LblLobbyist_NAME.Text = DDLEmployees.SelectedItem.ToString
            LblLobbyist_EMPLID.Text = DDLEmployees.SelectedValue
            LblLobbyist_NETID.Text = DT.Rows(0)("NETID").ToString
        End If

    End Sub


    Protected Sub LoadState()
        LBoxStateList.Items.Clear()
        SQL = "Select * from LobbyLog4_States_tbl where state_id not in (55) order by State_ID"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        LBoxStateList.Items.Clear()
        LBoxStateList.Items.Add(New ListItem("--Clear Selection--", "0"))

        LBoxStateList.Items(0).Attributes.Add("style", "color: BLUE")

        For i = 0 To DT.Rows.Count - 1
            LBoxStateList.Items(0).Attributes.Add("style", "color: BLUE")
            LBoxStateList.Items.Add(New ListItem(DT.Rows(i)("StateName").ToString, DT.Rows(i)("State_ID").ToString))
        Next
        LocalClass.CloseSQLServerConnection()

    End Sub

    Protected Sub LBoxState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBoxStateList.SelectedIndexChanged
        Dim STE As String = ""
        Dim ABV As String = ""
        Dim CLR As Integer
        Dim I, Z As Integer

        '--Choose Multple States--
        LBoxStateList.Items(0).Attributes.Add("style", "color: BLUE")

        For I = 0 To LBoxStateList.Items.Count - 1

            If LBoxStateList.Items(I).Selected = True Then
                If LBoxStateList.Items(I).Value > 0 Then
                    STE = Trim(STE) & "'" & LBoxStateList.Items(I).Text & "',"
                    CLR = 1
                Else
                    CLR = 0
                End If
            End If
        Next

        If CLR = 1 Then
            STE = STE.Trim().Substring(0, STE.Length - 1)
            '--Convert to State_ID
            SQL1 = "select * from LobbyLog4_States_tbl where StateName in (" & STE & ") order by State_ID"
            'Response.Write(SQL) : Response.End()
            DT1 = LocalClass.ExecuteSQLDataSet(SQL1)

            '--
            For Z = 0 To DT1.Rows.Count - 1
                ABV = Trim(ABV) & DT1.Rows(Z)("Abbreviation").ToString & ","
            Next

            Session("StateSelected") = "'" & ABV.Trim().Substring(0, ABV.Length - 1) & "'"
            Session("StateName") = "" & Replace(Replace(STE.Trim().Substring(0, STE.Length - 1), "'", ""), ",", ", ") & ""

            'Response.Write(STE & "<br>" & ABV) ': Response.End()
            'Response.Write(ABV) ': Response.End()
        Else
            Session("StateName") = ""
            Session("StateSelected") = ""
            LBoxStateList.ClearSelection()

        End If


    End Sub

    Protected Sub BtnSaveData_Click(sender As Object, e As EventArgs) Handles BtnSaveData.Click

        '--User Type 
        If CB1.Checked = True Then A = 1 '--Lobbyist
        If CB2.Checked = True Then A = 0 '--Admin 
        If CB2.Checked = True And CB1.Checked = True Then A = 2 '--Admin & Lobbyist
        '--Send Email Reminder
        If CB3.Checked = True Then B = 1 Else B = 0
        '--Federal Register
        If CB4.Checked = True Then C = 1 Else C = 0
        '--State Register
        If CB5.Checked = True Then D = 1 Else D = 0

        Response.Write("Admin " & LblLogin_Name.Text & " " & LblLogin_EMPLID.Text & " " & LblLogin_NETID.Text & "<br />Lobbist " _
                          & LblLobbyist_NAME.Text & " " & LblLobbyist_EMPLID.Text & " " & LblLobbyist_NETID.Text)
        Response.Write("<br />Lobbyist " & A & "<br />Email " & B & "<br/>States " & Session("StateSelected"))
        Response.Write("<br />Federal " & C & "<br />State " & D)

    End Sub

End Class