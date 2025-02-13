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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_icsleaveapi : GXProcedure
   {
      public prc_icsleaveapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_icsleaveapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ICSLeaveExport )
      {
         this.AV8ICSLeaveExport = "" ;
         initialize();
         ExecuteImpl();
         aP0_ICSLeaveExport=this.AV8ICSLeaveExport;
      }

      public string executeUdp( )
      {
         execute(out aP0_ICSLeaveExport);
         return AV8ICSLeaveExport ;
      }

      public void executeSubmit( out string aP0_ICSLeaveExport )
      {
         this.AV8ICSLeaveExport = "" ;
         SubmitImpl();
         aP0_ICSLeaveExport=this.AV8ICSLeaveExport;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17AuthorizationValue = StringUtil.FromBase64( StringUtil.StringReplace( AV16httprequest.GetHeader("Authorization"), "Basic ", ""));
         AV21CredsCollection = (GxSimpleCollection<string>)(GxRegex.Split(AV17AuthorizationValue,":"));
         AV14EmployeeEmail = ((string)AV21CredsCollection.Item(1));
         AV15EmployeeAPIPassword = ((string)AV21CredsCollection.Item(2));
         new logtofile(context ).execute(  StringUtil.FromBase64( "dXNlcm5hbWU6cGFzc3dvcmQ=")) ;
         new logtofile(context ).execute(  AV14EmployeeEmail+":"+AV15EmployeeAPIPassword) ;
         /* Using cursor P00CH2 */
         pr_default.execute(0, new Object[] {AV14EmployeeEmail, AV15EmployeeAPIPassword});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00CH2_A106EmployeeId[0];
            A148EmployeeName = P00CH2_A148EmployeeName[0];
            A188EmployeeAPIPassword = P00CH2_A188EmployeeAPIPassword[0];
            A109EmployeeEmail = P00CH2_A109EmployeeEmail[0];
            AV8ICSLeaveExport = "";
            AV8ICSLeaveExport += "BEGIN:VCALENDAR" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "PRODID:-//Yukon Software//APiCalConverter//EN" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "VERSION:2.0" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "CALSCALE:GREGORIAN" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:VTIMEZONE" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZID:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "LAST-MODIFIED:20240422T053450Z" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZURL:https://www.tzurl.org/zoneinfo/EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-LIC-LOCATION:EET";
            AV8ICSLeaveExport += "X-PROLEPTIC-TZNAME;X-NO-BIG-BANG=TRUE:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19770403T030000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19800406T010000Z;BYMONTH=4;BYDAY=1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19770925T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RDATE:19781001T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19790930T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19950924T010000Z;BYMONTH=9;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19810329T030000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19961027T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:VTIMEZONE" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-TIMEZONE:Europe/Bucharest" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-CALNAME:Absence" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-CALDESC:" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "METHOD:PUBLISH" + StringUtil.NewLine( );
            /* Using cursor P00CH3 */
            pr_default.execute(1, new Object[] {A106EmployeeId, A109EmployeeEmail, AV14EmployeeEmail});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A124LeaveTypeId = P00CH3_A124LeaveTypeId[0];
               A128LeaveRequestDate = P00CH3_A128LeaveRequestDate[0];
               A129LeaveRequestStartDate = P00CH3_A129LeaveRequestStartDate[0];
               A130LeaveRequestEndDate = P00CH3_A130LeaveRequestEndDate[0];
               A125LeaveTypeName = P00CH3_A125LeaveTypeName[0];
               A127LeaveRequestId = P00CH3_A127LeaveRequestId[0];
               A125LeaveTypeName = P00CH3_A125LeaveTypeName[0];
               AV8ICSLeaveExport += "BEGIN:VEVENT" + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A128LeaveRequestDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTSTAMP:" + GXt_char1 + "T000000Z" + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTSTART;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTEND;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
               AV8ICSLeaveExport += "SUMMARY:" + StringUtil.Trim( A148EmployeeName) + " | " + StringUtil.Trim( A125LeaveTypeName) + StringUtil.NewLine( );
               AV8ICSLeaveExport += "UID:" + StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0)) + StringUtil.Trim( A109EmployeeEmail) + StringUtil.NewLine( );
               AV8ICSLeaveExport += "END:VEVENT" + StringUtil.NewLine( );
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV8ICSLeaveExport += "END:VCALENDAR" + StringUtil.NewLine( );
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new logtofile(context ).execute(  AV8ICSLeaveExport) ;
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
         AV8ICSLeaveExport = "";
         AV17AuthorizationValue = "";
         AV16httprequest = new GxHttpRequest( context);
         AV21CredsCollection = new GxSimpleCollection<string>();
         AV14EmployeeEmail = "";
         AV15EmployeeAPIPassword = "";
         P00CH2_A106EmployeeId = new long[1] ;
         P00CH2_A148EmployeeName = new string[] {""} ;
         P00CH2_A188EmployeeAPIPassword = new string[] {""} ;
         P00CH2_A109EmployeeEmail = new string[] {""} ;
         A148EmployeeName = "";
         A188EmployeeAPIPassword = "";
         A109EmployeeEmail = "";
         P00CH3_A124LeaveTypeId = new long[1] ;
         P00CH3_A106EmployeeId = new long[1] ;
         P00CH3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00CH3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00CH3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00CH3_A125LeaveTypeName = new string[] {""} ;
         P00CH3_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_icsleaveapi__default(),
            new Object[][] {
                new Object[] {
               P00CH2_A106EmployeeId, P00CH2_A148EmployeeName, P00CH2_A188EmployeeAPIPassword, P00CH2_A109EmployeeEmail
               }
               , new Object[] {
               P00CH3_A124LeaveTypeId, P00CH3_A106EmployeeId, P00CH3_A128LeaveRequestDate, P00CH3_A129LeaveRequestStartDate, P00CH3_A130LeaveRequestEndDate, P00CH3_A125LeaveTypeName, P00CH3_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string GXt_char1 ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private string AV8ICSLeaveExport ;
      private string AV17AuthorizationValue ;
      private string AV14EmployeeEmail ;
      private string AV15EmployeeAPIPassword ;
      private string A188EmployeeAPIPassword ;
      private string A109EmployeeEmail ;
      private GxHttpRequest AV16httprequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21CredsCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00CH2_A106EmployeeId ;
      private string[] P00CH2_A148EmployeeName ;
      private string[] P00CH2_A188EmployeeAPIPassword ;
      private string[] P00CH2_A109EmployeeEmail ;
      private long[] P00CH3_A124LeaveTypeId ;
      private long[] P00CH3_A106EmployeeId ;
      private DateTime[] P00CH3_A128LeaveRequestDate ;
      private DateTime[] P00CH3_A129LeaveRequestStartDate ;
      private DateTime[] P00CH3_A130LeaveRequestEndDate ;
      private string[] P00CH3_A125LeaveTypeName ;
      private long[] P00CH3_A127LeaveRequestId ;
      private string aP0_ICSLeaveExport ;
   }

   public class prc_icsleaveapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CH2;
          prmP00CH2 = new Object[] {
          new ParDef("AV14EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV15EmployeeAPIPassword",GXType.VarChar,40,0)
          };
          Object[] prmP00CH3;
          prmP00CH3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV14EmployeeEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CH2", "SELECT EmployeeId, EmployeeName, EmployeeAPIPassword, EmployeeEmail FROM Employee WHERE (EmployeeEmail = ( :AV14EmployeeEmail)) AND (EmployeeAPIPassword = ( :AV15EmployeeAPIPassword)) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CH3", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T2.LeaveTypeName, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (:EmployeeEmail = ( :AV14EmployeeEmail)) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
