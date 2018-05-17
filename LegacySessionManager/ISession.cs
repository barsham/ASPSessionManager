namespace LegacySessionManager
{
    /// <summary>
    /// Current Session Interface
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Current Session ID
        /// </summary>
        string SessionId { get; set; }

        string CookieName { get; }
    }
}