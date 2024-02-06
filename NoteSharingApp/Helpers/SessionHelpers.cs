using NoteSharingApp.Entities;
using System.Web;

namespace NoteSharingApp.Helpers
{
    public class SessionHelpers
    {

        public static EvernoteUser User
        {
            get
            {
                return Get<EvernoteUser>("Login");
            }
        }

        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session["Login"] == null)
            {
                return default(T);
            };
            return (T)HttpContext.Current.Session["Login"];
        }

        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        public static void RemoveKey(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}