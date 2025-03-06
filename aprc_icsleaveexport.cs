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
                           long aP1_LeaveTypeId )
      {
         this.AV9ProjectId = aP0_ProjectId;
         this.AV8LeaveTypeId = aP1_LeaveTypeId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_ProjectId ,
                                 long aP1_LeaveTypeId )
      {
         this.AV9ProjectId = aP0_ProjectId;
         this.AV8LeaveTypeId = aP1_LeaveTypeId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  StringUtil.Str( (decimal)(AV8LeaveTypeId), 10, 0)+" : "+StringUtil.Str( (decimal)(AV9ProjectId), 10, 0)) ;
         AV10AuthorizationValue = StringUtil.FromBase64( StringUtil.StringReplace( AV11httprequest.GetHeader("Authorization"), "Basic ", ""));
         AV12CredsCollection = (GxSimpleCollection<string>)(GxRegex.Split(AV10AuthorizationValue,":"));
         AV13EmployeeEmail = ((string)AV12CredsCollection.Item(1));
         AV14EmployeeAPIPassword = ((string)AV12CredsCollection.Item(2));
         new logtofile(context ).execute(  AV13EmployeeEmail+":"+AV14EmployeeAPIPassword) ;
         AV22GXLvl13 = 0;
         /* Using cursor P00CO2 */
         pr_default.execute(0, new Object[] {AV13EmployeeEmail, AV14EmployeeAPIPassword});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A188EmployeeAPIPassword = P00CO2_A188EmployeeAPIPassword[0];
            A109EmployeeEmail = P00CO2_A109EmployeeEmail[0];
            A106EmployeeId = P00CO2_A106EmployeeId[0];
            AV22GXLvl13 = 1;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV22GXLvl13 == 0 )
         {
            AV21ErrorMessage = "ERROR: AUTH FAILED";
            AV20HttpResponse.AddString(AV21ErrorMessage);
            new logtofile(context ).execute(  AV21ErrorMessage) ;
            context.nUserReturn = 1;
            if ( context.WillRedirect( ) )
            {
               context.Redirect( context.wjLoc );
               context.wjLoc = "";
            }
            cleanup();
            if (true) return;
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV9ProjectId } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor P00CO3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A106EmployeeId = P00CO3_A106EmployeeId[0];
            A124LeaveTypeId = P00CO3_A124LeaveTypeId[0];
            A128LeaveRequestDate = P00CO3_A128LeaveRequestDate[0];
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
               GXt_char1 = AV15ICSLeaveExport;
               new formatdatetime(context ).execute(  A128LeaveRequestDate,  "YYYYMMDD", out  GXt_char1) ;
               AV15ICSLeaveExport += "DTSTAMP:" + GXt_char1 + "T000000Z" + StringUtil.NewLine( );
               GXt_char1 = AV15ICSLeaveExport;
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char1) ;
               AV15ICSLeaveExport += "DTSTART;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
               GXt_char1 = AV15ICSLeaveExport;
               new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char1) ;
               AV15ICSLeaveExport += "DTEND;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
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
         AV10AuthorizationValue = "";
         AV11httprequest = new GxHttpRequest( context);
         AV12CredsCollection = new GxSimpleCollection<string>();
         AV13EmployeeEmail = "";
         AV14EmployeeAPIPassword = "";
         P00CO2_A188EmployeeAPIPassword = new string[] {""} ;
         P00CO2_A109EmployeeEmail = new string[] {""} ;
         P00CO2_A106EmployeeId = new long[1] ;
         A188EmployeeAPIPassword = "";
         A109EmployeeEmail = "";
         AV21ErrorMessage = "";
         AV20HttpResponse = new GxHttpResponse( context);
         AV15ICSLeaveExport = "";
         P00CO3_A106EmployeeId = new long[1] ;
         P00CO3_A124LeaveTypeId = new long[1] ;
         P00CO3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00CO3_A125LeaveTypeName = new string[] {""} ;
         P00CO3_A148EmployeeName = new string[] {""} ;
         P00CO3_A109EmployeeEmail = new string[] {""} ;
         P00CO3_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_icsleaveexport__default(),
            new Object[][] {
                new Object[] {
               P00CO2_A188EmployeeAPIPassword, P00CO2_A109EmployeeEmail, P00CO2_A106EmployeeId
               }
               , new Object[] {
               P00CO3_A106EmployeeId, P00CO3_A124LeaveTypeId, P00CO3_A128LeaveRequestDate, P00CO3_A129LeaveRequestStartDate, P00CO3_A130LeaveRequestEndDate, P00CO3_A125LeaveTypeName, P00CO3_A148EmployeeName, P00CO3_A109EmployeeEmail, P00CO3_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV22GXLvl13 ;
      private long AV9ProjectId ;
      private long AV8LeaveTypeId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string GXt_char1 ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private string AV10AuthorizationValue ;
      private string AV15ICSLeaveExport ;
      private string AV13EmployeeEmail ;
      private string AV14EmployeeAPIPassword ;
      private string A188EmployeeAPIPassword ;
      private string A109EmployeeEmail ;
      private string AV21ErrorMessage ;
      private GxHttpRequest AV11httprequest ;
      private GxHttpResponse AV20HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12CredsCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00CO2_A188EmployeeAPIPassword ;
      private string[] P00CO2_A109EmployeeEmail ;
      private long[] P00CO2_A106EmployeeId ;
      private long[] P00CO3_A106EmployeeId ;
      private long[] P00CO3_A124LeaveTypeId ;
      private DateTime[] P00CO3_A128LeaveRequestDate ;
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
                                             long AV9ProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T3.LeaveTypeName, T2.EmployeeName, T2.EmployeeEmail, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00CO3(context, (long)dynConstraints[0] );
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
          new ParDef("AV13EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV14EmployeeAPIPassword",GXType.VarChar,40,0)
          };
          Object[] prmP00CO3;
          prmP00CO3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CO2", "SELECT EmployeeAPIPassword, EmployeeEmail, EmployeeId FROM Employee WHERE (EmployeeEmail = ( :AV13EmployeeEmail)) AND (EmployeeAPIPassword = ( :AV14EmployeeAPIPassword)) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
