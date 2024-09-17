/*
				   File: type_SdtQueryViewerElements_Element_Format_ValueStyle
			Description: ValuesStyles
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
namespace GeneXus.Programs.genexusreporting
{
	[XmlRoot(ElementName="QueryViewerElements.Element.Format.ValueStyle")]
	[XmlType(TypeName="QueryViewerElements.Element.Format.ValueStyle" , Namespace="GeneXus.Reporting" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Format_ValueStyle : GxUserType
	{
		public SdtQueryViewerElements_Element_Format_ValueStyle( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Value = "";

			gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Styleorclass = "";

		}

		public SdtQueryViewerElements_Element_Format_ValueStyle(IGxContext context)
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


			AddObjectProperty("StyleOrClass", gxTpr_Styleorclass, false);


			AddObjectProperty("ApplyToRowOrColumn", gxTpr_Applytoroworcolumn, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Value; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="StyleOrClass")]
		[XmlElement(ElementName="StyleOrClass")]
		public string gxTpr_Styleorclass
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Styleorclass; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Styleorclass = value;
				SetDirty("Styleorclass");
			}
		}




		[SoapElement(ElementName="ApplyToRowOrColumn")]
		[XmlElement(ElementName="ApplyToRowOrColumn")]
		public bool gxTpr_Applytoroworcolumn
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Applytoroworcolumn; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Applytoroworcolumn = value;
				SetDirty("Applytoroworcolumn");
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
			gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Value = "";
			gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Styleorclass = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Value;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Styleorclass;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Format_ValueStyle_Applytoroworcolumn;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"QueryViewerElements.Element.Format.ValueStyle", Namespace="GeneXus.Reporting")]
	public class SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Format_ValueStyle>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface( SdtQueryViewerElements_Element_Format_ValueStyle psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Value", Order=0)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="StyleOrClass", Order=1)]
		public  string gxTpr_Styleorclass
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Styleorclass);

			}
			set { 
				 sdt.gxTpr_Styleorclass = value;
			}
		}

		[DataMember(Name="ApplyToRowOrColumn", Order=2)]
		public bool gxTpr_Applytoroworcolumn
		{
			get { 
				return sdt.gxTpr_Applytoroworcolumn;

			}
			set { 
				sdt.gxTpr_Applytoroworcolumn = value;
			}
		}


		#endregion

		public SdtQueryViewerElements_Element_Format_ValueStyle sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Format_ValueStyle)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Format_ValueStyle() ;
			}
		}
	}
	#endregion
}