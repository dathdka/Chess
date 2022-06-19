using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class tot : MoveModel
    {
        public int curtop = 0;
        public int curleft = 0;
        public bool checkMove(MoveModel node)
        {
            if(node.top == curtop +70 && node.left == curleft) 
                return true;
            return false;
        }
    }
}