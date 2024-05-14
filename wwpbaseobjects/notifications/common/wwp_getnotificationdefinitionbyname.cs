using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationdefinitionbyname : GXProcedure
   {
      public wwp_getnotificationdefinitionbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationdefinitionbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           long aP1_WWPEntityId ,
                           out long aP2_WWPNotificationDefinitionId )
      {
         this.AV10WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV8WWPEntityId = aP1_WWPEntityId;
         this.AV9WWPNotificationDefinitionId = 0 ;
         initialize();
         executePrivate();
         aP2_WWPNotificationDefinitionId=this.AV9WWPNotificationDefinitionId;
      }

      public long executeUdp( string aP0_WWPNotificationDefinitionName ,
                              long aP1_WWPEntityId )
      {
         execute(aP0_WWPNotificationDefinitionName, aP1_WWPEntityId, out aP2_WWPNotificationDefinitionId);
         return AV9WWPNotificationDefinitionId ;
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 long aP1_WWPEntityId ,
                                 out long aP2_WWPNotificationDefinitionId )
      {
         wwp_getnotificationdefinitionbyname objwwp_getnotificationdefinitionbyname;
         objwwp_getnotificationdefinitionbyname = new wwp_getnotificationdefinitionbyname();
         objwwp_getnotificationdefinitionbyname.AV10WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_getnotificationdefinitionbyname.AV8WWPEntityId = aP1_WWPEntityId;
         objwwp_getnotificationdefinitionbyname.AV9WWPNotificationDefinitionId = 0 ;
         objwwp_getnotificationdefinitionbyname.context.SetSubmitInitialConfig(context);
         objwwp_getnotificationdefinitionbyname.initialize();
         Submit( executePrivateCatch,objwwp_getnotificationdefinitionbyname);
         aP2_WWPNotificationDefinitionId=this.AV9WWPNotificationDefinitionId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getnotificationdefinitionbyname)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WWPNotificationDefinitionId = 0;
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20WWPEntityId = P002K2_A20WWPEntityId[0];
            A59WWPNotificationDefinitionName = P002K2_A59WWPNotificationDefinitionName[0];
            A23WWPNotificationDefinitionId = P002K2_A23WWPNotificationDefinitionId[0];
            AV9WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P002K2_A20WWPEntityId = new long[1] ;
         P002K2_A59WWPNotificationDefinitionName = new string[] {""} ;
         P002K2_A23WWPNotificationDefinitionId = new long[1] ;
         A59WWPNotificationDefinitionName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationdefinitionbyname__default(),
            new Object[][] {
                new Object[] {
               P002K2_A20WWPEntityId, P002K2_A59WWPNotificationDefinitionName, P002K2_A23WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPEntityId ;
      private long AV9WWPNotificationDefinitionId ;
      private long A20WWPEntityId ;
      private long A23WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private string AV10WWPNotificationDefinitionName ;
      private string A59WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002K2_A20WWPEntityId ;
      private string[] P002K2_A59WWPNotificationDefinitionName ;
      private long[] P002K2_A23WWPNotificationDefinitionId ;
      private long aP2_WWPNotificationDefinitionId ;
   }

   public class wwp_getnotificationdefinitionbyname__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new ParDef("AV8WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("AV10WWPNotificationDefinitionName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "SELECT WWPEntityId, WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV8WWPEntityId) AND (WWPNotificationDefinitionName = ( :AV10WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
