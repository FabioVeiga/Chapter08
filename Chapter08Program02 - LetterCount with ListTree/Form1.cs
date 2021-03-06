﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter08Program02
{
    public partial class Form1 : Form
    {
        private const int MAXLETTERS = 26; //Symbolic constants
        private const int MAXCHARS = MAXLETTERS;
        private const int LETTERA = 65;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            char oneLetter;
            int index;
            int i;
            int length;
            int[] count = new int[MAXLETTERS];
            string input;
            string buff;

            length = txtInput.Text.Length;
            if (length == 0)
            {
                MessageBox.Show("You need to enter some text...", "Missing Input");
                txtInput.Focus();
                return;
            }

            //ajust by myself
            lsvOutput.Items.Clear();

            input = txtInput.Text;
            input = input.ToUpper();

            for (i = 0; i < input.Length; i++)
            {
                oneLetter = input[i]; //GEt a character
                index = oneLetter - LETTERA; //Meke into an index
                if (index < 0 || index > MAXCHARS) //A letters??
                    continue; //Nope
                count[index]++;//Yep
            }

            ListViewItem which;
            for (i = 0; i < MAXLETTERS; i++)
            {
                oneLetter = (char)(i + LETTERA);
                which = new ListViewItem(oneLetter.ToString());
                which.SubItems.Add(count[i].ToString());
                lsvOutput.Items.Add(which);
            }
        }
    }
}
