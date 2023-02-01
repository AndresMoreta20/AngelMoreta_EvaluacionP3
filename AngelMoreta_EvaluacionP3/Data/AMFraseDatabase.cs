using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngelMoreta_EvaluacionP3.Models;
using SQLite;

namespace AngelMoreta_EvaluacionP3.Data
{
    public class AMFraseDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public AMFraseDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);

            conn.CreateTable<AMFrase>();
        }
        public int AddNewFrase(AMFrase frase)
        {
            Init();

            if (frase.Id != 0)
            {
                return conn.Update(frase);
            }
            else
            {
                return conn.Insert(frase);
            }


        }

        public int UpdateFrase(AMFrase frase)
        {
            Init();
            return conn.Update(frase);



        }
        public List<AMFrase> GetAllFrases()
        {
            Init();
            List<AMFrase> frases = conn.Table<AMFrase>().ToList();
            return frases;
        }

        public int DeleteFrase(AMFrase item)
        {
            Init();
            return conn.Delete(item);
        }
    }
    
}
