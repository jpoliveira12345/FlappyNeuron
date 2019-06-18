using System;
using System.Collections.Generic;
// using Neuron;
namespace FlappyBirdNeuralNetwork
{
    class Network
    {
        private float limiar;
        private float output;
        private List<Layer> layerList;
        private float taxaAprendizado;

        public Network(float limiar)
        {
            layerList = new List<Layer>();
            this.limiar = limiar;
            
        }
        public float getOutput(){
            return this.output;
        }

        public float getPeso(int layerIndex, int neuronOriginIndex, int neuronDestinyIndex)
        {
            return this.layerList[layerIndex].getPeso(neuronOriginIndex,neuronDestinyIndex);
        }

        public float process(List<float> input){
            foreach(Layer l in layerList){
                l.process(input);
                input = l.getOutput();
            }

            return input[0];

        }


        public void backPropagationSaida(Layer layer, List<float> input, float taxaAprendizado){

            layer.backPropagationSaida(input, taxaAprendizado,input[3]);

        }

        public void backPropagationOculta(Layer layer, List<float> input, float taxaAprendizado){

            layer.backPropagationOculta(input, taxaAprendizado);
        }


        public void setTaxaAprendizado(float t){
            this.taxaAprendizado = t;
        }

        public void criaNetwork(){
            Layer Loculta = new Layer(null, null, 3, 1, 3);
            Layer Lsaida = new Layer(Loculta, null, 1, 1, 3);

            Loculta.setNext(Lsaida);

            this.layerList.Add(Loculta);
            this.layerList.Add(Lsaida);

        }

        public float resultadoNetwork(List<float> input){
            float resultado = this.process(input);

            return resultado;
        }

        public void aprendizadoNetwork(List<float> input, float taxaAprendizado){
            this.backPropagationSaida(layerList[1], input, taxaAprendizado);
            this.backPropagationOculta(layerList[0], input, taxaAprendizado);

        }

        public void getNeuronPesos(){
            foreach(Layer l in layerList){
                l.getNeuronPesos();
            }
        }
    }
}
