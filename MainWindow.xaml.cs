using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace headfirstcsharp_project
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			SetupGame();

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
				int index = random.Next(animalemoji.Count);//
				string nextemoji = animalemoji[index];
				textBlock.Text = nextemoji;
				animalemoji.RemoveAt(index);
			}

		}
	}
}
