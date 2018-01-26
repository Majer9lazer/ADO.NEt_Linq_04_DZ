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
                //Task_A();
                Task_B();
                //Task_C();
                //Task_D();
                //Task_E();
                //Task_F();
                //Task_G();
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
                xdoc.Save("Task_A_File"+item.PavilionId.ToString());

            }
        }
        // Рабочий полностью
        private static void Task_B()
        {
            //Directory.CreateDirectory("Area");
            DirectoryInfo dir = new DirectoryInfo("Task_B_Directory");
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
                XDocument xdoc = new XDocument(new XElement("AreaAndTimer",
           new XElement("AreaName", item.Name),
           new XElement("TimerUserId", item.UserId),
           new XElement("TimerDateStart", item.DateStart)));
                xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.UserId.ToString());
            }
            Console.WriteLine("Данные успешно выгружены!\nНо База Чето Не оч)");
        }
        private static void Task_E()
        {
            Console.WriteLine("Выгружаем данные...");
            DirectoryInfo dir = new DirectoryInfo("Task_E_Directory");
            dir.Create();
            var a = db.Timers.Where(w => w.DateFinish == null).Select(s => new
            {
                s.TimerId,
                s.DateStart,
                s.AreaId
            });
            foreach (var item in a.ToList())
            {
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                sub_dir.Create();
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.AreaId);
                sub_subDir.Create();
                XDocument xdoc = new XDocument(new XElement("Timer",
           new XElement("AreaId", item.AreaId),
           new XElement("TimerId", item.TimerId),
           new XElement("DateStart", item.DateStart)));
                xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.
                    AreaId.ToString()+".xml");
            }
            Console.WriteLine("Данные были выгружены успешно");

        }
        private static void Task_F()
        {
            Console.WriteLine("Выгружаем данные...");
            DirectoryInfo dir = new DirectoryInfo("Task_F_Directory");
            dir.Create();
            var a = db.Timers.Where(w => w.DateFinish != null).Select(s => new
            {
                s.TimerId,
                s.DateStart,
                s.AreaId,
                s.DateFinish
            });
            Console.WriteLine("Вот сколько нужно выгрузить строк : "+a.Count());
            foreach (var item in a.ToList())
            {
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                sub_dir.Create();
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.AreaId);
                sub_subDir.Create();
                XDocument xdoc = new XDocument(new XElement("Timer",
           new XElement("AreaId", item.AreaId),
           new XElement("TimerId", item.TimerId),
           new XElement("DateStart", item.DateStart)));
                xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.
                    AreaId.ToString() + ".xml");
            }
            Console.WriteLine("Данные были выгружены успешно");

        }
        private static void Task_G()
        {
            Console.WriteLine("Выгружаем данные...");
            DirectoryInfo dir = new DirectoryInfo("Task_G_Directory");
            dir.Create();
            var a = db.Areas.Select(s => new
            {
                s.AreaId,
                s.IP,
                s.Name
            });
            Console.WriteLine("Вот сколько нужно выгрузить строк : " + a.Count());
            XNamespace ns = "http://logbook.itstep.org/";
            XNamespace areaNs = "area";
            foreach (var item in a.ToList())
            {
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                sub_dir.Create();
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.Name);
                sub_subDir.Create();
                XDocument xdoc = new XDocument(new XElement(ns+  "Area",
           new XElement(areaNs + "AreaId", item.AreaId),
           new XElement(areaNs+"IP", item.IP),
           new XElement(areaNs+"Name", item.Name)));
                xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.
                    AreaId.ToString() + ".xml");
            }
            Console.WriteLine("Данные были выгружены успешно");

        }
        private static void Task_4_A()
        {

        }
    }
}
