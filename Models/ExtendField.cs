using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Wlniao;
namespace Models
{
    /// <summary>
    /// 扩展字段
    /// </summary>
    public class ExtendField
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        [StringLength(20)]
        public string Model { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [StringLength(50)]
        public string Key { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        [StringLength(30)]
        public string Field { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [StringLength(4000)]
        public string Value { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreateTime { get; set; }

    }
}