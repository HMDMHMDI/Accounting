using System;
namespace UI.Controls
{
	public class CustomBtn: Button
	{
		public CustomBtn()
		{
            Clicked += CustomBtn_Clicked;
		}

        private void CustomBtn_Clicked(object sender, EventArgs e)
        {
			MyFunc(SendId);
        }

        public int SendId { get; set; }
		public Action<int> MyFunc { get; set; }
		
	}
}

