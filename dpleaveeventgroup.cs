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
   public class dpleaveeventgroup : GXProcedure
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

      public dpleaveeventgroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleaveeventgroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_CompanyLocationId ,
                           out GXBaseCollection<SdtSDTLeaveEventGroup> aP3_Gxm2rootcol )
      {
         this.AV5FromDate = aP0_FromDate;
         this.AV6ToDate = aP1_ToDate;
         this.AV7CompanyLocationId = aP2_CompanyLocationId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEventGroup>( context, "SDTLeaveEventGroup", "YTT_version4") ;
         initialize();
         executePrivate();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTLeaveEventGroup> executeUdp( DateTime aP0_FromDate ,
                                                                 DateTime aP1_ToDate ,
                                                                 long aP2_CompanyLocationId )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 out GXBaseCollection<SdtSDTLeaveEventGroup> aP3_Gxm2rootcol )
      {
         dpleaveeventgroup objdpleaveeventgroup;
         objdpleaveeventgroup = new dpleaveeventgroup();
         objdpleaveeventgroup.AV5FromDate = aP0_FromDate;
         objdpleaveeventgroup.AV6ToDate = aP1_ToDate;
         objdpleaveeventgroup.AV7CompanyLocationId = aP2_CompanyLocationId;
         objdpleaveeventgroup.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEventGroup>( context, "SDTLeaveEventGroup", "YTT_version4") ;
         objdpleaveeventgroup.context.SetSubmitInitialConfig(context);
         objdpleaveeventgroup.initialize();
         Submit( executePrivateCatch,objdpleaveeventgroup);
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpleaveeventgroup)stateInfo).executePrivate();
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
         /* Using cursor P001T2 */
         pr_default.execute(0, new Object[] {AV7CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P001T2_A124LeaveTypeId[0];
            A100CompanyId = P001T2_A100CompanyId[0];
            A157CompanyLocationId = P001T2_A157CompanyLocationId[0];
            A132LeaveRequestStatus = P001T2_A132LeaveRequestStatus[0];
            A148EmployeeName = P001T2_A148EmployeeName[0];
            A106EmployeeId = P001T2_A106EmployeeId[0];
            A100CompanyId = P001T2_A100CompanyId[0];
            A157CompanyLocationId = P001T2_A157CompanyLocationId[0];
            A148EmployeeName = P001T2_A148EmployeeName[0];
            Gxm1sdtleaveeventgroup = new SdtSDTLeaveEventGroup(context);
            Gxm2rootcol.Add(Gxm1sdtleaveeventgroup, 0);
            Gxm1sdtleaveeventgroup.gxTpr_Id = (short)(A106EmployeeId);
            Gxm1sdtleaveeventgroup.gxTpr_Content = StringUtil.Trim( A148EmployeeName);
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
         P001T2_A124LeaveTypeId = new long[1] ;
         P001T2_A100CompanyId = new long[1] ;
         P001T2_A157CompanyLocationId = new long[1] ;
         P001T2_A132LeaveRequestStatus = new string[] {""} ;
         P001T2_A148EmployeeName = new string[] {""} ;
         P001T2_A106EmployeeId = new long[1] ;
         A132LeaveRequestStatus = "";
         A148EmployeeName = "";
         Gxm1sdtleaveeventgroup = new SdtSDTLeaveEventGroup(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpleaveeventgroup__default(),
            new Object[][] {
                new Object[] {
               P001T2_A124LeaveTypeId, P001T2_A100CompanyId, P001T2_A157CompanyLocationId, P001T2_A132LeaveRequestStatus, P001T2_A148EmployeeName, P001T2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV7CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private string scmdbuf ;
      private string A132LeaveRequestStatus ;
      private string A148EmployeeName ;
      private DateTime AV5FromDate ;
      private DateTime AV6ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P001T2_A124LeaveTypeId ;
      private long[] P001T2_A100CompanyId ;
      private long[] P001T2_A157CompanyLocationId ;
      private string[] P001T2_A132LeaveRequestStatus ;
      private string[] P001T2_A148EmployeeName ;
      private long[] P001T2_A106EmployeeId ;
      private GXBaseCollection<SdtSDTLeaveEventGroup> aP3_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTLeaveEventGroup> Gxm2rootcol ;
      private SdtSDTLeaveEventGroup Gxm1sdtleaveeventgroup ;
   }

   public class dpleaveeventgroup__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001T2;
          prmP001T2 = new Object[] {
          new ParDef("AV7CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001T2", "SELECT DISTINCT NULL AS LeaveTypeId, NULL AS CompanyId, NULL AS CompanyLocationId, NULL AS LeaveRequestStatus, EmployeeName, EmployeeId FROM ( SELECT T1.LeaveTypeId, T2.CompanyId, T3.CompanyLocationId, T1.LeaveRequestStatus, T4.EmployeeName, T1.EmployeeId FROM (((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Employee T4 ON T4.EmployeeId = T1.EmployeeId) WHERE (T1.LeaveRequestStatus = ( 'Approved') or T1.LeaveRequestStatus = ( 'Pending')) AND (T3.CompanyLocationId = :AV7CompanyLocationId) ORDER BY T1.EmployeeId) DistinctT ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001T2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 128);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
