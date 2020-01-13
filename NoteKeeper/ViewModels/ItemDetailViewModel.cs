using System;

using NoteKeeper.Models;
using System.Collections.Generic; 

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

       // NoteHeading property
        public String NoteHeading
        {
            get { return Note.Heading;  }
            set 
            { 
                    Note.Heading = value;
                    //call base class method fir INotifyPropertyChanged
                    this.OnPropertyChanged(); 
            }
        }

        //NoteText property
        public String NoteText
        {
            get { return Note.Text;  }
            set
            {
                Note.Text = value;
                this.OnPropertyChanged(); 
            }
        }

        //NoteCourse property
        public String NoteCourse
        {
            get { return Note.Course; }
            set
            {
                Note.Course = value;
                this.OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Note note = null)
        {
            this.InitializeCourseList();
            Title = "Edit Note"; 
            // if note param is null, create empty note
            Note = note ?? new Note();
        }        
            
        //did he forget this ? 
        async void InitializeCourseList()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }

    } //~class
} //~ namespace

