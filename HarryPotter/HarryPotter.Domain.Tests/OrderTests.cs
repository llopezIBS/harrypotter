using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HarryPotter.Domain.Tests
{

    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        {
            this._order = new Order();
        }

        [Test]
        public void New_CreateInstanceWith2Books_Create2Items()
        {
            IList<Book> books = new List<Book>();
            books.Add(new Book() { Id = 1 });
            books.Add(new Book() { Id = 2 });
            this._order = new Order(books);
            Assert.AreEqual(2, this._order.Items.Count);
            Assert.AreEqual(books[0], this._order.Items[0].Book);
            Assert.AreEqual(books[1], this._order.Items[1].Book);
        }

        
        [TestCase(8, 8, 52.6)]
        /*[TestCase(2, 8, 16)]
        [TestCase(5, 8, 40)]
        [TestCase(3,8, 21.6)]*/

        public void GetTotal_AddOneBookManyTime_GetTotalCorrect(int quantity , double bookPrice, double expectedTotal)
        {

            // Arrange
            
            Book bookA = new Book() { Price = bookPrice };
            this._order.AddBook(bookA, 2);
            Book bookB = new Book() { Price = bookPrice };
            this._order.AddBook(bookB, 2);
            Book bookC = new Book() { Price = bookPrice };
            this._order.AddBook(bookC, 2);
            Book bookD = new Book() { Price = bookPrice };
            this._order.AddBook(bookD, 1);
            Book bookE = new Book() { Price = bookPrice };
            this._order.AddBook(bookE, 1);
            

            // Act
            double totalCalculated = this._order.GeTotal();

            // Assert
            Assert.AreEqual(52.6, totalCalculated);
        }

        [Test]
        public void GetTotal_EmptyOrder_GetZero()
        {

            // Assert
            Assert.AreEqual(0, this._order.GeTotal());
        }

        [Test]
        public void AddBookToOrder_AddOneBookFiveTimes_OrderWithOneItemAndQuantityEqualFive()
        {
            // Arrange
            Author author = new Author();
            Book book01 = new Book() { Price = 8, Author = author, Name = "Book name" };
            int quantity = 5;

            // Act
            OrderItem itemAdded = this._order.AddBook(book01, quantity);

            // Assert
            Assert.AreEqual(1, this._order.Items.Count);
            Assert.AreEqual(itemAdded, this._order.Items[0]);
            Assert.AreEqual(itemAdded.Book, book01);
        }
    }
}
