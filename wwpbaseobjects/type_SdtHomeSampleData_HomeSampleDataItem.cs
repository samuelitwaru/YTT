/*
				   File: type_SdtHomeSampleData_HomeSampleDataItem
			Description: HomeSampleData
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="HomeSampleDataItem")]
	[XmlType(TypeName="HomeSampleDataItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtHomeSampleData_HomeSampleDataItem : GxUserType
	{
		public SdtHomeSampleData_HomeSampleDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtHomeSampleData_HomeSampleDataItem_Productname = "";

		}

		public SdtHomeSampleData_HomeSampleDataItem(IGxContext context)
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
			AddObjectProperty("ProductName", gxTpr_Productname, false);


			AddObjectProperty("ProductPrice", gxTpr_Productprice, false);


			AddObjectProperty("ProductWeight", gxTpr_Productweight, false);


			AddObjectProperty("ProductVolume", gxTpr_Productvolume, false);


			AddObjectProperty("ProductDiscount", gxTpr_Productdiscount, false);


			AddObjectProperty("ProductStatus", gxTpr_Productstatus, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductName")]
		[XmlElement(ElementName="ProductName")]
		public string gxTpr_Productname
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productname; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productname = value;
				SetDirty("Productname");
			}
		}



		[SoapElement(ElementName="ProductPrice")]
		[XmlElement(ElementName="ProductPrice")]
		public string gxTpr_Productprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtHomeSampleData_HomeSampleDataItem_Productprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Productprice
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productprice; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productprice = value;
				SetDirty("Productprice");
			}
		}



		[SoapElement(ElementName="ProductWeight")]
		[XmlElement(ElementName="ProductWeight")]
		public string gxTpr_Productweight_double
		{
			get {
				return Convert.ToString(gxTv_SdtHomeSampleData_HomeSampleDataItem_Productweight, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productweight = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Productweight
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productweight; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productweight = value;
				SetDirty("Productweight");
			}
		}



		[SoapElement(ElementName="ProductVolume")]
		[XmlElement(ElementName="ProductVolume")]
		public string gxTpr_Productvolume_double
		{
			get {
				return Convert.ToString(gxTv_SdtHomeSampleData_HomeSampleDataItem_Productvolume, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productvolume = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Productvolume
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productvolume; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productvolume = value;
				SetDirty("Productvolume");
			}
		}



		[SoapElement(ElementName="ProductDiscount")]
		[XmlElement(ElementName="ProductDiscount")]
		public string gxTpr_Productdiscount_double
		{
			get {
				return Convert.ToString(gxTv_SdtHomeSampleData_HomeSampleDataItem_Productdiscount, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productdiscount = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Productdiscount
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productdiscount; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productdiscount = value;
				SetDirty("Productdiscount");
			}
		}




		[SoapElement(ElementName="ProductStatus")]
		[XmlElement(ElementName="ProductStatus")]
		public short gxTpr_Productstatus
		{
			get {
				return gxTv_SdtHomeSampleData_HomeSampleDataItem_Productstatus; 
			}
			set {
				gxTv_SdtHomeSampleData_HomeSampleDataItem_Productstatus = value;
				SetDirty("Productstatus");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtHomeSampleData_HomeSampleDataItem_Productname = "";





			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtHomeSampleData_HomeSampleDataItem_Productname;
		 

		protected decimal gxTv_SdtHomeSampleData_HomeSampleDataItem_Productprice;
		 

		protected decimal gxTv_SdtHomeSampleData_HomeSampleDataItem_Productweight;
		 

		protected decimal gxTv_SdtHomeSampleData_HomeSampleDataItem_Productvolume;
		 

		protected decimal gxTv_SdtHomeSampleData_HomeSampleDataItem_Productdiscount;
		 

		protected short gxTv_SdtHomeSampleData_HomeSampleDataItem_Productstatus;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"HomeSampleDataItem", Namespace="YTT_version4")]
	public class SdtHomeSampleData_HomeSampleDataItem_RESTInterface : GxGenericCollectionItem<SdtHomeSampleData_HomeSampleDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtHomeSampleData_HomeSampleDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtHomeSampleData_HomeSampleDataItem_RESTInterface( SdtHomeSampleData_HomeSampleDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductName", Order=0)]
		public  string gxTpr_Productname
		{
			get { 
				return sdt.gxTpr_Productname;

			}
			set { 
				 sdt.gxTpr_Productname = value;
			}
		}

		[DataMember(Name="ProductPrice", Order=1)]
		public  string gxTpr_Productprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Productprice, 8, 1));

			}
			set { 
				sdt.gxTpr_Productprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductWeight", Order=2)]
		public  string gxTpr_Productweight
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Productweight, 8, 1));

			}
			set { 
				sdt.gxTpr_Productweight =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductVolume", Order=3)]
		public  string gxTpr_Productvolume
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Productvolume, 8, 1));

			}
			set { 
				sdt.gxTpr_Productvolume =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductDiscount", Order=4)]
		public decimal gxTpr_Productdiscount
		{
			get { 
				return sdt.gxTpr_Productdiscount;

			}
			set { 
				sdt.gxTpr_Productdiscount = value;
			}
		}

		[DataMember(Name="ProductStatus", Order=5)]
		public short gxTpr_Productstatus
		{
			get { 
				return sdt.gxTpr_Productstatus;

			}
			set { 
				sdt.gxTpr_Productstatus = value;
			}
		}


		#endregion

		public SdtHomeSampleData_HomeSampleDataItem sdt
		{
			get { 
				return (SdtHomeSampleData_HomeSampleDataItem)Sdt;
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
				sdt = new SdtHomeSampleData_HomeSampleDataItem() ;
			}
		}
	}
	#endregion
}