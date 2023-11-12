using System.Linq;
using Birdhouse.Common.Mathematics.Average.Interfaces;

namespace Birdhouse.Common.Mathematics.Average
{
    public class FloatAverageCalculator 
        : IAverageCalculator<float>
    {
        public FloatAverageCalculator(params float[] values)
        {
            _sum = values.Sum();
            _count = values.Length;
        }
        
        private float _sum = 0f;
        private int _count = 0;
        
        public float Add(float value)
        {
            _sum += value;
            _count++;

            return Current;
        }

        public float Current => _sum / _count;
    }
}