namespace Rifleman.Mobile.Common.Core.Classes
{
	public static class CoreEnums
	{
		public enum RecurrencyTypesRent
		{
			[EnumDescription( Name = "Weekly" )]
			Weeks = 1,
			[EnumDescription( Name = "Monthly" )]
			Months = 2,
			[EnumDescription( Name = "Yearly" )]
			Years = 3,
			[EnumDescription( Name = "" )]
			Custom = 4
		}

		public enum RecurrencyTypes
		{
			Days = 0,
			Weeks = 1,
			Months = 2,
			Years = 3
		}

		public enum ConnectionType
		{
			NotAvailable = 1,
			WiFi = 2,
			MobileData = 3
		}

		public enum RequestResult
		{
			Success = 1,
			NetworkError = 2,
			UnsuccessfulResult = 3,
		}

		public enum InvoiceStatus
		{
			None = 0,
			[EnumDescription( Name = "Paid" )]
			Paid = 1,
			[EnumDescription( Name = "Part Paid" )]
			PartPaid = 2,
			[EnumDescription( Name = "Due Today" )]
			DueToday = 3,
			[EnumDescription( Name = "Overdue" )]
			OverDue = 4
		}

		public enum DownloadStatus
		{
			None = 0,
			NotStarted = 1,
			Downloading = 2,
			Downloaded = 3
		}

		public enum StatusColour
		{
			Success = 1,
			Warning = 2,
			Danger = 3,
			Link = 4
		}

		public enum ContactCategoryForLease
		{
			None = 0,
			[EnumDescription( Name = "Account" )]
			Account = 1,
			[EnumDescription( Name = "Primary" )]
			Primary = 2,
			[EnumDescription( Name = "Tenant" )]
			Tenant = 3
		}

		public enum LeaseBreakStatusType
		{
			Active = 0,
			[EnumDescription( Name = "Not Exercised" )]
			Completed = 1,
			[EnumDescription( Name = "Notice Served" )]
			NoticeServed = 2,
			[EnumDescription( Name = "Exercised & Complete" )]
			Exercised = 3
		}

		public enum MaintenanceItemStatus
		{
			None = 0,
			[EnumDescription( Name = "Requested" )]
			Requested = 1,
			[EnumDescription( Name = "Approved" )]
			Approved = 2,
			[EnumDescription( Name = "Declined" )]
			Declined = 3
		}
	}
}
