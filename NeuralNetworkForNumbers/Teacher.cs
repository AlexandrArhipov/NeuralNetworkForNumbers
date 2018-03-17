using System;
using System.Collections.Generic;
using System.IO;

namespace NeuralNetworkForNumbers
{
    public class Teacher
    {
        private List<int> _numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } ;
        
        private const string PathToTrainingSet = @"../../TrainingSet/";
        
        public Teacher()
        {
            
        }

        public void Teach(NeuralNetwork neuralNetwork, int maxNumberOfIterations)
        {
            string[][] paths = new string[10][];

            for (int i = 0; i < 10; i++) 
                paths[i] = Directory.GetFiles(PathToTrainingSet + i);

            for (int iter = 0; iter < maxNumberOfIterations; iter++)
            {
                if (_numbers.Count == 0)
                    break;
                
                _numbers.Shuffle();
                foreach (var number in _numbers)
                {
                    if (iter >= paths[number].Length)
                    {
                        _numbers.Remove(number);
                        continue;
                    }

                    neuralNetwork.study(JpegEncoder.Encode(paths[number][iter], Neuron.row, Neuron.column), number);
                }
            }
            
            neuralNetwork.saveLocal();
        }
        
        
    }
}

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list) {
        int n = list.Count;
        Random rnd = new Random();
        while (n > 1) {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}