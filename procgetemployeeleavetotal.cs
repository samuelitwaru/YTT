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
   public class procgetemployeeleavetotal : GXProcedure
   {
      public procgetemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procgetemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out long aP3_TotalLeaveHours )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV8TotalLeaveHours = 0 ;
         initialize();
         executePrivate();
         aP3_TotalLeaveHours=this.AV8TotalLeaveHours;
      }

      public long executeUdp( long aP0_EmployeeId ,
                              DateTime aP1_DateFrom ,
                              DateTime aP2_DateTo )
      {
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_TotalLeaveHours);
         return AV8TotalLeaveHours ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out long aP3_TotalLeaveHours )
      {
         procgetemployeeleavetotal objprocgetemployeeleavetotal;
         objprocgetemployeeleavetotal = new procgetemployeeleavetotal();
         objprocgetemployeeleavetotal.AV11EmployeeId = aP0_EmployeeId;
         objprocgetemployeeleavetotal.AV10DateFrom = aP1_DateFrom;
         objprocgetemployeeleavetotal.AV9DateTo = aP2_DateTo;
         objprocgetemployeeleavetotal.AV8TotalLeaveHours = 0 ;
         objprocgetemployeeleavetotal.context.SetSubmitInitialConfig(context);
         objprocgetemployeeleavetotal.initialize();
         Submit( executePrivateCatch,objprocgetemployeeleavetotal);
         aP3_TotalLeaveHours=this.AV8TotalLeaveHours;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((procgetemployeeleavetotal)stateInfo).executePrivate();
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
         AV8TotalLeaveHours = 0;
         /* Optimized group. */
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV9DateTo, AV10DateFrom});
         c131LeaveRequestDuration = P00642_A131LeaveRequestDuration[0];
         pr_default.close(0);
         AV8TotalLeaveHours = (long)(AV8TotalLeaveHours+c131LeaveRequestDuration);
         /* End optimized group. */
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
         P00642_A131LeaveRequestDuration = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procgetemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P00642_A131LeaveRequestDuration
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11EmployeeId ;
      private long AV8TotalLeaveHours ;
      private long c131LeaveRequestDuration ;
      private string scmdbuf ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00642_A131LeaveRequestDuration ;
      private long aP3_TotalLeaveHours ;
   }

   public class procgetemployeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9DateTo",GXType.Date,8,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "SELECT SUM(T1.LeaveRequestDuration) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (T1.LeaveRequestStartDate < :AV9DateTo) AND (T1.LeaveRequestEndDate > :AV10DateFrom) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
