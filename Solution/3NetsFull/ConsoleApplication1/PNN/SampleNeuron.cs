using System;
using System.Dynamic;

namespace ProbabilisticNeuralNetwork
{
     [Serializable]
    public class SampleNeuron
    {
         public Signal signal { get; set; }

         public int resultNeuronIndex { get; set; }
        
         public SampleNeuron(Signal signal, int resultNeuronIndex)
        {
            this.signal = signal;
            this.resultNeuronIndex = resultNeuronIndex;
        }

         public SampleNeuron()
         {
             
         }

        public void Respond(Signal inputSignal, float lampda, ResultNeuron[] resultNeurons)
        {
            float sum = 0;


            //for (int i = 0; i < inputSignal.Values.Length; i++)
            //{
            //    sum += inputSignal.Values[i] * signal.Values[i];
            //}
            //sum -= 1;
            //var result = (float)Math.Exp(sum / (lampda * lampda));



            for (int i = 0; i < inputSignal.Values.Length; i++)
            {
                sum += (inputSignal.Values[i] - signal.Values[i]) * (inputSignal.Values[i] - signal.Values[i]);
            }
            var result = (float)Math.Exp(-sum / (2 * lampda * lampda));

            resultNeurons[resultNeuronIndex].AddResult(result);
        }
    }
}
