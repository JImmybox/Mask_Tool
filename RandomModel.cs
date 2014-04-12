Enter file contents hereusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mask_Hugo
{
    /// <summary>
    /// 隨機函數模型,提供List
    /// </summary>
    public class RandomModel
    {
        /// <summary>
        /// 數字欄位
        /// </summary>
        public int number
        {
            get; 
            set; 
        }

        /// <summary>
        /// 建構函數,初始化欄位
        /// </summary>
        /// <param name="num"></param>
        public RandomModel(int num)
        {
            this.number = num;
        }

        /// <summary>
        /// 取得連續整數List
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<RandomModel> GetListOfNumber(int num)
        {
            List<RandomModel> list = new List<RandomModel>();

            for (int i = 0; i < num; ++i)
            {
                list.Add(new RandomModel(i));
            }

            return list;
        }

        

    }
}
