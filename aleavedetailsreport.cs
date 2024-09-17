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
   public class aleavedetailsreport : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aleavedetailsreport().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

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

      public aleavedetailsreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aleavedetailsreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aleavedetailsreport objaleavedetailsreport;
         objaleavedetailsreport = new aleavedetailsreport();
         objaleavedetailsreport.context.SetSubmitInitialConfig(context);
         objaleavedetailsreport.initialize();
         Submit( executePrivateCatch,objaleavedetailsreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aleavedetailsreport)stateInfo).executePrivate();
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
         AV10FromDate = context.localUtil.YMDToD( 2024, 7, 1);
         AV11ToDate = context.localUtil.YMDToD( 2024, 7, 31);
         /* Using cursor P00BQ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00BQ2_A106EmployeeId[0];
            A100CompanyId = P00BQ2_A100CompanyId[0];
            A148EmployeeName = P00BQ2_A148EmployeeName[0];
            AV8EmployeeId = A106EmployeeId;
            AV18SDTEmployeeLeaveDetails.gxTpr_Employeeid = A106EmployeeId;
            AV18SDTEmployeeLeaveDetails.gxTpr_Employeename = A148EmployeeName;
            new logtofile(context ).execute(  StringUtil.Trim( A148EmployeeName)) ;
            /* Using cursor P00BQ3 */
            pr_default.execute(1, new Object[] {A100CompanyId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A124LeaveTypeId = P00BQ3_A124LeaveTypeId[0];
               A125LeaveTypeName = P00BQ3_A125LeaveTypeName[0];
               AV9LeaveTypeId = A124LeaveTypeId;
               AV20LeaveTypeItem.gxTpr_Leavetypeid = A124LeaveTypeId;
               AV20LeaveTypeItem.gxTpr_Leavetypename = A125LeaveTypeName;
               new logtofile(context ).execute(  "    "+StringUtil.Trim( A125LeaveTypeName)) ;
               AV24GXLvl15 = 0;
               /* Using cursor P00BQ4 */
               pr_default.execute(2, new Object[] {AV11ToDate, AV10FromDate, AV9LeaveTypeId, AV8EmployeeId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A124LeaveTypeId = P00BQ4_A124LeaveTypeId[0];
                  A106EmployeeId = P00BQ4_A106EmployeeId[0];
                  A130LeaveRequestEndDate = P00BQ4_A130LeaveRequestEndDate[0];
                  A129LeaveRequestStartDate = P00BQ4_A129LeaveRequestStartDate[0];
                  A127LeaveRequestId = P00BQ4_A127LeaveRequestId[0];
                  A173LeaveRequestHalfDay = P00BQ4_A173LeaveRequestHalfDay[0];
                  n173LeaveRequestHalfDay = P00BQ4_n173LeaveRequestHalfDay[0];
                  A131LeaveRequestDuration = P00BQ4_A131LeaveRequestDuration[0];
                  AV24GXLvl15 = 1;
                  AV21LeaveRequestItem.gxTpr_Leaverequestid = A127LeaveRequestId;
                  AV21LeaveRequestItem.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
                  if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) ) || ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) ) )
                  {
                     AV14LeaveRequestStartDate = A129LeaveRequestStartDate;
                     AV17LeaveRequestEndDate = A130LeaveRequestEndDate;
                     if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) )
                     {
                        AV14LeaveRequestStartDate = AV10FromDate;
                     }
                     if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) )
                     {
                        AV17LeaveRequestEndDate = AV11ToDate;
                     }
                     GXt_decimal1 = AV13LeaveRequestDuration;
                     new getleaverequestdays(context ).execute(  AV14LeaveRequestStartDate,  AV17LeaveRequestEndDate,  A173LeaveRequestHalfDay,  AV8EmployeeId, out  GXt_decimal1) ;
                     AV13LeaveRequestDuration = GXt_decimal1;
                     new logtofile(context ).execute(  "        "+StringUtil.Trim( StringUtil.Str( AV13LeaveRequestDuration, 4, 1))) ;
                     AV21LeaveRequestItem.gxTpr_Leaverequestduration = AV13LeaveRequestDuration;
                  }
                  else
                  {
                     new logtofile(context ).execute(  "        "+StringUtil.Trim( StringUtil.Str( A131LeaveRequestDuration, 4, 1))) ;
                     AV21LeaveRequestItem.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
                  }
                  AV20LeaveTypeItem.gxTpr_Leaverequest.Add(AV21LeaveRequestItem, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( AV24GXLvl15 == 0 )
               {
                  new logtofile(context ).execute(  "        "+"0.0") ;
                  AV21LeaveRequestItem.gxTpr_Leaverequestduration = 0.0m;
                  AV20LeaveTypeItem.gxTpr_Leaverequest.Add(AV21LeaveRequestItem, 0);
               }
               AV18SDTEmployeeLeaveDetails.gxTpr_Leavetype.Add(AV20LeaveTypeItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV19SDTEmployeeLeaveDetailsCollection.Add(AV18SDTEmployeeLeaveDetails, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new logtofile(context ).execute(  AV19SDTEmployeeLeaveDetailsCollection.ToJSonString(false)) ;
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
         AV10FromDate = DateTime.MinValue;
         AV11ToDate = DateTime.MinValue;
         scmdbuf = "";
         P00BQ2_A106EmployeeId = new long[1] ;
         P00BQ2_A100CompanyId = new long[1] ;
         P00BQ2_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV18SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
         P00BQ3_A100CompanyId = new long[1] ;
         P00BQ3_A124LeaveTypeId = new long[1] ;
         P00BQ3_A125LeaveTypeName = new string[] {""} ;
         A125LeaveTypeName = "";
         AV20LeaveTypeItem = new SdtSDTEmployeeLeaveDetails_LeaveTypeItem(context);
         P00BQ4_A124LeaveTypeId = new long[1] ;
         P00BQ4_A106EmployeeId = new long[1] ;
         P00BQ4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BQ4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BQ4_A127LeaveRequestId = new long[1] ;
         P00BQ4_A173LeaveRequestHalfDay = new string[] {""} ;
         P00BQ4_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00BQ4_A131LeaveRequestDuration = new decimal[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         AV21LeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem(context);
         AV14LeaveRequestStartDate = DateTime.MinValue;
         AV17LeaveRequestEndDate = DateTime.MinValue;
         AV19SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aleavedetailsreport__default(),
            new Object[][] {
                new Object[] {
               P00BQ2_A106EmployeeId, P00BQ2_A100CompanyId, P00BQ2_A148EmployeeName
               }
               , new Object[] {
               P00BQ3_A100CompanyId, P00BQ3_A124LeaveTypeId, P00BQ3_A125LeaveTypeName
               }
               , new Object[] {
               P00BQ4_A124LeaveTypeId, P00BQ4_A106EmployeeId, P00BQ4_A130LeaveRequestEndDate, P00BQ4_A129LeaveRequestStartDate, P00BQ4_A127LeaveRequestId, P00BQ4_A173LeaveRequestHalfDay, P00BQ4_n173LeaveRequestHalfDay, P00BQ4_A131LeaveRequestDuration
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl15 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV8EmployeeId ;
      private long A124LeaveTypeId ;
      private long AV9LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV13LeaveRequestDuration ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV14LeaveRequestStartDate ;
      private DateTime AV17LeaveRequestEndDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BQ2_A106EmployeeId ;
      private long[] P00BQ2_A100CompanyId ;
      private string[] P00BQ2_A148EmployeeName ;
      private long[] P00BQ3_A100CompanyId ;
      private long[] P00BQ3_A124LeaveTypeId ;
      private string[] P00BQ3_A125LeaveTypeName ;
      private long[] P00BQ4_A124LeaveTypeId ;
      private long[] P00BQ4_A106EmployeeId ;
      private DateTime[] P00BQ4_A130LeaveRequestEndDate ;
      private DateTime[] P00BQ4_A129LeaveRequestStartDate ;
      private long[] P00BQ4_A127LeaveRequestId ;
      private string[] P00BQ4_A173LeaveRequestHalfDay ;
      private bool[] P00BQ4_n173LeaveRequestHalfDay ;
      private decimal[] P00BQ4_A131LeaveRequestDuration ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV19SDTEmployeeLeaveDetailsCollection ;
      private SdtSDTEmployeeLeaveDetails AV18SDTEmployeeLeaveDetails ;
      private SdtSDTEmployeeLeaveDetails_LeaveTypeItem AV20LeaveTypeItem ;
      private SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem AV21LeaveRequestItem ;
   }

   public class aleavedetailsreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BQ2;
          prmP00BQ2 = new Object[] {
          };
          Object[] prmP00BQ3;
          prmP00BQ3 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP00BQ4;
          prmP00BQ4 = new Object[] {
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV9LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BQ2", "SELECT EmployeeId, CompanyId, EmployeeName FROM Employee WHERE CompanyId = 2 ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BQ3", "SELECT CompanyId, LeaveTypeId, LeaveTypeName FROM LeaveType WHERE CompanyId = :CompanyId ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BQ4", "SELECT LeaveTypeId, EmployeeId, LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestId, LeaveRequestHalfDay, LeaveRequestDuration FROM LeaveRequest WHERE (( LeaveRequestStartDate < :AV11ToDate and LeaveRequestEndDate > :AV10FromDate)) AND (LeaveTypeId = :AV9LeaveTypeId) AND (EmployeeId = :AV8EmployeeId) ORDER BY LeaveRequestStartDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
       }
    }

 }

}
