using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace IntTeTestat
{
	public partial class Info : UserControl
	{
		private MainPage mainpage;

		public Info()
		{
			InitializeComponent();
		}

		public Info(MainPage parent)
		{
			InitializeComponent();
			mainpage = parent;
		}

		private void cmdContinue_Click(object sender, RoutedEventArgs e)
		{
			Welcome startpage = new Welcome(mainpage);
			mainpage.ContentFrame.Content = startpage;
		}

	}
}
