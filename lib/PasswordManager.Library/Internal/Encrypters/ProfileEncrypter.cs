using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PasswordManager.Tests")]

namespace PasswordManager.Library.Internal.Encryption
{
    internal static class ProfileEncrypter
    {
        public static string EncryptPassword(string profilePassword, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Cannot encrypt password without proper userId.");
            }

            var purposeA = "Password Protection";
            var purposeB = $"User: {userId}";

            byte[] unprotectedBytes = Encoding.UTF8.GetBytes(profilePassword);
            byte[] protectedBytes = MachineKey.Protect(unprotectedBytes, purposeA, purposeB);
            string protectedText = Convert.ToBase64String(protectedBytes);

            return protectedText;
        }

        public static string DecryptPassword(string encryptedPassword, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Cannot decrypt password without proper userId.");
            }

            var purposeA = "Password Protection";
            var purposeB = $"User: {userId}";

            byte[] protectedBytes = Convert.FromBase64String(encryptedPassword);
            byte[] unprotectedBytes = MachineKey.Unprotect(protectedBytes, purposeA, purposeB);
            string unprotectedText = Encoding.UTF8.GetString(unprotectedBytes);

            return unprotectedText;
        }
    }
}
