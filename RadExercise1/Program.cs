using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1();
            Console.ReadKey();
            Q2(DateTime.Now.Date);
            Console.ReadKey();
            Q3();
            Console.ReadKey();
            Q4();
            Console.ReadKey();
            Q5();
            Console.ReadKey();
            Q7();
            Console.ReadKey();
            Q8();
            Console.ReadKey();
            Q9();
            Console.ReadKey();

        }

        public static void Q1()
        {
            using (TestDbContext db = new TestDbContext())
            {
                foreach (Club c in db.Clubs)
                {
                    Console.WriteLine(c.Info);
                }
            }

         }   

        public static void Q2(DateTime dt)
        {
            using (TestDbContext db = new TestDbContext())

                foreach (Club c in db.Clubs)
                {
                    var q2 = from ce in c.ClubEvents
                             where ce.StartDateTime.Date == dt.Date
                             select ce;
                    foreach (ClubEvent ce in q2)
                    {
                        Console.WriteLine(ce.Venue + ' ' + ce.StartDateTime.Date);
                    }

                    
                }
        }

        public static void Q3()
        {
            using (TestDbContext db = new TestDbContext())

                foreach (Club c in db.Clubs)
                {
                    var q3 = from eo in c.ClubEvents
                             where c.ClubName == "ITS FC"
                             select eo;
                    foreach (ClubEvent eo in q3)
                    {
                        Console.WriteLine(c.ClubName + ' ' + eo.Venue + ' ' + eo.StartDateTime.Date);
                    }
                }
        }

        public static void Q4()
        {
            using (TestDbContext db = new TestDbContext())
                foreach (Club c in db.Clubs)
                {
                    var q4 = from mem in c.ClubMembers
                             where c.ClubName == "ITS FC"
                             select mem;
                    foreach (Member mem in q4)
                    {
                        Console.WriteLine(c.ClubName + ' ' + mem.memberID);
                    }
                }
        }

        public static void Q5()
        {
            using (TestDbContext db = new TestDbContext())
                foreach (Club c in db.Clubs)
                {
                    var q5 = from mem in c.ClubMembers
                             where mem.approved == false
                             select mem;
                    foreach (Member mem in q5)
                    {
                        Console.WriteLine(c.ClubName + ' ' + mem.memberID);
                    }
                }
        }

        public static void Q7()
        {
            using (TestDbContext db = new TestDbContext())
            {
                var q7 = from c in db.Clubs
                         orderby c.ClubName
                         select c.Info;
                Console.WriteLine(q7);
            }
                 
        }

        public static void Q8()
        {
            using (TestDbContext db = new TestDbContext())
            {
                var q8 = from c in db.Clubs
                         join s in db.Students on c.adminID equals s.playerid
                         orderby s.FirstName
                         select s;
                foreach (Student student in q8)
                {
                    Console.WriteLine(student.FirstName + " " + student.SecondName);
                }

            }
        }

        static void Q9()
        {
            using (TestDbContext db = new TestDbContext())
                foreach(Club c in db.Clubs)
                {
                    var q9 = from m in c.ClubMembers
                             select m.memberID;
                    Console.WriteLine(c.ClubName);
                }
        }

    }
}
