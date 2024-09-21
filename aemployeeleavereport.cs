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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aemployeeleavereport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavereport().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
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

      public aemployeeleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavereport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP1_EmployeeIds ,
                           ref DateTime aP2_Date ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV22CompanyLocationId = aP0_CompanyLocationId;
         this.AV30EmployeeIds = aP1_EmployeeIds;
         this.AV28Date = aP2_Date;
         this.AV10Filename = "" ;
         this.AV23ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV30EmployeeIds;
         aP2_Date=this.AV28Date;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV23ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                ref DateTime aP2_Date ,
                                out string aP3_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_EmployeeIds, ref aP2_Date, out aP3_Filename, out aP4_ErrorMessage);
         return AV23ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                 ref DateTime aP2_Date ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         this.AV22CompanyLocationId = aP0_CompanyLocationId;
         this.AV30EmployeeIds = aP1_EmployeeIds;
         this.AV28Date = aP2_Date;
         this.AV10Filename = "" ;
         this.AV23ErrorMessage = "" ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV30EmployeeIds;
         aP2_Date=this.AV28Date;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV23ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8LeaveTypeNames.Add("Employee Name", 0);
         AV8LeaveTypeNames.Add("Leave Date", 0);
         /* Using cursor P00AT2 */
         pr_default.execute(0, new Object[] {AV22CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AT2_A100CompanyId[0];
            A157CompanyLocationId = P00AT2_A157CompanyLocationId[0];
            A101CompanyName = P00AT2_A101CompanyName[0];
            A125LeaveTypeName = P00AT2_A125LeaveTypeName[0];
            A124LeaveTypeId = P00AT2_A124LeaveTypeId[0];
            A157CompanyLocationId = P00AT2_A157CompanyLocationId[0];
            A101CompanyName = P00AT2_A101CompanyName[0];
            AV24CompanyName = StringUtil.Trim( A101CompanyName);
            AV8LeaveTypeNames.Add(StringUtil.Trim( A125LeaveTypeName), 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8LeaveTypeNames.Add("Vacation Days Left", 0);
         AV27excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV27excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV27excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV20ExcelCellRange = AV21excelSpreadsheet.cell(1, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV28Date,  "YYYY", out  GXt_char1) ;
         AV20ExcelCellRange.gxTpr_Valuetext = "Leave Overview "+GXt_char1+" For "+AV24CompanyName;
         AV20ExcelCellRange.setcellstyle( AV27excelCellStyle);
         AV12col = 1;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV8LeaveTypeNames.Count )
         {
            AV15Name = AV8LeaveTypeNames.GetString(AV32GXV1);
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(3, AV12col);
            AV20ExcelCellRange.gxTpr_Valuetext = AV15Name;
            AV20ExcelCellRange.setcellstyle( AV27excelCellStyle);
            AV12col = (short)(AV12col+1);
            AV32GXV1 = (int)(AV32GXV1+1);
         }
         AV13row = 4;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV30EmployeeIds ,
                                              AV30EmployeeIds.Count ,
                                              A157CompanyLocationId ,
                                              AV22CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00AT3 */
         pr_default.execute(1, new Object[] {AV22CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AT3_A100CompanyId[0];
            A157CompanyLocationId = P00AT3_A157CompanyLocationId[0];
            A106EmployeeId = P00AT3_A106EmployeeId[0];
            A148EmployeeName = P00AT3_A148EmployeeName[0];
            A147EmployeeBalance = P00AT3_A147EmployeeBalance[0];
            A157CompanyLocationId = P00AT3_A157CompanyLocationId[0];
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(AV13row, 1);
            AV20ExcelCellRange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(AV13row, AV8LeaveTypeNames.IndexOf("Vacation Days Left"));
            AV20ExcelCellRange.gxTpr_Valuenumber = A147EmployeeBalance;
            /* Using cursor P00AT5 */
            pr_default.execute(2, new Object[] {A148EmployeeName, AV28Date, A100CompanyId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A124LeaveTypeId = P00AT5_A124LeaveTypeId[0];
               A125LeaveTypeName = P00AT5_A125LeaveTypeName[0];
               A40000GXC1 = P00AT5_A40000GXC1[0];
               n40000GXC1 = P00AT5_n40000GXC1[0];
               A40000GXC1 = P00AT5_A40000GXC1[0];
               n40000GXC1 = P00AT5_n40000GXC1[0];
               AV14count = (short)(Math.Round(A40000GXC1, 18, MidpointRounding.ToEven));
               if ( AV14count > 0 )
               {
                  AV17index = (short)(AV8LeaveTypeNames.IndexOf(StringUtil.Trim( A125LeaveTypeName)));
                  AV20ExcelCellRange = AV21excelSpreadsheet.cell(AV13row, AV17index);
                  AV20ExcelCellRange.gxTpr_Valuenumber = (decimal)(AV14count);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV13row = (short)(AV13row+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV10Filename = "LeaveReport-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( Gx_date)), 10, 0)) + ".xlsx";
         AV21excelSpreadsheet.open( AV10Filename);
         AV29File.Source = AV10Filename;
         AV29File.Delete();
         AV21excelSpreadsheet.open( AV10Filename);
      }

      protected void S121( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV21excelSpreadsheet.gxTpr_Autofit = true;
         AV26boolean = AV21excelSpreadsheet.save();
         if ( AV26boolean )
         {
            AV21excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV21excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV21excelSpreadsheet.gxTpr_Errdescription);
         }
         new logtofile(context ).execute(  AV10Filename) ;
         AV11Session.Set("WWPExportFilePath", AV10Filename);
         AV11Session.Set("WWPExportFileName", AV10Filename);
         AV10Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Filename = "";
         AV23ErrorMessage = "";
         AV8LeaveTypeNames = new GxSimpleCollection<string>();
         P00AT2_A100CompanyId = new long[1] ;
         P00AT2_A157CompanyLocationId = new long[1] ;
         P00AT2_A101CompanyName = new string[] {""} ;
         P00AT2_A125LeaveTypeName = new string[] {""} ;
         P00AT2_A124LeaveTypeId = new long[1] ;
         A101CompanyName = "";
         A125LeaveTypeName = "";
         AV24CompanyName = "";
         AV27excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV20ExcelCellRange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV21excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         GXt_char1 = "";
         AV15Name = "";
         P00AT3_A100CompanyId = new long[1] ;
         P00AT3_A157CompanyLocationId = new long[1] ;
         P00AT3_A106EmployeeId = new long[1] ;
         P00AT3_A148EmployeeName = new string[] {""} ;
         P00AT3_A147EmployeeBalance = new decimal[1] ;
         A148EmployeeName = "";
         P00AT5_A124LeaveTypeId = new long[1] ;
         P00AT5_A100CompanyId = new long[1] ;
         P00AT5_A125LeaveTypeName = new string[] {""} ;
         P00AT5_A40000GXC1 = new decimal[1] ;
         P00AT5_n40000GXC1 = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         AV29File = new GxFile(context.GetPhysicalPath());
         AV11Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavereport__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A100CompanyId, P00AT2_A157CompanyLocationId, P00AT2_A101CompanyName, P00AT2_A125LeaveTypeName, P00AT2_A124LeaveTypeId
               }
               , new Object[] {
               P00AT3_A100CompanyId, P00AT3_A157CompanyLocationId, P00AT3_A106EmployeeId, P00AT3_A148EmployeeName, P00AT3_A147EmployeeBalance
               }
               , new Object[] {
               P00AT5_A124LeaveTypeId, P00AT5_A100CompanyId, P00AT5_A125LeaveTypeName, P00AT5_A40000GXC1, P00AT5_n40000GXC1
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV12col ;
      private short AV13row ;
      private short AV14count ;
      private short AV17index ;
      private int AV32GXV1 ;
      private int AV30EmployeeIds_Count ;
      private long AV22CompanyLocationId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal A40000GXC1 ;
      private string AV10Filename ;
      private string A101CompanyName ;
      private string A125LeaveTypeName ;
      private string AV24CompanyName ;
      private string GXt_char1 ;
      private string AV15Name ;
      private string A148EmployeeName ;
      private DateTime AV28Date ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool n40000GXC1 ;
      private bool AV26boolean ;
      private string AV23ErrorMessage ;
      private IGxSession AV11Session ;
      private GxFile AV29File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV30EmployeeIds ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
      private DateTime aP2_Date ;
      private GxSimpleCollection<string> AV8LeaveTypeNames ;
      private IDataStoreProvider pr_default ;
      private long[] P00AT2_A100CompanyId ;
      private long[] P00AT2_A157CompanyLocationId ;
      private string[] P00AT2_A101CompanyName ;
      private string[] P00AT2_A125LeaveTypeName ;
      private long[] P00AT2_A124LeaveTypeId ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV27excelCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV20ExcelCellRange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV21excelSpreadsheet ;
      private long[] P00AT3_A100CompanyId ;
      private long[] P00AT3_A157CompanyLocationId ;
      private long[] P00AT3_A106EmployeeId ;
      private string[] P00AT3_A148EmployeeName ;
      private decimal[] P00AT3_A147EmployeeBalance ;
      private long[] P00AT5_A124LeaveTypeId ;
      private long[] P00AT5_A100CompanyId ;
      private string[] P00AT5_A125LeaveTypeName ;
      private decimal[] P00AT5_A40000GXC1 ;
      private bool[] P00AT5_n40000GXC1 ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
   }

   public class aemployeeleavereport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AT3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV30EmployeeIds ,
                                             int AV30EmployeeIds_Count ,
                                             long A157CompanyLocationId ,
                                             long AV22CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T1.EmployeeName, T1.EmployeeBalance FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(T2.CompanyLocationId = :AV22CompanyLocationId)");
         if ( AV30EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV30EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00AT3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00AT2;
          prmP00AT2 = new Object[] {
          new ParDef("AV22CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP00AT5;
          prmP00AT5 = new Object[] {
          new ParDef("EmployeeName",GXType.Char,100,0) ,
          new ParDef("AV28Date",GXType.Date,8,0) ,
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP00AT3;
          prmP00AT3 = new Object[] {
          new ParDef("AV22CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "SELECT T1.CompanyId, T2.CompanyLocationId, T2.CompanyName, T1.LeaveTypeName, T1.LeaveTypeId FROM (LeaveType T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV22CompanyLocationId ORDER BY T1.LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT5", "SELECT T1.LeaveTypeId, T1.CompanyId, T1.LeaveTypeName, COALESCE( T2.GXC1, 0) AS GXC1 FROM (LeaveType T1 LEFT JOIN LATERAL (SELECT SUM(T3.LeaveRequestDuration) AS GXC1, T3.LeaveTypeId FROM (LeaveRequest T3 INNER JOIN Employee T4 ON T4.EmployeeId = T3.EmployeeId) WHERE (T1.LeaveTypeId = T3.LeaveTypeId) AND (T4.EmployeeName = ( :EmployeeName) and T3.LeaveRequestStartDate >= TO_DATE(date_part('year', :AV28Date)||'-'||1||'-'||1, 'YYYY-MM-DD') and T3.LeaveRequestStartDate < TO_DATE(date_part('year', :AV28Date)||'-'||12||'-'||31, 'YYYY-MM-DD')) GROUP BY T3.LeaveTypeId ) T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.CompanyId = :CompanyId ORDER BY T1.CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
