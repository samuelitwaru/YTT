/*
				   File: type_SdtCreateEmployeeAccount1TestSDT
			Description: CreateEmployeeAccount1TestSDT
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
	[XmlRoot(ElementName="CreateEmployeeAccount1TestSDT")]
	[XmlType(TypeName="CreateEmployeeAccount1TestSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtCreateEmployeeAccount1TestSDT : GxUserType
	{
		public SdtCreateEmployeeAccount1TestSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateEmployeeAccount1TestSDT_Testcaseid = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeeemail = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeefirstname = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeelastname = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Rolesstring = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Gamuserguid = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Expectedgamuserguid = "";

			gxTv_SdtCreateEmployeeAccount1TestSDT_Msggamuserguid = "";

		}

		public SdtCreateEmployeeAccount1TestSDT(IGxContext context)
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


			AddObjectProperty("EmployeeEmail", gxTpr_Employeeemail, false);


			AddObjectProperty("EmployeeFirstName", gxTpr_Employeefirstname, false);


			AddObjectProperty("EmployeeLastName", gxTpr_Employeelastname, false);


			AddObjectProperty("RolesString", gxTpr_Rolesstring, false);


			AddObjectProperty("GAMUserGUID", gxTpr_Gamuserguid, false);


			AddObjectProperty("ExpectedGAMUserGUID", gxTpr_Expectedgamuserguid, false);


			AddObjectProperty("MsgGAMUserGUID", gxTpr_Msggamuserguid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TestCaseId")]
		[XmlElement(ElementName="TestCaseId")]
		public string gxTpr_Testcaseid
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Testcaseid; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Testcaseid = value;
				SetDirty("Testcaseid");
			}
		}




		[SoapElement(ElementName="EmployeeEmail")]
		[XmlElement(ElementName="EmployeeEmail")]
		public string gxTpr_Employeeemail
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Employeeemail; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Employeeemail = value;
				SetDirty("Employeeemail");
			}
		}




		[SoapElement(ElementName="EmployeeFirstName")]
		[XmlElement(ElementName="EmployeeFirstName")]
		public string gxTpr_Employeefirstname
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Employeefirstname; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Employeefirstname = value;
				SetDirty("Employeefirstname");
			}
		}




		[SoapElement(ElementName="EmployeeLastName")]
		[XmlElement(ElementName="EmployeeLastName")]
		public string gxTpr_Employeelastname
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Employeelastname; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Employeelastname = value;
				SetDirty("Employeelastname");
			}
		}




		[SoapElement(ElementName="RolesString")]
		[XmlElement(ElementName="RolesString")]
		public string gxTpr_Rolesstring
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Rolesstring; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Rolesstring = value;
				SetDirty("Rolesstring");
			}
		}




		[SoapElement(ElementName="GAMUserGUID")]
		[XmlElement(ElementName="GAMUserGUID")]
		public string gxTpr_Gamuserguid
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Gamuserguid; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Gamuserguid = value;
				SetDirty("Gamuserguid");
			}
		}




		[SoapElement(ElementName="ExpectedGAMUserGUID")]
		[XmlElement(ElementName="ExpectedGAMUserGUID")]
		public string gxTpr_Expectedgamuserguid
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Expectedgamuserguid; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Expectedgamuserguid = value;
				SetDirty("Expectedgamuserguid");
			}
		}




		[SoapElement(ElementName="MsgGAMUserGUID")]
		[XmlElement(ElementName="MsgGAMUserGUID")]
		public string gxTpr_Msggamuserguid
		{
			get {
				return gxTv_SdtCreateEmployeeAccount1TestSDT_Msggamuserguid; 
			}
			set {
				gxTv_SdtCreateEmployeeAccount1TestSDT_Msggamuserguid = value;
				SetDirty("Msggamuserguid");
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
			gxTv_SdtCreateEmployeeAccount1TestSDT_Testcaseid = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeeemail = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeefirstname = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Employeelastname = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Rolesstring = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Gamuserguid = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Expectedgamuserguid = "";
			gxTv_SdtCreateEmployeeAccount1TestSDT_Msggamuserguid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Testcaseid;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Employeeemail;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Employeefirstname;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Employeelastname;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Rolesstring;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Gamuserguid;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Expectedgamuserguid;
		 

		protected string gxTv_SdtCreateEmployeeAccount1TestSDT_Msggamuserguid;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"CreateEmployeeAccount1TestSDT", Namespace="YTT_version4")]
	public class SdtCreateEmployeeAccount1TestSDT_RESTInterface : GxGenericCollectionItem<SdtCreateEmployeeAccount1TestSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateEmployeeAccount1TestSDT_RESTInterface( ) : base()
		{	
		}

		public SdtCreateEmployeeAccount1TestSDT_RESTInterface( SdtCreateEmployeeAccount1TestSDT psdt ) : base(psdt)
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

		[DataMember(Name="EmployeeEmail", Order=1)]
		public  string gxTpr_Employeeemail
		{
			get { 
				return sdt.gxTpr_Employeeemail;

			}
			set { 
				 sdt.gxTpr_Employeeemail = value;
			}
		}

		[DataMember(Name="EmployeeFirstName", Order=2)]
		public  string gxTpr_Employeefirstname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeefirstname);

			}
			set { 
				 sdt.gxTpr_Employeefirstname = value;
			}
		}

		[DataMember(Name="EmployeeLastName", Order=3)]
		public  string gxTpr_Employeelastname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeelastname);

			}
			set { 
				 sdt.gxTpr_Employeelastname = value;
			}
		}

		[DataMember(Name="RolesString", Order=4)]
		public  string gxTpr_Rolesstring
		{
			get { 
				return sdt.gxTpr_Rolesstring;

			}
			set { 
				 sdt.gxTpr_Rolesstring = value;
			}
		}

		[DataMember(Name="GAMUserGUID", Order=5)]
		public  string gxTpr_Gamuserguid
		{
			get { 
				return sdt.gxTpr_Gamuserguid;

			}
			set { 
				 sdt.gxTpr_Gamuserguid = value;
			}
		}

		[DataMember(Name="ExpectedGAMUserGUID", Order=6)]
		public  string gxTpr_Expectedgamuserguid
		{
			get { 
				return sdt.gxTpr_Expectedgamuserguid;

			}
			set { 
				 sdt.gxTpr_Expectedgamuserguid = value;
			}
		}

		[DataMember(Name="MsgGAMUserGUID", Order=7)]
		public  string gxTpr_Msggamuserguid
		{
			get { 
				return sdt.gxTpr_Msggamuserguid;

			}
			set { 
				 sdt.gxTpr_Msggamuserguid = value;
			}
		}


		#endregion

		public SdtCreateEmployeeAccount1TestSDT sdt
		{
			get { 
				return (SdtCreateEmployeeAccount1TestSDT)Sdt;
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
				sdt = new SdtCreateEmployeeAccount1TestSDT() ;
			}
		}
	}
	#endregion
}