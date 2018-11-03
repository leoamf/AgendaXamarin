using AgendaContatos.Dominio;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendaContatos.UI;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AgendaContatos
{
    public partial class App : Application
    {
        public new static App Current { get; set; }

        private const string dataUltimoRegistroKey = "DataUltimoRegistroKey";
        public string DataUltimoRegistroKey
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(dataUltimoRegistroKey))
                {
                    return Application.Current.Properties[dataUltimoRegistroKey].ToString();
                }

                return "";
            }

            set
            {
                Application.Current.Properties[dataUltimoRegistroKey] = value;
                Application.Current.SavePropertiesAsync();

            }
        }
        static SQLiteConnection _bd;


        public App()
        {
            InitializeComponent();
            Current = this;
            MainPage = new NavigationPage(new MainPage());
        }

        public static SQLiteConnection BD
        {
            get
            {
                if (_bd == null)
                {
                    string path = DependencyService.Get<IDatabasePath>().GetPath();
                    _bd = new SQLiteConnection(path);
                    _bd.CreateTable<Contato>();
                }

                return _bd;

            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
