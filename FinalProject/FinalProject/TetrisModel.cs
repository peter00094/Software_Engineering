﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class TetrisModel
    {
        private TetrisView tv;
        private String nowState = "IDLE";

        public String IdleState = "IDLE";
        public String MoveLeftState = "MOVE_LEFT";
        public String MoveRightState = "MOVE_RIGHT";
        public String MoveDownSlowState = "MOVE_DOWN_SLOW";
        public String MoveDownFastState = "MOVE_DOWN_FAST";
        public String RotateState = "ROTATE";
        public String EXIT_STATE = "EXIT";


        public TetrisModel(TetrisView view)
        {
            this.tv = view;
        }

        //reutrn now state
        public string getState()
        {
            return this.nowState;
        }
        //set the now state to the argument, and inform controller state changed
        public void setState(string newState)
        {
            this.nowState = newState;
        }
        // rotate the block
        public void Rotate(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            if (nowBlock != null && nowBlock.GetBlocksType() != "O")
            {
                Point center = ConvertIndexToPoint(nowBlock.GetCenter().Name);
                Point[] AllBlocksIndex = nowBlock.GetAllCubesPosition();
                PictureBox[] AllBlocksPosition = nowBlock.GetAllCubes();
                System.Drawing.Color nowColor = AllBlocksPosition[0].BackColor;
                Panel panelOnShow = tv.GetPanel1();
                if (nowBlock.GetNowState() != States.Stop)
                {
                    for (int i = 0; i < AllBlocksIndex.Length; i++)
                    {
                        int x = AllBlocksIndex[i].Gety() - center.Gety();
                        int y = AllBlocksIndex[i].Getx() - center.Getx();
                        // if result calculated is out of range then throw exception
                        if (center.Getx() - x < 0 || center.Getx() - x > 8 || center.Gety() + y < 0 || center.Gety() + y > 12)
                        {
                            throw new Exception();
                        }
                    }
                    // calculate new position of block rotated, and change the back color of picturebox in origin position
                    for (int i = 0; i < AllBlocksIndex.Length; i++)
                    {
                        int x = AllBlocksIndex[i].Gety() - center.Gety();
                        int y = AllBlocksIndex[i].Getx() - center.Getx();
                        AllBlocksIndex[i].Setx(center.Getx() - x);
                        AllBlocksIndex[i].Sety(center.Gety() + y);
                        AllBlocksPosition[i].BackColor = panelOnShow.BackColor;
                    }
                    // store new index of cubes in picturebox metrix
                    nowBlock.SetAllCubesPosition(AllBlocksIndex);
                    // change the back color of picturebox in new position to block color
                    for (int i = 0; i < AllBlocksPosition.Length; i++)
                    {
                        // if out of range then throw exception
                        if (i < 0 || i >= AllBlocksPosition.Length || i >= AllBlocksIndex.Length)
                        {
                            throw new Exception();
                        }
                        AllBlocksPosition[i] = allBlocks[AllBlocksIndex[i].Gety(), AllBlocksIndex[i].Getx()];
                        AllBlocksPosition[i].BackColor = nowColor;
                    }

                    //store new position of picture box in picturebox metrix
                    nowBlock.SetAllCubes(AllBlocksPosition);
                    //modify the center of block
                    nowBlock.SetCenter(AllBlocksPosition[1]);
                }
            }
        }
        // move the block left
        public void MoveLeft(Blocks nowBlock)
        {
            if (nowBlock != null)
            {
                PictureBox[,] allBlocks = tv.GetAllBlocks();
                Point[] nowBlockIndex = nowBlock.GetAllCubesPosition();
                PictureBox[] nowBlockPosition = nowBlock.GetAllCubes();
                System.Drawing.Color nowColor = nowBlockPosition[0].BackColor;
                Panel panelOnShow = tv.GetPanel1();
                if (nowBlock.GetNowState() != States.Stop)
                {
                    for (int i = 0; i < nowBlockIndex.Length; i++)
                    {
                        //avoid to move out of range
                        int x = nowBlockIndex[i].Getx();
                        if (x <= 0)
                        {
                            throw new Exception();
                        }
                        int y = nowBlockIndex[i].Gety();
                        //avoid to touch the existed block
                        if (allBlocks[y, x - 1].BackColor != panelOnShow.BackColor && allBlocks[y, x - 1].BackColor != allBlocks[y, x].BackColor && !nowBlockPosition.Contains<PictureBox>(allBlocks[y, x - 1]))
                        {
                            throw new Exception();
                        }
                    }
                    //set the color of origin block to background color
                    //compute the new position of block
                    for (int i = 0; i < nowBlockIndex.Length; i++)
                    {
                        nowBlockPosition[i].BackColor = panelOnShow.BackColor;
                        nowBlockIndex[i].Setx(nowBlockIndex[i].Getx() - 1);
                    }
                    //modify position of block
                    for (int i = 0; i < nowBlockPosition.Length; i++)
                    {
                        if (nowBlockIndex[i].Gety() < 0 || nowBlockIndex[i].Gety() > 12 || nowBlockIndex[i].Getx() < 0 || nowBlockIndex[i].Getx() > 8)
                        {
                            throw new Exception();
                        }
                        nowBlockPosition[i] = allBlocks[nowBlockIndex[i].Gety(), nowBlockIndex[i].Getx()];
                        nowBlockPosition[i].BackColor = nowColor;
                    }
                    // set new info. in every store unit
                    nowBlock.SetAllCubes(nowBlockPosition);
                    nowBlock.SetCenter(nowBlockPosition[1]);
                }
            }
        }
        // move the block right
        public void MoveRight(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            if (nowBlock != null)
            {
                Point[] nowBlockIndex = nowBlock.GetAllCubesPosition();
                PictureBox[] nowBlockPosition = nowBlock.GetAllCubes();
                System.Drawing.Color nowColor = nowBlockPosition[0].BackColor;
                Panel panelOnShow = tv.GetPanel1();
                if (nowBlock.GetNowState() != States.Stop)
                {
                    for (int i = 0; i < nowBlockIndex.Length; i++)
                    {
                        int x = nowBlockIndex[i].Getx();
                        // to avoid new index out of range
                        if (x >= 8)
                        {
                            throw new Exception();
                        }

                        int y = nowBlockIndex[i].Gety();
                        // to avoid to touch the existed block
                        if (allBlocks[y, x + 1].BackColor != panelOnShow.BackColor && allBlocks[y, x + 1].BackColor != allBlocks[y, x].BackColor && !nowBlockPosition.Contains<PictureBox>(allBlocks[y, x + 1]))
                        {
                            throw new Exception();
                        }
                    }
                    //set the color of origin block to background color
                    //compute the new position of block
                    for (int i = 0; i < nowBlockIndex.Length; i++)
                    {
                        nowBlockPosition[i].BackColor = panelOnShow.BackColor;
                        nowBlockIndex[i].Setx(nowBlockIndex[i].Getx() + 1);
                    }
                    //modify position of block
                    for (int i = 0; i < nowBlockPosition.Length; i++)
                    {
                        if (nowBlockIndex[i].Gety() < 0 || nowBlockIndex[i].Gety() > 12 || nowBlockIndex[i].Getx() < 0 || nowBlockIndex[i].Getx() > 8)
                        {
                            throw new Exception();
                        }
                        nowBlockPosition[i] = allBlocks[nowBlockIndex[i].Gety(), nowBlockIndex[i].Getx()];
                        nowBlockPosition[i].BackColor = nowColor;
                    }
                    // set all info. to every store unit
                    nowBlock.SetAllCubes(nowBlockPosition);
                    nowBlock.SetCenter(nowBlockPosition[1]);
                }
            }
        }
        // move the block down slow
        public void DropDownSlow(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            
        }
        // move the block down fast
        public void DropDownFast(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            
        }
        // remove the row full of color, and made the another row up this row move down
        public void RemoveLine(PictureBox[,] allBlocks)
        {
            
        }
        // determine whether the game is over or not
        public bool GameOver()
        {
            // if game is over, then return true, whereas return false
            return false;
        }
        // set shape of block
        public Blocks SetShape(PictureBox[] CubesNeeded, string type)
        {
            Blocks nowBlock;
            Point[] index = new Point[4];
            PictureBox[] cubes = new PictureBox[4];

            if (type == "T")
            {
                cubes = setContentByGiven(CubesNeeded, 0, 1, 2, 4, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockT(cubes, center);
            }
            else if (type == "Z")
            {
                cubes = setContentByGiven(CubesNeeded, 0, 1, 4, 5, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockZ(cubes, center);
            }
            else if (type == "O")
            {
                cubes = setContentByGiven(CubesNeeded, 0, 1, 3, 4, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockO(cubes, center);
            }
            else if (type == "Lightning")
            {
                cubes = setContentByGiven(CubesNeeded, 0, 3, 4, 7, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockLightning(cubes, center);
            }
            else if (type == "l")
            {
                cubes = setContentByGiven(CubesNeeded, 1, 4, 7, 10, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new Blockl(cubes, center);
            }
            else if (type == "L")
            {
                cubes = setContentByGiven(CubesNeeded, 1, 4, 7, 8, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockL(cubes, center);
            }
            else if (type == "J")
            {
                cubes = setContentByGiven(CubesNeeded, 1, 4, 7, 6, ref index);
                if (!TestCubesEmpty(cubes))
                {
                    tv.SetFinish(true);
                    return null;
                }
                PictureBox center = cubes[1];
                nowBlock = new BlockJ(cubes, center);
            }
            else
                nowBlock = null;

            nowBlock.SetAllCubesPosition(index);

            return nowBlock;
        }
        // find the picturebox wanted, and turn its index to integer
        private PictureBox[] setContentByGiven(PictureBox[] cubes, int first, int second, int third, int forth, ref Point[] index)
        {
            PictureBox[] result = new PictureBox[4];
            result[0] = cubes[first];
            index[0] = ConvertIndexToPoint(cubes[first].Name);
            result[1] = cubes[second];
            index[1] = ConvertIndexToPoint(cubes[second].Name);
            result[2] = cubes[third];
            index[2] = ConvertIndexToPoint(cubes[third].Name);
            result[3] = cubes[forth];
            index[3] = ConvertIndexToPoint(cubes[forth].Name);
            return result;
        }
        // turn the string index to point form
        private Point ConvertIndexToPoint(string content)
        {
            int i;
            for (i = 0; i < content.Length; i++)
            {
                if (content[i] <= '9' && content[i] >= '0')
                {
                    break;
                }
            }
            int index = int.Parse(content.Substring(i));
            int x, y;
            x = index % 10;
            y = index / 10;
            return new Point(x, y);
        }
        // test all cubes is "empty"
        private bool TestCubesEmpty(PictureBox[] cubes) {
            Panel panelOnShow = tv.GetPanel1();
            for (int i = 0; i < cubes.Length; i++)
            {
                if (cubes[i].BackColor != panelOnShow.BackColor)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
