using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Common.Utils
{
 

    public class SerializerUtil
    { 

        /// <summary>
        /// 将对象序列化为json字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>json字符串</returns>
        public static string ObjectToJson<T>(T t) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.WriteObject(stream, t);
                string result = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                return result;
            }
        }

        /// <summary>
        /// json字符串转成对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">json格式字符串</param>
        /// <returns>对象</returns>
        public static T JsonToObject<T>(string json) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                T result = formatter.ReadObject(stream) as T;
                return result;
            }
        }
    }
}
