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
   public class checkemployeependingvacationleave : GXProcedure
   {
      public checkemployeependingvacationleave( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public checkemployeependingvacationleave( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out bool aP1_HasPendingLeave )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV8HasPendingLeave = false ;
         initialize();
         executePrivate();
         aP1_HasPendingLeave=this.AV8HasPendingLeave;
      }

      public bool executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_HasPendingLeave);
         return AV8HasPendingLeave ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out bool aP1_HasPendingLeave )
      {
         checkemployeependingvacationleave objcheckemployeependingvacationleave;
         objcheckemployeependingvacationleave = new checkemployeependingvacationleave();
         objcheckemployeependingvacationleave.AV9EmployeeId = aP0_EmployeeId;
         objcheckemployeependingvacationleave.AV8HasPendingLeave = false ;
         objcheckemployeependingvacationleave.context.SetSubmitInitialConfig(context);
         objcheckemployeependingvacationleave.initialize();
         Submit( executePrivateCatch,objcheckemployeependingvacationleave);
         aP1_HasPendingLeave=this.AV8HasPendingLeave;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((checkemployeependingvacationleave)stateInfo).executePrivate();
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
         AV8HasPendingLeave = false;
         /* Using cursor P009A2 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P009A2_A124LeaveTypeId[0];
            A106EmployeeId = P009A2_A106EmployeeId[0];
            A144LeaveTypeVacationLeave = P009A2_A144LeaveTypeVacationLeave[0];
            A132LeaveRequestStatus = P009A2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P009A2_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P009A2_A144LeaveTypeVacationLeave[0];
            AV8HasPendingLeave = true;
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
         P009A2_A124LeaveTypeId = new long[1] ;
         P009A2_A106EmployeeId = new long[1] ;
         P009A2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P009A2_A132LeaveRequestStatus = new string[] {""} ;
         P009A2_A127LeaveRequestId = new long[1] ;
         A144LeaveTypeVacationLeave = "";
         A132LeaveRequestStatus = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.checkemployeependingvacationleave__default(),
            new Object[][] {
                new Object[] {
               P009A2_A124LeaveTypeId, P009A2_A106EmployeeId, P009A2_A144LeaveTypeVacationLeave, P009A2_A132LeaveRequestStatus, P009A2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string scmdbuf ;
      private string A144LeaveTypeVacationLeave ;
      private string A132LeaveRequestStatus ;
      private bool AV8HasPendingLeave ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009A2_A124LeaveTypeId ;
      private long[] P009A2_A106EmployeeId ;
      private string[] P009A2_A144LeaveTypeVacationLeave ;
      private string[] P009A2_A132LeaveRequestStatus ;
      private long[] P009A2_A127LeaveRequestId ;
      private bool aP1_HasPendingLeave ;
   }

   public class checkemployeependingvacationleave__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009A2;
          prmP009A2 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009A2", "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV9EmployeeId) AND (T1.LeaveRequestStatus = ( 'Pending')) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
