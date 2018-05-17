using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacySessionManager.UnitTest
{
    [TestClass]
    public class SessionTest
    {

        [TestMethod]
        public void VerifyCookieName()
        {
            var session =  new Session();
            Assert.AreEqual(session.CookieName, "LegacySessionManagerCookieName");
        }

        [TestMethod]
        public void VerifyNewSessionId()
        {
            var session = new Session();
            var sessionId = session.SessionId;
            Assert.IsNotNull(sessionId);
            Assert.AreNotEqual(sessionId, string.Empty);
        }


        [TestMethod]
        public void VerifySessionValue()
        {
            var session = new Session();
            const string firstKey = "FirstKey";
            const string firstValue = "John Smith";
            const string secondKey = "SecondKey";
            const string secondValue = "Sarah Tracer";

            session[firstKey] = firstValue; 
            session[secondKey] = secondValue;

            Assert.AreEqual(session[firstKey] , firstValue);
            Assert.AreEqual(session[secondKey] , secondValue);
        }

        [TestMethod]
        public void SessionAbondon()
        {

            var session = new Session();
            const string firstKey = "FirstKey";
            const string firstValue = "John Smith";
            const string secondKey = "SecondKey";
            const string secondValue = "Sarah Tracer";

            session[firstKey] = firstValue;
            session[secondKey] = secondValue;

            session.Abandon();

            Assert.AreEqual(session[firstKey],null);
            Assert.AreEqual(session[secondKey],null);

        }

        [TestMethod]
        public void VerifyCustomSessionId()
        {
            var sessionId = Guid.NewGuid().ToString();
            var session = new Session { SessionId = sessionId };

            const string firstKey = "FirstKey";
            const string firstValue = "John Smith";
            const string secondKey = "SecondKey";
            const string secondValue = "Sarah Tracer";

            session[firstKey] = firstValue;
            session[secondKey] = secondValue;

            Assert.AreEqual(session[firstKey], firstValue);
            Assert.AreEqual(session[secondKey], secondValue);
            Assert.AreEqual(session.SessionId ,sessionId);

        }
    }
}
