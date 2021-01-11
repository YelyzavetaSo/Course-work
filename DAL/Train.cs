using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Train
    {
        private int coachNum;
        private double percent;

        public string TrainNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string TrainType { get; set; }
        public int CoachesNumber { get { return coachNum; } private set { coachNum = Coaches.Count; } }
        public DateTime DateTimeOfDeparture{ get; set; }
        public double PercentOfAvailableSits { get { return percent; } set { percent = PercentOFAvailableSeatsInTrain(); } }
        public List<Coach> Coaches { get; set; }
        public Train() { }
        public Train(string tt, string trainnumber, string departure, string arrival, DateTime dateTime)
        {
            TrainNumber = trainnumber;
            Departure = departure;
            Arrival = arrival;
            DateTimeOfDeparture = dateTime;
            Coaches = new List<Coach>();
            if (tt == "IC")
            {
                TrainType = "Intercity";
                Coaches.Add(new Coach("s1", 1, 234.34));
            }
            else if (tt == "RE")
            {
                TrainType = "Regional express";
                Coaches.Add(new Coach("c", 1, 150.50));
            }   
            else if (tt == "NE")
            {
                TrainType = "Night express";
                Coaches.Add(new Coach("c", 1, 200.50));
            }
            else if (tt == "NF")
            {
                TrainType = "Night fast train";
                Coaches.Add(new Coach("c", 1, 250.50));
            }
            else throw new NoSuchTypeOfTrainException();
        }
        protected double PercentOFAvailableSeatsInTrain()
        {
            int AvailableSeat = 0, AllSeats = 0;
            if (CoachesNumber != 0) 
            {
                foreach (Coach coach in Coaches)
                {
                    AllSeats += coach.SeatsNumber;
                    AvailableSeat += coach.SeatsAvailable();
                }
                return (100 * AvailableSeat) / AllSeats;
            }
            else return 0.0;
        }
        public override string ToString() => $"({TrainType}){TrainNumber} | {Departure} - {Arrival}" +
            $" | {DateTimeOfDeparture : hh:mm} | {PercentOfAvailableSits}%";
        public void AddCoach(Coach tmp)
        {
            if (Coaches.Count < 12)//cheking if number of coach is maximum
            {
                Coaches.Add(tmp);
            }
            else throw new MaximumCoachNumberException();
        }
        public void RemoveCoach(int nc)
        {
            if (Coaches.Count != 0)
            {
                foreach (Coach coach in Coaches)
                {
                    if ((coach.CoachSequenceNumber == nc) && (coach.SeatsNumber == coach.SeatsAvailable()))
                    {
                        Coaches.Remove(coach);
                    }
                }
            }
            else throw new NoSuchNumberOfCoachException();
        }
    }
}
