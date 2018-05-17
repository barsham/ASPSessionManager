using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Linq;
using System.Data.Entity;

namespace LegacySessionManager
{
    internal static class SessionManager
    {
        public const string SessionCookieName = "LegacySessionManagerCookieName";

        /// <summary>
        /// Load Session from Database
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionExpiration"></param>
        /// <returns></returns>
        public static HybridDictionary LoadSession(string sessionId, int sessionExpiration)
        {

            using (var context = new SessionContext())
            {

                var sessionDictionary = new HybridDictionary();

                var session = context.SessionStates.Where(s => s.SessionId == sessionId)
                        .Where(s => DateTime.Now <= DbFunctions.AddMinutes(s.LastAccessed, sessionExpiration))
                        .FirstOrDefault();

                if (session != null)
                {
                    sessionDictionary = Deserialize(session.SessionDictionary);
                }

                return sessionDictionary;
            }

        }

        /// <summary>
        /// Saves the Session into the database
        /// </summary>
        /// <param name="key"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionDictionary"></param>
        public static void SaveSession(string key, string connectionString, HybridDictionary sessionDictionary)
        {

            using (var context = new SessionContext())
            {

                var session = context.SessionStates.FirstOrDefault(s => s.SessionId == key);

                if (session == null)
                {
                    session = new SessionState()
                    {
                        SessionId = key,
                        SessionDictionary = Serialize(sessionDictionary),
                        LastAccessed = DateTime.Now
                    };

                    context.SessionStates.Add(session);

                }
                else
                {
                    session.SessionDictionary = Serialize(sessionDictionary);
                    session.LastAccessed = DateTime.Now;
                    context.Entry(session).Property(x => x.SessionDictionary).IsModified = true;
                    context.Entry(session).Property(x => x.LastAccessed).IsModified = true;
                }

                context.SaveChanges();
            }

        }

        /// <summary>
        /// Generate New Session ID
        /// </summary>
        /// <returns></returns>
        public static string GenerateNewSessionId()
        {
            return Guid.NewGuid().ToString();
        }

        private static byte[] Serialize(HybridDictionary dictionary)
        {

            Stream stream = null;
            byte[] state = null;

            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new MemoryStream();
                formatter.Serialize(stream, dictionary);
                state = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(state, 0, (int) stream.Length);
                stream.Close();
            }
            finally
            {
                stream?.Close();
            }

            return state;
        }

        private static HybridDictionary Deserialize(byte[] binaryDictionary)
        {

            HybridDictionary dictionary = null;
            Stream stream = null;

            try
            {
                stream = new MemoryStream();
                stream.Write(binaryDictionary, 0, binaryDictionary.Length);
                stream.Position = 0;
                IFormatter formatter = new BinaryFormatter();
                dictionary = (HybridDictionary) formatter.Deserialize(stream);
            }
            finally
            {
                stream?.Close();
            }

            return dictionary;
        }

    }
}
