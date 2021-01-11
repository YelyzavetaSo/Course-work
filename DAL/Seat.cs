using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Seat
    {
        public int SeatNumber { get; set; }
        public double SeatCost { get; set; }
        public bool IsOccupied { get; set; }
        public Seat() => IsOccupied = false;
        public Seat(double cost, int num) { SeatNumber = num; SeatCost = cost; IsOccupied = false; }
        //public Seat(int sn) { SeatNumber = sn; IsOccupied = false; }
        public void SetOccupation(string st)
        {
            if (st == "reserve")
            {
                IsOccupied = true;
            }
            else IsOccupied = false;
        }
    }
}
