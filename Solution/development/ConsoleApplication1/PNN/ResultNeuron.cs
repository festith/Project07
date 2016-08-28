using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilisticNeuralNetwork
{
    [Serializable]
    public class ResultNeuron
    {
        private float result;

        public void ResetNeuron()
        {
            result = 0;
        }

        public void AddResult(float value)
        {
            result += value;
        }

        public float GetResult()
        {
            return result;
        }
    }
}
