using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DesafioPerlink.Services
{
    public class Conversor
    {
        /// <summary>
        /// pega a descrição([decsription("")]) do enum passando um enum
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string ToEnumDescription(Enum en)
        {
            if (en == null) return null;

            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static decimal StringParaDecimal(string valor)
        {
            if (string.IsNullOrEmpty(valor)) return default(decimal);
            return Convert.ToDecimal(valor.Trim());
        }
    }
}
