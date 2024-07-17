using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "LeaveRequest.Holidays" )]
   [XmlType(TypeName =  "LeaveRequest.Holidays" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtLeaveRequest_Holidays : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtLeaveRequest_Holidays( )
      {
      }

      public SdtLeaveRequest_Holidays( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"HolidayId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Holidays");
         metadata.Set("BT", "LeaveRequestHolidays");
         metadata.Set("PK", "[ \"HolidayId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"HolidayId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"LeaveRequestId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Holidayid_Z");
         state.Add("gxTpr_Holidayname_Z");
         state.Add("gxTpr_Holidaystartdate_Z_Nullable");
         state.Add("gxTpr_Isapplicable_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLeaveRequest_Holidays sdt;
         sdt = (SdtLeaveRequest_Holidays)(source);
         gxTv_SdtLeaveRequest_Holidays_Holidayid = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayid ;
         gxTv_SdtLeaveRequest_Holidays_Holidayname = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayname ;
         gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = sdt.gxTv_SdtLeaveRequest_Holidays_Holidaystartdate ;
         gxTv_SdtLeaveRequest_Holidays_Isapplicable = sdt.gxTv_SdtLeaveRequest_Holidays_Isapplicable ;
         gxTv_SdtLeaveRequest_Holidays_Mode = sdt.gxTv_SdtLeaveRequest_Holidays_Mode ;
         gxTv_SdtLeaveRequest_Holidays_Modified = sdt.gxTv_SdtLeaveRequest_Holidays_Modified ;
         gxTv_SdtLeaveRequest_Holidays_Initialized = sdt.gxTv_SdtLeaveRequest_Holidays_Initialized ;
         gxTv_SdtLeaveRequest_Holidays_Holidayid_Z = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayid_Z ;
         gxTv_SdtLeaveRequest_Holidays_Holidayname_Z = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayname_Z ;
         gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = sdt.gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z ;
         gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z = sdt.gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("HolidayId", gxTv_SdtLeaveRequest_Holidays_Holidayid, false, includeNonInitialized);
         AddObjectProperty("HolidayName", gxTv_SdtLeaveRequest_Holidays_Holidayname, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("HolidayStartDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("IsApplicable", gxTv_SdtLeaveRequest_Holidays_Isapplicable, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLeaveRequest_Holidays_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtLeaveRequest_Holidays_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLeaveRequest_Holidays_Initialized, false, includeNonInitialized);
            AddObjectProperty("HolidayId_Z", gxTv_SdtLeaveRequest_Holidays_Holidayid_Z, false, includeNonInitialized);
            AddObjectProperty("HolidayName_Z", gxTv_SdtLeaveRequest_Holidays_Holidayname_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("HolidayStartDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("IsApplicable_Z", gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLeaveRequest_Holidays sdt )
      {
         if ( sdt.IsDirty("HolidayId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayid = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayid ;
         }
         if ( sdt.IsDirty("HolidayName") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayname = sdt.gxTv_SdtLeaveRequest_Holidays_Holidayname ;
         }
         if ( sdt.IsDirty("HolidayStartDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = sdt.gxTv_SdtLeaveRequest_Holidays_Holidaystartdate ;
         }
         if ( sdt.IsDirty("IsApplicable") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Isapplicable = sdt.gxTv_SdtLeaveRequest_Holidays_Isapplicable ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "HolidayId" )]
      [  XmlElement( ElementName = "HolidayId"   )]
      public long gxTpr_Holidayid
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidayid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayid = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidayid");
         }

      }

      [  SoapElement( ElementName = "HolidayName" )]
      [  XmlElement( ElementName = "HolidayName"   )]
      public string gxTpr_Holidayname
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidayname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayname = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidayname");
         }

      }

      [  SoapElement( ElementName = "HolidayStartDate" )]
      [  XmlElement( ElementName = "HolidayStartDate"  , IsNullable=true )]
      public string gxTpr_Holidaystartdate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Holidays_Holidaystartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = DateTime.Parse( value);
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Holidaystartdate
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidaystartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidaystartdate");
         }

      }

      [  SoapElement( ElementName = "IsApplicable" )]
      [  XmlElement( ElementName = "IsApplicable"   )]
      public bool gxTpr_Isapplicable
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Isapplicable ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Isapplicable = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Isapplicable");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Mode_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Modified_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Initialized = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Initialized_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HolidayId_Z" )]
      [  XmlElement( ElementName = "HolidayId_Z"   )]
      public long gxTpr_Holidayid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidayid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayid_Z = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidayid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Holidayid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Holidayid_Z = 0;
         SetDirty("Holidayid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Holidayid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HolidayName_Z" )]
      [  XmlElement( ElementName = "HolidayName_Z"   )]
      public string gxTpr_Holidayname_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidayname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidayname_Z = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidayname_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Holidayname_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Holidayname_Z = "";
         SetDirty("Holidayname_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Holidayname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HolidayStartDate_Z" )]
      [  XmlElement( ElementName = "HolidayStartDate_Z"  , IsNullable=true )]
      public string gxTpr_Holidaystartdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = DateTime.Parse( value);
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Holidaystartdate_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Holidaystartdate_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Holidaystartdate_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IsApplicable_Z" )]
      [  XmlElement( ElementName = "IsApplicable_Z"   )]
      public bool gxTpr_Isapplicable_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z = value;
            gxTv_SdtLeaveRequest_Holidays_Modified = 1;
            SetDirty("Isapplicable_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z = false;
         SetDirty("Isapplicable_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtLeaveRequest_Holidays_Holidayname = "";
         gxTv_SdtLeaveRequest_Holidays_Holidaystartdate = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Holidays_Mode = "";
         gxTv_SdtLeaveRequest_Holidays_Holidayname_Z = "";
         gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtLeaveRequest_Holidays_Modified ;
      private short gxTv_SdtLeaveRequest_Holidays_Initialized ;
      private long gxTv_SdtLeaveRequest_Holidays_Holidayid ;
      private long gxTv_SdtLeaveRequest_Holidays_Holidayid_Z ;
      private string gxTv_SdtLeaveRequest_Holidays_Holidayname ;
      private string gxTv_SdtLeaveRequest_Holidays_Mode ;
      private string gxTv_SdtLeaveRequest_Holidays_Holidayname_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtLeaveRequest_Holidays_Holidaystartdate ;
      private DateTime gxTv_SdtLeaveRequest_Holidays_Holidaystartdate_Z ;
      private bool gxTv_SdtLeaveRequest_Holidays_Isapplicable ;
      private bool gxTv_SdtLeaveRequest_Holidays_Isapplicable_Z ;
   }

   [DataContract(Name = @"LeaveRequest.Holidays", Namespace = "YTT_version4")]
   public class SdtLeaveRequest_Holidays_RESTInterface : GxGenericCollectionItem<SdtLeaveRequest_Holidays>
   {
      public SdtLeaveRequest_Holidays_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequest_Holidays_RESTInterface( SdtLeaveRequest_Holidays psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "HolidayId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Holidayid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Holidayid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Holidayid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "HolidayName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Holidayname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Holidayname) ;
         }

         set {
            sdt.gxTpr_Holidayname = value;
         }

      }

      [DataMember( Name = "HolidayStartDate" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Holidaystartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Holidaystartdate) ;
         }

         set {
            sdt.gxTpr_Holidaystartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "IsApplicable" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Isapplicable
      {
         get {
            return sdt.gxTpr_Isapplicable ;
         }

         set {
            sdt.gxTpr_Isapplicable = value;
         }

      }

      public SdtLeaveRequest_Holidays sdt
      {
         get {
            return (SdtLeaveRequest_Holidays)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLeaveRequest_Holidays() ;
         }
      }

   }

   [DataContract(Name = @"LeaveRequest.Holidays", Namespace = "YTT_version4")]
   public class SdtLeaveRequest_Holidays_RESTLInterface : GxGenericCollectionItem<SdtLeaveRequest_Holidays>
   {
      public SdtLeaveRequest_Holidays_RESTLInterface( ) : base()
      {
      }

      public SdtLeaveRequest_Holidays_RESTLInterface( SdtLeaveRequest_Holidays psdt ) : base(psdt)
      {
      }

      public SdtLeaveRequest_Holidays sdt
      {
         get {
            return (SdtLeaveRequest_Holidays)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLeaveRequest_Holidays() ;
         }
      }

   }

}
