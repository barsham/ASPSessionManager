using System;
using System.Xml;
using System.Collections.Specialized;
using System.Web;
using System.Configuration;
using System.Web.SessionState;

namespace LegacySessionManager
{
    /// <summary>
    /// Session Page for ASP.NET
    /// </summary>
	public class SessionPage : System.Web.UI.Page
    {

        private Session _session = null;

        /// <summary>
        /// Represent Shared Session Object
        /// </summary>
        public new Session Session {
            get
            {
                if (_session == null)
                    InitializeSessionManager();
                return _session; 
                
            }
        }

       
        private void InitializeSessionManager()
        {

            if (_session == null)
            {
                _session = new Session();
            }
            
            var cookie = HttpContext.Current.Request.Cookies[SessionManager.SessionCookieName];

            if (cookie == null)
            {
                cookie = new HttpCookie(SessionManager.SessionCookieName, SessionManager.GenerateNewSessionId());
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            _session.SessionId = cookie.Value;
           
        }
 

        /// <summary>
        /// Raises the System.Web.UI.Control.Init event to initialize the page.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            InitializeSessionManager();
            base.OnInit(e);
        }

        
    }

}
