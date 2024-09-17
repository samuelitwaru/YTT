/*
				   File: type_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem
			Description: HomeSampleNameValueData
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
	[XmlRoot(ElementName="HomeSampleNameValueDataItem")]
	[XmlType(TypeName="HomeSampleNameValueDataItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtHomeSampleNameValueData_HomeSampleNameValueDataItem : GxUserType
	{
		public SdtHomeSampleNameValueData_HomeSampleNameValueDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Name = "";

		}

		public SdtHomeSampleNameValueData_HomeSampleNameValueDataItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Check", gxTpr_Check, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Name; 
			}
			set {
				gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value_double
		{
			get {
				return Convert.ToString(gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Value, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Value = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Value
		{
			get {
				return gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Value; 
			}
			set {
				gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Check")]
		[XmlElement(ElementName="Check")]
		public bool gxTpr_Check
		{
			get {
				return gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Check; 
			}
			set {
				gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Check = value;
				SetDirty("Check");
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
			gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Name = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Name;
		 

		protected decimal gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Value;
		 

		protected bool gxTv_SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_Check;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"HomeSampleNameValueDataItem", Namespace="YTT_version4")]
	public class SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_RESTInterface : GxGenericCollectionItem<SdtHomeSampleNameValueData_HomeSampleNameValueDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtHomeSampleNameValueData_HomeSampleNameValueDataItem_RESTInterface( SdtHomeSampleNameValueData_HomeSampleNameValueDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Value, 8, 1));

			}
			set { 
				sdt.gxTpr_Value =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Check", Order=2)]
		public bool gxTpr_Check
		{
			get { 
				return sdt.gxTpr_Check;

			}
			set { 
				sdt.gxTpr_Check = value;
			}
		}


		#endregion

		public SdtHomeSampleNameValueData_HomeSampleNameValueDataItem sdt
		{
			get { 
				return (SdtHomeSampleNameValueData_HomeSampleNameValueDataItem)Sdt;
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
				sdt = new SdtHomeSampleNameValueData_HomeSampleNameValueDataItem() ;
			}
		}
	}
	#endregion
}