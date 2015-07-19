using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Common
{
    /// <summary>
    /// Класс, содержащий различные вспомогательные методы и функции.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Возвращает новый массив указанной длины, начиная с заданного индекса.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Исходный массив.</param>
        /// <param name="index">Стартовый индекс, указывающий начальную позицию копирования.</param>
        /// <param name="length">Кол-во элементов для копирования.</param>
        /// <returns></returns>
        public static T[] SubArray<T>( T[] array, int index, int length )
        {
            T[] result = new T[ length ];
            Array.Copy( array, index, result, 0, length );
            return result;
        }

        public static byte[] ObjectToBytes( Object obj )
        {
            if ( obj == null )
                throw new NullReferenceException( "Нельзя конвертировать null объект в byte массив!" );

            BinaryFormatter bf = new BinaryFormatter();

            using ( MemoryStream ms = new MemoryStream() )
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T BytesToObject<T>( byte[] obj )
        {
            if ( obj == null || obj.Length == 0 )
                throw new NullReferenceException( "Нельзя конвертировать пустой или null byte массив в объект!" );

            Object result;
            T converted;

            BinaryFormatter bf = new BinaryFormatter();
            
            using ( MemoryStream ms = new MemoryStream() )
            {
                ms.Write( obj, 0, obj.Length );
                ms.Seek( 0, SeekOrigin.Begin );
                result = bf.Deserialize( ms );             
            }

            converted = ( T )result;

            return converted;
        }


    }
}
