using DemoAPI.Models;
using Lib.Entities;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Controllers.api
{
    public class ChessController: Controller
    {

        MoveModel[,] board = new MoveModel[10, 9];
        public int turn = 1;
        public void init()
        {
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        board[i, j] = new MoveModel(i, j);

                    }
                }
                board[2, 1] = new phao("phaoden2", 2, 1, false);
                board[2, 7] = new phao("phaoden1", 2, 7 , false);
                board[7, 1] = new phao("phaodo1", 7, 1, true);
                board[7, 7] = new phao("phaodo2", 7, 7, true);


                board[0, 4] = new tuong("tuongden1", 0, 4, false);
                board[9, 4] = new tuong("tuongdo1", 9, 4, true);

                board[0, 4] = new tuong("tuongden", 0, 4,false);
                board[9, 4] = new tuong("tuongdo", 9, 4,true);

                board[3, 0] = new tot("totden1", 3, 0, false);
                board[3, 2] = new tot("totden2", 3, 2, false);
                board[3, 4] = new tot("totden3", 3, 4, false);
                board[3, 6] = new tot("totden4", 3, 6, false);
                board[3, 8] = new tot("totden5", 3, 8, false);
                board[3, 8] = new tot("totden1", 3, 8, false);
                board[3, 6] = new tot("totden2", 3, 6, false);
                board[3, 4] = new tot("totden3", 3, 4, false);
                board[3, 2] = new tot("totden4", 3, 2, false);
                board[3, 0] = new tot("totden5", 3, 0, false);
                board[6, 0] = new tot("totdo1", 6, 0, true);
                board[6, 2] = new tot("totdo2", 6, 2, true);
                board[6, 4] = new tot("totdo3", 6, 4, true);
                board[6, 6] = new tot("totdo4", 6, 6, true);
                board[6, 8] = new tot("totdo5", 6, 8, true);

                board[0, 3] = new si("siden1", 0, 3, false);
                board[0, 5] = new si("siden2", 0, 5, false);
                board[9, 3] = new si("sido1", 9, 3, true);
                board[9, 5] = new si("sido2", 9, 5, true);

                board[0, 2] = new tinh("tinhden1", 0, 2, false);
                board[0, 6] = new tinh("tinhden2", 0, 6, false);
                board[9, 2] = new tinh("tinhdo1", 9, 2, true);
                board[9, 6] = new tinh("tinhdo2", 9, 6, true);

                board[0, 0] = new xe("xeden1", 0, 0, false);
                board[0, 8] = new xe("xeden2", 0, 8, false);
                board[9, 0] = new xe("xedo1", 9, 0, true);
                board[9, 8] = new xe("xedo2", 9, 8, true);

                board[0, 1] = new ma("maden1", 0, 1, false);
                board[0, 1] = new ma("maden1", 0, 1,false);
                board[0, 7] = new ma("maden2", 0, 7, false);
                board[9, 1] = new ma("mado1", 9, 1, true);
                board[9, 7] = new ma("mado2", 9, 7, true);
            }
        }
        ChessService chessService = new ChessService();
        
        [Route("api/chess/insertroom")]
        [HttpPost]
        public ActionResult insertroom(RoomModel rmodel)
        {
            Room r = new Room();
            r.Id = Guid.NewGuid();
            r.Name = rmodel.Name;
            chessService.insertRoom(r);
            return
            Json(new
            {
                message = "success",
               // data = stList //_dbContext.Student.OrderBy(s=>s.Id).Skip(2).Take(3).ToList() //Where(s=>s.Id == Guid.Parse(id)).FirstOrDefault()
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/getrooms")]
        [HttpGet]
        public ActionResult getallroom()
        {
            List<Room> roomList = chessService.getAllRoom();
            return
            Json(new
            {
                message = "success",
                data = roomList //_dbContext.Student.OrderBy(s=>s.Id).Skip(2).Take(3).ToList() //Where(s=>s.Id == Guid.Parse(id)).FirstOrDefault()
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/reload")]
        [HttpPost]
        public ActionResult getReload()
        {
            Session["arr"] = null;
            Session["turn"] = null;
            return Json(new
            {
                message = "succeed"
            }, JsonRequestBehavior.AllowGet);
        }


        [Route("api/chess/getchessnode")]
        [HttpPost]
        public ActionResult getAllNode(List<MoveModel> movelist)
        {
            string chessJson = System.IO.File.ReadAllText(Server.MapPath("/Data/ChessJson.txt"));
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<ChessNode> chessnode = js.Deserialize<List<ChessNode>>(chessJson);
            if(Session["arr"]==null)
            {
                init();
                Session["arr"] = board;
                
            }
            if (Session["turn"] == null)
                Session["turn"] = turn;
                return Json(new
            {
                chessnode = chessnode
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/movenode")]
        [HttpPost]
        public ActionResult getMoveNode(List<MoveModel> movelist)
        {
            MoveModel temp = new MoveModel();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            int positionx = 0;
            int positiony = 0;
            bool checkTurn;
            // lấy mảng trên session về
            MoveModel[,] nb = Session["arr"] as MoveModel[,];
            // phân loại và kiểm tra có đi được không
            turn = int.Parse(Session["turn"].ToString());
            checkTurn = turn % 2 != 0 ? true : false;
            temp = temp.getId(movelist.Last(), nb);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (nb[i, j].id == temp.id)
                    {
                        positionx = i;
                        positiony = j;
                        break;
                    }
                }
            }
            if (nb[positionx, positiony].isRed != checkTurn)
                temp.canMove = false;
            if (!temp.canMove)
            {
                //nếu canMove = false thì revert
                movelist.Remove(movelist.Last());
                return Json(new
                {
                    message = false
                }, JsonRequestBehavior.AllowGet);
            }

            try {
                // tìm vị trí quân cờ hiện tại cần di chuyển
                for (int i = 0; i< 10; i++)
                {
                    for(int j = 0; j<9; j++)
                    {
                        if(nb[i,j].id == temp.id)
                        {
                            positionx = i;
                            positiony = j;
                            break;
                        }
                    }
                }
                if (temp.canMove)
                {
                if (nb[positionx, positiony].isRed != checkTurn)
                    temp.canMove = false;
                // hoán đổi vị trí mới và cũ
                nb[temp.x, temp.y] = nb[positionx, positiony];
                nb[positionx, positiony] = new MoveModel();

                }    
                
            }
            catch(Exception)
            {
                // nếu quãng đi nằm ngoài mảng thì chặn
                temp.canMove = false;
            }

            if (temp.canMove)
            {
                turn += 1;
                // lưu vị trí các quân cờ vừa thay đổi
                movelist.Last().top = temp.top;
                movelist.Last().left = temp.left;
                nb[temp.x, temp.y].curtop = temp.top;
                nb[temp.x, temp.y].curleft = temp.left;
                nb[temp.x, temp.y].x = temp.x;
                nb[temp.x, temp.y].y = temp.y;
                if(temp.kill != null)
                    nb[temp.x, temp.y].kill = temp.kill;
                nb[temp.x, temp.y].step = 0;
                Session["arr"] = nb;
                Session["turn"] = turn;
                Requestlog.PostToClient(js.Serialize(movelist));
                
                return Json(new
                {
                    message = true,
                    top = temp.top,
                    left = temp.left,
                    kill = temp.kill,
                    turn = checkTurn

                }, JsonRequestBehavior.AllowGet);
            }
            movelist.Remove(movelist.Last());
            return Json(new
                {
                    message = false,
                    kill = temp.kill
                }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/getMess")]
        [HttpPost]
        public ActionResult sendMessage(String mess)
        {

            Requestlog.PostToClient(mess);
            return
            Json(new
            {
                message = mess,
               
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}