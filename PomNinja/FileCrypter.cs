using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PomNinja
{
    class FileCrypter
    {
        public static void Encrypt(string fileToEncrypt, string password)
        {
            try
            {
                if (!File.Exists(fileToEncrypt))
                {
                    MessageBox.Show("File does not Exist");
                    return;
                }
                byte[] realValue = File.ReadAllBytes(fileToEncrypt);
                byte[] encryptedValue = CryptEngine.Encrypt(realValue, password);
                File.Create(fileToEncrypt).Close();
                File.WriteAllBytes(fileToEncrypt, encryptedValue);
            }
            catch
            {
            }
        }
        public static void Decrypt(string fileToAccess, string password)
        {
            try
            {
                if (!File.Exists(fileToAccess))
                {
                    MessageBox.Show("File does not Exist");
                    return;
                }
                byte[] realValue = File.ReadAllBytes(fileToAccess);
                byte[] decryptedValue = CryptEngine.Decrypt(realValue, password);
                File.Create(fileToAccess).Close();
                File.WriteAllBytes(fileToAccess, decryptedValue);
            }
            catch
            {
            }
        }
    }
}
