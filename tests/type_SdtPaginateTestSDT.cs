/*
				   File: type_SdtPaginateTestSDT
			Description: PaginateTestSDT
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

using GeneXus.Programs;
namespace GeneXus.Programs.tests
{
	[XmlRoot(ElementName="PaginateTestSDT")]
	[XmlType(TypeName="PaginateTestSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtPaginateTestSDT : GxUserType
	{
		public SdtPaginateTestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtPaginateTestSDT_Testcaseid = "";

			gxTv_SdtPaginateTestSDT_Msgpages_to_show = "";

			gxTv_SdtPaginateTestSDT_Msgtotal_pages = "";

			gxTv_SdtPaginateTestSDT_Msgcurrent_page = "";

		}

		public SdtPaginateTestSDT(IGxContext context)
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
			AddObjectProperty("TestCaseId", gxTpr_Testcaseid, false);

			if (gxTv_SdtPaginateTestSDT_Pages_to_show != null)
			{
				AddObjectProperty("pages_to_show", gxTv_SdtPaginateTestSDT_Pages_to_show, false);
			}
			if (gxTv_SdtPaginateTestSDT_Expectedpages_to_show != null)
			{
				AddObjectProperty("Expectedpages_to_show", gxTv_SdtPaginateTestSDT_Expectedpages_to_show, false);
			}

			AddObjectProperty("Msgpages_to_show", gxTpr_Msgpages_to_show, false);


			AddObjectProperty("total_pages", gxTpr_Total_pages, false);


			AddObjectProperty("Expectedtotal_pages", gxTpr_Expectedtotal_pages, false);


			AddObjectProperty("Msgtotal_pages", gxTpr_Msgtotal_pages, false);

			if (gxTv_SdtPaginateTestSDT_Current_page != null)
			{
				AddObjectProperty("current_page", gxTv_SdtPaginateTestSDT_Current_page, false);
			}
			if (gxTv_SdtPaginateTestSDT_Expectedcurrent_page != null)
			{
				AddObjectProperty("Expectedcurrent_page", gxTv_SdtPaginateTestSDT_Expectedcurrent_page, false);
			}

			AddObjectProperty("Msgcurrent_page", gxTpr_Msgcurrent_page, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtPaginateTestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="pages_to_show" )]
		[XmlArray(ElementName="pages_to_show"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTpr_Pages_to_show_GXBaseCollection
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Pages_to_show == null )
				{
					gxTv_SdtPaginateTestSDT_Pages_to_show = new GXBaseCollection<GeneXus.Programs.SdtSDTPage>( context, "SDTPage", "");
				}
				return gxTv_SdtPaginateTestSDT_Pages_to_show;
			}
			set {
				gxTv_SdtPaginateTestSDT_Pages_to_show_N = false;
				gxTv_SdtPaginateTestSDT_Pages_to_show = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTpr_Pages_to_show
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Pages_to_show == null )
				{
					gxTv_SdtPaginateTestSDT_Pages_to_show = new GXBaseCollection<GeneXus.Programs.SdtSDTPage>( context, "SDTPage", "");
				}
				gxTv_SdtPaginateTestSDT_Pages_to_show_N = false;
				return gxTv_SdtPaginateTestSDT_Pages_to_show ;
			}
			set {
				gxTv_SdtPaginateTestSDT_Pages_to_show_N = false;
				gxTv_SdtPaginateTestSDT_Pages_to_show = value;
				SetDirty("Pages_to_show");
			}
		}

		public void gxTv_SdtPaginateTestSDT_Pages_to_show_SetNull()
		{
			gxTv_SdtPaginateTestSDT_Pages_to_show_N = true;
			gxTv_SdtPaginateTestSDT_Pages_to_show = null;
		}

		public bool gxTv_SdtPaginateTestSDT_Pages_to_show_IsNull()
		{
			return gxTv_SdtPaginateTestSDT_Pages_to_show == null;
		}
		public bool ShouldSerializegxTpr_Pages_to_show_GXBaseCollection_Json()
		{
			return gxTv_SdtPaginateTestSDT_Pages_to_show != null && gxTv_SdtPaginateTestSDT_Pages_to_show.Count > 0;

		}


		[SoapElement(ElementName="Expectedpages_to_show" )]
		[XmlArray(ElementName="Expectedpages_to_show"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTpr_Expectedpages_to_show_GXBaseCollection
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Expectedpages_to_show == null )
				{
					gxTv_SdtPaginateTestSDT_Expectedpages_to_show = new GXBaseCollection<GeneXus.Programs.SdtSDTPage>( context, "SDTPage", "");
				}
				return gxTv_SdtPaginateTestSDT_Expectedpages_to_show;
			}
			set {
				gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N = false;
				gxTv_SdtPaginateTestSDT_Expectedpages_to_show = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTpr_Expectedpages_to_show
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Expectedpages_to_show == null )
				{
					gxTv_SdtPaginateTestSDT_Expectedpages_to_show = new GXBaseCollection<GeneXus.Programs.SdtSDTPage>( context, "SDTPage", "");
				}
				gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N = false;
				return gxTv_SdtPaginateTestSDT_Expectedpages_to_show ;
			}
			set {
				gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N = false;
				gxTv_SdtPaginateTestSDT_Expectedpages_to_show = value;
				SetDirty("Expectedpages_to_show");
			}
		}

		public void gxTv_SdtPaginateTestSDT_Expectedpages_to_show_SetNull()
		{
			gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N = true;
			gxTv_SdtPaginateTestSDT_Expectedpages_to_show = null;
		}

		public bool gxTv_SdtPaginateTestSDT_Expectedpages_to_show_IsNull()
		{
			return gxTv_SdtPaginateTestSDT_Expectedpages_to_show == null;
		}
		public bool ShouldSerializegxTpr_Expectedpages_to_show_GXBaseCollection_Json()
		{
			return gxTv_SdtPaginateTestSDT_Expectedpages_to_show != null && gxTv_SdtPaginateTestSDT_Expectedpages_to_show.Count > 0;

		}


		[SoapElement(ElementName="Msgpages_to_show")]
		[XmlElement(ElementName="Msgpages_to_show")]
		public string gxTpr_Msgpages_to_show
		{
			get {
				return gxTv_SdtPaginateTestSDT_Msgpages_to_show; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Msgpages_to_show = value;
				SetDirty("Msgpages_to_show");
			}
		}




		[SoapElement(ElementName="total_pages")]
		[XmlElement(ElementName="total_pages")]
		public short gxTpr_Total_pages
		{
			get {
				return gxTv_SdtPaginateTestSDT_Total_pages; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Total_pages = value;
				SetDirty("Total_pages");
			}
		}




		[SoapElement(ElementName="Expectedtotal_pages")]
		[XmlElement(ElementName="Expectedtotal_pages")]
		public short gxTpr_Expectedtotal_pages
		{
			get {
				return gxTv_SdtPaginateTestSDT_Expectedtotal_pages; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Expectedtotal_pages = value;
				SetDirty("Expectedtotal_pages");
			}
		}




		[SoapElement(ElementName="Msgtotal_pages")]
		[XmlElement(ElementName="Msgtotal_pages")]
		public string gxTpr_Msgtotal_pages
		{
			get {
				return gxTv_SdtPaginateTestSDT_Msgtotal_pages; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Msgtotal_pages = value;
				SetDirty("Msgtotal_pages");
			}
		}



		[SoapElement(ElementName="current_page")]
		[XmlElement(ElementName="current_page")]
		public GeneXus.Programs.SdtSDTPage gxTpr_Current_page
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Current_page == null )
				{
					gxTv_SdtPaginateTestSDT_Current_page = new GeneXus.Programs.SdtSDTPage(context);
				}
				return gxTv_SdtPaginateTestSDT_Current_page; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Current_page = value;
				SetDirty("Current_page");
			}
		}
		public void gxTv_SdtPaginateTestSDT_Current_page_SetNull()
		{
			gxTv_SdtPaginateTestSDT_Current_page_N = true;
			gxTv_SdtPaginateTestSDT_Current_page = null;
		}

		public bool gxTv_SdtPaginateTestSDT_Current_page_IsNull()
		{
			return gxTv_SdtPaginateTestSDT_Current_page == null;
		}
		public bool ShouldSerializegxTpr_Current_page_Json()
		{
			return gxTv_SdtPaginateTestSDT_Current_page != null;

		}

		[SoapElement(ElementName="Expectedcurrent_page")]
		[XmlElement(ElementName="Expectedcurrent_page")]
		public GeneXus.Programs.SdtSDTPage gxTpr_Expectedcurrent_page
		{
			get {
				if ( gxTv_SdtPaginateTestSDT_Expectedcurrent_page == null )
				{
					gxTv_SdtPaginateTestSDT_Expectedcurrent_page = new GeneXus.Programs.SdtSDTPage(context);
				}
				return gxTv_SdtPaginateTestSDT_Expectedcurrent_page; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Expectedcurrent_page = value;
				SetDirty("Expectedcurrent_page");
			}
		}
		public void gxTv_SdtPaginateTestSDT_Expectedcurrent_page_SetNull()
		{
			gxTv_SdtPaginateTestSDT_Expectedcurrent_page_N = true;
			gxTv_SdtPaginateTestSDT_Expectedcurrent_page = null;
		}

		public bool gxTv_SdtPaginateTestSDT_Expectedcurrent_page_IsNull()
		{
			return gxTv_SdtPaginateTestSDT_Expectedcurrent_page == null;
		}
		public bool ShouldSerializegxTpr_Expectedcurrent_page_Json()
		{
			return gxTv_SdtPaginateTestSDT_Expectedcurrent_page != null;

		}


		[SoapElement(ElementName="Msgcurrent_page")]
		[XmlElement(ElementName="Msgcurrent_page")]
		public string gxTpr_Msgcurrent_page
		{
			get {
				return gxTv_SdtPaginateTestSDT_Msgcurrent_page; 
			}
			set {
				gxTv_SdtPaginateTestSDT_Msgcurrent_page = value;
				SetDirty("Msgcurrent_page");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtPaginateTestSDT_Testcaseid = "";

			gxTv_SdtPaginateTestSDT_Pages_to_show_N = true;


			gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N = true;

			gxTv_SdtPaginateTestSDT_Msgpages_to_show = "";


			gxTv_SdtPaginateTestSDT_Msgtotal_pages = "";

			gxTv_SdtPaginateTestSDT_Current_page_N = true;


			gxTv_SdtPaginateTestSDT_Expectedcurrent_page_N = true;

			gxTv_SdtPaginateTestSDT_Msgcurrent_page = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtPaginateTestSDT_Testcaseid;
		 
		protected bool gxTv_SdtPaginateTestSDT_Pages_to_show_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTv_SdtPaginateTestSDT_Pages_to_show = null;  
		protected bool gxTv_SdtPaginateTestSDT_Expectedpages_to_show_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDTPage> gxTv_SdtPaginateTestSDT_Expectedpages_to_show = null;  

		protected string gxTv_SdtPaginateTestSDT_Msgpages_to_show;
		 

		protected short gxTv_SdtPaginateTestSDT_Total_pages;
		 

		protected short gxTv_SdtPaginateTestSDT_Expectedtotal_pages;
		 

		protected string gxTv_SdtPaginateTestSDT_Msgtotal_pages;
		 

		protected GeneXus.Programs.SdtSDTPage gxTv_SdtPaginateTestSDT_Current_page = null;
		protected bool gxTv_SdtPaginateTestSDT_Current_page_N;
		 

		protected GeneXus.Programs.SdtSDTPage gxTv_SdtPaginateTestSDT_Expectedcurrent_page = null;
		protected bool gxTv_SdtPaginateTestSDT_Expectedcurrent_page_N;
		 

		protected string gxTv_SdtPaginateTestSDT_Msgcurrent_page;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"PaginateTestSDT", Namespace="YTT_version4")]
	public class SdtPaginateTestSDT_RESTInterface : GxGenericCollectionItem<SdtPaginateTestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtPaginateTestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtPaginateTestSDT_RESTInterface( SdtPaginateTestSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TestCaseId", Order=0)]
		public  string gxTpr_Testcaseid
		{
			get { 
				return sdt.gxTpr_Testcaseid;

			}
			set { 
				 sdt.gxTpr_Testcaseid = value;
			}
		}

		[DataMember(Name="pages_to_show", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDTPage_RESTInterface> gxTpr_Pages_to_show
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Pages_to_show_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDTPage_RESTInterface>(sdt.gxTpr_Pages_to_show);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Pages_to_show);
			}
		}

		[DataMember(Name="Expectedpages_to_show", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDTPage_RESTInterface> gxTpr_Expectedpages_to_show
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Expectedpages_to_show_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDTPage_RESTInterface>(sdt.gxTpr_Expectedpages_to_show);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Expectedpages_to_show);
			}
		}

		[DataMember(Name="Msgpages_to_show", Order=3)]
		public  string gxTpr_Msgpages_to_show
		{
			get { 
				return sdt.gxTpr_Msgpages_to_show;

			}
			set { 
				 sdt.gxTpr_Msgpages_to_show = value;
			}
		}

		[DataMember(Name="total_pages", Order=4)]
		public short gxTpr_Total_pages
		{
			get { 
				return sdt.gxTpr_Total_pages;

			}
			set { 
				sdt.gxTpr_Total_pages = value;
			}
		}

		[DataMember(Name="Expectedtotal_pages", Order=5)]
		public short gxTpr_Expectedtotal_pages
		{
			get { 
				return sdt.gxTpr_Expectedtotal_pages;

			}
			set { 
				sdt.gxTpr_Expectedtotal_pages = value;
			}
		}

		[DataMember(Name="Msgtotal_pages", Order=6)]
		public  string gxTpr_Msgtotal_pages
		{
			get { 
				return sdt.gxTpr_Msgtotal_pages;

			}
			set { 
				 sdt.gxTpr_Msgtotal_pages = value;
			}
		}

		[DataMember(Name="current_page", Order=7, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDTPage_RESTInterface gxTpr_Current_page
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Current_page_Json())
					return new GeneXus.Programs.SdtSDTPage_RESTInterface(sdt.gxTpr_Current_page);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Current_page = value.sdt;
			}
		}

		[DataMember(Name="Expectedcurrent_page", Order=8, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDTPage_RESTInterface gxTpr_Expectedcurrent_page
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Expectedcurrent_page_Json())
					return new GeneXus.Programs.SdtSDTPage_RESTInterface(sdt.gxTpr_Expectedcurrent_page);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Expectedcurrent_page = value.sdt;
			}
		}

		[DataMember(Name="Msgcurrent_page", Order=9)]
		public  string gxTpr_Msgcurrent_page
		{
			get { 
				return sdt.gxTpr_Msgcurrent_page;

			}
			set { 
				 sdt.gxTpr_Msgcurrent_page = value;
			}
		}


		#endregion

		public SdtPaginateTestSDT sdt
		{
			get { 
				return (SdtPaginateTestSDT)Sdt;
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
				sdt = new SdtPaginateTestSDT() ;
			}
		}
	}
	#endregion
}