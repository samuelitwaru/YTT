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
   [Serializable]
   public class SdtEO_GenerateEmail : GxUserType, IGxExternalObject
   {
      public SdtEO_GenerateEmail( )
      {
         /* Constructor for serialization */
      }

      public SdtEO_GenerateEmail( IGxContext context )
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

      public string formatcell( int gxTp_total ,
                                int gxTp_expected ,
                                bool gxTp_isHoliday )
      {
         string returnformatcell;
         returnformatcell = "";
         returnformatcell = (string)(GenerateEmail.GenerateEmail.FormatCell(gxTp_total, gxTp_expected, gxTp_isHoliday));
         return returnformatcell ;
      }

      public string getcss( )
      {
         string returngetcss;
         returngetcss = "";
         returngetcss = (string)(GenerateEmail.GenerateEmail.getCss());
         return returngetcss ;
      }

      public string generate( string gxTp_inputJson ,
                              string gxTp_fromDateString ,
                              string gxTp_toDateString )
      {
         string returngenerate;
         returngenerate = "";
         returngenerate = (string)(GenerateEmail.GenerateEmail.generate(gxTp_inputJson, gxTp_fromDateString, gxTp_toDateString));
         return returngenerate ;
      }

      public Object ExternalInstance
      {
         get {
            if ( EO_GenerateEmail_externalReference == null )
            {
               EO_GenerateEmail_externalReference = new GenerateEmail.GenerateEmail();
            }
            return EO_GenerateEmail_externalReference ;
         }

         set {
            EO_GenerateEmail_externalReference = (GenerateEmail.GenerateEmail)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected GenerateEmail.GenerateEmail EO_GenerateEmail_externalReference=null ;
   }

}
