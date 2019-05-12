using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public enum timeResultEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 早退
        /// </summary>
        Early,
        /// <summary>
        /// 迟到
        /// </summary>
        Late,
        /// <summary>
        /// 严重迟到
        /// </summary>
        SeriousLate,
        /// <summary>
        ///     旷工迟到
        /// </summary>
        Absenteeism,
        /// <summary>
        /// 未打卡
        /// </summary>
        NotSigned,
    }
}
