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
   public class dpleavetype : GXProcedure
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public dpleavetype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleavetype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyId ,
                           out GXBaseCollection<SdtSDTLeaveType> aP1_Gxm2rootcol )
      {
         this.AV5CompanyId = aP0_CompanyId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTLeaveType> executeUdp( long aP0_CompanyId )
      {
         execute(aP0_CompanyId, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( long aP0_CompanyId ,
                                 out GXBaseCollection<SdtSDTLeaveType> aP1_Gxm2rootcol )
      {
         dpleavetype objdpleavetype;
         objdpleavetype = new dpleavetype();
         objdpleavetype.AV5CompanyId = aP0_CompanyId;
         objdpleavetype.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4") ;
         objdpleavetype.context.SetSubmitInitialConfig(context);
         objdpleavetype.initialize();
         Submit( executePrivateCatch,objdpleavetype);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpleavetype)stateInfo).executePrivate();
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
         /* Using cursor P001V2 */
         pr_default.execute(0, new Object[] {AV5CompanyId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A175LeaveTypeColorApproved = P001V2_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P001V2_n175LeaveTypeColorApproved[0];
            A100CompanyId = P001V2_A100CompanyId[0];
            A124LeaveTypeId = P001V2_A124LeaveTypeId[0];
            A125LeaveTypeName = P001V2_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = P001V2_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P001V2_A145LeaveTypeLoggingWorkHours[0];
            A174LeaveTypeColorPending = P001V2_A174LeaveTypeColorPending[0];
            n174LeaveTypeColorPending = P001V2_n174LeaveTypeColorPending[0];
            Gxm1sdtleavetype = new SdtSDTLeaveType(context);
            Gxm2rootcol.Add(Gxm1sdtleavetype, 0);
            Gxm1sdtleavetype.gxTpr_Leavetypeid = A124LeaveTypeId;
            Gxm1sdtleavetype.gxTpr_Leavetypename = A125LeaveTypeName;
            Gxm1sdtleavetype.gxTpr_Leavetypevacationleave = A144LeaveTypeVacationLeave;
            Gxm1sdtleavetype.gxTpr_Leavetypeloggingworkhours = A145LeaveTypeLoggingWorkHours;
            Gxm1sdtleavetype.gxTpr_Leavetypecolorpending = A174LeaveTypeColorPending;
            Gxm1sdtleavetype.gxTpr_Leavetypecolorapproved = A175LeaveTypeColorApproved;
            Gxm1sdtleavetype.gxTpr_Companyid = A100CompanyId;
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
         P001V2_A175LeaveTypeColorApproved = new string[] {""} ;
         P001V2_n175LeaveTypeColorApproved = new bool[] {false} ;
         P001V2_A100CompanyId = new long[1] ;
         P001V2_A124LeaveTypeId = new long[1] ;
         P001V2_A125LeaveTypeName = new string[] {""} ;
         P001V2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P001V2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P001V2_A174LeaveTypeColorPending = new string[] {""} ;
         P001V2_n174LeaveTypeColorPending = new bool[] {false} ;
         A175LeaveTypeColorApproved = "";
         A125LeaveTypeName = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A174LeaveTypeColorPending = "";
         Gxm1sdtleavetype = new SdtSDTLeaveType(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpleavetype__default(),
            new Object[][] {
                new Object[] {
               P001V2_A175LeaveTypeColorApproved, P001V2_n175LeaveTypeColorApproved, P001V2_A100CompanyId, P001V2_A124LeaveTypeId, P001V2_A125LeaveTypeName, P001V2_A144LeaveTypeVacationLeave, P001V2_A145LeaveTypeLoggingWorkHours, P001V2_A174LeaveTypeColorPending, P001V2_n174LeaveTypeColorPending
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV5CompanyId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private string scmdbuf ;
      private string A175LeaveTypeColorApproved ;
      private string A125LeaveTypeName ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A174LeaveTypeColorPending ;
      private bool n175LeaveTypeColorApproved ;
      private bool n174LeaveTypeColorPending ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001V2_A175LeaveTypeColorApproved ;
      private bool[] P001V2_n175LeaveTypeColorApproved ;
      private long[] P001V2_A100CompanyId ;
      private long[] P001V2_A124LeaveTypeId ;
      private string[] P001V2_A125LeaveTypeName ;
      private string[] P001V2_A144LeaveTypeVacationLeave ;
      private string[] P001V2_A145LeaveTypeLoggingWorkHours ;
      private string[] P001V2_A174LeaveTypeColorPending ;
      private bool[] P001V2_n174LeaveTypeColorPending ;
      private GXBaseCollection<SdtSDTLeaveType> aP1_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTLeaveType> Gxm2rootcol ;
      private SdtSDTLeaveType Gxm1sdtleavetype ;
   }

   public class dpleavetype__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001V2;
          prmP001V2 = new Object[] {
          new ParDef("AV5CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001V2", "SELECT LeaveTypeColorApproved, CompanyId, LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending FROM LeaveType WHERE (CompanyId = :AV5CompanyId) AND (Not (char_length(trim(trailing ' ' from LeaveTypeColorApproved))=0)) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
