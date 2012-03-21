using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.XPath;

namespace CornerSites.Lib.Utils
{
    public class SiteHelper
    {
        public static DropDownList BindDropDownValues<T>(DropDownList Objddl, List<T> objList, string PrefixText)
        {
            Objddl.DataSource = objList;

            if (!string.IsNullOrEmpty(PrefixText))
                Objddl.Items.Add(new ListItem(PrefixText, "-1"));

            return Objddl;
        }

        public static DropDownList BindDropDownPrefixvalue(DropDownList Objddl, string PrefixText)
        {
            Objddl.Items.Add(new ListItem(PrefixText, "-1"));
            return Objddl;
        }

        public static string ReturnDropDownselectedItemValue(Control objcnt, string ConrolID)
        {
            if (objcnt == null)
                return string.Empty;
            if (((DropDownList)objcnt.FindControl(ConrolID)) == null)
                return string.Empty;
            return ((DropDownList)objcnt.FindControl(ConrolID)).SelectedValue;
        }

        public static string ReturnTextBoxValue(Control objcnt, string ConrolID)
        {
            if (objcnt == null)
                return string.Empty;
            if (((TextBox)objcnt.FindControl(ConrolID)) == null)
                return string.Empty;
            return ((TextBox)objcnt.FindControl(ConrolID)).Text;
        }

        public enum PROPERTYTYPE
        {
            ResidentialHouseVilla = 1,
            ResidentialPlot = 2,
            HolidayHome = 3,
            ResidentialApartment = 4,
            BuilderFloorApartment = 5,
            ServicedApartment = 6,
            StudioApartment = 7,
            NewResidentialProjects = 8,
            AgriculturalLand = 9,
            FarmHouse = 10,
            CommercialIndustrialland = 11,
            CommercialOfficeSpace = 12,
            CommercialShowroom = 13,
            CommercialShop = 14,
            Kiosk = 15,
            ResortsHotel = 16,
            GuestHouse = 17,
            PayingGuest = 18,
            GodownWareHouse = 19,
            BusinessCentre = 20,
            Factory = 21,
            IndustrialBuilding = 22,
            NewCommercialProjects = 23
        }

        public enum PaymentType
        {
            CreditCard =1 ,
            PayPal = 2
        }

        public static string EncryptPassword(string toEncrypt, bool useHashing, string Key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            //string key = (string)settingsReader.GetValue(Key,typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
            cTransform.TransformFinalBlock(toEncryptArray, 0,
            toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptPassword(string cipherString, bool useHashing, string Key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue(Key, typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static Hashtable SearchParams
        {
            get { return ((HttpContext.Current.Session["SearchParams"] == null) ? null : (Hashtable)HttpContext.Current.Session["SearchParams"]); }
            set { HttpContext.Current.Session["SearchParams"] = value; }
        }

        public static string GetStringSearchParams(Hashtable ObjHashTable, string Key)
        {
            string Return = string.Empty;
            if (ObjHashTable != null && ObjHashTable[Key] != null)
            {
                if (!string.IsNullOrEmpty(ObjHashTable[Key].ToString()))
                {
                    Return = ObjHashTable[Key].ToString();
                }
            }
            return Return;
        }
        public static char GetCharSearchParams(Hashtable ObjHashTable, string Key)
        {
            char Return = char.MinValue;
            if (ObjHashTable != null && ObjHashTable[Key] != null)
            {
                if (!string.IsNullOrEmpty(ObjHashTable[Key].ToString()))
                {
                    Return = char.Parse(ObjHashTable[Key].ToString());
                }
            }
            return Return;
        }

        public static byte? GetByteSearchParams(Hashtable ObjHashTable, string Key)
        {
            byte? Return = null;
            if (ObjHashTable != null && ObjHashTable[Key] != null)
            {
                if (!string.IsNullOrEmpty(ObjHashTable[Key].ToString()))
                {
                    if (ObjHashTable[Key].ToString() != "-1")
                        Return = byte.Parse(ObjHashTable[Key].ToString());
                }
            }
            return Return;
        }

        public static short? GetShortSearchParams(Hashtable ObjHashTable, string Key)
        {
            short? Return = null;
            if (ObjHashTable != null && ObjHashTable[Key] != null)
            {
                if (!string.IsNullOrEmpty(ObjHashTable[Key].ToString()))
                {
                    if (ObjHashTable[Key].ToString() != "-1")
                        Return = short.Parse(ObjHashTable[Key].ToString());
                }
            }
            return Return;
        }


        public static int? GetIntSearchParams(Hashtable ObjHashTable, string Key)
        {
            int? Return = null;
            if (ObjHashTable != null && ObjHashTable[Key] != null)
            {
                if (!string.IsNullOrEmpty(ObjHashTable[Key].ToString()))
                {
                    if (ObjHashTable[Key].ToString() != "-1")
                        Return = int.Parse(ObjHashTable[Key].ToString());
                }
            }
            return Return;
        }

        public static void OpenConnection(SqlConnection con)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void CloseConnection(SqlConnection con)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }
        }

        public static string XsltTransform(string xml, string filePath)
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            // load xslt to do transformation

            XslTransform xsl = new XslTransform();
            xsl.Load(filePath);

            XsltArgumentList xslarg = new XsltArgumentList();
            xslarg.AddParam("pageid", "", 1);


            StringWriter sw = new StringWriter();
            xsl.Transform(xdoc, xslarg, sw);
            string result = sw.ToString().Replace("xmlns:asp=\"remove\"",
                     "").Replace("&lt;", "<").Replace("&gt;", ">");
            // free up the memory of objects that are not used anymore

            sw.Close();
            return result;
        }
               
    }
}
