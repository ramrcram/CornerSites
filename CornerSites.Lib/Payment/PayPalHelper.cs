using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.paypal.soap.api;

namespace CornerSites.Lib.Payment
{
    public class PayPalHelper
    {
        /// <summary>
        /// Get Paypal currency code
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Paypal currency code</returns>
        public static CurrencyCodeType GetPaypalCurrency(string CurrencyCode)
        {
            CurrencyCodeType currencyCodeType = CurrencyCodeType.USD;
            try
            {
                currencyCodeType = (CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), CurrencyCode, true);
            }
            catch
            {
            }
            return currencyCodeType;
        }

        /// <summary>
        /// Checks response
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="abstractResponse">response</param>
        /// <param name="errorMsg">Error message if exists</param>
        /// <returns>True - response OK; otherwise, false</returns>
        public static bool CheckSuccess(int languageId, AbstractResponseType abstractResponse, out string errorMsg)
        {
            bool success = false;
            StringBuilder sb = new StringBuilder();
            switch (abstractResponse.Ack)
            {
                case AckCodeType.Success:
                case AckCodeType.SuccessWithWarning:
                    success = true;
                    break;
                default:
                    break;
            }
            if (null != abstractResponse.Errors)
            {
                foreach (ErrorType errorType in abstractResponse.Errors)
                {
                    if (sb.Length <= 0)
                    {
                        sb.Append(Environment.NewLine);
                    }
                    //sb.Append(errorType.LongMessage.EndsWith(".") ? errorType.LongMessage.Substring(0, errorType.LongMessage.Length - 1) : errorType.LongMessage);
                    sb.Append("We have been unable to take payment for this order. Do not post this order! Please contact Maker Support at Seek & Adore for advice and assistance.");

                    StringBuilder paypalErrorMsg = new StringBuilder();
                    paypalErrorMsg.Append("LongMessage: ").Append(errorType.LongMessage).Append(Environment.NewLine);
                    paypalErrorMsg.Append("ShortMessage: ").Append(errorType.ShortMessage).Append(Environment.NewLine);
                    paypalErrorMsg.Append("ErrorCode: ").Append(errorType.ErrorCode).Append(Environment.NewLine);
                    //LogManager.InsertLog(LogTypeEnum.OrderError, paypalErrorMsg.ToString(), paypalErrorMsg.ToString());

                    //MessageManager.SendAuthorizationFailedStoreOwnerNotification(null, errorType.ErrorCode,
                       // errorType.LongMessage, errorType.ShortMessage, languageId);
                }
            }
            errorMsg = sb.ToString();
            return success;
        }

    }
}
