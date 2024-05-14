/*
				   File: type_SdtLocationHolidaysSDT_itemsItem_organizer
			Description: organizer
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
	[XmlRoot(ElementName="LocationHolidaysSDT.itemsItem.organizer")]
	[XmlType(TypeName="LocationHolidaysSDT.itemsItem.organizer" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHolidaysSDT_itemsItem_organizer : GxUserType
	{
		public SdtLocationHolidaysSDT_itemsItem_organizer( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Email = "";

			gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Displayname = "";

		}

		public SdtLocationHolidaysSDT_itemsItem_organizer(IGxContext context)
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
			AddObjectProperty("email", gxTpr_Email, false);


			AddObjectProperty("displayName", gxTpr_Displayname, false);


			AddObjectProperty("self", gxTpr_Self, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Email; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="displayName")]
		[XmlElement(ElementName="displayName")]
		public string gxTpr_Displayname
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Displayname; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Displayname = value;
				SetDirty("Displayname");
			}
		}




		[SoapElement(ElementName="self")]
		[XmlElement(ElementName="self")]
		public bool gxTpr_Self
		{
			get {
				return gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Self; 
			}
			set {
				gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Self = value;
				SetDirty("Self");
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
			gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Email = "";
			gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Displayname = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Email;
		 

		protected string gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Displayname;
		 

		protected bool gxTv_SdtLocationHolidaysSDT_itemsItem_organizer_Self;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"LocationHolidaysSDT.itemsItem.organizer", Namespace="YTT_version4")]
	public class SdtLocationHolidaysSDT_itemsItem_organizer_RESTInterface : GxGenericCollectionItem<SdtLocationHolidaysSDT_itemsItem_organizer>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHolidaysSDT_itemsItem_organizer_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHolidaysSDT_itemsItem_organizer_RESTInterface( SdtLocationHolidaysSDT_itemsItem_organizer psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="email", Order=0)]
		public  string gxTpr_Email
		{
			get { 
				return sdt.gxTpr_Email;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="displayName", Order=1)]
		public  string gxTpr_Displayname
		{
			get { 
				return sdt.gxTpr_Displayname;

			}
			set { 
				 sdt.gxTpr_Displayname = value;
			}
		}

		[DataMember(Name="self", Order=2)]
		public bool gxTpr_Self
		{
			get { 
				return sdt.gxTpr_Self;

			}
			set { 
				sdt.gxTpr_Self = value;
			}
		}


		#endregion

		public SdtLocationHolidaysSDT_itemsItem_organizer sdt
		{
			get { 
				return (SdtLocationHolidaysSDT_itemsItem_organizer)Sdt;
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
				sdt = new SdtLocationHolidaysSDT_itemsItem_organizer() ;
			}
		}
	}
	#endregion
}