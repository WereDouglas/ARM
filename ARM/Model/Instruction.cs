using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Instruction
    {
        private string id;
        private string customerID;
        private string userID;
        private string itemID;
        private string date;      
        private string type;
        private string altContact;
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
        private string kinName;
        private string kinContact;
        private string kinAddress;
        private string reason;
        private string userSignature;
        private string created;
        private bool sync;       
        public Instruction() { }

        public Instruction(string id, string customerID, string userID, string itemID, string date, string type, string altContact, string safety, string appropriate, string appropriateSelection, string safetyOther, string phone, string equipmentType, string equipmentOther, string additional, string additionalNotes, string followUp, string signature, string kinName, string kinContact, string kinAddress, string reason, string userSignature, string created, bool sync)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.UserID = userID;
            this.ItemID = itemID;
            this.Date = date;
            this.Type = type;
            this.AltContact = altContact;
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
            this.KinName = kinName;
            this.KinContact = kinContact;
            this.KinAddress = kinAddress;
            this.Reason = reason;
            this.UserSignature = userSignature;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Instruction> p = new List<Instruction>();

        public static List<Instruction> List()
        {
            p.Clear();
            string Q = "SELECT * FROM instruction ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Instruction ps = new Instruction(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["date"].ToString(), Reader["type"].ToString(), Reader["altContact"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["kinName"].ToString(), Reader["kinContact"].ToString(), Reader["kinAddress"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"].ToString()));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        private static Instruction c = new Instruction();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string UserID { get => userID; set => userID = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string Date { get => date; set => date = value; }
        public string Type { get => type; set => type = value; }
        public string AltContact { get => altContact; set => altContact = value; }
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
        public string KinName { get => kinName; set => kinName = value; }
        public string KinContact { get => kinContact; set => kinContact = value; }
        public string KinAddress { get => kinAddress; set => kinAddress = value; }
        public string Reason { get => reason; set => reason = value; }
        public string UserSignature { get => userSignature; set => userSignature = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static Instruction Select(string id)
        {
            string Q = "SELECT * FROM instruction WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Instruction(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["date"].ToString(), Reader["type"].ToString(), Reader["altContact"].ToString(), Reader["safety"].ToString(), Reader["appropriate"].ToString(), Reader["appropriateSelection"].ToString(), Reader["safetyOther"].ToString(), Reader["phone"].ToString(), Reader["equipmentType"].ToString(), Reader["equipmentOther"].ToString(), Reader["additional"].ToString(), Reader["additionalNotes"].ToString(), Reader["followUp"].ToString(), Reader["signature"].ToString(), Reader["kinName"].ToString(), Reader["kinContact"].ToString(), Reader["kinAddress"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(),Convert.ToBoolean(Reader["sync"].ToString()));
            }
            DBConnect.CloseConn();
            return c;

        }
    }
    

}
