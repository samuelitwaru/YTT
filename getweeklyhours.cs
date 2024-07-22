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
   public class getweeklyhours : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public getweeklyhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getweeklyhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_WeekDate ,
                           out string aP1_WeeklyTotal ,
                           out string aP2_DailyTotal )
      {
         this.AV25WeekDate = aP0_WeekDate;
         this.AV26WeeklyTotal = "" ;
         this.AV8DailyTotal = "" ;
         initialize();
         executePrivate();
         aP1_WeeklyTotal=this.AV26WeeklyTotal;
         aP2_DailyTotal=this.AV8DailyTotal;
      }

      public string executeUdp( DateTime aP0_WeekDate ,
                                out string aP1_WeeklyTotal )
      {
         execute(aP0_WeekDate, out aP1_WeeklyTotal, out aP2_DailyTotal);
         return AV8DailyTotal ;
      }

      public void executeSubmit( DateTime aP0_WeekDate ,
                                 out string aP1_WeeklyTotal ,
                                 out string aP2_DailyTotal )
      {
         getweeklyhours objgetweeklyhours;
         objgetweeklyhours = new getweeklyhours();
         objgetweeklyhours.AV25WeekDate = aP0_WeekDate;
         objgetweeklyhours.AV26WeeklyTotal = "" ;
         objgetweeklyhours.AV8DailyTotal = "" ;
         objgetweeklyhours.context.SetSubmitInitialConfig(context);
         objgetweeklyhours.initialize();
         Submit( executePrivateCatch,objgetweeklyhours);
         aP1_WeeklyTotal=this.AV26WeeklyTotal;
         aP2_DailyTotal=this.AV8DailyTotal;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getweeklyhours)stateInfo).executePrivate();
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
         AV21TotalHour = 0;
         AV24TotalMinute = 0;
         if ( DateTimeUtil.Dow( AV25WeekDate) == 2 )
         {
            AV17StartDate = AV25WeekDate;
            AV11EndDate = DateTimeUtil.DAdd( AV25WeekDate, (6));
         }
         else
         {
            if ( DateTimeUtil.Dow( AV25WeekDate) == 1 )
            {
               AV17StartDate = DateTimeUtil.DAdd( AV25WeekDate, (-6));
               AV11EndDate = DateTimeUtil.DAdd( AV17StartDate, (6));
            }
            else
            {
               AV9daysToStart = (short)(DateTimeUtil.Dow( AV25WeekDate)-2);
               AV17StartDate = DateTimeUtil.DAdd( AV25WeekDate, (-AV9daysToStart));
               AV11EndDate = DateTimeUtil.DAdd( AV17StartDate, (6));
            }
         }
         AV32Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor P008B2 */
         pr_default.execute(0, new Object[] {AV17StartDate, AV32Udparg1, AV11EndDate});
         c121WorkHourLogHour = P008B2_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P008B2_A122WorkHourLogMinute[0];
         pr_default.close(0);
         AV21TotalHour = (short)(AV21TotalHour+c121WorkHourLogHour);
         AV24TotalMinute = (short)(AV24TotalMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         AV32Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor P008B3 */
         pr_default.execute(1, new Object[] {AV25WeekDate, AV32Udparg1});
         c121WorkHourLogHour = P008B3_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P008B3_A122WorkHourLogMinute[0];
         pr_default.close(1);
         AV27TotalDailyHour = (short)(AV27TotalDailyHour+c121WorkHourLogHour);
         AV28TotalDailyMinute = (short)(AV28TotalDailyMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         AV13ModTotalMinute = (short)(((int)((AV24TotalMinute) % (60))));
         AV23TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV24TotalMinute/ (decimal)(60), 0)+AV21TotalHour);
         if ( AV13ModTotalMinute < 10 )
         {
            AV26WeeklyTotal = StringUtil.Str( (decimal)(AV23TotalHoursAndMinutes), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0)) + "hrs";
         }
         else
         {
            AV26WeeklyTotal = StringUtil.Str( (decimal)(AV23TotalHoursAndMinutes), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0)) + "hrs";
         }
         AV29ModTotalDailyMinute = (short)(((int)((AV28TotalDailyMinute) % (60))));
         AV30TotalDailyHoursAndMinutes = (short)(NumberUtil.Trunc( AV28TotalDailyMinute/ (decimal)(60), 0)+AV27TotalDailyHour);
         if ( AV13ModTotalMinute < 10 )
         {
            AV8DailyTotal = StringUtil.Str( (decimal)(AV30TotalDailyHoursAndMinutes), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV29ModTotalDailyMinute), 4, 0)) + "hrs";
         }
         else
         {
            AV8DailyTotal = StringUtil.Str( (decimal)(AV30TotalDailyHoursAndMinutes), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV29ModTotalDailyMinute), 4, 0)) + "hrs";
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
         AV26WeeklyTotal = "";
         AV8DailyTotal = "";
         AV17StartDate = DateTime.MinValue;
         AV11EndDate = DateTime.MinValue;
         scmdbuf = "";
         P008B2_A121WorkHourLogHour = new short[1] ;
         P008B2_A122WorkHourLogMinute = new short[1] ;
         P008B3_A121WorkHourLogHour = new short[1] ;
         P008B3_A122WorkHourLogMinute = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getweeklyhours__default(),
            new Object[][] {
                new Object[] {
               P008B2_A121WorkHourLogHour, P008B2_A122WorkHourLogMinute
               }
               , new Object[] {
               P008B3_A121WorkHourLogHour, P008B3_A122WorkHourLogMinute
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21TotalHour ;
      private short AV24TotalMinute ;
      private short AV9daysToStart ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short AV27TotalDailyHour ;
      private short AV28TotalDailyMinute ;
      private short AV13ModTotalMinute ;
      private short AV23TotalHoursAndMinutes ;
      private short AV29ModTotalDailyMinute ;
      private short AV30TotalDailyHoursAndMinutes ;
      private long AV32Udparg1 ;
      private string AV26WeeklyTotal ;
      private string AV8DailyTotal ;
      private string scmdbuf ;
      private DateTime AV25WeekDate ;
      private DateTime AV17StartDate ;
      private DateTime AV11EndDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P008B2_A121WorkHourLogHour ;
      private short[] P008B2_A122WorkHourLogMinute ;
      private short[] P008B3_A121WorkHourLogHour ;
      private short[] P008B3_A122WorkHourLogMinute ;
      private string aP1_WeeklyTotal ;
      private string aP2_DailyTotal ;
   }

   public class getweeklyhours__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          new ParDef("AV17StartDate",GXType.Date,8,0) ,
          new ParDef("AV32Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV11EndDate",GXType.Date,8,0)
          };
          Object[] prmP008B3;
          prmP008B3 = new Object[] {
          new ParDef("AV25WeekDate",GXType.Date,8,0) ,
          new ParDef("AV32Udparg1",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (WorkHourLogDate >= :AV17StartDate) AND (EmployeeId = :AV32Udparg1) AND (WorkHourLogDate <= :AV11EndDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B3", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (WorkHourLogDate = :AV25WeekDate) AND (EmployeeId = :AV32Udparg1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
