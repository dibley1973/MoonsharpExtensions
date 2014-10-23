using Dibware.MoonsharpExtensions.InterpreterExtensions;
using Dibware.MoonsharpExtensionTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;

namespace Dibware.MoonsharpExtensionTests.InterpreterExtensions
{
    /// <summary>
    /// Encapsualtes tests for Script extensions 
    /// </summary>
    [TestClass]
    public class ScriptExtensionTests
    {
        #region GetObject

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_GetObject_ForNullKey_ThrowsArgumentNullException()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String key = null;

            // Act
            /* Run the script */
            context.DoString(luaScript);

            //DynValue resultObject = context.Globals.Get(key);
            DynValue resultObject = context.GetObject(key);

            // Assert
            // We should not get here as an "ArgumentNullException" error 
            // should be thrown by now
        }

        [TestMethod]
        public void Test_GetObject_ForInvalidKey_ReturnsDataTypeOfNil()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String key = MockLuaScripts.InValidKey1;

            // Act
            /* Run the script */
            context.DoString(luaScript);

            //DynValue resultObject = context.Globals.Get(key);
            DynValue resultObject = context.GetObject(key);

            // Assert
            Assert.AreEqual(DataType.Nil, resultObject.Type);
        }

        [TestMethod]
        public void Test_GetObject_ForValidKey_ReturnsTableDataType()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String key = MockLuaScripts.ObjectInstance1;

            // Act
            /* Run the script */
            context.DoString(luaScript);
            DynValue resultObject = context.GetObject(key);

            /* get the return's object's type */
            var resultObjectType = resultObject.Type;

            // Assert
            Assert.AreEqual(DataType.Table, resultObjectType);
        }

        //[TestMethod]
        //public void Test_AddObject_ToGlobalTable()
        //{
        //    // Arrange
        //    String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
        //    Script context = new Script();
        //    DynValue newObject = new DynValue();
        //    DynValue newObject2 = new DynValue();

        //    // Act
        //    /* Run the script */
        //    context.DoString(luaScript);

        //    /* Add a variable */
        //    context.Globals.Set("newKey", newObject);
        //    var function = context.Globals["rawset"];
        //    context.Call(function, "ZZZZ");
        //    //context.

        //    // Assert

        //}

        [TestMethod]
        public void Test_ToDelegateWithOneParameter()
        {
            // Arrange
            String luaScript = @"
                -- simple square
                function square (n1)
                    return n1 * n1
                end";
            Script context = new Script();
            var expectedFunctionResult = 4.0;

            // Act
            context.DoString(luaScript);
            var luaFunction = context.Globals.Get("square").Function;
            Func<double, double> clrFunction =
                luaFunction.ToDelegate<double, double>();

            // Assert
            Assert.AreEqual(expectedFunctionResult, clrFunction(2));
        }

        [TestMethod]
        public void Test_ToDelegateWithTwoParameters()
        {
            // Arrange
            String luaScript = @"
                -- simple add
                function add (n1, n2)
                    return n1 + n2
                end";
            Script context = new Script();
            var expectedFunctionResult = 5.0;

            // Act
            context.DoString(luaScript);
            var luaFunction = context.Globals.Get("add").Function;
            Func<double, double, double> clrFunction =
                luaFunction.ToDelegate<double, double, double>();

            // Assert
            Assert.AreEqual(expectedFunctionResult, clrFunction(2, 3));
        }

        [TestMethod]
        public void Test_ToDelegateWithThreeParameters()
        {
            // Arrange
            String luaScript = @"
                -- simple add3
                function add3 (n1, n2, n3)
                    return n1 + n2 + n3
                end";
            Script context = new Script();
            var expectedFunctionResult = 10.0;

            // Act
            context.DoString(luaScript);
            var luaFunction = context.Globals.Get("add3").Function;
            Func<double, double, double, double> clrFunction =
                luaFunction.ToDelegate<double, double, double, double>();

            // Assert
            Assert.AreEqual(expectedFunctionResult, clrFunction(2, 3, 5));
        }

        [TestMethod]
        public void Test_ReadLuaFunctionIntoDictionary()
        {
            // Arrange
            String luaScript = @"
                -- simple add
                function add (n1, n2)
                    return n1 + n2
                end";
            Script context = new Script();
            var expectedFunctionResult = 5.0;
            var functionDictionary = new Dictionary<String, Delegate>();

            // Act
            context.DoString(luaScript);
            var luaFunction = context.Globals.Get("add").Function;
            var luaFunctionResult = luaFunction.Call(2, 3).Number; // This return result via interpreter

            // Hold a reference to the Lua function in a delagate.
            Func<double, double, double> clrFunction = (n1, n2) => luaFunction.Call(n1, n2).ToObject<double>();

            // Add this into the dictionary
            functionDictionary.Add("add", clrFunction);

            // Assert
            Assert.AreEqual(expectedFunctionResult, luaFunctionResult);
            Assert.AreEqual(expectedFunctionResult, clrFunction(2, 3));
            Assert.AreEqual(expectedFunctionResult, functionDictionary["add"].DynamicInvoke(2, 3));
        }


        #endregion
    }
}