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
   public class atest : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new atest().executeCmdLine(args); ;
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

      public atest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atest( IGxContext context )
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
         atest objatest;
         objatest = new atest();
         objatest.context.SetSubmitInitialConfig(context);
         objatest.initialize();
         Submit( executePrivateCatch,objatest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atest)stateInfo).executePrivate();
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
         /* Using cursor P00B93 */
         pr_default.execute(0, new Object[] {AV12EmployeeId});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00B93_A40000GXC1[0];
            n40000GXC1 = P00B93_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P00B95 */
         pr_default.execute(1, new Object[] {AV8FromDate, AV9ToDate, AV12EmployeeId, AV13OneProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P00B95_A40001GXC2[0];
            n40001GXC2 = P00B95_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         AV12EmployeeId = 120;
         AV8FromDate = context.localUtil.YMDToD( 2024, 7, 1);
         AV9ToDate = context.localUtil.YMDToD( 2024, 7, 31);
         AV13OneProjectId = 69;
         AV11Hours = A40000GXC1;
         AV14Minutes = A40001GXC2;
         new logtofile(context ).execute(  StringUtil.Str( (decimal)(AV12EmployeeId), 10, 0)+","+context.localUtil.DToC( AV8FromDate, 2, "/")+","+context.localUtil.DToC( AV9ToDate, 2, "/")+","+StringUtil.Str( (decimal)(AV13OneProjectId), 10, 0)) ;
         new logtofile(context ).execute(  StringUtil.Str( (decimal)(AV11Hours), 8, 0)+" : "+StringUtil.Str( (decimal)(AV14Minutes), 8, 0)) ;
         AV11Hours = 0;
         AV14Minutes = 0;
         /* Optimized group. */
         /* Using cursor P00B96 */
         pr_default.execute(2, new Object[] {AV12EmployeeId, AV13OneProjectId, AV8FromDate, AV9ToDate});
         c121WorkHourLogHour = P00B96_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P00B96_A122WorkHourLogMinute[0];
         pr_default.close(2);
         AV11Hours = (int)(AV11Hours+c121WorkHourLogHour);
         AV14Minutes = (int)(AV14Minutes+c122WorkHourLogMinute);
         /* End optimized group. */
         new logtofile(context ).execute(  ">>>>>>>>>> "+StringUtil.Str( (decimal)(AV11Hours), 8, 0)) ;
         new logtofile(context ).execute(  ">>>>>>>>>> "+StringUtil.Str( (decimal)(AV14Minutes), 8, 0)) ;
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
         P00B93_A40000GXC1 = new short[1] ;
         P00B93_n40000GXC1 = new bool[] {false} ;
         AV8FromDate = DateTime.MinValue;
         AV9ToDate = DateTime.MinValue;
         P00B95_A40001GXC2 = new short[1] ;
         P00B95_n40001GXC2 = new bool[] {false} ;
         P00B96_A121WorkHourLogHour = new int[1] ;
         P00B96_A122WorkHourLogMinute = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atest__default(),
            new Object[][] {
                new Object[] {
               P00B93_A40000GXC1, P00B93_n40000GXC1
               }
               , new Object[] {
               P00B95_A40001GXC2, P00B95_n40001GXC2
               }
               , new Object[] {
               P00B96_A121WorkHourLogHour, P00B96_A122WorkHourLogMinute
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int AV11Hours ;
      private int AV14Minutes ;
      private int c121WorkHourLogHour ;
      private int c122WorkHourLogMinute ;
      private long AV12EmployeeId ;
      private long AV13OneProjectId ;
      private string scmdbuf ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00B93_A40000GXC1 ;
      private bool[] P00B93_n40000GXC1 ;
      private short[] P00B95_A40001GXC2 ;
      private bool[] P00B95_n40001GXC2 ;
      private int[] P00B96_A121WorkHourLogHour ;
      private short[] P00B96_A122WorkHourLogMinute ;
   }

   public class atest__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B93;
          prmP00B93 = new Object[] {
          new ParDef("AV12EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00B95;
          prmP00B95 = new Object[] {
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0) ,
          new ParDef("AV12EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV13OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00B96;
          prmP00B96 = new Object[] {
          new ParDef("AV12EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV13OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B93", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT SUM(WorkHourLogHour) AS GXC1 FROM WorkHourLog WHERE EmployeeId = :AV12EmployeeId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B93,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B95", "SELECT COALESCE( T1.GXC2, 0) AS GXC2 FROM (SELECT SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (WorkHourLogDate >= :AV8FromDate) AND (WorkHourLogDate <= :AV9ToDate) AND (EmployeeId = :AV12EmployeeId) AND (ProjectId = :AV13OneProjectId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B95,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B96", "SELECT SUM(WorkHourLogHour) AS GXC1, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (EmployeeId = :AV12EmployeeId and ProjectId = :AV13OneProjectId) AND (WorkHourLogDate >= :AV8FromDate) AND (WorkHourLogDate <= :AV9ToDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B96,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
