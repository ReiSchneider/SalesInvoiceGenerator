namespace SalesInvoiceGenerator
{
    partial class splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splashLoader = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // splashLoader
            // 
            this.splashLoader.Interval = 1000;
            this.splashLoader.Tick += new System.EventHandler(this.splash_loader_Tick);
            // 
            // splash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::SalesInvoiceGenerator.Properties.Resources.Splash;
            this.ClientSize = new System.Drawing.Size(620, 317);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice Generator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer splashLoader;
    }
}