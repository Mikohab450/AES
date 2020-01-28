

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
using System.Diagnostics;

namespace AES
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\Mikolaj\Documents\JA\JA\AES\x64\Debug\AES_ASM.dll")]
        unsafe public static extern void AESEncryption(byte * buf,byte* key,byte* done,int n);
        [DllImport(@"C:\Users\Mikolaj\Documents\JA\JA\AES\x64\Debug\AES_ASM.dll")]
        unsafe public static extern void AESDecryption(byte* buf, byte* key, byte* done,int n);

        public Form1()
        {
            InitializeComponent();
            //aes = new MyAES(buffer);
           sw = new Stopwatch();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private  void EncryptButton(object sender, EventArgs e) {
                    
            if (key == null || key.GetLength(0) == 0)
                aes = new MyAES(buffer);
            else aes = new MyAES(buffer, key);
            if (C.Checked)
            {
            //    sw.Start();
                buffer = aes.Encrypt();
          //      sw.Stop();
                key = aes.getKey();
                
         //       MessageBox.Show(sw.ElapsedMilliseconds.ToString());
            }
            else if (A.Checked)
            {

                int size = buffer.Length;
            
                byte[,]roundKey = new byte[60,4];
                key = aes.getKey();
                roundKey = aes.getRoundKeys(1);
                byte[] dataOut;
                int blocks;
                if (size < 16)
                {
                    dataOut = new byte[16];
                    blocks = 1;
                }
                else
                {
                    blocks = size / 16;
                    dataOut = new byte[size];
                }

                unsafe
                {

                    fixed (byte* t = &buffer[0])
                    {
                        fixed (byte* k = &roundKey[0,0])
                        {
                            fixed (byte* resultRef = &dataOut[0])
                            {
                              //  sw.Reset()
                                //sw.Start();  //stoper do mierzenia czasu wykonania
                                AESEncryption(t, k, resultRef, blocks);
                            //    sw.Stop();
                           //     MessageBox.Show(sw.ElapsedMilliseconds.ToString());

                            }
                        }

                    }
               }
                Buffer = dataOut;       //zapis
                
            }
            MessageBox.Show("Encrypted!");
        }




        private void DecryptButton(object sender, EventArgs e)
        {
            if (key != null || key.GetLength(0) != 0)
                aes = new MyAES(buffer,key);
            
            if (C.Checked)
            {
                //   sw.Reset();           //stoper do mierzenia czasu wykonania
                //sw.Start();
                buffer = aes.Decrypt();
              //  sw.Stop();

            //    MessageBox.Show(sw.ElapsedMilliseconds.ToString());
            }
            else if (A.Checked)
            {

                int size = buffer.Length;
                byte[,] roundKey = new byte[60, 4];

                roundKey = aes.getRoundKeys(2);
                byte[] dataOut;
                int blocks;
                if (size < 16)
                {
                    dataOut = new byte[16];
                    blocks = 1;
                }
                else
                {
                    blocks = size / 16;
                    dataOut = new byte[size];
                }

                unsafe
                {
                    fixed (byte* t = &buffer[0])
                    {
                        fixed (byte* k = &roundKey[0, 0])
                        {
                            fixed (byte* resultRef = &dataOut[0])
                            {
                             //   sw.Reset();       //stoper do mierzenia czasu wykonania
                            //    sw.Start();
                                   AESDecryption(t, k, resultRef, blocks);
                          //      sw.Stop();
                          //      MessageBox.Show(sw.ElapsedMilliseconds.ToString());
                            }
                        }

                    }

                    Buffer = dataOut;       //zapis
                }
            }
            MessageBox.Show("Decrypted!");
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
                    if (buffer.GetLength(0) == 0) { MessageBox.Show("PLik jest pusty!"); }
                }
                catch (IOException)
                { }         
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
                    File.WriteAllBytes(filePath, aes.WriteBuffer());
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
            //MessageBox.Show("Loaded Key!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
