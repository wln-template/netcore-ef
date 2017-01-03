using System;
using Microsoft.EntityFrameworkCore;
using Wlniao;
namespace Models
{
    public class MyContext : DbContext
    {
        private static string connstr = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connstr == null)
            {
                connstr = DbConnectInfo.WLN_CONNSTR;
            }
            if (string.IsNullOrEmpty(connstr))
            {
                optionsBuilder.UseSqlite("Data Source=" + Wlniao.IO.PathTool.Map(Wlniao.XCore.StartupRoot, "xcore", "xcore.db"));
            }
            else
            {
                if (string.IsNullOrEmpty(DbConnectInfo.WLN_MYSQL_PWD))
                {
                    optionsBuilder.UseSqlServer(connstr, b => b.UseRowNumberForPaging());
                }
                else
                {
                    optionsBuilder.UseMySql(connstr);
                }
            }
        }
        public static String NewId()
        {
            return DateTime.Now.Ticks.ToString() + "-" + strUtil.CreateRndStr(3);
        }

        public DbSet<Models.Setting> Setting { get; set; }
        public DbSet<Models.ExtendField> ExtendField { get; set; }
    }
}