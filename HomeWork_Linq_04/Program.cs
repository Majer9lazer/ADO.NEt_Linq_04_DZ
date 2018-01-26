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
        static Local_DB db = new Local_DB();
        static void Main(string[] args)
        {
            try
            {
                Task_D();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        private static void Task_A()
        {
            var a = db.Areas.Where(w => w.PavilionId == 1).OrderByDescending(o => o.AreaId).Select(s => s).ToList();
            foreach (Area item in a)
            {
                XDocument xdoc = new XDocument(
                    new XElement("Area",
                 new XElement("PavillionId", item.PavilionId), new XElement("AreaId", item.AreaId), new XElement("AreaName", item.Name)));
                xdoc.Save(item.PavilionId.ToString());

            }
        }
        // Рабочий полностью
        private static void Task_B()
        {
            //Directory.CreateDirectory("Area");
            DirectoryInfo dir = new DirectoryInfo("Task_C_Directory");
            dir.Create();
            List<Area> a = new List<Area>();
            try
            {
                a = db.Areas.OrderByDescending(o => o.AreaId).Select(s => s).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                a = null;

            }
            if (a != null)
            {
                foreach (Area item in a)

                {
                    Directory.CreateDirectory(dir.FullName + @"\" + item.Name);
                }
                Console.WriteLine("Директории были успешно добавлены!");
            }
            else
            {
                Console.WriteLine("На какой-то стадии возникла ошибка!");
            }
        }
        private static void Task_C()
        {
            DirectoryInfo dir = new DirectoryInfo("Task_C_Directory");
            dir.Create();
            List<Area> a = new List<Area>();
            try
            {
                a = db.Areas.Where(w => w.ParentId == 0).OrderByDescending(o => o.AreaId).Select(s => s).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                a = null;

            }
            if (a != null)
            {


                foreach (Area item in a)

                {

                    DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Areas");
                    sub_dir.Create();
                    DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.Name);
                    sub_subDir.Create();
                    //Directory.CreateDirectory(sub_dir.FullName + @"\" + item.Name);
                    XDocument xdoc = new XDocument(new XElement("Area",
                        new XElement("AreaId", item.AreaId),
                        new XElement("AreaName", item.FullName),
                        new XElement("AreaIp", item.IP)));

                    xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.AreaId);
                }

                Console.WriteLine("Директории были успешно добавлены!");
            }


            else
            {
                Console.WriteLine("На какой-то стадии возникла ошибка!");
            }
        }
        private static void Task_D()
        {
            DirectoryInfo dir = new DirectoryInfo("Task_D_Directory");
            dir.Create();
            //  var b = db.Timers.Select(s => s.UserId.Value).ToList();
            var sorterdAreas = db.Areas.Where(w => w.IP != null);
                var a = db.Timers.Select(s => new
                {
                    s.UserId,
                    s.DateStart,
                    Name=sorterdAreas.FirstOrDefault(f=>f.AreaId==s.AreaId).Name
                }).ToList();
            foreach (var item in a)
            {
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                sub_dir.Create();
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.Name);
                sub_subDir.Create();
                XDocument xdoc = new XDocument(new XElement("Area",
           new XElement("AreaName", item.Name),
           new XElement("TimerUserId", item.UserId),
           new XElement("TimerDateStart", item.DateStart)));
                xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.UserId.ToString());
            }
            Console.WriteLine("Данные успешно выгружены!\nНо База Чето Не оч)");
        }
    }
}
