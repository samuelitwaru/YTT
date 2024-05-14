/*
				   File: type_SdtSDTEmployeeProjectHours_ProjectHoursItem
			Description: ProjectHours
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
	[XmlRoot(ElementName="SDTEmployeeProjectHours.ProjectHoursItem")]
	[XmlType(TypeName="SDTEmployeeProjectHours.ProjectHoursItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeProjectHours_ProjectHoursItem : GxUserType
	{
		public SdtSDTEmployeeProjectHours_ProjectHoursItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectname = "";

			gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectformattedtime = "";

		}

		public SdtSDTEmployeeProjectHours_ProjectHoursItem(IGxContext context)
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
			AddObjectProperty("ProjectId", gxTpr_Projectid, false);


			AddObjectProperty("ProjectName", gxTpr_Projectname, false);


			AddObjectProperty("ProjectTime", gxTpr_Projecttime, false);


			AddObjectProperty("ProjectFormattedTime", gxTpr_Projectformattedtime, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectid; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectname; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectname = value;
				SetDirty("Projectname");
			}
		}




		[SoapElement(ElementName="ProjectTime")]
		[XmlElement(ElementName="ProjectTime")]
		public long gxTpr_Projecttime
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projecttime; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projecttime = value;
				SetDirty("Projecttime");
			}
		}




		[SoapElement(ElementName="ProjectFormattedTime")]
		[XmlElement(ElementName="ProjectFormattedTime")]
		public string gxTpr_Projectformattedtime
		{
			get {
				return gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectformattedtime; 
			}
			set {
				gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectformattedtime = value;
				SetDirty("Projectformattedtime");
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
			gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectname = "";

			gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectformattedtime = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectid;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectname;
		 

		protected long gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projecttime;
		 

		protected string gxTv_SdtSDTEmployeeProjectHours_ProjectHoursItem_Projectformattedtime;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTEmployeeProjectHours.ProjectHoursItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeProjectHours_ProjectHoursItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeProjectHours_ProjectHoursItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeProjectHours_ProjectHoursItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeProjectHours_ProjectHoursItem_RESTInterface( SdtSDTEmployeeProjectHours_ProjectHoursItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProjectId", Order=0)]
		public  string gxTpr_Projectid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projectid, 10, 0));

			}
			set { 
				sdt.gxTpr_Projectid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectName", Order=1)]
		public  string gxTpr_Projectname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectname);

			}
			set { 
				 sdt.gxTpr_Projectname = value;
			}
		}

		[DataMember(Name="ProjectTime", Order=2)]
		public  string gxTpr_Projecttime
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projecttime, 10, 0));

			}
			set { 
				sdt.gxTpr_Projecttime = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectFormattedTime", Order=3)]
		public  string gxTpr_Projectformattedtime
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectformattedtime);

			}
			set { 
				 sdt.gxTpr_Projectformattedtime = value;
			}
		}


		#endregion

		public SdtSDTEmployeeProjectHours_ProjectHoursItem sdt
		{
			get { 
				return (SdtSDTEmployeeProjectHours_ProjectHoursItem)Sdt;
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
				sdt = new SdtSDTEmployeeProjectHours_ProjectHoursItem() ;
			}
		}
	}
	#endregion
}