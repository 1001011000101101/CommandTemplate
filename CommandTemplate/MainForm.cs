using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandTemplate.Models;

namespace CommandTemplate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Command> Commands = new List<Command>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Commands = CommandsCreator.Execute();

            cbCommands.DataSource = Commands.Select(x => new { x.Name, x.SysName }).ToList();
            cbCommands.DisplayMember = "Name";
            cbCommands.ValueMember = "SysName";
            cbCommands.Enabled = true;
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            string commandSysName = ((dynamic)cbCommands.SelectedItem).SysName;
            Command command = Commands.FirstOrDefault(x => x.SysName == commandSysName);
            await command.ExecuteAsync();

            MessageBox.Show("All done");
        }
    }
}
