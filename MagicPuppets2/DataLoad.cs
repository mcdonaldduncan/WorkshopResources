using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MagicPuppets
{
    class DataLoad
    {
        public static List<Puppet> LoadXML(string filename)
        {
            List<Puppet> puppets = new List<Puppet>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode root = doc.DocumentElement;
            XmlNodeList puppetList = root.SelectNodes("/puppets/puppet");
            doc.AppendChild(root);
            foreach (XmlElement x in puppetList)
            {
                puppets.Add(new Puppet
                {
                    Name = x.GetAttribute("name"),
                    Material1 = x.GetAttribute("material1"),
                    Material2 = x.GetAttribute("material2"),
                    Material3 = x.GetAttribute("material3"),
                    Value = Convert.ToInt32(x.GetAttribute("value"))
                });

            }
            return puppets;
        }

    }
}
