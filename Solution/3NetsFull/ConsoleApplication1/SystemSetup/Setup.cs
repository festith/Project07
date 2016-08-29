
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.SystemSetup
{
    [Serializable]
   public class Setup
    {
        public List<float> results { get; set; }
        public List<int> betsCount { get; set; }

        //Net Setups:

        public int daysForFormPeriod { get; set; }
        public int monthForLevelPeriod { get; set; }
        public int monthForH2H { get; set; }
        public bool mergeStatistic { get; set; }
        public bool includeHomeH2H { get; set; }
        public int matchCountForDefaultValue { get; set; }
        
        //Simulation Setups:

        public float minValue { get; set; }
        public float maxValue { get; set; }
        public float minKf { get; set; }
        public float maxKf { get; set; }
        public float lampda { get; set; }
        public float kf { get; set; }

        public float finishResult { get; set; }

        
        public Setup()
        {
            results = new List<float>();
            betsCount = new List<int>();
            kf = 1f;
        }

        public void AddResult(float result, int bets)
        {
            results.Add(result);
            betsCount.Add(bets);
            finishResult = GetResult();
        }

        public float GetResult()
        {
            float result = 1f;
            foreach (var res in results)
            {
                result *= res;
            }
            return result;
        }

        public float GetMinResult()
        {
            return results.Min();
        }

        public float GetMinBetsCount()
        {
            return betsCount.Min();
        }

        public Setup Clone()
        {
            var clone = new Setup();

            //net:
            clone.daysForFormPeriod = daysForFormPeriod;
            clone.monthForLevelPeriod = monthForLevelPeriod;
            clone.monthForH2H = monthForH2H;
            clone.mergeStatistic = clone.mergeStatistic;
            clone.includeHomeH2H = includeHomeH2H;
            clone.matchCountForDefaultValue = matchCountForDefaultValue;

            //simulation:
            clone.minKf = minKf;
            clone.maxKf = maxKf;
            clone.minValue = minValue;
            clone.maxValue = maxValue;
            clone.lampda = lampda;

            return clone;
        }
    }
}
