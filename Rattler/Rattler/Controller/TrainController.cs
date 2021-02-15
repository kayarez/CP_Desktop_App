using Rattler.Models;
using System;
using System.Linq;
using System.Windows;

namespace Rattler.Controller
{
    class TrainController
    {
        public bool CheckIfTrainExists(Train train)
        {
            MyDbContext context = new MyDbContext();
            if (context.Trains.FirstOrDefault(Train => Train.Type == train.Type) != null && context.Trains.FirstOrDefault(Train => Train.NumberTrain == train.NumberTrain) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddTrain(Train train)
        {
            try
            {
                if (!CheckIfTrainExists(train))
                {
                    MyDbContext context = new MyDbContext();
                    context.Trains.Add(train);
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

        public bool RemoveTrain(Train train)
        {
            try
            {
                if(CheckIfTrainExists(train))
                {
                    MyDbContext context = new MyDbContext();
                    context.Trains.Attach(train);
                    context.Trains.Remove(train);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool UpdateTrain()
        {
            try
            {
                MyDbContext context = new MyDbContext();
                context.SaveChanges();
                return true;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
