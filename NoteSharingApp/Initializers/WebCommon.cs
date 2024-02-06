using NoteSharingApp.Common;
using NoteSharingApp.Helpers;

namespace NoteSharingApp.Initializers
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            if (SessionHelpers.User != null)
            {
                return SessionHelpers.User.Username;
            }
            return "System";
        }
    }
}