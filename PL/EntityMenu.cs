using System;

namespace PL
{
    public static class EntityMenu
    {
        public static void HelpMenu() => Console.WriteLine("In that program you can do such action as:\n" +
            "\t train - to add, remove or recive some information about trains;\n" +
            "\t reserve - to add, change, remove or recive information about reservations\n" +
            "\t end - to end work.");
        public static void TrainMenu() => Console.WriteLine("TRAINS commands:\n" +
            "\tadd - to add new train;\n\taddcoach - to add coach in train;\n" +
            "\tremove - to remove any train;\n\tremovecoach - to remove coach from train;\n" +
            "\tshowall - to show all trains with main information about them;\n" +
            "\tshowcertain - to show information about certain train;\n\tshowcoaches - to show information about every coach in certain train;\n" +
            "\tsearch - to find train by its number\n\tend - to go to the other command group.\n Choose one of them");
        //public static void CoachMenu() => Console.WriteLine("COACHES commands:\n" +
        //    "\tadd - to chose any coach and add it to the certain train;\n\tremove - to remove coach in certain train by number of coach;\n" +
        //    "Choose one of them");
        public static void ReservationMenu() => Console.WriteLine("RESERVATION commands:\n" +
            "\treserve - to reserve any seat;\n\tremove - to remove reservation; \n\tchange - to change reservation;\n" +
            "\tshow - to show information about certain reservation;\n\tshowbydate - to show information about all reservations in certain date;\n" +
            "\tend - to go to the other command group.\n Choose one of them");
    }
}
