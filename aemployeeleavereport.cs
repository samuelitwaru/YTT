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
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aemployeeleavereport().executeCmdLine(args); ;
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
          long aP0_CompanyLocationId ;
         DateTime aP1_Date = new DateTime()  ;
         string aP2_Filename = new string(' ',0)  ;
         string aP3_ErrorMessage = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_CompanyLocationId=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_CompanyLocationId=0;
         }
         if ( 1 < args.Length )
         {
            aP1_Date=((DateTime)(context.localUtil.CToD( (string)(args[1]), 1)));
         }
         else
         {
            aP1_Date=DateTime.MinValue;
         }
         if ( 2 < args.Length )
         {
            aP2_Filename=((string)(args[2]));
         }
         else
         {
            aP2_Filename="";
         }
         if ( 3 < args.Length )
         {
            aP3_ErrorMessage=((string)(args[3]));
         }
         else
         {
            aP3_ErrorMessage="";
         }
         execute(aP0_CompanyLocationId, ref aP1_Date, out aP2_Filename, out aP3_ErrorMessage);
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
                           ref DateTime aP1_Date ,
                           out string aP2_Filename ,
                           out string aP3_ErrorMessage )
      {
         this.AV22CompanyLocationId = aP0_CompanyLocationId;
         this.AV28Date = aP1_Date;
         this.AV10Filename = "" ;
         this.AV23ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Date=this.AV28Date;
         aP2_Filename=this.AV10Filename;
         aP3_ErrorMessage=this.AV23ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref DateTime aP1_Date ,
                                out string aP2_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_Date, out aP2_Filename, out aP3_ErrorMessage);
         return AV23ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref DateTime aP1_Date ,
                                 out string aP2_Filename ,
                                 out string aP3_ErrorMessage )
      {
         aemployeeleavereport objaemployeeleavereport;
         objaemployeeleavereport = new aemployeeleavereport();
         objaemployeeleavereport.AV22CompanyLocationId = aP0_CompanyLocationId;
         objaemployeeleavereport.AV28Date = aP1_Date;
         objaemployeeleavereport.AV10Filename = "" ;
         objaemployeeleavereport.AV23ErrorMessage = "" ;
         objaemployeeleavereport.context.SetSubmitInitialConfig(context);
         objaemployeeleavereport.initialize();
         Submit( executePrivateCatch,objaemployeeleavereport);
         aP1_Date=this.AV28Date;
         aP2_Filename=this.AV10Filename;
         aP3_ErrorMessage=this.AV23ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aemployeeleavereport)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
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
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV8LeaveTypeNames.Count )
         {
            AV15Name = AV8LeaveTypeNames.GetString(AV31GXV1);
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(3, AV12col);
            AV20ExcelCellRange.gxTpr_Valuetext = AV15Name;
            AV20ExcelCellRange.setcellstyle( AV27excelCellStyle);
            AV12col = (short)(AV12col+1);
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         AV13row = 4;
         /* Using cursor P00AT3 */
         pr_default.execute(1, new Object[] {AV22CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AT3_A100CompanyId[0];
            A157CompanyLocationId = P00AT3_A157CompanyLocationId[0];
            A148EmployeeName = P00AT3_A148EmployeeName[0];
            A147EmployeeBalance = P00AT3_A147EmployeeBalance[0];
            A106EmployeeId = P00AT3_A106EmployeeId[0];
            A157CompanyLocationId = P00AT3_A157CompanyLocationId[0];
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(AV13row, 1);
            AV20ExcelCellRange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
            AV20ExcelCellRange = AV21excelSpreadsheet.cell(AV13row, AV8LeaveTypeNames.IndexOf("Vacation Days Left"));
            AV20ExcelCellRange.gxTpr_Valuenumber = (decimal)(A147EmployeeBalance);
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
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
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
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV9ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV23ErrorMessage = AV9ExcelDocument.ErrDescription;
            AV9ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
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
         AV11Session.Set("WWPExportFilePath", AV10Filename);
         AV11Session.Set("WWPExportFileName", AV10Filename);
         AV10Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV10Filename = "";
         AV23ErrorMessage = "";
         AV8LeaveTypeNames = new GxSimpleCollection<string>();
         scmdbuf = "";
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
         P00AT3_A148EmployeeName = new string[] {""} ;
         P00AT3_A147EmployeeBalance = new short[1] ;
         P00AT3_A106EmployeeId = new long[1] ;
         A148EmployeeName = "";
         P00AT5_A124LeaveTypeId = new long[1] ;
         P00AT5_A100CompanyId = new long[1] ;
         P00AT5_A125LeaveTypeName = new string[] {""} ;
         P00AT5_A40000GXC1 = new decimal[1] ;
         P00AT5_n40000GXC1 = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         AV29File = new GxFile(context.GetPhysicalPath());
         AV9ExcelDocument = new ExcelDocumentI();
         AV11Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavereport__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A100CompanyId, P00AT2_A157CompanyLocationId, P00AT2_A101CompanyName, P00AT2_A125LeaveTypeName, P00AT2_A124LeaveTypeId
               }
               , new Object[] {
               P00AT3_A100CompanyId, P00AT3_A157CompanyLocationId, P00AT3_A148EmployeeName, P00AT3_A147EmployeeBalance, P00AT3_A106EmployeeId
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
      private short A147EmployeeBalance ;
      private short AV14count ;
      private short AV17index ;
      private int AV31GXV1 ;
      private long AV22CompanyLocationId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A40000GXC1 ;
      private string AV10Filename ;
      private string scmdbuf ;
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
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV21excelSpreadsheet ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP1_Date ;
      private IDataStoreProvider pr_default ;
      private long[] P00AT2_A100CompanyId ;
      private long[] P00AT2_A157CompanyLocationId ;
      private string[] P00AT2_A101CompanyName ;
      private string[] P00AT2_A125LeaveTypeName ;
      private long[] P00AT2_A124LeaveTypeId ;
      private long[] P00AT3_A100CompanyId ;
      private long[] P00AT3_A157CompanyLocationId ;
      private string[] P00AT3_A148EmployeeName ;
      private short[] P00AT3_A147EmployeeBalance ;
      private long[] P00AT3_A106EmployeeId ;
      private long[] P00AT5_A124LeaveTypeId ;
      private long[] P00AT5_A100CompanyId ;
      private string[] P00AT5_A125LeaveTypeName ;
      private decimal[] P00AT5_A40000GXC1 ;
      private bool[] P00AT5_n40000GXC1 ;
      private string aP2_Filename ;
      private string aP3_ErrorMessage ;
      private IGxSession AV11Session ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GxSimpleCollection<string> AV8LeaveTypeNames ;
      private GxFile AV29File ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV20ExcelCellRange ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV27excelCellStyle ;
   }

   public class aemployeeleavereport__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AT2;
          prmP00AT2 = new Object[] {
          new ParDef("AV22CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP00AT3;
          prmP00AT3 = new Object[] {
          new ParDef("AV22CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP00AT5;
          prmP00AT5 = new Object[] {
          new ParDef("EmployeeName",GXType.Char,128,0) ,
          new ParDef("AV28Date",GXType.Date,8,0) ,
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "SELECT T1.CompanyId, T2.CompanyLocationId, T2.CompanyName, T1.LeaveTypeName, T1.LeaveTypeId FROM (LeaveType T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV22CompanyLocationId ORDER BY T1.LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AT3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeName, T1.EmployeeBalance, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV22CompanyLocationId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
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
