using System;
using DAL;

namespace BLL
{
    //class to add trains, coaches & reservations by reciving data from PL and write them to file
    public class EntityService
    {

        //adding of the train
        public static void AddTrain(string file, string traintype, string trainnumber, string departure, string arrival, DateTime dt)
            => EntityContext<Train>.WriteInFile(file, CreateEntity.CreateTrain(traintype, trainnumber, departure, arrival, dt));

        //overriding of method of adding of the train
        public static void AddTrain(string file, Train train) => EntityContext<Train>.WriteInFile(file, train);

        //adding of coach
        public static void AddCoach(string fileTrain, string trainnumber, string coachtype, double cost)
        {
            Train searchedTrain = new Train();
            searchedTrain = SearchProvider.SearchOfTrainByNumber(trainnumber, fileTrain);
            //removing of the train(to which coaches will be adding) from file
            RemoveProvider.RemoveTrain(fileTrain, trainnumber);
            Coach coach = new Coach(coachtype, searchedTrain.CoachesNumber+1, cost);
            searchedTrain.AddCoach(coach);
            AddTrain(fileTrain,searchedTrain);
        }

        //to end after search
        public static void AddReservation(string filetrain, string filereserve, string trainnumber, int coachnumber, int seatnumber, DateTime dt)
        {
            Train searchedTrain = new Train();
            try { searchedTrain = SearchProvider.SearchOfTrainByNumber(trainnumber, filetrain); }
            catch { throw; }
            RemoveProvider.RemoveTrain(filetrain, trainnumber);
            Coach searchedCoach = new Coach();
            //search of needed coach number
            foreach(Coach coach in searchedTrain.Coaches)
            {
                if (coach.CoachSequenceNumber == coachnumber)
                {
                    for (int i = 0; i < coach.SeatsNumber; ++i)
                    {
                        if ((coach.Seats[i].SeatNumber == seatnumber) && (coach.Seats[i].IsOccupied == false))
                        {
                            coach.Seats[i].SetOccupation("reserve");
                            searchedCoach = coach;
                        }
                        else if ((searchedCoach.Seats[i].SeatNumber == seatnumber) && (searchedCoach.Seats[i].IsOccupied != false))
                        {
                            throw new OccupationException();
                        }
                    }
                }
            }
            AddTrain(filetrain,searchedTrain);
            EntityContext<Reservation>.WriteInFile(filereserve, CreateEntity.CreateReservation(seatnumber, searchedCoach, searchedTrain, dt));
        }
    }
}