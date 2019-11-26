using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;



namespace JakubKazimierskiGame
{
    public partial class Form1 : Form
    {
        
        


        #region Variables
        Random rand; //variable to create random positions 

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
        int money;
        int speedLvl;
        int bullets;
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
            //assigmnet of values to variables
            backgroundSpeed = 4;
            playerSpeed = 4;
            MunitionSpeed = 20;
            enemiesSpeed = 4;
            enemiesMunitionSpeed = 4;
            difficulty = 9;
            level = 1;
            score = 0;
            money = 0;
            speedLvl = 1;
            bullets = 1;
            pause = false;
            gameIsOver = false;
            rand = new Random();
            #endregion

            #region Creating picture  objects

            stars = new PictureBox[15];
                              
            munitions = new PictureBox[1];

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
        
            //creating enemies positions
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

            //creating postions of enemies bullets
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
            //methods to load pictures of enemies
            
           
           // Image enemi1 = Image.FromFile(@"images\\E1.png");
           
            Image enemi1 = JakubKazimierskiGame.Properties.Resources.E1;
            Image enemi2 = JakubKazimierskiGame.Properties.Resources.E2;
            Image enemi3 = JakubKazimierskiGame.Properties.Resources.E3___Kopia;

            Image boss1 = JakubKazimierskiGame.Properties.Resources.Boss1;
            Image boss2 = JakubKazimierskiGame.Properties.Resources.Boss2;

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
        /// <summary>
        /// Method of timer, which is responsible for moving background
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Timer responsible for moving left
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
        /// Timer responsible for moving right
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
        /// Method responsible for start moving
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event object</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if( speedLvl < 5)//improve speed
                    {
                        RightTimer.Interval = 5 - speedLvl;
                    }
                    RightTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (speedLvl < 5)//imporve speed 
                    {
                        LeftTimer.Interval = 5 - speedLvl;
                    }
                    LeftTimer.Start();
                }

                //start fire
                if (e.KeyCode == Keys.A)
                {
                    if (bullets <= 3) //more bullets, more intervals of shooting
                    {
                        MunitionTimer.Interval = 31 - 10 * bullets;
                    }
                    MunitionTimer.Start();
                    
                }
            }
        }

        /// <summary>
        ///Method responsible for stop moving
        /// </summary>
        /// <param name="sender">The even sender</param>
        /// <param name="e">The event object</param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightTimer.Stop();
            LeftTimer.Stop();

            //pause the game
            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
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

            //end fire
            if (e.KeyCode == Keys.S)
            {

                MunitionTimer.Stop();
                for (int i = 0; i < munitions.Length; i++)
                {
                    
                    munitions[i].Visible = false;
                    
                }

            }
        }
        #endregion

        #region Shooting method
    
        /// <summary>
        /// Method of timer, which is responsible for moving player ammo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Method responsible for rendering enemies 
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
        /// Method based on timer intervals responsible for moving enemies, also contains method responsible for collisions of object like bullets and ships
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            Collision();
            MoveEnemies(enemies, enemiesSpeed);
        }
        #endregion

        #region collisions methods
        /// <summary>
        /// Collision detector, detect bullets collisions with ships, and also ships collision to each other
        /// </summary>
        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                for (int j = 0; j < munitions.Length; j++)
                {
                   //logic of increasing values : level, money, score, bullet, speed
                    if (munitions[j].Bounds.IntersectsWith(enemies[i].Bounds))
                    {
                        score += 1;
                        scoreLabel.Text = (score < 10) ? "SCORE: 0" + score.ToString() : "SCORE: " + score.ToString();

                        if (score % 30 == 0)
                        {
                            level += 1;
                            levelLabel.Text = (level < 10) ? "LEVEL: 0" + level.ToString() : "LEVEL: " + level.ToString();

                            if (enemiesSpeed <= 10 && enemiesMunitionSpeed <=10 && difficulty >= 0)
                            {
                                difficulty--;
                                enemiesSpeed++;
                                enemiesMunitionSpeed++;
                            }

                            if(level == 10)
                            {
                                GameOver("You Won Star Battle!");
                            }
                        }
                        if (score % 5 == 0)
                        {
                            money += 1;
                            MoneyLabel.Text = (money < 10) ? "MONEY: 0" + money.ToString() : "MONEY: " + money.ToString();




                            if (money % 5 == 0)
                            {
                                speedLvl += 1;
                                if (speedLvl < 5)
                                {
                                    SpeedLvlLabel.Text = (speedLvl < 10) ? "SPEED: 0" + speedLvl.ToString() : "SPEED: " + speedLvl.ToString();
                                }
                            }
                            if (money % 20 == 0)
                            {
                                bullets += 1;
                                if (bullets <= 3)
                                {

                                    BulletsLabel.Text = (bullets < 10) ? "BULLETS: 0" + bullets.ToString() : "BULLETS: " + bullets.ToString();
                                }
                            }
                        }
                        //rendering enemies after collision
                        enemies[i].Location = new Point((i + 1) * 50, -100);
                    }
                    
                }
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    Player.Visible = false;
                    GameOver("GAME OVER");
                }

            }
        }

        #region Timers on/off Methods

        /// <summary>
        /// Stop game means stopping each timer, and also display on screen text and buttons
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
        /// stop timers method, timers are responsible for rendering graphic
        /// </summary>
        private void StopTimers()
        {
            MoveBackground.Stop();
            RightTimer.Stop();
            LeftTimer.Stop();
            MoveEnemiesTimer.Stop();
            MunitionTimer.Stop();
            EnemiesMunitionTimer.Stop();
        }
        
        /// <summary>
        /// start timers method
        /// </summary>
        private void StartTimers()
        {
            MoveBackground.Start();
            RightTimer.Start();
            LeftTimer.Start();
            MoveEnemiesTimer.Start();
            MunitionTimer.Start();
            EnemiesMunitionTimer.Start();
        }
        
        #endregion

        /// <summary>
        /// method responsible for rendering enemies ammo, method based on timer, and connected with collisions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            //with next levels, difficulty decrease itself, but it cause more bullets from enemies, so it is improving of difficulty in game
            for (int i=0; i < enemiesMunitions.Length - difficulty; i++)
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
    
        /// <summary>
        /// method responsible for collision enemies ammo with player ship
        /// </summary>
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
        
        /// <summary>
        /// method responsible for using replay button, program didn't render proper name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
            StopTimers();
            StartTimers();
        }
        /// <summary>
        /// method responsible for using end button, program didn't render proper name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        #endregion
    }
}
