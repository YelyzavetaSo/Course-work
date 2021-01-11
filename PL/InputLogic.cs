using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class InputLogic
    {
        //file paths for reservations and trains
        public static readonly string FileTrainPath = @"..\DataBase\Trains.bin";
        public static readonly string FileReservationPath = @"..\DataBase\Trains.bin";

        //methods to set date and time
        public static DateTime InputDateTime()
        {
            bool isSuccess = false;
            int year = 0, mounth = 0, day = 0, hour = 0, minute = 0;
            while (!isSuccess)
            {
                try
                {
                    year = InputDTValues("y");
                    mounth = InputDTValues("m");
                    day = InputDTValues("d");
                    hour = InputDTValues("h");
                    minute = InputDTValues("min");
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new DateTime(year, mounth, day, hour, minute, 00);
        }
        public static int InputDTValues(string line)
        {
            string pattern, data;
            int date = DateTime.Now.Year;
            if (line == "y")
            {
                pattern = $"^({date}|{date + 1})$";
                Console.WriteLine("Enter a year (Example: 2020):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else if (line == "m")
            {
                pattern = "^([1-9]|10|11|12)$";
                Console.WriteLine("Enter a mounth (Examples: 1, 12):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else if (line == "d")
            {
                pattern = "^([1-9]|1[0-9]|2[0-9]|3[01])$";
                Console.WriteLine("Enter a day (Examples: 1, 31)");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else if (line == "h")
            {
                pattern = "^(0[0-9]|1[0-9]|2[0-3])$";
                Console.WriteLine("Enter an hour (Example: 00, 23):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else if (line == "min")
            {
                pattern = "^[0-5][0-9]$";
                Console.WriteLine("Enter a minute (Example: 00, 59):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else throw new NotPassedValueException();
        }


        //methods to insert train value
        public static void InputTrain()
        {
            bool isSuccess = false;
            string type = null, number = null, departure = null, arrival = null;
            DateTime date = DateTime.Now;
            while (!isSuccess)
            {
                try
                {
                    type = InputForTrain("type");
                    number = InputForTrain("number");
                    departure = InputForTrain("departure");
                    arrival = InputForTrain("arrival");
                    date = InputDateTime();
                    isSuccess = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            EntityService.AddTrain(FileTrainPath, type, number, departure, arrival, date);
        }
        public static string InputForTrain(string line) 
        {
            string pattern, data;
            if (line == "number")
            {
                pattern = "^[0-9]{3}[A-Z]{1}$";
                Console.WriteLine("Enter train number, that contains 3 numbers and 1 upperspace letter(Example: 123A):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "type")
            {
                pattern = "^(IC|RE|NE|NF)$";
                Console.WriteLine("Types of trains:\n\tIC - Intercity;\n\tRE - Regional Express;\n" +
                    "\tNE - Night Express;\n\tNF - Night Fast Train.");
                Console.WriteLine("Enter 2 upperspace letters to choose train type:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "departure")
            {
                pattern = "^([A-Z]{1}[a-z]+|[A-Z]{1}[a-z]+[ ][A-Z]{1}[a-z]+|[A-Z]{1}[a-z]+[-][A-Z]{1}[a-z]+)$";//pattern for destination or arrival
                Console.WriteLine("Enter a destination(Examples: Kyiv, Kyiv Demiyivsky or Karolino-Buhaz):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "arrival")
            {
                pattern = "^([A-Z]{1}[a-z]+|[A-Z]{1}[a-z]+[ ][A-Z]{1}[a-z]+|[A-Z]{1}[a-z]+[-][A-Z]{1}[a-z]+)$";
                Console.WriteLine("Enter an arrival:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else throw new NotPassedValueException();
        }


        //methods to insert coach value
        public static void InputCoach()
        {
            bool isSuccess = false;
            string trainnumber = null, coachtype = null;
            double cost = 0.0;
            while (!isSuccess)
            {
                try
                {
                    trainnumber = InputForTrain("number");
                    coachtype = InputCoachType();
                    cost = InputCost();
                    isSuccess = true;
                }
                catch
                {
                    throw;
                }
            }
            try
            {
                EntityService.AddCoach(FileTrainPath, trainnumber, coachtype, cost);
            }
            catch { throw; }
            
        }
        public static double InputCost()
        {
            string pattern = "^[1-9][0-9]{2}.[0-9]{2}$", data;
            Console.WriteLine("Enter cost for seats in coach(Example: 123.45):");
            data = Console.ReadLine();
            if (!VerifyInputService.IsInputCorrect(data, pattern))
                throw new NotPassedValueException();
            return Double.Parse(data);
        }
        public static string InputCoachType()
        {
            string pattern, data;
            pattern = "^(c|b|dl|s1|s2)$";
            Console.WriteLine("Types of coaches:\n\tc - compartment(36 seats);\n\tb - berth(56 seats);\n" +
                "\ts1 - seating first class(64 seats);\n\ts2 - seating second class(94 seats).");
            Console.WriteLine("Enter underspace letter(s) to choose coach type:");
            data = Console.ReadLine();
            if (!VerifyInputService.IsInputCorrect(data, pattern))
                throw new NotPassedValueException();
            return data;
        }


        //methods to insert reserve
        public static void InputReserve()
        {
            bool isSuccess = false;
            string trainnumber = null;
            int coachnumber = 0, seatnumber = 0;
            DateTime dateTime = DateTime.Now;
            while (!isSuccess)
            {
                try
                {
                    trainnumber = InputForTrain("number");
                    coachnumber = InputInt("c");
                    seatnumber = InputInt("s");
                    isSuccess = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try { EntityService.AddReservation(FileTrainPath, FileReservationPath, trainnumber, coachnumber, seatnumber, dateTime); }
            catch { throw; }
        }
        public static int InputInt(string line)
        {
            string pattern, data;
            if (line == "c")
            {
                pattern = "^([1-9]|1[0-2])$";
                Console.WriteLine("Enter coach number:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else if (line == "s")
            {
                pattern = "^([1-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-4])$";
                Console.WriteLine("Enter seat number:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return Int32.Parse(data);
            }
            else throw new NotPassedValueException();
        }

    }
}
