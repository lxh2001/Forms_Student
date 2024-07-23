using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manatad_lab2
{
    public partial class FrmStudentRecord : Form
    {
        public static ListView listRecords;
        public FrmStudentRecord()
        {
            InitializeComponent();
            listRecords = this.listRecord;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();

            frmRegistration.Show();
            this.Hide();
        }

        private void listRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            
            string[] directoryPath = Directory.GetFiles("C:\\Users\\laxh\\source\\repos\\Manatad_lab2\\Manatad_lab2\\bin\\Debugs");

            // Validate if directory path is empty
            if (directoryPath.Length == 0) // Check if the array is empty
            {
                MessageBox.Show("Please enter a directory path.", "Find Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Search for files in the directory
            string[] files = Directory.GetFiles(directoryPath[1]);

            // Check if any files were found
            if (files.Length == 0)
            {
                MessageBox.Show("No files found in the specified directory.", "Find Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update listRecord in FrmStudentRecord
                if (FrmStudentRecord.listRecords != null)
                {
                    FrmStudentRecord.listRecords.Items.Clear();
                    foreach (string file in files)
                    {
                        FrmStudentRecord.listRecords.Items.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    MessageBox.Show("List control (listRecord) not found in FrmStudentRecord.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
           
            // Simulate successful upload
            MessageBox.Show("Successfully Uploaded!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear listRecord in FrmStudentRecord
            if (FrmStudentRecord.listRecords != null)
            {
                FrmStudentRecord.listRecords.Items.Clear();
            }
        }


    }
}
