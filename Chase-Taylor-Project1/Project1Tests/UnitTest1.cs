using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantDataAccessLayer;
using BusinessLayer;
using BusinessLayer.RestaurantComp;
using System.Collections.Generic;

namespace Project1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrudTest()
        {
            //act
            Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<RestaurantDataAccessLayer.Restaurant>();

            //arrange
            RestaurantDataAccessLayer.Restaurant rest1 = crud.Retrieve(1);
            bool test = crud.Add(new RestaurantDataAccessLayer.Restaurant());

            //assert
            Assert.AreEqual(rest1.RestaurantID, 1);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CrudTest2()
        {
            //act
            Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<RestaurantDataAccessLayer.Restaurant>();

            //arrange
            bool test = crud.Delete(crud.Retrieve(4));

            //assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CrudTest3()
        {
            //act
            Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<RestaurantDataAccessLayer.Restaurant>();


            //arrange
            RestaurantDataAccessLayer.Restaurant ent = new RestaurantDataAccessLayer.Restaurant();
            //bool test = crud.Update(ent);


        }

        [TestMethod]
        public void Top3Test()
        {
            IEnumerable<BusinessLayer.RestaurantComp.Restaurant> rest = BusinessLayer.BusinessLayer.GetTop3();

            
        }
    }
}
