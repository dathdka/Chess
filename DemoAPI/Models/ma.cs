using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class ma : MoveModel
    {

        public ma(string id, int x, int y, bool isRed)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.isRed = isRed;
        }
        public ma() { }
        //check buoc di
        public MoveModel checkMove(MoveModel node, MoveModel[,] board)
        {
            MoveModel curnode = new ma();

            // chua toi uu, thay thanh foreach ?
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (node.id == board[i, j].id)
                    {
                        curnode = board[i, j];
                        break;
                    }
                }
            }

            if (isWithin(node.top) != -1 && isWithin(node.left) != -1)
            {
                //xuong phai
                if (isWithin(node.top) - curnode.curtop == 150 && isWithin(node.left) - curnode.curleft == 75)
                {
                    node.x = curnode.x + 2;
                    node.y = curnode.y + 1;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x + 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                       board[curnode.x, curnode.y + 1].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }
                    
                    //check chan
                    node.canMove = true;
                    return node;
                }

                //phai xuong
                if (isWithin(node.top) - curnode.curtop == 75 && isWithin(node.left) - curnode.curleft == 150)
                {
                    node.x = curnode.x + 1;
                    node.y = curnode.y + 2;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x + 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                       board[curnode.x, curnode.y + 1].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                //xuong trai
                if (isWithin(node.top) - curnode.curtop == 150 && isWithin(node.left) - curnode.curleft == -75)
                {
                    node.x = curnode.x + 2;
                    node.y = curnode.y - 1;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x, curnode.y - 1].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x + 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                //trai len
                if (isWithin(node.top) - curnode.curtop == -75 && isWithin(node.left) - curnode.curleft == -150)
                {
                    node.x = curnode.x - 1;
                    node.y = curnode.y - 2;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x - 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                       board[curnode.x, curnode.y - 1].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }


                //len trai
                if (isWithin(node.top) - curnode.curtop == -150 && isWithin(node.left) - curnode.curleft == -75)
                {
                    node.x = curnode.x - 2;
                    node.y = curnode.y - 1;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x , curnode.y - 1].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x -1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                //len phai
                if (isWithin(node.top) - curnode.curtop == -150 && isWithin(node.left) - curnode.curleft == 75)
                {
                    node.x = curnode.x - 2;
                    node.y = curnode.y + 1;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x, curnode.y +1].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                       board[curnode.x -1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                //phai len
                if (isWithin(node.top) - curnode.curtop == -75 && isWithin(node.left) - curnode.curleft == 150)
                {
                    node.x = curnode.x - 1;
                    node.y = curnode.y + 2;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left); 
                    if (board[curnode.x, curnode.y + 1].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x - 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                //trai xuong
                if (isWithin(node.top) - curnode.curtop == 75 && isWithin(node.left) - curnode.curleft == -150)
                {
                    node.x = curnode.x + 1;
                    node.y = curnode.y - 2;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[curnode.x, curnode.y - 1].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x +1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[curnode.x, curnode.y].isRed == board[node.x, node.y].isRed)
                    {
                        node.canMove = false;
                        return node;
                    }
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;

                    }

                    //check chan
                    node.canMove = true;
                    return node;
                }

                // nh?ng tr??ng h?p còn l?i ko ?i ???c
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