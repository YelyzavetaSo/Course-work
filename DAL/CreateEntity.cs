using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //to create Entities like Train or Coach by getting info fron higher levels
    public class CreateEntity
    {
        public static Coach CreateCoach(string type, int sequenceNum, double cost) => new Coach(type, sequenceNum, cost);
        public static Train CreateTrain(string type, string trainnumber, string departure, string arrival, DateTime dt)
            => new Train(type, trainnumber, departure, arrival, dt);
        public static Reservation CreateReservation(int seat, Coach coach, Train train, DateTime date)
            => new Reservation(seat, coach, train, date);
    }
}
