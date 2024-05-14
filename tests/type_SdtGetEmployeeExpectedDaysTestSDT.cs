/*
				   File: type_SdtGetEmployeeExpectedDaysTestSDT
			Description: GetEmployeeExpectedDaysTestSDT
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
	[XmlRoot(ElementName="GetEmployeeExpectedDaysTestSDT")]
	[XmlType(TypeName="GetEmployeeExpectedDaysTestSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtGetEmployeeExpectedDaysTestSDT : GxUserType
	{
		public SdtGetEmployeeExpectedDaysTestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Testcaseid = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgemployeeid = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgfromdate = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgtodate = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgholidaycount = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgleavedays = "";

			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgexpectedworkdays = "";

		}

		public SdtGetEmployeeExpectedDaysTestSDT(IGxContext context)
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


			AddObjectProperty("EmployeeId", gxTpr_Employeeid, false);


			AddObjectProperty("ExpectedEmployeeId", gxTpr_Expectedemployeeid, false);


			AddObjectProperty("MsgEmployeeId", gxTpr_Msgemployeeid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FromDate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Expectedfromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Expectedfromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Expectedfromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ExpectedFromDate", sDateCnv, false);



			AddObjectProperty("MsgFromDate", gxTpr_Msgfromdate, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ToDate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Expectedtodate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Expectedtodate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Expectedtodate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ExpectedToDate", sDateCnv, false);



			AddObjectProperty("MsgToDate", gxTpr_Msgtodate, false);


			AddObjectProperty("HolidayCount", gxTpr_Holidaycount, false);


			AddObjectProperty("ExpectedHolidayCount", gxTpr_Expectedholidaycount, false);


			AddObjectProperty("MsgHolidayCount", gxTpr_Msgholidaycount, false);


			AddObjectProperty("LeaveDays", gxTpr_Leavedays, false);


			AddObjectProperty("ExpectedLeaveDays", gxTpr_Expectedleavedays, false);


			AddObjectProperty("MsgLeaveDays", gxTpr_Msgleavedays, false);


			AddObjectProperty("ExpectedWorkDays", gxTpr_Expectedworkdays, false);


			AddObjectProperty("ExpectedExpectedWorkDays", gxTpr_Expectedexpectedworkdays, false);


			AddObjectProperty("MsgExpectedWorkDays", gxTpr_Msgexpectedworkdays, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="EmployeeId")]
		[XmlElement(ElementName="EmployeeId")]
		public long gxTpr_Employeeid
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Employeeid; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="ExpectedEmployeeId")]
		[XmlElement(ElementName="ExpectedEmployeeId")]
		public long gxTpr_Expectedemployeeid
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedemployeeid; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedemployeeid = value;
				SetDirty("Expectedemployeeid");
			}
		}




		[SoapElement(ElementName="MsgEmployeeId")]
		[XmlElement(ElementName="MsgEmployeeId")]
		public string gxTpr_Msgemployeeid
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgemployeeid; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgemployeeid = value;
				SetDirty("Msgemployeeid");
			}
		}



		[SoapElement(ElementName="FromDate")]
		[XmlElement(ElementName="FromDate" , IsNullable=true)]
		public string gxTpr_Fromdate_Nullable
		{
			get {
				if ( gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate).value ;
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Fromdate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate = value;
				SetDirty("Fromdate");
			}
		}


		[SoapElement(ElementName="ExpectedFromDate")]
		[XmlElement(ElementName="ExpectedFromDate" , IsNullable=true)]
		public string gxTpr_Expectedfromdate_Nullable
		{
			get {
				if ( gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate).value ;
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Expectedfromdate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate = value;
				SetDirty("Expectedfromdate");
			}
		}



		[SoapElement(ElementName="MsgFromDate")]
		[XmlElement(ElementName="MsgFromDate")]
		public string gxTpr_Msgfromdate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgfromdate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgfromdate = value;
				SetDirty("Msgfromdate");
			}
		}



		[SoapElement(ElementName="ToDate")]
		[XmlElement(ElementName="ToDate" , IsNullable=true)]
		public string gxTpr_Todate_Nullable
		{
			get {
				if ( gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate).value ;
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Todate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate = value;
				SetDirty("Todate");
			}
		}


		[SoapElement(ElementName="ExpectedToDate")]
		[XmlElement(ElementName="ExpectedToDate" , IsNullable=true)]
		public string gxTpr_Expectedtodate_Nullable
		{
			get {
				if ( gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate).value ;
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Expectedtodate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate = value;
				SetDirty("Expectedtodate");
			}
		}



		[SoapElement(ElementName="MsgToDate")]
		[XmlElement(ElementName="MsgToDate")]
		public string gxTpr_Msgtodate
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgtodate; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgtodate = value;
				SetDirty("Msgtodate");
			}
		}




		[SoapElement(ElementName="HolidayCount")]
		[XmlElement(ElementName="HolidayCount")]
		public long gxTpr_Holidaycount
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Holidaycount; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Holidaycount = value;
				SetDirty("Holidaycount");
			}
		}




		[SoapElement(ElementName="ExpectedHolidayCount")]
		[XmlElement(ElementName="ExpectedHolidayCount")]
		public long gxTpr_Expectedholidaycount
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedholidaycount; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedholidaycount = value;
				SetDirty("Expectedholidaycount");
			}
		}




		[SoapElement(ElementName="MsgHolidayCount")]
		[XmlElement(ElementName="MsgHolidayCount")]
		public string gxTpr_Msgholidaycount
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgholidaycount; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgholidaycount = value;
				SetDirty("Msgholidaycount");
			}
		}




		[SoapElement(ElementName="LeaveDays")]
		[XmlElement(ElementName="LeaveDays")]
		public long gxTpr_Leavedays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Leavedays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Leavedays = value;
				SetDirty("Leavedays");
			}
		}




		[SoapElement(ElementName="ExpectedLeaveDays")]
		[XmlElement(ElementName="ExpectedLeaveDays")]
		public long gxTpr_Expectedleavedays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedleavedays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedleavedays = value;
				SetDirty("Expectedleavedays");
			}
		}




		[SoapElement(ElementName="MsgLeaveDays")]
		[XmlElement(ElementName="MsgLeaveDays")]
		public string gxTpr_Msgleavedays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgleavedays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgleavedays = value;
				SetDirty("Msgleavedays");
			}
		}




		[SoapElement(ElementName="ExpectedWorkDays")]
		[XmlElement(ElementName="ExpectedWorkDays")]
		public long gxTpr_Expectedworkdays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedworkdays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedworkdays = value;
				SetDirty("Expectedworkdays");
			}
		}




		[SoapElement(ElementName="ExpectedExpectedWorkDays")]
		[XmlElement(ElementName="ExpectedExpectedWorkDays")]
		public long gxTpr_Expectedexpectedworkdays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedexpectedworkdays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedexpectedworkdays = value;
				SetDirty("Expectedexpectedworkdays");
			}
		}




		[SoapElement(ElementName="MsgExpectedWorkDays")]
		[XmlElement(ElementName="MsgExpectedWorkDays")]
		public string gxTpr_Msgexpectedworkdays
		{
			get {
				return gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgexpectedworkdays; 
			}
			set {
				gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgexpectedworkdays = value;
				SetDirty("Msgexpectedworkdays");
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
			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Testcaseid = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgemployeeid = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgfromdate = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgtodate = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgholidaycount = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgleavedays = "";


			gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgexpectedworkdays = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Testcaseid;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Employeeid;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedemployeeid;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgemployeeid;
		 

		protected DateTime gxTv_SdtGetEmployeeExpectedDaysTestSDT_Fromdate;
		 

		protected DateTime gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedfromdate;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgfromdate;
		 

		protected DateTime gxTv_SdtGetEmployeeExpectedDaysTestSDT_Todate;
		 

		protected DateTime gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedtodate;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgtodate;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Holidaycount;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedholidaycount;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgholidaycount;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Leavedays;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedleavedays;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgleavedays;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedworkdays;
		 

		protected long gxTv_SdtGetEmployeeExpectedDaysTestSDT_Expectedexpectedworkdays;
		 

		protected string gxTv_SdtGetEmployeeExpectedDaysTestSDT_Msgexpectedworkdays;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"GetEmployeeExpectedDaysTestSDT", Namespace="YTT_version4")]
	public class SdtGetEmployeeExpectedDaysTestSDT_RESTInterface : GxGenericCollectionItem<SdtGetEmployeeExpectedDaysTestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGetEmployeeExpectedDaysTestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtGetEmployeeExpectedDaysTestSDT_RESTInterface( SdtGetEmployeeExpectedDaysTestSDT psdt ) : base(psdt)
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

		[DataMember(Name="EmployeeId", Order=1)]
		public  string gxTpr_Employeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ExpectedEmployeeId", Order=2)]
		public  string gxTpr_Expectedemployeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedemployeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedemployeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MsgEmployeeId", Order=3)]
		public  string gxTpr_Msgemployeeid
		{
			get { 
				return sdt.gxTpr_Msgemployeeid;

			}
			set { 
				 sdt.gxTpr_Msgemployeeid = value;
			}
		}

		[DataMember(Name="FromDate", Order=4)]
		public  string gxTpr_Fromdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fromdate);

			}
			set { 
				sdt.gxTpr_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ExpectedFromDate", Order=5)]
		public  string gxTpr_Expectedfromdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Expectedfromdate);

			}
			set { 
				sdt.gxTpr_Expectedfromdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MsgFromDate", Order=6)]
		public  string gxTpr_Msgfromdate
		{
			get { 
				return sdt.gxTpr_Msgfromdate;

			}
			set { 
				 sdt.gxTpr_Msgfromdate = value;
			}
		}

		[DataMember(Name="ToDate", Order=7)]
		public  string gxTpr_Todate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Todate);

			}
			set { 
				sdt.gxTpr_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ExpectedToDate", Order=8)]
		public  string gxTpr_Expectedtodate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Expectedtodate);

			}
			set { 
				sdt.gxTpr_Expectedtodate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MsgToDate", Order=9)]
		public  string gxTpr_Msgtodate
		{
			get { 
				return sdt.gxTpr_Msgtodate;

			}
			set { 
				 sdt.gxTpr_Msgtodate = value;
			}
		}

		[DataMember(Name="HolidayCount", Order=10)]
		public  string gxTpr_Holidaycount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Holidaycount, 10, 0));

			}
			set { 
				sdt.gxTpr_Holidaycount = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ExpectedHolidayCount", Order=11)]
		public  string gxTpr_Expectedholidaycount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedholidaycount, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedholidaycount = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MsgHolidayCount", Order=12)]
		public  string gxTpr_Msgholidaycount
		{
			get { 
				return sdt.gxTpr_Msgholidaycount;

			}
			set { 
				 sdt.gxTpr_Msgholidaycount = value;
			}
		}

		[DataMember(Name="LeaveDays", Order=13)]
		public  string gxTpr_Leavedays
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leavedays, 10, 0));

			}
			set { 
				sdt.gxTpr_Leavedays = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ExpectedLeaveDays", Order=14)]
		public  string gxTpr_Expectedleavedays
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedleavedays, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedleavedays = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MsgLeaveDays", Order=15)]
		public  string gxTpr_Msgleavedays
		{
			get { 
				return sdt.gxTpr_Msgleavedays;

			}
			set { 
				 sdt.gxTpr_Msgleavedays = value;
			}
		}

		[DataMember(Name="ExpectedWorkDays", Order=16)]
		public  string gxTpr_Expectedworkdays
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedworkdays, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedworkdays = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ExpectedExpectedWorkDays", Order=17)]
		public  string gxTpr_Expectedexpectedworkdays
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedexpectedworkdays, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedexpectedworkdays = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MsgExpectedWorkDays", Order=18)]
		public  string gxTpr_Msgexpectedworkdays
		{
			get { 
				return sdt.gxTpr_Msgexpectedworkdays;

			}
			set { 
				 sdt.gxTpr_Msgexpectedworkdays = value;
			}
		}


		#endregion

		public SdtGetEmployeeExpectedDaysTestSDT sdt
		{
			get { 
				return (SdtGetEmployeeExpectedDaysTestSDT)Sdt;
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
				sdt = new SdtGetEmployeeExpectedDaysTestSDT() ;
			}
		}
	}
	#endregion
}