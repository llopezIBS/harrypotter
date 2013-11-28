using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HarryPotter.Domain.Tests
{

    [TestFixture]
    public class OrderItemTests
    {
        private OrderItem _orderItem;

        [Test]
        public void New_CreateInstanceWith2Books_Create2Items()
        {
            Book book = new Book() { Id = 2 };
            this._orderItem = new OrderItem(book);
            Assert.AreEqual(book, this._orderItem.Book);
        }
    }
}