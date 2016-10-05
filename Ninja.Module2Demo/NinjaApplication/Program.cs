using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Classess;
using NinjaDomain.DataModel;
using System.Data.Entity;

namespace NinjaApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            //InsertNinja();
            UpdateNinja();
        }
        public static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "Ninja 2",
                ServedInOniwaban = false,
                ClanId = 1,
                DateOfBirth = new DateTime(1992,1,1)
            };
           
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        public static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Ninja 2",
                ServedInOniwaban = false,
                ClanId = 1,
                DateOfBirth = new DateTime(1992, 1, 1)
            };
            var ninja2 = new Ninja
            {
                Name = "Ninja 1",
                ServedInOniwaban = false,
                ClanId = 1,
                DateOfBirth = new DateTime(1992, 1, 1)
            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Add(ninja);
                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            }
        }

        public static void SimpleNinjaQuery()
        {
            using (var context = new NinjaContext())
            {
                var ninjalist = context.Ninjas.ToList();
            }
               
        }

        private static void UpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.Name = "Ninja is Update";
                context.SaveChanges();
            }
        }

        /*
         * Find will look in memory first and see if object is there 
         * If not then execute the sql query to database
         * Find : using key index 
         */ 
        private static void QueryUsingFind()
        {
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas.Find(2);
            }
        }

        /*
         * Sqlquery : allow you to write query string as param
         */ 
         private static void RetriveDataUsingDataProc()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // getOldNinjas is the store procedure that you write and
                // save in your database underr programmability
                var ninjas = context.Ninjas.SqlQuery("exec getOldNinjas");
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }

        private static void DeleteNinja()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                ninja = context.Ninjas.FirstOrDefault();
            }

            using (var context = new NinjaContext())
            {
                // the context is destroy so EF won't remember this ninja 
                // you can either attach ninja, so EF can recall it
                context.Ninjas.Attach(ninja);
                context.Ninjas.Remove(ninja);

                // or you can use Entry method and set the state to delete
                context.Entry(ninja).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        private static void deleteNinjaUsingStoreProcedure()
        {
            int valkey = 4;
            using (var context = new NinjaContext())
            {
                /*
                 * sqlquery vs ExecuteSqlCommand
                 * - sqlquery is query your DBSet and return entities from database
                 * - Execute is query context.Database and it run cmd and return status code
                 */ 
                context.Database.ExecuteSqlCommand("exec yourStoreProcedure {0}",valkey);
            }
        }

        private static void QueryObjectInvoleWithMultipleTable()
        {
            using (var context = new NinjaContext())
            {
                /*
                 * - Include will go to equipment table and get data 
                 *   using index key in ninja table
                 * - This is eager loading : load data in advance
                 */ 
                var ninjas = context.Ninjas.Include(n => n.EquipmentOwned);

                /*
                 * - or Explicit loading : you can load equipment data on the fly
                 *      - Entry : go back to database and look for that ninja
                 *      - Collection : find the equiment in the equipment table
                 *      - Load : explicit loading
                 */
                var ninja = context.Ninjas.FirstOrDefault(n => n.Name == "kieu lam");

                context.Entry(ninja).Collection(n => n.EquipmentOwned).Load();

                /*
                 * Lazy load : only load when it needed
                 *  - to do lazy load, you only need to go to ninja class
                 *    and set EquipmentOwned property to virtual.
                 *  - This will cause EF to override some logic behind the scene 
                 *    for lazy loading
                 */

                /*
                 * Projection query : allow you to return only property that you needed
                 *      - It also able to access data from other table
                 */
                var projectionNinja = context.Ninjas
                                        .Select(
                        nin => new { nin.Name, nin.EquipmentOwned,nin.Clan.ClanName });
            }
        }
    }
   
}
