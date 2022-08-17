using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public class Filter
    {
        private int? _pageSize;
        public int PageSize
        {
            get
            {
                if (!this._pageSize.HasValue)
                    this._pageSize = 10; // Este valor padrão deve ficar como parametro da aplicação web.
                return this._pageSize.Value;
            }
            set { this._pageSize = value; }
        }

        public int PageNumber = 0;

    }
}
