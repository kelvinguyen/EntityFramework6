using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Classess;

namespace NinjaDomain.DataModel
{
    public class DataHelpers
    {
        public static void NewDBWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            using (var context = new NinjaContext())
            {
                if (context.Ninjas.Any())
                    return;

                var vtclas = context.Clans.Add(new Clan { ClanName = "White Clan" });
            }
        }
    }
}
