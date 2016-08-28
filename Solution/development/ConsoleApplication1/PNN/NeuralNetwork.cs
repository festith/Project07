using System;
using System.Collections.Generic;


namespace ProbabilisticNeuralNetwork
{
    [Serializable]
    public class NeuralNetwork
    {
        public List<SampleNeuron> sampleNeuron { get; set; }

        public int answersCount { get; set; }

        public NeuralNetwork(int answersCount)
        {
            sampleNeuron = new List<SampleNeuron>();
            this.answersCount = answersCount;
        }

        public NeuralNetwork()
        {

        }

        public void ResetNetwork()
        {
            sampleNeuron.Clear();
        }

        public void AddSample(Signal signal, int resultIndex)
        {
            sampleNeuron.Add(new SampleNeuron(signal, resultIndex));
        }

        public float[] ProcessSignal(Signal signal, float lamda)
        {
            var resultNeurons = CreateResultNeurons();
            CalculateResult(signal, lamda, resultNeurons);
            return GetNormalizedResult(resultNeurons);
        }

        private ResultNeuron[] CreateResultNeurons()
        {
            var resultNeurons = new ResultNeuron[answersCount];
            for (int i = 0; i < answersCount; i++)
            {
                resultNeurons[i] = new ResultNeuron();
            }
            return resultNeurons;
        }

        private float[] GetNormalizedResult(ResultNeuron[] resultNeurons)
        {
            float sum = 0;
            foreach (var res in resultNeurons)
            {
                sum += res.GetResult();
            }
            var result = new float[resultNeurons.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = resultNeurons[i].GetResult() / sum;
            }
            return result;
        }

        private void CalculateResult(Signal signal, float lamda, ResultNeuron[] resultNeurons)
        {
            foreach (var neuron in sampleNeuron)
            {
                neuron.Respond(signal, lamda, resultNeurons);
            }
        }


    }
}
