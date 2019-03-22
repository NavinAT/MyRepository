using System.Collections.Generic;

namespace MyFirstMVCApplication.Models
{
	public class MyTeam
	{
		public List<string> Team_One = new List<string>();
		public List<string> Team_Two = new List<string>();

		public string Team1 { get; set; }
		public string Team2 { get; set; }

		public enum TeamList
		{
			CSK,
			RCB,
			MI,
			DC,
			RR,
			SRH,
			KXIP,
			KKR
		}

		public enum CSK
		{
			Dhoni,
			Raina
		}

		public enum RCB
		{
			Kohli,
			ABD
		}
	}
}