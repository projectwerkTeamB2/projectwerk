using System;
using System.Windows;

namespace GUI
{

    public partial class AddReeksOrUitgeverij : Window
    {
		
		public AddReeksOrUitgeverij(string question, string defaultAnswer = "") //krijgt de vraag binnen
		{
			InitializeComponent();
			lblQuestion.Content = question;
			txtAnswer.Text = defaultAnswer;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			
				this.DialogResult = true;
			
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer.SelectAll();
			txtAnswer.Focus();
		}

		public string Answer
		{
			get { return txtAnswer.Text; }
		}
	}
}
