using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        /// <summary>
        /// REST Get Products data
        /// POST a valid rating
        /// Test that the last data that was added was added correctly
        /// </summary>
        [Test]
        public void AddRating_Valid_ProductId_Return_true()
        {
            // Arrange

            // Create Dummy Record with no prior Ratings
            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            // Store the result of the AddRating method (which is being tested)
            bool validAdd = TestHelper.ProductService.AddRating(data.Id, 0);

            // Assert
            Assert.AreEqual(true, validAdd);

            // Reset
            // Delete Dummy Record
        }

        /// <summary>
        /// REST POST data that doesn't fit the constraints defined in function
        /// Test if it Adds
        /// Returns False because it wont add
        /// </summary>
        [Test]
        public void AddRating_Invalid_Product_ID_Not_Present_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)

            var result = false;

            // TODO You must fill out the commented line below with the invalid value and the function 
            // that must be called. 


            //result = TestHelper.ProductService.AddRat

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get result of false ID entered data
        /// Checks if the result equals the added data
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_ID_Null_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST Gets First Node of original data
        /// Caches the length of how many votes were made
        /// POST a new rating of 5 stars
        /// Gets first node of new data
        /// Checks origional data length against the new data length +1
        /// Checks if last data point was the one that was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            // Store the original Rating list length
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            // Get the updated First data item
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// REST get original data list
        /// Post rating to the data where number of stars are invalid
        /// Resturns false for invalid data point
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_more_5_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original ratings
        /// POST a rating against the constraint <=0
        /// Compares rating to see if added corrctly
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_less_than_0_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, -2);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original data
        /// Cache length of data
        /// POST new valid data point
        /// GET new data
        /// Test if equal count is original + 1, and new data should be equal
        /// Test if the correct valid data point was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_greater_than_0_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Store the original Rating list length for comparison later
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 1);
            // Get the updated First data item for comparison
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(1, dataNewList.Ratings.Last());
        }
        #endregion AddRating

    }
}