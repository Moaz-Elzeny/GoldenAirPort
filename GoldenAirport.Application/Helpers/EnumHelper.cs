using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace GoldenAirport.Application.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field is null)
            {
                return value.ToString();
            }
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        public static string GetEnumLocalizedDescription<TEnum>(TEnum value)
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
            {
                var field = value.GetType().GetField(value.ToString());
                if (field == null)
                    return value.ToString();
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            DisplayAttribute metadata = value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>();
            return value.ToString();
        }
        public static string GetEnumLocalizedDescription<TEnum>(TEnum value, string Culture)
        {
            if (Culture == "ar")
            {
                var field = value.GetType().GetField(value.ToString());
                if (field == null)
                    return value.ToString();
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            return value.ToString();
        }

        public static List<int> GetEnumValues(Type enumValue)
        {
            List<int> values = new List<int>();
            if (enumValue.IsEnum == false)
                return values;
            foreach (int i in Enum.GetValues(enumValue))
                values.Add(i);
            return values;
        }
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                .SelectMany(f => f.GetCustomAttributes(
                    typeof(DescriptionAttribute), false), (
                    f, a) => new { Field = f, Att = a })
                .Where(a => ((DescriptionAttribute)a.Att)
                    .Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
    }

}
