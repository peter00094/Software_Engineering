using System;
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

        }
        //set the now state to the argument, and inform controller state changed
        public void setState(string newState)
        {

        }
        // rotate the block
        public void Rotate(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            
        }
        // move the block left
        public void MoveLeft(Blocks nowBlock)
        {
            
        }
        // move the block right
        public void MoveRight(Blocks nowBlock, PictureBox[,] allBlocks)
        {
            
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
            
        }
        // set shape of block
        public Blocks SetShape(PictureBox[] CubesNeeded, string type)
        {
            
        }
        // find the picturebox wanted, and turn its index to integer
        private PictureBox[] setContentByGiven(PictureBox[] cubes, int first, int second, int third, int forth, ref Point[] index)
        {
            
        }
        // turn the string index to point form
        private Point ConvertIndexToPoint(string content)
        {
            
        }
        // test all cubes is "empty"
        private bool TestCubesEmpty(PictureBox[] cubes) {
            
        }
    }
}
