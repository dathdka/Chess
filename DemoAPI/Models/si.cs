using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class si : MoveModel
    {
        public int x { get; set; }
        public int y { get; set; }

        public si(string id, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }
        public si() { }

        public MoveModel checkMove(MoveModel node)
        {
            if (isWithin(node.top) != -1 && isWithin(node.left) != -1)
            {
                node.top = isWithin(node.top);
                node.left = isWithin(node.left);
                node.canMove = true;
            }
            return node;
        }
    }
}