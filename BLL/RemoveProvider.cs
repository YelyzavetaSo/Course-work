using System.Collections.Generic;
using DAL;

namespace BLL
{
    //remove from file(Train, carriage, reservation)
    public static class RemoveProvider
    {
        //remove train, get name of file with trains
        public static void RemoveTrain(string filename, string trainnumber)
        {
            List<Train> trainList = EntityContext<Train>.ReadFile(filename);
            for (int i = 0; i < trainList.Capacity; ++i)
            {
                if (trainList[i].TrainNumber == trainnumber)
                {
                    trainList.RemoveAt(i);
                }
            }
            EntityContext<Train>.ClearFile(filename);
            foreach (Train train in trainList)
            {
                EntityContext<Train>.WriteInFile(filename, train);
            }
        }

        //remove coach
        public static void RemoveCoach(string filename, string trainnumber, int coachnumber)
        {
            List<Train> trainsList = EntityContext<Train>.ReadFile(filename);
            Train searchedTrain = SearchProvider.SearchOfTrainByNumber(trainnumber, filename);
            foreach (Train train in trainsList)
            {
                if (searchedTrain.TrainNumber == train.TrainNumber)
                {
                    train.RemoveCoach(coachnumber);
                }
            }
            //clearing of train file
            EntityContext<Train>.ClearFile(filename);
            foreach (Train train in trainsList)
            {
                EntityContext<Train>.WriteInFile(filename, train);
            }
        }

        //remove reservation    
        public static void RemoveReserve(string reservefilename, string trainfilename, int seatnumber, int coachnumber, string trainnumber)
        {
            List<Reservation> reservationList = EntityContext<Reservation>.ReadFile(reservefilename);
            List<Train> trainList = EntityContext<Train>.ReadFile(trainfilename);
            Reservation searchedreservation = SearchProvider.SearchReservationBySCTData(trainnumber, coachnumber, seatnumber, reservefilename);
            //clearing of both of files
            EntityContext<Reservation>.ClearFile(reservefilename);
            EntityContext<Train>.ClearFile(trainfilename);
            Train searchedTrain = new Train();
            //cycle to find needed train, when it found => that train is removing from list
            foreach (Train train in trainList)
            {
                if (train.TrainNumber == trainnumber)
                {
                    searchedTrain = train;
                }
            }
            trainList.Remove(searchedTrain);                          //remove train with reservation from list
            reservationList.Remove(searchedreservation);              //remove reservation from list
            //cycle to find seat and remove reservation
            foreach (Coach coach in searchedTrain.Coaches)
            {
                if (coach.CoachSequenceNumber == coachnumber)//search of the coach with needed number
                {
                    foreach (Seat seat in coach.Seats)
                    {
                        if (seat.SeatNumber == seatnumber)   //search of needeed seat
                        {
                            seat.SetOccupation("other");     //to delete reservation => sets non occupated status
                        }
                    }
                }
            }
            trainList.Add(searchedTrain); //re adding train in list after removed reservation
            //rewriting files 
            foreach(Reservation reserve in reservationList)
            {
                EntityContext<Reservation>.WriteInFile(reservefilename, reserve);
            }
            foreach (Train train in trainList)
            {
                EntityContext<Train>.WriteInFile(reservefilename, train);
            }

        }
    }
}
