using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.paypal.sdk.services;
using com.paypal.soap.api;
using com.paypal.sdk.profiles;
using System.Web;
using System.Globalization;
using CornerSites.Lib.Utils;

namespace CornerSites.Lib.Payment
{
    public class PayPalDirectPaymentProcessor
    {
        #region Fields

        private string APIAccountUsername;
        private string APIAccountPassword;
        private string APIAccountSignature;
        private string Environment;
        private CallerServices caller;
        private IAPIProfile profile;

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the PayPalDirectPaymentProcessor class
        /// </summary>
        public PayPalDirectPaymentProcessor()
        {

        }

        #endregion

        #region Properies

        /// <summary>
        /// Gets Paypal API version
        /// </summary>
        public string APIVersion
        {
            get
            {
                return "3.0";
            }
        }

        /// <summary>
        /// Gets a value indicating whether capture is supported
        /// </summary>
        public bool CanCapture
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether refund is supported
        /// </summary>
        public bool CanRefund
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether void is supported
        /// </summary>
        public bool CanVoid
        {
            get
            {
                return true;
            }
        }


        #endregion

        #region Methods


        ///// <summary>
        ///// Get Paypal country code
        ///// </summary>
        ///// <param name="country">Country</param>
        ///// <returns>Paypal country code</returns>
        //protected CountryCodeType GetPaypalCountryCodeType(Country country)
        //{
        //    CountryCodeType payerCountry = CountryCodeType.IN;
        //    try
        //    {
        //        payerCountry = (CountryCodeType)Enum.Parse(typeof(CountryCodeType), country.TwoLetterIsoCode);
        //    }
        //    catch
        //    {
        //    }
        //    return payerCountry;
        //}

        ///// <summary>
        ///// Get Paypal credit card type
        ///// </summary>
        ///// <param name="CreditCardType">Credit card type</param>
        ///// <returns>Paypal credit card type</returns>
        //protected CreditCardTypeType GetPaypalCreditCardType(string CreditCardType)
        //{
        //    CreditCardTypeType creditCardTypeType = (CreditCardTypeType)Enum.Parse(typeof(CreditCardTypeType), CreditCardType);
        //    return creditCardTypeType;
        //}

        
        private void InitSettings()
        {
            APIAccountUsername = "ramrc0_1306615041_biz_api1.gmail.com";
            APIAccountPassword = "1306615058";
            APIAccountSignature = "AtP7rLd7TBR7eGbquoauyoA.T0bXAEgVPCgWRJ7.pbYP9lvnEWI2G4k6";
            Environment = "sandbox";

            //if (string.IsNullOrEmpty(APIAccountUsername))
            //    throw new NopException("Paypal Direct API Account Username is empty");

            //if (string.IsNullOrEmpty(APIAccountPassword))
            //    throw new NopException("Paypal Direct API Account Password is empty");

            //if (string.IsNullOrEmpty(APIAccountSignature))
            //    throw new NopException("Paypal Direct API Account Signature is empty");

            caller = new CallerServices();
            profile = ProfileFactory.createSignatureAPIProfile();

            profile.APIUsername = APIAccountUsername;
            profile.APIPassword = APIAccountPassword;
            profile.APISignature = APIAccountSignature;
            profile.Environment = Environment;
            caller.APIProfile = profile;
        }

        ///// <summary>
        ///// Process payment
        ///// </summary>
        ///// <param name="paymentInfo">Payment info required for an order processing</param>
        ///// <param name="customer">Customer</param>
        ///// <param name="orderGuid">Unique order identifier</param>
        ///// <param name="processPaymentResult">Process payment result</param>
        //public void ProcessPayment(PaymentInfo paymentInfo, Customer customer,
        //        Guid orderGuid, ref ProcessPaymentResult processPaymentResult, bool TransactMode)
        //{
        //    if (TransactMode)
        //    {
        //        AuthorizeOrSale(paymentInfo, customer, orderGuid, processPaymentResult, true);
        //        if (!String.IsNullOrEmpty(processPaymentResult.Error))
        //            return;
        //    }
        //    else
        //    {
        //        AuthorizeOrSale(paymentInfo, customer, orderGuid, processPaymentResult, false);
        //        if (!String.IsNullOrEmpty(processPaymentResult.Error))
        //            return;
        //    }
        //}

        /// <summary>
        /// Authorizes the payment
        /// </summary>
        /// <param name="paymentInfo">Payment info required for an order processing</param>
        /// <param name="customer">Customer</param>
        /// <param name="orderGuid">Unique order identifier</param>
        /// <param name="processPaymentResult">Process payment result</param>
        /// <param name="authorizeOnly">A value indicating whether to authorize only; true - authorize; false - sale</param>
        //protected void AuthorizeOrSale(PaymentInfo paymentInfo, Customer customer,
        //    Guid orderGuid, ProcessPaymentResult processPaymentResult, bool authorizeOnly)
        //{
        //    //InitSettings();

        //    DoDirectPaymentRequestType request = new DoDirectPaymentRequestType();
        //    DoDirectPaymentRequestDetailsType details = new DoDirectPaymentRequestDetailsType();

        //    request.Version = this.APIVersion;
        //    request.DoDirectPaymentRequestDetails = details;
        //    details.IPAddress = HttpContext.Current.Request.UserHostAddress;
        //    details.MerchantSessionId = "1X911810264059026";

        //    if (authorizeOnly)
        //        details.PaymentAction = PaymentActionCodeType.Authorization;
        //    else
        //        details.PaymentAction = PaymentActionCodeType.Sale;

        //    details.CreditCard = new CreditCardDetailsType();
        //    details.CreditCard.CreditCardTypeSpecified = true;
        //    details.CreditCard.CreditCardNumber = paymentInfo.CreditCardNumber;
        //    details.CreditCard.CreditCardType = GetPaypalCreditCardType(paymentInfo.CreditCardType);
        //    details.CreditCard.CVV2 = paymentInfo.CreditCardCvv2;
        //    details.CreditCard.ExpMonth = paymentInfo.CreditCardExpireMonth;
        //    details.CreditCard.ExpYear = paymentInfo.CreditCardExpireYear;
        //    details.CreditCard.ExpMonthSpecified = true;
        //    details.CreditCard.ExpYearSpecified = true;
        //    details.CreditCard.CardOwner = new PayerInfoType();
        //    details.CreditCard.CardOwner.Payer = "";
        //    details.CreditCard.CardOwner.PayerID = "";
        //    details.CreditCard.CardOwner.PayerStatus = PayPalUserStatusCodeType.unverified;
        //    details.CreditCard.CardOwner.PayerCountry = "India";

        //    details.CreditCard.CardOwner.Address = new AddressType();
        //    details.CreditCard.CardOwner.Address.CountrySpecified = true;
        //    details.CreditCard.CardOwner.Address.Street1 = paymentInfo.BillingAddress.Address1;
        //    details.CreditCard.CardOwner.Address.Street2 = paymentInfo.BillingAddress.Address2;
        //    details.CreditCard.CardOwner.Address.CityName = paymentInfo.BillingAddress.City;
        //    if (paymentInfo.BillingAddress.StateProvince != null)
        //        details.CreditCard.CardOwner.Address.StateOrProvince = paymentInfo.BillingAddress.StateProvince.Abbreviation;
        //    else
        //        details.CreditCard.CardOwner.Address.StateOrProvince = "CA";
        //    details.CreditCard.CardOwner.Address.PostalCode = paymentInfo.BillingAddress.ZipPostalCode;
        //    details.CreditCard.CardOwner.Address.CountryName = paymentInfo.BillingAddress.Country.Name;
        //    details.CreditCard.CardOwner.Address.Country = GetPaypalCountryCodeType(paymentInfo.BillingAddress.Country);
        //    details.CreditCard.CardOwner.Address.CountrySpecified = true;
        //    details.CreditCard.CardOwner.Payer = paymentInfo.BillingAddress.Email;
        //    details.CreditCard.CardOwner.PayerName = new PersonNameType();
        //    details.CreditCard.CardOwner.PayerName.FirstName = paymentInfo.BillingAddress.FirstName;
        //    details.CreditCard.CardOwner.PayerName.LastName = paymentInfo.BillingAddress.LastName;
        //    details.PaymentDetails = new PaymentDetailsType();
        //    details.PaymentDetails.OrderTotal = new BasicAmountType();
        //    details.PaymentDetails.OrderTotal.Value = paymentInfo.OrderTotal.ToString("N", new CultureInfo("en-us"));
        //    details.PaymentDetails.OrderTotal.currencyID = PayPalHelper.GetPaypalCurrency("INR");
        //    details.PaymentDetails.Custom = orderGuid.ToString();

        //    if (paymentInfo.ShippingAddress != null)
        //    {
        //        if (paymentInfo.ShippingAddress.StateProvince != null && paymentInfo.ShippingAddress.Country != null)
        //        {
        //            AddressType shippingAddress = new AddressType();
        //            shippingAddress.Name = paymentInfo.ShippingAddress.FirstName + " " + paymentInfo.ShippingAddress.LastName;
        //            shippingAddress.Street1 = paymentInfo.ShippingAddress.Address1;
        //            shippingAddress.CityName = paymentInfo.ShippingAddress.City;
        //            shippingAddress.StateOrProvince = paymentInfo.ShippingAddress.StateProvince.Abbreviation;
        //            shippingAddress.PostalCode = paymentInfo.ShippingAddress.ZipPostalCode;
        //            shippingAddress.Country = (CountryCodeType)Enum.Parse(typeof(CountryCodeType), paymentInfo.ShippingAddress.Country.TwoLetterIsoCode, true);
        //            shippingAddress.CountrySpecified = true;
        //            details.PaymentDetails.ShipToAddress = shippingAddress;
        //        }
        //    }

        //    DoDirectPaymentResponseType response = new DoDirectPaymentResponseType();
        //    response = (DoDirectPaymentResponseType)caller.Call("DoDirectPayment", request);

        //    string error = string.Empty;
        //    bool Success = PayPalHelper.CheckSuccess(customer.LanguageId, response, out error);

        //    if (Success)
        //    {
        //        processPaymentResult.AVSResult = response.AVSCode;
        //        processPaymentResult.AuthorizationTransactionCode = response.CVV2Code;

        //        if (authorizeOnly)
        //        {
        //            processPaymentResult.AuthorizationTransactionId = response.TransactionID;
        //            processPaymentResult.AuthorizationTransactionResult = response.Ack.ToString();
        //            processPaymentResult.PaymentStatus = "Authorized";
        //        }
        //        else
        //        {
        //            processPaymentResult.CaptureTransactionId = response.TransactionID;
        //            processPaymentResult.CaptureTransactionResult = response.Ack.ToString();
        //            processPaymentResult.PaymentStatus = "Paid";
        //        }
        //    }
        //    else
        //    {
        //        processPaymentResult.Error = error;
        //        processPaymentResult.FullError = error;
        //    }
        //}


        public string DoDirectPaymentCode(string paymentAmount, string buyerLastName, 
                string buyerFirstName, string buyerAddress1, string buyerAddress2, 
                string buyerCity, string buyerState, string buyerZipCode, 
                string creditCardType, string creditCardNumber, string CVV2, int expMonth, int expYear)
        {
            CallerServices caller = new CallerServices();

            IAPIProfile profile = ProfileFactory.createSignatureAPIProfile();
            /*
             WARNING: Do not embed plaintext credentials in your application code.
             Doing so is insecure and against best practices.
             Your API credentials must be handled securely. Please consider
             encrypting them for use in any production environment, and ensure
             that only authorized individuals may view or modify them.
             */

            // Set up your API credentials, PayPal end point, and API version.
            profile.APIUsername = "ramrc0_1306615041_biz_api1.gmail.com";
            profile.APIPassword = "1306615058";
            profile.APISignature = "AtP7rLd7TBR7eGbquoauyoA.T0bXAEgVPCgWRJ7.pbYP9lvnEWI2G4k6";
            profile.Environment = "sandbox";

            caller.APIProfile = profile;
            // Create the request object.
            DoDirectPaymentRequestType pp_Request = new DoDirectPaymentRequestType();
            //DoDirectPaymentRequestDetailsType details = new DoDirectPaymentRequestDetailsType();
            pp_Request.Version = APIVersion;


            // Add request-specific fields to the request.
            // Create the request details object.
            pp_Request.DoDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();
            //details.IPAddress = HttpContext.Current.Request.UserHostAddress;
            //details.MerchantSessionId = "1X911810264059026";
            pp_Request.DoDirectPaymentRequestDetails.IPAddress = HttpContext.Current.Request.UserHostAddress;
            pp_Request.DoDirectPaymentRequestDetails.MerchantSessionId = "1X911810264059026";
            //details.PaymentAction = PaymentActionCodeType.Sale;
            pp_Request.DoDirectPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Sale;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard = new CreditCardDetailsType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardNumber = creditCardNumber;
            switch (creditCardType)
            {
                case "Visa":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Visa;
                    break;
                case "MasterCard":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.MasterCard;
                    break;
                case "Discover":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Discover;
                    break;
                case "Amex":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Amex;
                    break;
            }
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CVV2 = CVV2;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonth = expMonth;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonthSpecified = true;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYear = expYear;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYearSpecified = true;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner = new PayerInfoType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Payer = "";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerID = "";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerStatus = PayPalUserStatusCodeType.unverified;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerCountry = CountryCodeType.US;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address = new AddressType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = buyerAddress1;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = buyerAddress2;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = buyerCity;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.StateOrProvince = buyerState;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = buyerZipCode;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountryName = "INR";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Country = CountryCodeType.IN;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = true;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName = new PersonNameType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = buyerFirstName;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = buyerLastName;
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            // NOTE: The only currency supported by the Direct Payment API at this time is US dollars (USD).

            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.USD;
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = paymentAmount;

            // Execute the API operation and obtain the response.
            DoDirectPaymentResponseType pp_response = new DoDirectPaymentResponseType();
            pp_response = (DoDirectPaymentResponseType)caller.Call("DoDirectPayment", pp_Request);

            InsPayDetails(pp_response.TransactionID);

            return pp_response.Ack.ToString();

            //InitSettings();

            //DoDirectPaymentRequestType request = new DoDirectPaymentRequestType();
            //DoDirectPaymentRequestDetailsType details = new DoDirectPaymentRequestDetailsType();

            //request.Version = this.APIVersion;
            //request.DoDirectPaymentRequestDetails = details;
            //details.IPAddress = HttpContext.Current.Request.UserHostAddress;
            //details.MerchantSessionId = "1X911810264059026";

            ////if (authorizeOnly)
            //details.PaymentAction = PaymentActionCodeType.Sale;
            ////else
            ////    details.PaymentAction = PaymentActionCodeType.Sale;

            //details.CreditCard = new CreditCardDetailsType();
            //details.CreditCard.CreditCardTypeSpecified = true;
            //details.CreditCard.CreditCardNumber = creditCardNumber;
            //details.CreditCard.CreditCardType = CreditCardTypeType.Visa;
            //details.CreditCard.CVV2 = CVV2;
            //details.CreditCard.ExpMonth = expMonth;
            //details.CreditCard.ExpYear = expYear;
            //details.CreditCard.ExpMonthSpecified = true;
            //details.CreditCard.ExpYearSpecified = true;
            //details.CreditCard.CardOwner = new PayerInfoType();
            //details.CreditCard.CardOwner.Payer = "";
            //details.CreditCard.CardOwner.PayerID = "";
            //details.CreditCard.CardOwner.PayerStatus = PayPalUserStatusCodeType.unverified;
            //details.CreditCard.CardOwner.PayerCountry = CountryCodeType.US;

            //details.CreditCard.CardOwner.Address = new AddressType();
            //details.CreditCard.CardOwner.Address.CountrySpecified = true;
            //details.CreditCard.CardOwner.Address.Street1 = "Test Street1";
            //details.CreditCard.CardOwner.Address.Street2 = "Test Street2";
            //details.CreditCard.CardOwner.Address.CityName = "Test City";
            ////if (paymentInfo.BillingAddress.StateProvince != null)
            ////    details.CreditCard.CardOwner.Address.StateOrProvince = paymentInfo.BillingAddress.StateProvince.Abbreviation;
            ////else
            //    details.CreditCard.CardOwner.Address.StateOrProvince = "CA";
            //    details.CreditCard.CardOwner.Address.PostalCode = "560032";
            //    details.CreditCard.CardOwner.Address.CountryName = "US";
            //    details.CreditCard.CardOwner.Address.Country = CountryCodeType.US;
            //details.CreditCard.CardOwner.Address.CountrySpecified = true;
            //details.CreditCard.CardOwner.Payer = "ramrc007@gmail.com";
            //details.CreditCard.CardOwner.PayerName = new PersonNameType();
            //details.CreditCard.CardOwner.PayerName.FirstName = buyerFirstName;
            //details.CreditCard.CardOwner.PayerName.LastName = buyerLastName;
            //details.PaymentDetails = new PaymentDetailsType();
            //details.PaymentDetails.OrderTotal = new BasicAmountType();
            //details.PaymentDetails.OrderTotal.Value = paymentAmount;
            //details.PaymentDetails.OrderTotal.currencyID = PayPalHelper.GetPaypalCurrency("US");
            //details.PaymentDetails.Custom = Guid.NewGuid().ToString();

            ////if (paymentInfo.ShippingAddress != null)
            ////{
            ////    if (paymentInfo.ShippingAddress.StateProvince != null && paymentInfo.ShippingAddress.Country != null)
            ////    {
            //        AddressType shippingAddress = new AddressType();
            //        shippingAddress.Name = "Ramesh rc";
            //        shippingAddress.Street1 = "Test street";
            //        shippingAddress.CityName = "Test City";
            //        shippingAddress.StateOrProvince = "Karnadaka";
            //        shippingAddress.PostalCode = "560032";
            //        shippingAddress.Country = CountryCodeType.US;
            //        shippingAddress.CountrySpecified = true;
            //        details.PaymentDetails.ShipToAddress = shippingAddress;
            ////    }
            ////}

            //DoDirectPaymentResponseType response = new DoDirectPaymentResponseType();
            //response = (DoDirectPaymentResponseType)caller.Call("DoDirectPayment", request);
            //return response.Ack.ToString();

        }

        private void InsPayDetails(string TransactionID)
        {
            Lib.SubscriptionData.InsPayDetails(CurrentSession.CurrentUserID,Convert.ToInt32(CurrentSession.SubscriptionAmount), "Notes",
                            (int)Lib.Utils.SiteHelper.PaymentType.PayPal,
                            TransactionID, null, CurrentSession.Promocode, CurrentSession.AdDUserType, CurrentSession.AddID, CurrentSession.DtExpDate);
        }
    
        #endregion
    }
}
