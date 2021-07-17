using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ModelsCoreProject
{
   public class Pagination
    {

     public   Pagination()
        {
            Pages = new List<int>();           
            CurrentPage = 1;
            RowCount = 3;
        }
        public int CurrentPage { get; set; }

        public int RowCount { get; set; }

        public int TotalRowCount { get; set; }

        public List<int> Pages { get; set; }

        public List<T> SetPage<T>(List<T> list){
            TotalRowCount = list.Count;
            int pageCount =(int) Math.Ceiling( TotalRowCount* 1.0 / RowCount);
            if(CurrentPage > pageCount)
            {
                CurrentPage = 1;
            }
            int startIndex = (CurrentPage - 1) * RowCount;
            List<T> lst = list.Skip(startIndex - 1).Take(RowCount).ToList();
            Pages.Clear();
            for(var i = 1; i <= pageCount; i = i +1)
            {
                Pages.Add(i);
            }
            return lst;
        }


        public string SetPageQuery(int totalRowCount) 
        {
            TotalRowCount = totalRowCount;
            int pageCount = (int)Math.Ceiling(TotalRowCount * 1.0 / RowCount);
            if (CurrentPage > pageCount)
            {
                CurrentPage = 1;
            }
            int startIndex = (CurrentPage - 1) * RowCount;
            
            Pages.Clear();
            for (var i = 1; i <= pageCount; i = i + 1)
            {
                Pages.Add(i);
            }
            return "  OFFSET "+(startIndex).ToString()+ " ROWS FETCH NEXT " +(RowCount).ToString()+ "  ROWS ONLY  ";
        }
    }
}
