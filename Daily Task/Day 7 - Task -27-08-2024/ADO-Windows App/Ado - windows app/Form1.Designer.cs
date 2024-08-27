namespace Ado___windows_app
{
    partial class dep
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.empid = new System.Windows.Forms.TextBox();
            this.empname = new System.Windows.Forms.TextBox();
            this.dep_text = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Display = new System.Windows.Forms.Button();
            this.button_Upd = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Button();
            this.lbl_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(416, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(334, 180);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "EmployeeID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Department";
            // 
            // empid
            // 
            this.empid.Location = new System.Drawing.Point(207, 80);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(100, 20);
            this.empid.TabIndex = 4;
            this.empid.TextChanged += new System.EventHandler(this.empid_TextChanged);
            // 
            // empname
            // 
            this.empname.Location = new System.Drawing.Point(207, 134);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(100, 20);
            this.empname.TabIndex = 5;
            // 
            // dep_text
            // 
            this.dep_text.Location = new System.Drawing.Point(207, 184);
            this.dep_text.Name = "dep_text";
            this.dep_text.Size = new System.Drawing.Size(100, 20);
            this.dep_text.TabIndex = 6;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Add.Location = new System.Drawing.Point(74, 310);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add ";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Update.Location = new System.Drawing.Point(160, 243);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Search";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(303, 310);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Display
            // 
            this.btn_Display.BackColor = System.Drawing.Color.Yellow;
            this.btn_Display.Location = new System.Drawing.Point(404, 310);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(75, 23);
            this.btn_Display.TabIndex = 10;
            this.btn_Display.Text = "Display";
            this.btn_Display.UseVisualStyleBackColor = false;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // button_Upd
            // 
            this.button_Upd.BackColor = System.Drawing.Color.Coral;
            this.button_Upd.Location = new System.Drawing.Point(192, 310);
            this.button_Upd.Name = "button_Upd";
            this.button_Upd.Size = new System.Drawing.Size(75, 23);
            this.button_Upd.TabIndex = 11;
            this.button_Upd.Text = "Update";
            this.button_Upd.UseVisualStyleBackColor = false;
            this.button_Upd.Click += new System.EventHandler(this.button_Upd_Click);
            // 
            // Count
            // 
            this.Count.BackColor = System.Drawing.Color.Khaki;
            this.Count.Location = new System.Drawing.Point(558, 349);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(75, 23);
            this.Count.TabIndex = 12;
            this.Count.Text = "Count";
            this.Count.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Count.UseVisualStyleBackColor = false;
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // lbl_count
            // 
            this.lbl_count.AllowDrop = true;
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(660, 355);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(0, 13);
            this.lbl_count.TabIndex = 13;
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 503);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.button_Upd);
            this.Controls.Add(this.btn_Display);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dep_text);
            this.Controls.Add(this.empname);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "dep";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empid;
        private System.Windows.Forms.TextBox empname;
        private System.Windows.Forms.TextBox dep_text;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Display;
        private System.Windows.Forms.Button button_Upd;
        private System.Windows.Forms.Button Count;
        private System.Windows.Forms.Label lbl_count;
    }
}

