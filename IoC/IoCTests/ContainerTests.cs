﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IoCTests.Entities;

namespace IoC.Tests
{
    [TestClass()]
    public class ContainerTests
    {

        private Container _container;

        [TestInitialize]
        public void Initialize()
        {
            _container = new Container(new DIActivator());
        }

        [TestMethod()]
        public void CreateInstanceTest()
        {
            _container.ReadAssembly(Assembly.GetExecutingAssembly());

            var customerBll = _container.CreateInstance<CustomerBLL>();

            Assert.IsNotNull(customerBll);
            Assert.IsTrue(customerBll.GetType() == typeof(CustomerBLL));
        }

        [TestMethod()]
        public void AddTypeTest()
        {
            _container.AddType(typeof(CustomerBLL));
            _container.AddType(typeof(Logger));
            _container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

            var customerBll = (CustomerBLL)_container.CreateInstance(typeof(CustomerBLL));

            Assert.IsNotNull(customerBll);
            Assert.IsTrue(customerBll.GetType() == typeof(CustomerBLL));
        }

        [TestMethod()]
        public void AddTypeTestWithGenericCreateInstance()
        {
            _container.AddType(typeof(CustomerBLL));
            _container.AddType(typeof(Logger));
            _container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

            var customerBll = _container.CreateInstance<CustomerBLL>();

            Assert.IsNotNull(customerBll);
            Assert.IsTrue(customerBll.GetType() == typeof(CustomerBLL));
        }

        [TestMethod()]
        public void PropertiesInjectionTest()
        {
            _container.ReadAssembly(Assembly.GetExecutingAssembly());

            var customerBll = _container.CreateInstance<CustomerBLL2>();

            Assert.IsNotNull(customerBll);
            Assert.IsTrue(customerBll.GetType() == typeof(CustomerBLL2));
            Assert.IsNotNull(customerBll.CustomerDAL);
            Assert.IsNotNull(customerBll.CustomerDAL.GetType() == typeof(CustomerDAL));
            Assert.IsNotNull(customerBll.Logger);
            Assert.IsNotNull(customerBll.Logger.GetType() == typeof(Logger));
        }

        [TestMethod()]
        public void PropertiesInjectionWithAddTypesTest()
        {
            _container.AddType(typeof(CustomerBLL2));
            _container.AddType(typeof(Logger));
            _container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

            var customerBll = (CustomerBLL2)_container.CreateInstance(typeof(CustomerBLL2));

            Assert.IsNotNull(customerBll);
            Assert.IsTrue(customerBll.GetType() == typeof(CustomerBLL2));
            Assert.IsNotNull(customerBll.CustomerDAL);
            Assert.IsNotNull(customerBll.CustomerDAL.GetType() == typeof(CustomerDAL));
            Assert.IsNotNull(customerBll.Logger);
            Assert.IsNotNull(customerBll.Logger.GetType() == typeof(Logger));
        }
    }
}