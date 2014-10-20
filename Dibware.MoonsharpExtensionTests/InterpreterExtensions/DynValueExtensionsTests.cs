﻿using Dibware.MoonsharpExtensions.Exceptions;
using Dibware.MoonsharpExtensions.InterpreterExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoonSharp.Interpreter;
using System;

namespace Dibware.MoonsharpExtensionTests.InterpreterExtensions
{
    /// <summary>
    /// Encapsualtes tests for DynValue extensions 
    /// </summary>
    [TestClass]
    public class DynValueExtensionsTests
    {
        /// <summary>
        /// Encapsualtes mocking scripts
        /// </summary>
        private class MockLuaScripts
        {
            public const String TEST_OBJECT_WITH_STRING = @"
                TestObject = {name = ""hello""}
                myObject = TestObject; TestObject = nil;
            ";

            public const String TEST_OBJECT_WITH_DOUBLE = @"
                TestObject = {const = 100.0}
                myObject = TestObject; TestObject = nil;
            ";
        }

        #region GetProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_GetProperty_ForNullKey_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            context.DoString(luaScript);                         /* Run the script */
            DynValue myObject = context.Globals.Get("myObject"); /* Get the object */
            String result = myObject.GetProperty<String>(null); /* Get the property */

            // Assert
            // We should not get here as an "ArgumentOutOfRangeException" error 
            // should be thrown by now
        }

        [TestMethod]
        public void Test_GetProperty_ForInvalidKey_ReturnsNull()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            context.DoString(luaScript);                             /* Run the script */
            DynValue myObject = context.Globals.Get("myObject");     /* Get the object */
            String result = myObject.GetProperty<String>("donkey"); /* Get the property */

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_GetProperty_ForValidTypeAndKey_ReturnsValue()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String expectedResult = @"hello";

            // Act
            context.DoString(luaScript);                                 /* Run the script */
            DynValue myObject = context.Globals.Get("myObject");         /* Get the object */
            String actualResult = myObject.GetProperty<String>("name"); /* Get the property */

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeParameterException))]
        public void Test_GetProperty_ForIncorrectType_ThrowsError()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            context.DoString(luaScript);                                 /* Run the script */
            DynValue myObject = context.Globals.Get("myObject");         /* Get the object */
            Double actualResult = myObject.GetProperty<Double>("name"); /* Get the property */

            // Assert
            // We should not get here as an "TypeParameterException" error 
            // should be thrown by now
        }

        #endregion

    }
}