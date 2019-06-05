using System;
using System.Collections;
using System.Collections.Generic;
// using Neuron;
namespace FlappyBirdNeuralNetwork{
    class Program{
        static void Main(string[] args){

            List<Neuron> arr = new List<Neuron>();
            arr.Add(new Neuron((float) 1.5));
            arr.Add(new Neuron((float) 1.7));
            arr.Add(null);
            
            for(int i = 0 ; i < arr.Count ; i++)
                Console.WriteLine("a  " + arr[i]);
        }
    }
}
