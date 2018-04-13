using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Order
    {
        private string id;
        private string customerID;
        private string userID;
        private string itemID;
        private string orderDateTime;
        private string orderBy;
        private string dispenseDateTime;
        private string dispenseBy;
        private string customerType;
        private string diagnosis;
        private string surgery;
        private string clinicalDate;
        private string equipmentLimits;
        private string equipmentHeights;
        private string equipmentWeights;
        private string equipmentInstructions;
        private string equipmentPeriod;
        private string setupLocation;
        private string setupDate;
        private string dischargeLocation;
        private string dischargeDate;
        private string notification;
        private string notificationDate;
        private string authorization;
        private string authorizationDate;       
        private string created;
        private bool sync;
        private string action;
        private string other;
        public Order() { }

        public Order(string id, string customerID, string userID, string itemID, string orderDateTime, string orderBy, string dispenseDateTime, string dispenseBy, string customerType, string diagnosis, string surgery, string clinicalDate, string equipmentLimits, string equipmentHeights, string equipmentWeights, string equipmentInstructions, string equipmentPeriod, string setupLocation, string setupDate, string dischargeLocation, string dischargeDate, string notification, string notificationDate, string authorization, string authorizationDate, string created, bool sync, string action, string other)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.UserID = userID;
            this.ItemID = itemID;
            this.OrderDateTime = orderDateTime;
            this.OrderBy = orderBy;
            this.DispenseDateTime = dispenseDateTime;
            this.DispenseBy = dispenseBy;
            this.CustomerType = customerType;
            this.Diagnosis = diagnosis;
            this.Surgery = surgery;
            this.ClinicalDate = clinicalDate;
            this.EquipmentLimits = equipmentLimits;
            this.EquipmentHeights = equipmentHeights;
            this.EquipmentWeights = equipmentWeights;
            this.EquipmentInstructions = equipmentInstructions;
            this.EquipmentPeriod = equipmentPeriod;
            this.SetupLocation = setupLocation;
            this.SetupDate = setupDate;
            this.DischargeLocation = dischargeLocation;
            this.DischargeDate = dischargeDate;
            this.Notification = notification;
            this.NotificationDate = notificationDate;
            this.Authorization = authorization;
            this.AuthorizationDate = authorizationDate;
            this.Created = created;
            this.Sync = sync;
            this.Action = action;
            this.Other = other;
        }

        static List<Order> p = new List<Order>();

       

        public static List<Order> List()
        {
            string Q = "SELECT * FROM Order ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Order ps = new Order(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["equipmentLimits"].ToString(), Reader["equipmentHeights"].ToString(), Reader["equipmentWeights"].ToString(), Reader["equipmentInstructions"].ToString(), Reader["equipmentPeriod"].ToString(), Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authorization"].ToString(), Reader["authorizationDate"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["action"].ToString(), Reader["other"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        private static Order c = new Order();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string UserID { get => userID; set => userID = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string OrderDateTime { get => orderDateTime; set => orderDateTime = value; }
        public string OrderBy { get => orderBy; set => orderBy = value; }
        public string DispenseDateTime { get => dispenseDateTime; set => dispenseDateTime = value; }
        public string DispenseBy { get => dispenseBy; set => dispenseBy = value; }
        public string CustomerType { get => customerType; set => customerType = value; }
        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        public string Surgery { get => surgery; set => surgery = value; }
        public string ClinicalDate { get => clinicalDate; set => clinicalDate = value; }
        public string EquipmentLimits { get => equipmentLimits; set => equipmentLimits = value; }
        public string EquipmentHeights { get => equipmentHeights; set => equipmentHeights = value; }
        public string EquipmentWeights { get => equipmentWeights; set => equipmentWeights = value; }
        public string EquipmentInstructions { get => equipmentInstructions; set => equipmentInstructions = value; }
        public string EquipmentPeriod { get => equipmentPeriod; set => equipmentPeriod = value; }
        public string SetupLocation { get => setupLocation; set => setupLocation = value; }
        public string SetupDate { get => setupDate; set => setupDate = value; }
        public string DischargeLocation { get => dischargeLocation; set => dischargeLocation = value; }
        public string DischargeDate { get => dischargeDate; set => dischargeDate = value; }
        public string Notification { get => notification; set => notification = value; }
        public string NotificationDate { get => notificationDate; set => notificationDate = value; }
        public string Authorization { get => authorization; set => authorization = value; }
        public string AuthorizationDate { get => authorizationDate; set => authorizationDate = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string Action { get => action; set => action = value; }
        public string Other { get => other; set => other = value; }

        public static Order Select(string id)
        {
            string Q = "SELECT * FROM order WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Order(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["orderDateTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDateTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["equipmentLimits"].ToString(), Reader["equipmentHeights"].ToString(), Reader["equipmentWeights"].ToString(), Reader["equipmentInstructions"].ToString(), Reader["equipmentPeriod"].ToString(), Reader["setupLocation"].ToString(), Reader["setupDate"].ToString(), Reader["dischargeLocation"].ToString(), Reader["dischargeDate"].ToString(), Reader["notification"].ToString(), Reader["notificationDate"].ToString(), Reader["authorization"].ToString(), Reader["authorizationDate"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["action"].ToString(), Reader["other"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }
    }
    

}
