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

namespace PokerSimulationUI
{
	/// <summary>
	/// Interaction logic for Fixation.xaml
	/// </summary>
	public partial class Fixation : Window
	{
		public Fixation()
		{
			this.InitializeComponent();

            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Focus();
		}
	}
}