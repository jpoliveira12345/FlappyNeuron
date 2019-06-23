using System;
using System.Collections;
using System.Collections.Generic;

namespace FlappyBirdNeuralNetwork{
    class Program{
        static void Main(string[] args){          
            
            Neuron n = new Neuron(1 , null, 1);  
            
            List<float> input = new List<float>();
            input.Add(n.RandomNumber(1));//1.344f);
            input.Add(n.RandomNumber(1));//2.556f);
            input.Add(n.RandomNumber(1));//3.266f);
            input.Add(1f);

            float taxaAprendizado = 0.5f;

            Network network = new Network(1);
            network.criaNetwork();
            network.aprendizadoNetwork(input, taxaAprendizado);
            Console.WriteLine("First: \n" + network.resultadoNetwork(input));
            //network.getNeuronPesos();
            for(int i = 0; i < 100; i++){
            network.aprendizadoNetwork(input, taxaAprendizado);
            }
            Console.WriteLine("\n Second: \n" + network.resultadoNetwork(input));
            //network.getNeuronPesos();
            for(int i = 0; i < 100; i++){
            network.aprendizadoNetwork(input, taxaAprendizado);
            }
            Console.WriteLine("\n Third: \n" + network.resultadoNetwork(input));
            
        }
    }
}
