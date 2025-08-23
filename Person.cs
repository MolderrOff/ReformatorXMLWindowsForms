using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace for_video
{
    [XmlRoot("Employees")]
    public class Employees
    {
        [XmlElement(typeof(Employee))]
        public Employee[] Employee;
    }

    [XmlType("Employee")]
    public class Employee
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public string Surname;
        [XmlAttribute]
        public double QuarterAmount;
        [XmlElement(typeof(Salary))]
        public Salary[] salary;
    }
    [XmlType("salary")]
    public class Salary
    {
        [XmlAttribute("amount")]
        public double Amount;
        [XmlAttribute("mount")]
        public string Mount;
    }
}
   