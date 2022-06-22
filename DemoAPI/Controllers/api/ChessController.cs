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
        public MoveModel[,] board = new MoveModel[10,9];
        public void Init ()
        {
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0;j <9; j++)
                {
                    board[i, j] = new MoveModel(i,j);

                }
            }
            board[2, 1] = new phao("phaoden1",2,1);
            board[2, 7] = new phao("phaoden2",2,7);
            board[7, 1] = new phao("phaodo1",7,1);
            board[7, 7] = new phao("phaodo2",7,7);
            board[0, 4] = new tuong("tuongden1", 0, 4);
            board[8, 4] = new tuong("tuongdo1", 9, 4);

            board[3, 0] = new tot("totden1", 3, 0);
            board[3, 2] = new tot("totden2", 3, 2);
            board[3, 4] = new tot("totden3", 3, 4);
            board[3, 6] = new tot("totden4", 3, 6);
            board[3, 8] = new tot("totden5", 3, 8);
            board[6, 0] = new tot("totdo1", 6, 0);
            board[6, 2] = new tot("totdo2", 6, 2);
            board[6, 4] = new tot("totdo3", 6, 4);
            board[6, 6] = new tot("totdo4", 6, 6);
            board[6, 8] = new tot("totdo5", 6, 8);

            board[0, 3] = new si("siden1", 0, 3);
            board[0, 5] = new si("siden2", 0, 5); 
            board[9, 3] = new si("sido1", 9, 3);
            board[9, 5] = new si("sido2", 9, 5);

            board[0, 2] = new tinh("tinhden1", 0, 2); 
            board[0, 6] = new tinh("tinhden2", 0, 6); 
            board[9, 2] = new tinh("tinhdo1", 9, 2); 
            board[9, 6] = new tinh("tinhdo2", 9, 6);

            board[0, 0] = new xe("xeden1", 0, 0);
            board[0, 8] = new xe("xeden2", 0, 8);
            board[9, 0] = new xe("xedo1", 9, 0);
            board[9, 8] = new xe("xedo2", 9, 8);
            
            board[0, 1] = new ma("maden1", 0, 1);
            board[0, 7] = new ma("maden2", 0, 7);
            board[9, 1] = new ma("mado1", 9, 1);
            board[9, 7] = new ma("mado2", 9, 7);
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
        [Route("api/chess/getchessnode")]
        [HttpPost]
        public ActionResult getAllNode(List<MoveModel> movelist)
        {
            string chessJson = System.IO.File.ReadAllText(Server.MapPath("/Data/ChessJson.txt"));
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<ChessNode> chessnode = js.Deserialize<List<ChessNode>>(chessJson);
            Init();
            return Json(new
            {
                message = "success",
                chessnode = chessnode
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/movenode")]
        [HttpPost]
        public ActionResult getMoveNode(List<MoveModel> movelist)
        {
            MoveModel temp = new MoveModel();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            //test
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = new MoveModel(i, j);

                }
            }
            board[2, 1] = new phao("phaoden2", 2, 1);
            board[2, 7] = new phao("phaoden1", 2, 7);
            board[7, 1] = new phao("phaodo1", 7, 1);
            board[7, 7] = new phao("phaodo2", 7, 7);
            board[0, 4] = new tuong("tuongden1", 0, 4);
            board[8, 4] = new tuong("tuongdo1", 9, 4);
            //end test
            temp = temp.getId(movelist.Last(), this.board);
            try {
                
                board[temp.x, temp.y] = board[temp.x, temp.y];
                board[temp.x, temp.y] = new MoveModel();
            }
            catch(Exception)
            {
                temp.canMove = false;
            }

            if (temp.canMove)
            {
                movelist.Last().top = temp.top;
                movelist.Last().left = temp.left;
                board[temp.x, temp.y].curtop = temp.top;
                board[temp.x, temp.y].curleft = temp.left;
                Requestlog.PostToClient(js.Serialize(movelist));
                return Json(new
                {
                    message = true,
                    top = temp.top,
                    left = temp.left

                }, JsonRequestBehavior.AllowGet);
            }
                return Json(new
                {
                    message = false
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