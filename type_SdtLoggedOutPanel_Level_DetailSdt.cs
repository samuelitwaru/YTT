using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "LoggedOutPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "LoggedOutPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtLoggedOutPanel_Level_DetailSdt : GxUserType
   {
      public SdtLoggedOutPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
      }

      public SdtLoggedOutPanel_Level_DetailSdt( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         return  ;
      }

      public void initialize( )
      {
         return  ;
      }

   }

   [DataContract(Name = @"LoggedOutPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtLoggedOutPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtLoggedOutPanel_Level_DetailSdt>
   {
      public SdtLoggedOutPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtLoggedOutPanel_Level_DetailSdt_RESTInterface( SdtLoggedOutPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      public SdtLoggedOutPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtLoggedOutPanel_Level_DetailSdt)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLoggedOutPanel_Level_DetailSdt() ;
         }
      }

   }

}
