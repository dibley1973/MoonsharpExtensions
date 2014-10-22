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
            Func<double, double, double> clrFunction = (n1, n2) => luaFunction.Call(n1, n2).ToObject<int>();

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