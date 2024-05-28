/*
				   File: type_SdtjsGanttTask
			Description: jsGanttTask
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
	[XmlRoot(ElementName="jsGanttTask")]
	[XmlType(TypeName="jsGanttTask" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtjsGanttTask : GxUserType
	{
		public SdtjsGanttTask( )
		{
			/* Constructor for serialization */
			gxTv_SdtjsGanttTask_Pname = "";

			gxTv_SdtjsGanttTask_Pstart = "";

			gxTv_SdtjsGanttTask_Pend = "";

			gxTv_SdtjsGanttTask_Pcolor = "";

			gxTv_SdtjsGanttTask_Plink = "";

			gxTv_SdtjsGanttTask_Pres = "";

			gxTv_SdtjsGanttTask_Pdepend = "";

			gxTv_SdtjsGanttTask_Pcaption = "";

		}

		public SdtjsGanttTask(IGxContext context)
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
			AddObjectProperty("pID", gxTpr_Pid, false);


			AddObjectProperty("pName", gxTpr_Pname, false);


			AddObjectProperty("pStart", gxTpr_Pstart, false);


			AddObjectProperty("pEnd", gxTpr_Pend, false);


			AddObjectProperty("pColor", gxTpr_Pcolor, false);


			AddObjectProperty("pLink", gxTpr_Plink, false);


			AddObjectProperty("pMile", gxTpr_Pmile, false);


			AddObjectProperty("pRes", gxTpr_Pres, false);


			AddObjectProperty("pComp", gxTpr_Pcomp, false);


			AddObjectProperty("pGroup", gxTpr_Pgroup, false);


			AddObjectProperty("pParent", gxTpr_Pparent, false);


			AddObjectProperty("pOpen", gxTpr_Popen, false);


			AddObjectProperty("pDepend", gxTpr_Pdepend, false);


			AddObjectProperty("pCaption", gxTpr_Pcaption, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="pID")]
		[XmlElement(ElementName="pID")]
		public short gxTpr_Pid
		{
			get {
				return gxTv_SdtjsGanttTask_Pid; 
			}
			set {
				gxTv_SdtjsGanttTask_Pid = value;
				SetDirty("Pid");
			}
		}




		[SoapElement(ElementName="pName")]
		[XmlElement(ElementName="pName")]
		public string gxTpr_Pname
		{
			get {
				return gxTv_SdtjsGanttTask_Pname; 
			}
			set {
				gxTv_SdtjsGanttTask_Pname = value;
				SetDirty("Pname");
			}
		}




		[SoapElement(ElementName="pStart")]
		[XmlElement(ElementName="pStart")]
		public string gxTpr_Pstart
		{
			get {
				return gxTv_SdtjsGanttTask_Pstart; 
			}
			set {
				gxTv_SdtjsGanttTask_Pstart = value;
				SetDirty("Pstart");
			}
		}




		[SoapElement(ElementName="pEnd")]
		[XmlElement(ElementName="pEnd")]
		public string gxTpr_Pend
		{
			get {
				return gxTv_SdtjsGanttTask_Pend; 
			}
			set {
				gxTv_SdtjsGanttTask_Pend = value;
				SetDirty("Pend");
			}
		}




		[SoapElement(ElementName="pColor")]
		[XmlElement(ElementName="pColor")]
		public string gxTpr_Pcolor
		{
			get {
				return gxTv_SdtjsGanttTask_Pcolor; 
			}
			set {
				gxTv_SdtjsGanttTask_Pcolor = value;
				SetDirty("Pcolor");
			}
		}




		[SoapElement(ElementName="pLink")]
		[XmlElement(ElementName="pLink")]
		public string gxTpr_Plink
		{
			get {
				return gxTv_SdtjsGanttTask_Plink; 
			}
			set {
				gxTv_SdtjsGanttTask_Plink = value;
				SetDirty("Plink");
			}
		}




		[SoapElement(ElementName="pMile")]
		[XmlElement(ElementName="pMile")]
		public short gxTpr_Pmile
		{
			get {
				return gxTv_SdtjsGanttTask_Pmile; 
			}
			set {
				gxTv_SdtjsGanttTask_Pmile = value;
				SetDirty("Pmile");
			}
		}




		[SoapElement(ElementName="pRes")]
		[XmlElement(ElementName="pRes")]
		public string gxTpr_Pres
		{
			get {
				return gxTv_SdtjsGanttTask_Pres; 
			}
			set {
				gxTv_SdtjsGanttTask_Pres = value;
				SetDirty("Pres");
			}
		}




		[SoapElement(ElementName="pComp")]
		[XmlElement(ElementName="pComp")]
		public short gxTpr_Pcomp
		{
			get {
				return gxTv_SdtjsGanttTask_Pcomp; 
			}
			set {
				gxTv_SdtjsGanttTask_Pcomp = value;
				SetDirty("Pcomp");
			}
		}




		[SoapElement(ElementName="pGroup")]
		[XmlElement(ElementName="pGroup")]
		public short gxTpr_Pgroup
		{
			get {
				return gxTv_SdtjsGanttTask_Pgroup; 
			}
			set {
				gxTv_SdtjsGanttTask_Pgroup = value;
				SetDirty("Pgroup");
			}
		}




		[SoapElement(ElementName="pParent")]
		[XmlElement(ElementName="pParent")]
		public short gxTpr_Pparent
		{
			get {
				return gxTv_SdtjsGanttTask_Pparent; 
			}
			set {
				gxTv_SdtjsGanttTask_Pparent = value;
				SetDirty("Pparent");
			}
		}




		[SoapElement(ElementName="pOpen")]
		[XmlElement(ElementName="pOpen")]
		public short gxTpr_Popen
		{
			get {
				return gxTv_SdtjsGanttTask_Popen; 
			}
			set {
				gxTv_SdtjsGanttTask_Popen = value;
				SetDirty("Popen");
			}
		}




		[SoapElement(ElementName="pDepend")]
		[XmlElement(ElementName="pDepend")]
		public string gxTpr_Pdepend
		{
			get {
				return gxTv_SdtjsGanttTask_Pdepend; 
			}
			set {
				gxTv_SdtjsGanttTask_Pdepend = value;
				SetDirty("Pdepend");
			}
		}




		[SoapElement(ElementName="pCaption")]
		[XmlElement(ElementName="pCaption")]
		public string gxTpr_Pcaption
		{
			get {
				return gxTv_SdtjsGanttTask_Pcaption; 
			}
			set {
				gxTv_SdtjsGanttTask_Pcaption = value;
				SetDirty("Pcaption");
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
			gxTv_SdtjsGanttTask_Pname = "";
			gxTv_SdtjsGanttTask_Pstart = "";
			gxTv_SdtjsGanttTask_Pend = "";
			gxTv_SdtjsGanttTask_Pcolor = "";
			gxTv_SdtjsGanttTask_Plink = "";

			gxTv_SdtjsGanttTask_Pres = "";




			gxTv_SdtjsGanttTask_Pdepend = "";
			gxTv_SdtjsGanttTask_Pcaption = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtjsGanttTask_Pid;
		 

		protected string gxTv_SdtjsGanttTask_Pname;
		 

		protected string gxTv_SdtjsGanttTask_Pstart;
		 

		protected string gxTv_SdtjsGanttTask_Pend;
		 

		protected string gxTv_SdtjsGanttTask_Pcolor;
		 

		protected string gxTv_SdtjsGanttTask_Plink;
		 

		protected short gxTv_SdtjsGanttTask_Pmile;
		 

		protected string gxTv_SdtjsGanttTask_Pres;
		 

		protected short gxTv_SdtjsGanttTask_Pcomp;
		 

		protected short gxTv_SdtjsGanttTask_Pgroup;
		 

		protected short gxTv_SdtjsGanttTask_Pparent;
		 

		protected short gxTv_SdtjsGanttTask_Popen;
		 

		protected string gxTv_SdtjsGanttTask_Pdepend;
		 

		protected string gxTv_SdtjsGanttTask_Pcaption;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"jsGanttTask", Namespace="YTT_version4")]
	public class SdtjsGanttTask_RESTInterface : GxGenericCollectionItem<SdtjsGanttTask>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtjsGanttTask_RESTInterface( ) : base()
		{	
		}

		public SdtjsGanttTask_RESTInterface( SdtjsGanttTask psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="pID", Order=0)]
		public short gxTpr_Pid
		{
			get { 
				return sdt.gxTpr_Pid;

			}
			set { 
				sdt.gxTpr_Pid = value;
			}
		}

		[DataMember(Name="pName", Order=1)]
		public  string gxTpr_Pname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pname);

			}
			set { 
				 sdt.gxTpr_Pname = value;
			}
		}

		[DataMember(Name="pStart", Order=2)]
		public  string gxTpr_Pstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pstart);

			}
			set { 
				 sdt.gxTpr_Pstart = value;
			}
		}

		[DataMember(Name="pEnd", Order=3)]
		public  string gxTpr_Pend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pend);

			}
			set { 
				 sdt.gxTpr_Pend = value;
			}
		}

		[DataMember(Name="pColor", Order=4)]
		public  string gxTpr_Pcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pcolor);

			}
			set { 
				 sdt.gxTpr_Pcolor = value;
			}
		}

		[DataMember(Name="pLink", Order=5)]
		public  string gxTpr_Plink
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Plink);

			}
			set { 
				 sdt.gxTpr_Plink = value;
			}
		}

		[DataMember(Name="pMile", Order=6)]
		public short gxTpr_Pmile
		{
			get { 
				return sdt.gxTpr_Pmile;

			}
			set { 
				sdt.gxTpr_Pmile = value;
			}
		}

		[DataMember(Name="pRes", Order=7)]
		public  string gxTpr_Pres
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pres);

			}
			set { 
				 sdt.gxTpr_Pres = value;
			}
		}

		[DataMember(Name="pComp", Order=8)]
		public short gxTpr_Pcomp
		{
			get { 
				return sdt.gxTpr_Pcomp;

			}
			set { 
				sdt.gxTpr_Pcomp = value;
			}
		}

		[DataMember(Name="pGroup", Order=9)]
		public short gxTpr_Pgroup
		{
			get { 
				return sdt.gxTpr_Pgroup;

			}
			set { 
				sdt.gxTpr_Pgroup = value;
			}
		}

		[DataMember(Name="pParent", Order=10)]
		public short gxTpr_Pparent
		{
			get { 
				return sdt.gxTpr_Pparent;

			}
			set { 
				sdt.gxTpr_Pparent = value;
			}
		}

		[DataMember(Name="pOpen", Order=11)]
		public short gxTpr_Popen
		{
			get { 
				return sdt.gxTpr_Popen;

			}
			set { 
				sdt.gxTpr_Popen = value;
			}
		}

		[DataMember(Name="pDepend", Order=12)]
		public  string gxTpr_Pdepend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pdepend);

			}
			set { 
				 sdt.gxTpr_Pdepend = value;
			}
		}

		[DataMember(Name="pCaption", Order=13)]
		public  string gxTpr_Pcaption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pcaption);

			}
			set { 
				 sdt.gxTpr_Pcaption = value;
			}
		}


		#endregion

		public SdtjsGanttTask sdt
		{
			get { 
				return (SdtjsGanttTask)Sdt;
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
				sdt = new SdtjsGanttTask() ;
			}
		}
	}
	#endregion
}