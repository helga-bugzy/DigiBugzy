using DevExpress.XtraSplashScreen;
namespace DigiBugzy.Desktop.MultiFunctional
{
    public partial class PageSplashScreen : SplashScreen
    {
        public string Title { 
            get => labelStatus.Text;
            set => labelStatus.Text = $"Opening {value} page, please wait....";
        }

        public PageSplashScreen()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2022-" + DateTime.Now.Year;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}