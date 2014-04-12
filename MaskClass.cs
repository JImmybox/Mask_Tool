Enter file contents hereusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mask_Hugo
{
    /// <summary>
    /// 遮罩功能物件
    /// </summary>
    public class MaskClass
    {
        #region 欄位宣告

        /// <summary>
        /// 遮罩目標字串
        /// </summary>
        string strText;

        #endregion

        #region 建構子

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="text"></param>
        public MaskClass(string text) 
        {
            strText = text;
        }

        #endregion

        #region 遮罩方法

        /// <summary>
        /// 結尾遮罩
        /// </summary>
        /// <param name="num"></param>
        /// <returns>遮罩處理結果字串</returns>
        public MaskModel SwMaskLeftToRight(int num)
        {
            //建立結果資料模型
            MaskModel resultModel = new MaskModel();

            try
            {
                //驗證參數
                if (!DoValidate(num))
                {
                    resultModel = GetVarErrorModel();
                    return resultModel;
                }

                //將目標字串轉型為Char陣列
                char[] Text = strText.ToCharArray();

                //利用迴圈處理每個Char,依結尾遮罩，從 i 大於 num 之後遮罩字串
                for (int i = 0 ; i < Text.Length ; ++i)
                {
                    if (i >= num - 1)
                    {
                        Text[i] = GetMaskChar();
                    }
                }

                //取得執行結果
                resultModel = GetResultModel(Text);

                return resultModel;
            }
            catch(Exception ex) 
            {
                return GetCatchModel(ex);
            }
        }

        /// <summary>
        /// 起始遮罩
        /// </summary>
        /// <param name="num"></param>
        /// <returns>遮罩處理結果字串</returns>
        public MaskModel SwMaskRightToLeft(int num)
        {
            //建立結果資料模型
            MaskModel resultModel = new MaskModel();

            try
            {
                //驗證參數
                if (!DoValidate(num))
                {
                    resultModel = GetVarErrorModel();
                    return resultModel;
                }

                //將目標字串轉型為Char陣列
                char[] Text = strText.ToCharArray();

                //將Char陣列Reverse
                Array.Reverse(Text);

                //經reverse，與結尾遮罩相同
                for (int i = 0 ; i < Text.Length ; ++i)
                {
                    if (i >= num - 1)
                    {
                        Text[i] = GetMaskChar();
                    }
                }

                //將Char陣列Reverse回來
                Array.Reverse(Text);

                //取得執行結果
                resultModel = GetResultModel(Text);

                return resultModel;
            }
            catch(Exception ex)
            {
                return GetCatchModel(ex);
            }
        }

        /// <summary>
        /// 範圍遮罩
        /// </summary>
        /// <param name="star"></param>
        /// <param name="end"></param>
        /// <returns>遮罩處理結果字串</returns>
        public MaskModel SwMaskRange(int star, int end)
        {
            //建立結果資料模型
            MaskModel resultModel = new MaskModel();

            try
            {
                //驗證參數
                if (!DoValidate(star, end))
                {
                    resultModel = GetVarErrorModel();
                    return resultModel;
                }

                //將目標字串轉型為Char陣列
                char[] Text = strText.ToCharArray();

                //利用迴圈處理每個Char,依範圍遮罩，從 i 介於 star與end 之間遮罩
                for (int i = 0 ; i < Text.Length ; ++i)
                {
                    if (i >= star - 1 && i < end - 1)
                    {
                        Text[i] = GetMaskChar();
                    }
                }

                //取得執行結果
                resultModel = GetResultModel(Text);

                return resultModel;
            }
            catch (Exception ex)
            {
                return GetCatchModel(ex);
            }
        }

        /// <summary>
        /// 亂數遮罩
        /// </summary>
        /// <param name="random"></param>
        /// <returns>遮罩處理結果字串</returns>
        public MaskModel SwMaskRandom(int random)
        {
            //建立結果資料模型
            MaskModel resultModel = new MaskModel();

            try
            {
                //驗證參數
                if (!DoValidate(random))
                {
                    resultModel = GetVarErrorModel();
                    return resultModel;
                }

                //將目標字串轉型為Char陣列
                char[] Text = strText.ToCharArray();

                //取得亂數欲遮罩位置陣列
                int[] maskList = GetRandomList(random);

                //利用迴圈處理每個Char,依亂數遮罩位置給予遮罩
                for (int i = 0; i < maskList.Length; ++i)
                {
                    Text[maskList[i]] = GetMaskChar();
                }

                //取得執行結果
                resultModel = GetResultModel(Text);

                return resultModel;
            }
            catch (Exception ex)
            {
                return GetCatchModel(ex);
            }
        }

        /// <summary>
        /// 中間遮罩
        /// </summary>
        /// <param name="star"></param>
        /// <param name="end"></param>
        /// <returns>遮罩處理結果字串</returns>
        public MaskModel SwMaskMiddle(int star, int end)
        {
            //建立結果資料模型
            MaskModel resultModel = new MaskModel();

            try
            {
                //驗證參數
                if (!DoValidate(star, end))
                {
                    resultModel = GetVarErrorModel();
                    return resultModel;
                }

                //將目標字串轉型為Char陣列
                char[] Text = strText.ToCharArray();

                //重新取得結尾絕對位置
                end = Text.Length - end;

                //利用迴圈處理每個Char,依中間遮罩，從 i 介於 star與end 之間遮罩
                for (int i = 0; i < Text.Length; ++i)
                {
                    if (i >= star && i < end)
                    {
                        Text[i] = GetMaskChar();
                    }
                }
                
                //取得執行結果
                resultModel = GetResultModel(Text);

                return resultModel;
            }
            catch (Exception ex)
            {
                return GetCatchModel(ex);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 取得遮罩字元
        /// </summary>
        /// <returns></returns>
        private char GetMaskChar()
        {
            return Convert.ToChar("*");
        }

        /// <summary>
        /// 取得遮罩亂數位置
        /// </summary>
        /// <param name="num">保留的個數</param>
        /// <returns>遮罩位置數字陣列</returns>
        private int[] GetRandomList(int num)
        {
            Random getRandom = new Random();

            List<RandomModel> list = RandomModel.GetListOfNumber(strText.Length);

            int maskNum = strText.Length - num;

            int[] maskList = new int[maskNum];

            for (int i = 0; i < maskNum; ++i)
            {
                int j = getRandom.Next(0, list.Count);

                maskList[i] = list[j].number;

                list.RemoveAt(j);
            }

            return maskList;
        }

        /// <summary>
        /// 驗證輸入數字是否合法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoValidate(int input)
        {
            if (input > strText.Length)
            {
                return false;
            }

            if (input < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 驗證輸入數字是否合法
        /// </summary>
        /// <param name="inputStar"></param>
        /// <param name="inputEnd"></param>
        /// <returns></returns>
        private bool DoValidate(int inputStar, int inputEnd)
        {
            if (inputStar > strText.Length || inputEnd > strText.Length)
            {
                return false;
            }

            if (inputStar < 1 || inputEnd < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 取得引數錯誤結果模型
        /// </summary>
        /// <returns></returns>
        private MaskModel GetVarErrorModel()
        {
            MaskModel result = new MaskModel();

            result.isSuccess = false;
            result.maskResult = "";
            result.message = "方法引數錯誤!";

            return result;
        }

        /// <summary>
        /// 取得執行錯誤結果模型
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private MaskModel GetCatchModel(Exception ex)
        {
            MaskModel result = new MaskModel();

            result.isSuccess = false;
            result.maskResult = "";
            result.message = string.Format("錯誤原因︰{0}",ex.Message);

            return result;
        }

        /// <summary>
        /// 取得執行結果模型
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private MaskModel GetResultModel(char[] text)
        {
            MaskModel resultModel = new MaskModel();

            resultModel.isSuccess = true;
            resultModel.message = "";
            resultModel.maskResult = new string(text);

            return resultModel;
        }

        #endregion

    }
}
