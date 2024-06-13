using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class leavetypeconversion : GXProcedure
   {
      public leavetypeconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public leavetypeconversion( IGxContext context )
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
         leavetypeconversion objleavetypeconversion;
         objleavetypeconversion = new leavetypeconversion();
         objleavetypeconversion.context.SetSubmitInitialConfig(context);
         objleavetypeconversion.initialize();
         Submit( executePrivateCatch,objleavetypeconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leavetypeconversion)stateInfo).executePrivate();
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
         /* Using cursor LEAVETYPEC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A175LeaveTypeColorApproved = LEAVETYPEC2_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = LEAVETYPEC2_n175LeaveTypeColorApproved[0];
            A174LeaveTypeColorPending = LEAVETYPEC2_A174LeaveTypeColorPending[0];
            n174LeaveTypeColorPending = LEAVETYPEC2_n174LeaveTypeColorPending[0];
            A145LeaveTypeLoggingWorkHours = LEAVETYPEC2_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = LEAVETYPEC2_A144LeaveTypeVacationLeave[0];
            A100CompanyId = LEAVETYPEC2_A100CompanyId[0];
            A125LeaveTypeName = LEAVETYPEC2_A125LeaveTypeName[0];
            A124LeaveTypeId = LEAVETYPEC2_A124LeaveTypeId[0];
            /*
               INSERT RECORD ON TABLE GXA0020

            */
            AV2LeaveTypeId = A124LeaveTypeId;
            AV3LeaveTypeName = A125LeaveTypeName;
            AV4CompanyId = A100CompanyId;
            AV5LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            AV6LeaveTypeLoggingWorkHours = A145LeaveTypeLoggingWorkHours;
            if ( LEAVETYPEC2_n174LeaveTypeColorPending[0] )
            {
               AV7LeaveTypeColorPending = " ";
            }
            else
            {
               AV7LeaveTypeColorPending = A174LeaveTypeColorPending;
            }
            if ( LEAVETYPEC2_n175LeaveTypeColorApproved[0] )
            {
               AV8LeaveTypeColorApproved = " ";
            }
            else
            {
               AV8LeaveTypeColorApproved = A175LeaveTypeColorApproved;
            }
            /* Using cursor LEAVETYPEC3 */
            pr_default.execute(1, new Object[] {AV2LeaveTypeId, AV3LeaveTypeName, AV4CompanyId, AV5LeaveTypeVacationLeave, AV6LeaveTypeLoggingWorkHours, AV7LeaveTypeColorPending, AV8LeaveTypeColorApproved});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0020");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         LEAVETYPEC2_A175LeaveTypeColorApproved = new string[] {""} ;
         LEAVETYPEC2_n175LeaveTypeColorApproved = new bool[] {false} ;
         LEAVETYPEC2_A174LeaveTypeColorPending = new string[] {""} ;
         LEAVETYPEC2_n174LeaveTypeColorPending = new bool[] {false} ;
         LEAVETYPEC2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         LEAVETYPEC2_A144LeaveTypeVacationLeave = new string[] {""} ;
         LEAVETYPEC2_A100CompanyId = new long[1] ;
         LEAVETYPEC2_A125LeaveTypeName = new string[] {""} ;
         LEAVETYPEC2_A124LeaveTypeId = new long[1] ;
         A175LeaveTypeColorApproved = "";
         A174LeaveTypeColorPending = "";
         A145LeaveTypeLoggingWorkHours = "";
         A144LeaveTypeVacationLeave = "";
         A125LeaveTypeName = "";
         AV3LeaveTypeName = "";
         AV5LeaveTypeVacationLeave = "";
         AV6LeaveTypeLoggingWorkHours = "";
         AV7LeaveTypeColorPending = "";
         AV8LeaveTypeColorApproved = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetypeconversion__default(),
            new Object[][] {
                new Object[] {
               LEAVETYPEC2_A175LeaveTypeColorApproved, LEAVETYPEC2_n175LeaveTypeColorApproved, LEAVETYPEC2_A174LeaveTypeColorPending, LEAVETYPEC2_n174LeaveTypeColorPending, LEAVETYPEC2_A145LeaveTypeLoggingWorkHours, LEAVETYPEC2_A144LeaveTypeVacationLeave, LEAVETYPEC2_A100CompanyId, LEAVETYPEC2_A125LeaveTypeName, LEAVETYPEC2_A124LeaveTypeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0020 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long AV2LeaveTypeId ;
      private long AV4CompanyId ;
      private string scmdbuf ;
      private string A175LeaveTypeColorApproved ;
      private string A174LeaveTypeColorPending ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A144LeaveTypeVacationLeave ;
      private string A125LeaveTypeName ;
      private string AV3LeaveTypeName ;
      private string AV5LeaveTypeVacationLeave ;
      private string AV6LeaveTypeLoggingWorkHours ;
      private string AV7LeaveTypeColorPending ;
      private string AV8LeaveTypeColorApproved ;
      private string Gx_emsg ;
      private bool n175LeaveTypeColorApproved ;
      private bool n174LeaveTypeColorPending ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] LEAVETYPEC2_A175LeaveTypeColorApproved ;
      private bool[] LEAVETYPEC2_n175LeaveTypeColorApproved ;
      private string[] LEAVETYPEC2_A174LeaveTypeColorPending ;
      private bool[] LEAVETYPEC2_n174LeaveTypeColorPending ;
      private string[] LEAVETYPEC2_A145LeaveTypeLoggingWorkHours ;
      private string[] LEAVETYPEC2_A144LeaveTypeVacationLeave ;
      private long[] LEAVETYPEC2_A100CompanyId ;
      private string[] LEAVETYPEC2_A125LeaveTypeName ;
      private long[] LEAVETYPEC2_A124LeaveTypeId ;
   }

   public class leavetypeconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLEAVETYPEC2;
          prmLEAVETYPEC2 = new Object[] {
          };
          Object[] prmLEAVETYPEC3;
          prmLEAVETYPEC3 = new Object[] {
          new ParDef("AV2LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV3LeaveTypeName",GXType.Char,100,0) ,
          new ParDef("AV4CompanyId",GXType.Int64,10,0) ,
          new ParDef("AV5LeaveTypeVacationLeave",GXType.Char,20,0) ,
          new ParDef("AV6LeaveTypeLoggingWorkHours",GXType.Char,20,0) ,
          new ParDef("AV7LeaveTypeColorPending",GXType.Char,20,0) ,
          new ParDef("AV8LeaveTypeColorApproved",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("LEAVETYPEC2", "SELECT LeaveTypeColorApproved, LeaveTypeColorPending, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, CompanyId, LeaveTypeName, LeaveTypeId FROM LeaveType ORDER BY LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLEAVETYPEC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LEAVETYPEC3", "INSERT INTO GXA0020(LeaveTypeId, LeaveTypeName, CompanyId, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved) VALUES(:AV2LeaveTypeId, :AV3LeaveTypeName, :AV4CompanyId, :AV5LeaveTypeVacationLeave, :AV6LeaveTypeLoggingWorkHours, :AV7LeaveTypeColorPending, :AV8LeaveTypeColorApproved)", GxErrorMask.GX_NOMASK,prmLEAVETYPEC3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 100);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
