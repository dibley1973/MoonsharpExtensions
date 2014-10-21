using Dibware.MoonsharpExtensions.InterpreterExtensions;
using Dibware.MoonsharpExtensionTests.MockData;
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
        #region GetMember

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_GetMember_ForNullKey_ThrowsArgumentNullException()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the member */
            DynValue resultMember = resultObject.GetMember(null);

            // Assert
            // We should not get here as an "ArgumentNullException" error 
            // should be thrown by now
        }

        [TestMethod]
        public void Test_GetMember_ForInvalidKey_ReturnsDataTypeOfNil()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the member */
            DynValue resultMember = resultObject.GetMember(MockLuaScripts.InValidKey1);

            // Assert
            Assert.AreEqual(DataType.Nil, resultMember.Type);
        }

        [TestMethod]
        public void Test_GetMember_ForValidTypeAndKey_ReturnsValue()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String expectedResult = MockLuaScripts.ValidValue1;

            // Act
            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the member */
            DynValue resultMember = resultObject.GetMember(MockLuaScripts.ValidKey1);

            /* Get the result */
            String actualResult = resultMember.String;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        #endregion

        #region GetProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_GetProperty_ForNullKey_ThrowsAArgumentNullException()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the property */
            String result = resultObject.GetPropertyValue<String>(null);

            // Assert
            // We should not get here as an "ArgumentNullException" error 
            // should be thrown by now
        }

        [TestMethod]
        public void Test_GetProperty_ForInvalidKey_ReturnsNull()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act
            /* Run the script */
            context.DoString(luaScript);
            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);
            /* Get the property */
            String result = resultObject.GetPropertyValue<String>(MockLuaScripts.InValidKey1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_GetProperty_ForValidTypeAndKey_ReturnsValue()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String expectedResult = MockLuaScripts.ValidValue1;

            // Act
            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the property */
            String actualResult = resultObject.GetPropertyValue<String>(MockLuaScripts.ValidKey1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Test_GetProperty_ForIncorrectType_ThrowsError()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();

            // Act

            /* Run the script */
            context.DoString(luaScript);

            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);

            /* Get the property */
            Double actualResult = resultObject.GetPropertyValue<Double>(MockLuaScripts.ValidKey1);

            // Assert
            // We should not get here as an "TypeParameterException" error 
            // should be thrown by now
        }

        #endregion

    }
}