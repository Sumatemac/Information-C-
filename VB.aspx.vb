Imports System.IO
Imports System.Data
Imports System.Net.Mail

Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Id"), New DataColumn("Name"), New DataColumn("Country")})
            dt.Rows.Add(1, "John Hammond", "United States")
            dt.Rows.Add(2, "Mudassar Khan", "India")
            dt.Rows.Add(3, "Suzanne Mathews", "France")
            dt.Rows.Add(4, "Robert Schidner", "Russia")
            GridView1.DataSource = dt
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub SendEmail(sender As Object, e As EventArgs)
        Using sw As New StringWriter()
            Using hw As New HtmlTextWriter(sw)
                GridView1.RenderControl(hw)
                Dim sr As New StringReader(sw.ToString())
                Dim mm As New MailMessage("sender@gmail.com", "receiver@gmail.com")
                mm.Subject = "GridView Email"
                mm.Body = "GridView:<hr />" + sw.ToString()
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim NetworkCred As New System.Net.NetworkCredential()
                NetworkCred.UserName = "sender@gmail.com"
                NetworkCred.Password = "<password>"
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = 587
                smtp.Send(mm)
            End Using
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 
    End Sub
End Class

