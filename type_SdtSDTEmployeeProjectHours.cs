/*
				   File: type_SdtSDTEmployeeProjectHours
			Description: SDTEmployeeProjectHours
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
	[XmlRoot(ElementName="SDTEmployeeProjectHours")]
	[XmlType(TypeName="SDTEmployeeProjectHours" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeProjectHours : GxUserType
	{
		public SdtSDTEmployeeProjectHours( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeProjectHours_Employeename = "";

			gxTv_SdtSDTEmployeeProjectHours_Totalformattedtime = "";

			gxTv_SdtSDTEmployeeProjectHours_Totalformattedleave = "";

			gxTv_SdtSDTEmployeeProjectHours_Formattedtotal = "";

		}

		public SdtSDTEmployeeProjectHours(IGxContext context)
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
			AddObjectProperty("EmployeeId", gxTpr_Employeeid, false);


			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("TotalTime", gxTpr_Totaltime, false);


			AddObjectProperty("TotalFormattedTime", gxTpr_Totalformattedtime, false);


			AddObjectProperty("TotalLeave", gxTpr_Totalleave, false);


			AddObjectProperty("TotalFormattedLeave", gxTpr_Totalformattedleave, false);


			AddObjectProperty("ExpectedWorkTime", gxTpr_Expectedworktime, false);


			AddObjectProperty("IsWorkTimeOptimal", gxTpr_Isworktimeoptimal, false);


			AddObjectProperty("Total", gxTpr_Total, false);


			AddObjectProperty("FormattedTotal", gxTpr_Formattedtotal, false);

			if (gxTv_SdtSDTEmployeeProjectHours_Projecthours != null)
			{
				AddObjectProperty("ProjectHours", gxTv_SdtSDTEmployeeProjectHours_Projecthours, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmployeeId")]
		[XmlElement(ElementName="EmployeeId")]
		public long gxTpr_Employeeid
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Employeeid; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="TotalTime")]
		[XmlElement(ElementName="TotalTime")]
		public long gxTpr_Totaltime
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Totaltime; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Totaltime = value;
				SetDirty("Totaltime");
			}
		}




		[SoapElement(ElementName="TotalFormattedTime")]
		[XmlElement(ElementName="TotalFormattedTime")]
		public string gxTpr_Totalformattedtime
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Totalformattedtime; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Totalformattedtime = value;
				SetDirty("Totalformattedtime");
			}
		}




		[SoapElement(ElementName="TotalLeave")]
		[XmlElement(ElementName="TotalLeave")]
		public long gxTpr_Totalleave
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Totalleave; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Totalleave = value;
				SetDirty("Totalleave");
			}
		}




		[SoapElement(ElementName="TotalFormattedLeave")]
		[XmlElement(ElementName="TotalFormattedLeave")]
		public string gxTpr_Totalformattedleave
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Totalformattedleave; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Totalformattedleave = value;
				SetDirty("Totalformattedleave");
			}
		}




		[SoapElement(ElementName="ExpectedWorkTime")]
		[XmlElement(ElementName="ExpectedWorkTime")]
		public long gxTpr_Expectedworktime
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Expectedworktime; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Expectedworktime = value;
				SetDirty("Expectedworktime");
			}
		}




		[SoapElement(ElementName="IsWorkTimeOptimal")]
		[XmlElement(ElementName="IsWorkTimeOptimal")]
		public bool gxTpr_Isworktimeoptimal
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Isworktimeoptimal; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Isworktimeoptimal = value;
				SetDirty("Isworktimeoptimal");
			}
		}




		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public long gxTpr_Total
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Total; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="FormattedTotal")]
		[XmlElement(ElementName="FormattedTotal")]
		public string gxTpr_Formattedtotal
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_Formattedtotal; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Formattedtotal = value;
				SetDirty("Formattedtotal");
			}
		}




		[SoapElement(ElementName="ProjectHours" )]
		[XmlArray(ElementName="ProjectHours"  )]
		[XmlArrayItemAttribute(ElementName="ProjectHoursItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployeeProjectHours_ProjectHoursItem> gxTpr_Projecthours
		{
			get {
				if ( gxTv_SdtSDTEmployeeProjectHours_Projecthours == null )
				{
					gxTv_SdtSDTEmployeeProjectHours_Projecthours = new GXBaseCollection<SdtSDTEmployeeProjectHours_ProjectHoursItem>( context, "SDTEmployeeProjectHours.ProjectHoursItem", "");
				}
				return gxTv_SdtSDTEmployeeProjectHours_Projecthours;
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_Projecthours_N = false;
				gxTv_SdtSDTEmployeeProjectHours_Projecthours = value;
				SetDirty("Projecthours");
			}
		}

		public void gxTv_SdtSDTEmployeeProjectHours_Projecthours_SetNull()
		{
			gxTv_SdtSDTEmployeeProjectHours_Projecthours_N = true;
			gxTv_SdtSDTEmployeeProjectHours_Projecthours = null;
		}

		public bool gxTv_SdtSDTEmployeeProjectHours_Projecthours_IsNull()
		{
			return gxTv_SdtSDTEmployeeProjectHours_Projecthours == null;
		}
		public bool ShouldSerializegxTpr_Projecthours_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployeeProjectHours_Projecthours != null && gxTv_SdtSDTEmployeeProjectHours_Projecthours.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTEmployeeProjectHours_Employeename = "";

			gxTv_SdtSDTEmployeeProjectHours_Totalformattedtime = "";

			gxTv_SdtSDTEmployeeProjectHours_Totalformattedleave = "";



			gxTv_SdtSDTEmployeeProjectHours_Formattedtotal = "";

			gxTv_SdtSDTEmployeeProjectHours_Projecthours_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployeeProjectHours_Employeeid;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_Employeename;
		 

		protected long gxTv_SdtSDTEmployeeProjectHours_Totaltime;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_Totalformattedtime;
		 

		protected long gxTv_SdtSDTEmployeeProjectHours_Totalleave;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_Totalformattedleave;
		 

		protected long gxTv_SdtSDTEmployeeProjectHours_Expectedworktime;
		 

		protected bool gxTv_SdtSDTEmployeeProjectHours_Isworktimeoptimal;
		 

		protected long gxTv_SdtSDTEmployeeProjectHours_Total;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_Formattedtotal;
		 
		protected bool gxTv_SdtSDTEmployeeProjectHours_Projecthours_N;
		protected GXBaseCollection<SdtSDTEmployeeProjectHours_ProjectHoursItem> gxTv_SdtSDTEmployeeProjectHours_Projecthours = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTEmployeeProjectHours", Namespace="YTT_version4")]
	public class SdtSDTEmployeeProjectHours_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeProjectHours>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeProjectHours_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeProjectHours_RESTInterface( SdtSDTEmployeeProjectHours psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EmployeeId", Order=0)]
		public  string gxTpr_Employeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EmployeeName", Order=1)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="TotalTime", Order=2)]
		public  string gxTpr_Totaltime
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Totaltime, 10, 0));

			}
			set { 
				sdt.gxTpr_Totaltime = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalFormattedTime", Order=3)]
		public  string gxTpr_Totalformattedtime
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Totalformattedtime);

			}
			set { 
				 sdt.gxTpr_Totalformattedtime = value;
			}
		}

		[DataMember(Name="TotalLeave", Order=4)]
		public  string gxTpr_Totalleave
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Totalleave, 10, 0));

			}
			set { 
				sdt.gxTpr_Totalleave = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalFormattedLeave", Order=5)]
		public  string gxTpr_Totalformattedleave
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Totalformattedleave);

			}
			set { 
				 sdt.gxTpr_Totalformattedleave = value;
			}
		}

		[DataMember(Name="ExpectedWorkTime", Order=6)]
		public  string gxTpr_Expectedworktime
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedworktime, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedworktime = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="IsWorkTimeOptimal", Order=7)]
		public bool gxTpr_Isworktimeoptimal
		{
			get { 
				return sdt.gxTpr_Isworktimeoptimal;

			}
			set { 
				sdt.gxTpr_Isworktimeoptimal = value;
			}
		}

		[DataMember(Name="Total", Order=8)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total, 10, 0));

			}
			set { 
				sdt.gxTpr_Total = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedTotal", Order=9)]
		public  string gxTpr_Formattedtotal
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Formattedtotal);

			}
			set { 
				 sdt.gxTpr_Formattedtotal = value;
			}
		}

		[DataMember(Name="ProjectHours", Order=10, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployeeProjectHours_ProjectHoursItem_RESTInterface> gxTpr_Projecthours
		{
			get {
				if (sdt.ShouldSerializegxTpr_Projecthours_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployeeProjectHours_ProjectHoursItem_RESTInterface>(sdt.gxTpr_Projecthours);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Projecthours);
			}
		}


		#endregion

		public SdtSDTEmployeeProjectHours sdt
		{
			get { 
				return (SdtSDTEmployeeProjectHours)Sdt;
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
				sdt = new SdtSDTEmployeeProjectHours() ;
			}
		}
	}
	#endregion
}