
//=========================Utility.cs=====================================
using System;
using System.Collections.Generic;
using System.Text;

namespace VectorDistanceCalculator
{
    class Utility
    {
        //TO DO work out shortest distance logic

        public void CalcDistance(double[,] Name)
        {


            for (int i = 0; i < Name.GetLength(0)-1; i++)
            {

                for (int j = i+1; j < Name.GetLength(0); i++)
                {
                    double x = Name[i, 0];
                    double y = Name[i, 1];
                    double z = Name[i, 2];
                    double x2 = Name[j, 0];
                    double y2 = Name[j, 1];
                    double z2 = Name[j, 2];
                    double diffx = Math.Abs(x - x2);
                    double diffy = Math.Abs(y - y2);
                    double diffz = Math.Abs(z - z2);
                    double distance = Math.Sqrt((Math.Pow(diffx, 2) + Math.Pow(diffy, 2) + Math.Pow(diffz, 2)));



                    Console.Write($"\nPoint A: X:{x}, Y:{y}, Z:{z}\n Point B: X:{x2}, Y:{y2}, Z:{z2}\n");
                    Console.WriteLine($"Difference: X: {diffx}  Y: {diffy}  Z: {diffz}");
                    Console.WriteLine($"Distance Between Point A and Point B: {distance}");
                    Console.WriteLine($"The Shortest Distance is ");



                    break;

                }
            }

        }


    }

}
//==============================Program.cs==================================================
using System;

namespace VectorDistanceCalculator
{
    class Program
    {


        public static void Main(string[] args)
        {
            Utility util = new Utility();
            //creates a new random object
            Random ran = new Random();
            // creates a 2D array with 1000 rows and 3 columns. columns represent x, y, z respectively
            double[,] Points = new double[1000, 3];


            // fills array with random numbers from 1-1000
            for (int col = 0; col < Points.GetLength(0); col++)
            {
                for(int row = 0; row < Points.GetLength(1); row++)
                {
                    Points[col, row] = ran.Next(1, 1000);

                }
            }

            //Test tp print array to check population
            /*int rowLength = Points.GetLength(0);
            int colLength = Points.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", Points[i, j]));

                }

                Console.Write(Environment.NewLine + Environment.NewLine);
               Console.WriteLine();
            }*/
            util.CalcDistance(Points);






        }



    }

}
