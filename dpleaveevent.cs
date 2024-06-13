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
   public class dpleaveevent : GXProcedure
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

      public dpleaveevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleaveevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_CompanyLocationId ,
                           out GXBaseCollection<SdtSDTLeaveEvent> aP3_Gxm2rootcol )
      {
         this.AV5FromDate = aP0_FromDate;
         this.AV6ToDate = aP1_ToDate;
         this.AV7CompanyLocationId = aP2_CompanyLocationId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         initialize();
         executePrivate();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTLeaveEvent> executeUdp( DateTime aP0_FromDate ,
                                                            DateTime aP1_ToDate ,
                                                            long aP2_CompanyLocationId )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 out GXBaseCollection<SdtSDTLeaveEvent> aP3_Gxm2rootcol )
      {
         dpleaveevent objdpleaveevent;
         objdpleaveevent = new dpleaveevent();
         objdpleaveevent.AV5FromDate = aP0_FromDate;
         objdpleaveevent.AV6ToDate = aP1_ToDate;
         objdpleaveevent.AV7CompanyLocationId = aP2_CompanyLocationId;
         objdpleaveevent.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         objdpleaveevent.context.SetSubmitInitialConfig(context);
         objdpleaveevent.initialize();
         Submit( executePrivateCatch,objdpleaveevent);
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpleaveevent)stateInfo).executePrivate();
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
         /* Using cursor P001S2 */
         pr_default.execute(0, new Object[] {AV6ToDate, AV5FromDate, AV7CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P001S2_A124LeaveTypeId[0];
            A100CompanyId = P001S2_A100CompanyId[0];
            A130LeaveRequestEndDate = P001S2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P001S2_A129LeaveRequestStartDate[0];
            A157CompanyLocationId = P001S2_A157CompanyLocationId[0];
            A132LeaveRequestStatus = P001S2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P001S2_A127LeaveRequestId[0];
            A125LeaveTypeName = P001S2_A125LeaveTypeName[0];
            A106EmployeeId = P001S2_A106EmployeeId[0];
            A175LeaveTypeColorApproved = P001S2_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P001S2_n175LeaveTypeColorApproved[0];
            A100CompanyId = P001S2_A100CompanyId[0];
            A125LeaveTypeName = P001S2_A125LeaveTypeName[0];
            A175LeaveTypeColorApproved = P001S2_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P001S2_n175LeaveTypeColorApproved[0];
            A157CompanyLocationId = P001S2_A157CompanyLocationId[0];
            Gxm1sdtleaveevent = new SdtSDTLeaveEvent(context);
            Gxm2rootcol.Add(Gxm1sdtleaveevent, 0);
            Gxm1sdtleaveevent.gxTpr_Id = A127LeaveRequestId;
            Gxm1sdtleaveevent.gxTpr_Content = StringUtil.Trim( A125LeaveTypeName);
            GXt_char1 = "";
            new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYY-MM-DD", out  GXt_char1) ;
            Gxm1sdtleaveevent.gxTpr_Start = GXt_char1;
            GXt_char1 = "";
            new formatdatetime(context ).execute(  DateTimeUtil.DAdd( A130LeaveRequestEndDate, (1)),  "YYYY-MM-DD", out  GXt_char1) ;
            Gxm1sdtleaveevent.gxTpr_End = GXt_char1;
            Gxm1sdtleaveevent.gxTpr_Group = (short)(A106EmployeeId);
            Gxm1sdtleaveevent.gxTpr_Classname = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? "ApprovedLeave" : "PendingLeave "+StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0));
            Gxm1sdtleaveevent.gxTpr_Color = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? StringUtil.Trim( A175LeaveTypeColorApproved) : "#DDDDDD");
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
         P001S2_A124LeaveTypeId = new long[1] ;
         P001S2_A100CompanyId = new long[1] ;
         P001S2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P001S2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P001S2_A157CompanyLocationId = new long[1] ;
         P001S2_A132LeaveRequestStatus = new string[] {""} ;
         P001S2_A127LeaveRequestId = new long[1] ;
         P001S2_A125LeaveTypeName = new string[] {""} ;
         P001S2_A106EmployeeId = new long[1] ;
         P001S2_A175LeaveTypeColorApproved = new string[] {""} ;
         P001S2_n175LeaveTypeColorApproved = new bool[] {false} ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A175LeaveTypeColorApproved = "";
         Gxm1sdtleaveevent = new SdtSDTLeaveEvent(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpleaveevent__default(),
            new Object[][] {
                new Object[] {
               P001S2_A124LeaveTypeId, P001S2_A100CompanyId, P001S2_A130LeaveRequestEndDate, P001S2_A129LeaveRequestStartDate, P001S2_A157CompanyLocationId, P001S2_A132LeaveRequestStatus, P001S2_A127LeaveRequestId, P001S2_A125LeaveTypeName, P001S2_A106EmployeeId, P001S2_A175LeaveTypeColorApproved,
               P001S2_n175LeaveTypeColorApproved
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV7CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A127LeaveRequestId ;
      private long A106EmployeeId ;
      private string scmdbuf ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A175LeaveTypeColorApproved ;
      private string GXt_char1 ;
      private DateTime AV5FromDate ;
      private DateTime AV6ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool n175LeaveTypeColorApproved ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P001S2_A124LeaveTypeId ;
      private long[] P001S2_A100CompanyId ;
      private DateTime[] P001S2_A130LeaveRequestEndDate ;
      private DateTime[] P001S2_A129LeaveRequestStartDate ;
      private long[] P001S2_A157CompanyLocationId ;
      private string[] P001S2_A132LeaveRequestStatus ;
      private long[] P001S2_A127LeaveRequestId ;
      private string[] P001S2_A125LeaveTypeName ;
      private long[] P001S2_A106EmployeeId ;
      private string[] P001S2_A175LeaveTypeColorApproved ;
      private bool[] P001S2_n175LeaveTypeColorApproved ;
      private GXBaseCollection<SdtSDTLeaveEvent> aP3_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTLeaveEvent> Gxm2rootcol ;
      private SdtSDTLeaveEvent Gxm1sdtleaveevent ;
   }

   public class dpleaveevent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001S2;
          prmP001S2 = new Object[] {
          new ParDef("AV6ToDate",GXType.Date,8,0) ,
          new ParDef("AV5FromDate",GXType.Date,8,0) ,
          new ParDef("AV7CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001S2", "SELECT T1.LeaveTypeId, T2.CompanyId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T3.CompanyLocationId, T1.LeaveRequestStatus, T1.LeaveRequestId, T2.LeaveTypeName, T1.EmployeeId, T2.LeaveTypeColorApproved FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) WHERE (T1.LeaveRequestStatus = ( 'Approved') or T1.LeaveRequestStatus = ( 'Pending')) AND (T1.LeaveRequestStartDate <= :AV6ToDate) AND (T1.LeaveRequestEndDate >= :AV5FromDate) AND (T3.CompanyLocationId = :AV7CompanyLocationId) ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001S2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
