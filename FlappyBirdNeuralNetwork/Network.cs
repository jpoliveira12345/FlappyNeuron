using System;
using System.Collections.Generic;
// using Neuron;
namespace FlappyBirdNeuralNetwork{
    class Network{
        private float limiar;
        private float output;
        private List<float>  weightVector = new List<float>();
        private List<float>  inputLayer = new List<float>();
        float transferencyFunction(float input){
            return input;
        }
    }
}