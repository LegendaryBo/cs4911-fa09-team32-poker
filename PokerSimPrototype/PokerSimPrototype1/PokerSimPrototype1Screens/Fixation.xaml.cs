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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerSimPrototype1Screens
{
	/// <summary>
	/// Interaction logic for Copy_of_Welcome.xaml
	/// </summary>
	public partial class Copy_of_Welcome : UserControl
	{
		public Copy_of_Welcome()
		{
			this.InitializeComponent();
		}

		private void LayoutRoot_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				MessageBox.Show("Go to next screen automatically...");
			}
		}
	}
}