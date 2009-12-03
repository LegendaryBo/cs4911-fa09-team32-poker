using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Timers;
using System.Windows.Threading;
using System.Threading;

namespace PokerSimulationUI
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        private PokerSimulation.Session _controller = new PokerSimulation.Session();
        private PokerSimulation.Trial _currentTrial;
        private const string SESSION_ID = "Session ID";
        private const string SUBJECT_ID = "Subject ID";
        private const string INPUT_DEFAULT = "Type your answer and press ENTER.";
		private string _userInput = null;

        public View()
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
        }

        private void TxtBx_SubjectID_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
			if(TxtBx_SubjectID.Text == SUBJECT_ID)
			{
        		TxtBx_SubjectID.Text = "";
			}
        }

        private void TxtBx_SubjectID_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	if(TxtBx_SubjectID.Text == "")
			{
				TxtBx_SubjectID.Text = SUBJECT_ID;
			}
        }

        private void TxtBx_SessionID_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	if(TxtBx_SessionID.Text == SESSION_ID)
			{
        		TxtBx_SessionID.Text = "";
			}
        }

        private void TxtBx_SessionID_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	if(TxtBx_SessionID.Text == "")
			{
				TxtBx_SessionID.Text = SESSION_ID;
			}
        }

        private void Btn_StartSess_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string filename = TxtBx_SubjectID.Text.Trim() + "_" + TxtBx_SessionID.Text.Trim();

            if (_controller.TryOpenFile(filename + ".in") ||
                _controller.TryOpenFile(filename + ".txt") ||
                _controller.TryOpenFile(filename + ".sim"))
            {
                DoTrial();
            }
            else
            {
                MessageBox.Show("Sorry, but " + filename + " is invalid.");
            }
        }

        private void Btn_ChooseFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".in";                                                      // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt|Simulation Input File (.in)|*.in|Simulation Script (.sim)|*.sim"; // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                if (ext == ".in" || ext == ".txt" || ext == ".sim")
                {
                    if (_controller.TryOpenFile(filename))
                    {
                        DoTrial();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, but " + filename + " is invalid.");
                }
            }
        }

        private void HideWelcomeScreen()
        {
            Grid_Welcome_Content.Visibility = Visibility.Hidden;
        }

        private void ShowWelcomeScreen()
        {
            Grid_Welcome_Content.Visibility = Visibility.Visible;
            TxtBx_SessionID.Text = SESSION_ID;
            TxtBx_SubjectID.Text = SUBJECT_ID;
        }
		
		private void HideTrialScreen()
		{
			Uni_Grid_Cards.Visibility = Visibility.Hidden;
            TxtBx_Subj_Input.Visibility = Visibility.Hidden;
		}
		
		private void ShowTrialScreen()
		{
			Uni_Grid_Cards.Visibility = Visibility.Visible;
		}

        private void DoTrial()
        {
            HideWelcomeScreen();

            Thread fix = new Thread(ShowFixation);
            fix.SetApartmentState(ApartmentState.STA);
            fix.Start();
            fix.Join(Properties.Settings.Default.FixationTime);

            ShowCards();
        }

        private void ShowCards()
        {
            _currentTrial = _controller.GetNextTrial();

            if (_currentTrial != null)
            {
                string[] cardLabels = _currentTrial.PokerHand.ToString().Split(",".ToCharArray());

                if (cardLabels.Length == 5)
                {
                    Rect_Card0.Fill = (Brush)FindResource(cardLabels[0].Trim());
                    Rect_Card1.Fill = (Brush)FindResource(cardLabels[1].Trim());
                    Rect_Card2.Fill = (Brush)FindResource(cardLabels[2].Trim());
                    Rect_Card3.Fill = (Brush)FindResource(cardLabels[3].Trim());
                    Rect_Card4.Fill = (Brush)FindResource(cardLabels[4].Trim());
                    Rect_Card5.Fill = (Brush)FindResource("BACK");
                    Rect_Card6.Fill = (Brush)FindResource("BACK");
                }
                else if (cardLabels.Length == 6)
                {
                    Rect_Card0.Fill = (Brush)FindResource(cardLabels[0].Trim());
                    Rect_Card1.Fill = (Brush)FindResource(cardLabels[1].Trim());
                    Rect_Card2.Fill = (Brush)FindResource(cardLabels[2].Trim());
                    Rect_Card3.Fill = (Brush)FindResource(cardLabels[3].Trim());
                    Rect_Card4.Fill = (Brush)FindResource(cardLabels[4].Trim());
                    Rect_Card5.Fill = (Brush)FindResource(cardLabels[5].Trim());
                    Rect_Card6.Fill = (Brush)FindResource("BACK");
                }
                else if (cardLabels.Length == 7)
                {
                    Rect_Card0.Fill = (Brush)FindResource(cardLabels[0].Trim());
                    Rect_Card1.Fill = (Brush)FindResource(cardLabels[1].Trim());
                    Rect_Card2.Fill = (Brush)FindResource(cardLabels[2].Trim());
                    Rect_Card3.Fill = (Brush)FindResource(cardLabels[3].Trim());
                    Rect_Card4.Fill = (Brush)FindResource(cardLabels[4].Trim());
                    Rect_Card5.Fill = (Brush)FindResource(cardLabels[5].Trim());
                    Rect_Card6.Fill = (Brush)FindResource(cardLabels[6].Trim());
                }

                TxtBx_Subj_Input.Text = "";
                TxtBx_Subj_Input.Visibility = Visibility.Visible;

                ShowTrialScreen();

                TxtBx_Subj_Input.Focus();
            }
        }

        private void ShowFixation()
        {
            Fixation myFixScreen = new Fixation();
            myFixScreen.Activate();
            myFixScreen.Focus();
        }

        private void TxtBx_Subj_Input_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	if(e.Key == Key.Enter && TxtBx_Subj_Input.Text.Trim() != "")
			{
				_userInput = TxtBx_Subj_Input.Text.Trim();
                DoTrial();
			}
        }
    }
}
