using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsCoreProject
{
   public  class BaseModel
    {

        Pagination _pagination;

        public Pagination Pagination { get; set; }
        //public Pagination Pagination {
        //    get
        //    {
        //        if (_pagination == null)
        //        {
        //            _pagination = new Pagination();
        //        }
        //        return Pagination;

        //    }  
        //    set => _pagination = value;
        //}

        private string _orderBy;
        private string _columnName;


        public string OrderBy
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "asc";
                }
                else
                {
                    return _orderBy.ToLower();
                }


            }
            set => _orderBy = value;
        }

        public string ColumnName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "id";
                }
                return _columnName.ToLower();


            }
            set => _columnName = value;
        }


        public virtual string GetOrderBy(string alias)
        {
            return " Order by " + alias  + ColumnName + " " + OrderBy + " ";
        }


        public virtual string GetOrderBy()
        {
            return " Order by "  + ColumnName + " " + OrderBy + " ";
        }

    }
}
