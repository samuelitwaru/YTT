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
   public class jsganttprovider2 : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public jsganttprovider2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public jsganttprovider2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtjsGanttTask>( context, "jsGanttTask", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtjsGanttTask> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol )
      {
         jsganttprovider2 objjsganttprovider2;
         objjsganttprovider2 = new jsganttprovider2();
         objjsganttprovider2.Gxm2rootcol = new GXBaseCollection<SdtjsGanttTask>( context, "jsGanttTask", "YTT_version4") ;
         objjsganttprovider2.context.SetSubmitInitialConfig(context);
         objjsganttprovider2.initialize();
         Submit( executePrivateCatch,objjsganttprovider2);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((jsganttprovider2)stateInfo).executePrivate();
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
         /* Using cursor P001R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P001R2_A124LeaveTypeId[0];
            A106EmployeeId = P001R2_A106EmployeeId[0];
            A127LeaveRequestId = P001R2_A127LeaveRequestId[0];
            A125LeaveTypeName = P001R2_A125LeaveTypeName[0];
            A148EmployeeName = P001R2_A148EmployeeName[0];
            A125LeaveTypeName = P001R2_A125LeaveTypeName[0];
            A148EmployeeName = P001R2_A148EmployeeName[0];
            Gxm1jsgantttask = new SdtjsGanttTask(context);
            Gxm2rootcol.Add(Gxm1jsgantttask, 0);
            Gxm1jsgantttask.gxTpr_Pid = (short)(A127LeaveRequestId);
            Gxm1jsgantttask.gxTpr_Pname = A125LeaveTypeName;
            Gxm1jsgantttask.gxTpr_Pstart = "2024-01-01";
            Gxm1jsgantttask.gxTpr_Pend = "2024-31-01";
            Gxm1jsgantttask.gxTpr_Pcolor = "ff0000";
            Gxm1jsgantttask.gxTpr_Plink = "http://www.gxtechnical.com/cp";
            Gxm1jsgantttask.gxTpr_Pmile = 0;
            Gxm1jsgantttask.gxTpr_Pres = A148EmployeeName;
            Gxm1jsgantttask.gxTpr_Pcomp = 0;
            Gxm1jsgantttask.gxTpr_Pgroup = 1;
            Gxm1jsgantttask.gxTpr_Pparent = 0;
            Gxm1jsgantttask.gxTpr_Popen = 0;
            Gxm1jsgantttask.gxTpr_Pdepend = "";
            Gxm1jsgantttask.gxTpr_Pcaption = "Task for cp2";
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
         P001R2_A124LeaveTypeId = new long[1] ;
         P001R2_A106EmployeeId = new long[1] ;
         P001R2_A127LeaveRequestId = new long[1] ;
         P001R2_A125LeaveTypeName = new string[] {""} ;
         P001R2_A148EmployeeName = new string[] {""} ;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         Gxm1jsgantttask = new SdtjsGanttTask(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.jsganttprovider2__default(),
            new Object[][] {
                new Object[] {
               P001R2_A124LeaveTypeId, P001R2_A106EmployeeId, P001R2_A127LeaveRequestId, P001R2_A125LeaveTypeName, P001R2_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string scmdbuf ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P001R2_A124LeaveTypeId ;
      private long[] P001R2_A106EmployeeId ;
      private long[] P001R2_A127LeaveRequestId ;
      private string[] P001R2_A125LeaveTypeName ;
      private string[] P001R2_A148EmployeeName ;
      private GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtjsGanttTask> Gxm2rootcol ;
      private SdtjsGanttTask Gxm1jsgantttask ;
   }

   public class jsganttprovider2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001R2;
          prmP001R2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P001R2", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestId, T2.LeaveTypeName, T3.EmployeeName FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 128);
                return;
       }
    }

 }

}
