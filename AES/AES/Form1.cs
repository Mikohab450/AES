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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void EncryptButton(object sender, EventArgs e) { }

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
                    //var fileStream = openFileDialog1.OpenFile();
                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                    buffer = File.ReadAllBytes(filePath);
                }
                catch (IOException)
                { }
                //MessageBox.Show(fileContent,filePath,MessageBoxButtons.OK);
                //sampleText = fileContent;
                // buffer = Encoding.UTF8.GetBytes(sampleText);
                sampleText = Encoding.UTF8.GetString(buffer);
              
            }
        }

        private void SaveFileButton(object sender, EventArgs e)
        {

            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = string.Empty;
                string fileContent = string.Empty;
                //string keyContent = string.Empty;

                try
                {
                    filePath = saveFileDialog1.FileName;
                 //   var fileStream = saveFileDialog1.OpenFile();
                    //    using (StreamWriter writer = new StreamWriter(fileStream))
                    //    {
                    //        fileContent = Encoding.UTF8.GetString(buffer);
                    //        writer.Write(fileContent);
                    //    }
                    //}
                    //  using (BinaryWriter writer = new BinaryWriter(fileStream))
                    //    {
                    //        writer.Write(buffer);
                    //        writer.Flush();
                    //        writer.Close();
                    //    }
                    File.WriteAllBytes(filePath, buffer);
            }

                catch (IOException) { }
       
            }
            try
            {
                File.WriteAllBytes("Key", Key);
               // using (BinaryWriter writer = new BinaryWriter(File.Open("Key", FileMode.Create)))
               // {

                 //   string keyContent = Encoding.UTF8.GetString(Key);
                  //  MessageBox.Show(keyContent);
                  //  writer.Write(keyContent);
                  //  writer.Write(Key);

              //  }
            }
            catch { }


        }
        




        private void DecryptButton(object sender, EventArgs e)
        {
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
                    //filePath = openFileDialog2.FileName;
                  //  var fileStream = openFileDialog2.OpenFile();
                  //  using (StreamReader reader = new StreamReader(fileStream))
                  //  {
                  //      fileContent = reader.ReadToEnd();
                        Key=File.ReadAllBytes("Key");
                 //   }
                }
                catch (IOException)
                { }
              //  Key = Encoding.UTF8.GetBytes(fileContent);
                MessageBox.Show(fileContent);


            }
        }
    }
}
