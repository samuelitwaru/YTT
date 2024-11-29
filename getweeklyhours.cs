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
                           long aP1_EmployeeId ,
                           out string aP2_WeeklyTotal ,
                           out string aP3_DailyTotal ,
                           out string aP4_MonthlyTotal )
      {
         this.AV25WeekDate = aP0_WeekDate;
         this.AV36EmployeeId = aP1_EmployeeId;
         this.AV26WeeklyTotal = "" ;
         this.AV8DailyTotal = "" ;
         this.AV31MonthlyTotal = "" ;
         initialize();
         ExecuteImpl();
         aP2_WeeklyTotal=this.AV26WeeklyTotal;
         aP3_DailyTotal=this.AV8DailyTotal;
         aP4_MonthlyTotal=this.AV31MonthlyTotal;
      }

      public string executeUdp( DateTime aP0_WeekDate ,
                                long aP1_EmployeeId ,
                                out string aP2_WeeklyTotal ,
                                out string aP3_DailyTotal )
      {
         execute(aP0_WeekDate, aP1_EmployeeId, out aP2_WeeklyTotal, out aP3_DailyTotal, out aP4_MonthlyTotal);
         return AV31MonthlyTotal ;
      }

      public void executeSubmit( DateTime aP0_WeekDate ,
                                 long aP1_EmployeeId ,
                                 out string aP2_WeeklyTotal ,
                                 out string aP3_DailyTotal ,
                                 out string aP4_MonthlyTotal )
      {
         this.AV25WeekDate = aP0_WeekDate;
         this.AV36EmployeeId = aP1_EmployeeId;
         this.AV26WeeklyTotal = "" ;
         this.AV8DailyTotal = "" ;
         this.AV31MonthlyTotal = "" ;
         SubmitImpl();
         aP2_WeeklyTotal=this.AV26WeeklyTotal;
         aP3_DailyTotal=this.AV8DailyTotal;
         aP4_MonthlyTotal=this.AV31MonthlyTotal;
      }

      protected override void ExecutePrivate( )
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
         /* Optimized group. */
         /* Using cursor P008B2 */
         pr_default.execute(0, new Object[] {AV17StartDate, AV36EmployeeId, AV11EndDate});
         c121WorkHourLogHour = P008B2_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P008B2_A122WorkHourLogMinute[0];
         pr_default.close(0);
         AV21TotalHour = (short)(AV21TotalHour+c121WorkHourLogHour);
         AV24TotalMinute = (short)(AV24TotalMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor P008B3 */
         pr_default.execute(1, new Object[] {AV25WeekDate, AV36EmployeeId});
         c121WorkHourLogHour = P008B3_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P008B3_A122WorkHourLogMinute[0];
         pr_default.close(1);
         AV27TotalDailyHour = (short)(AV27TotalDailyHour+c121WorkHourLogHour);
         AV28TotalDailyMinute = (short)(AV28TotalDailyMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor P008B4 */
         pr_default.execute(2, new Object[] {AV36EmployeeId, AV25WeekDate});
         c121WorkHourLogHour = P008B4_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P008B4_A122WorkHourLogMinute[0];
         pr_default.close(2);
         AV35TotalMonthlyHour = (short)(AV35TotalMonthlyHour+c121WorkHourLogHour);
         AV33TotalMonthlyMinute = (short)(AV33TotalMonthlyMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         AV32ModTotalMonthlyMinute = (short)(((int)((AV33TotalMonthlyMinute) % (60))));
         AV34TotalMonthlyHoursAndMinutes = (short)(NumberUtil.Trunc( AV33TotalMonthlyMinute/ (decimal)(60), 0)+AV35TotalMonthlyHour);
         if ( AV13ModTotalMinute < 10 )
         {
            AV31MonthlyTotal = StringUtil.Str( (decimal)(AV34TotalMonthlyHoursAndMinutes), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0)) + "hrs";
         }
         else
         {
            AV31MonthlyTotal = StringUtil.Str( (decimal)(AV34TotalMonthlyHoursAndMinutes), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0)) + "hrs";
         }
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
         cleanup();
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
         AV26WeeklyTotal = "";
         AV8DailyTotal = "";
         AV31MonthlyTotal = "";
         AV17StartDate = DateTime.MinValue;
         AV11EndDate = DateTime.MinValue;
         P008B2_A121WorkHourLogHour = new short[1] ;
         P008B2_A122WorkHourLogMinute = new short[1] ;
         P008B3_A121WorkHourLogHour = new short[1] ;
         P008B3_A122WorkHourLogMinute = new short[1] ;
         P008B4_A121WorkHourLogHour = new short[1] ;
         P008B4_A122WorkHourLogMinute = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getweeklyhours__default(),
            new Object[][] {
                new Object[] {
               P008B2_A121WorkHourLogHour, P008B2_A122WorkHourLogMinute
               }
               , new Object[] {
               P008B3_A121WorkHourLogHour, P008B3_A122WorkHourLogMinute
               }
               , new Object[] {
               P008B4_A121WorkHourLogHour, P008B4_A122WorkHourLogMinute
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
      private short AV35TotalMonthlyHour ;
      private short AV33TotalMonthlyMinute ;
      private short AV32ModTotalMonthlyMinute ;
      private short AV34TotalMonthlyHoursAndMinutes ;
      private short AV13ModTotalMinute ;
      private short AV23TotalHoursAndMinutes ;
      private short AV29ModTotalDailyMinute ;
      private short AV30TotalDailyHoursAndMinutes ;
      private long AV36EmployeeId ;
      private string AV26WeeklyTotal ;
      private string AV8DailyTotal ;
      private string AV31MonthlyTotal ;
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
      private short[] P008B4_A121WorkHourLogHour ;
      private short[] P008B4_A122WorkHourLogMinute ;
      private string aP2_WeeklyTotal ;
      private string aP3_DailyTotal ;
      private string aP4_MonthlyTotal ;
   }

   public class getweeklyhours__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          new ParDef("AV17StartDate",GXType.Date,8,0) ,
          new ParDef("AV36EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV11EndDate",GXType.Date,8,0)
          };
          Object[] prmP008B3;
          prmP008B3 = new Object[] {
          new ParDef("AV25WeekDate",GXType.Date,8,0) ,
          new ParDef("AV36EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP008B4;
          prmP008B4 = new Object[] {
          new ParDef("AV36EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV25WeekDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (WorkHourLogDate >= :AV17StartDate) AND (EmployeeId = :AV36EmployeeId) AND (WorkHourLogDate <= :AV11EndDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B3", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (WorkHourLogDate = :AV25WeekDate) AND (EmployeeId = :AV36EmployeeId) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B4", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (EmployeeId = :AV36EmployeeId) AND (date_part('month', WorkHourLogDate) = date_part('month', :AV25WeekDate)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B4,1, GxCacheFrequency.OFF ,true,false )
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
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
