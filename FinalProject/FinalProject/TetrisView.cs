using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class TetrisView : Form
    {
        private TetrisModel tm;
        private TetrisController tc;
        private bool finish_flag;
        private Blocks nowBlock, nextBlock;
        protected int nowTime = 0;
        PictureBox[] initialCubesOnShow, initialCubesOnNext;
        private String[] Type = { "T", "Z", "l", "Lightning", "L", "J", "O" };
        

        public TetrisView()
        {
            InitializeComponent();
            ViewSetting();
            this.tm = new TetrisModel(this);
            this.tc = new TetrisController(this);
            finish_flag = false;
            nowBlock = null;
            nextBlock = null;
            initialCubesOnShow = new System.Windows.Forms.PictureBox[12];
            initialCubesOnShow = GetWantedBlockOnShow();
            initialCubesOnNext = new System.Windows.Forms.PictureBox[12];
            initialCubesOnNext = GetWantedBlockOnNext();
            tc.start();
        }

        public ref Blocks GetNowBlock()
        {
            return ref(this.nowBlock);
        }

        public void SetNowBlock(Blocks nowblock)
        {
            this.nowBlock = nowblock;
        }

        public ref Blocks GetNextBlock()
        {
            return ref (this.nextBlock);
        }

        public void SetNextBlock(Blocks nextBlock)
        {
            this.nextBlock = nextBlock;
        }

        public ref PictureBox[,] GetAllBlocks()
        {
            return ref(this.allCubesOnShow);
        }

        public void SetAllBlocks(PictureBox[,] allblocks)
        {
            this.allCubesOnShow = allblocks;
        }
        // change the view of program, in the program.cs, it will explain how program start
        public void ChangeGameView()
        {
            //may made a tetrisView array, and random choose one to show
        }
        // be inform the state is changed, then modify the model to new model
        public void stateHasChanged(TetrisModel model)
        {

        }
        // inform whether game is finished
        public bool finish()
        {
            return finish_flag;
        }
        // set finish flag
        public void SetFinish(bool state) {
            this.finish_flag = state;
        }
        // get key code
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
        }
        // geneate the position of new block on show panel
        private PictureBox[] GetWantedBlockOnShow()
        {
            
        }
        // geneate the position of new block on nect panel
        private PictureBox[] GetWantedBlockOnNext()
        {
            
        }
        // change color of every picturebox in matrix to background color
        private void ClearNextPanel() {
            
        }
        // setting the apparent, you will not modify the code here
        public virtual void ViewSetting() {
            
        }
        // when the inteval of timer1 is arrive
        private void timer1_Tick(object sender, EventArgs e)
        {
            //record the time of game played
            
        }
        // when button1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //start
            
        }
        // when button2 is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            //pause
            
        }
        // when the inteval of timer2 is arrive, the program need to generate new block
        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
        // exit the game
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        // change the game view
        private void button4_Click(object sender, EventArgs e)
        {

        }

        public Panel GetPanel1() {
            return this.panel1;
        }

        public Panel GetPanel2()
        {
            return this.panel2;
        }

        public Label GetLabel1() {
            return this.label1;
        }
    }
}
