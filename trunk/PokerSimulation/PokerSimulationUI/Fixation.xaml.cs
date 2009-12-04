using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PokerSimulationUI
{
	/// <summary>
	/// Interaction logic for Fixation.xaml
	/// </summary>
	public partial class Fixation : Window
	{
        private DispatcherTimer _timer;
		
        public Fixation()
		{
			this.InitializeComponent();

            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;

            Loaded += new RoutedEventHandler(Fixation_Loaded);
		}

        void Fixation_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.FixationTime);
            _timer.Tick += new EventHandler(_timer_Tick);

            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            this.Close();
        }
	}
}