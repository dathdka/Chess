using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class xe : MoveModel
    {
        public xe(string id, int x, int y, bool isRed)

        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.isRed = isRed;
        }
        public xe() { }
        //check buoc di
        public MoveModel checkMove(MoveModel node, MoveModel[,] board)
        {
            MoveModel curnode = new xe();

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
                //Khi top giảm và left giữ nguyên thì quân cờ đi lên
                if (curnode.curtop > isWithin(node.top) && curnode.curleft == isWithin(node.left))
                {
                    //Tính số bước nhảy của quân cờ
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    //Tính tọa độ điểm nhay tiếp theo cua quân cờ ==
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y;
                    //===============================================
                    //Làm tròn số top và left trên giao diện=========
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    //===============================================
                    if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                    {
                        for (int i = curnode.x; i > node.x; i--)
                        {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                                return node;
                        }    
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
                        for (int i = curnode.y; i < node.y; i++)
                        {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                                return node;
                        }
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
                //Khi top tăng và left giữ nguyên thì quân cờ đi xuống
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
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang trái
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
}