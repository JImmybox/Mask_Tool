using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mask_Hugo
{
    public class Program
    {
        /// <summary>
        /// 程式進入點
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            MaskInitialize();
            
            DoMaskProccess("Systemweb");
            
            Console.Read();
        }

        /// <summary>
        /// 初始化遮罩程式
        /// </summary>
        private static void MaskInitialize()
        {
            Console.WriteLine("字串=“Systemweb”");
        }

        /// <summary>
        /// 執行程式主體
        /// </summary>
        /// <param name="text"></param>
        private static void DoMaskProccess(string text)
        {
            MaskModel result = new MaskModel();
            MaskClass tool = new MaskClass(text);
            
            result = tool.SwMaskLeftToRight(4);
            Console.WriteLine("結尾遮罩(LeftToRight): 字串由左至右, 指定第n個字開始遮罩, ");
            Console.WriteLine("如 SwMaskLeftToRight (4) = " + ShowResult(result));

            result = tool.SwMaskRightToLeft(4);
            Console.WriteLine("起始遮罩(RightToLeft): 字串由右至左, 指定第n個字往前開始遮罩, ");
            Console.WriteLine("如 SwMaskRightToLeft (4) =  " + ShowResult(result));

            result = tool.SwMaskRange(3,7);
            Console.WriteLine("範圍遮罩(Range):  字串指定一個範圍區間(n~m)內遮罩, ");
            Console.WriteLine("如 SwMaskRange (3,7) =  " + ShowResult(result));

            result = tool.SwMaskRandom(3);
            Console.WriteLine("亂數遮罩(Random):字串指定需要保留幾個值, 其餘字元遮罩, ");
            Console.WriteLine("如 SwMaskRandom (3) = " + ShowResult(result));

            result = tool.SwMaskMiddle(1,3);
            Console.WriteLine("中間遮罩(Middle): 字串指定前後各保留幾碼顯示, 其餘字元遮罩,");
            Console.WriteLine("如 SwMaskMiddle (1,3) =  " + ShowResult(result));

        }

        /// <summary>
        /// 顯示呼叫方法結果字串
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string ShowResult(MaskModel result)
        {
            if (!result.isSuccess)
            {
                return result.message;
            }

            return result.maskResult;
        }
    }
}
