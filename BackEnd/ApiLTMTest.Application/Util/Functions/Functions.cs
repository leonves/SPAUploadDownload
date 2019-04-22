using Newtonsoft.Json;
using System;

namespace ApiLTMTest.Application.Util.Functions
{
    public static class Functions
    {
        public static TReturn ConvertObjectTo<TReturn>(object objectSource)
        {
            var result = JsonConvert.DeserializeObject<TReturn>(JsonConvert.SerializeObject(objectSource));

            return result;
        }

        public static TReturn CopyPropertiesFrom<TReturn>(this TReturn self, object parent)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)

                foreach (var toProperty in toProperties)

                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType && fromProperty.GetValue(parent) != null)
                    {
                        toProperty.SetValue(self, fromProperty.GetValue(parent));
                        break;
                    }

            return self;
        }

        public static string ConvertToHex(int number)
        {
            var result = number.ToString("X");

            return result;
        }

        public static int ConvertFromHex(string hex)
        {
            var result = Convert.ToInt32(hex, 16);

            return result;
        }
    }
}
