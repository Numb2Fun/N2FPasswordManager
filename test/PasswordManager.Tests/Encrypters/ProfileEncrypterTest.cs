using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using PasswordManager.Library.Internal.Encryption;

namespace PasswordManager.Tests.Encrypters
{
    public class ProfileEncrypterTest
    {
        [Fact]
        public void EncryptDecryptPassword_PasswordEqualsDecryptedOutput()
        {
            string password = "#Rjsl3kq&L";
            string id = "aeba7afb-a508-4f25-8414-b08255051fe4";

            string encryptedPassword = ProfileEncrypter.EncryptPassword(password, id);
            string decryptedPassword = ProfileEncrypter.DecryptPassword(encryptedPassword, id);

            Assert.Equal(password, decryptedPassword);
        }
    }
}
