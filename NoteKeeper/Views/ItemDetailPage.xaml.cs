using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using NoteKeeper.Services;

namespace NoteKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    /*
     * Step 7 - last thing
     * This class sends the SaveNote message. 
     * See the Save_Clicked method
     */
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        
        public System.Collections.Generic.IList<String> CourseList { get; set;}

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            // added in data binding section 
            // he missied removal of this
            // InitializeData();
            this.viewModel = viewModel;
            BindingContext = this.viewModel; 

            // since CourseList is paret of this object set 
            // BindingContext for Picker to this            
            // this.NoteCourse.BindingContext = this;

            // just for fun
            // can access views with x:Name programatically
            // this.NoteHeading.Text = "Hello Tucson";
            // this.NoteText.Text = "How goes the game?";
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            // he missed removal of this also 
            // InitializeData();
            viewModel = new ItemDetailViewModel();
            BindingContext = this.viewModel; 

            // since CourseList is parent of this object set 
            // BindingContext for Picker to this
            // this.NoteCourse.BindingContext = this;
        }

        private async void InitializeData()
        {
            var pluralsightDataStore = new MockPluralsightDataStore();
            CourseList = await pluralsightDataStore.GetCoursesAsync();
            // note the syntax using commas
            // The Note class does not even have a ctor, this must be 
            // the way to use c# accessors to init and object
            
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            //test - modifify data model- check for notifcations
            /*
            viewModel.NoteHeading = "XXXXXXX"; 
            DisplayAlert("Cancel Option", "Heading value is" + viewModel.Note.Heading, 
                          "Button 2", "Button 1"); 
            */
            //step 7 adding modal page navigation 
            Navigation.PopModalAsync(); 
        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            //Send SaveNote message
            MessagingCenter.Send(this, "SaveNote", this.viewModel.Note); 

            //DisplayAlert("Save Option", "Save was selected", "Button 2", "Button 1");
            //step 7 adding modal page navigation 
            Navigation.PopModalAsync();
        }
    
    }
}