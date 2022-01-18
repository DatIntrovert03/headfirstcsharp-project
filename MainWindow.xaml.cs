using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace headfirstcsharp_project
{
	using System.Windows.Threading;

	public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		int tenthsofsecondselapsed;
		int matchesfound;

		public MainWindow()
		{
			InitializeComponent();
			timer.Interval = TimeSpan.FromSeconds(.1);
			timer.Tick += Timer_Tick;
			SetupGame();

		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			tenthsofsecondselapsed++;
			timetextblock.Text = (tenthsofsecondselapsed / 10F).ToString("0.0s");
			if(matchesfound==8)
			{
				timer.Stop();
				timetextblock.Text = timetextblock.Text + "-Play again?";
			}
		}

		private void SetupGame()
		{
			List<string> animalemoji = new List<string>()
			{
				"😀","😀",
				"😁","😁",
				"🤣","🤣",
				"🎆","🎆",
				"🤑","🤑",
				"🚓","🚓",
				"👚","👚",
				"🐴","🐴",
			};
			Random random = new Random();
			foreach (TextBlock textBlock in maingrid.Children.OfType<TextBlock>())
			{
				if (textBlock.Name != "timetextblock")
				{
					textBlock.Visibility = Visibility.Visible;
					int index = random.Next(animalemoji.Count);//
					string nextemoji = animalemoji[index];
					textBlock.Text = nextemoji;
					animalemoji.RemoveAt(index);
				}
				
			}
			timer.Start();
			tenthsofsecondselapsed = 0;
			matchesfound = 0;

		}
		TextBlock lasttextblock;
		bool findingMatch = false;

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			TextBlock textblock = sender as TextBlock;

			if (findingMatch==false)
			{
				textblock.Visibility = Visibility.Hidden;
				lasttextblock = textblock;
				findingMatch = true;
			}
			else if(textblock.Text==lasttextblock.Text)
			{
				matchesfound++;
				textblock.Visibility = Visibility.Hidden;
				findingMatch = false;
			}
			else
			{
				lasttextblock.Visibility = Visibility.Visible;
				findingMatch = false;
			}
		}

		private void timetextblock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (matchesfound==8)
			{
				SetupGame();
			}
		}
	}
}
