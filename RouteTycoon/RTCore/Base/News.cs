using System;
using System.Drawing;

namespace RouteTycoon.RTCore.Base
{
	internal class Bankruptcy : Plugin.INews // 예산 100만RTW 미만
	{
		public string Name
		{
			get
			{
				return "Bankruptcy";
			}
		}
		
		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Message
		{
			get
			{
				return GameManager.Company.Name + ".. 파산 위기";
			}
		}

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public bool AlreadyDo
		{
			get;
			set;
		}

		public bool IsAvailable()
		{
			if (GameManager.Company.Money > 1000000)
				AlreadyDo = false;

			return (GameManager.Company.Money <= 1000000);
		}

		public void Update()
		{
			foreach (var r in GameManager.Map.Regions)
				foreach (var c in r.Childs)
					if (c.Preference[0] >= 5) c.Preference[0] -= 5;
					else if (c.Preference[0] < 5) c.Preference[0] = 0;
		}
	}

	internal class Mansour : Plugin.INews // 예산 5억RTW 돌파
	{
		public string Name
		{
			get
			{
				return "Mansour";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Message
		{
			get
			{
				return GameManager.Company.Name + ".. 예산 드디어 5억 돌파";
			}
		}

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public bool AlreadyDo
		{
			get;
			set;
		} = true;

		public bool IsAvailable()
		{
			if (GameManager.Company.Money < 500000000)
				AlreadyDo = false;

			return (GameManager.Company.Money >= 500000000);
		}

		public void Update()
		{
			foreach (Region r in GameManager.Map.Regions)
				foreach (City c in r.Childs)
					if (c.Preference[0] <= 90) c.Preference[0] += 10;
					else if (c.Preference[0] > 90) c.Preference[0] = 100;
		}
	}

	internal class OpeningRoute : Plugin.INews, Plugin.IGamePlugin // 노선 개통
	{
		public OpeningRoute()
		{
			if (PluginManager.GetGamePluginList().Find((e) => { return e is OpeningRoute; }) != null)
				PluginManager.RemovePlugin(PluginManager.GetGamePluginList().Find((e) => { return e is OpeningRoute; }));

			PluginManager.RegistryPlugin(this);
		}

		private bool Available = false;
		private string name = "";

		public string Name
		{
			get
			{
				return "OpeningRoute";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public string Message
		{
			get
			{
				return GameManager.Company.Name + $".. '{name}' 노선 개통";
			}
		}

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public bool AlreadyDo
		{
			get;
			set;
		}

		public bool IsAvailable()
		{
			if (!Available)
				AlreadyDo = false;

			return Available;
		}

		public void Update()
		{
			foreach (Region r in GameManager.Map.Regions)
				foreach (City c in r.Childs)
					if (c.Preference[0] <= 95) c.Preference[0] += 5;
					else if (c.Preference[0] > 95) c.Preference[0] = 100;
		}

		public void NewGame()
		{
			
		}

		public void LoadGame()
		{
			
		}

		public void SaveGame()
		{
			
		}

		public void RouteAdded(RouteEventArgs e)
		{
			name = e.Route.Name;
			Available = true;
		}

		public void RouteDeleted(RouteEventArgs e)
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

		public void TrainSold(TrainEventArgs e)
		{
			
		}

		public void TrainInputed(TrainInputedEventArgs e)
		{
			
		}

		public void TrainOutputed(TrainOutputedEventArgs e)
		{
			
		}

		public void TrainDataAdded(TrainDataAddedEventArgs e)
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

	internal class IncomeUp : Plugin.INews //흑자 전환
	{
		public string Name
		{
			get
			{
				return "IncomeUp";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public bool AlreadyDo
		{
			get;
			set;
		}

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public string Message
		{
			get { return GameManager.Company.Name + ".. 수익을 드디어 흑자로 전환"; }
		}

		public bool IsAvailable()
		{
			if (GameManager.Company.Income <= 0)
				AlreadyDo = false;

			return (GameManager.Company.Income > 0);
		}

		public void Update()
		{
			foreach (Region r in GameManager.Map.Regions)
				foreach (City c in r.Childs)
					if (c.Preference[0] <= 95) c.Preference[0] += 5;
					else if (c.Preference[0] > 95) c.Preference[0] = 105;
		}
	}

	internal class IncomeDown : Plugin.INews //적자 전환
	{
		public string Name
		{
			get
			{
				return "IncomeDown";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public bool AlreadyDo
		{
			get;
			set;
		} = true;

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public string Message
		{
			get { return GameManager.Company.Name + ".. 더 이상 수익이 나지 않아.."; }
		}

		public bool IsAvailable()
		{
			if (GameManager.Company.Income > 0)
				AlreadyDo = false;

			return (GameManager.Company.Income <= 0);
		}

		public void Update()
		{
			foreach (Region r in GameManager.Map.Regions)
				foreach (City c in r.Childs)
					if (c.Preference[0] >= 10) c.Preference[0] -= 10;
					else if (c.Preference[0] < 10) c.Preference[0] = 0;
		}
	}

	internal class NewCompany : Plugin.INews, Plugin.IGamePlugin
	{
		public NewCompany()
		{
			if (PluginManager.GetGamePluginList().Find((e) => { return e is NewCompany; }) != null)
				PluginManager.RemovePlugin(PluginManager.GetGamePluginList().Find((e) => { return e is NewCompany; }));

			PluginManager.RegistryPlugin(this);
		}

		public bool AlreadyDo
		{
			get;
			set;
		}

		public string Developer
		{
			get
			{
				return "kmc7468";
			}
		}

		public Image Image
		{
			get
			{
				return RTAPI.ResourceAPI.NoImage;
			}
		}

		public string Message
		{
			get
			{
				return GameManager.Company.Name + "이라는 새 철도 신생 기업 탄생!";
			}
		}

		public string Name
		{
			get
			{
				return "NewCompany";
			}
		}

		bool Available = false;

		public bool IsAvailable()
		{
			if (!Available)
				AlreadyDo = false;

			return Available;
		}

		public void LoadGame()
		{
			
		}

		public void NewGame()
		{
			Available = true;
		}

		public void RouteAdded(RouteEventArgs e)
		{
		
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

		public void Update()
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
}
