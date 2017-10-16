using System;

namespace GRLib
{
    public class Record
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavouriteColor { get; set; }
        public DateTime DOB { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}  {Gender} {FavouriteColor} {DOB}";
        }
    }
}
