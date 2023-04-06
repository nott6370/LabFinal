using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using static final5.Most;

namespace final5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = checkBox18.Checked ? checkBox18.Text : checkBox19.Text;
            string category = GetSelectedCheckboxText(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9);
            string storage = GetSelectedCheckboxText(checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17);
            string price = "";

            if (checkBox18.Checked)
            {
                switch (storage)
                {
                    case "128GB":
                        price = "39900";
                        break;
                    case "256GB":
                        price = "43400";
                        break;
                    case "512GB":
                        price = "50900";
                        break;
                    case "1TB":
                        price = "58400";
                        break;
                }
            }
            else if (checkBox19.Checked)
            {
                switch (storage)
                {
                    case "128GB":
                        price = "42900";
                        break;
                    case "256GB":
                        price = "46900";
                        break;
                    case "512GB":
                        price = "56400";
                        break;
                    case "1TB":
                        price = "65400";
                        break;
                }
            }

            string description = textBox2.Text;

            //เรียกใช้ Product
            Product product = new Product { Name = name, Category = category, Storage = storage, Price = price, Description = description };

            //เพิ่มข้อมูลใน DataGrid
            dataGridView1.Rows.Add(name, price, category, storage, description);

            //ให้ TextBox ว่าง
            textBox2.Text = "";

            //เรียกใช้ Total
            int sum = Total.CalculateSum(dataGridView1, 4);
            label5.Text = sum.ToString();

            //เรียกใช้ Most
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[] { label10, label11, label12, label13 };
            Most.ShowMaxRowValues(dataGridView1, 4, label9, labels);


            ClearAllCheckBoxes();
        }

        private string GetSelectedCheckboxText(params CheckBox[] checkBoxes)
        {
            foreach (var checkBox in checkBoxes)
            {
                if (checkBox.Checked) return checkBox.Text;
            }
            return "";
        }

        private void ClearAllCheckBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string allDATARAW = readAllLine[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1]);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(.csv)|.csv";
                if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(sfd.FileName))
                {
                    try
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string columnNames = "";
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                        }
                        outputCSV[0] += columnNames;
                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                var cellValue = dataGridView1.Rows[i - 1].Cells[j].Value;
                                outputCSV[i] += cellValue != null ? cellValue.ToString() + "," : ",";
                            }
                        }
                        File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        MessageBox.Show("Saved");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
