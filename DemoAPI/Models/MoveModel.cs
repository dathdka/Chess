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
        public int curtop { get; set; }
        public int curleft { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public int step { get; set; }


        public bool canMove = false;

        public MoveModel() { }
        public MoveModel(int x , int y)
        {
            this.id = "0";
            this.top = 0;
            this.left = 0;
            this.visible = true;
            this.curtop = 0;
            this.curleft = 0;
            this.x = x;
            this.y = y;
            this.step = 0;
        }
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

        public MoveModel getId(MoveModel node, MoveModel[,] board)
        {
            phao phao = new phao();
            tuong tuong = new tuong();
            switch (node.id)
            {
                case "phaoden1":
                    return phao.checkMove(node, board);
                case "phaoden2":
                    return phao.checkMove(node, board);
                case "phaodo1":
                    return phao.checkMove(node, board);
                case "phaodo2":
                    return phao.checkMove(node, board);
                default:
                    node.canMove = false;
                    return node;

            }
        }
        
    }
}