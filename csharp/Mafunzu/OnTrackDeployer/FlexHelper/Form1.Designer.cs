namespace FlexHelper
{
    partial class Form1
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
            this.searchFor = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.replaceWithLabel = new System.Windows.Forms.Label();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.processDirectoriesLabel = new System.Windows.Forms.Label();
            this.processDirectoriesTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fileExtensionsLabel = new System.Windows.Forms.Label();
            this.fileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadassemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whenThisTextIsFoundCheckBox = new System.Windows.Forms.CheckBox();
            this.textThatMustBeFoundTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchFor
            // 
            this.searchFor.AutoSize = true;
            this.searchFor.Location = new System.Drawing.Point(12, 36);
            this.searchFor.Name = "searchFor";
            this.searchFor.Size = new System.Drawing.Size(59, 13);
            this.searchFor.TabIndex = 0;
            this.searchFor.Text = "Search for:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(110, 29);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(368, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.Text = "find-this";
            // 
            // replaceWithLabel
            // 
            this.replaceWithLabel.AutoSize = true;
            this.replaceWithLabel.Location = new System.Drawing.Point(12, 68);
            this.replaceWithLabel.Name = "replaceWithLabel";
            this.replaceWithLabel.Size = new System.Drawing.Size(72, 13);
            this.replaceWithLabel.TabIndex = 2;
            this.replaceWithLabel.Text = "Replace with:";
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceTextBox.Location = new System.Drawing.Point(110, 68);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(368, 20);
            this.replaceTextBox.TabIndex = 3;
            this.replaceTextBox.Text = "XGryffeX";
            // 
            // processDirectoriesLabel
            // 
            this.processDirectoriesLabel.AutoSize = true;
            this.processDirectoriesLabel.Location = new System.Drawing.Point(12, 106);
            this.processDirectoriesLabel.Name = "processDirectoriesLabel";
            this.processDirectoriesLabel.Size = new System.Drawing.Size(60, 13);
            this.processDirectoriesLabel.TabIndex = 4;
            this.processDirectoriesLabel.Text = "Directories:";
            // 
            // processDirectoriesTextBox
            // 
            this.processDirectoriesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.processDirectoriesTextBox.Location = new System.Drawing.Point(110, 103);
            this.processDirectoriesTextBox.Name = "processDirectoriesTextBox";
            this.processDirectoriesTextBox.Size = new System.Drawing.Size(368, 20);
            this.processDirectoriesTextBox.TabIndex = 5;
            this.processDirectoriesTextBox.Text = "c:\\Mafunzu\\RunTrack\\Flex\\src\\;c:\\Mafunzu\\RunTrack\\Flex\\unit-test\\";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(321, 235);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(403, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fileExtensionsLabel
            // 
            this.fileExtensionsLabel.AutoSize = true;
            this.fileExtensionsLabel.Location = new System.Drawing.Point(12, 147);
            this.fileExtensionsLabel.Name = "fileExtensionsLabel";
            this.fileExtensionsLabel.Size = new System.Drawing.Size(79, 13);
            this.fileExtensionsLabel.TabIndex = 8;
            this.fileExtensionsLabel.Text = "File extensions:";
            // 
            // fileExtensionTextBox
            // 
            this.fileExtensionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fileExtensionTextBox.Location = new System.Drawing.Point(109, 140);
            this.fileExtensionTextBox.Name = "fileExtensionTextBox";
            this.fileExtensionTextBox.Size = new System.Drawing.Size(368, 20);
            this.fileExtensionTextBox.TabIndex = 9;
            this.fileExtensionTextBox.Text = ".as;.mxml";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadassemblyToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadassemblyToolStripMenuItem
            // 
            this.loadassemblyToolStripMenuItem.Name = "loadassemblyToolStripMenuItem";
            this.loadassemblyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadassemblyToolStripMenuItem.Text = "&Loadassembly";
            this.loadassemblyToolStripMenuItem.Click += new System.EventHandler(this.loadassemblyToolStripMenuItem_Click);
            // 
            // whenThisTextIsFoundCheckBox
            // 
            this.whenThisTextIsFoundCheckBox.AutoSize = true;
            this.whenThisTextIsFoundCheckBox.Location = new System.Drawing.Point(19, 186);
            this.whenThisTextIsFoundCheckBox.Name = "whenThisTextIsFoundCheckBox";
            this.whenThisTextIsFoundCheckBox.Size = new System.Drawing.Size(70, 17);
            this.whenThisTextIsFoundCheckBox.TabIndex = 11;
            this.whenThisTextIsFoundCheckBox.Text = "Condition";
            this.whenThisTextIsFoundCheckBox.UseVisualStyleBackColor = true;
            this.whenThisTextIsFoundCheckBox.Click += new System.EventHandler(this.whenThisTextIsFoundCheckBox_Click);
            // 
            // textThatMustBeFoundTextBox
            // 
            this.textThatMustBeFoundTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textThatMustBeFoundTextBox.Enabled = false;
            this.textThatMustBeFoundTextBox.Location = new System.Drawing.Point(109, 186);
            this.textThatMustBeFoundTextBox.Name = "textThatMustBeFoundTextBox";
            this.textThatMustBeFoundTextBox.Size = new System.Drawing.Size(368, 20);
            this.textThatMustBeFoundTextBox.TabIndex = 12;
            this.textThatMustBeFoundTextBox.Text = "this text must be found also (will not be replaced)";
            // 
            // Form1
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(492, 267);
            this.Controls.Add(this.textThatMustBeFoundTextBox);
            this.Controls.Add(this.whenThisTextIsFoundCheckBox);
            this.Controls.Add(this.fileExtensionTextBox);
            this.Controls.Add(this.fileExtensionsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.processDirectoriesTextBox);
            this.Controls.Add(this.processDirectoriesLabel);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.replaceWithLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchFor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FlexHelper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchFor;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label replaceWithLabel;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Label processDirectoriesLabel;
        private System.Windows.Forms.TextBox processDirectoriesTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label fileExtensionsLabel;
        private System.Windows.Forms.TextBox fileExtensionTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadassemblyToolStripMenuItem;
        private System.Windows.Forms.CheckBox whenThisTextIsFoundCheckBox;
        private System.Windows.Forms.TextBox textThatMustBeFoundTextBox;
    }
}