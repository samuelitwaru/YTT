/*
				   File: type_SdtSDTRow_SDTRowItem
			Description: SDTRow
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


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDTRowItem")]
	[XmlType(TypeName="SDTRowItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTRow_SDTRowItem : GxUserType
	{
		public SdtSDTRow_SDTRowItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRow_SDTRowItem_Value = "";

		}

		public SdtSDTRow_SDTRowItem(IGxContext context)
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
			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtSDTRow_SDTRowItem_Value; 
			}
			set {
				gxTv_SdtSDTRow_SDTRowItem_Value = value;
				SetDirty("Value");
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
			gxTv_SdtSDTRow_SDTRowItem_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRow_SDTRowItem_Value;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTRowItem", Namespace="YTT_version4")]
	public class SdtSDTRow_SDTRowItem_RESTInterface : GxGenericCollectionItem<SdtSDTRow_SDTRowItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRow_SDTRowItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRow_SDTRowItem_RESTInterface( SdtSDTRow_SDTRowItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Value", Order=0)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}


		#endregion

		public SdtSDTRow_SDTRowItem sdt
		{
			get { 
				return (SdtSDTRow_SDTRowItem)Sdt;
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
				sdt = new SdtSDTRow_SDTRowItem() ;
			}
		}
	}
	#endregion
}