using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInvoiceGenerator
{
    public partial class InputForm : Form
    {
        private static Boolean prefClosing = false;
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            loadInfo();
            dataGridView1.Rows[0].Cells[2].Value = "0";
            dataGridView1.Rows[0].Cells[3].Value = "0";
            dataGridView1.Rows[0].Cells[4].Value = "0";
            dataGridView1.Rows[0].Cells[4].ReadOnly = true;
            inp_tax.Text = "0.0";

        }

        private void InputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.TaskManagerClosing:
                case CloseReason.UserClosing:
                case CloseReason.WindowsShutDown:
                    if(prefClosing == true)
                    {
                        new config().Show();
                        prefClosing = false;
                    }else
                    {
                        Application.Exit();
                    }
                    break;
                default:
                    break;
            }
        }

        private void InputFormMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender.ToString().Equals("Preferences"))
            {
                prefClosing = true;
                this.Close();
            }else if (sender.ToString().Equals("About Us"))
            {
                MessageBox.Show("Cancio, Kyle Cedrick R.\nCenteno, Elijah Gabriel A.\nSuarez, Jessie James P.\n\nF-ELEC1 PROJECT: SALES INVOICE GENERATOR");
            }
        }

        private void dataGridView1_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value = "0";
            ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value = "0";
            ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value = "0";
            ((DataGridView)sender).Rows[e.RowIndex].Cells[4].ReadOnly = true;

            double subTotal = 0.0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                subTotal += Double.Parse((string)row.Cells[4].Value);
            }

            inp_subTotal.Text = subTotal.ToString();
            computeSubTotal();
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgrid = ((DataGridView)sender);

            if (dgrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Equals(dgrid.Rows[e.RowIndex].Cells[2]))
            {
                double price = 0.0;
                if (Double.TryParse((string)(dgrid.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value, out price))
                {
                    dgrid.Rows[e.RowIndex].Cells[4].Value = Double.Parse((string)dgrid.Rows[e.RowIndex].Cells[2].Value) * Double.Parse((string)dgrid.Rows[e.RowIndex].Cells[3].Value);
                }
                else
                {
                    dgrid.Rows[e.RowIndex].Cells[2].Value = "0";
                    MessageBox.Show("Price must be a number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dgrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Equals(dgrid.Rows[e.RowIndex].Cells[3]))
            {
                if (dgrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Equals(dgrid.Rows[e.RowIndex].Cells[3]))
                {
                    int qty = 0;
                    if (Int32.TryParse((string)(dgrid.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value, out qty))
                    {
                        String total = (string)(Double.Parse((string)dgrid.Rows[e.RowIndex].Cells[2].Value) * Double.Parse((string)dgrid.Rows[e.RowIndex].Cells[3].Value)).ToString();
                        dgrid.Rows[e.RowIndex].Cells[4].Value = total.ToString();
                    }
                    else
                    {
                        dgrid.Rows[e.RowIndex].Cells[3].Value = "0";
                        MessageBox.Show("QTY must be a whole number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            computeSubTotal();
        }

        private void computeSubTotal()
        {
            double subTotal = 0.0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                subTotal += Double.Parse((row.Cells[4].Value).ToString());

            }

            inp_subTotal.Text = subTotal.ToString();
            Double subTtl = Double.Parse(inp_subTotal.Text);
            Double tax = Double.Parse(inp_tax.Text)/ 100;
            String output = (subTtl + (subTtl * tax)).ToString();
            inp_totalDue.Text = output;
        }

        private Boolean isFieldsEmpty()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (String.IsNullOrEmpty((string)(row.Cells[0].Value)))
                {
                    return true;
                }

            }

            return false;

        }

        private void inp_tax_TextChanged(object sender, EventArgs e)
        {
            double tax = 0.0;
            if (!Double.TryParse(inp_tax.Text, out tax))
            {
                MessageBox.Show("Invalid Tax Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inp_tax.Text = "0.0";
            }
            computeSubTotal();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {

            

            dataInfo.loadDataInfo();
            if (String.IsNullOrEmpty(inp_customerName.Text))
            {
                MessageBox.Show("Customer's Name cannot be empty", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                if (String.IsNullOrEmpty(inp_address1.Text))
                {
                    MessageBox.Show("Address 1 cannot be empty", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (String.IsNullOrEmpty(inp_cityStateZip.Text))
                    {
                        MessageBox.Show("City info cannot be empty", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CustomerInfo.CustomerName = inp_customerName.Text;
                        CustomerInfo.Address1 = inp_address1.Text;
                        CustomerInfo.Address2 = inp_address2.Text;
                        CustomerInfo.CityStateZip = inp_cityStateZip.Text;
                        CustomerInfo.SubTotal = inp_subTotal.Text;
                        CustomerInfo.Tax = inp_tax.Text;
                        CustomerInfo.TotalDue = inp_totalDue.Text;
                        CustomerInfo.Notes = inp_notes.Text;


                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {

                            if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                String data = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                                CustomerInfo.Item.Add(data);
                                data = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                                CustomerInfo.Desc.Add(data);
                                data = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                                CustomerInfo.Unit.Add(data);
                                data = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                                CustomerInfo.Qty.Add(data);
                                data = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                                CustomerInfo.Total.Add(data);
                            }
                            
                            
                            GC.Collect();
                        }
                        PDFGenerator.generatePDF();
                        dataInfo.Serial = dataInfo.Serial + 1;
                        dataInfo.saveDataInfo();
                        Console.WriteLine(dataInfo.Serial.ToString());

                        loadInfo();

                    }
                }
            }
                // if (isFieldsEmpty() == false)
                // {
           // }else
           // {
           //     MessageBox.Show("Item Names cannot be empty", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
        }

        private void loadInfo()
        {
            dateLabel.Text = System.DateTime.Today.ToString("MM/dd/yyyy");
            serialLabel.Text = "No. " + dataInfo.Serial.ToString();
            label_company.Text = dataInfo.CompanyName;
            label_address.Text = dataInfo.Address1;
            label_cityStateZip.Text = dataInfo.City + ", " + dataInfo.State + ", " + dataInfo.Zip;
            label_phone.Text = dataInfo.Phone;
        }
    }
}
