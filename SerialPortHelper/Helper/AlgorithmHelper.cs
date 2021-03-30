using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortHelper.Helper
{
    /// <summary>
    /// 16进制使用的隔离符枚举
    /// </summary>
    public enum EnumHex
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 空格
        /// </summary>
        Blank,
        /// <summary>
        /// OX
        /// </summary>
        OX,
        /// <summary>
        /// Ox
        /// </summary>
        Ox
    }

    /// <summary>
    /// 计算进制类助手 
    /// 无校验 （no parity）
    /// 奇校验 （odd parity）：如果字符数据位中"1"的数目是偶数，校验位为"1"，如果"1"的数目是奇数，校验位应为"0"。（校验位调整个数）
    /// 偶校验 （even parity）：如果字符数据位中"1"的数目是偶数，则校验位应为"0"，如果是奇数则为"1"。（校验位调整个数）
    /// mark parity：校验位始终为1
    /// space parity：校验位始终为0
    /// </summary>
    public class AlgorithmHelper
    {
        #region 十进制转16进制
        /// <summary>
        /// 十进制转16进制
        /// </summary>
        /// <returns></returns>
        public string From10To16(int d)
        {
            string hex = "";
            if (d < 16)
            {
                hex = BeginChange(d);
            }
            else
            {
                int c;
                int s = 0;
                int n = d;
                int temp = d;
                while (n >= 16)
                {
                    s++;
                    n = n / 16;
                }
                string[] m = new string[s];
                int i = 0;
                do
                {
                    c = d / 16;
                    //判断是否大于10，如果大于10，则转换为A~F的格式
                    m[i++] = BeginChange(d % 16);
                    d = c;

                } while (c >= 16);

                hex = BeginChange(d);

                for (int j = m.Length - 1; j >= 0; j--)
                {
                    hex += m[j];
                }
            }
            return hex;
        }

        /// <summary>
        /// 判断是否为10~15之间的数，如果是则进行转换
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string BeginChange(int d)
        {
            string hex = "";
            switch (d)
            {
                case 10:
                    hex = "A";
                    break;
                case 11:
                    hex = "B";
                    break;
                case 12:
                    hex = "C";
                    break;
                case 13:
                    hex = "D";
                    break;
                case 14:
                    hex = "E";
                    break;
                case 15:
                    hex = "F";
                    break;
                default:
                    break;
            }
            return hex;
        }
        #endregion

        #region 其他函数【16进制中的隔离符处理】

        /// <summary>
        /// 把16进制隔离符转换成实际的字符串
        /// </summary>
        /// <param name="hex">16进制隔离符枚举</param>
        /// <returns></returns>
        private string AddSplitString(EnumHex hex)
        {
            switch (hex)
            {
                case EnumHex.None:
                    return "";
                case EnumHex.Blank:
                    return " ";
                case EnumHex.OX:
                    return "OX";
                case EnumHex.Ox:
                    return "Ox";  
                default:
                    return "";
            }
        }

        /// <summary>
        /// 去掉16进制字符串中的隔离符 【如："","Ox","OX"】
        /// </summary>
        /// <param name="inString">需要转换的字符串数据</param>
        /// <returns></returns>
        private string DeleteSplitString(string inString)
        {
            string outString = string.Empty;
            string[] delArray = { " ","Ox","OX"};

            //存在隔离
            if (inString.Contains("")|| inString.Contains("Ox") || inString.Contains("OX"))
            {
                //以隔离符进行转换数组，去掉隔离符
                string[] str = inString.Split(delArray,System.StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < str.Length; i++)
                {
                    outString += str[i].ToString();
                }
                return outString;
            }
            else
            {
                //不存在隔离符就直接返回
                return inString;
            }
        }

        #endregion

        #region 汉子、英文、纯16进制数、byte[]之间的各种转换方法
        
        /// <summary>
        /// 字符串转换成16进制
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string StringTo16(string inString,EnumHex hex)
        {
            string outString = string.Empty;
            byte[] bytes = Encoding.Default.GetBytes(inString);

            for (int i = 0; i < bytes.Length; i++)
            {
                int strInt = Convert.ToInt16(bytes[i] - '\0');
                string s = strInt.ToString("X");
                if (s.Length==1)
                {
                    s = "0" + s;
                }
                s = s + AddSplitString(hex);
                outString += s;
            }
            return outString;
        }

        /// <summary>
        /// 字符串转换成byte[]
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public byte[] StringToBytes(string inString)
        {
            //把字符串转换成16进制
            inString = StringTo16(inString, EnumHex.None);
            //把16进制转换成byte[]
            return From16ToBytes(inString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public byte[] From16ToBytes(string inString)
        {
            //去掉16进制中的隔离符
            inString = DeleteSplitString(inString);
            byte[] stringByte = new byte[inString.Length / 2];


            for (int a = 0,b=0; a < inString.Length; a=a+2,b++)
            {
                try
                {
                    string str = inString.Substring(a, 2);
                    stringByte[b] = (byte)Convert.ToInt16(str,16);
                }
                catch (Exception ex)
                {
                    throw new Exception("输入的数据不是纯16进制数！参考错误信息："+ex.Message);
                }
            }
            return stringByte;
        }

        /// <summary>
        /// 把16进制字符串转换成英文数字和汉子混合格式
        /// </summary>
        /// <param name="inString">需要转换的16进制字符串</param>
        /// <returns></returns>
        public string From16ToString(string inString)
        {
            inString = DeleteSplitString(inString);
            return Encoding.Default.GetString(From16ToBytes(inString));
        }

        /// <summary>
        /// 把byte[]转换成String
        /// </summary>
        /// <param name="bytes">需要转换的byte[]</param>
        /// <param name="hex">隔离符</param>
        /// <returns></returns>
        public string BytesToString(byte[] bytes,EnumHex hex)
        {
            return From16ToString(BytesTo16(bytes, hex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string BytesTo16(byte[] bytes,EnumHex hex)
        {
            string outString = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                // 16进制数为一位时前面填充0
                if (bytes[i].ToString("X").Length<2)
                {
                    //转成16进制数
                    outString += "0" + bytes[i].ToString("X")+AddSplitString(hex);
                }
                else
                {
                    //转成16进制数据
                    outString += bytes[i].ToString("X")+AddSplitString(hex);
                }
            }
            return outString;
        }

        /// <summary>
        /// 把byte[]直接转换成字符串,直接以2进制形式显示出来
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string BytesTo2String(byte[] bytes,EnumHex hex)
        {
            string outSting = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                string tempString = Convert.ToString(bytes[i],2);
                if (tempString.Length!=8)
                {
                    string add0 = "";
                    for (int j = 0; j < 8-tempString.Length; j++)
                    {
                        add0 += "0";
                    }
                    tempString += add0 + tempString + AddSplitString(hex);
                }
                else
                {
                    outSting += tempString + AddSplitString(hex);
                }
            }
            return outSting;
        }

        /// <summary>
        /// 把字符串传进来，输出一个byte数组 【可以把此byte数组直接发送到串口中】
        /// </summary>
        /// <param name="inString">要转换的字符串</param>
        /// <param name="is16">是否已经是16进制，true时已经是，false不是(需要转换)</param>
        /// <returns>输出一个byte数组</returns>
        public byte[] StringToBytes(string inString,bool is16)
        {
            if (is16)
            {
                return From16ToBytes(inString);
            }
            else
            {
                return StringToBytes(inString);
            }
        }

        #endregion

    }
}