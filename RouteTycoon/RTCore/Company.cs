using RouteTycoon.RTCore.Plugin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class Company
	{
		private ICompanyPlugin plug;

		public Company(ICompanyPlugin plugin)
		{
			plug = plugin;
		}

		public string Name
		{
			get;
			set;
		}

		public bool useDefaultLogo
		{
			get;
			set;
		}

		public Image Logo
		{
			get
			{
				try
				{
					if (Plugin == null) // User
						if (!useDefaultLogo)
							return Image.FromFile($".\\data\\saves\\{Name}.png");
						else
							return Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "defaultlogo.png", 5, 7, 1, 6));
					else // AI
					{
						XmlDocument root = new XmlDocument();

						using (StreamReader sr = new StreamReader(ResourceManager.Get($".\\data\\system\\company.npk", "companys.xml", 5, 7, 1, 6), Encoding.Default))
						{
							root.LoadXml(sr.ReadToEnd());
						}

						XmlNode companys = root.SelectNodes("Companys")[0];

						foreach (XmlNode it in companys.SelectNodes("Company"))
						{
							if (it.Attributes["Name"].Value == Name)
							{
								return Image.FromStream(ResourceManager.Get(".\\data\\system\\company.npk", it.Attributes["Logo"].Value, 5, 7, 1, 6));
							}
						}
					}

					throw new Exception("알 수 없는 오류가 발생 하였습니다.");
				}
				catch (Exception ex)
				{
					Environment.ReportError(ex, AccessManager.AccessKey);
					return null;
				}
			}
		}

		public string PresidentName
		{
			get;
			set;
		}

		public decimal Money
		{
			get;
			set;
		}

		private List<decimal> bankbooks = new List<decimal>();

		public List<decimal> Bankbooks
		{
			get
			{
				return bankbooks;
			}
		}

		public decimal Loan
		{
			get;
			set;
		}

		public decimal IncomeAdd
		{
			get;
			set;
		}

		public decimal Income
		{
			get
			{
				try
				{
					decimal v = CalcDefIncome();
					decimal ia = 0; // IncomeAdd
					if (IncomeAdd <= 0)
						ia = Math.Abs(IncomeAdd);
					else
						ia = IncomeAdd;

					if (GameManager.Sandbox)
					{
						if (v <= 0)
							if (IncomeAdd > 0) return ia;
							else return 0;
						else
							return v + ia;
					}
					else
					{
						if (IncomeAdd < 0)
							v -= ia;
						else
							v += ia;

						return v;
					}
				}
				catch (Exception e)
				{
					Environment.ReportError(e, AccessManager.AccessKey);
					return 0;
				}
			}
		}

		public decimal GetCityIncome(City city)
		{
			try
			{
				decimal res = 0;

				#region 노선 수익
				foreach (var it in GameManager.RouteMgr.Routes)
				{
					if (it.Owner != this) continue;

					long pass_carry = 0;
					long freight_carry = 0;

					foreach (var t in it.Trains)
					{
						foreach (TrainParant a in t.Data.Args)
						{
							if (a is Locomotive) continue;

							if (a is Coach)
							{
								Coach c = (Coach)a;

								if (c.Rank == Coach.CarriageRank.FREIGHT)
									freight_carry += c.Carrying;
								else
									pass_carry += c.Carrying;
							}
							else if (a is EngineCoach)
							{
								EngineCoach lc = (EngineCoach)a;

								if (lc.Coach.Rank == EngineCoach.CoachData.CoachRank.FREIGHT)
									freight_carry += lc.Coach.Carrying;
								else
									pass_carry += lc.Coach.Carrying;
							}
						}
					}

					int use = it.UseMoney;
					if (it.Type == Route.RouteType.HIGH) use = use + Convert.ToInt32(use * 0.3);

					long pass_visit = 0;
					long freight_visit = 0;
					long double_visit = 0;

					foreach (var s in it.Stations)
					{
						if (s.Parent != city) continue;

						if (s.Type == Station.StationType.DOUBLE)
							double_visit += s.Visitor;
						else if (s.Type == Station.StationType.PASSENGER)
							pass_visit += s.Visitor;
						else if (s.Type == Station.StationType.FREIGHT)
							freight_visit += s.Visitor;
					}

					res += GameManager.GameRule.CalcRouteIncome(pass_visit + (double_visit / 2), pass_carry, use);
					res += GameManager.GameRule.CalcRouteIncome(freight_visit + (double_visit / 2), freight_carry, use);
				}
				#endregion

				return res;
			}
			catch (Exception EX)
			{
				Environment.ReportError(EX, AccessManager.AccessKey);
				return 0;
			}
		}

		private decimal CalcDefIncome()
		{
			try
			{
				decimal res = 0;

				#region 열차 유지비
				foreach (var r in GameManager.RouteMgr.Routes)
				{
					if (r.Owner != this) continue;
					foreach (var it in r.Trains)
						res -= it.Data.Maintenance;
				}
				#endregion
				#region 세금
				res -= GameManager.GameRule.CalcTax(this);
				#endregion
				#region 노선 수익
				foreach (var it in GameManager.RouteMgr.Routes)
				{
					if (it.Owner != this) continue;

					long pass_carry = 0;
					long freight_carry = 0;

					foreach (var t in it.Trains)
					{
						foreach (TrainParant a in t.Data.Args)
						{
							if (a is Locomotive) continue;

							if (a is Coach)
							{
								Coach c = (Coach)a;

								if (c.Rank == Coach.CarriageRank.FREIGHT)
									freight_carry += c.Carrying;
								else
									pass_carry += c.Carrying;
							}
							else if (a is EngineCoach)
							{
								EngineCoach lc = (EngineCoach)a;

								if (lc.Coach.Rank == EngineCoach.CoachData.CoachRank.FREIGHT)
									freight_carry += lc.Coach.Carrying;
								else
									pass_carry += lc.Coach.Carrying;
							}
						}
					}

					int use = it.UseMoney;
					if (it.Type == Route.RouteType.HIGH) use = use + Convert.ToInt32(use * 0.3);

					long pass_visit = 0;
					long freight_visit = 0;
					long double_visit = 0;

					foreach (var s in it.Stations)
					{
						if (s.Type == Station.StationType.DOUBLE)
							double_visit += s.Visitor;
						else if (s.Type == Station.StationType.PASSENGER)
							pass_visit += s.Visitor;
						else if (s.Type == Station.StationType.FREIGHT)
							freight_visit += s.Visitor;
					}

					res += GameManager.GameRule.CalcRouteIncome(pass_visit + (double_visit / 2), pass_carry, use);
					res += GameManager.GameRule.CalcRouteIncome(freight_visit + (double_visit / 2), freight_carry, use);
				}
				#endregion

				return res;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return 0;
			}
		}

		public ICompanyPlugin Plugin
		{
			get
			{
				return plug;
			}
		}
	}
}