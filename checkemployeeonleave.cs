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
   public class checkemployeeonleave : GXProcedure
   {
      public checkemployeeonleave( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public checkemployeeonleave( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_RequestStartDate ,
                           long aP1_EmployeeId ,
                           out bool aP2_ValidDate )
      {
         this.AV8RequestStartDate = aP0_RequestStartDate;
         this.AV10EmployeeId = aP1_EmployeeId;
         this.AV9ValidDate = false ;
         initialize();
         executePrivate();
         aP2_ValidDate=this.AV9ValidDate;
      }

      public bool executeUdp( DateTime aP0_RequestStartDate ,
                              long aP1_EmployeeId )
      {
         execute(aP0_RequestStartDate, aP1_EmployeeId, out aP2_ValidDate);
         return AV9ValidDate ;
      }

      public void executeSubmit( DateTime aP0_RequestStartDate ,
                                 long aP1_EmployeeId ,
                                 out bool aP2_ValidDate )
      {
         checkemployeeonleave objcheckemployeeonleave;
         objcheckemployeeonleave = new checkemployeeonleave();
         objcheckemployeeonleave.AV8RequestStartDate = aP0_RequestStartDate;
         objcheckemployeeonleave.AV10EmployeeId = aP1_EmployeeId;
         objcheckemployeeonleave.AV9ValidDate = false ;
         objcheckemployeeonleave.context.SetSubmitInitialConfig(context);
         objcheckemployeeonleave.initialize();
         Submit( executePrivateCatch,objcheckemployeeonleave);
         aP2_ValidDate=this.AV9ValidDate;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((checkemployeeonleave)stateInfo).executePrivate();
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
         AV11GXLvl1 = 0;
         /* Using cursor P007H2 */
         pr_default.execute(0, new Object[] {AV10EmployeeId, AV8RequestStartDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130LeaveRequestEndDate = P007H2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P007H2_A129LeaveRequestStartDate[0];
            A106EmployeeId = P007H2_A106EmployeeId[0];
            A132LeaveRequestStatus = P007H2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P007H2_A127LeaveRequestId[0];
            AV11GXLvl1 = 1;
            AV9ValidDate = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl1 == 0 )
         {
            AV9ValidDate = false;
         }
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
         P007H2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P007H2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P007H2_A106EmployeeId = new long[1] ;
         P007H2_A132LeaveRequestStatus = new string[] {""} ;
         P007H2_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.checkemployeeonleave__default(),
            new Object[][] {
                new Object[] {
               P007H2_A130LeaveRequestEndDate, P007H2_A129LeaveRequestStartDate, P007H2_A106EmployeeId, P007H2_A132LeaveRequestStatus, P007H2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl1 ;
      private long AV10EmployeeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string scmdbuf ;
      private string A132LeaveRequestStatus ;
      private DateTime AV8RequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool AV9ValidDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P007H2_A130LeaveRequestEndDate ;
      private DateTime[] P007H2_A129LeaveRequestStartDate ;
      private long[] P007H2_A106EmployeeId ;
      private string[] P007H2_A132LeaveRequestStatus ;
      private long[] P007H2_A127LeaveRequestId ;
      private bool aP2_ValidDate ;
   }

   public class checkemployeeonleave__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007H2;
          prmP007H2 = new Object[] {
          new ParDef("AV10EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV8RequestStartDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007H2", "SELECT LeaveRequestEndDate, LeaveRequestStartDate, EmployeeId, LeaveRequestStatus, LeaveRequestId FROM LeaveRequest WHERE (EmployeeId = :AV10EmployeeId) AND (LeaveRequestStartDate < :AV8RequestStartDate and LeaveRequestEndDate > :AV8RequestStartDate) AND (LeaveRequestStatus = ( 'Approved')) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
