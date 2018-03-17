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
            float totalCount = 0, correctCount = 0;
            NeuralNetwork neuralNetwork = NeuralNetwork.fromXml();
            
            string[][] paths = new string[10][];

            for (int i = 0; i < 10; i++) 
                paths[i] = Directory.GetFiles(PathToTestingSet + i);

            for (int i = 0; i < 10; i++)
            {
                foreach (var path in paths[i])
                {
                    totalCount++;
                    int answer = neuralNetwork.getAnswer(JpegEncoder.Encode(path, Neuron.row, Neuron.column));

                    if (answer == i)
                    {
                        Console.WriteLine($"{i} - {path}: correct");
                        correctCount++;
                    }
                    else
                        Console.WriteLine($"{i} - {path}: incorrect; answer = {answer}");
                }
            }
            Console.WriteLine($"Correctness: {correctCount / totalCount * 100}%");
            Console.ReadLine();
        }
    }
}