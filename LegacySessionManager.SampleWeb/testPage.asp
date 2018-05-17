<!-- #include file=globalinclude.asp -->
<%
    
    Session("lName") = "Yuen"

    IF (len(Session("Count")) = 0) THEN 
        Session("Count") = "1"
    ELSE
        Session("Count") = Session("Count") + 1
    END IF
    
    Response.Write "Count:" & Session("Count")
    Response.Write "<BR>"
    Response.Write Session("fName") & " " & Session("lName")
    Response.Write "<BR>"
    Response.Write Session.SessionID
    Response.Write "<BR>"
   
%>