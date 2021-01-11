using System;

namespace BLL
{
    public class NoTrainException:Exception
    {
        public override string Message => "No such train in database!";
    }
    public class NoReservationWithSuchDateException : Exception
    {
        public override string Message => "No reservations with such date!";
    }
    public class NoReservationException : Exception
    {
        public override string Message => "No such reservation in database!";
    }
    public class OccupationException : Exception
    {
        public override string Message => "That seat is occupated!";
    }

    public class NotPassedValueException : Exception
    {
        public override string Message => "Vallue do not pass to format!";
    }
}
