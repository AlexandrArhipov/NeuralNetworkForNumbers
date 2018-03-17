using System;

namespace NeuralNetworkForNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] result = JpegEncoder.Encode(@"C:\Users\alexu\source\repos\NeuralNetworkForNumbers\NeuralNetworkForNumbers\TrainingSet\0\img_1.jpg", 28, 28);

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    Console.Write(String.Format("{0,4:0.0}", result[i,j] + " "));

                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}