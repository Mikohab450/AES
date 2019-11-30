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

        private void button1_Click(object sender, EventArgs e)
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
                label1.Text = filePath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write("sra do gara");
                    }
                }
                catch (IOException) { }
            }
        }
  
        
     

        private void button2_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithm crypt= Aes.Create();
            crypt.GenerateKey();
            crypt.GenerateIV();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
