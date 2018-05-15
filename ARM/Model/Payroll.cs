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
        private string category;
        private double days;        
        private string date;
        private double hours;
        private double rate;
        private double total;
        private double deduction;
        private double payable;
        private double overtime;
        private double overtimePay;
        // private double overTimeHrs;


        static List<Payroll> p = new List<Payroll>();
        public Payroll() { }

        public Payroll(string employee, string client, string account, string category, double days, string date, double hours, double rate, double total, double deduction, double payable, double overtime, double overtimePay)
        {
            this.Employee = employee;
            this.Client = client;
            this.Account = account;
            this.Category = category;
            this.Days = days;
            this.Date = date;
            this.Hours = hours;
            this.Rate = rate;
            this.Total = total;
            this.Deduction = deduction;
            this.Payable = payable;
            this.Overtime = overtime;
            this.OvertimePay = overtimePay;
        }

        static Payroll c = new Payroll();

        public string Employee { get => employee; set => employee = value; }
        public string Client { get => client; set => client = value; }
        public string Account { get => account; set => account = value; }
        public string Category { get => category; set => category = value; }
        public double Days { get => days; set => days = value; }
        public string Date { get => date; set => date = value; }
        public double Hours { get => hours; set => hours = value; }
        public double Rate { get => rate; set => rate = value; }
        public double Total { get => total; set => total = value; }
        public double Deduction { get => deduction; set => deduction = value; }
        public double Payable { get => payable; set => payable = value; }
        public double Overtime { get => overtime; set => overtime = value; }
        public double OvertimePay { get => overtimePay; set => overtimePay = value; }
    }
}