using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CornerSites.Lib.Data
{
    public class ObjectInterFace
    {
        //public interface ItblResidentialPropertyAd
        //{
        //    public int ResidentialAdID
        //    {
        //        get
        //        {
        //            return this._ResidentialAdID;
        //        }
        //        set
        //        {

        //            this._ResidentialAdID = value;

        //        }
        //    }
        //    private int _ResidentialAdID;

        //    public string AdHeader
        //    {
        //        get
        //        {
        //            return this._AdHeader;
        //        }
        //        set
        //        {
                    
        //            this._AdHeader = value
        //        }
        //    }
        //    private string _AdHeader;

        //    public string LeaseType
        //    {
        //        get
        //        {
        //            return this._LeaseType;
        //        }
        //        set
        //        {
        //            this._LeaseType = value
        //        }
        //    }
        //    private string _LeaseType;

        //    public global::System.Nullable<short> AreaID
        //    {
        //        get
        //        {
        //            return this._AreaID;
        //        }
        //        set
        //        {
        //            this._AreaID = value
        //        }
        //    }
        //    private global::System.Nullable<short> _AreaID;

        //    public string AdressLine
        //    {
        //        get
        //        {
        //            return this._AdressLine;
        //        }
        //        set
        //        {
        //            this._AdressLine = value
        //        }
        //    }
        //    private string _AdressLine;

        //    public string Pincode
        //    {
        //        get
        //        {
        //            return this._Pincode;
        //        }
        //        set
        //        {
        //            this._Pincode = value
        //        }
        //    }
        //    private string _Pincode;

            
        //    public string LandMark
        //    {
        //        get
        //        {
        //            return this._LandMark;
        //        }
        //        set
        //        {
        //            this._LandMark = value
        //        }
        //    }
        //    private string _LandMark;

        //    public global::System.Nullable<int> PropertyPrice
        //    {
        //        get
        //        {
        //            return this._PropertyPrice;
        //        }
        //        set
        //        {
        //            this._PropertyPrice = value;
        //        }
        //    }
        //    private global::System.Nullable<int> _PropertyPrice;

        //    public string PropertyDescription
        //    {
        //        get
        //        {
        //            return this._PropertyDescription;
        //        }
        //        set
        //        {
        //            this._PropertyDescription = value
        //        }
        //    }
        //    private string _PropertyDescription;

        //    public global::System.Nullable<byte> BedRooms
        //    {
        //        get
        //        {
        //            return this._BedRooms;
        //        }
        //        set
        //        {
        //            this._BedRooms = value;
        //        }
        //    }
        //    private global::System.Nullable<byte> _BedRooms;

        //    public global::System.Nullable<byte> BathRooms
        //    {
        //        get
        //        {
        //            return this._BathRooms;
        //        }
        //        set
        //        {
        //            this._BathRooms = value;
        //        }
        //    }
        //    private global::System.Nullable<byte> _BathRooms;

        //    public global::System.Nullable<byte> Balcony
        //    {
        //        get
        //        {
        //            return this._Balcony;
        //        }
        //        set
        //        {
        //            this._Balcony = value;
        //        }
        //    }
        //    private global::System.Nullable<byte> _Balcony;

        //    public global::System.Nullable<int> PlotArea
        //    {
        //        get
        //        {
        //            return this._PlotArea;
        //        }
        //        set
        //        {
        //            this._PlotArea = value;
        //        }
        //    }
        //    private global::System.Nullable<int> _PlotArea;

        //    public global::System.Nullable<int> BuildArea
        //    {
        //        get
        //        {
        //            return this._BuildArea;
        //        }
        //        set
        //        {
        //            this._BuildArea = value;
        //        }
        //    }
        //    private global::System.Nullable<int> _BuildArea;

        //    public string PropertyImage1
        //    {
        //        get
        //        {
        //            return this._PropertyImage1;
        //        }
        //        set
        //        {
        //            this._PropertyImage1 = value
        //        }
        //    }
        //    private string _PropertyImage1;

        //    public string PropertyImage2
        //    {
        //        get
        //        {
        //            return this._PropertyImage2;
        //        }
        //        set
        //        {
        //            this._PropertyImage2 = value
        //        }
        //    }
        //    private string _PropertyImage2;

        //    public global::System.Nullable<global::System.DateTime> AdExpiryDate
        //    {
        //        get
        //        {
        //            return this._AdExpiryDate;
        //        }
        //        set
        //        {
        //            this._AdExpiryDate = value;
        //        }
        //    }
        //    private global::System.Nullable<global::System.DateTime> _AdExpiryDate;

        //    public global::System.Nullable<bool> PriceNegotiableFlag
        //    {
        //        get
        //        {
        //            return this._PriceNegotiableFlag;
        //        }
        //        set
        //        {
        //            this._PriceNegotiableFlag = value;
        //        }
        //    }
        //    private global::System.Nullable<bool> _PriceNegotiableFlag;

        //    partial void OnPriceNegotiableFlagChanging(global::System.Nullable<bool> value);
        //    partial void OnPriceNegotiableFlagChanged();

        //    public global::System.Nullable<byte> FloorNumber
        //    {
        //        get
        //        {
        //            return this._FloorNumber;
        //        }
        //        set
        //        {
        //            this._FloorNumber = value
        //        }
        //    }
        //    private global::System.Nullable<byte> _FloorNumber;

        //    public global::System.Nullable<byte> TotalFloors
        //    {
        //        get
        //        {
        //            return this._TotalFloors;
        //        }
        //        set
        //        {
        //            this._TotalFloors = value
        //        }
        //    }
        //    private global::System.Nullable<byte> _TotalFloors;

        //    public string DuesToPay
        //    {
        //        get
        //        {
        //            return this._DuesToPay;
        //        }
        //        set
        //        {
        //            this._DuesToPay = value
        //        }
        //    }
        //    private string _DuesToPay;

        //    public string TandC
        //    {
        //        get
        //        {
        //            return this._TandC;
        //        }
        //        set
        //        {
        //            this._TandC = value
        //        }
        //    }
        //    private string _TandC;
        //}
    }
}
