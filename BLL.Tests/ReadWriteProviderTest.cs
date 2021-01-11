using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class ReadWriteProviderTest
    {
        [TestMethod()]
        public void ReadTrain_should_return_list_of_trains_after_reading_file()
        {
            //arrange
            string Path = @"..\DataBase\TrainsTest.bin";
            EntityContext<Train>.ClearFile(Path);
            foreach (Train train in GetTrainList())
            {
                ReadWriteProvider.WriteTrain(Path, train);
            }
            List<Train> expect = GetTrainList();

            //act
            List<Train> readTrains = ReadWriteProvider.ReadTrain(Path);


            //assert
            Assert.AreEqual(expect.Count, readTrains.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i].TrainNumber, readTrains[i].TrainNumber);
                Assert.AreEqual(expect[i].Departure, readTrains[i].Departure);
                Assert.AreEqual(expect[i].Arrival, readTrains[i].Arrival);
                Assert.AreEqual(expect[i].CoachesNumber, readTrains[i].CoachesNumber);
            }
        }
        [TestMethod()]
        public void ReadTrain_should_throw_exception_about_empty_stream()
        {
            string Path = @"..\DataBase\TrainsTest.bin";

            //act
            EntityContext<Train>.ClearFile(Path); 

            //assert
            Assert.ThrowsException<SerializationException>(() => ReadWriteProvider.ReadTrain(Path));
        }


        [TestMethod()]
        public void ReadReservation_should_return_list_of_reserves_after_reading()
        {
            //arrange
            string Path = @"..\DataBase\ReserveTest.bin";
            EntityContext<Reservation>.ClearFile(Path);
            foreach (Reservation reserve in GetReservationsList())
            {
                ReadWriteProvider.WriteReservation(Path, reserve);
            }
            List<Reservation> expect = GetReservationsList();

            //act
            List<Reservation> readReserves = ReadWriteProvider.ReadReservation(Path);


            //assert
            Assert.AreEqual(expect[0].ToString(), readReserves[0].ToString());
            Assert.AreEqual(expect[1].ToString(), readReserves[1].ToString());
        }
        [TestMethod()]
        public void ReadReservation__should_throw_exception_about_empty_stream()
        {
            string Path = @"..\DataBase\ReserveTest.bin";

            //act
            EntityContext<Reservation>.ClearFile(Path);

            //assert
            Assert.ThrowsException<SerializationException>(() => ReadWriteProvider.ReadReservation(Path));
        }


        [TestMethod()]
        public void WriteTrain_should_leave_info_after_action()
        {
            string Path = @"..\DataBase\TrainsTest.bin";
            EntityContext<Train>.ClearFile(Path);
            var expected = GetTrainList();

            //action
            foreach(var train in expected)
            {
                ReadWriteProvider.WriteTrain(Path, train);
            }
            var actual = ReadWriteProvider.ReadTrain(Path);


            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].TrainNumber, actual[i].TrainNumber);
                Assert.AreEqual(expected[i].Departure, actual[i].Departure);
                Assert.AreEqual(expected[i].Arrival, actual[i].Arrival);
                Assert.AreEqual(expected[i].CoachesNumber, actual[i].CoachesNumber);
            }
        }
        [TestMethod()]
        public void WriteReservation_should_leave_info_after_action()
        {
            string Path = @"..\DataBase\ReserveTest.bin";
            EntityContext<Reservation>.ClearFile(Path);
            var expected = GetReservationsList();

            //action
            foreach (var reserve in expected)
            {
                ReadWriteProvider.WriteReservation(Path, reserve);
            }
            var actual = ReadWriteProvider.ReadReservation(Path);

            Assert.AreEqual(expected[0].ToString(), actual[0].ToString());
            Assert.AreEqual(expected[1].ToString(), actual[1].ToString());
        }


        public static List<Train> GetTrainList()
        {
            List<Train> trains = new List<Train>
            {
                new Train("IC", "123A", "Kyiv", "Odessa", DateTime.Now),
                new Train("NE", "123L", "Kyiv", "Lviv", DateTime.Now)
            };
            trains[0].AddCoach(new Coach("c", trains[0].CoachesNumber + 1, 123.00));
            trains[1].AddCoach(new Coach("b", trains[0].CoachesNumber + 1, 234.12));
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