using System;
using System.Collections.Generic;
using System.Linq;

namespace RouteTycoon.RTCore
{
	public class Train
	{
		public Train(string name)
		{
			try
			{
				_mgrindex = TrainManager.TrainDatas.IndexOf(TrainManager.TrainDatas.First(x => x.Name == name));
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private int _mgrindex = 0;

		public TrainData Data
		{
			get
			{
				return TrainManager.TrainDatas[_mgrindex];
			}
		}

		public string Name
		{
			get;
			set;
		}

		public Station NowStation
		{
			get;
			set;
		}

		public bool RunMode // false - 상행 / true - 하행
		{
			get;
			set;
		}

		public double Progress
		{
			get;
			set;
		}

		public Route Route
		{
			get;
			set;
		}

		public int WayIndex
		{
			get;
			set;
		}

		public Company Owner
		{
			get;
			set;
		}
	}
}
