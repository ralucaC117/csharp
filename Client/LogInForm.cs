/*using mpp_proiect_csharp.Services;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;*/

using mpp_proiect_csharp.Services;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using System.Windows.Forms;

namespace mpp_proiect_csharp
{
    public partial class LogInForm : Form
    {
        private Controller controller;
        

        public LogInForm(Controller controller)
        {         
            InitializeComponent();
            this.controller = controller;
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
          
            log4net.Config.XmlConfigurator.Configure();           
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            try
            {
                this.Visible = false;
                int id = controller.login(username, password);
                MessageBox.Show("Login succeded");
                MainForm mainForm = new MainForm(controller)
                {
                    IdOperator = id
                };
                mainForm.ShowDialog();  
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
