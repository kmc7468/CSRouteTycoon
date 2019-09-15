using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteTycoon.RTCore.Base
{
	internal class FirstMove : Plugin.IAchievement
	{
		public string Description
		{
			get
			{
				return "예산 5억 달성";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Name
		{
			get
			{
				return "첫 걸음";
			}
		}

		public bool isClear()
		{
			if (GameManager.Company.Money >= 500000000)
				return true;
			else
				return false;
		}

		public void Reward()
		{
			GameManager.Company.Money += 5000000;
		}
	}

	internal class FirstRoute : Plugin.IAchievement, Plugin.IGamePlugin
	{
		public FirstRoute()
		{
			if (PluginManager.GetGamePluginList().Find((e) => { return e is FirstRoute; }) != null)
				PluginManager.RemovePlugin(PluginManager.GetGamePluginList().Find((e) => { return e is FirstRoute; }));

			PluginManager.RegistryPlugin(this);
		}

		public string Description
		{
			get
			{
				return "노선 개통 하기";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Name
		{
			get
			{
				return "첫 노선";
			}
		}

		bool _clear = false;

		public bool isClear()
		{
			return _clear;
		}

		public void LoadGame()
		{

		}

		public void NewGame()
		{
			
		}

		public void Reward()
		{
			GameManager.Company.Money += 3000000;
		}

		public void RouteAdded(RouteEventArgs e)
		{
			if (_clear) return;
			_clear = true;
		}

		public void RouteDeleted(RouteEventArgs e)
		{

		}

		public void SaveGame()
		{
			
		}

		public void StationAdded(StationEventArgs e)
		{
			
		}

		public void StationDeleted(StationEventArgs e)
		{
			
		}

		public void TrainBought(TrainEventArgs e)
		{
			
		}

		public void TrainDataAdded(TrainDataAddedEventArgs e)
		{
			
		}

		public void TrainInputed(TrainInputedEventArgs e)
		{
			
		}

		public void TrainOutputed(TrainOutputedEventArgs e)
		{

		}

		public void TrainSold(TrainEventArgs e)
		{

		}

		public void Loan(LoanEventArgs e)
		{

		}

		public void ClearLoan(LoanEventArgs e)
		{

		}

		public void DepositBankBook(BankBookEventArgs e)
		{

		}

		public void WithdrawBankBook(BankBookEventArgs e)
		{

		}
	}

	public class Income50000000 : Plugin.IAchievement
	{
		public string Description
		{
			get
			{
				return "수익 5천만RTW 달성";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Name
		{
			get
			{
				return "수익 늘리기";
			}
		}

		public bool isClear()
		{
			if (GameManager.Company.Income >= 50000000)
				return true;
			else
				return false;
		}

		public void Reward()
		{
			GameManager.Company.Money += 3000000;
		}
	}
}
