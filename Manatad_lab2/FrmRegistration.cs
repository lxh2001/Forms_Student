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
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontactnum_TextChanged(object sender, EventArgs e)
        {
            // Store the current cursor position
            int cursorPosition = txtcontactnum.SelectionStart;

            // Filter out non-digit characters
            string filteredText = string.Empty;
            foreach (char c in txtcontactnum.Text)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c;
                }
            }

            // Update the TextBox text and restore the cursor position
            txtcontactnum.Text = filteredText;
            txtcontactnum.SelectionStart = cursorPosition > filteredText.Length ? filteredText.Length : cursorPosition;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            // Create an instance of FrmStudentRecords
            FrmStudentRecord studentRecordsForm = new FrmStudentRecord();

            studentRecordsForm.Show();
            this.Hide();

        }
        private void Form1_load(object sender, EventArgs e)
        {
                cmbprogram.Items.AddRange(new string[] { "BS Information Technology", "BS Computer Science", "BS Accountancy", "BS Multimedia Arts", "BS Hotel Restaurant Management" });
                cmbgender.Items.AddRange(new string[] { "Male", "Female" });
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Get the user input values
            string studentNumber = txtstudentnum.Text;
            string lastName = txtlname.Text;
            string firstName = txtfname.Text;
            string middleInitial = txtminitial.Text;
            string programs = cmbprogram.Text.Trim();
            string gender = cmbgender.Text.Trim();
            string birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string contactNumber = txtcontactnum.Text;

            // Validate if any required fields are empty
            if (string.IsNullOrEmpty(studentNumber) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Please fill out all required fields (Student Number, Last Name, First Name).", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the file name using the last name
            string fileName = lastName + ".txt";

            
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("Student Number: " + studentNumber);
                    writer.WriteLine("Last Name: " + lastName);
                    writer.WriteLine("First Name: " + firstName);
                    writer.WriteLine("Middle Initial: " + middleInitial);
                    writer.WriteLine("Program: " + programs);
                    writer.WriteLine("Gender: " + gender);
                    writer.WriteLine("Birthday: " + birthday);
                    writer.WriteLine("Contact Number: " + contactNumber);
                }

                MessageBox.Show("Registration successful! Data saved to " + fileName, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data to file: " + ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtstudentnum_TextChanged(object sender, EventArgs e)
        {
            // Store the current cursor position
            int cursorPosition = txtstudentnum.SelectionStart;

            // Filter out non-digit characters
            string filteredText = string.Empty;
            foreach (char c in txtstudentnum.Text)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c;
                }
            }

            // Update the TextBox text and restore the cursor position
            txtstudentnum.Text = filteredText;
            txtstudentnum.SelectionStart = cursorPosition > filteredText.Length ? filteredText.Length : cursorPosition;
        }

        private void txtage_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtage.SelectionStart;

            // Filter out non-digit characters
            string filteredText = string.Empty;
            foreach (char c in txtage.Text)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c;
                }
            }

            // Update the TextBox text and restore the cursor position
            txtage.Text = filteredText;
            txtage.SelectionStart = cursorPosition > filteredText.Length ? filteredText.Length : cursorPosition;
        }
    }
}
