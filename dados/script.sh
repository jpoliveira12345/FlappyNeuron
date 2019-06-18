#!/bin/bash
mv $1 NeuralFileOLD.txt
touch NeuralFile.txt
grep -oP '.*\s.*\s.*\s1' NeuralFileOLD.txt | shuf -n $2 NeuralFileOLD.txt > NeuralFile.txt
grep -oP '.*\s.*\s.*\s0' NeuralFileOLD.txt | shuf -n $2 NeuralFileOLD.txt >> NeuralFile.txt