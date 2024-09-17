/*
				   File: type_SdtQueryViewerElements_Element
			Description: QueryViewerElements
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
	[XmlRoot(ElementName="Element")]
	[XmlType(TypeName="Element" , Namespace="GeneXus.Reporting" )]
	[Serializable]
	public class SdtQueryViewerElements_Element : GxUserType
	{
		public SdtQueryViewerElements_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Name = "";

			gxTv_SdtQueryViewerElements_Element_Title = "";

			gxTv_SdtQueryViewerElements_Element_Visible = "";

			gxTv_SdtQueryViewerElements_Element_Datafield = "";

		}

		public SdtQueryViewerElements_Element(IGxContext context)
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


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Visible", gxTpr_Visible, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Axis", gxTpr_Axis, false);


			AddObjectProperty("Aggregation", gxTpr_Aggregation, false);


			AddObjectProperty("DataField", gxTpr_Datafield, false);

			if (gxTv_SdtQueryViewerElements_Element_Filter != null)
			{
				AddObjectProperty("Filter", gxTv_SdtQueryViewerElements_Element_Filter, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Expandcollapse != null)
			{
				AddObjectProperty("ExpandCollapse", gxTv_SdtQueryViewerElements_Element_Expandcollapse, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Axisorder != null)
			{
				AddObjectProperty("AxisOrder", gxTv_SdtQueryViewerElements_Element_Axisorder, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Format != null)
			{
				AddObjectProperty("Format", gxTv_SdtQueryViewerElements_Element_Format, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Grouping != null)
			{
				AddObjectProperty("Grouping", gxTv_SdtQueryViewerElements_Element_Grouping, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Actions != null)
			{
				AddObjectProperty("Actions", gxTv_SdtQueryViewerElements_Element_Actions, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Analytics != null)
			{
				AddObjectProperty("Analytics", gxTv_SdtQueryViewerElements_Element_Analytics, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Name; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Title; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Visible")]
		[XmlElement(ElementName="Visible")]
		public string gxTpr_Visible
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Visible; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Visible = value;
				SetDirty("Visible");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public short gxTpr_Type
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Type; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Axis")]
		[XmlElement(ElementName="Axis")]
		public short gxTpr_Axis
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Axis; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Axis = value;
				SetDirty("Axis");
			}
		}




		[SoapElement(ElementName="Aggregation")]
		[XmlElement(ElementName="Aggregation")]
		public short gxTpr_Aggregation
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Aggregation; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Aggregation = value;
				SetDirty("Aggregation");
			}
		}




		[SoapElement(ElementName="DataField")]
		[XmlElement(ElementName="DataField")]
		public string gxTpr_Datafield
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Datafield; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Datafield = value;
				SetDirty("Datafield");
			}
		}



		[SoapElement(ElementName="Filter" )]
		[XmlElement(ElementName="Filter" )]
		public SdtQueryViewerElements_Element_Filter gxTpr_Filter
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Filter == null )
				{
					gxTv_SdtQueryViewerElements_Element_Filter = new SdtQueryViewerElements_Element_Filter(context);
				}
				gxTv_SdtQueryViewerElements_Element_Filter_N = false;
				return gxTv_SdtQueryViewerElements_Element_Filter;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Filter_N = false;
				gxTv_SdtQueryViewerElements_Element_Filter = value;
				SetDirty("Filter");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Filter_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Filter_N = true;
			gxTv_SdtQueryViewerElements_Element_Filter = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Filter_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Filter == null;
		}
		public bool ShouldSerializegxTpr_Filter_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Filter != null && gxTv_SdtQueryViewerElements_Element_Filter.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="ExpandCollapse" )]
		[XmlElement(ElementName="ExpandCollapse" )]
		public SdtQueryViewerElements_Element_ExpandCollapse gxTpr_Expandcollapse
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Expandcollapse == null )
				{
					gxTv_SdtQueryViewerElements_Element_Expandcollapse = new SdtQueryViewerElements_Element_ExpandCollapse(context);
				}
				gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = false;
				return gxTv_SdtQueryViewerElements_Element_Expandcollapse;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = false;
				gxTv_SdtQueryViewerElements_Element_Expandcollapse = value;
				SetDirty("Expandcollapse");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Expandcollapse_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = true;
			gxTv_SdtQueryViewerElements_Element_Expandcollapse = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Expandcollapse_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Expandcollapse == null;
		}
		public bool ShouldSerializegxTpr_Expandcollapse_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Expandcollapse != null && gxTv_SdtQueryViewerElements_Element_Expandcollapse.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="AxisOrder" )]
		[XmlElement(ElementName="AxisOrder" )]
		public SdtQueryViewerElements_Element_AxisOrder gxTpr_Axisorder
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Axisorder == null )
				{
					gxTv_SdtQueryViewerElements_Element_Axisorder = new SdtQueryViewerElements_Element_AxisOrder(context);
				}
				gxTv_SdtQueryViewerElements_Element_Axisorder_N = false;
				return gxTv_SdtQueryViewerElements_Element_Axisorder;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Axisorder_N = false;
				gxTv_SdtQueryViewerElements_Element_Axisorder = value;
				SetDirty("Axisorder");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Axisorder_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Axisorder_N = true;
			gxTv_SdtQueryViewerElements_Element_Axisorder = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Axisorder_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Axisorder == null;
		}
		public bool ShouldSerializegxTpr_Axisorder_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Axisorder != null && gxTv_SdtQueryViewerElements_Element_Axisorder.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Format" )]
		[XmlElement(ElementName="Format" )]
		public SdtQueryViewerElements_Element_Format gxTpr_Format
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format = new SdtQueryViewerElements_Element_Format(context);
				}
				gxTv_SdtQueryViewerElements_Element_Format_N = false;
				return gxTv_SdtQueryViewerElements_Element_Format;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_N = false;
				gxTv_SdtQueryViewerElements_Element_Format = value;
				SetDirty("Format");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Format_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_N = true;
			gxTv_SdtQueryViewerElements_Element_Format = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Format == null;
		}
		public bool ShouldSerializegxTpr_Format_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Format != null && gxTv_SdtQueryViewerElements_Element_Format.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Grouping" )]
		[XmlElement(ElementName="Grouping" )]
		public SdtQueryViewerElements_Element_Grouping gxTpr_Grouping
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Grouping == null )
				{
					gxTv_SdtQueryViewerElements_Element_Grouping = new SdtQueryViewerElements_Element_Grouping(context);
				}
				gxTv_SdtQueryViewerElements_Element_Grouping_N = false;
				return gxTv_SdtQueryViewerElements_Element_Grouping;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Grouping_N = false;
				gxTv_SdtQueryViewerElements_Element_Grouping = value;
				SetDirty("Grouping");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Grouping_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Grouping_N = true;
			gxTv_SdtQueryViewerElements_Element_Grouping = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Grouping_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Grouping == null;
		}
		public bool ShouldSerializegxTpr_Grouping_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Grouping != null && gxTv_SdtQueryViewerElements_Element_Grouping.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Actions" )]
		[XmlElement(ElementName="Actions" )]
		public SdtQueryViewerElements_Element_Actions gxTpr_Actions
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Actions == null )
				{
					gxTv_SdtQueryViewerElements_Element_Actions = new SdtQueryViewerElements_Element_Actions(context);
				}
				gxTv_SdtQueryViewerElements_Element_Actions_N = false;
				return gxTv_SdtQueryViewerElements_Element_Actions;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Actions_N = false;
				gxTv_SdtQueryViewerElements_Element_Actions = value;
				SetDirty("Actions");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Actions_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Actions_N = true;
			gxTv_SdtQueryViewerElements_Element_Actions = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Actions_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Actions == null;
		}
		public bool ShouldSerializegxTpr_Actions_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Actions != null && gxTv_SdtQueryViewerElements_Element_Actions.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Analytics" )]
		[XmlElement(ElementName="Analytics" )]
		public SdtQueryViewerElements_Element_Analytics gxTpr_Analytics
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Analytics == null )
				{
					gxTv_SdtQueryViewerElements_Element_Analytics = new SdtQueryViewerElements_Element_Analytics(context);
				}
				gxTv_SdtQueryViewerElements_Element_Analytics_N = false;
				return gxTv_SdtQueryViewerElements_Element_Analytics;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Analytics_N = false;
				gxTv_SdtQueryViewerElements_Element_Analytics = value;
				SetDirty("Analytics");
			}

		}

		public void gxTv_SdtQueryViewerElements_Element_Analytics_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Analytics_N = true;
			gxTv_SdtQueryViewerElements_Element_Analytics = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Analytics_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Analytics == null;
		}
		public bool ShouldSerializegxTpr_Analytics_Json()
		{
				return (gxTv_SdtQueryViewerElements_Element_Analytics != null && gxTv_SdtQueryViewerElements_Element_Analytics.ShouldSerializeSdtJson());

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
			gxTv_SdtQueryViewerElements_Element_Name = "";
			gxTv_SdtQueryViewerElements_Element_Title = "";
			gxTv_SdtQueryViewerElements_Element_Visible = "";



			gxTv_SdtQueryViewerElements_Element_Datafield = "";

			gxTv_SdtQueryViewerElements_Element_Filter_N = true;


			gxTv_SdtQueryViewerElements_Element_Expandcollapse_N = true;


			gxTv_SdtQueryViewerElements_Element_Axisorder_N = true;


			gxTv_SdtQueryViewerElements_Element_Format_N = true;


			gxTv_SdtQueryViewerElements_Element_Grouping_N = true;


			gxTv_SdtQueryViewerElements_Element_Actions_N = true;


			gxTv_SdtQueryViewerElements_Element_Analytics_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Name;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Title;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Visible;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Type;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Axis;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Aggregation;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Datafield;
		 
		protected bool gxTv_SdtQueryViewerElements_Element_Filter_N;
		protected SdtQueryViewerElements_Element_Filter gxTv_SdtQueryViewerElements_Element_Filter = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Expandcollapse_N;
		protected SdtQueryViewerElements_Element_ExpandCollapse gxTv_SdtQueryViewerElements_Element_Expandcollapse = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Axisorder_N;
		protected SdtQueryViewerElements_Element_AxisOrder gxTv_SdtQueryViewerElements_Element_Axisorder = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Format_N;
		protected SdtQueryViewerElements_Element_Format gxTv_SdtQueryViewerElements_Element_Format = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Grouping_N;
		protected SdtQueryViewerElements_Element_Grouping gxTv_SdtQueryViewerElements_Element_Grouping = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Actions_N;
		protected SdtQueryViewerElements_Element_Actions gxTv_SdtQueryViewerElements_Element_Actions = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Analytics_N;
		protected SdtQueryViewerElements_Element_Analytics gxTv_SdtQueryViewerElements_Element_Analytics = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Element", Namespace="GeneXus.Reporting")]
	public class SdtQueryViewerElements_Element_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerElements_Element_RESTInterface( SdtQueryViewerElements_Element psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Visible", Order=2)]
		public  string gxTpr_Visible
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Visible);

			}
			set { 
				 sdt.gxTpr_Visible = value;
			}
		}

		[DataMember(Name="Type", Order=3)]
		public short gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Axis", Order=4)]
		public short gxTpr_Axis
		{
			get { 
				return sdt.gxTpr_Axis;

			}
			set { 
				sdt.gxTpr_Axis = value;
			}
		}

		[DataMember(Name="Aggregation", Order=5)]
		public short gxTpr_Aggregation
		{
			get { 
				return sdt.gxTpr_Aggregation;

			}
			set { 
				sdt.gxTpr_Aggregation = value;
			}
		}

		[DataMember(Name="DataField", Order=6)]
		public  string gxTpr_Datafield
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Datafield);

			}
			set { 
				 sdt.gxTpr_Datafield = value;
			}
		}

		[DataMember(Name="Filter", Order=7, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Filter_RESTInterface gxTpr_Filter
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filter_Json())
					return new SdtQueryViewerElements_Element_Filter_RESTInterface(sdt.gxTpr_Filter);
				else
					return null;

			}

			set {
				sdt.gxTpr_Filter = value.sdt;
			}

		}

		[DataMember(Name="ExpandCollapse", Order=8, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface gxTpr_Expandcollapse
		{
			get {
				if (sdt.ShouldSerializegxTpr_Expandcollapse_Json())
					return new SdtQueryViewerElements_Element_ExpandCollapse_RESTInterface(sdt.gxTpr_Expandcollapse);
				else
					return null;

			}

			set {
				sdt.gxTpr_Expandcollapse = value.sdt;
			}

		}

		[DataMember(Name="AxisOrder", Order=9, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_AxisOrder_RESTInterface gxTpr_Axisorder
		{
			get {
				if (sdt.ShouldSerializegxTpr_Axisorder_Json())
					return new SdtQueryViewerElements_Element_AxisOrder_RESTInterface(sdt.gxTpr_Axisorder);
				else
					return null;

			}

			set {
				sdt.gxTpr_Axisorder = value.sdt;
			}

		}

		[DataMember(Name="Format", Order=10, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Format_RESTInterface gxTpr_Format
		{
			get {
				if (sdt.ShouldSerializegxTpr_Format_Json())
					return new SdtQueryViewerElements_Element_Format_RESTInterface(sdt.gxTpr_Format);
				else
					return null;

			}

			set {
				sdt.gxTpr_Format = value.sdt;
			}

		}

		[DataMember(Name="Grouping", Order=11, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Grouping_RESTInterface gxTpr_Grouping
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grouping_Json())
					return new SdtQueryViewerElements_Element_Grouping_RESTInterface(sdt.gxTpr_Grouping);
				else
					return null;

			}

			set {
				sdt.gxTpr_Grouping = value.sdt;
			}

		}

		[DataMember(Name="Actions", Order=12, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Actions_RESTInterface gxTpr_Actions
		{
			get {
				if (sdt.ShouldSerializegxTpr_Actions_Json())
					return new SdtQueryViewerElements_Element_Actions_RESTInterface(sdt.gxTpr_Actions);
				else
					return null;

			}

			set {
				sdt.gxTpr_Actions = value.sdt;
			}

		}

		[DataMember(Name="Analytics", Order=13, EmitDefaultValue=false)]
		public SdtQueryViewerElements_Element_Analytics_RESTInterface gxTpr_Analytics
		{
			get {
				if (sdt.ShouldSerializegxTpr_Analytics_Json())
					return new SdtQueryViewerElements_Element_Analytics_RESTInterface(sdt.gxTpr_Analytics);
				else
					return null;

			}

			set {
				sdt.gxTpr_Analytics = value.sdt;
			}

		}


		#endregion

		public SdtQueryViewerElements_Element sdt
		{
			get { 
				return (SdtQueryViewerElements_Element)Sdt;
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
				sdt = new SdtQueryViewerElements_Element() ;
			}
		}
	}
	#endregion
}