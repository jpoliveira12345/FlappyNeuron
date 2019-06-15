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

        public void setPeso(int neuronIndex, float novoPeso){
            pesosList[neuronIndex] = novoPeso;
        }

        public int getThisNeuronIndex(){
            int index = this.camada.getNeuroniosList().IndexOf(this);
            return index;
        }

        private float getSignal(int index){
            return this.camada.getPrevious().getPeso(this.getThisNeuronIndex(), index);
        }

        public float fSoma(){
            float output = 0;
            for(int i = 0; i < pesosList.Count; i++){
                output += pesosList[i] * getSignal(i);
            }
            return output;
        }

        public float process(){
            float y = fSoma();
            y = fTransicao(y);

            return y;
        }

        public float getGradienteOculta(){
                
            float gradiente = fTransicaoDerivada(fSoma()) * getSaidaPropagation(); 

            return gradiente;
        }

        public void backPropagationOculta(float taxaAprendizado){
            //Para neuronios da camada oculta
            for(int i = 0; i < pesosList.Count; i++){
                pesosList[i] = (-taxaAprendizado) * getGradienteOculta() * getSignal(i);
            }
        }

        
        public float getErro(float desejado){
            
            //float erro = Desejado - Saida
            float erro = desejado - this.process();

            return erro;
        }
        

        public float getGradienteSaida(float desejado){
            float gradiente = (- getErro(desejado)) * fTransicaoDerivada(fSoma());
            
            return gradiente;
        }

		public float getSaidaPropagation(){
			
			float saida = 0;
			

			saida = this.camada.getNext().getSomatorios(this.getThisNeuronIndex());

			return saida;
			

		}

        public void backPropagationSaida(float taxaAprendizado, float desejado){
            //Para neuronios da camada de saida
            for(int i = 0; i < pesosList.Count; i++){
                pesosList[i] = (-taxaAprendizado) * getGradienteSaida(desejado) * getSignal(i);
            }


        }

        public float fTransicaoDerivada(float somaPonderada){
            
            return trataTransicao(derivadaSigmoide(somaPonderada));
        }
        public float fTransicao(float somaPonderada){

            return trataTransicao(fSigmoide(somaPonderada));
        }

        public float fSigmoide(float x){
            double y = 1/(1 + Math.Pow(Math.E, x));
            return (float) y;
        }

        public float derivadaSigmoide(float x){
            double y = fSigmoide(x) * (1 - fSigmoide(x));
            return (float) y;
        }

        public float trataTransicao(float x){
            double y = Math.Round(x);
            return (float) y;
        }
    }
}
