    using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Collections;

namespace Class
{
    public partial class CreateDatatable
    {
        public static DataTable Create(object genericList)
        {
            DataTable dataTable = null;
            Type listType = genericList.GetType();

            if (listType.IsGenericType & (genericList != null))
            {
                //determine the underlying type the List<> contains
                Type elementType = listType.GetGenericArguments()[0];

                //create empty table -- give it a name in case
                //it needs to be serialized
                dataTable = new DataTable(elementType.Name + "List");

                //define the table -- add a column for each public
                //property or field
                MemberInfo[] memberInfos = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo memberInfo in memberInfos)
                {
                    if (memberInfo.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                        if (IsNullableType(propertyInfo.PropertyType))
                        {

                            DataColumn dc = new DataColumn(propertyInfo.Name, new NullableConverter(propertyInfo.PropertyType).UnderlyingType) { DefaultValue = getvalidet(new NullableConverter(propertyInfo.PropertyType).UnderlyingType.Name) };
                            dataTable.Columns.Add(dc);
                            
                        }
                        else {
                            DataColumn dc = new DataColumn(propertyInfo.Name, propertyInfo.PropertyType) { DefaultValue = getvalidet(propertyInfo.PropertyType.Name) };
                            dataTable.Columns.Add(dc);
                        }
                    }
                    else if (memberInfo.MemberType == MemberTypes.Field)
                    {
                        FieldInfo fieldInfo = memberInfo as FieldInfo;
                        dataTable.Columns.Add(fieldInfo.Name, fieldInfo.FieldType);
                    }
                }

                //populate the table
                IList listData = genericList as IList;
                foreach (object record in listData)
                {
                    int index = 0;
                    object[] fieldValues = new object[dataTable.Columns.Count];
                    foreach (DataColumn columnData in dataTable.Columns)
                    {
                        MemberInfo memberInfo = elementType.GetMember(columnData.ColumnName)[0];
                        if (memberInfo.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                            fieldValues[index] = propertyInfo.GetValue(record, null);
                        }
                        else if (memberInfo.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fieldInfo = memberInfo as FieldInfo;
                            fieldValues[index] = fieldInfo.GetValue(record);
                        }
                        index += 1;
                    }
                    dataTable.Rows.Add(fieldValues);
                }
            }
            return dataTable;
        }



        public static DataTable GenericListToDataTableNullAlowed(object genericList)
        {
            DataTable dataTable = null;
            Type listType = genericList.GetType();

            if (listType.IsGenericType & (genericList != null))
            {
                //determine the underlying type the List<> contains
                Type elementType = listType.GetGenericArguments()[0];

                //create empty table -- give it a name in case
                //it needs to be serialized
                dataTable = new DataTable(elementType.Name + "List");

                //define the table -- add a column for each public
                //property or field
                MemberInfo[] memberInfos = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo memberInfo in memberInfos)
                {
                    try
                    {
                        if (memberInfo.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                            if (IsNullableType(propertyInfo.PropertyType))
                            {

                                DataColumn dc = new DataColumn(propertyInfo.Name, new NullableConverter(propertyInfo.PropertyType).UnderlyingType) { DefaultValue = getvalidet(new NullableConverter(propertyInfo.PropertyType).UnderlyingType.Name) };
                                dataTable.Columns.Add(dc);

                            }
                            else
                            {
                                DataColumn dc = new DataColumn(propertyInfo.Name, propertyInfo.PropertyType) { DefaultValue = getvalidet(propertyInfo.PropertyType.Name) };
                                dataTable.Columns.Add(dc);
                            }
                        }
                        else if (memberInfo.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fieldInfo = memberInfo as FieldInfo;
                            dataTable.Columns.Add(fieldInfo.Name, fieldInfo.FieldType);
                        }
                    }
                    catch(Exception ex) 
                    {
                    
                    }
                }

                //populate the table
                IList listData = genericList as IList;
                foreach (object record in listData)
                {
                    int index = 0;
                    object[] fieldValues = new object[dataTable.Columns.Count];
                    foreach (DataColumn columnData in dataTable.Columns)
                    {
                        MemberInfo memberInfo = elementType.GetMember(columnData.ColumnName)[0];
                        if (memberInfo.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                            fieldValues[index] = propertyInfo.GetValue(record, null);
                        }
                        else if (memberInfo.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fieldInfo = memberInfo as FieldInfo;
                            fieldValues[index] = fieldInfo.GetValue(record);
                        }
                        index += 1;
                    }
                    dataTable.Rows.Add(fieldValues);
                }
            }
            return dataTable;
        }



        /// <summary>
        /// Check if a type is Nullable type
        /// </summary>
        /// <param name="propertyType">Type to be checked</param>
        /// <returns>true/false</returns>
        /// <remarks></remarks>
        private static bool IsNullableType(Type propertyType)
        {
            return (propertyType.IsGenericType) && (object.ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(Nullable<>)));
        }
        public static object getvalidet(string str)
        {
            if (str == "Int32")
            {
                return 0;
            }
            else if (str == "Int64")
            {
                return 0;
            }

            else if (str == "String")
            {
                return "";
            }
            else if (str == "Boolean")
            {
                return false;
            }
            else if (str == "Decimal")
            {
                return 0m;
            }
            else if (str == "DateTime")
            {
                return DBNull.Value;
            }
            
            else
            {
                return "";
            }
            
        }
    }
}
