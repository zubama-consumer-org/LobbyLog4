Public Class RecordingTimeLobbyist
    Inherits System.Web.UI.Page
    Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, ReturnValue As String
    Dim LocalClass As New GetData
    Dim LogonClass As New LogonClass
    Dim DT, DT1, DT2, DT3, DT4, DT5 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserName.Text = "Welcome " & Session("First") '& " " & Session("Last")

        If IsPostBack Then
            'Response.Write("IsPostBack")
        Else
        End If

    End Sub

End Class