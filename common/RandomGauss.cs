using System;

namespace Doo
{
    public class RandomEx : Random
    {
        public RandomEx(int seed)
            : base(seed)
        {
        }

        // Return a random number from a Gauss distribution using the Box-Muller transformation.
        public double NextGauss(double mean, double stdDev, bool ensureUnitaryRange)
        {
            double d1 = this.NextDouble();
            double d2 = this.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(d1)) * Math.Sin(2.0 * Math.PI * d2);
            double d = mean + stdDev * randStdNormal;
            // If a range between 0-1 is requested, roughly cut the distribution,
            // naturally the resulting distribution will be asymmetric.
            if (ensureUnitaryRange)
                d = Math.Min(Math.Max(d, 0), 1);
            return d;
        }
    }
}
