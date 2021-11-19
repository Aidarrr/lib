using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DBCW
{
    public partial class Form1 : Form
    {
        public Methods methods = new Methods();
        public Dictionary<ToolStripMenuItem, string> dictionary = new Dictionary<ToolStripMenuItem, string>();
        public string str;

        public Form1()
        {
            InitializeComponent();
            dictionary[ClientsToolStripMenuItem1] = "clients";
            dictionary[journalTherapyToolStripMenuItem1] = "journalTherapy";
            dictionary[journalPayToolStripMenuItem1] = "journalPay";
            dictionary[MedicamentsToolStripMenuItem1] = "Medicament";
            dictionary[EmployeesToolStripMenuItem] = "Employees";
            dictionary[PetsToolStripMenuItem] = "Pets";
            dictionary[DiseaseToolStripMenuItem] = "Disease";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuItems_Click(object sender, EventArgs e)
        {
            try
            {
                methods.Show(dataGridView1, dictionary[(ToolStripMenuItem)sender], checkBox1);
                str = dictionary[(ToolStripMenuItem)sender];
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            methods.Update(dataGridView1);
        }

        private void traineesToolStripMenuItem_Click(object sender, EventArgs e) //view1
        {
            methods.OpenView(dataGridView1, "view1");
        }

        private void OpenViewByTables_Click(object sender, EventArgs e) //view2
        {
            methods.OpenView(dataGridView1, "view2");
        }

        private void Find_Click(object sender, EventArgs e)
        {
            methods.Find(dataGridView1, str, textBox1.Text, checkBox1);
        }

        private void Report_Click(object sender, EventArgs e)
        {
            try
            {
                methods.ReportAboutPrice(dataGridView1, Convert.ToInt32(textBox2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите число.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportPets_Click(object sender, EventArgs e)
        {
            try
            {
                methods.ReportAboutPets(dataGridView1, textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите тип животного.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                methods.ReportEmployees(dataGridView1, Convert.ToInt32(textBox4.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите число.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
