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

        public Neuron(float limiar, Layer camada, int sizePrevious){
            this.limiar = limiar;
            this.camada = camada;
            pesosList = new List<float>();

            for(int i = 0; i < sizePrevious; i++){
                pesosList.Add(RandomNumber(1));
            }
        }



    public float RandomNumber(float max)  
    {  
        Random random = new Random(); 

        double rand = random.NextDouble() * max;

        return (float) rand;
    }    

        public float getPeso(int neuronIndex){
            return pesosList[neuronIndex];
        }

        public void setPeso(int neuronIndex, float novoPeso){
            pesosList[neuronIndex] = novoPeso;
        }

        public int getThisNeuronIndex(){
            int index = this.camada.getNeuroniosList().IndexOf(this);
            return index;
        }

        public float fSoma(List<float> input){
            float output = 0;
            for(int i = 0; i < pesosList.Count; i++){
                output += pesosList[i] * input[i];
            }
            return output;
        }

        public float process(List<float> input){
            double y = fSoma(input);
            y = fTransicao(y);
            return (float) y;
        }

        public float getGradienteOculta(List<float> input){
            
            double gradiente = fTransicaoDerivada(fSoma(input)) * getSaidaPropagation(); 

            return (float) gradiente;
        }

        public void backPropagationOculta(List<float> input, float taxaAprendizado){
            //Para neuronios da camada oculta
            for(int i = 0; i < pesosList.Count; i++){
                pesosList[i] += (-taxaAprendizado) * getGradienteOculta(input) * input[i];
            }
        }

        
        public float getErro(List<float> input, float desejado){
            
            //float erro = Desejado - Saida
            float erro = desejado - this.process(input);

            return erro;
        }
        

        public float getGradienteSaida(List<float> input, float desejado){
            double gradiente = (- getErro(input, desejado)) * fTransicaoDerivada(fSoma(input));
            
            return (float) gradiente;
        }

		public float getSaidaPropagation(){
			
			float saida = 0;
			

			saida = this.camada.getNext().getSomatorios(this.getThisNeuronIndex());

			return saida;
			

		}

        public void backPropagationSaida(List<float> input, float taxaAprendizado, float desejado){
            //Para neuronios da camada de saida
            for(int i = 0; i < pesosList.Count; i++){
                pesosList[i] += (-taxaAprendizado) * getGradienteSaida(input, desejado) * input[i];
            }


        }

        public double fTransicaoDerivada(float somaPonderada){
            var derivada = 1/(1 + Math.Pow(Math.E, somaPonderada));
            var y = (derivada * (1 - derivada));
            /* 
            if(y >= 0){
                return 1f;
            }else{
                return 0f;
            }
            */
            return y;
        }
        public double fTransicao(double somaPonderada){
            double y = 1/(1 + Math.Pow(Math.E, somaPonderada));
            /* 
            if(y >= 0){
                return 1f;
            }else{
                return 0f;
            }
            */

            return y;
        }

        public void getNeuronPesos(){
            foreach(float i in pesosList){
                Console.WriteLine("Index: " + getThisNeuronIndex());
                Console.WriteLine(i);
            }
        }
    }
}
