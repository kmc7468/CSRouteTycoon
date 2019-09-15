namespace RouteTycoon.RTCore
{
	public class RouteEventArgs
	{
		public Route Route
		{
			get;
			internal set;
		}
	}

	public class StationEventArgs
	{
		public Station Station
		{
			get;
			internal set;
		}
	}

	public class TrainEventArgs
	{
		public Train Train
		{
			get;
			internal set;
		}
	}

	public class TrainInputedEventArgs : TrainEventArgs
	{
		public Route InputRoute
		{
			get;
			internal set;
		}
	}

	public class TrainOutputedEventArgs : TrainEventArgs
	{
		public Route OutputRoute
		{
			get;
			internal set;
		}
	}

	public class TrainDataAddedEventArgs
	{
		public TrainData Data
		{
			get;
			internal set;
		}
	}

	public class LoanEventArgs
	{
		public decimal Value
		{
			get;
			internal set;
		}
	}

	public class BankBookEventArgs
	{
		public decimal Value
		{
			get;
			internal set;
		}
	}
}
