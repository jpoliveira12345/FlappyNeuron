using System;
using System.Collections.Generic;
// using Neuron;
namespace FlappyBirdNeuralNetwork
{
    class Layer
    {
        List<Neuron> neuroniosList;
        Layer previous = null;
        Layer next = null;
        List<float> output;

        public Layer(Layer anterior, int size, Layer proxima, float limiar )
        {
            neuroniosList = new List<Neuron>();
            this.previous = anterior;
            this.next = proxima;
            for (int i = 0 ; i < size ; i++ )
                neuroniosList.Add( new Neuron(limiar) );

        }

        public Layer(int size, Layer proxima, float limiar)
        {
            neuroniosList = new List<Neuron>();
            this.next = proxima;
            for (int i = 0 ; i < size ; i++ )
                neuroniosList.Add( new Neuron(limiar) );
        }
        
        public Layer(Layer anterior, int size, float limiar )
        {
            neuroniosList = new List<Neuron>();
            this.previous = anterior;
            for (int i = 0 ; i < size ; i++ )
                neuroniosList.Add( new Neuron(limiar) );
        }

        public List<float> process( List<float> input ){
            for ( Neuron n in neuroniosList )
                Console.Write("dasdf");
                // n.addNeuron()
            return this.output;
        }

    }
}