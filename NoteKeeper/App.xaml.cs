using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoteKeeper.Services;
using NoteKeeper.Views;

namespace NoteKeeper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            //set startup page
            MainPage = new MainPage();
            //change startup page 
            //MainPage = new ItemDetailPage();
            //an experiment 
            //MainPage = new MyContentPage(); 
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
