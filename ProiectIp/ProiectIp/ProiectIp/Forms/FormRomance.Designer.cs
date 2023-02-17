
namespace ProiectIp.Forms
{
    partial class FormRomance
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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchLabel = new System.Windows.Forms.Label();
            this.movie_grid = new System.Windows.Forms.DataGridView();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.searchPanel.Controls.Add(this.searchLabel);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(800, 60);
            this.searchPanel.TabIndex = 2;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.searchLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(54)))), ((int)(((byte)(67)))));
            this.searchLabel.Location = new System.Drawing.Point(21, 23);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(131, 17);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "SEARCH MOVIE";
            // 
            // movie_grid
            // 
            this.movie_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.movie_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movie_grid.Dock = System.Windows.Forms.DockStyle.Left;
            this.movie_grid.Location = new System.Drawing.Point(0, 60);
            this.movie_grid.Name = "movie_grid";
            this.movie_grid.RowHeadersWidth = 70;
            this.movie_grid.RowTemplate.Height = 24;
            this.movie_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.movie_grid.Size = new System.Drawing.Size(536, 390);
            this.movie_grid.TabIndex = 3;
            this.movie_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Movie_grid_CellClick);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionBox.Location = new System.Drawing.Point(536, 60);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(264, 390);
            this.descriptionBox.TabIndex = 4;
            // 
            // FormRomance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.movie_grid);
            this.Controls.Add(this.searchPanel);
            this.Name = "FormRomance";
            this.Text = "FormRomance";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.DataGridView movie_grid;
        private System.Windows.Forms.TextBox descriptionBox;
    }
}