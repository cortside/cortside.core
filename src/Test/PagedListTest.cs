using System;
using System.Collections;
using Cortside.Core.Util;
using Xunit;

namespace Cortside.Core.Test {

    /// <summary>
    /// Summary description for PagedListTest.
    /// </summary>
    public class PagedListTest {

        [Fact]
        public void ShouldBeAbleToCreatePageList() {
            PagedList<ArrayList> pagedList = new PagedList<ArrayList>(5);
            Assert.Equal(5, pagedList.PageSize);
        }

        [Fact]
        public void ShouldBeAbleToCreatePageListWithList() {
            ArrayList list = new ArrayList();
            list.Add(101);
            list.Add(202);

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(5, pageList.PageSize);
            Assert.Equal(list.Count, pageList.GetListByPageNumber(1).Count);
        }

        [Fact]
        public void ShouldHaveAccessToCompleteListCount() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(45, pageList.TotalRecords);
        }

        [Fact]
        public void ShouldKnowNumberOfPagesThereAre() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(5, pageList.PageSize);
            Assert.Equal(9, pageList.TotalPages);
        }

        [Fact]
        public void ShouldBeAbleToAddRangeToPageList() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(5, pageList.PageSize);
            Assert.Equal(9, pageList.TotalPages);

            ArrayList list2 = new ArrayList();
            for (Int32 j = 200; j < 210; j++) {
                list2.Add(j);
            }

            pageList.AddRange(list2);
            Assert.Equal(11, pageList.TotalPages);
        }

        [Fact]
        public void ShouldBeAbleToAddRangeToPageListWhenConstuctedWithoutList() {

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5);
            Assert.Equal(5, pageList.PageSize);

            ArrayList list2 = new ArrayList();
            for (Int32 j = 200; j < 210; j++) {
                list2.Add(j);
            }

            pageList.AddRange(list2);
            Assert.Equal(2, pageList.TotalPages);
        }

        [Fact]
        public void ShouldGetRightSubListByPage() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(5, pageList.PageSize);
            Assert.Equal(9, pageList.TotalPages);
            ArrayList tempList = pageList.GetListByPageNumber(1);
            Assert.Equal(100, tempList[0]);
            Assert.Equal(104, tempList[4]);
            tempList = pageList.GetListByPageNumber(3);
            Assert.Equal(110, tempList[0]);
            Assert.Equal(114, tempList[4]);
            tempList = pageList.GetListByPageNumber(9);
            Assert.Equal(140, tempList[0]);
            Assert.Equal(144, tempList[4]);
        }

        [Fact]
        public void ShouldKnowIfHasPrevious() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.False(pageList.HasPrevious(1));
            Assert.True(pageList.HasPrevious(5));
            Assert.True(pageList.HasPrevious(9));
        }

        [Fact]
        public void ShouldKnowIfHasNext() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.False(pageList.HasNext(9));
            Assert.True(pageList.HasNext(5));
            Assert.True(pageList.HasNext(1));
        }

        [Fact]
        public void ShouldHandleItWhenLastPageHasFewerRecordsThenPageSize() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 123; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(3, pageList.GetListByPageNumber(5).Count);
        }

        [Fact]
        public void ShouldBeAbleToGetPageNumberFromIndex() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(1, pageList.GetPageNumber(0));
            Assert.Equal(1, pageList.GetPageNumber(2));
            Assert.Equal(1, pageList.GetPageNumber(4));
            Assert.Equal(3, pageList.GetPageNumber(10));
            Assert.Equal(3, pageList.GetPageNumber(12));
            Assert.Equal(3, pageList.GetPageNumber(14));
            Assert.Equal(9, pageList.GetPageNumber(40));
            Assert.Equal(9, pageList.GetPageNumber(43));
            Assert.Equal(9, pageList.GetPageNumber(44));
        }

        [Fact]
        public void ShouldGetIndexOutOfRangeExceptionIfTryingToGetPageNumberWithBadIndex() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            try {
                pageList.GetPageNumber(-1);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.GetPageNumber(45);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
        }

        [Fact]
        public void ShouldGetIndexOutOfRangeExceptionWhenAskingForNegitivePage() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);

            try {
                pageList.GetListByPageNumber(0);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.HasNext(0);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.HasPrevious(0);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.GetStartNumber(0);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.GetEndNumber(0);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
        }

        [Fact]
        public void ShouldGetIndexOutOfRangeExceptionWhenAskingForPageLargerThenTotalPages() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);

            try {
                pageList.GetListByPageNumber(10);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.HasNext(10);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.HasPrevious(10);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.GetStartNumber(10);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
            try {
                pageList.GetEndNumber(10);
                Assert.True(false, "Should have gotten a IndexOutOfRangeException");
            } catch (IndexOutOfRangeException) {
                //Expected
            }
        }

        [Fact]
        public void ShouldBeAbleToGetStartItemNumberForPage() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 145; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(1, pageList.GetStartNumber(1));
            Assert.Equal(21, pageList.GetStartNumber(5));
            Assert.Equal(41, pageList.GetStartNumber(9));
        }

        [Fact]
        public void ShouldBeAbleToGetEndItemNumberForPage() {
            ArrayList list = new ArrayList();
            for (Int32 i = 100; i < 147; i++) {
                list.Add(i);
            }

            PagedList<ArrayList> pageList = new PagedList<ArrayList>(5, list);
            Assert.Equal(5, pageList.GetEndNumber(1));
            Assert.Equal(25, pageList.GetEndNumber(5));
            Assert.Equal(45, pageList.GetEndNumber(9));
            Assert.Equal(47, pageList.GetEndNumber(10));
        }

        [Fact]
        public void ShouldBeAbleToUseContainsMethodOnGeneratedList() {
            //WebFacade facade = new WebFacade();
            //IDirectSalesAgentUser dsaUser = null;
            //ICustomer customer = null;
            //ICustomer customer2 = null;
            //try {
            //    dsaUser = TestUtility.CreateNewDSAUser(true);
            //    customer = TestUtility.CreateNewCustomer(dsaUser.DirectSalesAgent.DirectSalesAgentId);
            //    customer2 = TestUtility.CreateNewCustomer(dsaUser.DirectSalesAgent.DirectSalesAgentId);

            //    facade.Login(dsaUser.Username, TestUtility.PASSWORD, "1.1.1.1");

            //    CustomerList list = facade.CustomerLookupAll(StringType.DEFAULT, StringType.DEFAULT, StringType.DEFAULT, USStateCodeEnum.DEFAULT, CustomerStatusEnum.DEFAULT, BooleanType.DEFAULT, BooleanType.DEFAULT);

            //    PagedList2<CustomerList, ICustomer> pagedList = new PagedList2<CustomerList, ICustomer>(5, list);
            //    CustomerList list2 = pagedList.GetListByPageNumber(1);
            //    Assert.Equal(3, list2.Count);
            //    Assert.True(list2.Contains(list[0].CustomerId), "should have found customer");
            //} finally {
            //    TestUtility.DeleteCustomer(customer);
            //    TestUtility.DeleteCustomer(customer2);
            //    TestUtility.DeleteDemonstrator(facade.GetDemonstrator(dsaUser.DirectSalesAgent.DirectSalesAgentId));
            //}
        }
    }
}
