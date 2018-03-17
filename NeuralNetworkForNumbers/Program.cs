namespace NeuralNetworkForNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            NeuralNetwork neuralNetwork = new NeuralNetwork();
            
            teacher.Teach(neuralNetwork, 100);
        }

//        static void Main(string[] args)
//        {
//            
//        }
    }
}