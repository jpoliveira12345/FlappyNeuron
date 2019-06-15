using System;
using System.Collections.Generic;
// using Neuron;
namespace FlappyBirdNeuralNetwork
{
    class Network
    {
        private float limiar;
        private float output;
        private Layer inputLayer;
        private Layer outputLayer;
        private List<Layer> layerList;
        private float taxaAprendizado;

        public Network(Layer inputLayer, Layer outputLayer, float limiar, int size)
        {
            layerList = new List<Layer>();
            Layer previousLayer = inputLayer;
            layerList.Add(inputLayer);
            Layer nextLayer;
            this.limiar = limiar;
            this.inputLayer = inputLayer;
            this.outputLayer = outputLayer;
            for (int i = 0; i < size; i++)
            {
                nextLayer = new Layer(size, limiar);
                previousLayer.setNext(nextLayer);
                nextLayer.setPrevious(previousLayer);
                layerList.Add(nextLayer);
                previousLayer = nextLayer;
            }
            previousLayer.setNext(outputLayer);
            outputLayer.setPrevious(previousLayer);
            layerList.Add(outputLayer);
        }
        public float getOutput(){
            return this.output;
        }

        public float getPeso(int layerIndex, int neuronOriginIndex, int neuronDestinyIndex)
        {
            return this.layerList[layerIndex].getPeso(neuronOriginIndex,neuronDestinyIndex);
        }

        public float process(List<float> input){
            foreach( Layer l in this.layerList ){
                l.process(input);
                input = l.getOutput();
            }

            return input[0];

        }


        public void backPropagationSaida(Layer layer, float taxaAprendizado, float desejado){

            layer.backPropagationSaida(taxaAprendizado, desejado);

        }

        public void backPropagationOculta(Layer layer, float taxaAprendizado){

            layer.backPropagationOculta(taxaAprendizado);
        }


        public void setTaxaAprendizado(float t){
            this.taxaAprendizado = t;
        }

        public void resultadoNetwork(){

        }

        public void aprendizadoNetwork(){

        }

    }
}
