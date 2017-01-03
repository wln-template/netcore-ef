using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wlniao;
namespace Models
{
    /// <summary>
    /// 设置
    /// </summary>
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        [StringLength(100)]
        public string Key { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [StringLength(512)]
        public string Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static ApiResult<Int32> Set(String Key, String Value)
        {
            var rlt = new ApiResult<Int32>();
            try
            {
                var db = new MyContext();
                var id = Set(db, Key, Value);
                if (db.SaveChanges() > 0)
                {
                    Cache.Set("Setting_" + Key, Value);
                    rlt.success = true;
                    rlt.message = "操作成功";
                    rlt.data = id;
                }
                else
                {
                    rlt.message = "操作失败";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rlt.message = ex.Message;
            }
            return rlt;
        }

        /// <summary>
        /// 取值（由XCore缓存）
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Default"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static String Get(String Key, String Default = "", String Description = "")
        {
            var value = Cache.Get("Setting_" + Key);
            if (string.IsNullOrEmpty(value))
            {
                value = Get(new MyContext(), Key, Default, Description);
            }
            return value;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Int32 Set(MyContext db, String Key, String Value)
        {
            var model = db.Setting.Where(a => a.Key == Key).LastOrDefault();
            if (model == null)
            {
                model = new Setting();
                model.Key = Key;
                model.Value = Value;
                db.Setting.Add(model);
            }
            else
            {
                model.Value = Value;
                db.Setting.Update(model);
            }
            return model.Id;
        }
        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Key"></param>
        /// <param name="Default"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static String Get(MyContext db, String Key, String Default = "", String Description = "")
        {
            if (!string.IsNullOrEmpty(Key))
            {
                var keydata = db.Setting.Where(a => a.Key == Key).LastOrDefault();
                if (keydata != null && !string.IsNullOrEmpty(keydata.Value))
                {
                    return keydata.Value;
                }
                else if (keydata == null || (keydata.Description != Description && !string.IsNullOrEmpty(Description)))
                {
                    var _db = new MyContext();
                    if (keydata == null)
                    {
                        if (Key == "SystemName")
                        {
                            Description = "系统名称";
                        }
                        keydata = new Setting();
                        keydata.Key = Key;
                        keydata.Value = Default;
                        keydata.Description = Description;
                        _db.Setting.Add(keydata);
                    }
                    else
                    {
                        keydata.Description = Description;
                        _db.Setting.Update(keydata);
                    }
                    _db.SaveChanges();
                }
            }
            return Default.IsNullOrEmpty() ? "" : Default;
        }
    }
}
