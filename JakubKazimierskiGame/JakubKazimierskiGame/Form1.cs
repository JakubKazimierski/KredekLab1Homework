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


        PictureBox[] enemiesMunitions;
        int enemiesMunitionSpeed;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameIsOver;

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
            #region creating variables object
            
            backgroundSpeed = 4;
            playerSpeed = 4;
            MunitionSpeed = 20;
            enemiesSpeed = 4;
            enemiesMunitionSpeed = 4;
            difficulty = 9;
            level = 1;
            score = 0;
            pause = false;
            gameIsOver = false;
            #endregion

            #region Creating picture box object
            
            stars = new PictureBox[15];
            
            rand = new Random();
            
            munitions = new PictureBox[2];

            enemies = new PictureBox[10];

            enemiesMunitions = new PictureBox[10];

            #endregion

            #region Rendering Images loops
            //rendering ammo
            for (int i = 0; i<munitions.Length; i++ )
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
        
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
            
                enemies[i].Location = new Point((i + 1) * 50, -50);
                this.Controls.Add(enemies[i]);
            }


            for (int i = 0; i < enemiesMunitions.Length; i++)
            {

                enemiesMunitions[i] = new PictureBox();
                enemiesMunitions[i].Size = new Size(2, 25);
                enemiesMunitions[i].BackColor = Color.Magenta;
                enemiesMunitions[i].Visible = false;
                int x = rand.Next(0, 10);
                enemiesMunitions[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMunitions[i]);
            }

            #endregion
            //load enemies img from file
            #region Images of enemies

            Image enemi1 = Image.FromFile("images\\E3.png");
            Image enemi2 = Image.FromFile("images\\E3.png");
            Image enemi3 = Image.FromFile("images\\E3.png");

            Image boss1 = Image.FromFile("images\\E3.png");
            Image boss2 = Image.FromFile("images\\E3.png");


            //create enemies img
               enemies[0].Image = boss1;
               enemies[1].Image = enemi3;
               enemies[2].Image = enemi2;
               enemies[3].Image = enemi3;
               enemies[4].Image = enemi1;
               enemies[5].Image = enemi1;
               enemies[6].Image = enemi3;
               enemies[7].Image = enemi3;
               enemies[8].Image = enemi2;
               enemies[9].Image = boss2;
            #endregion

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
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftTimer.Start();
                }
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
            
            if(e.KeyCode == Keys.Space)
            {
                if(!gameIsOver)
                {
                    if(pause)
                    {
                        StartTimers();
                        label1.Visible = false;
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width / 2 - 120, 150);
                        label1.Text = "PAUSED";
                        label1.Visible = true;
                        StopTimers();
                        pause = true;
                    }
                }
            }
        
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
                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        #endregion

        #region Moving enemies methods
        /// <summary>
        /// Create enemies method to move
        /// </summary>
        /// <param name="array"></param>
        /// <param name="speed"></param>
        private void MoveEnemies(PictureBox[] array, int speed)
        {
            
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null)
                    {
                        array[i].Visible = true;
                        array[i].Top += speed;

                        if (array[i].Top > this.Height)
                        {
                            array[i].Location = new Point((i + 1) * 50, -200);
                        }
                    }
                }
            
        }
        
        /// <summary>
        /// Create enemies timer to move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }
        #endregion

        #region collisions methods
        /// <summary>
        /// Collision detector
        /// </summary>
        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                for (int j = 0; j < munitions.Length; j++)
                {
                    if (munitions[j].Bounds.IntersectsWith(enemies[i].Bounds))
                    {
                        enemies[i].Location = new Point((i + 1) * 50, -100);
                    }
                    if(Player.Bounds.IntersectsWith(enemies[i].Bounds))
                    {
                        Player.Visible = false;
                        GameOver("");
                    }
                }            
            }
        }

        #region Timers on/off Methods

        /// <summary>
        /// Stop game
        /// </summary>
        /// <param name="str"></param>
        private void GameOver(String str)
        {
            label1.Text = str;
            label1.Location = new Point(this.Width / 2 - 120, 150);
            label1.Visible = true;
            
            ReplayButton.Location = new Point(this.Width / 2 - 120, 250);
            ReplayButton.Visible = true;

            EndButton.Location = new Point(this.Width / 2 - 120, 350);
            EndButton.Visible = true;
            
            StopTimers();
        }

        /// <summary>
        /// stop timers
        /// </summary>
        private void StopTimers()
        {
            MoveBackground.Stop();
            MoveEnemiesTimer.Stop();
            MunitionTimer.Stop();
            EnemiesMunitionTimer.Stop();
        }
        
        /// <summary>
        /// start timers
        /// </summary>
        private void StartTimers()
        {
            MoveBackground.Start();
            MoveEnemiesTimer.Start();
            MunitionTimer.Start();
            EnemiesMunitionTimer.Start();
        }
        
        #endregion

        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i=0; i < enemiesMunitions.Length; i++)
            {
                if(enemiesMunitions[i].Top < this.Height)
                {
                    enemiesMunitions[i].Visible = true;
                    enemiesMunitions[i].Top += enemiesMunitionSpeed; 
                }
                else
                {
                    enemiesMunitions[i].Visible = false;
                    int x = rand.Next(0, 10);
                    enemiesMunitions[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
            EnemiesMunitionCollision();
        }
    
        private void EnemiesMunitionCollision()
        {
            for(int i = 0; i< enemiesMunitions.Length; i++)
            {
                if(enemiesMunitions[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesMunitions[i].Visible = false;
                    Player.Visible = false;
                    GameOver("Game Over");

                }
            }

        }

        #endregion

        #region Buttons methods
        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        #endregion
    }
}
