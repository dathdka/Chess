using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class MoveModel
    {
        public string id { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public bool visible { get; set; }

        public bool canMove = false;

        public int isWithin(int value)
        {
            int step = value / 75;
            int isNegative = value > 0 ? 1 : -1;
            if (Math.Abs(value) > Math.Abs(step) * 75 + 55)
                return 75 * (step + 1 * isNegative);
            else if (Math.Abs(value) <= Math.Abs(step) * 75 + 20)
                return 75 * step;
            return -1;
        }
    }
}