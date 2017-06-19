using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (var db = new Models.MyContext())
                {
                    db.Database.Migrate();
                    var isInit = Models.Setting.Get(db, "IsInit");
                    if (isInit != "true")
                    {
                        Models.Setting.Set(db, "IsInit", "true");
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Wlniao.log.Error("Database connect error:" + ex.Message);
            }
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://*:" + Wlniao.XCore.ListenPort)
                .Build();
            host.Run();
        }
    }
}
