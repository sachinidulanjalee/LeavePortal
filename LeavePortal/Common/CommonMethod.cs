using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Windows.Forms;

namespace LeavePortal.Common
{
    public class CommonMethod
    {
           public static string GetDescription(System.Enum value)
            {
                DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }

            public static T GetEnumValue<T>(string description)
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

            internal static void setEnumValues(object cmbSlipType, Type type)
            {
                throw new NotImplementedException();
            }

            public static void setEnumValues(ComboBox cxbx, Type typ)
            {
                if (!typ.IsEnum)
                {
                    throw new ArgumentException("Only Enum types can be set");
                }

                List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

                foreach (int i in Enum.GetValues(typ))
                {
                    string name = Enum.GetName(typ, i);
                    string desc = name;
                    FieldInfo fi = typ.GetField(name);

                    // Get description for enum element
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0)
                    {
                        string s = attributes[0].Description;
                        if (!string.IsNullOrEmpty(s))
                        {
                            desc = s;
                        }
                    }

                    list.Add(new KeyValuePair<string, int>(desc, i));
                }

                // NOTE: It is very important that DisplayMember and ValueMember are set before DataSource.
                //       If you do, this works fine, and the SelectedValue of the ComboBox will be an int
                //       version of the Enum.
                //       If you don't, it will be a KeyValuePair.
                cxbx.DisplayMember = "Key";
                cxbx.ValueMember = "Value";
                cxbx.DataSource = list;
            }

        public List<DropListDTO> ComboDataBindByEnum<T>()
        {
            List<DropListDTO> oData = new List<DropListDTO>();
            try
            {
                oData.Add(new DropListDTO { Text = "- Select -", Value = "" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new DropListDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}
