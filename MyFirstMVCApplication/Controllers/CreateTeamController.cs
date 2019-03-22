using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyFirstMVCApplication.Models;

namespace MyFirstMVCApplication.Controllers
{
	public class CreateTeamController : Controller
	{
		#region Fields
		private int nKeeper;
		private int nNumberOfBatsmans;
		private int nNumberOfAllRounders;
		private int nNumberOfBowlers;

		private readonly List<List<string>> myTeams = new List<List<string>>(6);
		private List<string> MyTeamList;

		private readonly string[] WicketKeepers = { "Dhoni", "Patel" };
		private readonly int[] MinMaxWicketKeeper = { 1 };

		private readonly string[] Batsmans = { "Watson", "DuPlessis", "Raina", "Rayudu", "Kohli", "ABD", "Hetmyer", "Kedar" };
		private readonly int[] MinMaxForBatsmans = { 3, 4, 5 };

		private readonly string[] AllRounders = { "Bravo", "Jaddu", "Shivam dube", "Washington" };
		private readonly int[] MinMaxForAllRounders = { 1, 2, 3 };

		private readonly string[] Bowlers = { "Chahar", "Thakur", "Tahir", "Mohit", "Umesh yadav", "Chahal", "NCN", "Siraj" };
		private readonly int[] MinMaxForBowlers = { 3, 4, 5 };
		#endregion

		#region Publics
		public ActionResult CreateTeam()
		{
			return View(new MyTeam());
		}

		[HttpPost]
		public ActionResult CreateTeam(MyTeam myTeam, string Go, string CreateTeam)
		{
			if(Go != null)
			{
				if(myTeam.Team1 == "CSK")
				{
					myTeam.Team_One = Enum.GetNames(typeof(MyTeam.CSK)).ToList();
				}
				if(myTeam.Team1 == "RCB")
				{
					myTeam.Team_One = Enum.GetNames(typeof(MyTeam.RCB)).ToList();
				}

				if(myTeam.Team2 == "CSK")
				{
					myTeam.Team_Two = Enum.GetNames(typeof(MyTeam.CSK)).ToList();
				}
				if(myTeam.Team2 == "RCB")
				{
					myTeam.Team_Two = Enum.GetNames(typeof(MyTeam.RCB)).ToList();
				}
			}

			if(CreateTeam != null)
			{
				for(int i = 0; i < 6; i++)
				{
					MyTeamList = new List<string>(11);

					GetTeamCombination();

					AddPlayers(nKeeper, WicketKeepers);
					AddPlayers(nNumberOfBatsmans, Batsmans);
					AddPlayers(nNumberOfAllRounders, AllRounders);
					AddPlayers(nNumberOfBowlers, Bowlers);

					myTeams.Add(MyTeamList);
				}
			}

			return View(myTeam);
		}
		#endregion

		#region Privates
		private void GetTeamCombination()
		{
			while(nKeeper + nNumberOfBatsmans + nNumberOfAllRounders + nNumberOfBowlers != 11)
			{
				nKeeper = MinMaxWicketKeeper[new Random().Next(0, MinMaxWicketKeeper.Length)];
				nNumberOfBatsmans = MinMaxForBatsmans[new Random().Next(0, MinMaxForBatsmans.Length)];
				nNumberOfAllRounders = MinMaxForAllRounders[new Random().Next(0, MinMaxForAllRounders.Length)];
				nNumberOfBowlers = MinMaxForBowlers[new Random().Next(0, MinMaxForBowlers.Length)];
			}
		}

		private void AddPlayers(int nNumberOfPlayers, string[] group)
		{
			for(int i = 0; i < nNumberOfPlayers; i++)
			{
				string strRandomPlayerName = group[new Random().Next(0, group.Length)];
				int nNumberOfTimesOccured = 0;

				foreach(List<string> myTeam in myTeams)
				{
					foreach(string playerName in myTeam)
					{
						if(strRandomPlayerName == playerName)
						{
							nNumberOfTimesOccured++;
							break;
						}
					}
				}

				if(!MyTeamList.Contains(strRandomPlayerName) && nNumberOfTimesOccured <= 3) MyTeamList.Add(strRandomPlayerName);
				else i--;
			}
		}
		#endregion
	}
}