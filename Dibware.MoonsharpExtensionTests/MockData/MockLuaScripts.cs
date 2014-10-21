using System;

namespace Dibware.MoonsharpExtensionTests.MockData
{
    /// <summary>
    /// Encapsualtes mocking scripts
    /// </summary>
    internal class MockLuaScripts
    {
        public const String ValidKey1 = @"name";
        public const String InValidKey1 = @"donkey";
        public const String ValidValue1 = @"hello";
        public const String ObjectInstance1 = @"myObject";

        public static readonly String TEST_OBJECT_WITH_STRING = 
            String.Concat(@"TestObject = {",
                ValidKey1,
                @"= """,
                ValidValue1,
                @"""} ",
                ObjectInstance1,
                @" = TestObject; TestObject = nil;");

        public const String TEST_OBJECT_WITH_DOUBLE = @"
                TestObject = {cost = 100.0}
                myObject = TestObject; TestObject = nil;
            ";
    }
}