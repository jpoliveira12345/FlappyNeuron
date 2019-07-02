using System;
using System.Collections;
using System.Collections.Generic;

namespace FlappyBirdNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando a camada de entrada
            Neuron n = new Neuron(null, 1);
            List<float> input = new List<float>();
            input.Add(n.RandomNumber(1));//1.344f);
            input.Add(n.RandomNumber(1));//2.556f);
            input.Add(n.RandomNumber(1));//3.266f);
            input.Add(1f);

            // Criando a rede
            float taxaAprendizado = 0.5f;
            Network network = new Network(3,3,6,1);
            network.aprendizadoNetwork(input, taxaAprendizado);
            new Network(network.ToString());



            // network.criaNetwork();

            // Console.WriteLine("First: \n" + network.resultadoNetwork(input));
            //network.getNeuronPesos();

            // for (int i = 0; i < 100; i++)
            // {
            //     network.aprendizadoNetwork(input, taxaAprendizado);
            // }
            // Console.WriteLine("\n Second: \n" + network.resultadoNetwork(input));
            // //network.getNeuronPesos();
            // for (int i = 0; i < 100; i++)
            // {
            //     network.aprendizadoNetwork(input, taxaAprendizado);
            // }
            // Console.WriteLine("\n Third: \n" + network.resultadoNetwork(input));


            // new Network(network.ToString());
            // Console.WriteLine(network.ToString());
        }
    }
}
