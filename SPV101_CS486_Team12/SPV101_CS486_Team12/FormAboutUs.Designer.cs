namespace Team12
{
    partial class FormAboutUs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewIntroduction = new System.Windows.Forms.DataGridView();
            this.studentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskAssigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntroduction)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIntroduction
            // 
            this.dataGridViewIntroduction.AllowUserToAddRows = false;
            this.dataGridViewIntroduction.AllowUserToDeleteRows = false;
            this.dataGridViewIntroduction.AllowUserToResizeColumns = false;
            this.dataGridViewIntroduction.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridViewIntroduction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewIntroduction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIntroduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIntroduction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewIntroduction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIntroduction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewIntroduction.ColumnHeadersHeight = 60;
            this.dataGridViewIntroduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewIntroduction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentID,
            this.studentName,
            this.taskAssigned});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIntroduction.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewIntroduction.EnableHeadersVisualStyles = false;
            this.dataGridViewIntroduction.GridColor = System.Drawing.Color.Beige;
            this.dataGridViewIntroduction.Location = new System.Drawing.Point(40, 58);
            this.dataGridViewIntroduction.Name = "dataGridViewIntroduction";
            this.dataGridViewIntroduction.ReadOnly = true;
            this.dataGridViewIntroduction.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewIntroduction.RowHeadersVisible = false;
            this.dataGridViewIntroduction.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            this.dataGridViewIntroduction.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewIntroduction.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10);
            this.dataGridViewIntroduction.RowTemplate.Height = 40;
            this.dataGridViewIntroduction.RowTemplate.ReadOnly = true;
            this.dataGridViewIntroduction.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIntroduction.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewIntroduction.ShowCellErrors = false;
            this.dataGridViewIntroduction.ShowCellToolTips = false;
            this.dataGridViewIntroduction.ShowEditingIcon = false;
            this.dataGridViewIntroduction.ShowRowErrors = false;
            this.dataGridViewIntroduction.Size = new System.Drawing.Size(720, 361);
            this.dataGridViewIntroduction.TabIndex = 3;
            // 
            // studentID
            // 
            this.studentID.HeaderText = "Student ID";
            this.studentID.Name = "studentID";
            this.studentID.ReadOnly = true;
            this.studentID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // studentName
            // 
            this.studentName.HeaderText = "Student Name";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.studentName.Width = 200;
            // 
            // taskAssigned
            // 
            this.taskAssigned.HeaderText = "Task Assigned";
            this.taskAssigned.Name = "taskAssigned";
            this.taskAssigned.ReadOnly = true;
            this.taskAssigned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.taskAssigned.Width = 417;
            // 
            // FormAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(800, 668);
            this.Controls.Add(this.dataGridViewIntroduction);
            this.Name = "FormAboutUs";
            this.Text = "FormAboutUs";
            this.Load += new System.EventHandler(this.FormAboutUs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntroduction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewIntroduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskAssigned;
    }
}