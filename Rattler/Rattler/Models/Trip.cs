using Rattler.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Rattler.Models
{
    public class Trip: ICloneable, INotifyPropertyChanged
    {
        private int numberSeats;
        [Key]
        public int Id { get; set; }
        [Required]
        public System.DateTime? DateDeparture { get; set; }
        [Required]
        public System.DateTime? DateArrival { get; set; }
        [Required]
        public string PlaceDeparture { get; set; }
        [Required]
        public string PlaceArrival { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int NumberSeats
        {
            get { return numberSeats; }
            set
            {
                if (numberSeats == value)
                    return;
                else
                {
                    if (value >= 0)
                    {
                        numberSeats = value;
                        OnPropertyChanged("NumberSeats");
                    }

                }
            }
        }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public  List<Ticket> Tickets { get; set; }


        public object Clone()
        {
            return new Trip()
            {
                Train = new Train()
                {
                    Id = this.Train.Id,
                    Type = this.Train.Type,
                },
                Id = this.Id,
                DateDeparture = this.DateDeparture,
                DateArrival = this.DateArrival,
                PlaceDeparture = this.PlaceDeparture,
                PlaceArrival = this.PlaceArrival,
                Cost = this.Cost,
                TrainId = this.TrainId

            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public Trip()
        {

        }

        public Trip(DateTime? dateDeparture, DateTime? dateArrival, string placeDeparture, string placeArrival, double cost, int numberSeats, string numberTrain, string type)
        {
            DateDeparture = dateDeparture;
            DateArrival = dateArrival;
            PlaceDeparture = placeDeparture;
            PlaceArrival = placeArrival;
            NumberSeats = numberSeats;
            Cost = cost;
            using (MyDbContext context = new MyDbContext())
            {
                try
                {
                    Train trainFromDb = context.Trains.First(train => train.NumberTrain == numberTrain && train.Type == type);
                    this.TrainId = trainFromDb.Id;
                }
                catch (Exception)
                {
                    Train train = new Train(type, numberTrain);
                    this.Train = train;
                }

            }
        }

    }
}
