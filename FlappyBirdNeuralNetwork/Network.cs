using System;
using System.Collections.Generic;
using System.Text;
namespace FlappyBirdNeuralNetwork
{
    class Network
    {
        private List<Layer> layerList;
        private float taxaAprendizado;

        public Network()
        {
            this.layerList = new List<Layer>();
        }

        public float process(List<float> input)
        {
            foreach (Layer l in layerList)
            {
                l.process(input);
                input = l.getOutput();
            }
            return input[0];
        }

        public void backPropagationSaida(Layer layer, List<float> input, float taxaAprendizado)
        {
            layer.backPropagationSaida(input, taxaAprendizado, input[3]);
        }

        public void backPropagationOculta(Layer layer, List<float> input, float taxaAprendizado)
        {
            layer.backPropagationOculta(input, taxaAprendizado, input[3]);
        }

        public void criaNetwork()
        {
            Layer Loculta = new Layer(null, 3, 6);
            Layer Loculta2 = new Layer(Loculta, 6, 6);
            Layer Lsaida = new Layer(Loculta2, 6, 1);

            Loculta.setNext(Loculta2);
            Loculta2.setNext(Lsaida);

            this.layerList.Add(Loculta);
            this.layerList.Add(Loculta2);
            this.layerList.Add(Lsaida);

        }

        public float resultadoNetwork(List<float> input)
        {
            float resultado = this.process(input);

            return resultado;
        }

        public void aprendizadoNetwork(List<float> input, float taxaAprendizado)
        {
            layerList[0].process(input);
            layerList[1].process(layerList[0].getOutput());
            this.backPropagationSaida(layerList[2], layerList[1].getOutput(), taxaAprendizado);
            this.backPropagationOculta(layerList[1], layerList[0].getOutput(), taxaAprendizado);
            this.backPropagationOculta(layerList[0], input, taxaAprendizado);
        }

        public void getNeuronPesos()
        {
            foreach (Layer l in layerList)
            {
                l.getNeuronPesos();
            }
        }

        public void setLayer(Layer l)
        {
            this.layerList.Add(l);
        }
        public int getSize()
        {
            return this.layerList.Count;
        }
        public float getPeso(int layerIndex, int neuronOriginIndex, int neuronDestinyIndex)
        {
            return this.layerList[layerIndex].getPeso(neuronOriginIndex, neuronDestinyIndex);
        }
        public void setTaxaAprendizado(float t)
        {
            this.taxaAprendizado = t;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Layer l in layerList)
            {
                s.Append(l.ToString());
            }
            return s.ToString();
        }

        public void FromString(string str)
        {
            string[] layers = str.Split("L\n");
            foreach (string s in layers)
            {
                
            }
        }

    }
}
