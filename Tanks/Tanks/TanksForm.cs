﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    
    public partial class TanksForm : Form
    {
        public static Random rnd = new Random();
        public static int sizeCell = 25;
        private AboutObjectsForm form;
        private Game newGame;

        public TanksForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.Width = 500;
            map.Height = 500;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
            if (settings.DialogResult==DialogResult.OK)
            {
                newGame = new Game(settings.ApplesCount, settings.TanksCount);
                switch (settings.Speed)
                {
                    case 2: GameStep.Interval = 50;
                        break;
                    case 1:
                        GameStep.Interval = 60;
                        break;
                    case 0:
                        GameStep.Interval = 70;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }
            ShotsStep.Interval = GameStep.Interval / 2;
            btnStats.Enabled = true;
            newGame.Start(this);
            GameStep.Enabled = true;
            ShotsStep.Enabled = true;
        }

        private void GameStep_Tick(object sender, EventArgs e)
        {
            newGame.Step();
            ctlScore.Text = newGame.Score.ToString();
            if (newGame.gameOver && newGame.Delta==30)
            {
                GameStep.Enabled = false;
                ShotsStep.Enabled = false;
                StatsStep.Enabled = false;
                newGame.GameOver();
            }
            
        }

        private void TanksForm_KeyDown(object sender, KeyEventArgs e)
        {
            newGame.OnKeyPress(e.KeyCode);
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            StatsStep.Interval = GameStep.Interval * 6;
            StatsStep.Enabled = true;
            form = new AboutObjectsForm();
            form.Show();
            form.FormClosed += Form_FormClosed;
            btnStats.Enabled = false;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStats.Enabled = true;
        }

        private void RefreshStats()
        {
            form.ctlAboutObjects.Rows.Clear();
            form.ctlAboutObjects.Rows.Add(newGame.kolobok.GetType(), newGame.kolobok.X, newGame.kolobok.Y);

            for (int i = 0; i < newGame.Tanks.Count; i++)
            {
                form.ctlAboutObjects.Rows.Add(newGame.Tanks[i].GetType(), newGame.Tanks[i].X, newGame.Tanks[i].Y);
            }

            for (int i = 0; i < newGame.Apples.Count; i++)
            {
                form.ctlAboutObjects.Rows.Add(newGame.Apples[i].GetType(), newGame.Apples[i].X, newGame.Apples[i].Y);
            }

            for (int i = 0; i < newGame.ShotsKolobok.Count; i++)
            {
                form.ctlAboutObjects.Rows.Add(newGame.ShotsKolobok[i].GetType(), newGame.ShotsKolobok[i].X, newGame.ShotsKolobok[i].Y);
            }

            for (int i = 0; i < newGame.ShotsTanks.Count; i++)
            {
                form.ctlAboutObjects.Rows.Add(newGame.ShotsTanks[i].GetType(), newGame.ShotsTanks[i].X, newGame.ShotsTanks[i].Y);
            }
        }

        private void StatsStep_Tick(object sender, EventArgs e)
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    RefreshStats();
                }
            }
        }

        private void ShotsStep_Tick(object sender, EventArgs e)
        {
            newGame.StepOfShots();
        }
    }
}
