using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
   public static class GenericCollection
    {
        public static List<Transaction> transactions ;
        public static List<Deliveries> deliveries;
        public static List<ItemReview> itemReviews;
        public static List<ItemCoverage> itemCoverage;
        public static List<ICD10> icd10;
        public static List<ItemStatus> itemStatus;
        public static List<PatientStatus> patientStatus;
    }
}
