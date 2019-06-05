using System;
using System.Collections;
using System.Collections.Generic;

namespace FlappyBirdNeuralNetwork
{
    class Neuron
    {
        private float limiar;
        private List<float> pesosList;
        private List<Neuron> neuronAnteriorList;

        public Neuron(float limiar){
            this.limiar = limiar;
            pesosList = new List<float>();
            neuronAnteriorList = new List<Neuron>();
        }

        public void addNeuron ( Neuron neuronioAnterior , float peso ) {
            /*
            Na camada de entrada, adicionar apenas o pesso e o neurônio nulo
             */
            neuronAnteriorList.Add(neuronioAnterior);
            pesosList.Add(peso);
        }

        public void mudarPeso( Neuron n , float novoPeso ){
            pesosList[neuronAnteriorList.IndexOf(n)] = novoPeso;
        }

        public float getOutput()
        {
            float output = 0;
            for(int i = 0; i < neuronAnteriorList.Count ; i++)
                output += neuronAnteriorList[i].getOutput() * pesosList[i];
            
            return fTransicao(output);
        }

        private float fTransicao(float somaPonderada){

            return somaPonderada;
        }
    }
}