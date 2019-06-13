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

        public Layer(int size, float limiar )
        {
            neuroniosList = new List<Neuron>();
            for (int i = 0 ; i < size ; i++ )
                neuroniosList.Add( new Neuron(limiar, this) );

        }

        public float getPeso( int neuronOriginIndex , int neuronDestinyIndex ){
            return this.neuroniosList[neuronDestinyIndex].getPeso(neuronOriginIndex);
        }

        public void changePeso( int neuronOriginIndex , int neuronDestinyIndex , float novoPeso){
            // this.neuroniosList[neuronDestinyIndex].getPeso(neuronOriginIndex);
        }

        public void setNext(Layer l){
            this.next = l;
        }
        public void setPrevious(Layer l){
            this.previous = l;
        }

        public void process(List<float> input){
            for(int i = 0; i < neuroniosList.Count ; i++){
                
            }
        }

        public List<float> getOutput(){
            return output;
        }

    }
}