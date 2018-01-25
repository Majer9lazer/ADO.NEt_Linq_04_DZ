using HomeWork_Linq_04.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace HomeWork_Linq_04
{
    class Program
    {
        static CRCMS_new db = new CRCMS_new();
        static void Main(string[] args)
        {
            Task_B();
        }
        private static void Task_A()
        {
            var a = db.Areas.Where(w => w.PavilionId == 1).Select(s => s).ToList();
            foreach (Area item in a)
            {
                XDocument xdoc = new XDocument(
                    new XElement("Area",
                 new XElement("PavillionId", item.PavilionId), new XElement("AreaId", item.AreaId), new XElement("AreaName", item.Name)));
                xdoc.Save(item.PavilionId.ToString());

            }
        }
        //Почти рабочий
        private static void Task_B()
        {
            var a  = db.Areas.Select(s => s).ToList();
            foreach (Area item in a)
            {
                Directory.CreateDirectory(item.Name);
             
            }
        }
    }
}
