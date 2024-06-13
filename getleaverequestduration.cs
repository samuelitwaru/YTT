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
namespace GeneXus.Programs {
   public class getleaverequestduration : GXProcedure
   {
      public getleaverequestduration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getleaverequestduration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           out decimal aP1_LeaveRequestDuration )
      {
         this.AV8LeaveRequestId = aP0_LeaveRequestId;
         this.AV9LeaveRequestDuration = 0 ;
         initialize();
         executePrivate();
         aP1_LeaveRequestDuration=this.AV9LeaveRequestDuration;
      }

      public decimal executeUdp( long aP0_LeaveRequestId )
      {
         execute(aP0_LeaveRequestId, out aP1_LeaveRequestDuration);
         return AV9LeaveRequestDuration ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 out decimal aP1_LeaveRequestDuration )
      {
         getleaverequestduration objgetleaverequestduration;
         objgetleaverequestduration = new getleaverequestduration();
         objgetleaverequestduration.AV8LeaveRequestId = aP0_LeaveRequestId;
         objgetleaverequestduration.AV9LeaveRequestDuration = 0 ;
         objgetleaverequestduration.context.SetSubmitInitialConfig(context);
         objgetleaverequestduration.initialize();
         Submit( executePrivateCatch,objgetleaverequestduration);
         aP1_LeaveRequestDuration=this.AV9LeaveRequestDuration;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getleaverequestduration)stateInfo).executePrivate();
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
         /* Using cursor P009N2 */
         pr_default.execute(0, new Object[] {AV8LeaveRequestId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127LeaveRequestId = P009N2_A127LeaveRequestId[0];
            A131LeaveRequestDuration = P009N2_A131LeaveRequestDuration[0];
            AV9LeaveRequestDuration = A131LeaveRequestDuration;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P009N2_A127LeaveRequestId = new long[1] ;
         P009N2_A131LeaveRequestDuration = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getleaverequestduration__default(),
            new Object[][] {
                new Object[] {
               P009N2_A127LeaveRequestId, P009N2_A131LeaveRequestDuration
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8LeaveRequestId ;
      private long A127LeaveRequestId ;
      private decimal AV9LeaveRequestDuration ;
      private decimal A131LeaveRequestDuration ;
      private string scmdbuf ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009N2_A127LeaveRequestId ;
      private decimal[] P009N2_A131LeaveRequestDuration ;
      private decimal aP1_LeaveRequestDuration ;
   }

   public class getleaverequestduration__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009N2;
          prmP009N2 = new Object[] {
          new ParDef("AV8LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009N2", "SELECT LeaveRequestId, LeaveRequestDuration FROM LeaveRequest WHERE LeaveRequestId = :AV8LeaveRequestId ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009N2,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
