using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carsaleproject
{
    class formLoad
    {
       public static void customerLoad(){
           customer a = new customer();
           a.Show();
       }

     
       public static void supplierLoad()
       {
          Supplier a1 = new Supplier();
           a1.Show();
       }

       public static void employeeLoad()
       {
           Employee a2 = new Employee();
           a2.Show();
       }

       public static void invoiceLoad()
       {
           Invoice a3 = new Invoice();
           a3.Show();
       }

       public static void salaryLoad()
       {
           Salary a4 = new Salary();
           a4.Show();
       }

       public static void productLoad()
       {
           Product a5 = new Product();
           a5.Show();
       }

       public static void homeLoad()
       {
           Home a6 = new Home();
           a6.Show();
       }
       public static void reportLoad()
       {
           report a7 = new report();
           a7.Show();
       
       }
    }
}
