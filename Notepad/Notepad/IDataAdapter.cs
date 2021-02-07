using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Notepad
{
    /// <summary>
    /// 获取数据的适配器
    /// </summary>
    public interface IDataAdapter
    {
        /// <summary>
        /// 需要根据关键字获取合适的数据
        /// </summary>
        /// <param name="keyWord"></param>
        DataView GetFitData(string keyWord);
    }
}
