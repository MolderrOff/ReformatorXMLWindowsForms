using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using net.sf.saxon.om;

namespace for_video
{
    [XmlRoot("Pay")]
    public class Pay
    {
        [XmlElement(typeof(Item))]
        public Item[] item;
        [XmlAttribute("allmount")]
        public double AllMount;
    }
    [XmlType("item")]
    public class Item
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("surname")]
        public string Surname;
        [XmlAttribute("amount")]
        public double Amount;
        [XmlAttribute("mount")]
        public string Mount;
    }
}
