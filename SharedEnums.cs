public class SharedEnums
{
	public enum SortDirection
	{
		Ascending = 0,
		Descending = 1
	}
	public enum Paging
	{
		DefaultPageNumber = 1,
		DefaultPageSize = 10
	}
	public enum PageEnum
	{
		Dashboard = 1,
		Request = 2,
		Profile = 3,
		Audit = 4
	}
	public enum AppAction
	{
		View = 1,
		Add = 2,
		Edit = 3,
		Delete = 4,
		Export = 5,
		ExportXml = 6
	}
	public enum SettlementType
	{
		Account = 1,
		Wallet = 2,
		PrepaidCard = 3
	}
}