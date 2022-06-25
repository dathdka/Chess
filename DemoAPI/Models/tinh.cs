using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class tinh : MoveModel
    {

        public tinh(string id, int x, int y, bool isRed)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.isRed = isRed;
        }
        public tinh() { }
        public MoveModel checkMove(MoveModel node, MoveModel[,] board)
        {
            MoveModel curnode = new tinh();

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
                //Khi top giảm và left giữ tăng  thì quân cờ đi lên bên phải 
                if (curnode.curtop > isWithin(node.top) && curnode.curleft < isWithin(node.left))
                {

                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    if (node.step != 2)
                    {
                        return node;
                    }
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);
                    
                    //Chặn bước nhảy của quân cờ khi có vật cản
                        int i = curnode.x - 1; 
                        int j = curnode.y + 1;
                        string b = board[i, j].GetType().ToString();
                        if (board[i, j].GetType().ToString() != "DemoAPI.Models.MoveModel")
                        {
                            return node;
                        }
                    //Chặn đi 1 nước
                    //if(node.x == curnode.x -2 && node.y == curnode.y + 2)
                    //{
                    //    return node;
                    //}
         
                    //cấm qua sông 
                    if (curnode.isRed == true && node.x < 5)
                    {
                        return node;
                    }
                    if (curnode.isRed == false && node.x > 4)
                    {
                        return node;
                    }
                    //Check an quan co
                    if (curnode.isRed == true)
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x >= 5)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }
                    else
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x <= 4)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }



                    string a = board[(node.x), (node.y)].GetType().ToString();
                    if (a != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }

                    

                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

                    node.canMove = true;
                    return node;
                }
                //Khi top giảm và left giảm thì quân cờ đi sang trái lên trên
                if (curnode.curtop > isWithin(node.top) && curnode.curleft > isWithin(node.left))

                {

                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    if (node.step != 2)
                    {
                        return node;
                    }
                    node.x = curnode.x - Math.Abs(node.step);
                    node.y = curnode.y - Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);

                    //Chặn bước nhảy của quân cờ khi có vật cản
                    int i = curnode.x - 1;
                    int j = curnode.y - 1;
                    string b = board[i, j].GetType().ToString();
                    if (board[i, j].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }
                    //Chặn đi 1 nước
                    //if (node.x == curnode.x - 2 && node.y == curnode.y - 2)
                    //{
                    //    return node;
                    //}
                    //cấm qua sông 
                    if (curnode.isRed == true && node.x < 5)
                    {
                        return node;
                    }
                    if (curnode.isRed == false && node.x > 4)
                    {
                        return node;
                    }
                    //Check an quan co
                    if (curnode.isRed == true)
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x >= 5)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }
                    else
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x <= 4)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }

                    string a = board[(node.x), (node.y)].GetType().ToString();
                    if (a != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }



                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

                    node.canMove = true;
                    return node;
                }
                //Khi top tăng và left giảm thì quân cờ đi xuống trái 
                if (curnode.curtop < isWithin(node.top) && curnode.curleft > isWithin(node.left))

                {

                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    if (node.step != 2)
                    {
                        return node;
                    }
                    node.x = curnode.x + Math.Abs(node.step);
                    node.y = curnode.y - Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);

                    //Chặn bước nhảy của quân cờ khi có vật cản
                    int i = curnode.x + 1;
                    int j = curnode.y - 1;
                    string b = board[i, j].GetType().ToString();
                    if (board[i, j].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }
                    
                    //Chặn đi 1 nước
                    //if (node.y == curnode.y - 1)
                    //{
                    //    return node;
                    //}
                    //cấm qua sông 
                    if (curnode.isRed == true && node.x < 5)
                    {
                        return node;
                    }
                    if (curnode.isRed == false && node.x > 4)
                    {
                        return node;
                    }
                    //Check an quan co
                    if (curnode.isRed == true)
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x >= 5)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }
                    else
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x <= 4)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }



                    string a = board[(node.x), (node.y)].GetType().ToString();
                    if (a != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }



                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

                    node.canMove = true;
                    return node;
                }
                //Khi top tăng và left tăng thì quân cờ đi xuống phải 
                if (curnode.curtop < isWithin(node.top) && curnode.curleft < isWithin(node.left))

                {

                    node.step = Math.Abs(isWithin(node.top - curnode.curtop) / 75);
                    if (node.step != 2)
                    {
                        return node;
                    }
                    node.x = curnode.x + Math.Abs(node.step);
                    node.y = curnode.y + Math.Abs(node.step);
                    node.top = isWithin(node.top);
                    node.left = isWithin(node.left);

                    //Chặn bước nhảy của quân cờ khi có vật cản
                    int i = curnode.x + 1;
                    int j = curnode.y + 1;
                    string b = board[i, j].GetType().ToString();
                    if (board[i, j].GetType().ToString() != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }
                    //Chặn đi 1 nước
                    //if (node.y == curnode.y + 1)
                    //{
                    //        
                    //    return node;
                    //}
                    //cấm qua sông 
                    if (curnode.isRed == true && node.x < 5)
                    {
                        return node;
                    }
                    if (curnode.isRed == false && node.x > 4)
                    {
                        return node;
                    }
                    //Check an quan co
                    if (curnode.isRed == true)
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x >= 5)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }
                    else
                    {
                        if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                        && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed && node.x <= 4)
                        {
                            int count = 0;

                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                node.kill = board[node.x, node.y].id;
                                node.canMove = true;
                            }
                            return node;
                        }
                    }



                    string a = board[(node.x), (node.y)].GetType().ToString();
                    if (a != "DemoAPI.Models.MoveModel")
                    {
                        return node;
                    }



                    //===============================================
                    //nếu vẫn chạy ổn trả về giá trị canMove = true

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