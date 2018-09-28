﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _180927_Černý1
{
    public partial class Form1 : Form
    {
        #region Init

        //Výchozí pozice tlačítek
        static List<Button> _buttonyList       = new List<Button>();
        static List<Point>  _vychoziPoziceList = new List<Point>();

        static int _vychoziVelikost;

        public Form1()
        {
            InitializeComponent();

            //Výchozí velikost - šířka prostředního tlačítka
            _vychoziVelikost = btn5.Size.Width;

            //Uložení všech tlačítek do seznamu
            _buttonyList = new List<Button> {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9};

            //Uložení výchozí pozice každého tlačítka
            foreach (var button in _buttonyList)
            {
                _vychoziPoziceList.Add(new Point(button.Location.X, button.Location.Y));
            }
        }
        #endregion

        #region Můj další kód

        // ----- SMĚRY ----- //
        public enum Smer
        {
            Vlevo,
            Vpravo,
            Nahoru,
            Dolu
        }

        // ----- POSUN TLAČÍTEK ----- //
        public void PosunTlacitka(Smer smer, params Button[] buttony)
        {
            foreach (var button in buttony)
            {
                switch (smer)
                {
                    case Smer.Vlevo:
                        button.Left -= button.Width;
                        break;
                    case Smer.Vpravo:
                        button.Left += button.Width;
                        break;
                    case Smer.Nahoru:
                        button.Top -= button.Height;
                        break;
                    case Smer.Dolu:
                        button.Top += button.Height;
                        break;
                }
            }
        }

        // ----- ZMĚNA VELIKOSTÍ ----- //
        public void ZvetsiTlacitka(Smer smer, params Button[] buttony)
        {
            foreach (var button in buttony)
            {
                switch (smer)
                {
                    case Smer.Vlevo:
                        button.Width += _vychoziVelikost;
                        button.Left -= _vychoziVelikost;
                        break;
                    case Smer.Vpravo:
                        button.Width += _vychoziVelikost;
                        break;
                    case Smer.Nahoru:
                        button.Height += _vychoziVelikost;
                        button.Top -= _vychoziVelikost;
                        break;
                    case Smer.Dolu:
                        button.Height += _vychoziVelikost;
                        break;
                }
            }
        }

        // ----- OZNAČENÍ PO NAJETÍ MYŠI ----- //
        public void HighlightOn(Color barva, params Button[] buttony)
        {
            foreach (var button in buttony)
            {
                button.BackColor = barva;
            }
        }

        public void HighlightOffAll()
        {
            foreach (var button in _buttonyList)
            {
                button.BackColor = SystemColors.Control;
                button.UseVisualStyleBackColor = true;
            }
        }
        #endregion

        #region Posunovací tlačítka prostřední - posouvají sebe
        // ----- POSUNOVACÍ PROSTŘEDNÍ TLAČÍTKA ----- //
        // Jako číselník mobilu:
        // 1-2-3
        // 4-5-6
        // 7-8-9

        private void btn1_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn1);
            PosunTlacitka(Smer.Vlevo, btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn3);
            PosunTlacitka(Smer.Vpravo, btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Vlevo, btn4);
        }

        //Prostřední tlačítko - Reset pozic a velikostí
        private void btn5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _buttonyList.Count; i++)
            {
                _buttonyList[i].Location = _vychoziPoziceList[i];
                _buttonyList[i].Size = new Size(_vychoziVelikost, _vychoziVelikost);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Vpravo, btn6); 
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn7);
            PosunTlacitka(Smer.Vlevo, btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn9);
            PosunTlacitka(Smer.Vpravo, btn9);
        }
        #endregion

        #region Posunovací tlačítka rohová vnější - posouvají prostřední tlačítka
        // ----- POSUNOVACÍ ROHOVÁ TLAČÍTKA VNĚJŠÍ ----- //
        private void btnPosun1_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn1, btn2, btn3);
            PosunTlacitka(Smer.Vlevo, btn1, btn4, btn7);
        }

        private void btnPosun2_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn1, btn2, btn3);
        }

        private void btnPosun3_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Nahoru, btn1, btn2, btn3);
            PosunTlacitka(Smer.Vpravo, btn3, btn6, btn9);
        }

        private void btnPosun4_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Vlevo, btn1, btn4, btn7);
        }

        private void btnPosun6_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Vpravo, btn3, btn6, btn9);
        }

        private void btnPosun7_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn7, btn8, btn9);
            PosunTlacitka(Smer.Vlevo, btn1, btn4, btn7);
        }

        private void btnPosun8_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn7, btn8, btn9);
        }

        private void btnPosun9_Click(object sender, EventArgs e)
        {
            PosunTlacitka(Smer.Dolu, btn7, btn8, btn9);
            PosunTlacitka(Smer.Vpravo, btn3, btn6, btn9);
        }

        #endregion

        #region Zvětšovačí tlačítka rohová vnitřní
        // ----- ZVĚTŠOVACÍ TLAČÍTKA VNITŘNÍ ----- //
        private void btnZvetsi1_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn1, btn2, btn3);
            ZvetsiTlacitka(Smer.Vlevo, btn1, btn4, btn7);
        }

        private void btnZvetsi2_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn1, btn2, btn3);
        }

        private void btnZvetsi3_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn1, btn2, btn3);
            ZvetsiTlacitka(Smer.Vpravo, btn3, btn6, btn9);
        }

        private void btnZvetsi4_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vlevo, btn1, btn4, btn7);
        }

        private void btnZvetsi6_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vpravo, btn3, btn6, btn9);
        }

        private void btnZvetsi7_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vlevo, btn1, btn4, btn7);
            ZvetsiTlacitka(Smer.Dolu, btn7, btn8, btn9);
        }

        private void btnZvetsi8_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Dolu, btn7, btn8, btn9);
        }

        private void btnZvetsi9_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vpravo, btn3, btn6, btn9);
            ZvetsiTlacitka(Smer.Dolu, btn7, btn8, btn9);
        }
        #endregion

        #region Zvětšovačí tlačítka rohová prostřední
        // ----- ZVĚTŠOVACÍ ROHOVÁ PROSTŘEDNÍ TLAČÍTKA ----- //
        private void btnZvetsiSingle1_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn1);
            ZvetsiTlacitka(Smer.Vlevo, btn1);
        }

        private void btnZvetsiSingle2_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn2);
        }

        private void btnZvetsiSingle3_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Nahoru, btn3);
            ZvetsiTlacitka(Smer.Vpravo, btn3);
        }

        private void btnZvetsiSingle4_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vlevo, btn4);
        }

        private void btnZvetsiSingle6_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Vpravo, btn6);
        }

        private void btnZvetsiSingle7_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Dolu, btn7);
            ZvetsiTlacitka(Smer.Vlevo, btn7);
        }

        private void btnZvetsiSingle8_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Dolu, btn8);
        }

        private void btnZvetsiSingle9_Click(object sender, EventArgs e)
        {
            ZvetsiTlacitka(Smer.Dolu, btn9);
            ZvetsiTlacitka(Smer.Vpravo, btn9);
        }
        #endregion

        #region Highlight eventy pro zvětšovací tlačítka rohová vnitřní
        // ----- HIGHLIGHTY PRO ZVĚTŠOVACÍ TLAČÍTKA ROHOVÁ VNÍTŘNÍ ----- //
        private void btnZvetsi1_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1, btn2, btn3, btn4, btn7);
        }

        private void btnZvetsi1_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi2_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1, btn2, btn3);
        }

        private void btnZvetsi2_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi3_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1, btn2, btn3, btn6, btn9);
        }

        private void btnZvetsi3_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi4_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1, btn4, btn7);
        }

        private void btnZvetsi4_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi6_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn3, btn6, btn9);
        }

        private void btnZvetsi6_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi7_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1, btn4, btn7, btn8, btn9);
        }

        private void btnZvetsi7_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi8_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn7, btn8, btn9);
        }

        private void btnZvetsi8_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsi9_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn3, btn6, btn7, btn8, btn9);
        }

        private void btnZvetsi9_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        #endregion

        #region Highligh eventy pro zvětšovací tlačítka rohová prostřední
        // ----- HIGHLIGHTY PRO ZVĚTŠOVACÍ TLAČÍTKA ROHOVÁ PROSTŘEDNÍ ----- //
        private void btnZvetsiSingle1_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn1);
        }

        private void btnZvetsiSingle1_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle2_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn2);
        }

        private void btnZvetsiSingle2_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle3_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn3);
        }

        private void btnZvetsiSingle3_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle4_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn4);
        }

        private void btnZvetsiSingle4_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle6_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn6);
        }

        private void btnZvetsiSingle6_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle7_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn7);
        }

        private void btnZvetsiSingle7_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle8_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn8);
        }

        private void btnZvetsiSingle8_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnZvetsiSingle9_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Aqua, btn9);
        }

        private void btnZvetsiSingle9_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }


        #endregion

        #region Highlight eventy pro posunovací tlačítka rohová vnější
        // ----- HIGHLIGHTY PRO POSUNOVACÍ TLAČÍTKA ROHOVÁ VNĚJŠÍ ----- //
        private void btnPosun1_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn1, btn2, btn3, btn4, btn7);
        }

        private void btnPosun1_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun2_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn1, btn2, btn3);
        }

        private void btnPosun2_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun3_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn1, btn2, btn3, btn6, btn9);
        }

        private void btnPosun3_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun4_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn1, btn4, btn7);
        }

        private void btnPosun4_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun6_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn3, btn6, btn9);
        }

        private void btnPosun6_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun7_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn1, btn4, btn7, btn8, btn9);
        }

        private void btnPosun7_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun8_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn7, btn8, btn9);
        }

        private void btnPosun8_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }

        private void btnPosun9_MouseEnter(object sender, EventArgs e)
        {
            HighlightOn(Color.Yellow, btn3, btn6, btn7, btn8, btn9);
        }

        private void btnPosun9_MouseLeave(object sender, EventArgs e)
        {
            HighlightOffAll();
        }
        #endregion
    }
}