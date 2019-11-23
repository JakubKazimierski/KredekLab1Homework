using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JakubKazimierskiGame
{
    public partial class Form1 : Form
    {

        #region Variables
        Random rand;

        PictureBox[] stars;
        int backgroundSpeed;
         
        int playerSpeed;

        PictureBox[] munitions;
        int MunitionSpeed;

        PictureBox[] enemies;
        int enemiesSpeed;


        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Bacground Methods

        /// <summary>
        /// Loading backround of game
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event object</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 4;
            playerSpeed = 4;
            MunitionSpeed = 20;
            enemiesSpeed = 4;

            stars = new PictureBox[15];
            
            rand = new Random();
            
            munitions = new PictureBox[2];
          

            //rendering ammo
            for(int i = 0; i<munitions.Length; i++ )
            {

                munitions[i] = new PictureBox();
                munitions[i].BorderStyle = BorderStyle.None;
                munitions[i].Size = new Size(8, 8);
                munitions[i].BackColor = Color.Red;
                this.Controls.Add(munitions[i]);
            }



            //rendering stars at background
            for (int i = 0; i < stars.Length; i ++)
            {

                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rand.Next(-25, 500), rand.Next(-10, 500));
                if( i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.White;

                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }


                this.Controls.Add(stars[i]);



            }
        
        }

        private void MoveBackground_Tick(object sender, EventArgs e)
        {
            //rendering stars depending from timer
            for ( int i = 0; i < stars.Length / 2; i++ )
            {
                stars[i].Top += backgroundSpeed;

                if(stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
            //rendering sars depending from timer
            for (int i = stars.Length / 2 ; i < stars.Length ; i++)
            {
                stars[i].Top += backgroundSpeed-2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

        }

        #endregion

        #region Moving Player Methods
        
        /// <summary>
        /// Timer init moving left
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event object</param>
        private void LeftTimer_Tick(object sender, EventArgs e)
        {
            if ( Player.Left > 10)
            {

                Player.Left -= playerSpeed;
            }
        }

        /// <summary>
        /// Timer init of moving rigth
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event object</param>
        private void RightTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 630)
            {

                Player.Left += playerSpeed;
            }
        }

        /// <summary>
        /// Start moving
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event object</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Right)
            {
                RightTimer.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                LeftTimer.Start();
            }
        }

        /// <summary>
        /// Stop moving
        /// </summary>
        /// <param name="sender">The even sender</param>
        /// <param name="e">The event object</param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightTimer.Stop();
            LeftTimer.Stop(); 
        }

        #endregion

        #region Shooting method
        private void MunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }
        #endregion
    }
}
