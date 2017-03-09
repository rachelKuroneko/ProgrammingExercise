using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTest.Test
{
    [TestClass]
    public class AnotherTestTest
    {
        [TestMethod]
        public void TestTitle()
        {
            // Arrange 
            var title = new TestBook();

            // Act 
            title.Title = "Train, Heartnet";
            
            // Assert 
            Assert.AreEqual("Train, Heartnet", title.Title);
            
        }

        [TestMethod()]
        [DeploymentItem(@"names.txt")]
        public void readFromFile()
        {
            //Arrange 
            

            //Act 
            Program.ReadFromFile();

            //Assert 
            //CollectionAssert.AreEqual();
        }
    }
}
