using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class EmployeeListPagination<T> :List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; set; }

        public EmployeeListPagination(List<T>items,int count,int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages =(int) Math.Ceiling(count /(double) pageSize); // pagesize etc 4 employees per page
            this.AddRange(items);
            //Sometimes we may get a flaoting pagesize so we cast it as double and  the we use Math to get 
        }
        //enable or disable our paging buttons (previous next buttons)
       
        public bool IsPreviousPageAvailable => PageIndex > 1; //checks if previous page is available (pageindex greater than 1)

        public bool IsNextPageAvailable  => PageIndex < TotalPages;



        public static EmployeeListPagination<T> Create (IList<T> source, int pageIndex,int pageSize)
        {
            var count = source.Count;

            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //  i am skipping items depending on the page am in and am  inserting items according to the list
            //example if i am in the first page  therefore pageIndex = 1 am not gonna skip any items and if my pageSize is 4 am goint to take the first 4
             

            return new EmployeeListPagination<T>(items, count, pageIndex, pageSize);
        }

    }
   
}
