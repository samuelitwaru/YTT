using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class gxdomainwwptilesize
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainwwptilesize ()
      {
         domain[(short)0] = "1 block";
         domain[(short)1] = "2 blocks";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["OneBlock"] = (short)0;
            domainMap["TwoBlocks"] = (short)1;
         }
         return (short)domainMap[key] ;
      }

   }

}
