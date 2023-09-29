using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_Spaceship.Model
{
    /// <summary>
    /// This class only contains a 2 dimentional string array called data.
    /// The array keeps track of data for countries, to calculate the population in 40 years.
    /// </summary>
    class Countries
    {
        internal string[,] data = new[,]
        {
            { "Nauru", "9540", "0,55"},
            { "Denmark", "5581503", "0,22" },
            { "Australia", "22751014", "1,07" },
            { "Latvia", "1986705", "-1,06" },
            { "Monaco", "37731", "0,12" },
            { "South Sudan", "12042910", "4,02" },
            { "Angola", "19625353", "2,78" }
        };
    }
}
