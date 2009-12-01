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
using System.Windows.Threading;

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
        	MessageBox.Show("Starting the session!");
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
                        HideWelcomeScreen();
                        DoTrial();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, but " + filename + " is an invalid file type.");
                }
            }
        }

        private void HideWelcomeScreen()
        {
            TxtBlck_Welcome.Visibility = Visibility.Hidden;
            TxtBlck_ChooseFile.Visibility = Visibility.Hidden;
            TxtBx_SessionID.Visibility = Visibility.Hidden;
            TxtBx_SubjectID.Visibility = Visibility.Hidden;
            Btn_ChooseFile.Visibility = Visibility.Hidden;
            Btn_StartSess.Visibility = Visibility.Hidden;
            Pth_Splitter.Visibility = Visibility.Hidden;
        }

        private void ShowWelcomeScreen()
        {
            TxtBlck_Welcome.Visibility = Visibility.Visible;
            TxtBlck_ChooseFile.Visibility = Visibility.Visible;
            TxtBx_SessionID.Visibility = Visibility.Visible;
            TxtBx_SessionID.Text = SESSION_ID;
            TxtBx_SubjectID.Visibility = Visibility.Visible;
            TxtBx_SubjectID.Text = SUBJECT_ID;
            Btn_ChooseFile.Visibility = Visibility.Visible;
            Btn_StartSess.Visibility = Visibility.Visible;
            Pth_Splitter.Visibility = Visibility.Visible;
        }
		
		private void HideCards()
		{
			Uni_Grid_Cards.Visibility = Visibility.Hidden;
		}
		
		private void ShowCards()
		{
			Uni_Grid_Cards.Visibility = Visibility.Visible;
		}

        private void DoTrial()
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

                ShowCards();
            }
        }
    }
}
