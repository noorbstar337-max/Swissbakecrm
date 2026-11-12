<%@ Application Language="VB" %>
<%@ Import Namespace="System.Timers" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.IO"%>

<script runat="server">

    'Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Code that runs on application startup
    '    'RegisterRoutes(RouteTable.Routes)
    '    BundleTable.EnableOptimizations = True
    '    BundleConfig.RegisterBundles(BundleTable.Bundles)
    '    'Session.Timeout = 120
      
       
    'End Sub
    
     Sub Application_Start(sender As Object, e As EventArgs)
	RegisterRoutes(RouteTable.Routes)
        'BundleTable.EnableOptimizations = True
        'BundleConfig.RegisterBundles(BundleTable.Bundles)
        'Dim myTimer As New System.Timers.Timer()
        '' Set the Interval to 20 Minute (1200000 milliseconds).
        ''myTimer.Interval = 300000
        'myTimer.Interval = 1200000
        'myTimer.AutoReset = True
        'AddHandler myTimer.Elapsed, AddressOf myTimer_Elapsed
        'myTimer.Enabled = True
        HttpRuntime.Cache.Insert("CheckForTasks", 60, Nothing, DateTime.Now.AddSeconds(1200), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, New CacheItemRemovedCallback(AddressOf CheckForTasks))
    End Sub

    Public Sub CheckForTasks(k As String, v As Object, r As CacheItemRemovedReason)
        ' do whatever you need to do
        'ActivityBLL.SendActivityTodayMail()
        SendScheduleMail()
        If Date.Now.ToString("HH:mm tt") >= "12:00 PM" And Date.Now.ToString("HH:mm tt") <= "12:19 PM" Then
            ActivityBLL.SendActivityTodayMail()
            'ElseIf Date.Now.ToString("HH:mm tt") >= "09:00 AM" And Date.Now.ToString("HH:mm tt") <= "09:19 AM" Then
            '    DailyDigestBLL.SendDailyDigest()
        End If
        HttpRuntime.Cache.Insert("CheckForTasks", 60, Nothing, DateTime.Now.AddSeconds(1200), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, _
            AddressOf CheckForTasks)
    End Sub
    
	 Private Sub RegisterRoutes(routes As RouteCollection)
        
		routes.MapPageRoute("Document", "PrintDoc/{type}", "~/Document.aspx")
        routes.Ignore("{file}.js")
        routes.Ignore("{file}.css")
        routes.Ignore("{file}.png")
        routes.Ignore("Styles/{*pathInfo}")
        routes.Ignore("Scripts/{*pathInfo}")
        routes.Ignore("Images/{*pathInfo}")
    End Sub
   
    'Public Sub myTimer_Elapsed(source As Object, e As System.Timers.ElapsedEventArgs)
    '    ''SendScheduleMail()
    '    'Dim StartTime As String = "11:30:00 AM"
    '    'Dim EndTime As String = "12:40:00 PM"
    '    ''Dim Temp As String = Application("MailSent")
    '    'If StartTime <= DateTime.Now.ToString("h:mm:ss tt") And EndTime >= DateTime.Now.ToString("h:mm:ss tt") Then
    '    '    ActivityBLL.SendActivityTodayMail()
    '    '    'Application.Add("MailSent", "True")
    '    'Else
    '    '    'Application("MailSent")="False"
    '    'End If
    '    ''ActivityBLL.SendActivityTodayMail
    'End Sub
    
    Public Sub SendScheduleMail()
        ActivityBLL.SendScheduleMail()
    End Sub
    
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
     Dim blogcookie As HttpCookie
     blogcookie = Request.Cookies.Get("blogcookievalue")
     If (blogcookie Is Nothing) Then
         blogcookie = New HttpCookie("blogcookievalue")
         blogcookie.Value = "None"
         Response.Cookies.Add(blogcookie)
        End If
        'Dim incoming As HttpContext = HttpContext.Current
        'Dim oldpath As String = incoming.Request.Path.ToLower()
        'incoming.Response.Filter = New System.IO.Compression.GZipStream(incoming.Response.Filter, System.IO.Compression.CompressionMode.Compress)
        'HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip")
        'HttpContext.Current.Response.Cache.VaryByHeaders("Accept-encoding") = True
    End Sub
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub
    
    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        UserBLL.Logout(Session("Audlog_Id"))
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
         Session.Timeout = 60
     End Sub
</script>