using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    // create an block whose shape is T
    public class BlockT : Blocks
    {
        public BlockT(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Purple;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "T";
        }
    }
    // create an block whose shape is l (straight line)
    public class Blockl : Blocks
    {
        public Blockl(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Aqua;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "l";
        }
    }
    // create an block whose shape is Z
    public class BlockZ : Blocks
    {
        public BlockZ(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Red;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "Z";
        }
    }
    // create an block whose shape is reverse Z
    public class BlockLightning : Blocks
    {
        public BlockLightning(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Green;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "Lightning";
        }
    }
    // create an block whose shape is L
    public class BlockL : Blocks
    {
        public BlockL(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Blue;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "L";
        }
    }
    // create an block whose shape is reverse L
    public class BlockJ : Blocks
    {
        public BlockJ(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Orange;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "J";
        }
    }
    // create an block whose shape is a cube
    public class BlockO : Blocks
    {
        public BlockO(System.Windows.Forms.PictureBox[] cubes, System.Windows.Forms.PictureBox center)
        {
            this.allCubes = cubes;
            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].BackColor = System.Drawing.Color.Yellow;
            }
            this.nowState = States.Moving;
            this.Center = center;
            this.type = "O";
        }
    }
}
