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
    public class Product
    {
		private string id;
        private string name;
        private string code;
        private string category;
        private string type;
        private string description;
        private string cost;
        private string batch;
        private string serial;
        private string barcode;
        private string unitOfMeasure;
        private string measureDescription;
        private string manufacturer;
        private string created;
        private string sync;
        private string companyID;
        private string image;
		private string expires;
		public Product() { }

        public Product(string id, string name, string code, string category, string type, string description, string cost, string batch, string serial, string barcode, string unitOfMeasure, string measureDescription, string manufacturer, string created, string sync, string companyID, string image,string expires)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Category = category;
            this.Type = type;
            this.Description = description;
            this.Cost = cost;
            this.Batch = batch;
            this.Serial = serial;
            this.Barcode = barcode;
            this.UnitOfMeasure = unitOfMeasure;
            this.MeasureDescription = measureDescription;
            this.Manufacturer = manufacturer;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Image = image;
			this.Expires = expires;
        }

        static List<Product> p = new List<Product>();
        public static MySqlDataReader Reader;

        public static List<Product> List()
        {
            p.Clear();
            string Q = "SELECT * FROM product ";
		    Reader = MySQL.Reading(Q);
			while (Reader.Read())
            {
                Product ps = new Product(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batch"].ToString(), Reader["serial"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(),Reader["expires"].ToString());
                p.Add(ps);
            }
		
			return p;

        }
        public static List<Product> List(string Q)
        {
            try
            {
                p.Clear();
				Reader = MySQL.Reading(Q);
				while (Reader.Read())
                {
                    Product ps = new Product(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batch"].ToString(), Reader["serial"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["expires"].ToString());
					p.Add(ps);
                }
			
			}
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine("" + e);
            }
            return p;
        }
        
        static Product c = new Product();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
        public string Category { get => category; set => category = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Cost { get => cost; set => cost = value; }
        public string Batch { get => batch; set => batch = value; }
        public string Serial { get => serial; set => serial = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string UnitOfMeasure { get => unitOfMeasure; set => unitOfMeasure = value; }
        public string MeasureDescription { get => measureDescription; set => measureDescription = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Created { get => created; set => created = value; }
        public string Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string Image { get => image; set => image = value; }
		public string Expires { get => expires; set => expires = value; }

		public static Product Select(string ID)
        {
            string Q = "SELECT * FROM product WHERE id = '" + ID + "'";
			 Reader = MySQL.Reading(Q);
			while (Reader.Read())
            {
                c = new Product(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batch"].ToString(), Reader["serial"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["expires"].ToString());
			}
		
			return c;

        }


    }

}
