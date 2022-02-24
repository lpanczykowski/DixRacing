using System;
using System.Collections.Generic;

namespace DixRacing.Domain.SharedKernel
{
    public class PaginatedResult<T>
    {
        public int TotalRowCount { get; set; }
        public int TotalPages {get;set;}        
        public int CurrentPage {get;set;}
        public int ItemsPerPage {get;set;}
        public IEnumerable<T> Rows { get; set; }
        public PaginatedResult(IEnumerable<T> Rows,int TotalRowCount,int CurrentPage,int ItemsPerPage)
        {
            this.TotalRowCount = TotalRowCount;
            this.Rows = Rows;
            this.CurrentPage = CurrentPage;
            this.ItemsPerPage = ItemsPerPage;
            this.TotalPages = (int) Math.Ceiling(TotalRowCount/(double) ItemsPerPage);
        }
        
    }
}