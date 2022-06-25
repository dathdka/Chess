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
                //Khi top giảm và left giữ nguyên thì quân cờ đi lên ben phai
                if ((curnode.curtop - isWithin(node.top)) / 75 == -2 && (curnode.curleft - isWithin(node.left)) / 75 == 1)
                {
                    //Tính số bước nhảy của quân cờ
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    //Tính tọa độ điểm nhay tiếp theo cua quân cờ ==
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y + Math.Abs(node.step);
                    //===============================================
                    //Làm tròn số top và left trên giao diện=========
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    //===============================================
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
                        return node;
                    }
                    //Chặn bước nhảy của quân cờ khi có vật cản======
                    for (int i = curnode.x - 1; i >= node.x; i--)
                    {
                        string a = board[i, node.y].GetType().ToString();
                        if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    }
                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

                    node.canMove = true;
                    return node;
                }
                //Khi top giảm và left giữ nguyên thì quân cờ đi lên ben trai
                if ((curnode.curtop - isWithin(node.top)) / 75 == -2  && (curnode.curleft - isWithin(node.left)) /75 == -1)
                {
                    //Tính số bước nhảy của quân cờ
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    //Tính tọa độ điểm nhay tiếp theo cua quân cờ ==
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y - Math.Abs(node.step);
                    //===============================================
                    //Làm tròn số top và left trên giao diện=========
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    //===============================================
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
                        return node;
                    }
                    //Chặn bước nhảy của quân cờ khi có vật cản======
                    for (int i = curnode.x - 1; i >= node.x; i--)
                    {
                        string a = board[i, node.y].GetType().ToString();
                        if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    }
                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

                    node.canMove = true;
                    return node;
                }
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang phải
                if ((curnode.curtop - isWithin(node.top)) / 75 == 1 && (curnode.curleft - isWithin(node.left)) / 75 == -2)
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft) / 75);
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
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
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang phải
                if ((curnode.curtop - isWithin(node.top)) / 75 == 1 && (curnode.curleft - isWithin(node.left)) / 75 == 2)
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft) / 75);
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
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
                //Khi top tăng và left giữ nguyên thì quân cờ đi xuống 1
                if ((curnode.curtop - isWithin(node.top)) / 75 == 2 && (curnode.curleft - isWithin(node.left)) / 75 == 1)
                {
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop)) / 75;
                    node.y = curnode.y + Math.Abs(node.step);
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
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
                //Khi top tăng và left giữ nguyên thì quân cờ đi xuống 2
                if ((curnode.curtop - isWithin(node.top)) / 75 == 2 && (curnode.curleft - isWithin(node.left)) / 75 == -1)
                {
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop)) / 75;
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
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
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang trái 1
                if ((curnode.curtop - isWithin(node.top)) / 75 == -1 && (curnode.curleft - isWithin(node.left)) / 75 == 2)
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft)) / 75;
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x - Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        node.kill = board[node.x, node.y].id;
                        node.canMove = true;
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
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang trái 2
                if ((curnode.curtop - isWithin(node.top)) / 75 == -1 && (curnode.curleft - isWithin(node.left)) / 75 == -2)
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft)) / 75;
                    node.y = curnode.y - Math.Abs(node.step);
                    node.x = curnode.x - Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                            node.kill = board[node.x, node.y].id;
                            node.canMove = true;
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
                // những trường hợp còn lại ko đi được
                else
                {
                    node.canMove = false;
                    return node;
                }

            }
            return node;
        }
    }
