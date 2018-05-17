<%@ Page Language="C#" Debug="true" Inherits="LegacySessionManager.SessionPage" %>

<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        Session["fName"] = "Billy";

        int count;

        if (Session["Count"] == null)
            Session["Count"] = "0";

        if (!int.TryParse(Session["Count"].ToString(), out count))
            count = 0;

        Session["Count"] = (count + 1).ToString();

        Response.Write("Count:" + Session["Count"]);
        Response.Write("<BR>");
        Response.Write(Session["fName"] + " " + Session["lName"]);
        Response.Write("<BR>");
        Response.Write(Session.SessionId);
        Response.Write("<BR>");
    }
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>WebForm1</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body>
    <form id="Form1" method="post" runat="server">
    </form>
</body>
</html>
