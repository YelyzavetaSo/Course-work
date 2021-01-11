using System.Collections.Generic;
using DAL;

namespace BLL
{
    //class to set types for reading and writing in files
    //using of methods from DAL
    public static class ReadWriteProvider
    {
        public static List<Train> ReadTrain(string filename) => EntityContext<Train>.ReadFile(filename);
        public static List<Reservation> ReadReservation(string fileName) => EntityContext<Reservation>.ReadFile(fileName);
        public static void WriteTrain(string filename, Train train) { EntityContext<Train>.WriteInFile(filename, train); }
        public static void WriteReservation(string filename, Reservation reservation) { EntityContext<Reservation>.WriteInFile(filename, reservation); }
    }
}
