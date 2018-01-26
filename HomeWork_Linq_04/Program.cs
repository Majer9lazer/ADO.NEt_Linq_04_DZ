using HomeWork_Linq_04.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


                Console.WriteLine("Выполнить полностью задание 3 нажмите 3");
                Console.WriteLine("Выполнить полностью задание 4 нажмите 4");
                int option = 0;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 3:
                        {
                            Stopwatch stp = new Stopwatch();
                            stp.Start();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнятеся задание : A");
                            BestStruct.Task_A();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Выполнятеся задание : B");
                            BestStruct.Task_B();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Выполнятеся задание : C");
                            BestStruct.Task_C();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Выполнятеся задание : D");
                            BestStruct.Task_D();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Выполнятеся задание : E");
                            BestStruct.Task_E();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Выполнятеся задание : F");
                            BestStruct.Task_F();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выполнятеся задание : G");
                            BestStruct.Task_G();
                            Console.ForegroundColor = ConsoleColor.White;
                            stp.Stop();
                            Console.WriteLine("Отработало за - " + stp.ElapsedMilliseconds + " миллисекунд, " + stp.ElapsedMilliseconds / 100 + " секунд, " + (stp.ElapsedMilliseconds / 100) / 60 + " минут");
                            break;
                        }
                    case 4:
                        {
                            Stopwatch stp = new Stopwatch();
                            stp.Start();
                            Console.ForegroundColor = ConsoleColor.Green;
                            BestStruct.Task_4_a_A(BestStruct.Task_A());
                            Console.ForegroundColor = ConsoleColor.Blue;
                            BestStruct.Task_4_b_F();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            BestStruct.Task_4_c_C();
                            Console.ForegroundColor = ConsoleColor.Red;
                            BestStruct.Task_4_d_G();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            BestStruct.Task_5();
                            Console.ForegroundColor = ConsoleColor.White;
                            stp.Stop();
                            Console.WriteLine("Отработало за - " + stp.ElapsedMilliseconds + " миллисекунд, " + stp.ElapsedMilliseconds / 100 + " секунд, " + (stp.ElapsedMilliseconds / 100) / 60 + " минут");
                            break;
                        }
                    default:
                        Console.WriteLine("Что-то не то ввел");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        struct BestStruct
        {
            public static XDocument Task_A()
            {
                var a = db.Areas.Where(w => w.PavilionId == 1).OrderByDescending(o => o.AreaId).Select(s => s).ToList();
                foreach (Area item in a)
                {
                    XDocument xdoc = new XDocument(
                        new XElement("Area",
                     new XElement("PavillionId", item.PavilionId), new XElement("AreaId", item.AreaId), new XElement("AreaName", item.Name)));
                    xdoc.Save("Task_A_File" + item.PavilionId.ToString());
                    return xdoc;
                }
                return null;
            }
            // Рабочий полностью
            public static void Task_B()
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
            public static void Task_C()
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
            public static void Task_D()
            {
                DirectoryInfo dir = new DirectoryInfo("Task_D_Directory");
                dir.Create();
                //  var b = db.Timers.Select(s => s.UserId.Value).ToList();
                var sorterdAreas = db.Areas.Where(w => w.IP != null);
                var a = db.Timers.Select(s => new
                {
                    s.UserId,
                    s.DateStart,
                    Name = sorterdAreas.FirstOrDefault(f => f.AreaId == s.AreaId).Name
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
            public static void Task_E()
            {
                Console.WriteLine("Выгружаем данные...");
                DirectoryInfo dir = new DirectoryInfo("Task_E_Directory");
                dir.Create();


                var a = db.Timers.Where(w => w.DateFinish == null).Select(s => new
                {
                    s.TimerId,
                    s.DateStart,
                    s.AreaId,
                    s.DateFinish,
                    s.UserId,
                    s.DurationInSeconds,


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
               new XElement("DateStart", item.DateStart),
               new XElement("DateFinish", item.DateFinish),
               new XElement("Userid", item.UserId),
               new XElement("DurationInSeconds", item.DurationInSeconds)));
                    xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.
                        AreaId.ToString() + ".xml");
                }

                Console.WriteLine("Данные были выгружены успешно");

            }
            public static void Task_F()
            {
                Console.WriteLine("Выгружаем данные...");
                DirectoryInfo dir = new DirectoryInfo("Task_F_Directory");
                DirectoryInfo sub_dir = null;
                dir.Create();
                var a = db.Timers.Where(w => w.DateFinish != null).Select(s => new
                {
                    s.TimerId,
                    s.DateStart,
                    s.AreaId,
                    s.DateFinish
                });
                Console.WriteLine("Вот сколько нужно выгрузить строк : " + a.Count());
                foreach (var item in a.ToList())
                {
                    sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                    sub_dir.Create();
                    //DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName + @"\" + item.AreaId);
                    //sub_subDir.Create();
                    XDocument xdoc = new XDocument(new XElement("Timer",
               new XElement("AreaId", item.AreaId),
               new XElement("TimerId", item.TimerId),
               new XElement("DateStart", item.DateStart),
               new XElement("DateFinish", item.DateFinish)));
                    xdoc.Save(sub_dir.FullName + @"\" + "_" + item.
                        AreaId.ToString() + ".xml");
                }
                Console.WriteLine("Данные были выгружены успешно");

            }
            public static void Task_G()
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
                    XDocument xdoc = new XDocument(new XElement(ns + "Area",
               new XElement(areaNs + "AreaId", item.AreaId),
               new XElement(areaNs + "IP", item.IP),
               new XElement(areaNs + "Name", item.Name)));
                    xdoc.Save(sub_subDir.FullName + @"\" + "_" + item.
                        AreaId.ToString() + ".xml");
                }
                Console.WriteLine("Данные были выгружены успешно");

            }
            public static void Task_4_a_A(XDocument xdoc)
            {
                if (xdoc == null)
                {
                    Console.WriteLine("Файл пришел пустым!");
                }
                else
                {
                    var a = xdoc.Elements().Where(w => w.Name == "Area").Elements();
                    Console.WriteLine("Вывод данных из задания А : ");
                    foreach (XElement item in a)
                    {
                        Console.WriteLine(item.Name + " : " + item.Value);
                    }
                }
            }
            public static void Task_4_b_F()
            {
                DirectoryInfo dir = new DirectoryInfo("Task_F_Directory");
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");

                if (sub_dir != null)
                {
                    Console.WriteLine("Загружаем данные для вывода из задания B");
                    FileInfo[] files = sub_dir.GetFiles();
                    DirectoryInfo changfedData = new DirectoryInfo(sub_dir.FullName + @"\" + "TodayChanges");
                    changfedData.Create();
                    Console.WriteLine("----------------");
                    int k = 0;
                    foreach (FileInfo item in files)
                    {

                        XDocument xdoc = XDocument.Load(sub_dir.FullName + @"\" + item);
                        var a = xdoc.Elements().Where(w => w.Name == "Timer").Elements();
                        foreach (var elem in a)
                        {

                            if (elem.Name == "DateFinish")
                            {
                                elem.Value = DateTime.Now.ToString();
                                xdoc.Save(changfedData.FullName + @"\" + "TimeChangeToday_" + k + "_" + string.Format("{0,9:d}", DateTime.Now));
                            }
                            Console.WriteLine(elem.Name + " : " + elem.Value);

                        }
                        k++;
                        Console.WriteLine("----------------");
                    }
                    Console.WriteLine("Данные были выведены и некоторые из них изменены");
                }
                else
                {
                    Console.WriteLine("Такая директория не существует");
                }
            }
            public static void Task_4_c_C()
            {
                Console.WriteLine("Загружаем данные из задания C ...");
                DirectoryInfo dir = new DirectoryInfo("Task_C_Directory");
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Areas");
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName);
                var a = dir.GetFiles();
                var b = sub_subDir.GetDirectories();
                Console.WriteLine("________________");
                foreach (DirectoryInfo item in b)
                {
                    var c = item.GetFiles();
                    foreach (FileInfo file in c)
                    {
                        var d = file.FullName;
                        XDocument xdoc = XDocument.Load(file.FullName);
                        var elements = xdoc.Elements().Where(w => w.Name == "Area").Elements();
                        foreach (XElement element in elements)
                        {
                            Console.WriteLine(element.Name + " : " + element.Value);
                        }
                    }
                    Console.WriteLine("________________");
                }
            }
            public static void Task_4_d_G()
            {



                Console.WriteLine("Загружаем данные из задания D ..."); ;
                DirectoryInfo dir = new DirectoryInfo("Task_E_Directory");
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName);


                var b = sub_subDir.GetDirectories();
                Console.WriteLine("________________");
                foreach (DirectoryInfo item in b)
                {
                    var c = item.GetFiles();
                    foreach (FileInfo file in c)
                    {

                        XDocument xdoc = XDocument.Load(file.FullName);
                        var elements = xdoc.Elements().Where(w => w.Name == "Timer").Elements();
                        foreach (XElement element in elements)
                        {
                            Console.WriteLine(element.Name + " : " + element.Value);
                        }

                    }
                    Console.WriteLine("________________");
                }

                Console.WriteLine("Все данные были выгружены успешно!");
            }
            public static void Task_5()
            {
                Console.WriteLine("Загружаем данные из задания 5 ...");
                DirectoryInfo dir = new DirectoryInfo("Task_E_Directory");
                DirectoryInfo sub_dir = new DirectoryInfo(dir.FullName + @"\" + "Timers");
                DirectoryInfo sub_subDir = new DirectoryInfo(sub_dir.FullName);
                var b = sub_subDir.GetDirectories();
                Console.WriteLine("________________");
                List<string> counts = new List<string>();
                foreach (DirectoryInfo item in b)
                {
                    var c = item.GetFiles();
                    foreach (FileInfo file in c)
                    {

                        XDocument xdoc = XDocument.Load(file.FullName);
                        var elements = xdoc.Elements().Where(w => w.Name == "Timer").Elements();
                        foreach (XElement element in elements)
                        {
                            Console.WriteLine(element.Name + " : " + element.Value);
                            if (element.Name == "AreaId")
                            {
                                counts.Add(element.Name.LocalName);
                            }
                        }

                    }
                    Console.WriteLine("________________");
                }
                Console.WriteLine("Количество незавершенных работ = " + counts.Count);
                Console.WriteLine("Все данные были выгружены успешно!");
                Console.WriteLine("Это было последнее задание. Так вот всё было сделано кроме пунтка 5_подпунка_c\n" +
                    "Так как по логике невозможно найти сумму потраченного времени когда РАБОТА ЕЩЕ НЕ ЗАВЕРШИЛАСЬ!!!!!");

            }
        }
    }
}
