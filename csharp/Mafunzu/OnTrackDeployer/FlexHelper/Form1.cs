using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlexHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   

        private void okButton_Click(object sender, EventArgs e)
        {
            if(searchTextBox.Text.Length==0)
            {
                return;
            }
            if(processDirectoriesTextBox.Text.Length==0)
            {
                return;
            }
            var directories = processDirectoriesTextBox.Text.Trim().Split(new char[] { ';' });
            var fileExtensions = fileExtensionTextBox.Text.Trim().Split(new char[] {';'});

            IWordReplacer wordReplacer = null;
            if (whenThisTextIsFoundCheckBox.Checked && textThatMustBeFoundTextBox.Text.Length>0)
            {
                wordReplacer = new ConditionalWordReplacer(searchTextBox.Text.Trim(), replaceTextBox.Text.Trim(),
                                            textThatMustBeFoundTextBox.Text);
            }
            else
            {
                wordReplacer = new WordReplacer(searchTextBox.Text.Trim(), replaceTextBox.Text.Trim());
            }

            foreach (var directory in directories)
            {
                var recursiveFileWordReplacer = new RecursiveFileWordReplacer(directory, wordReplacer, fileExtensions);
                recursiveFileWordReplacer.ReplaceAll();
            }
            MessageBox.Show("All done");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadassemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var assemblyToLoadPath = @"c:\Ontrack\OnTrackDeployer\ConnectionStringSetterTask\bin\Debug\log4net.dll"; 
            PrintAssembly.RunILAssemblyParser(new string[]{assemblyToLoadPath});
        }

        private void whenThisTextIsFoundCheckBox_Click(object sender, EventArgs e)
        {
            textThatMustBeFoundTextBox.Enabled = whenThisTextIsFoundCheckBox.Checked;
        }
    }
}