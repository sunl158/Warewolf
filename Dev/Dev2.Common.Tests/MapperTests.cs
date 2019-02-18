﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Common.Tests
{
    public class Parent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
#pragma warning disable 169
        string _name = "name";
#pragma warning restore 169
        public override string ToString()
        {
            return _name;
        }
    }

    public class Child
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
#pragma warning disable 169
        string _name;
#pragma warning restore 169
    }

    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        [Owner("Siphamandla Dube")]
        [TestCategory(nameof(Mapper))]
        public void Mapper_Map_GivenObjects_ShouldMapCorrectly()
        {
            //---------------Set up test pack-------------------
            Mapper.Clear();
            Mapper.AddMap<Parent, Child>((parent1, child1) =>
            {
                child1.ParentId = parent1.Id;
            });
            var parent = new Parent()
            {
                Id = 100,
                Name = "name",
                Surname = "surname"
            };
            var child = new Child()
            {
                Name = "child",
                Id = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Mapper.Map(parent, child, true, "Id", "Name");
            //---------------Test Result -----------------------
            Assert.AreEqual(100, parent.Id);
            Assert.AreEqual(100, child.ParentId);
        }

        [TestMethod]
        [Owner("Siphamandla Dube")]
        [TestCategory(nameof(Mapper))]
        public void Mapper_Map_ObjectsNoActions_ShouldMapCorrectly()
        {
            //---------------Set up test pack-------------------
            Mapper.Clear();
            Mapper.AddMap<Parent, Child>();
            var parent = new Parent()
            {
                Id = 100,
                Name = "name",
                Surname = "surname"
            };
            var child = new Child()
            {
                Name = "child",
                Id = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Mapper.Map(parent, child);
            //---------------Test Result -----------------------
            Assert.AreEqual(100, parent.Id);
            Assert.AreEqual(parent.Id, child.Id);
            Assert.AreEqual(parent.Name, child.Name);
            Assert.AreEqual(parent.Surname, child.Surname);
        }

        [TestMethod]
        [Owner("Siphamandla Dube")]
        [TestCategory(nameof(Mapper))]
        public void Mapper_Map_TMapTo_IsNotNull_ExpectArgumentNullException()
        {
            //---------------Set up test pack-------------------
            Mapper.Clear();
            Mapper.AddMap<Parent, Child>();
            var parent = new Parent()
            {
                Id = 100,
                Name = "name",
                Surname = "surname"
            };
            var child = new Child()
            {
                Name = "child",
                Id = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.ThrowsException<ArgumentNullException>(()=> Mapper.Map(default(Parent), child));
        }
    }
}
