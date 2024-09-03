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
         AV8TotalLeaveHours = 0;
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV9DateTo, AV10DateFrom});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00642_A124LeaveTypeId[0];
            A145LeaveTypeLoggingWorkHours = P00642_A145LeaveTypeLoggingWorkHours[0];
            A130LeaveRequestEndDate = P00642_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00642_A129LeaveRequestStartDate[0];
            A106EmployeeId = P00642_A106EmployeeId[0];
            A132LeaveRequestStatus = P00642_A132LeaveRequestStatus[0];
            A173LeaveRequestHalfDay = P00642_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00642_n173LeaveRequestHalfDay[0];
            A127LeaveRequestId = P00642_A127LeaveRequestId[0];
            A145LeaveTypeLoggingWorkHours = P00642_A145LeaveTypeLoggingWorkHours[0];
            GXt_decimal1 = (decimal)(AV30Var);
            new getleaverequestdays(context ).execute(  AV10DateFrom,  AV9DateTo,  A173LeaveRequestHalfDay,  A106EmployeeId, out  GXt_decimal1) ;
            AV30Var = (short)(Math.Round(GXt_decimal1, 18, MidpointRounding.ToEven));
            new logtofile(context ).execute(  ">>>>>>>>>>>"+StringUtil.Str( (decimal)(AV30Var), 4, 0)) ;
            AV8TotalLeaveHours = (long)(AV8TotalLeaveHours+AV30Var);
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
         P00642_A124LeaveTypeId = new long[1] ;
         P00642_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00642_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00642_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00642_A106EmployeeId = new long[1] ;
         P00642_A132LeaveRequestStatus = new string[] {""} ;
         P00642_A173LeaveRequestHalfDay = new string[] {""} ;
         P00642_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00642_A127LeaveRequestId = new long[1] ;
         A145LeaveTypeLoggingWorkHours = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A173LeaveRequestHalfDay = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procgetemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P00642_A124LeaveTypeId, P00642_A145LeaveTypeLoggingWorkHours, P00642_A130LeaveRequestEndDate, P00642_A129LeaveRequestStartDate, P00642_A106EmployeeId, P00642_A132LeaveRequestStatus, P00642_A173LeaveRequestHalfDay, P00642_n173LeaveRequestHalfDay, P00642_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30Var ;
      private long AV11EmployeeId ;
      private long AV8TotalLeaveHours ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A132LeaveRequestStatus ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00642_A124LeaveTypeId ;
      private string[] P00642_A145LeaveTypeLoggingWorkHours ;
      private DateTime[] P00642_A130LeaveRequestEndDate ;
      private DateTime[] P00642_A129LeaveRequestStartDate ;
      private long[] P00642_A106EmployeeId ;
      private string[] P00642_A132LeaveRequestStatus ;
      private string[] P00642_A173LeaveRequestHalfDay ;
      private bool[] P00642_n173LeaveRequestHalfDay ;
      private long[] P00642_A127LeaveRequestId ;
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
              new CursorDef("P00642", "SELECT T1.LeaveTypeId, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (T1.LeaveRequestStartDate < :AV9DateTo) AND (T1.LeaveRequestEndDate > :AV10DateFrom) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
