using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Common
{
    public class DBHelper
    {


        #region OleDB操作
        public static string oleDBConStr = ConfigurationManager.ConnectionStrings["GGChatDB"].ConnectionString;


        /// <summary>
        /// OleDb查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable SelectByOleDB(string sql)
        {

            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter(sql, con);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                con.Close();
                con = null;
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// OleDb查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable SelectByOleDB(string sql, object[] valueArr)
        {

            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                foreach (object item in valueArr)
                {
                    cmd.Parameters.Add("?", item);
                }
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                con.Close();
                con = null;
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int ExecuteByOleDB(string sql, object[] valueArr)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand(sql, con);

                foreach (object item in valueArr)
                {
                    cmd.Parameters.Add(new OleDbParameter("?", item));
                }
                cmd.Transaction = tran;
                row = cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }

        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int ExecuteByOleDB(string sql, OleDbParameter[] paraArr)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddRange(paraArr);
                cmd.Transaction = tran;
                row = cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }

        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int ExecuteByOleDB(string sql)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.Transaction = tran;
                row = cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }

        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int MutiExecuteByOleDB(string[] sqlArr, List<object[]> valueList)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    row = -1;
                    OleDbCommand cmd = new OleDbCommand(sqlArr[i], con);
                    foreach (object item in valueList[i])
                    {
                        cmd.Parameters.Add("?", item);
                    }
                    cmd.Transaction = tran;
                    row = cmd.ExecuteNonQuery();
                }
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }


        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int MutiExecuteByOleDB(string[] sqlArr, object[] valueList)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    row = -1;
                    OleDbCommand cmd = new OleDbCommand(sqlArr[i], con);
                    foreach (OleDbParameter item in valueList[i] as OleDbParameter[])
                    {
                        cmd.Parameters.Add(item);
                    }
                    cmd.Transaction = tran;
                    row = cmd.ExecuteNonQuery();
                }
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }


        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int MutiExecuteByOleDB0(string[] sqlArr, object[] valueArr)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    OleDbCommand cmd = new OleDbCommand(sqlArr[i], con);
                    cmd.Parameters.AddRange(valueArr[i] as OleDbParameter[]);
                    cmd.Transaction = tran;
                    row = cmd.ExecuteNonQuery();
                }
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }

        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int MutiExecuteByOleDB0(string[] sqlArr)
        {
            int row = 0;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    OleDbCommand cmd = new OleDbCommand(sqlArr[i], con);
                    cmd.Transaction = tran;
                    row += cmd.ExecuteNonQuery();
                }
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    row = 0;
                    tran.Rollback();
                }
                throw;
            }
            if (row != sqlArr.Length)
            {
                row = 0;
                if (tran != null)
                {
                    row = 0;
                    tran.Rollback();
                }
            }
            return row;
        }


        /// <summary>
        /// OleDB增删改查的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paraArr"></param>
        /// <returns></returns>
        public static int MutiExecuteByOleDB(string[] sqlArr)
        {
            int row = -1;
            OleDbTransaction tran = null;
            try
            {
                OleDbConnection con = new OleDbConnection(oleDBConStr);
                con.Open();
                tran = con.BeginTransaction();
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    row = -1;
                    OleDbCommand cmd = new OleDbCommand(sqlArr[i], con);
                    cmd.Transaction = tran;
                    row = cmd.ExecuteNonQuery();
                }
                tran.Commit();
                con.Close();
                con = null;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }
            return row;
        }
        #endregion


        #region SqlServer操作

        /// <summary>
        /// 全局数据库变量
        /// </summary>

        private static string ConStr = ConfigurationManager.ConnectionStrings["GGChatDB"].ConnectionString;


        /// <summary>
        /// 增删改的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Excute(string sql)
        {
            int row = -1;
            SqlTransaction tran = null;
            try
            {
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                tran = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sql, con) { Transaction = tran };
                row = cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                row = -1;
                throw new Exception(ex.Message);
            }
            return row;
        }

        /// <summary>
        /// 增删改的通用方法[正则表达式 参数化]
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Excute(string sql, object[] sqlValueArr)
        {
            int row = -1;
            SqlTransaction tran = null;
            try
            {
                Regex r = new Regex(@"@+\w+"); // 定义一个Regex对象实例

                MatchCollection paramCollection = r.Matches(sql); // 在字符串中匹配 

                SqlParameter[] sqlParaArr = new SqlParameter[paramCollection.Count];
                for (int i = 0; i < paramCollection.Count; i++) //在输入字符串中找到所有匹配
                {
                    string val = paramCollection[i].Value.Trim().Replace("\r\n", ""); 
                    sqlParaArr[i] = new SqlParameter(val, sqlValueArr[i]);
                }
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                tran = con.BeginTransaction(); 
                SqlCommand cmd = new SqlCommand(sql, con);
                foreach (SqlParameter item in sqlParaArr)
                {
                    cmd.Parameters.Add(item);
                }
                cmd.Transaction = tran;
                row = cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                row = -1;
            }
            return row;
        }

        /// <summary>
        /// 增删改的通用方法[多条sql]
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Excute(string[] sqlArr)
        {
            int row = -1;
            SqlTransaction tran = null;
            try
            {
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                tran = con.BeginTransaction();
                foreach (string sql in sqlArr)
                {
                    SqlCommand cmd = new SqlCommand(sql, con) { Transaction = tran };
                    row = cmd.ExecuteNonQuery();
                    row++;

                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Transaction = tran;
                    //row = cmd.ExecuteNonQuery();
                    //row++;
                }
                if (row == sqlArr.Length)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                row = -1;
                throw new Exception(ex.Message);
            }
            return row;
        }


        /// <summary>
        /// 获得DataTable的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable Select(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 获得DataTable的通用方法[参数化]
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable Select(string sql, object[] sqlValueArr)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    string[] filedArr = sql.Split('@');
                    SqlParameter[] sqlParaArr = new SqlParameter[sqlValueArr.Length];
                    for (int i = 0; i < sqlValueArr.Length; i++)
                    {
                        string temp = filedArr[i + 1].Substring(0, 2);
                        string field = "@" + temp;
                        sqlParaArr[i] = new SqlParameter(field, sqlValueArr[i]);
                    }
                    foreach (SqlParameter item in sqlParaArr)
                    {
                        cmd.Parameters.Add(item);
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }


        /// <summary>
        /// 获得DataTable的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static T SelectSingleEntity<T>(string sql)
        {
            T newItem = Activator.CreateInstance<T>();
            Type type = typeof(T);//得到对象类型

            PropertyInfo[] propArr = type.GetProperties();//得到所有属性
            DataTable dt = Select(sql);
            try
            {
                if (dt.Rows.Count == 1)
                {
                    foreach (PropertyInfo prepor in propArr)
                    {
                        object value = dt.Rows[0][prepor.Name];
                        prepor.SetValue(newItem, value, null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newItem;
        }


        /// <summary>
        /// 获得List的通用方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> Select<T>(string sql)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);//得到对象类型

            PropertyInfo[] propArr = type.GetProperties();//得到所有属性
            DataTable dt = Select(sql);
            try
            {
                foreach (DataRow item in dt.Rows)
                {
                    T newItem = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prepor in propArr)
                    {
                        object value = item[prepor.Name];
                        prepor.SetValue(newItem, value, null);
                    }
                    list.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        /// <summary>
        /// 得到单个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Object GetSingleData(string sql)
        {
            object obj = new object();
            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    obj = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        #endregion


        #region MD5加密

        /// <summary>
        /// 得到MD5加密后的密码
        /// </summary>
        /// <param name="oldPwd"></param>
        /// <returns></returns>
        public static string GetMD5Pwd(string oldPwd)
        {
            try
            {
                string newPwd = "";
                MD5 md5 = MD5.Create();
                byte[] buffer = System.Text.Encoding.Default.GetBytes(oldPwd);
                byte[] MD5Buffer = md5.ComputeHash(buffer);
                foreach (byte item in MD5Buffer)
                {
                    newPwd += item.ToString("x");
                }
                return newPwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        /// <summary>
        /// 将sql数据源转换成 list实体类
        /// </summary>
        public static List<T> ConvertToModel<T>(string sql) where T : class, new()
        {
            DataTable dt = DBHelper.Select(sql);
            List<T> ts = new List<T>();// 定义集合
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    if (dt.Columns.Contains(pi.Name))
                    {
                        if (!pi.CanWrite) continue;
                        var value = dr[pi.Name];
                        if (value != DBNull.Value)
                        {
                            if (pi.PropertyType.FullName.Contains("System.Nullable"))
                            {
                                pi.SetValue(t, Convert.ChangeType(value, (Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType)), null);
                            }
                            else
                            {
                                switch (pi.PropertyType.FullName)
                                {
                                    case "System.Decimal":
                                        pi.SetValue(t, decimal.Parse(value.ToString()), null);
                                        break;
                                    case "System.String":
                                        pi.SetValue(t, value.ToString(), null);
                                        break;
                                    case "System.Char":
                                        pi.SetValue(t, Convert.ToChar(value), null);
                                        break;
                                    case "System.Guid":
                                        pi.SetValue(t, value, null);
                                        break;
                                    case "System.Int16":
                                        pi.SetValue(t, Convert.ToInt16(value), null);
                                        break;
                                    case "System.Int32":
                                        pi.SetValue(t, int.Parse(value.ToString()), null);
                                        break;
                                    case "System.Int64":
                                        pi.SetValue(t, Convert.ToInt64(value), null);
                                        break;
                                    case "System.Byte[]":
                                        pi.SetValue(t, Convert.ToByte(value), null);
                                        break;
                                    case "System.Boolean":
                                        pi.SetValue(t, Convert.ToBoolean(value), null);
                                        break;
                                    case "System.Double":
                                        pi.SetValue(t, Convert.ToDouble(value.ToString()), null);
                                        break;
                                    case "System.DateTime":
                                        pi.SetValue(t, value ?? Convert.ToDateTime(value), null);
                                        break;
                                    default:
                                        pi.SetValue(t, value);
                                        break;
                                    //throw new Exception("类型不匹配:" + pi.PropertyType.FullName);

                                }
                            }
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }


        /// <summary>
        /// 将sql数据源转换成 list实体类（包含泛型）
        /// </summary>
        public static List<T> ConvertToExtModel<T>(string sql) where T : class, new()
        {
            DataTable dt = DBHelper.Select(sql);
            List<T> ts = new List<T>();// 定义集合
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    if (dt.Columns.Contains(pi.Name))
                    {
                        if (!pi.CanWrite) continue;
                        var value = dr[pi.Name];
                        if (value != DBNull.Value)
                        {
                            if (!pi.PropertyType.IsGenericType)
                            {
                                //非泛型
                                pi.SetValue(t, value == null ? null : Convert.ChangeType(value, pi.PropertyType), null);
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    pi.SetValue(t, value == null ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(pi.PropertyType)), null);
                                }
                            }
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }

    }
}
