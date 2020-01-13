using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using NoteKeeper.Models;
using NoteKeeper.Services;

namespace NoteKeeper.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //is this one OBE?
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        // added in 6 Managing with MVVM
        // => shorthand notation for single line get 
        // ?? if null, create new MockPluralSightDataStore
        // returns null if no implementation method registered
        public IPluralsightDataStore PluralsightDataStore =>
            DependencyService.Get<IPluralsightDataStore>() ??
            new MockPluralsightDataStore(); 

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
