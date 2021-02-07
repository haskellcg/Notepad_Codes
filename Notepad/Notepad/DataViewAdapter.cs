using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Notepad
{
    public class DataViewAdapter : IDataAdapter
    {
        private string _keyWord;
        private DataView _dataTb;

        public DataViewAdapter(DataTable  dataSource)
        {
            this._dataTb = new DataView(dataSource);
        }

        /// <summary>
        /// 返回设置关键字
        /// </summary>
        public string KeyWord
        {
            get { return _keyWord; }
            set {

                if (_dataTb.Table.Columns.Contains(value))
                {
                    _keyWord = value;
                }
                else
                {
                    throw new Exception("在数据表中不包含制定列");
                }

            }
        }

        /// <summary>
        /// 获取合适的数据
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataView GetFitData(string keyWord)
        {
            _dataTb.RowFilter=(string.IsNullOrEmpty(_keyWord)?string.Empty:string.Format("{0} like '{1}%'",_keyWord,keyWord));
            return _dataTb;
        }
    }
}
