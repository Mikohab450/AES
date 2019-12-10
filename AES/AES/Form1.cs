using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadFileButton(object sender, EventArgs e)
        {

            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = string.Empty;
                string fileContent = string.Empty;

                try
                {
                    filePath = openFileDialog1.FileName;
                    var fileStream = openFileDialog1.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                catch (IOException)
                { }
                //MessageBox.Show(fileContent,filePath,MessageBoxButtons.OK);
                sampleText = fileContent;
              
            }
        }

        private void SaveFileButton(object sender, EventArgs e)
        {

            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = string.Empty;
                string fileContent = string.Empty;

                try
                {
                    filePath = saveFileDialog1.FileName;
                    var fileStream = saveFileDialog1.OpenFile();

                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(buffer);
                        writer.Flush();
                        writer.Close();
                    }
                }
                catch (IOException) { }
       
            }
            try
            {
                using (Stream file = File.OpenWrite("here.txt"))
                {
                    file.Write(fileBytes, 0, fileBytes.Length);
                }
            }
            catch (IOException)
            { }
        }
  
        
     

        private void DecryptButton(object sender, EventArgs e)
        {
           // Aes myAes = Aes.Create();
            //myAes.GenerateKey();
            //myAes.GenerateIV();
            // Check arguments.
            if (sampleText == null || sampleText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.Zeros;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            sampleText = plaintext;
       //     MessageBox.Show(sampleText);
            buffer = Encoding.ASCII.GetBytes(plaintext);
        }

        private void EncryptButton(object sender, EventArgs e)
        {
            Aes myAes = Aes.Create();
            myAes.GenerateKey();
            myAes.GenerateIV();
           // Key = myAes.Key;
            IV = myAes.IV;
            Key = myAes.Key;
            // Check arguments.
            if (sampleText == null || sampleText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (myAes.Key == null || myAes.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (myAes.IV == null || myAes.IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = myAes.Key;
                aesAlg.IV = myAes.IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(sampleText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            //            return encrypted;
            buffer = encrypted;
            sampleText = Encoding.ASCII.GetString(encrypted);
            MessageBox.Show(sampleText);
        }

        private void LoadKeyButton(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog2.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = string.Empty;
                string fileContent = string.Empty;

                try
                {
                    filePath = openFileDialog2.FileName;
                    var fileStream = openFileDialog2.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                catch (IOException)
                { }
                Key = Encoding.ASCII.GetBytes(fileContent);
                MessageBox.Show("I'm loading the key.......");

            }
        }
    }
}
