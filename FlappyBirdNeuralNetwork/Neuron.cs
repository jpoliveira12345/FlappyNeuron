using System;
using System.Collections;
using System.Collections.Generic;

namespace FlappyBirdNeuralNetwork
{
    class Neuron
    {
        private float limiar;
        private List<float> pesosList;

        private Layer camada;

        public Neuron(float limiar, Layer camada){
            this.limiar = limiar;
            this.camada = camada;
            pesosList = new List<float>();
        }

        public float getPeso(int neuronIndex){
            return pesosList[neuronIndex];
        }
        private float fTransicao(float somaPonderada){

            return somaPonderada;
        }
    }
}