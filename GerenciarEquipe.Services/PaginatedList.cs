using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Services
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int MaxSizeRange { get; private set; }
        public List<int> RangePage { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalRecords { get; private set; }
        public int StartRecordsPage { get; private set; }
        public int EndRecordsPage { get; private set; }
        public object GereneralData { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, int maxSizeRange)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            MaxSizeRange = maxSizeRange;

            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalRecords = count; 
            StartRecordsPage = pageIndex * pageSize + 1;
            EndRecordsPage = ((pageIndex + 1) * pageSize) > count ? count : ((pageIndex + 1) * pageSize);

            var rangeSize = 0;
            if (TotalPages > MaxSizeRange)
                rangeSize = MaxSizeRange;
            else
                rangeSize = TotalPages;

            var start = pageIndex;
            if (pageIndex > TotalPages - rangeSize)
            {
                start = TotalPages - rangeSize;
            }

            for (var i = start; i < start + rangeSize; i++)
            {
                RangePage.Add(i);
            }

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize, int maxSizeRange)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize, maxSizeRange);
        }
    }
}
