using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Reservation
    {
        public DateTime DateOfReservation { get; set; }
        public int SeatNumber { get; set; }
        public int CoachInfo{ get; set; }
        public Train TrainInfo { get; set; }
        public double ReservationCost { get; set; }
        public Reservation() { }
        public Reservation(int seat, Coach coach, Train train, DateTime date)
        {
            SeatNumber = seat;
            coach.Seats[SeatNumber].SetOccupation("reserve");
            ReservationCost = coach.Seats[SeatNumber].SeatCost;
            CoachInfo = coach.CoachSequenceNumber;
            TrainInfo = train;
            DateOfReservation = date;
        }
        public override string ToString() => $" Information about reservation:\n Train information: {TrainInfo}\n" +
            $" Coach number:{CoachInfo}\n Seat number:{SeatNumber}\n Reservation cost:{ReservationCost}\n Date of reservation:{DateOfReservation:dd-MM}";
    }
}
