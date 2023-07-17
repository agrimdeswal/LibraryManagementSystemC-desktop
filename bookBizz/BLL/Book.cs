using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookBizz.BLL
{
    internal class Book
    {
            public int ISBN { get; set; }
            public int Price { get; set; }
            public string Title { get; set; }
            public string YearPublished { get; set; }
            public int QOH { get; set; }
    }
}
