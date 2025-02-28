/*
				   File: type_SdtSDT_Example
			Description: SDT_Example
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
	[XmlRoot(ElementName="SDT_Example")]
	[XmlType(TypeName="SDT_Example" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_Example : GxUserType
	{
		public SdtSDT_Example( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Example_Value = "";

		}

		public SdtSDT_Example(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_Example_Id; 
			}
			set {
				gxTv_SdtSDT_Example_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtSDT_Example_Value; 
			}
			set {
				gxTv_SdtSDT_Example_Value = value;
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
			gxTv_SdtSDT_Example_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_Example_Id;
		 

		protected string gxTv_SdtSDT_Example_Value;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Example", Namespace="YTT_version4")]
	public class SdtSDT_Example_RESTInterface : GxGenericCollectionItem<SdtSDT_Example>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Example_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Example_RESTInterface( SdtSDT_Example psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 10, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Value", Order=1)]
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

		public SdtSDT_Example sdt
		{
			get { 
				return (SdtSDT_Example)Sdt;
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
				sdt = new SdtSDT_Example() ;
			}
		}
	}
	#endregion
}