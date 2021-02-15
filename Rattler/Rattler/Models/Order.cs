using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rattler.Models
{
    public class Order:INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public int? UserId { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        public enum State
        {
            Done, Undone
        }

        State state = State.Undone;
      
        public State States
        {
        
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("States");
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;   

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
