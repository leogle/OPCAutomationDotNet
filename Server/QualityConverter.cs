using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNL.Automation.Server
{
    public class QualityConverter
    {
        public static TagQuality GetQuality(int quality)
        {
            switch (quality)
            {
                case 1:
                    return TagQuality.Good;
                case 2:
                    return TagQuality.Uncertain;
                case 3:
                    return TagQuality.Bad;
                default:
                    return TagQuality.Uncertain;
            }
        }
    }
}
