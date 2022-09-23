using DevExpress.XtraEditors;
using System;

namespace DigiBugzy.Desktop.Dashboards
{
    public partial class DashChild : XtraForm
    {
        #region Delegates & Events

        public delegate void PassControl(string? option, string? section);

        public PassControl passControl;

        #endregion

        #region Ctor

        public DashChild()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Event Procedures

        /// <summary>
        /// Event raised when buttons are click - to signal selection to main parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttons_Click(object sender, EventArgs e)
        {
            var button = (SimpleButton)sender;
            passControl(option: button.Text, section: button.Tag.ToString());
                
        }

        #endregion
    }
}