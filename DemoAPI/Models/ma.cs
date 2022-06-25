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
                    // check kill
                    if (board[curnode.x, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y].isRed != board[node.x, node.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                    }
                    //check chan
                    if (board[curnode.x + 1, curnode.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&
                        board[curnode.x, curnode.y + 1].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        node.canMove = false;
                        return node;
                    }
                    node.canMove = true;
                    return node;
                }
                //Khi top gi? nguyên và left t?ng thì quân c? ?i sang ph?i
                if (curnode.curtop == isWithin(node.top) && curnode.curleft < isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft) / 75);
                    node.y = curnode.y + Math.Abs(node.step);
                    node.x = curnode.x;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        int count = 0;
                        for (int i = curnode.y + 1; i < node.y; i++)
                        {
                            if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }
                        }
                        if (count == 1)
                        {
                            node.kill = board[node.x, node.y].id;
                            node.canMove = true;
                        }
                        return node;
                    }

                    for (int i = curnode.y + 1; i <= node.y; i++)
                    {
                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    }
                    node.canMove = true;
                    return node;
                }
                //Khi top t?ng và left gi? nguyên thì quân c? ?i xu?ng
                if (curnode.curtop < isWithin(node.top) && curnode.curleft == isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop)) / 75;
                    node.y = curnode.y;
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        int count = 0;
                        for (int i = curnode.x + 1; i < node.x; i++)
                        {
                            if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }
                        }
                        if (count == 1)
                        {
                            node.kill = board[node.x, node.y].id;
                            node.canMove = true;
                        }
                        return node;
                    }
                    for (int i = curnode.x + 1; i <= node.x; i++)
                    {
                        if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    }
                    node.canMove = true;
                    return node;
                }
                //Khi top gi? nguyên và left t?ng thì quân c? ?i sang trái
                if (curnode.curtop == isWithin(node.top) && curnode.curleft > isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft)) / 75;
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x;
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        int count = 0;
                        for (int i = curnode.y - 1; i > node.y; i--)
                        {
                            if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }
                        }
                        if (count == 1)
                        {
                            node.kill = board[node.x, node.y].id;
                            node.canMove = true;
                        }
                        return node;
                    }
                    for (int i = curnode.y - 1; i >= node.y; i--)
                    {
                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    }
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