using System.Text;
using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    //class to make strings from entities
    public static class PrintService
    { 
        public static StringBuilder StringTrains(string filename)
        {
            StringBuilder trainstrings = new StringBuilder();
            foreach(var item in ReadWriteProvider.ReadTrain(filename))
            {
                trainstrings.Append(item.ToString()+"\n");
            }
            return trainstrings;
        }

        //two methods are using search methods
        public static StringBuilder StringTrain(string filename, string trainnumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append(SearchProvider.SearchOfTrainByNumber(trainnumber, filename).ToString());
            }
            catch { throw; }
            return stringBuilder;
        }
        public static StringBuilder StringTrainWithCoaches(string filename, string trainnumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try 
            {
                Train train = SearchProvider.SearchOfTrainByNumber(trainnumber, filename);
                stringBuilder.Append(train.ToString());
                foreach(var coach in train.Coaches)
                {
                    stringBuilder.Append($"Free seats in {coach.CoachSequenceNumber} coach is {coach.SeatsAvailable()}\n");
                }
            }
            catch { throw; }
            return stringBuilder;
        }

        public static StringBuilder StringReservations(string filename)
        {
            StringBuilder trainstrings = new StringBuilder();
            foreach (var item in ReadWriteProvider.ReadReservation(filename))
            {
                trainstrings.Append(item.ToString() + "\n");
            }
            return trainstrings;
        }
        //methods are using search methods
        public static StringBuilder StringReserveByDate(string filename, DateTime dateTime)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Reservation> list = new List<Reservation>();
            try
            {
                list = SearchProvider.SearchOfReservation(dateTime, filename);
            }
            catch { throw; }
            foreach(var item in list)
            {
                stringBuilder.Append(item.ToString() + "\n");
            }
            return stringBuilder;
        }
        public static StringBuilder StringReserveBySeat(string filename, string trainnumber, int coach, int seat)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Reservation reservation = new Reservation();
            try
            {
                reservation = SearchProvider.SearchReservationBySCTData(trainnumber, coach, seat, filename);
            }
            catch { throw; }
            stringBuilder.Append(reservation.ToString());
            return stringBuilder;
        }

    }
}
