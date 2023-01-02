using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public enum AgeLimit
    {
        Kids,
        Pupils,
        U18,
        U21,
        Senior
    }

    public static class AgeLimitYears
    {
        public static int ToYears(AgeLimit ageLimit)
        {
            return limits[ageLimit];
        }
        private static Dictionary<AgeLimit, int> limits = new()
        {
            {AgeLimit.Kids, 7 },
            {AgeLimit.Pupils, 12 },
            {AgeLimit.U18, 18 },
            {AgeLimit.U21, 21 },
            {AgeLimit.Senior, 200 }
        };
    }
}
