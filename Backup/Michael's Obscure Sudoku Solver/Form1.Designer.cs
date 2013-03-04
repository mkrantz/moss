namespace MOSS
{
    partial class frmSudoku
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
            if(disposing && (components != null))
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
            this.sudokuGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lbCandidates = new System.Windows.Forms.ListBox();
            this.lblCandidates = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // sudokuGrid
            // 
            this.sudokuGrid.AllowUserToAddRows = false;
            this.sudokuGrid.AllowUserToDeleteRows = false;
            this.sudokuGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sudokuGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.sudokuGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sudokuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sudokuGrid.ColumnHeadersVisible = false;
            this.sudokuGrid.GridColor = System.Drawing.Color.Black;
            this.sudokuGrid.Location = new System.Drawing.Point(132, 87);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.ReadOnly = true;
            this.sudokuGrid.RowHeadersVisible = false;
            this.sudokuGrid.RowHeadersWidth = 18;
            this.sudokuGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sudokuGrid.Size = new System.Drawing.Size(190, 183);
            this.sudokuGrid.TabIndex = 0;
            this.sudokuGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.sudokuGrid_CellMouseLeave);
            this.sudokuGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sudokuGrid_CellMouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sudoku Solver";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(190, 297);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Solve Me!";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResults.Location = new System.Drawing.Point(12, 338);
            this.lblResults.MinimumSize = new System.Drawing.Size(10, 10);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(10, 13);
            this.lblResults.TabIndex = 3;
            // 
            // lbCandidates
            // 
            this.lbCandidates.Enabled = false;
            this.lbCandidates.FormattingEnabled = true;
            this.lbCandidates.Location = new System.Drawing.Point(363, 109);
            this.lbCandidates.Name = "lbCandidates";
            this.lbCandidates.Size = new System.Drawing.Size(25, 134);
            this.lbCandidates.TabIndex = 4;
            // 
            // lblCandidates
            // 
            this.lblCandidates.AutoSize = true;
            this.lblCandidates.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCandidates.Location = new System.Drawing.Point(359, 94);
            this.lblCandidates.Name = "lblCandidates";
            this.lblCandidates.Size = new System.Drawing.Size(60, 13);
            this.lblCandidates.TabIndex = 5;
            this.lblCandidates.Text = "Candidates";
            // 
            // frmSudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 369);
            this.Controls.Add(this.lblCandidates);
            this.Controls.Add(this.lbCandidates);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sudokuGrid);
            this.Name = "frmSudoku";
            this.Text = "Michael\'s Obscure Sudoku Solver";
            this.Load += new System.EventHandler(this.frmSudoku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView sudokuGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListBox lbCandidates;
        private System.Windows.Forms.Label lblCandidates;

    }
}

