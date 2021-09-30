using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace BookStore
{
    public class ExcelOutput : IOutput
    {
        public static string ToCsv(List<Book> items)
        {
            string delimiter = ",";
            Type itemType = typeof(Book);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                // .Where(x => Attribute.IsDefined(x, typeof(VisibleAttribute), true));
                .Where(pi => pi.GetCustomAttributes(typeof(VisibleAttribute), false).Length == 0);
            var csv = new StringBuilder();

            csv.AppendLine(string.Join(delimiter, props.Select(p => p.Name)));

            foreach (var item in items.Where(x => !x.IsDelete).OrderBy(x => x.Title))
            {
                csv.AppendLine(string.Join(delimiter, props.Select(p => GetCsvFieldasedOnValue(p, item))));
            }

            return csv.ToString();
        }

        public static string GetEnumMemberAttrValue<T>(T enumVal)
        {
            var enumType = typeof(T);
            var memInfo = enumType.GetMember(enumVal.ToString());
            var attr = memInfo.FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            if (attr != null)
            {
                return attr.Value;
            }

            return enumVal.ToString();
        }
        private static object GetCsvFieldasedOnValue<T>(PropertyInfo p, T item)
        {
            string value = "";
            try
            {
                value = p.GetValue(item, null)?.ToString();

                if (p.PropertyType == typeof(string))
                {
                    value = $"\"{value.Replace("\r\n", "")}\"";
                }
                else if (p.PropertyType == typeof(DateTime))
                {
                    value = Convert.ToDateTime(value).ToString("d");
                }
                else if (p.PropertyType == typeof(Genre))
                {
                    Genre genre = (Genre)Enum.Parse(typeof(Genre), value);
                    value = GetEnumMemberAttrValue<Genre>(genre);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }
        public void SaveBooks(List<Book> books)
        {
            string path = ConfigurationManager.AppSettings["FileOutput"]; ;
            string s = ToCsv(books);
            File.WriteAllText(path, s);
            Console.WriteLine($"File {path} is ready");
        }
    }
}
