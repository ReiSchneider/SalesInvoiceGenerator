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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
            dataInfo.loadDataInfo();
        }

        private void splash_loader_Tick(object sender, EventArgs e)
        {
            splashLoader.Dispose();
            if(dataInfo.NewFile == 0)
            {
                new config().Show();
            }else
            {
                new InputForm().Show();
            }
            GC.Collect();
            this.Close();
            
        }

        private void splash_Load(object sender, EventArgs e)
        {
            dataInfo.loadDataInfo();
            CustomerInfo.initLists();
            splashLoader.Enabled = true;
        }
    }
}
