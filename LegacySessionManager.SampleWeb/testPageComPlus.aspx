<%@ Page Language="C#" Debug="true" Inherits="System.Web.UI.Page" %>

<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        var comType = Type.GetTypeFromProgID("SharedSessionManager.Session");
        dynamic Session = Activator.CreateInstance(comType);

        Session["fName"] = "Billy";

        int count;

        if (!int.TryParse(Session["Count"], out count))
            Session["Count"] = "0";

        Session["Count"] = (int.Parse(Session["Count"]) + 1).ToString();

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
