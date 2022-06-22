using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class phao : MoveModel
    {
        
        public phao(string id, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }
        public phao() { }
        //check buoc di
        public  MoveModel checkMove(MoveModel node, MoveModel[,] board)
        {
            MoveModel curnode = new phao();

            // chua toi uu, thay thanh foreach ?
            for(int i =0; i< 10;i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(node.id == board[i,j].id)
                    {
                        curnode = board[i, j];
                        break;
                    }
                }
            }

            if(isWithin(node.top) !=-1 && isWithin(node.left) != -1)
            {
                //di len
                if(curnode.curtop > isWithin(node.top) && curnode.curleft == isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.top) / 75);
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    node.canMove = true;
                    return node;
                }
                //sang phai
                if (curnode.curtop == isWithin(node.top) && curnode.curleft < isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left) / 75);
                    node.y = curnode.y + Math.Abs(node.step);
                    node.x = curnode.x;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    node.canMove = true;
                    return node;
                }
                 //di xuong  
                if (curnode.curtop < isWithin(node.top) && curnode.curleft == isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.top)) / 75;
                    node.y = curnode.y;
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    node.canMove = true;
                    return node;
                }
                //sang trai
                if (curnode.curtop == isWithin(node.top) && curnode.curleft > isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left)) / 75;
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    node.canMove = true;
                    return node;
                }
                else 
                {
                    node.canMove = false;
                    return node;
                }

            }
            return node;
        }
    }
}