using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Refleksja
{
    public partial class Form1 : Form
    {
        private List<Type> list = new List<Type>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            list.Clear();

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var filesEXE = Directory.GetFiles(folderDialog.SelectedPath, "*.exe");
                foreach (var file in filesEXE)
                {
                    addClassesInContract(file);
                }

                var filesDLL = Directory.GetFiles(folderDialog.SelectedPath, "*.dll");
                foreach (var file in filesDLL)
                {
                    addClassesInContract(file);
                }
                

                foreach (var methot in list)
                {                    
                    this.comboBox1.Items.Add(methot);
                }
            }
        }

        private void addClassesInContract(String path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            var assembly = Assembly.LoadFrom(path);
            foreach (var type in assembly.GetExportedTypes())
            {
                if (!typeof(IMethod).IsAssignableFrom(type))
                {
                    continue;
                }

                if (!(Activator.CreateInstance(type) is IMethod method))
                {
                    throw new InvalidOperationException();
                }

                list.Add(type);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = this.comboBox1.SelectedItem as Type;
            
            var descriptionAttribute = type.GetCustomAttribute<DescriptionAttribute>(true);
            if (descriptionAttribute != null)
            {
                this.descriptionLabel.Text = descriptionAttribute.Description;
            }
            else
            {
                this.descriptionLabel.Text = "No description.";
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            var type = this.comboBox1.SelectedItem as Type;
            if (type != null)
            {
                if (!(Activator.CreateInstance(type) is IMethod method))
                {
                    throw new InvalidOperationException();
                }
                
                if (Int32.TryParse(argOne.Text, out int a) && Int32.TryParse(argTwo.Text, out int b))
                {
                    this.resultLabel.Text = method.Method(a, b).ToString();
                }
                else
                {
                    MessageBox.Show("Invalid argument type.");
                }

            }
        }

    }
}
