<%
    
    DIM Session ,cookieName
    SET Session = server.CreateObject("LegacySessionManager.Session")
     cookieName = Session.CookieName

    '   Register Cookie with Session Id
    IF (ISNULL(Request.Cookies(cookieName)) OR Request.Cookies(cookieName) = "")  THEN        
        Response.Cookies(cookieName) = Session.SessionID
    ELSE
        Session.SessionID  = Request.Cookies(cookieName)
    END IF

%>