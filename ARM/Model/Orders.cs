using ARM.DB;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Orders
    {
        private string id;
        private string caseID;
        private string customerID;
        private string userID;        
        private string orderDateTime;
        private string orderBy;
        private string dispenseDateTime;
        private string dispenseBy;
        private string customerType;
        private string diagnosis;
        private string surgery;
        private string clinicalDate;        
        private string setupLocation;
        private string setupDate;
        private string dischargeLocation;
        private string dischargeDate;
        private string notification;
        private string notificationDate;
        private string authoriz;
        private string authorizationDate;
        private string action;
        private string other;
        private string practitionerID;
        private string safety;
        private string appropriate;
        private string appropriateSelection;
        private string safetyOther;
        private string phone;
        private string equipmentType;
        private string equipmentOther;
        private string additional;
        private string additionalNotes;
        private string followUp;
        private string signature;
        private string emergencyID;        
        private string reason;
        private string userSignature;
        private string created;
        private bool sync;
        private string companyID;
        public Orders() { }

        public Orders(string id, string caseID, string customerID, string userID, string orderDateTime, string orderBy, string dispenseDateTime, string dispenseBy, string customerType, string diagnosis, string surgery, string clinicalDate, string setupLocation, string setupDate, string dischargeLocation, string dischargeDate, string notification, string notificationDate, string authoriz, string authorizationDate, string action, string other, string practitionerID, string safety, string appropriate, string appropriateSelection, string safetyOther, string phone, string equipmentType, string equipmentOther, string additional, string additionalNotes, string followUp, string signature, string emergencyID, string reason, string userSignature, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.CaseID = caseID;
            this.CustomerID = customerID;
            this.UserID = userID;
            this.OrderDateTime = orderDateTime;
            this.OrderBy = orderBy;
            this.DispenseDateTime = dispenseDateTime;
            this.DispenseBy = dispenseBy;
            this.CustomerType = customerType;
            this.Diagnosis = diagnosis;
            this.Surgery = surgery;
            this.ClinicalDate = clinicalDate;
            this.SetupLocation = setupLocation;
            this.SetupDate = setupDate;
            this.DischargeLocation = dischargeLocation;
            this.DischargeDate = dischargeDate;
            this.Notification = notification;
            this.NotificationDate = notificationDate;
            this.Authoriz = authoriz;
            this.AuthorizationDate = authorizationDate;
            this.Action = action;
            this.Other = other;
            this.PractitionerID = practitionerID;
            this.Safety = safety;
            this.Appropriate = appropriate;
            this.AppropriateSelection = appropriateSelection;
            this.SafetyOther = safetyOther;
            this.Phone = phone;
            this.EquipmentType = equipmentType;
            this.EquipmentOther = equipmentOther;
            this.Additional = additional;
            this.AdditionalNotes = additionalNotes;
            this.FollowUp = followUp;
            this.Signature = signature;
            this.EmergencyID = emergencyID;
            this.Reason = reason;
            this.UserSignature = userSignature;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Orders> p = new List<Orders>();
        public static List<Orders> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Orders ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Orders ps = new Orders(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(),Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authoriz"].ToString(), Reader["authorizationDate"].ToString(),Reader["action"].ToString(), Reader["other"].ToString(), Reader["practitionerID"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["emergencyID"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Orders> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Orders ps = new Orders(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authoriz"].ToString(), Reader["authorizationDate"].ToString(), Reader["action"].ToString(), Reader["other"].ToString(), Reader["practitionerID"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["emergencyID"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Orders> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Orders ps = new Orders(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authoriz"].ToString(), Reader["authorizationDate"].ToString(), Reader["action"].ToString(), Reader["other"].ToString(), Reader["practitionerID"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["emergencyID"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        private static Orders c = new Orders();

        public string Id { get => id; set => id = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string UserID { get => userID; set => userID = value; }
        public string OrderDateTime { get => orderDateTime; set => orderDateTime = value; }
        public string OrderBy { get => orderBy; set => orderBy = value; }
        public string DispenseDateTime { get => dispenseDateTime; set => dispenseDateTime = value; }
        public string DispenseBy { get => dispenseBy; set => dispenseBy = value; }
        public string CustomerType { get => customerType; set => customerType = value; }
        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        public string Surgery { get => surgery; set => surgery = value; }
        public string ClinicalDate { get => clinicalDate; set => clinicalDate = value; }
        public string SetupLocation { get => setupLocation; set => setupLocation = value; }
        public string SetupDate { get => setupDate; set => setupDate = value; }
        public string DischargeLocation { get => dischargeLocation; set => dischargeLocation = value; }
        public string DischargeDate { get => dischargeDate; set => dischargeDate = value; }
        public string Notification { get => notification; set => notification = value; }
        public string NotificationDate { get => notificationDate; set => notificationDate = value; }
        public string Authoriz { get => authoriz; set => authoriz = value; }
        public string AuthorizationDate { get => authorizationDate; set => authorizationDate = value; }
        public string Action { get => action; set => action = value; }
        public string Other { get => other; set => other = value; }
        public string PractitionerID { get => practitionerID; set => practitionerID = value; }
        public string Safety { get => safety; set => safety = value; }
        public string Appropriate { get => appropriate; set => appropriate = value; }
        public string AppropriateSelection { get => appropriateSelection; set => appropriateSelection = value; }
        public string SafetyOther { get => safetyOther; set => safetyOther = value; }
        public string Phone { get => phone; set => phone = value; }
        public string EquipmentType { get => equipmentType; set => equipmentType = value; }
        public string EquipmentOther { get => equipmentOther; set => equipmentOther = value; }
        public string Additional { get => additional; set => additional = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
        public string FollowUp { get => followUp; set => followUp = value; }
        public string Signature { get => signature; set => signature = value; }
        public string EmergencyID { get => emergencyID; set => emergencyID = value; }
        public string Reason { get => reason; set => reason = value; }
        public string UserSignature { get => userSignature; set => userSignature = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Orders Select(string ID)
        {
            string Q = "SELECT * FROM orders WHERE  id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Orders(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authoriz"].ToString(), Reader["authorizationDate"].ToString(), Reader["action"].ToString(), Reader["other"].ToString(), Reader["practitionerID"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["emergencyID"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }


}
