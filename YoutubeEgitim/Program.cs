using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEgitim
{
    internal class Program
    {
        static void Main(string[] args)
        {


            CustomerManeger customerManager=new CustomerManeger(new Customer(),new MilitaryCreditManager());
            customerManager.GiveCredit(); 
            CustomerManeger customerManager2=new CustomerManeger(new Customer(),new TeacherCreditManager());
            customerManager2.GiveCredit();

            //Creditmanager creditmanager = new Creditmanager();
            //creditmanager.Calculate();
            //creditmanager.Calculate();
            //creditmanager.Save();

            //Customer customer = new Customer();
            //customer.Id = 1;
            //customer.City = "Ankara";


            //CustomerManeger customerManeger = new CustomerManeger(customer);
            //customerManeger.Save();
            //customerManeger.Delete();

            //Company company = new Company();
            //company.TaxNumber="10000";
            //company.CompanyName = "Arçelik";
            //company.Id = 100;

            //CustomerManeger customerManager2= new CustomerManeger(new Person());

            //Person person = new Person();
            //person.NationalIdentity= "01234567890";

            //Customer c1=new Customer();
            //Customer c2 = new Person();
            //Customer c3=new Company();

            Console.ReadLine();
        }
    }

    class Creditmanager
    {
        public void Calculate() 
        {
            Console.WriteLine("Hesaplandı.");
        }
        public void Save()
        {
            Console.WriteLine("Kredi verildi.");
        }

    }
    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();
        

        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi.");
        }
    }

    class TeacherCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Öğretmen Kredisi hesaplandı."); 
        }
        public override void Save()
        {
            //
            base.Save();
            //
        }


    }
    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker Kredisi hesaplandı.");
        }

      
    }

    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı.");
        }
        public int Id { get; set; }
        
        public string City { get; set; }

    }
    class Person:Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }
    class Company:Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }

    class CustomerManeger
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManeger(Customer customer,ICreditManager creditManager)
        {
                _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine("Müşteri kaydedildi.");
        }
        public void Delete()
        {
            Console.WriteLine("Müşteri silindi." );
        }
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }


    }
}
