using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileinput = Console.ReadLine();
            string filedata = Console.ReadLine();
            string fileoutput = Console.ReadLine();
            double[,] fileinput1 = ReadImageDataFromFile(fileinput);
            double[,] flieinput2 = ReadImageDataFromFile(filedata);
            double[,] table77 = new double[7, 7];
            table77[0, 0] = 0; table77[0, 1] = 160; table77[0, 2] = 64; table77[0, 3] = 16; table77[0, 4] = 0; table77[0, 5] = 0; table77[0, 6] = 160;
            table77[1, 0] = 32; table77[1, 1] = 64; table77[1, 2] = 0; table77[1, 3] = 128; table77[1, 4] = 64; table77[1, 5] = 32; table77[1, 6] = 64;
            table77[2, 0] = 160; table77[2, 1] = 192; table77[2, 2] = 32; table77[2, 3] = 16; table77[2, 4] = 0; table77[2, 5] = 160; table77[2, 6] = 192;
            table77[3, 0] = 16; table77[3, 1] = 128; table77[3, 2] = 0; table77[3, 3] = 64; table77[3, 4] = 96; table77[3, 5] = 16; table77[3, 6] = 128;
            table77[4, 0] = 0; table77[4, 1] = 32; table77[4, 2] = 64; table77[4, 3] = 128; table77[4, 4] = 192; table77[4, 5] = 0; table77[4, 6] = 32;
            table77[5, 0] = 0; table77[5, 1] = 160; table77[5, 2] = 64; table77[5, 3] = 16; table77[5, 4] = 0; table77[5, 5] = 0; table77[5, 6] = 160;
            table77[6, 0] = 32; table77[6, 1] = 64; table77[6, 2] = 0; table77[6, 3] = 128; table77[6, 4] = 64; table77[6, 5] = 32; table77[6, 6] = 64;

            double[,] outputimagedata = new double[7,7];
            int n = 0; int m = 2; int a = 2;
            double sum = 0;
            double[,] X = new double[3, 3];
            while (n <= a)
            {
                for (int j = m - 2; j <= m; j++)
                {
                    X[n, j] = table77[n, j] * flieinput2[n, j];
                    sum = sum + X[n, j];
                }
            }
        }

        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }

        static void WriteImageDataToFile(string imageDataFilePath,
                                 double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }

    }
}
