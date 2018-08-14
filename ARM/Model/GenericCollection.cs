using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
	public static class GenericCollection
	{
		public static List<CaseTransaction> caseTransactions = new List<CaseTransaction>();
	 // public static List<Deliveries> deliveries;
		public static List<ItemReview> itemReviews;
		public static List<ItemCoverage> itemCoverage;
		public static List<ICD10> icd10;
		public static List<ItemStatus> itemStatus;
		public static List<PatientStatus> patientStatus;
		public static List<Users> users = new List<Users>();
		public static List<Schedule> schedules = new List<Schedule>();
		public static List<Customer> customers = new List<Customer>();
		public static List<Coverage> coverage = new List<Coverage>();
		public static List<Conditions> conditions = new List<Conditions>();
		public static List<Practitioner> practitioners = new List<Practitioner>();
		public static List<Rate> rates = new List<Rate>();
		public static List<Account> accounts = new List<Account>();
		public static List<Responsible> responsibles = new List<Responsible>();
		public static List<Emergency> emergencies = new List<Emergency>();
		public static List<Pay>pay = new List<Pay>();
	}
}
