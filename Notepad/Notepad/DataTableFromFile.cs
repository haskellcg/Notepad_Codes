using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Notepad
{
    /// <summary>
    /// 从文件中组织DataTable
    /// </summary>
    public class DataTableFromFile
    {
        private FileInfo _fileInfo;
        private Dictionary<string, string> wordDictionary;

        public DataTableFromFile(string fileName)
        {
            this._fileInfo = new FileInfo(fileName);
            wordDictionary = new Dictionary<string, string>();
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            return this._fileInfo.Exists;
        }


        /// <summary>
        /// 根据文件获取datatable文件的组织结构为每行以TAB分割的字符串
        /// </summary>
        /// <param name="columnsName">列名</param>
        /// <returns></returns>
        public DataTable GetDataTable(string wordColumn)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(wordColumn);

            StreamReader fileReader = new StreamReader(this._fileInfo.FullName, Encoding.GetEncoding("gb2312"));

            while (!fileReader.EndOfStream)
            {
                string tempLine = fileReader.ReadLine();
                int FirstTabIndex = tempLine.IndexOf('\t');
                string wordInFile = tempLine.Substring(0, FirstTabIndex);
                string translateInFile = tempLine.Substring(FirstTabIndex + 1);
                wordInFile = wordInFile.Trim();
                translateInFile = translateInFile.Trim();

                if (wordDictionary.ContainsKey(wordInFile))
                {
                    string transelate = wordDictionary[wordInFile];
                    transelate = translateInFile + "；" + transelate;
                    wordDictionary[wordInFile] = transelate;
                }
                else
                {
                    wordDictionary.Add(wordInFile, translateInFile);
                    dataTable.Rows.Add(wordInFile);
                }

            }
            return dataTable;
        }


        public Dictionary<string, string> WordDictionary
        {
            get { return this.wordDictionary; }
        }
    }
}
