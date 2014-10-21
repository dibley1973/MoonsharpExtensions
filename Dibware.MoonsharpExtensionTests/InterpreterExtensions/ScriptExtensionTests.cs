using Dibware.MoonsharpExtensions.InterpreterExtensions;
using Dibware.MoonsharpExtensionTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoonSharp.Interpreter;
using System;

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

        #endregion
    }
}