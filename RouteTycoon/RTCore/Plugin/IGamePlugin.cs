namespace RouteTycoon.RTCore.Plugin
{
	public interface IGamePlugin
	{
		void NewGame();
		void LoadGame();
		void SaveGame();

		void RouteAdded(RouteEventArgs e);
		void RouteDeleted(RouteEventArgs e);

		void StationAdded(StationEventArgs e);
		void StationDeleted(StationEventArgs e);

		void TrainBought(TrainEventArgs e);
		void TrainSold(TrainEventArgs e);
		void TrainInputed(TrainInputedEventArgs e);
		void TrainOutputed(TrainOutputedEventArgs e);
		void TrainDataAdded(TrainDataAddedEventArgs e);

		void Loan(LoanEventArgs e);
		void ClearLoan(LoanEventArgs e);

		void DepositBankBook(BankBookEventArgs e);
		void WithdrawBankBook(BankBookEventArgs e);
    }
}
