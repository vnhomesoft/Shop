namespace Shop.Common.Constants
{
	/// <summary>
	/// Define name of various loggers
	/// </summary>
	public static class LoggerName
	{
		public const string DEFAULT = "default";
		public const string FILE = "file";
		public const string CONSOLE = "console";
	}

	public static class Controllers
	{
		public const string CATEGORY = "Category";
		public const string PRODUCT = "Product";
		public const string ORDER = "Order";
		public const string USER = "User";
		public const string DASHBOARD = "Dashboard";

		public static class Action
		{
			public const string CREATE = "Create";
			public const string EDIT = "Edit";
			public const string DELETE = "Delete";
			public const string INDEX = "Index";
		}
	}

}