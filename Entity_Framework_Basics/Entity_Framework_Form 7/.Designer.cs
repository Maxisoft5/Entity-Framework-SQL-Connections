namespace Entity_Framework_Form_7
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eagerLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readRouteTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explicitLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lazyLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketrouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.k1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTicket2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(925, 379);
            this.dataGridView1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tickets",
            "Waybills",
            "Customers",
            "Airplanes"});
            this.comboBox1.Location = new System.Drawing.Point(831, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(734, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Read table";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Read_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.eagerLoadingToolStripMenuItem,
            this.explicitLoadingToolStripMenuItem,
            this.lazyLoadingToolStripMenuItem,
            this.k1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTicketToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addTicketToolStripMenuItem
            // 
            this.addTicketToolStripMenuItem.Name = "addTicketToolStripMenuItem";
            this.addTicketToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.addTicketToolStripMenuItem.Text = "Add ticket";
            this.addTicketToolStripMenuItem.Click += new System.EventHandler(this.addTicketToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTicketToolStripMenuItem,
            this.deleteTicket2ToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteTicketToolStripMenuItem
            // 
            this.deleteTicketToolStripMenuItem.Name = "deleteTicketToolStripMenuItem";
            this.deleteTicketToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.deleteTicketToolStripMenuItem.Text = "Delete ticket";
            this.deleteTicketToolStripMenuItem.Click += new System.EventHandler(this.deleteTicketToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateTicketToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // updateTicketToolStripMenuItem
            // 
            this.updateTicketToolStripMenuItem.Name = "updateTicketToolStripMenuItem";
            this.updateTicketToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.updateTicketToolStripMenuItem.Text = "Update ticket";
            this.updateTicketToolStripMenuItem.Click += new System.EventHandler(this.updateTicketToolStripMenuItem_Click);
            // 
            // eagerLoadingToolStripMenuItem
            // 
            this.eagerLoadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readRouteTicketToolStripMenuItem});
            this.eagerLoadingToolStripMenuItem.Name = "eagerLoadingToolStripMenuItem";
            this.eagerLoadingToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.eagerLoadingToolStripMenuItem.Text = "Eager Loading";
            // 
            // readRouteTicketToolStripMenuItem
            // 
            this.readRouteTicketToolStripMenuItem.Name = "readRouteTicketToolStripMenuItem";
            this.readRouteTicketToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.readRouteTicketToolStripMenuItem.Text = "Read Route+Ticket";
            this.readRouteTicketToolStripMenuItem.Click += new System.EventHandler(this.readRouteTicketToolStripMenuItem_Click);
            // 
            // explicitLoadingToolStripMenuItem
            // 
            this.explicitLoadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.routeTicketToolStripMenuItem});
            this.explicitLoadingToolStripMenuItem.Name = "explicitLoadingToolStripMenuItem";
            this.explicitLoadingToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.explicitLoadingToolStripMenuItem.Text = "Explicit Loading";
            // 
            // routeTicketToolStripMenuItem
            // 
            this.routeTicketToolStripMenuItem.Name = "routeTicketToolStripMenuItem";
            this.routeTicketToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.routeTicketToolStripMenuItem.Text = "Route + Ticket";
            this.routeTicketToolStripMenuItem.Click += new System.EventHandler(this.routeTicketToolStripMenuItem_Click);
            // 
            // lazyLoadingToolStripMenuItem
            // 
            this.lazyLoadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ticketrouteToolStripMenuItem});
            this.lazyLoadingToolStripMenuItem.Name = "lazyLoadingToolStripMenuItem";
            this.lazyLoadingToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.lazyLoadingToolStripMenuItem.Text = "Lazy Loading";
            // 
            // ticketrouteToolStripMenuItem
            // 
            this.ticketrouteToolStripMenuItem.Name = "ticketrouteToolStripMenuItem";
            this.ticketrouteToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.ticketrouteToolStripMenuItem.Text = "Ticket+route";
            this.ticketrouteToolStripMenuItem.Click += new System.EventHandler(this.ticketrouteToolStripMenuItem_Click);
            // 
            // k1ToolStripMenuItem
            // 
            this.k1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.k1ToolStripMenuItem.Name = "k1ToolStripMenuItem";
            this.k1ToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.k1ToolStripMenuItem.Text = "Connections";
            this.k1ToolStripMenuItem.Click += new System.EventHandler(this.k1ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem2.Text = "1 : 1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // deleteTicket2ToolStripMenuItem
            // 
            this.deleteTicket2ToolStripMenuItem.Name = "deleteTicket2ToolStripMenuItem";
            this.deleteTicket2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.deleteTicket2ToolStripMenuItem.Text = "Delete ticket2";
            this.deleteTicket2ToolStripMenuItem.Click += new System.EventHandler(this.deleteTicket2ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 478);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eagerLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readRouteTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explicitLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routeTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lazyLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketrouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem k1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteTicket2ToolStripMenuItem;
    }
}

