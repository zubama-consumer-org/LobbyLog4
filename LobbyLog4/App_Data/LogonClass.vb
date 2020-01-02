Imports System.Data.SqlClient

Public Class LogonClass

    'Public sqlConn As New SqlConnection(ConfigurationSettings.AppSettings("GlobalSQLDataConnection"))
    Sub SecuritySettngs()

        Dim FullPath As String = HttpContext.Current.Request.ApplicationPath

        HttpContext.Current.Response.AddHeader("Refresh", Convert.ToString((HttpContext.Current.Session.Timeout * 60) + 5))

        If HttpContext.Current.Session("NETID") = "" Then
            HttpContext.Current.Response.Cookies("NETID").Expires = DateTime.MinValue
            'where is the app root. Ask system where the app root really is
            HttpContext.Current.Response.Redirect(FullPath & "/default.aspx")
        End If
        'LogonClass.SetGlobals()
        'LogonClass.FindUserRights(LogonClass.EMPLID)
        HasAdminRights()

    End Sub

    Sub LogOut()
        HttpContext.Current.Session("NETID") = ""
        HttpContext.Current.Session("UserToken") = ""
        HttpContext.Current.Response.Cookies("NETID").Value = ""
        HttpContext.Current.Response.Cookies("NETID").Expires = DateTime.Now.AddDays(-1)
        'Response.Cookies("NETID").Value.Remove()
        'HttpContext.Current.Request.Cookies("NETID")
    End Sub

    Sub ForceLogin()
        HttpContext.Current.Session("UserToken") = "1"
        HttpContext.Current.Response.Cookies("AppNameText").Value = "CU LobbyLog"
        HttpContext.Current.Response.Cookies("CallingURL").Value = "/Advocate/1-WeekRange.aspx"
        HttpContext.Current.Response.Redirect("\Authenticator\Authenticator.aspx")
    End Sub

    Sub ForceLoginAdmin()
        HttpContext.Current.Session("UserToken") = "1"
        HttpContext.Current.Response.Cookies("AppNameText").Value = "CU LobbyLog"
        HttpContext.Current.Response.Cookies("CallingURL").Value = "Admin/AdminMain.aspx"
        HttpContext.Current.Response.Redirect("\Authenticator\Authenticator.aspx")
    End Sub

    Function GetUserRights(ByVal EMPLID) As String
        Dim LocalClass As New GetData
        Dim DS As SqlDataReader
        'Dim DT As DataTable
        Dim SQL As String

        SQL = "Select * from ID_TBL where emplid=" & EMPLID
        DS = LocalClass.ExecuteSQLDataSet(SQL)
        DS.Read()
        GetUserRights = DS("rights")
        LocalClass.CloseSQLServerConnection()

    End Function

    Sub Login()

        Dim LocalClass As New GetData
        'Dim Tmp As String
        Dim Flagit As Boolean = True

        If HttpContext.Current.Request.Cookies("NETID").Value = Nothing Then Flagit = False

        If Flagit = False Then
            HttpContext.Current.Session("UserToken") = "1"
            HttpContext.Current.Response.Cookies("AppNameText").Value = "CU LobbyLog"
            HttpContext.Current.Response.Cookies("CallingURL").Value = "/Advocate/1-WeekRange.aspx"
            HttpContext.Current.Response.Redirect("\Authenticator\Authenticator.aspx")
        Else
            HttpContext.Current.Session("UserToken") = "1"
            'LogonClass.EMPLID = HttpContext.Current.Request.Cookies("Emplid").Value

        End If

    End Sub





    Sub HasUserRightsx()
        Dim Flager As Boolean = False

        If HttpContext.Current.Session("UR") = "Both" Then Flager = True

        If HttpContext.Current.Session("UR") = "User1" Then Flager = True
        If HttpContext.Current.Session("UR") = "Admin" Then Flager = True

        If Flager = False Then
            Try
                HttpContext.Current.Response.Redirect("../NoRights.aspx?ID=0")
            Catch ex As Exception
                HttpContext.Current.Response.Redirect("NoRights.aspx?ID=0")
            End Try
        End If

    End Sub

    Sub AdvocateRightsDisplay()

        Dim RightsHolder As String = UCase(GetUserRights(HttpContext.Current.Session("EMPLID")))
        Dim Flager As Boolean = False


        If InStr(RightsHolder, "ADVCATEUSER") > 0 Then
            'HttpContext.Current.Session("UR") &= HttpContext.Current.Session("UR") + "User1"
            'Hyperlink5.Enabled = True ' Advocate
            Flager = True
        End If

        If Flager = False Then
            Try
                HttpContext.Current.Response.Redirect("../NoRights.aspx?ID=0")
            Catch ex As Exception
                HttpContext.Current.Response.Redirect("NoRights.aspx?ID=0")
            End Try
        End If

    End Sub

    Function HasAdminRights()

        Dim Flagger As Boolean = False

        If HttpContext.Current.Session("UR") = "Both" Then
            Flagger = True
        End If

        If HttpContext.Current.Session("UR") = "User" Then
            Flagger = True
        End If

        HasAdminRights = Flagger

    End Function
    Public ReadOnly Property NETID() As String
        Get
            Return HttpContext.Current.Session("NETID")
        End Get
    End Property
    'Public ReadOnly Property EMPLID() As String
    'Get
    'Try
    'Return HttpContext.Current.Session("EMPLID")
    'Catch ex As Exception
    'If HttpContext.Current.Request.Url.PathAndQuery.ToString = "/Admin/AdminMain.aspx" Then
    'ForceLoginAdmin()
    'Else
    'ForceLogin()
    'End If
    'End Try
    'End Get
    'End Property
    Public ReadOnly Property NameFL() As String
        Get
            Return HttpContext.Current.Session("NAMEFL")
        End Get
    End Property
    Public ReadOnly Property NameLF() As String
        Get
            Return HttpContext.Current.Request.Cookies("NameLF").Value
        End Get
    End Property
    Public ReadOnly Property First() As String
        Get
            Return HttpContext.Current.Request.Cookies("First").Value
        End Get
    End Property
    Public ReadOnly Property Last() As String
        Get
            Return HttpContext.Current.Request.Cookies("Last").Value
        End Get
    End Property
    Public ReadOnly Property DeptName() As String
        Get
            Return HttpContext.Current.Request.Cookies("DeptName").Value
        End Get
    End Property
    Public ReadOnly Property DeptID() As String
        Get
            Return HttpContext.Current.Request.Cookies("DeptID").Value
        End Get
    End Property
    Public ReadOnly Property JOB() As String
        Get
            Return HttpContext.Current.Request.Cookies("JOB").Value
        End Get
    End Property
    Public ReadOnly Property STD_HOURS() As String
        Get
            Return HttpContext.Current.Request.Cookies("STD_HOURS").Value
        End Get
    End Property
    Public ReadOnly Property SAP() As String
        Get
            Return HttpContext.Current.Request.Cookies("SAP").Value
        End Get
    End Property
    Public ReadOnly Property Supervisor_Name() As String
        Get
            Return HttpContext.Current.Request.Cookies("Supervisor").Value
        End Get
    End Property
    Public ReadOnly Property EMPL_ON_CLOCK() As String
        Get
            Return HttpContext.Current.Request.Cookies("EMPL_ON_CLOCK").Value
        End Get
    End Property
    Public ReadOnly Property UserRights() As String
        ' Dim LocalClass As New CUSharedLocalClass
        Get
            Return HttpContext.Current.Session("UR")
        End Get
    End Property
End Class


