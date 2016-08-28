using System;

namespace ProbabilisticNeuralNetwork
{
    [Serializable]
    public class Signal
    {
        public float[] Values { get; set; }

        public Signal(float[] values)
        {
            Values = Normalize(values);
        }

        public Signal()
        {

        }

        private float[] Normalize(float[] values)
        {
            var normalizedValues = new float[values.Length];
            float lenght = 0;
            foreach (var value in values)
            {
                lenght += value * value;
            }

            lenght = (float)Math.Sqrt(lenght);

            if (lenght == 0)
            {
                return values;
            }

            for (int i = 0; i < values.Length; i++)
            {
                normalizedValues[i] = values[i] / lenght;
            }
            
            return normalizedValues;
        }
    }
}
