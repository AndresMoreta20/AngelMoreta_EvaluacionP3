using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelMoreta_EvaluacionP3.Models
{
    [Table("frase2")]
    public class AMFrase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string _id { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        // public List<string> tags { get; set; }
        public string authorSlug { get; set; }
        public int length { get; set; }
        public string dateAdded { get; set; }
        public string dateModified { get; set; }
        public string FechaActual { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public int totalCount { get; set; }
        public int page { get; set; }
        public int totalPages { get; set; }
        public int lastItemIndex { get; set; }
        public List<AMFrase> results { get; set; }
    }
}
