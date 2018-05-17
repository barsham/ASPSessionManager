using System.Collections.Specialized;

namespace LegacySessionManager
{
    [System.Runtime.InteropServices.ProgId(nameof(LegacySessionManager) + "." + nameof(Session))]
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.NotSupported)]
    /// <summary>
    /// Current Session
    /// </summary>
    public class Session : System.EnterpriseServices.ServicedComponent,ISession
    {

        private string _SessionId = string.Empty;
        private HybridDictionary _SessionDictionary = null;

        /// <summary>
        /// Current Session ID
        /// </summary>
        public string SessionId
        {
            get
            {
                if (string.IsNullOrEmpty(_SessionId))
                    _SessionId = SessionManager.GenerateNewSessionId();
                return _SessionId;
            }
            set
            {
                _SessionId = value;
            }
        }

        public string CookieName => SessionManager.SessionCookieName;

        /// <summary>
        /// Collection of Session Objects
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get
            {

                _SessionDictionary = SessionManager.LoadSession(
                    SessionId,
                    ApplicationConfiguration.SessionTimeout);

                return (object)_SessionDictionary[name.ToLower()];

            }
            set
            {
                if (_SessionDictionary == null)
                    _SessionDictionary = SessionManager.LoadSession(
                        SessionId,
                        ApplicationConfiguration.SessionTimeout);

                _SessionDictionary[name.ToLower()] = value;
                SessionManager.SaveSession(
                    SessionId, 
                    ApplicationConfiguration.SessionDatabase, 
                    _SessionDictionary);

            }
        }

        /// <summary>
        /// Abandon Session
        /// </summary>
        public void Abandon()
        {
            _SessionDictionary = new HybridDictionary();
            SessionManager.SaveSession(SessionId, ApplicationConfiguration.SessionDatabase, _SessionDictionary);
        }


    }
}
