namespace DeckjsHelper
{
    partial class MainWindow
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
            this.extensionsListBox = new System.Windows.Forms.ListBox();
            this.stylesListBox = new System.Windows.Forms.ListBox();
            this.transitionsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputBrowseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.extsReloadButton = new System.Windows.Forms.Button();
            this.stylesReloadButton = new System.Windows.Forms.Button();
            this.transitionsReloadButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.djlTextBox = new System.Windows.Forms.TextBox();
            this.djlBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // extensionsListBox
            // 
            this.extensionsListBox.FormattingEnabled = true;
            this.extensionsListBox.Location = new System.Drawing.Point(9, 140);
            this.extensionsListBox.Name = "extensionsListBox";
            this.extensionsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.extensionsListBox.Size = new System.Drawing.Size(159, 147);
            this.extensionsListBox.TabIndex = 6;
            // 
            // stylesListBox
            // 
            this.stylesListBox.FormattingEnabled = true;
            this.stylesListBox.Location = new System.Drawing.Point(174, 140);
            this.stylesListBox.Name = "stylesListBox";
            this.stylesListBox.Size = new System.Drawing.Size(159, 147);
            this.stylesListBox.TabIndex = 7;
            // 
            // transitionsListBox
            // 
            this.transitionsListBox.FormattingEnabled = true;
            this.transitionsListBox.Location = new System.Drawing.Point(339, 140);
            this.transitionsListBox.Name = "transitionsListBox";
            this.transitionsListBox.Size = new System.Drawing.Size(159, 147);
            this.transitionsListBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Extensions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Style themes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transition themes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Output folder";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(9, 62);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(417, 20);
            this.outputTextBox.TabIndex = 3;
            // 
            // outputBrowseButton
            // 
            this.outputBrowseButton.Location = new System.Drawing.Point(432, 60);
            this.outputBrowseButton.Name = "outputBrowseButton";
            this.outputBrowseButton.Size = new System.Drawing.Size(66, 23);
            this.outputBrowseButton.TabIndex = 4;
            this.outputBrowseButton.Text = "Browse";
            this.outputBrowseButton.UseVisualStyleBackColor = true;
            this.outputBrowseButton.Click += new System.EventHandler(this.outputBrowseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Presentation title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(9, 101);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(489, 20);
            this.titleTextBox.TabIndex = 5;
            // 
            // extsReloadButton
            // 
            this.extsReloadButton.Location = new System.Drawing.Point(9, 294);
            this.extsReloadButton.Name = "extsReloadButton";
            this.extsReloadButton.Size = new System.Drawing.Size(159, 23);
            this.extsReloadButton.TabIndex = 9;
            this.extsReloadButton.Text = "Reload";
            this.extsReloadButton.UseVisualStyleBackColor = true;
            this.extsReloadButton.Click += new System.EventHandler(this.extsReloadButton_Click);
            // 
            // stylesReloadButton
            // 
            this.stylesReloadButton.Location = new System.Drawing.Point(174, 294);
            this.stylesReloadButton.Name = "stylesReloadButton";
            this.stylesReloadButton.Size = new System.Drawing.Size(159, 23);
            this.stylesReloadButton.TabIndex = 10;
            this.stylesReloadButton.Text = "Reload";
            this.stylesReloadButton.UseVisualStyleBackColor = true;
            this.stylesReloadButton.Click += new System.EventHandler(this.stylesReloadButton_Click);
            // 
            // transitionsReloadButton
            // 
            this.transitionsReloadButton.Location = new System.Drawing.Point(340, 294);
            this.transitionsReloadButton.Name = "transitionsReloadButton";
            this.transitionsReloadButton.Size = new System.Drawing.Size(158, 23);
            this.transitionsReloadButton.TabIndex = 11;
            this.transitionsReloadButton.Text = "Reload";
            this.transitionsReloadButton.UseVisualStyleBackColor = true;
            this.transitionsReloadButton.Click += new System.EventHandler(this.transitionsReloadButton_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(216, 339);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 12;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "deck.js location";
            // 
            // djlTextBox
            // 
            this.djlTextBox.Location = new System.Drawing.Point(9, 25);
            this.djlTextBox.Name = "djlTextBox";
            this.djlTextBox.Size = new System.Drawing.Size(417, 20);
            this.djlTextBox.TabIndex = 1;
            // 
            // djlBrowseButton
            // 
            this.djlBrowseButton.Location = new System.Drawing.Point(432, 23);
            this.djlBrowseButton.Name = "djlBrowseButton";
            this.djlBrowseButton.Size = new System.Drawing.Size(66, 23);
            this.djlBrowseButton.TabIndex = 2;
            this.djlBrowseButton.Text = "Browse";
            this.djlBrowseButton.UseVisualStyleBackColor = true;
            this.djlBrowseButton.Click += new System.EventHandler(this.djlBrowseButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 372);
            this.Controls.Add(this.djlBrowseButton);
            this.Controls.Add(this.djlTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.transitionsReloadButton);
            this.Controls.Add(this.stylesReloadButton);
            this.Controls.Add(this.extsReloadButton);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outputBrowseButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.transitionsListBox);
            this.Controls.Add(this.stylesListBox);
            this.Controls.Add(this.extensionsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "deck.js Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox extensionsListBox;
        private System.Windows.Forms.ListBox stylesListBox;
        private System.Windows.Forms.ListBox transitionsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputBrowseButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button extsReloadButton;
        private System.Windows.Forms.Button stylesReloadButton;
        private System.Windows.Forms.Button transitionsReloadButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox djlTextBox;
        private System.Windows.Forms.Button djlBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;


    }
}

