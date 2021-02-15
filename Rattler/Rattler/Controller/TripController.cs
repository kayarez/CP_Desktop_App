using Rattler.Models;
using System;
using System.Linq;
using System.Windows;

namespace Rattler.Controller
{
    class TripController
    {
        public bool CheckIfTripExists(Trip trip)
        {
            MyDbContext context = new MyDbContext();
            if(context.Trips.FirstOrDefault(Trip => Trip.DateArrival == trip.DateArrival)!= null
                && context.Trips.FirstOrDefault(Trip => Trip.DateDeparture == trip.DateDeparture) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddTrip(Trip trip)
        {
            try
            {
                if (!CheckIfTripExists(trip))
                {
                    MyDbContext context = new MyDbContext();
                    context.Trips.Add(trip);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool RemoveTrip(Trip trip)
        {
            try
            {
                if (CheckIfTripExists(trip))
                {
                    MyDbContext context = new MyDbContext();
                    context.Trips.Attach(trip);
                    context.Trips.Remove(trip);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
