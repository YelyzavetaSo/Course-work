using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class CommandHandler
    {
        public void CommandHandle()
        {
            EntityMenu.HelpMenu();
            bool stop = false;
            while (!stop)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "train":
                        EntityMenu.TrainMenu();
                        string data = Console.ReadLine();
                        switch (data)
                        {
                            case "add":
                                bool isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputTrain();
                                        isSuccess = true;
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Train was added!");
                                break;
                            case "addcoach":
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputCoach();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Coach was added!");
                                break;
                            case "remove":
                                string trainnumber = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trainnumber = InputLogic.InputForTrain("number");
                                        isSuccess = true;
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                try { RemoveProvider.RemoveTrain(InputLogic.FileTrainPath, trainnumber); }
                                catch(Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "removecoach":
                                trainnumber = null;
                                int coachnumber = 0;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trainnumber = InputLogic.InputForTrain("number");
                                        coachnumber = InputLogic.InputInt("c");
                                        isSuccess = true;
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                try { RemoveProvider.RemoveCoach(InputLogic.FileTrainPath, trainnumber, coachnumber); }
                                catch(Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "showall":
                                string trains = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trains = PrintService.StringTrains(InputLogic.FileTrainPath).ToString();
                                        isSuccess = true;
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(trains);
                                break;
                            case "showcertain":
                                trainnumber = null; 
                                trains = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trainnumber = InputLogic.InputForTrain("number");
                                        trains = PrintService.StringTrain(InputLogic.FileTrainPath, trainnumber).ToString();
                                        isSuccess = true;
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(trains);
                                break;
                            case "showcoaches":
                                trains = null;
                                trainnumber = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trainnumber = InputLogic.InputForTrain("number");
                                        trains = PrintService.StringTrainWithCoaches(InputLogic.FileTrainPath, trainnumber).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(trains);
                                break;
                            case "search":
                                trains = null;
                                trainnumber = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        trainnumber = InputLogic.InputForTrain("number");
                                        trains = PrintService.StringTrain(InputLogic.FileTrainPath, trainnumber).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(trains);
                                break;
                            case "end":
                                EntityMenu.HelpMenu();
                                break;
                            default: Console.WriteLine("Wrong command!");
                                break;
                        }
                        break;
                    case "reserve":
                        EntityMenu.ReservationMenu();
                        data = Console.ReadLine();
                        switch (data)
                        {
                            case "reserve":
                                bool isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputReserve();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Reserve was added!");
                                break;
                            case "remove":
                                int coach = 0, seat = 0;
                                string train = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        train = InputLogic.InputForTrain("number");
                                        coach = InputLogic.InputInt("c");
                                        seat = InputLogic.InputInt("s");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                try { RemoveProvider.RemoveReserve(InputLogic.FileReservationPath, InputLogic.FileTrainPath, seat, coach, train); }
                                catch(Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "change":
                                coach = 0;
                                seat = 0;
                                train = null;
                                isSuccess = false;
                                Console.WriteLine("Now enter information about previous reserve:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        train = InputLogic.InputForTrain("number");
                                        coach = InputLogic.InputInt("c");
                                        seat = InputLogic.InputInt("s");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                try { RemoveProvider.RemoveReserve(InputLogic.FileReservationPath, InputLogic.FileTrainPath, seat, coach, train); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                isSuccess = false;
                                Console.WriteLine("Now enter information about new reserve:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputReserve();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Reserve was added!");
                                break;
                            case "show":
                                coach = 0;
                                seat = 0;
                                train = null;
                                string reserve = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        train = InputLogic.InputForTrain("number");
                                        coach = InputLogic.InputInt("c");
                                        seat = InputLogic.InputInt("s");
                                        reserve = PrintService.StringReserveBySeat(InputLogic.FileReservationPath, train, coach, seat).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(reserve);
                                break;
                            case "showbydate":
                                DateTime dateTime = new DateTime();
                                reserve = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        dateTime = InputLogic.InputDateTime();
                                        reserve = PrintService.StringReserveByDate(InputLogic.FileTrainPath, dateTime).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(reserve);
                                break;
                            case "end":
                                EntityMenu.HelpMenu();
                                break;
                            default:
                                Console.WriteLine("Wrong command!");
                                break;
                        }
                        break;
                    case "end":
                        stop = true;
                        Console.WriteLine("Tap any key on the keyboard, to stop program.");
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }
            }
        }
    }
}
