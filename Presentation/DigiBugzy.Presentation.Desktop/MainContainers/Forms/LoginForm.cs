



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBugzy.Presentation.Desktop.MainContainers.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IMediator _mediator;
        public LoginForm(IMediator mediator)
        {
            _mediator = mediator;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            if(cmbAdministration.SelectedIndex < 0)
            {
                lblMessage.Text = "Please select an administration to continue";
            }

            
        }

        private async void LoadDigiAdministrations()
        {
            var response = await _mediator.Send(new GetDigiAdminsDto { Filter = new StandardFilter(false, false) });
            
        }
    }
}
