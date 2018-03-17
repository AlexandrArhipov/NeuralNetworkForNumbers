using System;
using System.IO;
using System.Windows.Forms;

namespace NeuralNetworkForNumbers
{
    public class Program
    {
//        static void Main(string[] args)
//        {
//            Teacher teacher = new Teacher();
//            NeuralNetwork neuralNetwork = new NeuralNetwork();
//            
//            teacher.Teach(neuralNetwork, 100);
//        }

        private const string PathToTestingSet = @"../../TestSet/";
        
        static void Main(string[] args)
        {
            NeuralNetwork neuralNetwork = NeuralNetwork.fromXml();
            
            string[][] paths = new string[10][];

            for (int i = 0; i < 10; i++) 
                paths[i] = Directory.GetFiles(PathToTestingSet + i);

            for (int i = 0; i < 10; i++)
            {
                foreach (var path in paths[i])
                {
                    int answer = neuralNetwork.getAnswer(JpegEncoder.Encode(path, Neuron.row, Neuron.column));

                    Console.WriteLine(i + ": " + (answer == i ? "correct" : "incorrect"));
                }
            }
        }
    }
}