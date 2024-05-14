/*
				   File: type_SdtLocationHolidaysSDT
			Description: LocationHolidaysSDT
				 Author: Nemo 🐠 for C# (.NET) version 18.0.6.177934
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="LocationHolidaysSDT")]
	[XmlType(TypeName="LocationHolidaysSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHolidaysSDT : GxUserType
	{
		public SdtLocationHolidaysSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHolidaysSDT_Kind = "";

			gxTv_SdtLocationHolidaysSDT_Etag = "";

			gxTv_SdtLocationHolidaysSDT_Summary = "";

			gxTv_SdtLocationHolidaysSDT_Description = "";

			gxTv_SdtLocationHolidaysSDT_Updated = (DateTime)(DateTime.MinValue);

			gxTv_SdtLocationHolidaysSDT_Timezone = "";

			gxTv_SdtLocationHolidaysSDT_Accessrole = "";

			gxTv_SdtLocationHolidaysSDT_Nextsynctoken = "";

		}

		public SdtLocationHolidaysSDT(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("kind", gxTpr_Kind, false);


			AddObjectProperty("etag", gxTpr_Etag, false);


			AddObjectProperty("summary", gxTpr_Summary, false);


			AddObjectProperty("description", gxTpr_Description, false);


			datetime_STZ = gxTpr_Updated;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("updated", sDateCnv, false);



			AddObjectProperty("timeZone", gxTpr_Timezone, false);


			AddObjectProperty("accessRole", gxTpr_Accessrole, false);


			AddObjectProperty("nextSyncToken", gxTpr_Nextsynctoken, false);

			if (gxTv_SdtLocationHolidaysSDT_Items != null)
			{
				AddObjectProperty("items", gxTv_SdtLocationHolidaysSDT_Items, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="kind")]
		[XmlElement(ElementName="kind")]
		public string gxTpr_Kind
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Kind; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Kind = value;
				SetDirty("Kind");
			}
		}




		[SoapElement(ElementName="etag")]
		[XmlElement(ElementName="etag")]
		public string gxTpr_Etag
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Etag; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Etag = value;
				SetDirty("Etag");
			}
		}




		[SoapElement(ElementName="summary")]
		[XmlElement(ElementName="summary")]
		public string gxTpr_Summary
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Summary; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Summary = value;
				SetDirty("Summary");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Description; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Description = value;
				SetDirty("Description");
			}
		}



		[SoapElement(ElementName="updated")]
		[XmlElement(ElementName="updated" , IsNullable=true)]
		public string gxTpr_Updated_Nullable
		{
			get {
				if ( gxTv_SdtLocationHolidaysSDT_Updated == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtLocationHolidaysSDT_Updated).value ;
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Updated = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Updated
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Updated; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Updated = value;
				SetDirty("Updated");
			}
		}



		[SoapElement(ElementName="timeZone")]
		[XmlElement(ElementName="timeZone")]
		public string gxTpr_Timezone
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Timezone; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Timezone = value;
				SetDirty("Timezone");
			}
		}




		[SoapElement(ElementName="accessRole")]
		[XmlElement(ElementName="accessRole")]
		public string gxTpr_Accessrole
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Accessrole; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Accessrole = value;
				SetDirty("Accessrole");
			}
		}




		[SoapElement(ElementName="nextSyncToken")]
		[XmlElement(ElementName="nextSyncToken")]
		public string gxTpr_Nextsynctoken
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_Nextsynctoken; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Nextsynctoken = value;
				SetDirty("Nextsynctoken");
			}
		}




		[SoapElement(ElementName="items" )]
		[XmlArray(ElementName="items"  )]
		[XmlArrayItemAttribute(ElementName="itemsItem" , IsNullable=false )]
		public GXBaseCollection<SdtLocationHolidaysSDT_itemsItem> gxTpr_Items
		{
			get {
				if ( gxTv_SdtLocationHolidaysSDT_Items == null )
				{
					gxTv_SdtLocationHolidaysSDT_Items = new GXBaseCollection<SdtLocationHolidaysSDT_itemsItem>( context, "LocationHolidaysSDT.itemsItem", "");
				}
				return gxTv_SdtLocationHolidaysSDT_Items;
			}
			set {
				gxTv_SdtLocationHolidaysSDT_Items_N = false;
				gxTv_SdtLocationHolidaysSDT_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtLocationHolidaysSDT_Items_SetNull()
		{
			gxTv_SdtLocationHolidaysSDT_Items_N = true;
			gxTv_SdtLocationHolidaysSDT_Items = null;
		}

		public bool gxTv_SdtLocationHolidaysSDT_Items_IsNull()
		{
			return gxTv_SdtLocationHolidaysSDT_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GxSimpleCollection_Json()
		{
			return gxTv_SdtLocationHolidaysSDT_Items != null && gxTv_SdtLocationHolidaysSDT_Items.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtLocationHolidaysSDT_Kind = "";
			gxTv_SdtLocationHolidaysSDT_Etag = "";
			gxTv_SdtLocationHolidaysSDT_Summary = "";
			gxTv_SdtLocationHolidaysSDT_Description = "";
			gxTv_SdtLocationHolidaysSDT_Updated = (DateTime)(DateTime.MinValue);
			gxTv_SdtLocationHolidaysSDT_Timezone = "";
			gxTv_SdtLocationHolidaysSDT_Accessrole = "";
			gxTv_SdtLocationHolidaysSDT_Nextsynctoken = "";

			gxTv_SdtLocationHolidaysSDT_Items_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtLocationHolidaysSDT_Kind;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Etag;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Summary;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Description;
		 

		protected DateTime gxTv_SdtLocationHolidaysSDT_Updated;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Timezone;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Accessrole;
		 

		protected string gxTv_SdtLocationHolidaysSDT_Nextsynctoken;
		 
		protected bool gxTv_SdtLocationHolidaysSDT_Items_N;
		protected GXBaseCollection<SdtLocationHolidaysSDT_itemsItem> gxTv_SdtLocationHolidaysSDT_Items = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"LocationHolidaysSDT", Namespace="YTT_version4")]
	public class SdtLocationHolidaysSDT_RESTInterface : GxGenericCollectionItem<SdtLocationHolidaysSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHolidaysSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHolidaysSDT_RESTInterface( SdtLocationHolidaysSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="kind", Order=0)]
		public  string gxTpr_Kind
		{
			get { 
				return sdt.gxTpr_Kind;

			}
			set { 
				 sdt.gxTpr_Kind = value;
			}
		}

		[DataMember(Name="etag", Order=1)]
		public  string gxTpr_Etag
		{
			get { 
				return sdt.gxTpr_Etag;

			}
			set { 
				 sdt.gxTpr_Etag = value;
			}
		}

		[DataMember(Name="summary", Order=2)]
		public  string gxTpr_Summary
		{
			get { 
				return sdt.gxTpr_Summary;

			}
			set { 
				 sdt.gxTpr_Summary = value;
			}
		}

		[DataMember(Name="description", Order=3)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="updated", Order=4)]
		public  string gxTpr_Updated
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Updated);

			}
			set { 
				sdt.gxTpr_Updated = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="timeZone", Order=5)]
		public  string gxTpr_Timezone
		{
			get { 
				return sdt.gxTpr_Timezone;

			}
			set { 
				 sdt.gxTpr_Timezone = value;
			}
		}

		[DataMember(Name="accessRole", Order=6)]
		public  string gxTpr_Accessrole
		{
			get { 
				return sdt.gxTpr_Accessrole;

			}
			set { 
				 sdt.gxTpr_Accessrole = value;
			}
		}

		[DataMember(Name="nextSyncToken", Order=7)]
		public  string gxTpr_Nextsynctoken
		{
			get { 
				return sdt.gxTpr_Nextsynctoken;

			}
			set { 
				 sdt.gxTpr_Nextsynctoken = value;
			}
		}

		[DataMember(Name="items", Order=8, EmitDefaultValue=false)]
		public GxGenericCollection<SdtLocationHolidaysSDT_itemsItem_RESTInterface> gxTpr_Items
		{
			get {
				if (sdt.ShouldSerializegxTpr_Items_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtLocationHolidaysSDT_itemsItem_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}


		#endregion

		public SdtLocationHolidaysSDT sdt
		{
			get { 
				return (SdtLocationHolidaysSDT)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtLocationHolidaysSDT() ;
			}
		}
	}
	#endregion
}