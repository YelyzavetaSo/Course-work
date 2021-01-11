using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Coach
    {
        public int CoachSequenceNumber { get; set; }
        public string Type { get; set; }
        public int SeatsNumber { get; set; }
        public Seat[] Seats { get; set; }
        public Coach() { }
        public int SeatsAvailable()
        {
            int count = 0;
            foreach(Seat seat in Seats)
            {
                if (seat.IsOccupied == false)
                {
                    ++count;
                }
            }
            return count;
        }
        public Coach(string type, int num, double cost)//that constructor receives a type of couch and its sequence number in train
        {
            if (type == "c")
            {
                CoachSequenceNumber = num;
                Type = "Compartment";
                SeatsNumber = 36;
                Seats = new Seat[SeatsNumber];
                for (int i = 0; i < SeatsNumber; i++)
                {
                    Seats[i] = new Seat(cost, i + 1);
                }
            }
            else if (type == "b")
            {
                CoachSequenceNumber = num;
                Type = "Berth";
                SeatsNumber = 54;
                Seats = new Seat[SeatsNumber];
                for (int i = 0; i < SeatsNumber; i++)
                {
                    Seats[i] = new Seat(cost, i + 1);
                }
            }
            else if (type == "dl")
            {
                CoachSequenceNumber = num;
                Type = "De Luxe";
                SeatsNumber = 18;
                Seats = new Seat[SeatsNumber];
                for (int i = 0; i < SeatsNumber; i++)
                {
                    Seats[i] = new Seat(cost, i + 1);
                }
            }
            else if (type == "s1")
            {
                CoachSequenceNumber = num;
                Type = "Seating first class";
                SeatsNumber = 64;
                Seats = new Seat[SeatsNumber];
                for (int i = 0; i < SeatsNumber; i++)
                {
                    Seats[i] = new Seat(cost, i + 1);
                }
            }
            else if (type == "s2")
            {
                CoachSequenceNumber = num;
                Type = "Seating second class";
                SeatsNumber = 94;
                Seats = new Seat[SeatsNumber];
                for (int i = 0; i < SeatsNumber; i++)
                {
                    Seats[i] = new Seat(cost, i + 1);
                }
            }
            else
                throw new NoSuchTypeOfCarriageException();
        }
        public override string ToString()
        {
            return $"{CoachSequenceNumber} | {Type} | {SeatsNumber} | {SeatsAvailable()}";
        }
    }
}
