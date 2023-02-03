using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            int[] listOfNumbers, listOfFrequency;
            int numbersOfData;
            float width, range, lowest, highest;
            int i;
            float cInterval;

            // Enter width
            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());

            // Enter number of data
            Console.Write("Enter numbers of data: ");
            numbersOfData = Convert.ToInt32(Console.ReadLine());

            listOfNumbers = new int[numbersOfData];

            // Get values of data
            for (i = 0; i < numbersOfData; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                listOfNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Clearscreen
            Console.Clear();

            // Display data in ascending order
            for (i = 0; i < listOfNumbers.Length; i++)
            {
                Array.Sort(listOfNumbers);
                Console.Write($" {listOfNumbers[i]}");
            }

            // Get highest and lowest value of the data
            highest = listOfNumbers.Max();
            lowest = listOfNumbers.Min();

            // lowest number class limit variables
            float limitLowest = lowest, frequencyLowest = lowest;


            // range and class interval formula
            range = highest - lowest;
            cInterval = range / width;

            // display given
            Console.WriteLine($"\nThe highest number is {highest}");
            Console.WriteLine($"The lowest number is {lowest}");
            Console.WriteLine($"The width is {width}");
            Console.WriteLine($"The range is {range}");

            // Table --------------------------------

            // class interval if the answer is not whole number
            if (cInterval % 2 != 0)
            {
                int roundedUp = (int)Math.Ceiling(cInterval);
                cInterval = roundedUp;
            }

            bool anotherRow = true;
            float newLowest;

            // MIDPOINT
            int midpointNum = Convert.ToInt32(width);
            float[] midpoint;
            midpoint = new float[midpointNum];

            // F(x) formula
            listOfFrequency = new int[midpointNum];
            float fx, tmpFx = 0;
            //float[] fx;

            // cumulative frequency
            int cumulativeFrequency = numbersOfData;

            // meanmdianmdoe
            double mean = 0, tmpMean = 0; // median = 0, mcLower, mcCF, mcFreq, mode = 0, modalLc, modalFreq, fmNegative, fmPositive;

            Console.WriteLine($"The class interval is {cInterval}");

            // class interval

            for (i = 0; i < midpointNum; i++)
            {
                Console.WriteLine($"\nClass Interval {i + 1}: {lowest} - {lowest + (cInterval - 1)}");
                Console.WriteLine($"Class limit {i + 1}: {lowest - 0.5} - {lowest + ((cInterval - 1) + 0.5)}");
                Console.Write($"Enter frequency {i + 1}: ");
                listOfFrequency[i] = Convert.ToInt32(Console.ReadLine());

                lowest += cInterval - 1;
                newLowest = lowest;
                midpoint[i] = ((lowest - cInterval + 1) + newLowest) / 2;
                lowest++;

                Console.WriteLine($"Midpoint {i + 1}: {midpoint[i]}");

                fx = listOfFrequency[i] * midpoint[i];

                Console.WriteLine($"F(x): {fx}");

                tmpFx += (listOfFrequency[i]) * midpoint[i];
                // Subtract cf to new listOfFREQUNECY
                Console.WriteLine($"Cumulative Frequency {i + 1}: {cumulativeFrequency}");
                cumulativeFrequency -= listOfFrequency[i];
            }

            // ask another row
            int choice;

            while (anotherRow)
            {

                Console.WriteLine("\nDo you want to add another row?\nPress 1 if yes, press 0 if no.");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    for (i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"\nClass Interval {width + 1}: {lowest} - {lowest + (cInterval - 1)}");
                        Console.WriteLine($"Class limit {width + 1}: {lowest - 0.5} - {lowest + ((cInterval - 1) + 0.5)}");
                        Console.Write($"\nEnter frequency {width + 1}: ");
                        listOfFrequency[i] = Convert.ToInt32(Console.ReadLine());

                        lowest += cInterval - 1;
                        newLowest = lowest;
                        midpoint[i] = ((lowest - cInterval + 1) + newLowest) / 2;
                        lowest++;

                        Console.WriteLine($"Midpoint {width + 1}: {midpoint[i]}");
                        Console.WriteLine($"F(x): {listOfFrequency[i] * midpoint[i]}");

                        // Subtract cf to new listOfFREQUNECY
                        Console.WriteLine($"Cumulative Frequency {i + 1}: {cumulativeFrequency}");
                        cumulativeFrequency -= listOfFrequency[i];
                    }
                }
                else
                {
                    anotherRow = false;
                }
            }


            // median class
            GetMedianClass(numbersOfData, listOfFrequency);

            // mean

            //tmpMean += fx[i];
            tmpMean += tmpFx;
            mean = tmpMean / numbersOfData;

            Console.Write($"\nMean is: {mean}\n");

            // median
            GetMedian(Convert.ToInt32(cInterval), numbersOfData);

            // mode
            GetMode(Convert.ToInt32(cInterval));

            Console.ReadKey();


        }

        static void GetMedianClass(int numbersOfData, int[] listOfFrequency)
        {
            float medianClass = numbersOfData / 2;
            float modalClass = listOfFrequency.Max();
            Console.WriteLine($"\nMedian Class: {medianClass}");

            Console.Write("Enter median class in table: ");
            medianClass = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Modal class: {modalClass}");
        }

        static void GetMedian(int roundedUp, float numbersOfData)
        {

            Console.Write("Enter lower class limit of median class: ");
            double mcLower = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"N: {numbersOfData}");
            Console.Write("Enter cumulative frequency before the median class: ");
            double mcCF = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter frequency of the median class: ");
            double mcFreq = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Class size: {roundedUp}");

            double median = mcLower + (((numbersOfData / 2) - mcCF) / mcFreq) * roundedUp;
            Console.Write($"Median is: {median}");
        }

        static void GetMode(int roundedUp)
        {
            Console.Write("\nEnter lower class limit of modal class: ");
            double modalLc = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter frequency of the modal class: ");
            double modalFreq = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter frequency before the modal class: ");
            double fmNegative = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter frequency after the modal class: ");
            double fmPositive = Convert.ToDouble(Console.ReadLine());

            double mode = modalLc + ((modalFreq - fmNegative) / ((modalFreq - fmNegative) + (modalFreq - fmPositive))) * roundedUp;
            Console.Write($"Mode is: {mode}");

        }
    }
}