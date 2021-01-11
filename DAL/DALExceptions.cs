using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NoSuchTypeOfCarriageException : Exception
    {
        public override string Message => "Here is no such type of coach!";
    }
    public class NoSuchTypeOfTrainException : Exception
    {
        public override string Message => "Here is no such type of train!";
    }
    public class NoSuchNumberOfCoachException : Exception
    {
        public override string Message => "Here is no such number of coach!";
    }
    public class ReservedSeatsInCoachException : Exception
    {
        public override string Message => "That coach contains a reserved seats!";
    }
    public class MaximumCoachNumberException : Exception
    {
        public override string Message => "Maximum coach number in train!";
    }
}
