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
            int id = 354;

            string encryptedPassword = ProfileEncrypter.EncryptPassword(password, id);
            string decryptedPassword = ProfileEncrypter.DecryptPassword(encryptedPassword, id);

            Assert.Equal(password, decryptedPassword);
        }
    }
}
