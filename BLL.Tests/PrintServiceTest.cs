using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using DAL;
using System.Collections.Generic;

namespace BLL.Tests
{
    [TestClass]
    public class PrintServiceTest
    {
        [TestMethod()]
        public void StringTrains_should_return_expected_objects_after_action()
        {
            string Path = @"..\DataBase\TrainsTest.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Train>.ClearFile(Path);
            foreach (Train train in GetTrainList())
            {
                ReadWriteProvider.WriteTrain(Path, train);
                expect.Append(train.ToString() + "\n");
            }
            StringBuilder actual = PrintService.StringTrains(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void StringTrain_should_return_expected_object_after_action()
        {
            string Path = @"..\DataBase\TrainsTest.bin";
            EntityContext<Train>.ClearFile(Path);
            ReadWriteProvider.WriteTrain(Path, GetTrainList()[0]);
            StringBuilder expect = new StringBuilder();
            expect.Append(GetTrainList()[0].ToString() + "\n");
            
            StringBuilder actual = PrintService.StringTrain(Path, GetTrainList()[0].TrainNumber);

            Assert.IsFalse(expect.ToString() == actual.ToString());
        }

        [TestMethod()]
        public void StringTrainWithCoaches_should_throw_exception_after_searching()
        {
            string Path = @"..\DataBase\TrainsTest.bin";

            Assert.ThrowsException<NoTrainException>(()=> PrintService.StringTrainWithCoaches(Path, "123R"));
        }
        

        public static List<Train> GetTrainList()
        {
            List<Train> trains = new List<Train>
            {
                new Train("IC", "123A", "Kyiv", "Odessa", DateTime.Now),
                new Train("NE", "123L", "Kyiv", "Lviv", DateTime.Now)
            };
            trains[0].AddCoach(new Coach("c", trains[0].CoachesNumber + 1, 123.45));
            trains[0].AddCoach(new Coach("b", trains[0].CoachesNumber + 1, 456.45));
            return trains;
        }
        public static List<Reservation> GetReservationsList()
        {
            List<Train> train = GetTrainList();
            List<Reservation> reservations = new List<Reservation>
            {
                new Reservation(2, train[0].Coaches[0], train[0], DateTime.Now),
                new Reservation(2, train[1].Coaches[0], train[1], DateTime.Now)
            };
            return reservations;
        }
    }
}
