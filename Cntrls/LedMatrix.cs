using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class LedMatrix : UserControl
    {
        public enum Grafica
        {
            Graphic1,
            Graphic2,
            Graphic3,
            Graphic4,

            All
        } 

        private StatusLeds[][] AllLeds = null;

        private Grafica _SelectedGraphic = Grafica.Graphic1;
        private Grafica _CurrentGraphic = Grafica.Graphic1;
        private int _CurrentGraphicStep = 0;

        private StatusLeds.eStatusLed _LedsOnColor = StatusLeds.eStatusLed.GRAY;
        private StatusLeds.eStatusLed _LedsOffColor = StatusLeds.eStatusLed.BLACK;

        private char[] _CharToShow;
        public char[] CharToShow
        {
            get { return _CharToShow; }
            set { _CharToShow = value; }
        }

        public StatusLeds.eStatusLed LedsOnColor
        {
            get { return _LedsOnColor; }
            set { _LedsOnColor = value; }
        }
        public StatusLeds.eStatusLed LedsOffColor
        {
            get { return _LedsOffColor; }
            set { _LedsOffColor = value; }
        }

        public LedMatrix()
        {
            InitializeComponent();
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            AllLeds = new StatusLeds[10][];

            AllLeds[0] = new StatusLeds[40];
            AllLeds[1] = new StatusLeds[40];
            AllLeds[2] = new StatusLeds[40];
            AllLeds[3] = new StatusLeds[40];
            AllLeds[4] = new StatusLeds[40];
            AllLeds[5] = new StatusLeds[40];
            AllLeds[6] = new StatusLeds[40];
            AllLeds[7] = new StatusLeds[40];
            AllLeds[8] = new StatusLeds[40];
            AllLeds[9] = new StatusLeds[40];

            for (int l = 0; l < 10; l++)
                for (int c = 0; c < 40; c++)
                {
                    StatusLeds Led = new StatusLeds();
                    Led.SetLedStatus(_LedsOffColor);

                    Led.Size = new Size(20, 20);
                    Led.Location = new Point((Led.Width * c), (Led.Height * l)); 

                    AllLeds[l][c] = Led;

                    Controls.Add(Led);
                }
        }

        public void SetChar(char ToShow)
        {
            byte[][] Pattern; 

            switch (ToShow)
            {
                case 'A': Pattern = MatriciGrafiche.Pattern_A;
                    break;

                case 'B': Pattern = MatriciGrafiche.Pattern_B;
                    break;

                case 'C': Pattern = MatriciGrafiche.Pattern_C;
                    break;

                case 'D': Pattern = MatriciGrafiche.Pattern_D;
                    break;

                case 'E': Pattern = MatriciGrafiche.Pattern_E;
                    break;

                case 'F': Pattern = MatriciGrafiche.Pattern_F;
                    break;

                case 'G': Pattern = MatriciGrafiche.Pattern_G;
                    break;

                case 'H': Pattern = MatriciGrafiche.Pattern_H;
                    break;

                case 'I': Pattern = MatriciGrafiche.Pattern_I;
                    break;

                case 'L': Pattern = MatriciGrafiche.Pattern_L;
                    break;

                case 'M': Pattern = MatriciGrafiche.Pattern_M;
                    break;

                case 'N': Pattern = MatriciGrafiche.Pattern_N;
                    break;

                case 'O': Pattern = MatriciGrafiche.Pattern_O;
                    break;

                case 'P': Pattern = MatriciGrafiche.Pattern_P;
                    break;

                case 'Q': Pattern = MatriciGrafiche.Pattern_Q;
                    break;

                case 'R': Pattern = MatriciGrafiche.Pattern_R;
                    break;

                case 'S': Pattern = MatriciGrafiche.Pattern_S;
                    break;

                case 'T': Pattern = MatriciGrafiche.Pattern_T;
                    break;

                case 'U': Pattern = MatriciGrafiche.Pattern_U;
                    break;

                case 'V': Pattern = MatriciGrafiche.Pattern_V;
                    break;

                case 'Z': Pattern = MatriciGrafiche.Pattern_Z;
                    break;

                case ' ': Pattern = MatriciGrafiche.Pattern_ALL_OFF;
                    break;

                default:
                    return;
            }

            SetLedsPattern(Pattern);
        }

        private void SetLedsPattern(byte[][] Pattern)
        {  
            for (int l = 0; l < 10; l++)
                for (int c = 0; c < 40; c++)
                    if (Pattern[l][c] == 1)
                        AllLeds[l][c].SetLedStatus(_LedsOnColor);
                    else
                        AllLeds[l][c].SetLedStatus(_LedsOffColor); 
        }

        public void StartGraphic(Grafica ToSet)
        {
            _SelectedGraphic = ToSet;
            _CurrentGraphic = ToSet;
            _CurrentGraphicStep = 0;
            _CurrentStepG4 = 0;
            tmrGraphicRefresh.Enabled = true;
        }

        public void StopGraphic()
        { 
            tmrGraphicRefresh.Enabled = false;
        }

        private int _CurrentStepG4 = 0;
        private bool ManageGraphic4()
        {
            //Pattern
            byte[][] cPattern = (byte[][])MatriciGrafiche.Pattern_BASE_3CAR.Clone();
            //Carattere corrente
            byte[][] c1 = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep]).Clone();
            //Prossimo carattere         
            byte[][] c2 = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep + 1]).Clone();
            byte[][] c3 = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep + 2]).Clone();
            byte[][] c4 = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep + 3]).Clone();
            byte[][] cNext;

            if (_CurrentGraphicStep + 4 < _CharToShow.Length)
                cNext = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep + 4]).Clone();
            else
            {
                _CurrentGraphicStep = 0;
                cNext = (byte[][])MatriciGrafiche.GetCharPattern(_CharToShow[_CurrentGraphicStep]).Clone();
            } 
            
            for (int l = 0; l < 10; l++)
                for (int c = 0, cc = 0; c < 40; c++, cc++) 
                    try
                    { 
                        if (cc >= 10)
                            cc = 0;

                        if (c >= 10 && c < 20)
                            if (cc + _CurrentStepG4 < 10)
                                cPattern[l][c] = c2[l][cc + _CurrentStepG4];
                            else
                                cPattern[l][c] = c3[l][cc + _CurrentStepG4 - 10];
                        else if (c >= 20 && c < 30)
                            if (cc + _CurrentStepG4 < 10)
                                cPattern[l][c] = c3[l][cc + _CurrentStepG4];
                            else
                                cPattern[l][c] = c4[l][cc + _CurrentStepG4 - 10];
                        else if (c >= 30)
                            if (cc + _CurrentStepG4 < 10)
                                cPattern[l][c] = c4[l][cc + _CurrentStepG4];
                            else
                                cPattern[l][c] = cNext[l][cc + _CurrentStepG4 - 10];
                        else
                            if (cc + _CurrentStepG4 < 10)
                                cPattern[l][c] = c1[l][cc + _CurrentStepG4];
                            else
                                cPattern[l][c] = c2[l][cc + _CurrentStepG4 - 10];
                    }
                    catch (Exception Ex)
                    {
                        System.Diagnostics.Debug.Assert(true, Ex.Message + "  " + Ex.StackTrace);
                        MessageBox.Show("c: " + c.ToString() + "  cc:" + cc.ToString() + "  cStep:" + _CurrentStepG4.ToString() + " " + Ex.Message + "  " + Ex.StackTrace);
                        return false;
                    } 

            SetLedsPattern(cPattern);

            _CurrentStepG4++;

            if (_CurrentStepG4 == 10)
            {
                _CurrentStepG4 = 0;
                _CurrentGraphicStep++;
                return false;
            }

            return false;
        }


        bool RefreshRunning = false;
        private void RefreshGraphic(object sender, EventArgs e)
        {
            bool ChangeGraphic = false;

            if (RefreshRunning)
                return;

            RefreshRunning = true;

            SuspendLayout();

            switch (_CurrentGraphic)
            {
                case Grafica.All:
                case Grafica.Graphic1:

                    switch (_CurrentGraphicStep)
                    {
                        case 0:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic1_Step2);
                            _CurrentGraphicStep = 1;
                            ChangeGraphic = false;
                            break;

                        case 1:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic1_Step3);
                            _CurrentGraphicStep = 2;
                            ChangeGraphic = false;
                            break;

                        case 2:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic1_Step4);
                            _CurrentGraphicStep = 3;
                            ChangeGraphic = false;
                            break;

                        case 3:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic1_Step5);
                            _CurrentGraphicStep = 4;
                            ChangeGraphic = false;
                            break;

                        case 4:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic1_Step1);
                            _CurrentGraphicStep = 0;
                            ChangeGraphic = true;
                            break;
                    }

                    break;

                case Grafica.Graphic2:

                    switch (_CurrentGraphicStep)
                    {
                        case 0:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic2_Chess_POS);
                            _CurrentGraphicStep = 1;
                            ChangeGraphic = false;
                            break;

                        case 1:
                            SetLedsPattern(MatriciGrafiche.Pattern_Graphic2_Chess_NEG);
                            _CurrentGraphicStep = 0;
                            ChangeGraphic = true;
                            break;
                    }

                    break; 

                case Grafica.Graphic3:

                    if (_CurrentGraphicStep >= _CharToShow.Length)
                    {
                        ChangeGraphic = true;
                        break;
                    }

                    SetChar(_CharToShow[_CurrentGraphicStep]);
                    _CurrentGraphicStep++;
                    ChangeGraphic = false;

                    break;

                case Grafica.Graphic4:
                    ChangeGraphic = ManageGraphic4();

                    //if (ChangeGraphic)
                    //{
                    //    _CurrentGraphicStep = 0;
                    //    _CurrentStepG4 = 0;
                    //}

                    break;
            }

            if (_SelectedGraphic == Grafica.All && ChangeGraphic)
            {
                _CurrentGraphicStep = 0;

                switch (_CurrentGraphic)
                {
                    case Grafica.All:
                    case Grafica.Graphic1:
                        _CurrentGraphic = Grafica.Graphic2;
                        break;

                    case Grafica.Graphic2:
                        _CurrentGraphic = Grafica.Graphic3;
                        break;

                    case Grafica.Graphic3:
                        _CurrentGraphic = Grafica.Graphic1;
                        break;
                }
            }

            ResumeLayout(true);

            RefreshRunning = false;
        }
    }

   internal static class MatriciGrafiche
    {
       internal static readonly byte[][] Pattern_BASE_3CAR = new byte[][] //40 x 10
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

       internal static readonly byte[][] Pattern_ALL_OFF = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_ALL_ON = new byte[][] 
            {
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

       #region Alfabeto

       internal static byte[][] GetCharPattern(char c)
       {
           switch (c)
           {
               case 'A': return Pattern_A;
               case 'B': return Pattern_B; 
               case 'C': return Pattern_C; 
               case 'D': return Pattern_D; 
               case 'E': return Pattern_E; 
               case 'F': return Pattern_F; 
               case 'G': return Pattern_G; 
               case 'H': return Pattern_H; 
               case 'I': return Pattern_I; 
               case 'L': return Pattern_L; 
               case 'M': return Pattern_M; 
               case 'N': return Pattern_N; 
               case 'O': return Pattern_O; 
               case 'P': return Pattern_P; 
               case 'Q': return Pattern_Q; 
               case 'R': return Pattern_R; 
               case 'S': return Pattern_S; 
               case 'T': return Pattern_T; 
               case 'U': return Pattern_U;
               case 'V': return Pattern_V;
               case 'Z': return Pattern_Z;

               case 'a': return Pattern_a;
               case 'b': return Pattern_b;
               case 'c': return Pattern_c;
               case 'd': return Pattern_d;
               case 'e': return Pattern_e;
               case 'f': return Pattern_f;
               case 'g': return Pattern_g;
               case 'h': return Pattern_h;
               case 'i': return Pattern_i;
               case 'l': return Pattern_l;
               case 'm': return Pattern_m;
               case 'n': return Pattern_n;
               case 'o': return Pattern_o;
               case 'p': return Pattern_p;
               case 'q': return Pattern_q;
               case 'r': return Pattern_r;
               case 's': return Pattern_s;
               case 't': return Pattern_t;
               case 'u': return Pattern_u;
               case 'v': return Pattern_v;
               case 'z': return Pattern_z;

               case '0': return Pattern_0;
               case '1': return Pattern_1;
               case '2': return Pattern_2;
               case '3': return Pattern_3;
               case '4': return Pattern_4;
               case '5': return Pattern_5;
               case '6': return Pattern_6;
               case '7': return Pattern_7;
               case '8': return Pattern_8;
               case '9': return Pattern_9;

               case  '-': return Pattern_Line;

               case ' ': default: return Pattern_ALL_OFF;
           }
       }

       internal static readonly byte[][] Pattern_A = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_B = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_C = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_D = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_E = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_F = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_G = new byte[][]  
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_H = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            };

       internal static readonly byte[][] Pattern_I = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_L = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_M = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 1, 0, 0, 1, 1, 1, 0 },
                new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 1, 1, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_N = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 1, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 1, 1, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 1, 1, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 1, 1, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 1, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_O = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_P = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_Q = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 1, 0, 1, 1, 0 },
                new byte [] { 0, 1, 1, 0, 0, 0, 1, 1, 1, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 1, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_R = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_S = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_T = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_U = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_V = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_Z = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_a = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_b = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_c = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_d = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_e = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_f = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_g = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_h = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_i = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_l = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_m = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 0, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_n = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_o = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_p = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_q = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_r = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_s = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_t = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_u = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

       internal static readonly byte[][] Pattern_v = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            }; 

       internal static readonly byte[][] Pattern_z = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

        #endregion

       #region Numeri

       internal static readonly byte[][] Pattern_1 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_2 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_3 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_4 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_5 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_6 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_7 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_8 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_9 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_0 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       #endregion

       #region Punteggiatura 

       internal static readonly byte[][] Pattern_Line = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       #endregion

       #region Graphic1

       internal static readonly byte[][] Pattern_Graphic1_Step1 = new byte[][] 
            {
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new byte [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 
                new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

       internal static readonly byte[][] Pattern_Graphic1_Step2 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_Graphic1_Step3 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new byte [] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_Graphic1_Step4 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       internal static readonly byte[][] Pattern_Graphic1_Step5 = new byte[][] 
            {
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

       #endregion

       #region Graphic2 

       internal static readonly byte[][] Pattern_Graphic2_Chess_POS = new byte[][] 
            {
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }, 
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }
            };

       internal static readonly byte[][] Pattern_Graphic2_Chess_NEG = new byte[][] 
            {
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                new byte [] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, 
                new byte [] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }
            };

       #endregion

   }
}
