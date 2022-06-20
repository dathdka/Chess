﻿using DemoAPI.Models;
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
        public MoveModel[,] board = new MoveModel[8,9];
        public void Init ()
        {
            board[2, 1] = new phao("phaoden1",2,1);
            board[2, 7] = new phao("phaoden2",2,7);
            board[7, 1] = new phao("phaodo1",7,1);
            board[7, 7] = new phao("phaodo2",7,7);
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
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            phao t = new phao();
            MoveModel temp =  t.checkMove(movelist.Last());
            
            if (temp.canMove)
            {
                movelist.Last().top = temp.top;
                movelist.Last().left = temp.left;
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