using Xamarin.Forms;

namespace TaxCalculator
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            DependencyInjection.Init();
            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

