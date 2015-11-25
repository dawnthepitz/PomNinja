using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PomNinja
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = o.FileName;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                FileCrypter.Encrypt(txtFilePath.Text, txtRename.Text);
                MessageBox.Show(txtRename.Text);
                File.Move(txtFilePath.Text, Path.GetDirectoryName(txtFilePath.Text) + '\\' + txtRename.Text);
                MessageBox.Show("Encryption Complete");
            }
            catch
            {
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                FileCrypter.Decrypt(txtFilePath.Text, Path.GetFileName(txtFilePath.Text));
                MessageBox.Show(Path.GetFileName(txtFilePath.Text));
                File.Move(txtFilePath.Text, Path.GetDirectoryName(txtFilePath.Text) + '\\' + txtRename.Text);
                MessageBox.Show("Decryption Complete");
            }
            catch
            {
            }
        }
    }
}
