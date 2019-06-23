using System;
using System.Collections.Generic;
namespace FlappyBirdNeuralNetwork
{
    class Network
    {
        private float limiar;
        private List<Layer> layerList;
        private float taxaAprendizado;

        public Network(float limiar)
        {
            layerList = new List<Layer>();
            this.limiar = limiar;
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


        public void backPropagationSaida(Layer layer, List<float> input,float taxaAprendizado){
            layer.backPropagationSaida(input, taxaAprendizado,input[3]);
        }

        public void backPropagationOculta(Layer layer, List<float> input, float taxaAprendizado){
            layer.backPropagationOculta(input, taxaAprendizado, input[3]);
        }


        public void setTaxaAprendizado(float t){
            this.taxaAprendizado = t;
        }

        public void criaNetwork(){
            Layer Loculta = new Layer(null, null, 6, 1, 3);
            Layer Loculta2 = new Layer(Loculta, null, 6, 1, 6);
            Layer Lsaida = new Layer(Loculta2, null, 1, 1, 6);

            Loculta.setNext(Loculta2);
            Loculta2.setNext(Lsaida);

            this.layerList.Add(Loculta);
            this.layerList.Add(Loculta2);
            this.layerList.Add(Lsaida);

        }

        public float resultadoNetwork(List<float> input){
            float resultado = this.process(input);

            return resultado;
        }

        public void aprendizadoNetwork(List<float> input, float taxaAprendizado){
            layerList[0].process(input);
            layerList[1].process(layerList[0].getOutput());
            this.backPropagationSaida(layerList[2], layerList[1].getOutput(), taxaAprendizado);
            this.backPropagationOculta(layerList[1], layerList[0].getOutput(), taxaAprendizado);
            this.backPropagationOculta(layerList[0], input, taxaAprendizado);

        }

        public void getNeuronPesos(){
            foreach(Layer l in layerList){
                l.getNeuronPesos();
            }
        }

        public void setLayer(Layer l){
            this.layerList.Add(l);
        }
    }
}
