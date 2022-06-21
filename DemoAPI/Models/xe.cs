using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class xe : MoveModel
    {


        public int x { get; set; }
        public int y { get; set; }

        public xe(string id, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }
        public xe() { }
        //check buoc di
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