using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInvoiceGenerator
{

    public partial class config : Form
    {
        public config()
        {
            InitializeComponent();
        }


        private void config_Load(object sender, EventArgs e)
        {
            inp_serial.Text = dataInfo.Serial.ToString();
            if(dataInfo.NewFile == 0)
            {
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                configWelcome.Text = "First time setup. Please enter valid company info";
            }else
            {
                this.ControlBox = true;
                configWelcome.Text = "Company Info Configuration";
                input_companyName.Text = dataInfo.CompanyName;
                input_address.Text = dataInfo.Address1;
                input_city.Text = dataInfo.City;
                input_state.Text = dataInfo.State;
                input_zip.Text = dataInfo.Zip;
                input_phone.Text = dataInfo.Phone;
                

            }
        }


        private void config_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dataInfo.NewFile == 0)
            {
                Application.Exit();
            }else
            {
                new InputForm().Show();
            }
        }

        private void config_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult saveOptions = MessageBox.Show("Save company info?", "Save Configurations", MessageBoxButtons.YesNo);
            if(saveOptions == DialogResult.Yes)
            {
                if(checkIfEmpty() == false)
                {
                    if(dataInfo.NewFile == 0)
                    {
                        MessageBox.Show("Configuration saved successfully. You may change your settings later at File > Preferences.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
                    {
                        MessageBox.Show("Configuration saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dataInfo.NewFile = 1;
                    dataInfo.CompanyName = input_companyName.Text;
                    dataInfo.Address1 = input_address.Text;
                    dataInfo.City = input_city.Text;
                    dataInfo.State = input_state.Text;
                    dataInfo.Zip = input_zip.Text;
                    dataInfo.Phone = input_phone.Text;
                    dataInfo.Serial = Int32.Parse(inp_serial.Text);
                    dataInfo.saveDataInfo();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Inputs must not be empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private Boolean checkIfEmpty()
        {
            String[] inputTexts = {input_companyName.Text, input_address.Text, input_city.Text, input_state.Text , input_zip.Text, input_phone.Text, inp_serial.Text };
            foreach(String inp in inputTexts)
            {
                if (String.IsNullOrEmpty(inp))
                {
                    return true;
                }
            }
            return false;
        }
        private void configWelcome_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void input_companyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void inp_serial_Leave(object sender, EventArgs e)
        {
            int x = 1;
            if (!Int32.TryParse(((TextBox)sender).Text, out x))
            {
                MessageBox.Show("Serial No. must be an integer", "Invalid Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = dataInfo.Serial.ToString();
            }

        }
    }
}
