Enter file contents hereusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mask_Hugo
{
    /// <summary>
    /// 遮罩資料處理模型
    /// </summary>
    public class MaskModel
    {
        /// <summary>
        /// 執行是否成功
        /// </summary>
        public bool isSuccess
        { get; set;}

        /// <summary>
        /// 遮罩處理字串
        /// </summary>
        public string maskResult
        { get; set; }

        /// <summary>
        /// 結果訊息
        /// </summary>
        public string message
        { get; set; }
    }
}
