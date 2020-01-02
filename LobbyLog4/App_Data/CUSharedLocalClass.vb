Imports System.Data
Imports System.Data.SqlClient


Public Class GetData

    Public sqlConn As String = ConfigurationManager.ConnectionStrings("GlobalSQLDataConnection").ConnectionString
    Public SQLCNN As String

    Sub SetSqlConn()
        'This sub decides on what connection string to use.  It can tell what server the program is running on and set the SQL
        Dim ServerName As String
        ServerName = HttpContext.Current.Server.MachineName
        'If (ServerName = "CU-YNK-CUNET") Or (ServerName = "CUNET") Then
        'SQLCNN = sqlConn_PROD
        SQLCNN = sqlConn
        'Else
        'SQLCNN = sqlConn_DEV
        'SQLCNN = GlobalSQLDataConnection
        'End If
    End Sub
    Sub CloseSQLServerConnection()
        'Dim ds As New DataSet()
        'Dim DT As DataTable = ds.Tables(0)
        'DT.Dispose()
        'DT.Clear()
    End Sub
    Function ExecuteSQLDataSet(ByVal SQLValue As String)
        Try
            SetSqlConn()
            ' create a DataSet and fill with rows using SQL statement
            'JAV removed on 11/30/2018 for using logic for DEV vs PROD
            Dim da As New SqlDataAdapter(SQLValue, sqlConn)
            ' specify that provider-specific types are required in DataSet
            da.ReturnProviderSpecificTypes = True
            Dim ds As New DataSet()
            da.Fill(ds, "id_tbl")
            Dim dt As DataTable = ds.Tables(0)
            'builder.Append(String.Format("'emplid' column DataType = '{0}'", dt.Columns("emplid").DataType.ToString()))
            ExecuteSQLDataSet = dt
            ds.Dispose()
            dt.Dispose()
            da.Dispose()
        Catch ex As Exception
            If Len(HttpContext.Current.Session("EMPLID")) < 4 Then
                HttpContext.Current.Response.Redirect("default.aspx", True)
            End If
        End Try

    End Function

End Class
