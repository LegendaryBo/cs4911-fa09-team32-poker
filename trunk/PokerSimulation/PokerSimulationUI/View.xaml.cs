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
        private DispatcherTimer _timer;
        private DateTime _timeStamp;
        private DateTime _firstKeyPress;
        private TimeSpan _timeSpan;
        private bool _showFeedback = Properties.Settings.Default.ShowFeedback;
        private static Dictionary<PokerSimulation.HandRank, string> _handStrings;

        public View()
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.FixationTime);
            _timer.Tick += new EventHandler(Timer_Tick);
            LoadHandStrings();
        }

        private static void LoadHandStrings()
        {
            if (_handStrings == null)
            {
                _handStrings = new Dictionary<PokerSimulation.HandRank, string>();
                _handStrings[PokerSimulation.HandRank.HighCard] = Properties.Settings.Default.HighCardString;
                _handStrings[PokerSimulation.HandRank.OnePair] = Properties.Settings.Default.OnePairString;
                _handStrings[PokerSimulation.HandRank.TwoPair] = Properties.Settings.Default.TwoPairString;
                _handStrings[PokerSimulation.HandRank.ThreeOfAKind] = Properties.Settings.Default.ThreeOfAKindString;
                _handStrings[PokerSimulation.HandRank.FullHouse] = Properties.Settings.Default.FullHouseString;
                _handStrings[PokerSimulation.HandRank.FourOfAKind] = Properties.Settings.Default.FourOfAKindString;
                _handStrings[PokerSimulation.HandRank.Flush] = Properties.Settings.Default.FlushString;
                _handStrings[PokerSimulation.HandRank.Straight] = Properties.Settings.Default.StraightString;
                _handStrings[PokerSimulation.HandRank.StraightFlush] = Properties.Settings.Default.StraightFlushString;
                _handStrings[PokerSimulation.HandRank.RoyalFlush] = Properties.Settings.Default.RoyalFlushString;
            }
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
                HideWelcomeScreen();
                ShowPressAnyKey();
            }
            else
            {
                MessageBox.Show("Sorry, but there was a problem opening: " + filename + ".");
            }
        }

        private void Btn_ChooseFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".in";                                                      // Default file extension
            dlg.Filter = "Simulation Script (.sim)|*.sim|Text documents (.txt)|*.txt|Simulation Input File (.in)|*.in"; // Filter files by extension

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
                        HideWelcomeScreen();
                        ShowPressAnyKey();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, but there was a problem opening: " + filename + ".");
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
            TxtBlck_Instr.Visibility = Visibility.Hidden;
		}
		
		private void ShowTrialScreen()
		{
            Uni_Grid_Cards.Visibility = Visibility.Visible;
            TxtBx_Subj_Input.Visibility = Visibility.Visible;
            TxtBlck_Instr.Visibility = Visibility.Visible;
		}

        private void ShowPressAnyKey()
        {
            Grid_Ready.Visibility = Visibility.Visible;
            Grid_Ready.Focus();
        }

        private void HidePressAnyKey()
        {
            Grid_Ready.Visibility = Visibility.Hidden;
        }

        private void DoTrial()
        {
            _timer.Start();
            ShowFixation();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
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

                _firstKeyPress = DateTime.MinValue;
                _timeStamp = DateTime.Now;
                ShowTrialScreen();

                TxtBx_Subj_Input.Focus();
            }
            else
            {
                HideTrialScreen();
                TxtBlck_ThankYou.Visibility = Visibility.Visible;
            }
        }

        private void ShowFixation()
        {
            TxtBx_Subj_Input.Visibility = Visibility.Hidden;
            TxtBlck_Instr.Visibility = Visibility.Hidden;

            Rect_Card0.Fill = Brushes.DarkGreen;
            Rect_Card1.Fill = Brushes.DarkGreen;
            Rect_Card2.Fill = Brushes.DarkGreen;
            Rect_Card3.Fill = (Brush)FindResource("FIX");
            Rect_Card4.Fill = Brushes.DarkGreen;
            Rect_Card5.Fill = Brushes.DarkGreen;
            Rect_Card6.Fill = Brushes.DarkGreen;

            Uni_Grid_Cards.Visibility = Visibility.Visible;
        }

        private void TxtBx_Subj_Input_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_firstKeyPress == DateTime.MinValue)
            {
                _firstKeyPress = DateTime.Now;
                _timeSpan = TimeSpan.FromTicks(_firstKeyPress.Ticks - _timeStamp.Ticks);
                _currentTrial.ReactionTime = _timeSpan;
            }

            if (e.Key == Key.Enter && TxtBx_Subj_Input.Text.Trim() != "")
			{
                _timeSpan = TimeSpan.FromTicks(DateTime.Now.Ticks - _timeStamp.Ticks);
				_currentTrial.ResponseString = TxtBx_Subj_Input.Text.Trim();
                _currentTrial.ResponseTime = _timeSpan;
                _currentTrial.FixationTime = TimeSpan.FromMilliseconds(Properties.Settings.Default.FixationTime);

                if (_showFeedback)
                {
                    string feedback;

                    if (_currentTrial.HandRank == _currentTrial.ResponseRank)
                    {
                        feedback = "Correct!\n" + 
                                   "You answered in " + _timeSpan.TotalSeconds + " seconds.";
                    }
                    else
                    {
                        feedback = "Sorry, the correct answer is: " + _handStrings[_currentTrial.HandRank] + "\n" +
                                   "You answered in " + _timeSpan.TotalSeconds + " seconds.";
                    }
                    _timeStamp = DateTime.Now;
                    MessageBox.Show(feedback);
                    _currentTrial.FeedbackTime = TimeSpan.FromMilliseconds(DateTime.Now.Ticks - _timeStamp.Ticks);
                }
                else
                {
                    _currentTrial.FeedbackTime = TimeSpan.Zero;
                }

                while (!_currentTrial.Persist())
                {
                    MessageBox.Show("Trial could not be saved.\nPlease notify your administrator.");
                }

                DoTrial();
			}
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	if (Grid_Ready.Visibility == Visibility.Visible)
            {
                Grid_Ready.Visibility = Visibility.Hidden;
                DoTrial();
            }
        }
    }
}
