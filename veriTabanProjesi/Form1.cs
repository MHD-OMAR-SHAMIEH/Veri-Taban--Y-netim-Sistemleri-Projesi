using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriTabanProjesi
{
    public partial class Form1 : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres",
            "Udgjd hgpfdfm057", "NewDB");
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private int rowIndex = -1;


        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void employeePage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            Select();
        }
        private void Select()
        {
            try
            {
                conn.Open();

                sql = @"select * from vacationselect()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                vacationData.DataSource = null;
                vacationData.DataSource = dt;
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("error: " + ex.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void vacationData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                rowIndex = e.RowIndex;
                vacationName.Text = vacationData.Rows[e.RowIndex].Cells["_name"].Value.ToString();
                vacationType.Text = vacationData.Rows[e.RowIndex].Cells["_type"].Value.ToString();
                vacationTimeOfVacation.Text = vacationData.Rows[e.RowIndex].Cells["_timeOfVacation"].Value.ToString();
            }
        }

        private void btnVacationAdd_Click(object sender, EventArgs e)
        {
            rowIndex = -1;
            vacationName.Enabled = vacationType.Enabled = vacationTimeOfVacation.Enabled = true;
            vacationName.Text = vacationType.Text = vacationTimeOfVacation.Text = null;
            vacationName.Select();
        }

        private void btnVacationEdit_Click(object sender, EventArgs e)
        {
            if(rowIndex<0)
            {
                MessageBox.Show("please choose vacation to update");
                return;
            }
            vacationName.Enabled = vacationType.Enabled = vacationTimeOfVacation.Enabled = true;
        }

        private void btnVacationDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("please choose vacation to delete");
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from vacationdelete(:_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id",int.Parse(vacationData.Rows[rowIndex].Cells["_id"].Value.ToString()));
                if((int)cmd.ExecuteScalar()==1)
                {
                    MessageBox.Show("deleted vacation successfully");
                    rowIndex = -1;
                    conn.Close();
                    Select();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("deleted fail, error: "+ex.Message);
            }
        }

        private void btnVacationSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            if(rowIndex<0)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from vacationadd(:_name,:_type,:_timeOfVacation)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_name",vacationName.Text);
                    cmd.Parameters.AddWithValue("_type", vacationType.Text);
                    cmd.Parameters.AddWithValue("_timeOfVacation", vacationTimeOfVacation.Text);
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();
                    if(result==1)
                    {
                        MessageBox.Show("added new vacation successfully");
                        Select();
                    }
                    else
                    {
                        MessageBox.Show("added fail");
                    }
                    
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("add fail, error:" + ex.Message);
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from vacationedit(:_id,:_name,:_type,:_timeOfVacation)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", int.Parse(vacationData.Rows[rowIndex].Cells["_id"].Value.ToString()));
                    cmd.Parameters.AddWithValue("_name", vacationName.Text);
                    cmd.Parameters.AddWithValue("_type", vacationType.Text);
                    cmd.Parameters.AddWithValue("_timeOfVacation", vacationTimeOfVacation.Text);
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();
                    if(result==1)
                    {
                        MessageBox.Show("updated successfully");
                        Select();
                    }
                    else
                    {
                        MessageBox.Show("updated fail");
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("update fail, error:" + ex.Message);
                }
            }
            result = 0;
            vacationName.Text = vacationType.Text = vacationTimeOfVacation.Text = null;
            vacationName.Enabled = vacationType.Enabled = vacationTimeOfVacation.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void addressPage_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }
    }
}
