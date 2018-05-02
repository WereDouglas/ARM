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
    public class Payroll
    {
        private string employee;
        private string client;       
        private string account;
        private double days;
        private string date;
        private double hours;
        private double rate;
        private double total;
        private double deduction;
        private double payable;
       

        static List<Payroll> p = new List<Payroll>();
        public Payroll() { }

        public Payroll(string employee, string client, string account, double days, string date, double hours, double rate, double total, double deduction, double payable)
        {
            this.Employee = employee;
            this.Client = client;
            this.Account = account;
            this.Days = days;
            this.Date = date;
            this.Hours = hours;
            this.Rate = rate;
            this.Total = total;
            this.Deduction = deduction;
            this.Payable = payable;
        }

        static Payroll c = new Payroll();

        public string Employee { get => employee; set => employee = value; }
        public string Client { get => client; set => client = value; }
        public string Account { get => account; set => account = value; }
        public double Days { get => days; set => days = value; }
        public string Date { get => date; set => date = value; }
        public double Hours { get => hours; set => hours = value; }
        public double Rate { get => rate; set => rate = value; }
        public double Total { get => total; set => total = value; }
        public double Deduction { get => deduction; set => deduction = value; }
        public double Payable { get => payable; set => payable = value; }
    }
}