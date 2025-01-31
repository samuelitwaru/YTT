using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getusersfromrole : GXProcedure
   {
      public wwp_getusersfromrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfromrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPSubscriptionRoleId ,
                           out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_WWPUserExtendedIdCollection=this.AV9WWPUserExtendedIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_WWPSubscriptionRoleId )
      {
         execute(aP0_WWPSubscriptionRoleId, out aP1_WWPUserExtendedIdCollection);
         return AV9WWPUserExtendedIdCollection ;
      }

      public void executeSubmit( string aP0_WWPSubscriptionRoleId ,
                                 out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_WWPUserExtendedIdCollection=this.AV9WWPUserExtendedIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrolebyguid(AV10WWPSubscriptionRoleId, out  AV13GAMErrorCollection);
         AV14GAMUserCollection = AV12GAMRole.getusers(out  AV13GAMErrorCollection);
         AV9WWPUserExtendedIdCollection.Clear();
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV14GAMUserCollection.Count )
         {
            AV11GAMUser = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV14GAMUserCollection.Item(AV15GXV1));
            AV9WWPUserExtendedIdCollection.Add(AV11GAMUser.gxTpr_Guid, 0);
            AV15GXV1 = (int)(AV15GXV1+1);
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
         AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV12GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV13GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMUserCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
      }

      private int AV15GXV1 ;
      private string AV10WWPSubscriptionRoleId ;
      private GxSimpleCollection<string> AV9WWPUserExtendedIdCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV12GAMRole ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV14GAMUserCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection ;
   }

}
