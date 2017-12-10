using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    //state of blocks
    public enum States
    {
        Moving, Stop
    };
    public class Blocks
    {
        //real position of block in picturebox metrix
        protected PictureBox[] allCubes;
        //index of cubes in block in picturebox metrix
        protected Point[] allCubesPosition;
        //real position of block in picturebox metrix, alway equal to allCubes[1]
        protected PictureBox Center;
        //now state of block
        protected States nowState;
        //type of block
        protected string type;

        public Blocks() { }

        public Blocks(PictureBox[] cubes, Point[] position, PictureBox center, string type)
        {
            this.nowState = States.Moving;
            this.allCubesPosition = position;
            this.allCubes = new PictureBox[4];
            for (int i = 0; i < this.allCubes.Length; i++)
            {
                this.allCubes[i] = cubes[i];
            }
            this.Center = center;
            this.type = type;
        }

        public PictureBox[] GetAllCubes()
        {
            return this.allCubes;
        }

        public void SetAllCubes(PictureBox[] allcubes)
        {
            this.allCubes = allcubes;
        }

        public Point[] GetAllCubesPosition()
        {
            return allCubesPosition;
        }

        public void SetAllCubesPosition(Point[] position)
        {
            this.allCubesPosition = position;
        }

        public PictureBox GetCenter()
        {
            return this.Center;
        }

        public void SetCenter(PictureBox center)
        {
            this.Center = center;
        }

        public States GetNowState()
        {
            return nowState;
        }

        public void SetNowState(States nowstate)
        {
            this.nowState = nowstate;
        }

        public string GetBlocksType()
        {
            return type;
        }

        public void SetBlockType(string type)
        {
            this.type = type;
        }
    }
}
