using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{

    public class tot : MoveModel
    {
<<<<<<< HEAD
        public int x { get; set; }
        public int y { get; set; }

=======
>>>>>>> main
        public tot(string id, int x, int y, bool isRed)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.isRed = isRed;
        }
        public tot() { }
        //check buoc di
        public MoveModel checkMove(MoveModel node, MoveModel[,] board)
        {
            MoveModel curnode = new tot();
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
                    if(node.step > 1 )
                    {
                        node.canMove = false;
                        return node;
                    }
                    else
                    {
                        //Tính tọa độ điểm nhay tiếp theo cua quân cờ ==
                        node.x = curnode.x - Math.Abs(node.step);
                        node.y = curnode.y;
                        //===============================================
                        //Làm tròn số top và left trên giao diện=========
                        node.top = isWithin(node.top);
                        node.left = isWithin(node.left);
                        ////===============================================
                        
                        // check nếu là con đen thì không cho di chuyển 
                        if(board[curnode.x, curnode.y].isRed == false)
                        {
                            node.canMove = false;
                        }
                        else
                        {
                            // check con trước mặt là rỗng hay có tướng và nó là con đen hay trắng
                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                for (int i = curnode.x; i > node.x; i--)
                                {
                                    if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel" &&  board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                                    {
                                        node.kill = board[node.x, node.y].id;
                                        node.canMove = true;
                                    }
                                    return node;
                                }

                            }
                            else
                            {
                                node.canMove = true;
                                return node;               
                                
                            }
                           
                        }
                       
                    }
                   

                }
                    //Khi top giữ nguyên và left tăng thì quân cờ đi sang phải
                if (curnode.curtop == isWithin(node.top) && curnode.curleft < isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft) / 75);
                    
                    if (node.step > 1)
                    {
                        node.canMove = false;
                        return node;
                    }
                    else
                    {
                        node.y = curnode.y + Math.Abs(node.step);
                        node.x = curnode.x;
                        node.top = isWithin(node.top);
                        node.left = isWithin(node.left);
                       
                        if (board[curnode.x, curnode.y].isRed == false )
                        {
                            if(curnode.x > 4)
                            {
                                if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                                    )
                                {

                                    for (int i = curnode.y; i < node.y; i++)
                                    {
                                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel" && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                                        {
                                            node.kill = board[node.x, node.y].id;
                                            node.canMove = true;
                                        }
                                    }
                                    return node;
                                }
                                else
                                {
                                    node.canMove = true;
                                    return node;
                                    
                                }
                            }
                            else
                            {
                                node.canMove = false;
                                return node;
                            }
                        }   
                        else
                        {
                            if(curnode.x <5)
                            {
                                if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                                    
                                {

                                    for (int i = curnode.y; i < node.y; i++)
                                    {
                                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel" && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                                        {
                                            node.kill = board[node.x, node.y].id;
                                            node.canMove = true;
                                        }
                                    }
                                    return node;
                                }
                                else
                                {
                                    node.canMove = true;
                                    return node;
                                  
                                }
                            }
                            else
                            {
                                node.canMove = false;
                                return node;
                            }
                          
                        }

                    }
                   
                }
                //Khi top tăng và left giữ nguyên thì quân cờ đi xuống
                if (curnode.curtop < isWithin(node.top) && curnode.curleft == isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.top - curnode.curtop)) / 75;
                    if (node.step > 1)
                    {
                        node.canMove = false;
                        return node;
                    }
                    else
                    {
                        node.y = curnode.y;
                        node.x = curnode.x + Math.Abs(node.step);
                        node.top = isWithin(node.top);
                        node.left = isWithin(node.left);
                        if (board[curnode.x, curnode.y].isRed == true)
                        {
                            node.canMove = false;
                        }
                        else
                        {
                            //check trước mặt là ô rỗng hay có quân cờ
                            if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel")
                            {
                                for (int i = curnode.x; i < node.x; i++)
                                {
                                    //check nếu có quân cờ thì đấy là quân đen hay quân trắng, nếu là đỏ thì ăn, đen thì chịu
                                    if (board[i, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel" && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)                               
                                    {                                      
                                        node.kill = board[node.x, node.y].id;
                                        node.canMove = true;                                         
                                    }
                                }
                                return node;
                            }
                            else
                            {
                                node.canMove = true;
                                return node;
                                
                            }                        

                        }
                       
                       
                    }
                   
                }
                //Khi top giữ nguyên và left tăng thì quân cờ đi sang trái
                if (curnode.curtop == isWithin(node.top) && curnode.curleft > isWithin(node.left))
                {
                    node.step = Math.Abs(isWithin(node.left - curnode.curleft)) / 75;
                    if (node.step > 1)
                    {
                        node.canMove = false;
                        return node;
                    }
                    else
                    {
                        node.y = curnode.y - Math.Abs(node.step);
                        node.x = curnode.x;
                        node.top = isWithin(node.top);
                        node.left = isWithin(node.left);
                      

                        if (board[curnode.x, curnode.y].isRed == false)
                        {
                            if (curnode.x > 4)
                            {
                                if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                                   )
                                {
                                    for (int i = curnode.y; i > node.y; i--)
                                    {
                                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel" && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                                            
                                        {
                                            node.kill = board[node.x, node.y].id;
                                            node.canMove = true;
                                        }
                                    }
                                    return node;
                                }
                                else
                                {
                                    node.canMove = true;
                                    return node;
                                 
                                }
                            }
                            else
                            {
                                node.canMove = false;
                                return node;
                            }
                        }
                        else
                        {
                            if (curnode.x < 5)
                            {
                                if (board[node.x, node.y].GetType().ToString() != "DemoAPI.Models.MoveModel"
                            )
                                {
                                    for (int i = curnode.y; i > node.y; i--)
                                    {
                                        if (board[node.x, i].GetType().ToString() != "DemoAPI.Models.MoveModel" && board[node.x, node.y].isRed != board[curnode.x, curnode.y].isRed)
                                        {

                                            node.kill = board[node.x, node.y].id;
                                            node.canMove = true;
                                        }
                                    }
                                    return node;
                                }
                                else
                                {
                                    node.canMove = true;
                                    return node;
                                }
                            }
                            else
                            {
                                node.canMove = false;
                                return node;
                            }

                        }
                    }
                   
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