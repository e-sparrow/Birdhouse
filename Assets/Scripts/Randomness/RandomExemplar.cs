using UnityEngine;
using Random = System.Random;

namespace ESparrow.Utils.Randomness
{
    public class RandomExemplar
    {
        public static readonly RandomExemplar main;

        private Random _random;

        private readonly int _seed;

        public RandomExemplar()
        {
            _seed = new Random().Next();
            _random = new Random(_seed);
        }

        public RandomExemplar(int seed)
        {
            _seed = seed;
            _random = new Random(_seed);
        }

        public void Reset()
        {
            _random = new Random(_seed);
        }

        public int NextInt()
        {
            return _random.Next();
        }

        public int NextInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }

        public double NextDouble(double min, double max)
        {
            return min + NextDouble() * (max - min);
        }

        public float NextFloat()
        {
            return (float) NextDouble();
        }

        public float NextFloat(float min, float max)
        {
            return (float) NextDouble(min, max);
        }

        public Vector2 NextVector2InUnit()
        {
            return new Vector2(NextFloat(), NextFloat());
        }

        public Vector3 NextVector3InUnit()
        {
            return new Vector3(NextFloat(), NextFloat(), NextFloat());
        }

        public Vector2 NextVector2InRect(Rect rect)
        {
            var randomX = NextFloat(rect.min.x, rect.max.x);
            var randomY = NextFloat(rect.min.y, rect.max.y);

            return new Vector2(randomX, randomY);
        }

        public Vector3 NextVector3InBounds(Bounds bounds)
        {
            var randomX = NextFloat(bounds.min.x, bounds.max.x);
            var randomY = NextFloat(bounds.min.y, bounds.max.y);
            var randomZ = NextFloat(bounds.min.z, bounds.max.z);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
}
