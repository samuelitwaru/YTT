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
   public class sdsendpushnotifications : GXProcedure
   {
      public sdsendpushnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdsendpushnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Title ,
                           string aP1_Text ,
                           long aP2_EmployeeId )
      {
         this.AV22Title = aP0_Title;
         this.AV18Text = aP1_Text;
         this.AV10EmployeeId = aP2_EmployeeId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Text ,
                                 long aP2_EmployeeId )
      {
         sdsendpushnotifications objsdsendpushnotifications;
         objsdsendpushnotifications = new sdsendpushnotifications();
         objsdsendpushnotifications.AV22Title = aP0_Title;
         objsdsendpushnotifications.AV18Text = aP1_Text;
         objsdsendpushnotifications.AV10EmployeeId = aP2_EmployeeId;
         objsdsendpushnotifications.context.SetSubmitInitialConfig(context);
         objsdsendpushnotifications.initialize();
         Submit( executePrivateCatch,objsdsendpushnotifications);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sdsendpushnotifications)stateInfo).executePrivate();
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
         new getloggedinuser(context ).execute( out  AV11GAMUser, out  AV9Employee) ;
         /* Using cursor P005Q2 */
         pr_default.execute(0, new Object[] {AV9Employee.gxTpr_Companyid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112EmployeeIsActive = P005Q2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P005Q2_A110EmployeeIsManager[0];
            A100CompanyId = P005Q2_A100CompanyId[0];
            A111GAMUserGUID = P005Q2_A111GAMUserGUID[0];
            A106EmployeeId = P005Q2_A106EmployeeId[0];
            AV14ManagerGUID = A111GAMUserGUID;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P005Q3 */
         pr_default.execute(1, new Object[] {AV14ManagerGUID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A150DeviceUser = P005Q3_A150DeviceUser[0];
            n150DeviceUser = P005Q3_n150DeviceUser[0];
            A149DeviceToken = P005Q3_A149DeviceToken[0];
            A151DeviceId = P005Q3_A151DeviceId[0];
            AV13ManagerDeviceToken = A149DeviceToken;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV15NewEmployee.Load(AV10EmployeeId);
         /* Using cursor P005Q4 */
         pr_default.execute(2, new Object[] {AV15NewEmployee.gxTpr_Gamuserguid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A150DeviceUser = P005Q4_A150DeviceUser[0];
            n150DeviceUser = P005Q4_n150DeviceUser[0];
            A149DeviceToken = P005Q4_A149DeviceToken[0];
            A151DeviceId = P005Q4_A151DeviceId[0];
            AV16NewEmployeeDeviceToken = A149DeviceToken;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV19TheNotification.gxTpr_Title.gxTpr_Defaulttext = AV22Title;
         AV19TheNotification.gxTpr_Text.gxTpr_Defaulttext = AV18Text;
         AV21TheNotificationDelivery.gxTpr_Priority = "High";
         AV20TheNotificationConfiguration.gxTpr_Applicationid = "YTTV3SD";
         if ( (0==AV10EmployeeId) || ( AV10EmployeeId == 0 ) )
         {
            AV8DeviceToken = AV13ManagerDeviceToken;
         }
         else
         {
            AV8DeviceToken = AV16NewEmployeeDeviceToken;
         }
         new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV20TheNotificationConfiguration,  AV8DeviceToken,  AV19TheNotification,  AV21TheNotificationDelivery, out  AV17OutMessages, out  AV12IsSuccessful) ;
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
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9Employee = new SdtEmployee(context);
         scmdbuf = "";
         P005Q2_A112EmployeeIsActive = new bool[] {false} ;
         P005Q2_A110EmployeeIsManager = new bool[] {false} ;
         P005Q2_A100CompanyId = new long[1] ;
         P005Q2_A111GAMUserGUID = new string[] {""} ;
         P005Q2_A106EmployeeId = new long[1] ;
         A111GAMUserGUID = "";
         AV14ManagerGUID = "";
         P005Q3_A150DeviceUser = new string[] {""} ;
         P005Q3_n150DeviceUser = new bool[] {false} ;
         P005Q3_A149DeviceToken = new string[] {""} ;
         P005Q3_A151DeviceId = new string[] {""} ;
         A150DeviceUser = "";
         A149DeviceToken = "";
         A151DeviceId = "";
         AV13ManagerDeviceToken = "";
         AV15NewEmployee = new SdtEmployee(context);
         P005Q4_A150DeviceUser = new string[] {""} ;
         P005Q4_n150DeviceUser = new bool[] {false} ;
         P005Q4_A149DeviceToken = new string[] {""} ;
         P005Q4_A151DeviceId = new string[] {""} ;
         AV16NewEmployeeDeviceToken = "";
         AV19TheNotification = new GeneXus.Core.genexus.common.notifications.SdtNotification(context);
         AV21TheNotificationDelivery = new GeneXus.Core.genexus.common.notifications.SdtDelivery(context);
         AV20TheNotificationConfiguration = new GeneXus.Core.genexus.common.notifications.SdtConfiguration(context);
         AV8DeviceToken = "";
         AV17OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsendpushnotifications__default(),
            new Object[][] {
                new Object[] {
               P005Q2_A112EmployeeIsActive, P005Q2_A110EmployeeIsManager, P005Q2_A100CompanyId, P005Q2_A111GAMUserGUID, P005Q2_A106EmployeeId
               }
               , new Object[] {
               P005Q3_A150DeviceUser, P005Q3_n150DeviceUser, P005Q3_A149DeviceToken, P005Q3_A151DeviceId
               }
               , new Object[] {
               P005Q4_A150DeviceUser, P005Q4_n150DeviceUser, P005Q4_A149DeviceToken, P005Q4_A151DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10EmployeeId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private string AV18Text ;
      private string scmdbuf ;
      private string A149DeviceToken ;
      private string A151DeviceId ;
      private string AV13ManagerDeviceToken ;
      private string AV16NewEmployeeDeviceToken ;
      private string AV8DeviceToken ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private bool n150DeviceUser ;
      private bool AV12IsSuccessful ;
      private string AV22Title ;
      private string A111GAMUserGUID ;
      private string AV14ManagerGUID ;
      private string A150DeviceUser ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P005Q2_A112EmployeeIsActive ;
      private bool[] P005Q2_A110EmployeeIsManager ;
      private long[] P005Q2_A100CompanyId ;
      private string[] P005Q2_A111GAMUserGUID ;
      private long[] P005Q2_A106EmployeeId ;
      private string[] P005Q3_A150DeviceUser ;
      private bool[] P005Q3_n150DeviceUser ;
      private string[] P005Q3_A149DeviceToken ;
      private string[] P005Q3_A151DeviceId ;
      private string[] P005Q4_A150DeviceUser ;
      private bool[] P005Q4_n150DeviceUser ;
      private string[] P005Q4_A149DeviceToken ;
      private string[] P005Q4_A151DeviceId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17OutMessages ;
      private SdtEmployee AV9Employee ;
      private SdtEmployee AV15NewEmployee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV19TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV20TheNotificationConfiguration ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV21TheNotificationDelivery ;
   }

   public class sdsendpushnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005Q2;
          prmP005Q2 = new Object[] {
          new ParDef("AV9Employee__Companyid",GXType.Int64,10,0)
          };
          Object[] prmP005Q3;
          prmP005Q3 = new Object[] {
          new ParDef("AV14ManagerGUID",GXType.VarChar,100,60)
          };
          Object[] prmP005Q4;
          prmP005Q4 = new Object[] {
          new ParDef("AV15NewEmployee__Gamuserguid",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P005Q2", "SELECT EmployeeIsActive, EmployeeIsManager, CompanyId, GAMUserGUID, EmployeeId FROM Employee WHERE (CompanyId = :AV9Employee__Companyid) AND (EmployeeIsManager = TRUE) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q3", "SELECT DeviceUser, DeviceToken, DeviceId FROM Device WHERE DeviceUser = ( :AV14ManagerGUID) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q4", "SELECT DeviceUser, DeviceToken, DeviceId FROM Device WHERE DeviceUser = ( :AV15NewEmployee__Gamuserguid) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1000);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1000);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                return;
       }
    }

 }

}
