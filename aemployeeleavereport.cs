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
         string aP1_Filename = new string(' ',0)  ;
         string aP2_ErrorMessage = new string(' ',0)  ;
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
            aP1_Filename=((string)(args[1]));
         }
         else
         {
            aP1_Filename="";
         }
         if ( 2 < args.Length )
         {
            aP2_ErrorMessage=((string)(args[2]));
         }
         else
         {
            aP2_ErrorMessage="";
         }
         execute(aP0_CompanyLocationId, out aP1_Filename, out aP2_ErrorMessage);
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
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV22CompanyLocationId = aP0_CompanyLocationId;
         this.AV10Filename = "" ;
         this.AV23ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV23ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                out string aP1_Filename )
      {
         execute(aP0_CompanyLocationId, out aP1_Filename, out aP2_ErrorMessage);
         return AV23ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         aemployeeleavereport objaemployeeleavereport;
         objaemployeeleavereport = new aemployeeleavereport();
         objaemployeeleavereport.AV22CompanyLocationId = aP0_CompanyLocationId;
         objaemployeeleavereport.AV10Filename = "" ;
         objaemployeeleavereport.AV23ErrorMessage = "" ;
         objaemployeeleavereport.context.SetSubmitInitialConfig(context);
         objaemployeeleavereport.initialize();
         Submit( executePrivateCatch,objaemployeeleavereport);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV23ErrorMessage;
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
            A125LeaveTypeName = P00AT2_A125LeaveTypeName[0];
            A124LeaveTypeId = P00AT2_A124LeaveTypeId[0];
            A157CompanyLocationId = P00AT2_A157CompanyLocationId[0];
            AV8LeaveTypeNames.Add(StringUtil.Trim( A125LeaveTypeName), 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8LeaveTypeNames.Add("Annual Leave Availability", 0);
         AV12col = 1;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV8LeaveTypeNames.Count )
         {
            AV15Name = AV8LeaveTypeNames.GetString(AV25GXV1);
            AV9ExcelDocument.get_Cells(1, AV12col, 1, 1).Text = AV15Name;
            AV9ExcelDocument.get_Cells(1, AV12col, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(1, AV12col, 1, 1).Color = 11;
            AV12col = (short)(AV12col+1);
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         AV13row = 2;
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
            AV9ExcelDocument.get_Cells(AV13row, 1, 1, 1).Text = StringUtil.Trim( A148EmployeeName);
            AV9ExcelDocument.get_Cells(AV13row, AV8LeaveTypeNames.IndexOf("Annual Leave Availability"), 1, 1).Number = A147EmployeeBalance;
            /* Using cursor P00AT5 */
            pr_default.execute(2, new Object[] {A148EmployeeName, A100CompanyId});
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
                  AV9ExcelDocument.get_Cells(AV13row, AV17index, 1, 1).Number = AV14count;
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
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV9ExcelDocument.Clear();
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
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV9ExcelDocument.Close();
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
         P00AT2_A125LeaveTypeName = new string[] {""} ;
         P00AT2_A124LeaveTypeId = new long[1] ;
         A125LeaveTypeName = "";
         AV15Name = "";
         AV9ExcelDocument = new ExcelDocumentI();
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
         AV11Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavereport__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A100CompanyId, P00AT2_A157CompanyLocationId, P00AT2_A125LeaveTypeName, P00AT2_A124LeaveTypeId
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
      private int AV25GXV1 ;
      private long AV22CompanyLocationId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A40000GXC1 ;
      private string AV10Filename ;
      private string scmdbuf ;
      private string A125LeaveTypeName ;
      private string AV15Name ;
      private string A148EmployeeName ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool n40000GXC1 ;
      private string AV23ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AT2_A100CompanyId ;
      private long[] P00AT2_A157CompanyLocationId ;
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
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private IGxSession AV11Session ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GxSimpleCollection<string> AV8LeaveTypeNames ;
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
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.LeaveTypeName, T1.LeaveTypeId FROM (LeaveType T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV22CompanyLocationId ORDER BY T1.LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AT3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeName, T1.EmployeeBalance, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV22CompanyLocationId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT5", "SELECT T1.LeaveTypeId, T1.CompanyId, T1.LeaveTypeName, COALESCE( T2.GXC1, 0) AS GXC1 FROM (LeaveType T1 LEFT JOIN LATERAL (SELECT SUM(T3.LeaveRequestDuration) AS GXC1, T3.LeaveTypeId FROM (LeaveRequest T3 INNER JOIN Employee T4 ON T4.EmployeeId = T3.EmployeeId) WHERE (T1.LeaveTypeId = T3.LeaveTypeId) AND (T4.EmployeeName = ( :EmployeeName)) GROUP BY T3.LeaveTypeId ) T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.CompanyId = :CompanyId ORDER BY T1.CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT5,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[3])[0] = rslt.getLong(4);
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