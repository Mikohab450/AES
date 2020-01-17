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
using System.Runtime.InteropServices;

namespace AES
{
    public partial class Form1 : Form
    {
        [DllImport(@"../../../x64/Debug/AES_ASM.dll")]
        public static extern void AESEncryption(long[] word, long[] stringList, long amount);


        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private  void EncryptButton(object sender, EventArgs e) {
            if (C.Checked)
            {
                aes = new MyAES(buffer);
                buffer = aes.Encrypt();
                key = aes.getKey();
                MessageBox.Show("Encrypted!");
            }
            if (A.Checked)
            {
               long[] test={ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                unsafe
                {
                    fixed (long* t = &test[0])
                    {
                        AESEncryption(test, test, 10);
                    }
                }

                
            }
        }




        private void DecryptButton(object sender, EventArgs e)
        {
            if (C.Checked)
            {
                aes = new MyAES(buffer, key);
                buffer = aes.Decrypt();
                MessageBox.Show("Decrypted!");
            }
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
                    buffer = File.ReadAllBytes(filePath);
                }
                catch (IOException)
                { }         
            }
            MessageBox.Show("File loaded!");
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
                    File.WriteAllBytes(filePath, buffer);
                    File.WriteAllBytes("Key", key);
                }

                catch (IOException) { }
            }
            MessageBox.Show("File saved!");
        }


        private void LoadKeyButton(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog2.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = string.Empty;
                try
                {
                    filePath = openFileDialog2.FileName;
                    key =File.ReadAllBytes(filePath);
                }
                catch (IOException)
                { }
            }
            MessageBox.Show("Loaded Key!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
