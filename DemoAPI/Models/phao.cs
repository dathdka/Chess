using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class phao : MoveModel
    {
        public int curtop = 0;
        public int curleft = 0;
        // check range
        public int isWithin(int value)
        {
            int step = value / 75;
            int isNegative = value > 0 ? 1 : -1;
            if (Math.Abs(value) > Math.Abs(step) * 75 + 55)
                return 75 * (step + 1*isNegative); 
            else if(Math.Abs( value) <= Math.Abs( step) * 75 + 20)
                return 75 * step;
            return -1;
        }

        //check buoc di
        public MoveModel checkMove(MoveModel node)
        {
            
            if(isWithin(node.top) !=-1 && isWithin(node.left) != -1)
            {
                node.top = isWithin(node.top);
                node.left = isWithin(node.left);
                node.canMove = true;
                return node;
            }
            node.canMove = false;
            return node;
        }
    }
}