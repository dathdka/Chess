using DemoAPI.Models;
using Lib;
using Lib.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DemoAPI.Controllers.api
{
    public class ClassRoomController: Controller
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        [HttpPost]
        [Route("api/ClassRoom/insertClassRoom")]
        public ActionResult getbyId1(RoomModel clRoom)
        {
            try
            {
                Room cl = new Room();
                cl.Name = clRoom.Name;
                cl.Id = Guid.NewGuid();
                _dbContext.Room.Add(cl);
                _dbContext.SaveChanges();
                return
                Json(new
                {
                    status = true,
                    message = "them thanh cong",
                    data = cl
                });
             }
            catch (Exception ex) {
                return
                Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
    }
}