using System;
using System.Collections;

namespace Cortside.Core.Util {

    /// <summary>
    /// Utility open type to help handle paging
    /// </summary>
    public class PagedList<T> : IPagedList where T : IList, new() {
        private Int32 pageSize;
        private T completeList;

        public PagedList(Int32 pageSize) {
            this.pageSize = pageSize;
        }

        public PagedList(Int32 pageSize, T initialList) {
            this.pageSize = pageSize;
            this.completeList = initialList;
        }

        public T GetListByPageNumber(Int32 pageNumber) {
            CheckPageNumberInRange(pageNumber);
            Int32 minRecord = pageSize * (pageNumber - 1);
            T tempList = new T();
            for (int i = minRecord; i < (minRecord + pageSize) && i < completeList.Count; i++) {
                tempList.Add(completeList[i]);
            }
            return tempList;
        }

        public Int32 PageSize {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public Int32 TotalPages {
            get {
                Int32 totalPages = completeList.Count / pageSize;
                if (completeList.Count % pageSize > 0) {
                    totalPages++;
                }
                return totalPages;
            }
        }

        public void AddRange(T listToAdd) {
            if (completeList == null) {
                completeList = new T();
            }
            foreach (object t in listToAdd) {
                completeList.Add(t);
            }
        }

        public Boolean HasPrevious(Int32 pageNumber) {
            CheckPageNumberInRange(pageNumber);
            return !pageNumber.Equals(1);
        }

        public Boolean HasNext(Int32 pageNumber) {
            CheckPageNumberInRange(pageNumber);
            return !pageNumber.Equals(TotalPages);
        }

        public Int32 GetPageNumber(Int32 index) {
            if (index < 0 || index >= completeList.Count) {
                throw new IndexOutOfRangeException();
            }
            return (index / pageSize) + 1;
        }

        public Int32 TotalRecords {
            get { return completeList.Count; }
        }

        public Int32 GetStartNumber(Int32 pageNumber) {
            CheckPageNumberInRange(pageNumber);
            return (pageNumber * PageSize) + 1 - PageSize;
        }

        public Int32 GetEndNumber(Int32 pageNumber) {
            CheckPageNumberInRange(pageNumber);
            if (pageNumber.Equals(TotalPages)) {
                return completeList.Count;
            } else {
                return pageNumber * PageSize;
            }
        }

        private void CheckPageNumberInRange(Int32 pageNumber) {
            if (pageNumber < 1 || (completeList.Count > 0 && pageNumber > TotalPages)) {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public interface IPagedList {
        Int32 PageSize { get; }

        Int32 TotalPages { get; }

        Int32 TotalRecords { get; }

        Boolean HasPrevious(Int32 pageNumber);

        Boolean HasNext(Int32 pageNumber);

        Int32 GetPageNumber(Int32 index);

        Int32 GetStartNumber(Int32 pageNumber);

        Int32 GetEndNumber(Int32 pageNumber);
    }
}