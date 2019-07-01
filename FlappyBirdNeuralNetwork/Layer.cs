using System;
using System.Collections.Generic;
using System.Text;
namespace FlappyBirdNeuralNetwork
{
    class Layer
    {
        List<Neuron> neuroniosList;
        Layer previous = null;
        Layer next = null;
        List<float> output;

        public Layer(Layer anterior, int sizePrevious, int size)
        {
            neuroniosList = new List<Neuron>();
            output = new List<float>();
            this.previous = anterior;

            for (int i = 0; i < size; i++)
            {
                neuroniosList.Add(new Neuron( this, sizePrevious));
            }
        }

        public float getPeso(int neuronOriginIndex, int neuronDestinyIndex)
        {
            return this.neuroniosList[neuronDestinyIndex].getPeso(neuronOriginIndex);
        }

        public void changePeso(int neuronOriginIndex, int neuronDestinyIndex, float novoPeso)
        {
            this.neuroniosList[neuronDestinyIndex].setPeso(neuronOriginIndex, novoPeso);
        }

        public void setNext(Layer l)
        {
            this.next = l;
        }
        public void setPrevious(Layer l)
        {
            this.previous = l;
        }

        public void process(List<float> input)
        {
            this.output = new List<float>();
            for (int i = 0; i < neuroniosList.Count; i++)
            {
                this.output.Add(neuroniosList[i].process(input));
            }
        }

        public void backPropagationOculta(List<float> input, float taxaAprendizado, float desejado)
        {
            for (int i = 0; i < neuroniosList.Count; i++)
            {
                neuroniosList[i].backPropagationOculta(input, taxaAprendizado, desejado);
            }
        }

        public void backPropagationSaida(List<float> sinal, float taxaAprendizado, float desejado)
        {

            for (int i = 0; i < neuroniosList.Count; i++)
            {
                neuroniosList[i].backPropagationSaida(sinal, taxaAprendizado, desejado);
            }
        }

        public float getSomatorios(int index, float desejado)
        {
            float soma = 0;
            foreach (Neuron n in this.neuroniosList)
            {
                soma += n.getPeso(index) * n.getGradienteSaida(n.getThisPesos(), desejado);
            }
            return soma;
        }

        public Layer getPrevious()
        {
            return this.previous;
        }

        public Layer getNext()
        {
            return this.next;
        }

        public List<float> getOutput()
        {
            return output;
        }

        public List<Neuron> getNeuroniosList()
        {
            return neuroniosList;
        }

        public void getNeuronPesos()
        {
            foreach (Neuron neuron in neuroniosList)
            {
                neuron.getNeuronPesos();
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("L").Append("\n");
            for (int i = 0; i < (neuroniosList.Count) ; i++)
            {
                s.Append("\tN");
                s.Append(neuroniosList[i].ToString());
            }
            return s.ToString();
        }

    }
}
