using System;
using System.ComponentModel;

namespace SearchLastFile
{
    public static class AttributesHelper
    {
        /// <summary>
        /// get enum string description value
        /// </summary>
        /// <param name="value">enum value</param>
        /// <returns>string enum value</returns>
        public static string ToDescription(this Enum value)
        {
            var da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }
}
