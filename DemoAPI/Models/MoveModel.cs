using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class MoveModel
    {
        public string id { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public bool visible { get; set; }
        public int curtop { get; set; }
        public int curleft { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool isRed { get; set; }

        public string kill { get; set; }

        public int step { get; set; }


        public bool canMove = false;

        public MoveModel() { }
        public MoveModel(int x , int y)
        {
            this.id = "0";
            this.top = 0;
            this.left = 0;
            this.visible = true;
            this.curtop = 0;
            this.curleft = 0;
            this.x = x;
            this.y = y;
            this.isRed = false;
            this.step = 0;
        }
        public int isWithin(int value)
        {
            // tính số bước nhảy
            int step = value / 75;
            // check số âm
            int isNegative = value > 0 ? 1 : -1;
            // nếu số bước nhảy sắp tới ~ bước nhảy xa nhất thì trả về bước nhảy xa nhất
            if (Math.Abs(value) > Math.Abs(step) * 75 + 55)
                return 75 * (step + 1 * isNegative);
            // nếu số bước nhảy sắp tới ~ bước nhảy xa nhất - 1 thì trả về bước nhảy xa nhất -1
            else if (Math.Abs(value) <= Math.Abs(step) * 75 + 20)
                return 75 * step;
            //nếu bước nhảy nằm giữa 2 điểm thì trả về -1
            return -1;
        }

        public MoveModel getId(MoveModel node, MoveModel[,] board)
        {
            phao phao = new phao();
            tuong tuong = new tuong();
            xe xe = new xe();
            si si = new si();
            tinh tinh = new tinh();
            tot tot = new tot();
            ma ma = new ma();
            //phân loại quân cờ
            switch (node.id)
            {
                case "phaoden1":
                    return phao.checkMove(node, board);
                case "phaoden2":
                    return phao.checkMove(node, board);
                case "phaodo1":
                    return phao.checkMove(node, board);
                case "phaodo2":
                    return phao.checkMove(node, board);
                case "xeden1":
                    return xe.checkMove(node, board);
                case "xeden2":
                    return xe.checkMove(node, board);
                case "xedo1":
                    return xe.checkMove(node, board);
                case "xedo2":
                    return xe.checkMove(node, board);
                case "siden1":
                    return si.checkMove(node, board);
                case "siden2":
                    return si.checkMove(node, board);
                case "sido1":
                    return si.checkMove(node, board);
                case "sido2":
                    return si.checkMove(node, board);
                case "tinhden1":
                    return tinh.checkMove(node, board);
                case "tinhden2":
                    return tinh.checkMove(node, board);
                case "tinhdo1":
                    return tinh.checkMove(node, board);
                case "tinhdo2":
                    return tinh.checkMove(node, board);
                case "totden1":
                    return tot.checkMove(node, board);
                case "totden2":
                    return tot.checkMove(node, board);
                case "totden3":
                    return tot.checkMove(node, board);
                case "totden4":
                    return tot.checkMove(node, board);
                case "totden5":
                    return tot.checkMove(node, board);
                case "totdo1":
                    return tot.checkMove(node, board);
                case "totdo2":
                    return tot.checkMove(node, board);
                case "totdo3":
                    return tot.checkMove(node, board);
                case "totdo4":
                    return tot.checkMove(node, board);
                case "totdo5":
                    return tot.checkMove(node, board);
                case "maden1":
                    return ma.checkMove(node, board);
                case "maden2":
                    return ma.checkMove(node, board);
                case "mado1":
                    return ma.checkMove(node, board);
                case "mado2":
                    return ma.checkMove(node, board);
                case "tuongden":
                    return tuong.checkMove(node, board);
                case "tuongdo":
                    return tuong.checkMove(node, board);
                default:
                    node.canMove = false;
                    return node;

            }
        }
        
    }
}