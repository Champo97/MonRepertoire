using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MonRepertoire.Helper
{
    public static class ExtendsMethods
    {
        public static string CustomToString<T>(this T enumValue) where T : struct
        {
            try
            {
                if (!(enumValue is Enum))
                {
                    throw new Exception("Le paramètre passé n'est pas un 'Enum'.");
                }

                MemberInfo[] memberInfos = typeof(T).GetMember(enumValue.ToString());
                DescriptionAttribute descriptionAttribute;

                if (memberInfos.Length == 0 || (descriptionAttribute = memberInfos[0].GetCustomAttribute<DescriptionAttribute>(false)) == null)
                    return enumValue.ToString();

                return descriptionAttribute.Description;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}