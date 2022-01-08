using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Veterinary.Data;

namespace Veterinary
{
    public partial class App : Application
    {
        static VetDatabase database;
        public static VetDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   VetDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Vet.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
