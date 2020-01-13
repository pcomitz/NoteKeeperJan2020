using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoteKeeper.Models;
using NoteKeeper.Views;

namespace NoteKeeper.ViewModels
{
    /*
     * Step 7 last 
     * This class subscribes to the SaveNote message
     */
    public class ItemsViewModel : BaseViewModel
    {
        //changed in 7 
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //step 7 subscribe to message
            // he throws in an lambda with two outs in the bottome of the 9th
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this,"SaveNote",
                async (sender, note) => {
                Notes.Add(note);
                await PluralsightDataStore.AddNoteAsync(note); 
           }); 

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notes.Clear();
                // this gets complicated 
                // PluralSightDataStore is a (member ...property? ) 
                // created in BaseViewModel via DependencyService
                // it is of type IPluralSightDataStore 
                var notes = await PluralsightDataStore.GetNotesAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}