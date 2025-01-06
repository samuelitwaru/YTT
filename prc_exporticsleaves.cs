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
   public class prc_exporticsleaves : GXProcedure
   {
      public prc_exporticsleaves( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_exporticsleaves( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_EmployeeId ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV13FromDate = aP0_FromDate;
         this.AV12ToDate = aP1_ToDate;
         this.AV14EmployeeId = aP2_EmployeeId;
         this.AV8Filename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP3_Filename=this.AV8Filename;
         aP4_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                long aP2_EmployeeId ,
                                out string aP3_Filename )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeId, out aP3_Filename, out aP4_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_EmployeeId ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         this.AV13FromDate = aP0_FromDate;
         this.AV12ToDate = aP1_ToDate;
         this.AV14EmployeeId = aP2_EmployeeId;
         this.AV8Filename = "" ;
         this.AV16ErrorMessage = "" ;
         SubmitImpl();
         aP3_Filename=this.AV8Filename;
         aP4_ErrorMessage=this.AV16ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Filename = "LeaveRequests.ics";
         AV9File.Source = AV8Filename;
         AV9File.Delete();
         AV9File.Open("");
         new logtofile(context ).execute(  ">>>>>>"+AV8Filename) ;
         AV10Lines.Add("BEGIN:VCALENDAR", 0);
         AV10Lines.Add("PRODID:-//Yukon Software//APiCalConverter//EN", 0);
         AV10Lines.Add("VERSION:2.0", 0);
         AV10Lines.Add("CALSCALE:GREGORIAN", 0);
         AV10Lines.Add("X-WR-TIMEZONE:Europe/Bucharest", 0);
         AV10Lines.Add("X-WR-CALNAME:Absence", 0);
         AV10Lines.Add("X-WR-CALDESC:", 0);
         AV10Lines.Add("METHOD:PUBLISH", 0);
         /* Using cursor P00CA2 */
         pr_default.execute(0, new Object[] {AV14EmployeeId, AV12ToDate, AV13FromDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00CA2_A124LeaveTypeId[0];
            A106EmployeeId = P00CA2_A106EmployeeId[0];
            A130LeaveRequestEndDate = P00CA2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00CA2_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = P00CA2_A128LeaveRequestDate[0];
            A125LeaveTypeName = P00CA2_A125LeaveTypeName[0];
            A148EmployeeName = P00CA2_A148EmployeeName[0];
            A109EmployeeEmail = P00CA2_A109EmployeeEmail[0];
            A127LeaveRequestId = P00CA2_A127LeaveRequestId[0];
            A125LeaveTypeName = P00CA2_A125LeaveTypeName[0];
            A148EmployeeName = P00CA2_A148EmployeeName[0];
            A109EmployeeEmail = P00CA2_A109EmployeeEmail[0];
            AV10Lines.Add("BEGIN:VEVENT", 0);
            AV10Lines.Add("DTSTAMP:"+new formatdatetime(context).executeUdp(  A128LeaveRequestDate,  "YYYYMMDD")+"T000000Z", 0);
            AV10Lines.Add("DTSTART;VALUE=DATE:"+new formatdatetime(context).executeUdp(  A129LeaveRequestStartDate,  "YYYYMMDD"), 0);
            AV10Lines.Add("DTEND;VALUE=DATE:"+new formatdatetime(context).executeUdp(  A130LeaveRequestEndDate,  "YYYYMMDD"), 0);
            AV10Lines.Add("SUMMARY:"+StringUtil.Trim( A148EmployeeName)+" | "+StringUtil.Trim( A125LeaveTypeName), 0);
            AV10Lines.Add("UID:"+StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0))+StringUtil.Trim( A109EmployeeEmail), 0);
            AV10Lines.Add("SEQUENCE:0", 0);
            AV10Lines.Add("X-CONFLUENCE-SUBCALENDAR-TYPE:subscription", 0);
            AV10Lines.Add("CATEGORIES:subscription", 0);
            AV10Lines.Add("TRANSP:TRANSPARENT", 0);
            AV10Lines.Add("STATUS:CONFIRMED", 0);
            AV10Lines.Add("END:VEVENT", 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV10Lines.Add("END:VCALENDAR", 0);
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV10Lines.Count )
         {
            AV19Oneline = ((string)AV10Lines.Item(AV18GXV1));
            AV9File.WriteLine(AV19Oneline);
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV9File.Close();
         AV15Session.Set("WWPExportFilePath", AV8Filename);
         AV15Session.Set("WWPExportFileName", AV8Filename);
         AV8Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV8Filename = "";
         AV16ErrorMessage = "";
         AV9File = new GxFile(context.GetPhysicalPath());
         AV10Lines = new GxSimpleCollection<string>();
         P00CA2_A124LeaveTypeId = new long[1] ;
         P00CA2_A106EmployeeId = new long[1] ;
         P00CA2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00CA2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00CA2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00CA2_A125LeaveTypeName = new string[] {""} ;
         P00CA2_A148EmployeeName = new string[] {""} ;
         P00CA2_A109EmployeeEmail = new string[] {""} ;
         P00CA2_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A128LeaveRequestDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         AV19Oneline = "";
         AV15Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_exporticsleaves__default(),
            new Object[][] {
                new Object[] {
               P00CA2_A124LeaveTypeId, P00CA2_A106EmployeeId, P00CA2_A130LeaveRequestEndDate, P00CA2_A129LeaveRequestStartDate, P00CA2_A128LeaveRequestDate, P00CA2_A125LeaveTypeName, P00CA2_A148EmployeeName, P00CA2_A109EmployeeEmail, P00CA2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private long AV14EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private DateTime AV13FromDate ;
      private DateTime AV12ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A128LeaveRequestDate ;
      private string AV19Oneline ;
      private string AV8Filename ;
      private string AV16ErrorMessage ;
      private string A109EmployeeEmail ;
      private IGxSession AV15Session ;
      private GxFile AV9File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV10Lines ;
      private IDataStoreProvider pr_default ;
      private long[] P00CA2_A124LeaveTypeId ;
      private long[] P00CA2_A106EmployeeId ;
      private DateTime[] P00CA2_A130LeaveRequestEndDate ;
      private DateTime[] P00CA2_A129LeaveRequestStartDate ;
      private DateTime[] P00CA2_A128LeaveRequestDate ;
      private string[] P00CA2_A125LeaveTypeName ;
      private string[] P00CA2_A148EmployeeName ;
      private string[] P00CA2_A109EmployeeEmail ;
      private long[] P00CA2_A127LeaveRequestId ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
   }

   public class prc_exporticsleaves__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CA2;
          prmP00CA2 = new Object[] {
          new ParDef("AV14EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV12ToDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CA2", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T3.EmployeeName, T3.EmployeeEmail, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE (T1.EmployeeId = :AV14EmployeeId) AND (T1.LeaveRequestStartDate <= :AV12ToDate) AND (T1.LeaveRequestEndDate >= :AV13FromDate) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA2,100, GxCacheFrequency.OFF ,true,false )
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
