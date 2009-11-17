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
	/// Interaction logic for Screen_1.xaml
	/// </summary>
	public partial class Screen_1 : UserControl
	{
		public Screen_1()
		{
			this.InitializeComponent();
		}

		private void txtbx_subjectID_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			if(txtbx_subjectID.Text == "Subject ID")
			{
				txtbx_subjectID.Text = "";
			}
		}

		private void txtbx_subjectID_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			if(txtbx_subjectID.Text == "")
			{
				txtbx_subjectID.Text = "Subject ID";
			}
		}

		private void txtbx_sessionID_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			if(txtbx_sessionID.Text == "Session ID")
			{
				txtbx_sessionID.Text = "";
			}
		}

		private void txtbx_sessionID_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			if(txtbx_sessionID.Text == "")
			{
				txtbx_sessionID.Text = "Session ID";
			}
		}
	}
}