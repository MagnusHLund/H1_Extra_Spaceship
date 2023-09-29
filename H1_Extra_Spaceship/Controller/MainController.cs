using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_Spaceship.Controller
{
    /// <summary>
    /// This class is where the actual program runs
    /// </summary>
    internal class MainController
    {
        Model.Countries countries = new Model.Countries();
        View.View view = new View.View();

        /// <summary>
        /// This is the entry point for the class.
        /// It goes through each of the planets, in the array inside Model.Countries.data[] and calculates each countries population in 40 years.
        /// Each future population then gets stored in the int array calculated[].
        /// This data then gets output to the console, as well as the countries name.
        /// </summary>
        internal void Start()
        {
            // Stores calculated future populations
            int[] calculated = new int[countries.data.GetLength(0)];

            // Goes through each planet and calculates the future population through the Calculate() method
            for (byte i = 0; i < countries.data.GetLength(0); i++)
            {
                calculated[i] = Calculate(i);
            }

            view.Message("Total people in each countries space ship:");

            // Outputs the name of the country and the future population, in the console.
            for (byte i = 0; i < calculated.Length; i++)
            {
                view.Message($"{countries.data[i, 0]}:");
                view.Message($"{calculated[i]}\n");
            }
        }

        /// <summary>
        /// This method calculates the future population.
        /// It does so using the math formula for exponential growth.
        /// futurePopulation = currentPopulation(1 + growthRate)^40
        /// '40' represents the total years till the spaceships takes off. 
        /// 
        /// Math example:
        /// Population is currently 9540, with a growth rate of 0.55%
        /// the 0.55% gets divided with 100, which is 0.0055 and then we replace the first 0 with a 1, by addition.
        /// Now we got '9540(1.0055)^40'.
        /// The 1.0055 then gets exponentiated with 40 years, which is 1.245... 
        /// the currentPopulation '9540' then gets multiplied with the exponentiated growthRate, which results in the futurePopulation '11880'.
        /// 
        /// The parameter is used to determine which country that are being calculated.
        /// The country value is based on the for loop 'i' value, from the Start() method, where its called from.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private int Calculate(byte country)
        {
            // Gets the information from the Model.Countries.data[] and does some basic percentage math for the growth rate.
            int currentPopulation = int.Parse(countries.data[country, 1]);
            float growthRate = float.Parse(countries.data[country, 2]) / 100 + 1;

            // Changes the value of growthRate by exponentiating the growthRate with 40 years
            growthRate = (float)Math.Pow(growthRate, 40);

            // Multiplies the currentPopulation and multiplies it with the 40 years of growthRate, which becomes the futurePopulation that gets returned.
            int futurePopulation = (int)(currentPopulation * growthRate);
            return futurePopulation;
        }
    }
}
