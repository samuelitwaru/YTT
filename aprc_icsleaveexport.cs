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
   public class aprc_icsleaveexport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ProjectId");
            if ( ! entryPointCalled )
            {
               AV9ProjectId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
                  AV22Token = GetPar( "Token");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_icsleaveexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_icsleaveexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProjectId ,
                           long aP1_LeaveTypeId ,
                           string aP2_Token )
      {
         this.AV9ProjectId = aP0_ProjectId;
         this.AV8LeaveTypeId = aP1_LeaveTypeId;
         this.AV22Token = aP2_Token;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_ProjectId ,
                                 long aP1_LeaveTypeId ,
                                 string aP2_Token )
      {
         this.AV9ProjectId = aP0_ProjectId;
         this.AV8LeaveTypeId = aP1_LeaveTypeId;
         this.AV22Token = aP2_Token;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveTypeId), 10, 0))+" : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV9ProjectId), 10, 0))) ;
         new logtofile(context ).execute(  "Token: "+AV22Token) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22Token)) )
         {
            /* Execute user subroutine: 'AUTHFAILED' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV23GXLvl8 = 0;
         /* Using cursor P00CO2 */
         pr_default.execute(0, new Object[] {AV22Token});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A188EmployeeAPIPassword = P00CO2_A188EmployeeAPIPassword[0];
            A106EmployeeId = P00CO2_A106EmployeeId[0];
            AV23GXLvl8 = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV23GXLvl8 == 0 )
         {
            /* Execute user subroutine: 'AUTHFAILED' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV15ICSLeaveExport = "";
         AV15ICSLeaveExport += "BEGIN:VCALENDAR" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "PRODID:-//Yukon Software//APiCalConverter//EN" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "VERSION:2.0" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "CALSCALE:GREGORIAN" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:VTIMEZONE" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZID:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "LAST-MODIFIED:20240422T053450Z" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZURL:https://www.tzurl.org/zoneinfo/EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "X-LIC-LOCATION:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "X-PROLEPTIC-TZNAME;X-NO-BIG-BANG=TRUE:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "DTSTART:19770403T030000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19800406T010000Z;BYMONTH=4;BYDAY=1SU" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "DTSTART:19770925T040000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "RDATE:19781001T040000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "DTSTART:19790930T040000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19950924T010000Z;BYMONTH=9;BYDAY=-1SU" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "DTSTART:19810329T030000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "DTSTART:19961027T040000" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "END:VTIMEZONE" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "X-WR-TIMEZONE:Europe/Bucharest" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "X-WR-CALNAME:Absence" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "X-WR-CALDESC:" + StringUtil.NewLine( );
         AV15ICSLeaveExport += "METHOD:PUBLISH" + StringUtil.NewLine( );
         AV18ProjectIdCollection.Add(AV9ProjectId, 0);
         GXt_objcol_int1 = AV19EmployeeIdCollection;
         new getemployeeidsbyproject(context ).execute(  AV18ProjectIdCollection, out  GXt_objcol_int1) ;
         AV19EmployeeIdCollection = GXt_objcol_int1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV19EmployeeIdCollection ,
                                              AV9ProjectId ,
                                              AV19EmployeeIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor P00CO3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A106EmployeeId = P00CO3_A106EmployeeId[0];
            A124LeaveTypeId = P00CO3_A124LeaveTypeId[0];
            A128LeaveRequestDate = P00CO3_A128LeaveRequestDate[0];
            A173LeaveRequestHalfDay = P00CO3_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00CO3_n173LeaveRequestHalfDay[0];
            A129LeaveRequestStartDate = P00CO3_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00CO3_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = P00CO3_A125LeaveTypeName[0];
            A148EmployeeName = P00CO3_A148EmployeeName[0];
            A109EmployeeEmail = P00CO3_A109EmployeeEmail[0];
            A127LeaveRequestId = P00CO3_A127LeaveRequestId[0];
            A148EmployeeName = P00CO3_A148EmployeeName[0];
            A109EmployeeEmail = P00CO3_A109EmployeeEmail[0];
            A125LeaveTypeName = P00CO3_A125LeaveTypeName[0];
            if ( A124LeaveTypeId == AV8LeaveTypeId )
            {
               AV15ICSLeaveExport += "BEGIN:VEVENT" + StringUtil.NewLine( );
               GXt_char2 = AV15ICSLeaveExport;
               new formatdatetime(context ).execute(  A128LeaveRequestDate,  "YYYYMMDD", out  GXt_char2) ;
               AV15ICSLeaveExport += "DTSTAMP:" + GXt_char2 + "T000000Z" + StringUtil.NewLine( );
               if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Morning") == 0 )
               {
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTSTART;TZID=Europe/Bucharest:" + GXt_char2 + "T090000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTEND;TZID=Europe/Bucharest:" + GXt_char2 + "T130000Z" + StringUtil.NewLine( );
               }
               else if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Afternoon") == 0 )
               {
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTSTART;TZID=Europe/Bucharest:" + GXt_char2 + "T130000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTEND;TZID=Europe/Bucharest:" + GXt_char2 + "T170000Z" + StringUtil.NewLine( );
               }
               else
               {
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTSTART;VALUE=DATE:" + GXt_char2 + "T000000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV15ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV15ICSLeaveExport += "DTEND;VALUE=DATE:" + GXt_char2 + "T235959Z" + StringUtil.NewLine( );
               }
               AV15ICSLeaveExport += "SUMMARY:" + StringUtil.Trim( A148EmployeeName) + " | " + StringUtil.Trim( A125LeaveTypeName) + StringUtil.NewLine( );
               AV15ICSLeaveExport += "UID:" + StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0)) + StringUtil.Trim( A109EmployeeEmail) + StringUtil.NewLine( );
               AV15ICSLeaveExport += "END:VEVENT" + StringUtil.NewLine( );
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         new logtofile(context ).execute(  AV15ICSLeaveExport) ;
         new logtofile(context ).execute(  "----------------------------------------------------------") ;
         AV15ICSLeaveExport += "END:VCALENDAR" + StringUtil.NewLine( );
         AV20HttpResponse.AddString(AV15ICSLeaveExport);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'AUTHFAILED' Routine */
         returnInSub = false;
         AV21ErrorMessage = "ERROR: AUTH FAILED";
         AV20HttpResponse.AddString(AV21ErrorMessage);
         new logtofile(context ).execute(  AV21ErrorMessage) ;
         context.nUserReturn = 1;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         returnInSub = true;
         if (true) return;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P00CO2_A188EmployeeAPIPassword = new string[] {""} ;
         P00CO2_A106EmployeeId = new long[1] ;
         A188EmployeeAPIPassword = "";
         AV15ICSLeaveExport = "";
         AV18ProjectIdCollection = new GxSimpleCollection<long>();
         AV19EmployeeIdCollection = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         P00CO3_A106EmployeeId = new long[1] ;
         P00CO3_A124LeaveTypeId = new long[1] ;
         P00CO3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A173LeaveRequestHalfDay = new string[] {""} ;
         P00CO3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00CO3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A125LeaveTypeName = new string[] {""} ;
         P00CO3_A148EmployeeName = new string[] {""} ;
         P00CO3_A109EmployeeEmail = new string[] {""} ;
         P00CO3_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         GXt_char2 = "";
         AV20HttpResponse = new GxHttpResponse( context);
         AV21ErrorMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_icsleaveexport__default(),
            new Object[][] {
                new Object[] {
               P00CO2_A188EmployeeAPIPassword, P00CO2_A106EmployeeId
               }
               , new Object[] {
               P00CO3_A106EmployeeId, P00CO3_A124LeaveTypeId, P00CO3_A128LeaveRequestDate, P00CO3_A173LeaveRequestHalfDay, P00CO3_n173LeaveRequestHalfDay, P00CO3_A129LeaveRequestStartDate, P00CO3_A130LeaveRequestEndDate, P00CO3_A125LeaveTypeName, P00CO3_A148EmployeeName, P00CO3_A109EmployeeEmail,
               P00CO3_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV23GXLvl8 ;
      private int AV19EmployeeIdCollection_Count ;
      private long AV9ProjectId ;
      private long AV8LeaveTypeId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A173LeaveRequestHalfDay ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool n173LeaveRequestHalfDay ;
      private string AV15ICSLeaveExport ;
      private string AV22Token ;
      private string A188EmployeeAPIPassword ;
      private string A109EmployeeEmail ;
      private string AV21ErrorMessage ;
      private GxHttpResponse AV20HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00CO2_A188EmployeeAPIPassword ;
      private long[] P00CO2_A106EmployeeId ;
      private GxSimpleCollection<long> AV18ProjectIdCollection ;
      private GxSimpleCollection<long> AV19EmployeeIdCollection ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private long[] P00CO3_A106EmployeeId ;
      private long[] P00CO3_A124LeaveTypeId ;
      private DateTime[] P00CO3_A128LeaveRequestDate ;
      private string[] P00CO3_A173LeaveRequestHalfDay ;
      private bool[] P00CO3_n173LeaveRequestHalfDay ;
      private DateTime[] P00CO3_A129LeaveRequestStartDate ;
      private DateTime[] P00CO3_A130LeaveRequestEndDate ;
      private string[] P00CO3_A125LeaveTypeName ;
      private string[] P00CO3_A148EmployeeName ;
      private string[] P00CO3_A109EmployeeEmail ;
      private long[] P00CO3_A127LeaveRequestId ;
   }

   public class aprc_icsleaveexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CO3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV19EmployeeIdCollection ,
                                             long AV9ProjectId ,
                                             int AV19EmployeeIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDate, T1.LeaveRequestHalfDay, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T3.LeaveTypeName, T2.EmployeeName, T2.EmployeeEmail, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         if ( AV19EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00CO3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (int)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00CO2;
          prmP00CO2 = new Object[] {
          new ParDef("AV22Token",GXType.VarChar,40,0)
          };
          Object[] prmP00CO3;
          prmP00CO3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CO2", "SELECT EmployeeAPIPassword, EmployeeId FROM Employee WHERE EmployeeAPIPassword = ( :AV22Token) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CO3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
