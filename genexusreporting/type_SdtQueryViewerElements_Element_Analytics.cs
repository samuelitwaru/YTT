/*
				   File: type_SdtQueryViewerElements_Element_Analytics
			Description: Analytics
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
	[XmlRoot(ElementName="QueryViewerElements.Element.Analytics")]
	[XmlType(TypeName="QueryViewerElements.Element.Analytics" , Namespace="GeneXus.Reporting" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Analytics : GxUserType
	{
		public SdtQueryViewerElements_Element_Analytics( )
		{
			/* Constructor for serialization */
		}

		public SdtQueryViewerElements_Element_Analytics(IGxContext context)
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
			AddObjectProperty("ShowValuesAs", gxTpr_Showvaluesas, false);


			AddObjectProperty("RollingAverageType", gxTpr_Rollingaveragetype, false);


			AddObjectProperty("RollingAverageTerms", gxTpr_Rollingaverageterms, false);


			AddObjectProperty("DifferenceFrom", gxTpr_Differencefrom, false);


			AddObjectProperty("ShowAsPercentage", gxTpr_Showaspercentage, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ShowValuesAs")]
		[XmlElement(ElementName="ShowValuesAs")]
		public short gxTpr_Showvaluesas
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Analytics_Showvaluesas; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_Showvaluesas = value;
				SetDirty("Showvaluesas");
			}
		}




		[SoapElement(ElementName="RollingAverageType")]
		[XmlElement(ElementName="RollingAverageType")]
		public short gxTpr_Rollingaveragetype
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaveragetype; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaveragetype = value;
				SetDirty("Rollingaveragetype");
			}
		}




		[SoapElement(ElementName="RollingAverageTerms")]
		[XmlElement(ElementName="RollingAverageTerms")]
		public short gxTpr_Rollingaverageterms
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaverageterms; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaverageterms = value;
				SetDirty("Rollingaverageterms");
			}
		}




		[SoapElement(ElementName="DifferenceFrom")]
		[XmlElement(ElementName="DifferenceFrom")]
		public short gxTpr_Differencefrom
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Analytics_Differencefrom; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_Differencefrom = value;
				SetDirty("Differencefrom");
			}
		}




		[SoapElement(ElementName="ShowAsPercentage")]
		[XmlElement(ElementName="ShowAsPercentage")]
		public short gxTpr_Showaspercentage
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Analytics_Showaspercentage; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_Showaspercentage = value;
				SetDirty("Showaspercentage");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtQueryViewerElements_Element_Analytics_Showvaluesas;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaveragetype;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Analytics_Rollingaverageterms;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Analytics_Differencefrom;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Analytics_Showaspercentage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"QueryViewerElements.Element.Analytics", Namespace="GeneXus.Reporting")]
	public class SdtQueryViewerElements_Element_Analytics_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Analytics>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Analytics_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerElements_Element_Analytics_RESTInterface( SdtQueryViewerElements_Element_Analytics psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ShowValuesAs", Order=0)]
		public short gxTpr_Showvaluesas
		{
			get { 
				return sdt.gxTpr_Showvaluesas;

			}
			set { 
				sdt.gxTpr_Showvaluesas = value;
			}
		}

		[DataMember(Name="RollingAverageType", Order=1)]
		public short gxTpr_Rollingaveragetype
		{
			get { 
				return sdt.gxTpr_Rollingaveragetype;

			}
			set { 
				sdt.gxTpr_Rollingaveragetype = value;
			}
		}

		[DataMember(Name="RollingAverageTerms", Order=2)]
		public short gxTpr_Rollingaverageterms
		{
			get { 
				return sdt.gxTpr_Rollingaverageterms;

			}
			set { 
				sdt.gxTpr_Rollingaverageterms = value;
			}
		}

		[DataMember(Name="DifferenceFrom", Order=3)]
		public short gxTpr_Differencefrom
		{
			get { 
				return sdt.gxTpr_Differencefrom;

			}
			set { 
				sdt.gxTpr_Differencefrom = value;
			}
		}

		[DataMember(Name="ShowAsPercentage", Order=4)]
		public short gxTpr_Showaspercentage
		{
			get { 
				return sdt.gxTpr_Showaspercentage;

			}
			set { 
				sdt.gxTpr_Showaspercentage = value;
			}
		}


		#endregion

		public SdtQueryViewerElements_Element_Analytics sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Analytics)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Analytics() ;
			}
		}
	}
	#endregion
}