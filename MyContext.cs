using System;
using Microsoft.EntityFrameworkCore;
using Wlniao;
namespace Models
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(DbConnectInfo.WLN_CONNSTR_MYSQL))
            {
                optionsBuilder.UseMySql(DbConnectInfo.WLN_CONNSTR_MYSQL);
            }
            else if (!string.IsNullOrEmpty(DbConnectInfo.WLN_CONNSTR_SQLSERVER))
            {
                optionsBuilder.UseSqlServer(DbConnectInfo.WLN_CONNSTR_SQLSERVER, b => b.UseRowNumberForPaging());
            }
            else if (!string.IsNullOrEmpty(DbConnectInfo.WLN_CONNSTR_SQLITE))
            {
                optionsBuilder.UseSqlite(DbConnectInfo.WLN_CONNSTR_SQLITE);
            }
            else
            {
#if DEBUG
                var connstr = "Data Source=" + Wlniao.IO.PathTool.Map(Wlniao.XCore.StartupRoot, "xcore", "xcore.db");
                optionsBuilder.UseSqlite(connstr);
#else
                log.Fatal("WLN_CONNSTR is not config");
#endif
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