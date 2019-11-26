using System;
using System.Web.UI;

namespace BlazorCompWebFormDemo
{
	public partial class FormDemo : Page
	{
		#region Fields
		private int Increment;
		#endregion

		#region Protecteds
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!this.IsPostBack) return;
			if(IncrementBox.Text == null) return;
			Int32.TryParse(IncrementBox.Text, out Increment);
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Increment++;

			IncrementBox.Text = Increment.ToString();
		}
		#endregion
	}
}