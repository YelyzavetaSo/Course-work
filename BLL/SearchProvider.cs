using System;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    //search in file(Train, carriage, reservations)
    public class SearchProvider
    {
        //search train
        public static Train SearchOfTrainByNumber(string trainnumber, string filename)
        {
            List<Train> trains = EntityContext<Train>.ReadFile(filename);
            foreach (var train in trains)
            {
                if (train.TrainNumber == trainnumber)
                {
                    return train;
                }
            }
            throw new NoTrainException();
        }

        //search reservation by date
        public static List<Reservation> SearchOfReservation(DateTime dateOfReservation, string filename)
        {
            List<Reservation> reservationList = EntityContext<Reservation>.ReadFile(filename);
            List<Reservation> searchedReservations = new List<Reservation>();
            foreach (var reserve in reservationList)
            {
                if (reserve.DateOfReservation.Date == dateOfReservation.Date)
                {
                    searchedReservations.Add(reserve);
                }
            }
            if (searchedReservations.Count == 0)
                throw new NoReservationWithSuchDateException();
            return searchedReservations;
        }

        //search reservation by seat, coach and train data, gets file with reservations
        public static Reservation SearchReservationBySCTData(string trainNumber, int coachnumber, int seatnumber, string filename)
        {
            List<Reservation> reservationsList = EntityContext<Reservation>.ReadFile(filename);
            Reservation searchedReserve = new Reservation();
            foreach (var reserve in reservationsList)
            {
                if (reserve.TrainInfo.TrainNumber == trainNumber)
                {

                    if (reserve.CoachInfo == coachnumber)
                    {
                        if (reserve.SeatNumber == seatnumber)
                            searchedReserve = reserve;
                    }
                }
            }
            return searchedReserve;
        }

    }
}
