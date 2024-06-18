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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class project_bc : GxSilentTrn, IGxSilentTrn
   {
      public project_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public project_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0E15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E15( ) ;
         standaloneModal( ) ;
         AddRow0E15( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z102ProjectId = A102ProjectId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E15( ) ;
            }
            else
            {
               CheckExtendedTable0E15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0E15( 11) ;
                  ZM0E15( 12) ;
               }
               CloseExtendedTableCursors0E15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProjectManagerId") == 0 )
               {
                  AV20Insert_ProjectManagerId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new assignprojectmanager(context ).execute(  AV22ComboProjectManagerId,  A102ProjectId) ;
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z103ProjectName = A103ProjectName;
            Z104ProjectDescription = A104ProjectDescription;
            Z105ProjectStatus = A105ProjectStatus;
            Z166ProjectManagerId = A166ProjectManagerId;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z167ProjectManagerName = A167ProjectManagerName;
            Z176ProjectManagerEmail = A176ProjectManagerEmail;
            Z177ProjectManagerIsActive = A177ProjectManagerIsActive;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z103ProjectName = A103ProjectName;
            Z104ProjectDescription = A104ProjectDescription;
            Z105ProjectStatus = A105ProjectStatus;
            Z166ProjectManagerId = A166ProjectManagerId;
            Z102ProjectId = A102ProjectId;
            Z167ProjectManagerName = A167ProjectManagerName;
            Z176ProjectManagerEmail = A176ProjectManagerEmail;
            Z177ProjectManagerIsActive = A177ProjectManagerIsActive;
         }
      }

      protected void standaloneNotModal( )
      {
         AV32Pgmname = "Project_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A105ProjectStatus)) && ( Gx_BScreen == 0 ) )
         {
            A105ProjectStatus = "Active";
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor BC000E6 */
         pr_default.execute(4, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
            A103ProjectName = BC000E6_A103ProjectName[0];
            A104ProjectDescription = BC000E6_A104ProjectDescription[0];
            A105ProjectStatus = BC000E6_A105ProjectStatus[0];
            A167ProjectManagerName = BC000E6_A167ProjectManagerName[0];
            A176ProjectManagerEmail = BC000E6_A176ProjectManagerEmail[0];
            A177ProjectManagerIsActive = BC000E6_A177ProjectManagerIsActive[0];
            A166ProjectManagerId = BC000E6_A166ProjectManagerId[0];
            n166ProjectManagerId = BC000E6_n166ProjectManagerId[0];
            ZM0E15( -9) ;
         }
         pr_default.close(4);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {n166ProjectManagerId, A166ProjectManagerId, A102ProjectId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A166ProjectManagerId) || (0==A102ProjectId) ) )
            {
               GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC000E7 */
         pr_default.execute(5, new Object[] {A103ProjectName, A102ProjectId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Project Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(5);
         if ( new employeehasproject(context).executeUdp(  A166ProjectManagerId,  A102ProjectId) && IsUpd( )  )
         {
            GX_msglist.addItem("No matching Employee Project", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) )
         {
            GX_msglist.addItem("Project Name cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A105ProjectStatus, "Active") == 0 ) || ( StringUtil.StrCmp(A105ProjectStatus, "Inactive") == 0 ) ) )
         {
            GX_msglist.addItem("Field Project Status is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {n166ProjectManagerId, A166ProjectManagerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A166ProjectManagerId) ) )
            {
               GX_msglist.addItem("No matching 'Project Manager'.", "ForeignKeyNotFound", 1, "PROJECTMANAGERID");
               AnyError = 1;
            }
         }
         A167ProjectManagerName = BC000E4_A167ProjectManagerName[0];
         A176ProjectManagerEmail = BC000E4_A176ProjectManagerEmail[0];
         A177ProjectManagerIsActive = BC000E4_A177ProjectManagerIsActive[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E15( )
      {
         /* Using cursor BC000E8 */
         pr_default.execute(6, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 9) ;
            RcdFound15 = 1;
            A103ProjectName = BC000E3_A103ProjectName[0];
            A104ProjectDescription = BC000E3_A104ProjectDescription[0];
            A105ProjectStatus = BC000E3_A105ProjectStatus[0];
            A166ProjectManagerId = BC000E3_A166ProjectManagerId[0];
            n166ProjectManagerId = BC000E3_n166ProjectManagerId[0];
            A102ProjectId = BC000E3_A102ProjectId[0];
            Z102ProjectId = A102ProjectId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0E0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Project"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103ProjectName, BC000E2_A103ProjectName[0]) != 0 ) || ( StringUtil.StrCmp(Z104ProjectDescription, BC000E2_A104ProjectDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z105ProjectStatus, BC000E2_A105ProjectStatus[0]) != 0 ) || ( Z166ProjectManagerId != BC000E2_A166ProjectManagerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Project"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E9 */
                     pr_default.execute(7, new Object[] {A103ProjectName, A104ProjectDescription, A105ProjectStatus, n166ProjectManagerId, A166ProjectManagerId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000E10 */
                     pr_default.execute(8);
                     A102ProjectId = BC000E10_A102ProjectId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Project");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E11 */
                     pr_default.execute(9, new Object[] {A103ProjectName, A104ProjectDescription, A105ProjectStatus, n166ProjectManagerId, A166ProjectManagerId, A102ProjectId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Project");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Project"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E12 */
                  pr_default.execute(10, new Object[] {A102ProjectId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Project");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( new employeehasproject(context).executeUdp(  A166ProjectManagerId,  A102ProjectId) && IsUpd( )  )
            {
               GX_msglist.addItem("No matching Employee Project", 1, "");
               AnyError = 1;
            }
            /* Using cursor BC000E13 */
            pr_default.execute(11, new Object[] {n166ProjectManagerId, A166ProjectManagerId});
            A167ProjectManagerName = BC000E13_A167ProjectManagerName[0];
            A176ProjectManagerEmail = BC000E13_A176ProjectManagerEmail[0];
            A177ProjectManagerIsActive = BC000E13_A177ProjectManagerIsActive[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E14 */
            pr_default.execute(12, new Object[] {A102ProjectId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0E15( )
      {
         /* Scan By routine */
         /* Using cursor BC000E15 */
         pr_default.execute(13, new Object[] {A102ProjectId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound15 = 1;
            A103ProjectName = BC000E15_A103ProjectName[0];
            A104ProjectDescription = BC000E15_A104ProjectDescription[0];
            A105ProjectStatus = BC000E15_A105ProjectStatus[0];
            A167ProjectManagerName = BC000E15_A167ProjectManagerName[0];
            A176ProjectManagerEmail = BC000E15_A176ProjectManagerEmail[0];
            A177ProjectManagerIsActive = BC000E15_A177ProjectManagerIsActive[0];
            A166ProjectManagerId = BC000E15_A166ProjectManagerId[0];
            n166ProjectManagerId = BC000E15_n166ProjectManagerId[0];
            A102ProjectId = BC000E15_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound15 = 0;
         ScanKeyLoad0E15( ) ;
      }

      protected void ScanKeyLoad0E15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound15 = 1;
            A103ProjectName = BC000E15_A103ProjectName[0];
            A104ProjectDescription = BC000E15_A104ProjectDescription[0];
            A105ProjectStatus = BC000E15_A105ProjectStatus[0];
            A167ProjectManagerName = BC000E15_A167ProjectManagerName[0];
            A176ProjectManagerEmail = BC000E15_A176ProjectManagerEmail[0];
            A177ProjectManagerIsActive = BC000E15_A177ProjectManagerIsActive[0];
            A166ProjectManagerId = BC000E15_A166ProjectManagerId[0];
            n166ProjectManagerId = BC000E15_n166ProjectManagerId[0];
            A102ProjectId = BC000E15_A102ProjectId[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0E15( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
         A166ProjectManagerId = 0;
         n166ProjectManagerId = false;
         n166ProjectManagerId = true;
         new assignprojectmanagerrole(context ).execute(  A166ProjectManagerId,  A102ProjectId) ;
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
         new assignprojectmanagerrole(context ).execute(  A166ProjectManagerId,  A102ProjectId) ;
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void AddRow0E15( )
      {
         VarsToRow15( bcProject) ;
      }

      protected void ReadRow0E15( )
      {
         RowToVars15( bcProject, 1) ;
      }

      protected void InitializeNonKey0E15( )
      {
         A106EmployeeId = 0;
         A103ProjectName = "";
         A104ProjectDescription = "";
         A166ProjectManagerId = 0;
         n166ProjectManagerId = false;
         A167ProjectManagerName = "";
         A176ProjectManagerEmail = "";
         A177ProjectManagerIsActive = false;
         A105ProjectStatus = "Active";
         Z103ProjectName = "";
         Z104ProjectDescription = "";
         Z105ProjectStatus = "";
         Z166ProjectManagerId = 0;
      }

      protected void InitAll0E15( )
      {
         A102ProjectId = 0;
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A105ProjectStatus = i105ProjectStatus;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow15( SdtProject obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Projectname = A103ProjectName;
         obj15.gxTpr_Projectdescription = A104ProjectDescription;
         obj15.gxTpr_Projectmanagerid = A166ProjectManagerId;
         obj15.gxTpr_Projectmanagername = A167ProjectManagerName;
         obj15.gxTpr_Projectmanageremail = A176ProjectManagerEmail;
         obj15.gxTpr_Projectmanagerisactive = A177ProjectManagerIsActive;
         obj15.gxTpr_Projectstatus = A105ProjectStatus;
         obj15.gxTpr_Projectid = A102ProjectId;
         obj15.gxTpr_Projectid_Z = Z102ProjectId;
         obj15.gxTpr_Projectname_Z = Z103ProjectName;
         obj15.gxTpr_Projectdescription_Z = Z104ProjectDescription;
         obj15.gxTpr_Projectstatus_Z = Z105ProjectStatus;
         obj15.gxTpr_Projectmanagerid_Z = Z166ProjectManagerId;
         obj15.gxTpr_Projectmanagername_Z = Z167ProjectManagerName;
         obj15.gxTpr_Projectmanageremail_Z = Z176ProjectManagerEmail;
         obj15.gxTpr_Projectmanagerisactive_Z = Z177ProjectManagerIsActive;
         obj15.gxTpr_Projectmanagerid_N = (short)(Convert.ToInt16(n166ProjectManagerId));
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtProject obj15 )
      {
         obj15.gxTpr_Projectid = A102ProjectId;
         return  ;
      }

      public void RowToVars15( SdtProject obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A103ProjectName = obj15.gxTpr_Projectname;
         A104ProjectDescription = obj15.gxTpr_Projectdescription;
         A166ProjectManagerId = obj15.gxTpr_Projectmanagerid;
         n166ProjectManagerId = false;
         A167ProjectManagerName = obj15.gxTpr_Projectmanagername;
         A176ProjectManagerEmail = obj15.gxTpr_Projectmanageremail;
         A177ProjectManagerIsActive = obj15.gxTpr_Projectmanagerisactive;
         A105ProjectStatus = obj15.gxTpr_Projectstatus;
         A102ProjectId = obj15.gxTpr_Projectid;
         Z102ProjectId = obj15.gxTpr_Projectid_Z;
         Z103ProjectName = obj15.gxTpr_Projectname_Z;
         Z104ProjectDescription = obj15.gxTpr_Projectdescription_Z;
         Z105ProjectStatus = obj15.gxTpr_Projectstatus_Z;
         Z166ProjectManagerId = obj15.gxTpr_Projectmanagerid_Z;
         Z167ProjectManagerName = obj15.gxTpr_Projectmanagername_Z;
         Z176ProjectManagerEmail = obj15.gxTpr_Projectmanageremail_Z;
         Z177ProjectManagerIsActive = obj15.gxTpr_Projectmanagerisactive_Z;
         n166ProjectManagerId = (bool)(Convert.ToBoolean(obj15.gxTpr_Projectmanagerid_N));
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A102ProjectId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E15( ) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102ProjectId = A102ProjectId;
         }
         ZM0E15( -9) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars15( bcProject, 0) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102ProjectId = A102ProjectId;
         }
         ZM0E15( -9) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A102ProjectId != Z102ProjectId )
               {
                  A102ProjectId = Z102ProjectId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0E15( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A102ProjectId != Z102ProjectId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0E15( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0E15( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars15( bcProject, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcProject) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars15( bcProject, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcProject) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcProject) ;
         }
         else
         {
            SdtProject auxBC = new SdtProject(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A102ProjectId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProject);
               auxBC.Save();
               bcProject.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars15( bcProject, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars15( bcProject, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow15( bcProject) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcProject) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcProject, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0E15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A102ProjectId != Z102ProjectId )
            {
               A102ProjectId = Z102ProjectId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A102ProjectId != Z102ProjectId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("project_bc",pr_default);
         VarsToRow15( bcProject) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcProject.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProject.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProject )
         {
            bcProject = (SdtProject)(sdt);
            if ( StringUtil.StrCmp(bcProject.gxTpr_Mode, "") == 0 )
            {
               bcProject.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcProject) ;
            }
            else
            {
               RowToVars15( bcProject, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProject.gxTpr_Mode, "") == 0 )
            {
               bcProject.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcProject, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProject Project_BC
      {
         get {
            return bcProject ;
         }

      }

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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "project_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV32Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z103ProjectName = "";
         A103ProjectName = "";
         Z104ProjectDescription = "";
         A104ProjectDescription = "";
         Z105ProjectStatus = "";
         A105ProjectStatus = "";
         Z167ProjectManagerName = "";
         A167ProjectManagerName = "";
         Z176ProjectManagerEmail = "";
         A176ProjectManagerEmail = "";
         BC000E6_A103ProjectName = new string[] {""} ;
         BC000E6_A104ProjectDescription = new string[] {""} ;
         BC000E6_A105ProjectStatus = new string[] {""} ;
         BC000E6_A167ProjectManagerName = new string[] {""} ;
         BC000E6_A176ProjectManagerEmail = new string[] {""} ;
         BC000E6_A177ProjectManagerIsActive = new bool[] {false} ;
         BC000E6_A166ProjectManagerId = new long[1] ;
         BC000E6_n166ProjectManagerId = new bool[] {false} ;
         BC000E6_A102ProjectId = new long[1] ;
         BC000E5_A106EmployeeId = new long[1] ;
         BC000E7_A103ProjectName = new string[] {""} ;
         BC000E4_A167ProjectManagerName = new string[] {""} ;
         BC000E4_A176ProjectManagerEmail = new string[] {""} ;
         BC000E4_A177ProjectManagerIsActive = new bool[] {false} ;
         BC000E8_A102ProjectId = new long[1] ;
         BC000E3_A103ProjectName = new string[] {""} ;
         BC000E3_A104ProjectDescription = new string[] {""} ;
         BC000E3_A105ProjectStatus = new string[] {""} ;
         BC000E3_A166ProjectManagerId = new long[1] ;
         BC000E3_n166ProjectManagerId = new bool[] {false} ;
         BC000E3_A102ProjectId = new long[1] ;
         sMode15 = "";
         BC000E2_A103ProjectName = new string[] {""} ;
         BC000E2_A104ProjectDescription = new string[] {""} ;
         BC000E2_A105ProjectStatus = new string[] {""} ;
         BC000E2_A166ProjectManagerId = new long[1] ;
         BC000E2_n166ProjectManagerId = new bool[] {false} ;
         BC000E2_A102ProjectId = new long[1] ;
         BC000E10_A102ProjectId = new long[1] ;
         BC000E13_A167ProjectManagerName = new string[] {""} ;
         BC000E13_A176ProjectManagerEmail = new string[] {""} ;
         BC000E13_A177ProjectManagerIsActive = new bool[] {false} ;
         BC000E14_A106EmployeeId = new long[1] ;
         BC000E14_A102ProjectId = new long[1] ;
         BC000E15_A103ProjectName = new string[] {""} ;
         BC000E15_A104ProjectDescription = new string[] {""} ;
         BC000E15_A105ProjectStatus = new string[] {""} ;
         BC000E15_A167ProjectManagerName = new string[] {""} ;
         BC000E15_A176ProjectManagerEmail = new string[] {""} ;
         BC000E15_A177ProjectManagerIsActive = new bool[] {false} ;
         BC000E15_A166ProjectManagerId = new long[1] ;
         BC000E15_n166ProjectManagerId = new bool[] {false} ;
         BC000E15_A102ProjectId = new long[1] ;
         i105ProjectStatus = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.project_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.project_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A103ProjectName, BC000E2_A104ProjectDescription, BC000E2_A105ProjectStatus, BC000E2_A166ProjectManagerId, BC000E2_n166ProjectManagerId, BC000E2_A102ProjectId
               }
               , new Object[] {
               BC000E3_A103ProjectName, BC000E3_A104ProjectDescription, BC000E3_A105ProjectStatus, BC000E3_A166ProjectManagerId, BC000E3_n166ProjectManagerId, BC000E3_A102ProjectId
               }
               , new Object[] {
               BC000E4_A167ProjectManagerName, BC000E4_A176ProjectManagerEmail, BC000E4_A177ProjectManagerIsActive
               }
               , new Object[] {
               BC000E5_A106EmployeeId
               }
               , new Object[] {
               BC000E6_A103ProjectName, BC000E6_A104ProjectDescription, BC000E6_A105ProjectStatus, BC000E6_A167ProjectManagerName, BC000E6_A176ProjectManagerEmail, BC000E6_A177ProjectManagerIsActive, BC000E6_A166ProjectManagerId, BC000E6_n166ProjectManagerId, BC000E6_A102ProjectId
               }
               , new Object[] {
               BC000E7_A103ProjectName
               }
               , new Object[] {
               BC000E8_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E10_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E13_A167ProjectManagerName, BC000E13_A176ProjectManagerEmail, BC000E13_A177ProjectManagerIsActive
               }
               , new Object[] {
               BC000E14_A106EmployeeId, BC000E14_A102ProjectId
               }
               , new Object[] {
               BC000E15_A103ProjectName, BC000E15_A104ProjectDescription, BC000E15_A105ProjectStatus, BC000E15_A167ProjectManagerName, BC000E15_A176ProjectManagerEmail, BC000E15_A177ProjectManagerIsActive, BC000E15_A166ProjectManagerId, BC000E15_n166ProjectManagerId, BC000E15_A102ProjectId
               }
            }
         );
         AV32Pgmname = "Project_BC";
         Z105ProjectStatus = "Active";
         A105ProjectStatus = "Active";
         i105ProjectStatus = "Active";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private int trnEnded ;
      private int AV33GXV1 ;
      private long Z102ProjectId ;
      private long A102ProjectId ;
      private long AV20Insert_ProjectManagerId ;
      private long AV22ComboProjectManagerId ;
      private long Z166ProjectManagerId ;
      private long A166ProjectManagerId ;
      private long A106EmployeeId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV32Pgmname ;
      private string Z103ProjectName ;
      private string A103ProjectName ;
      private string Z105ProjectStatus ;
      private string A105ProjectStatus ;
      private string Z167ProjectManagerName ;
      private string A167ProjectManagerName ;
      private string sMode15 ;
      private string i105ProjectStatus ;
      private bool returnInSub ;
      private bool Z177ProjectManagerIsActive ;
      private bool A177ProjectManagerIsActive ;
      private bool n166ProjectManagerId ;
      private bool mustCommit ;
      private string Z104ProjectDescription ;
      private string A104ProjectDescription ;
      private string Z176ProjectManagerEmail ;
      private string A176ProjectManagerEmail ;
      private IGxSession AV12WebSession ;
      private SdtProject bcProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000E6_A103ProjectName ;
      private string[] BC000E6_A104ProjectDescription ;
      private string[] BC000E6_A105ProjectStatus ;
      private string[] BC000E6_A167ProjectManagerName ;
      private string[] BC000E6_A176ProjectManagerEmail ;
      private bool[] BC000E6_A177ProjectManagerIsActive ;
      private long[] BC000E6_A166ProjectManagerId ;
      private bool[] BC000E6_n166ProjectManagerId ;
      private long[] BC000E6_A102ProjectId ;
      private long[] BC000E5_A106EmployeeId ;
      private string[] BC000E7_A103ProjectName ;
      private string[] BC000E4_A167ProjectManagerName ;
      private string[] BC000E4_A176ProjectManagerEmail ;
      private bool[] BC000E4_A177ProjectManagerIsActive ;
      private long[] BC000E8_A102ProjectId ;
      private string[] BC000E3_A103ProjectName ;
      private string[] BC000E3_A104ProjectDescription ;
      private string[] BC000E3_A105ProjectStatus ;
      private long[] BC000E3_A166ProjectManagerId ;
      private bool[] BC000E3_n166ProjectManagerId ;
      private long[] BC000E3_A102ProjectId ;
      private string[] BC000E2_A103ProjectName ;
      private string[] BC000E2_A104ProjectDescription ;
      private string[] BC000E2_A105ProjectStatus ;
      private long[] BC000E2_A166ProjectManagerId ;
      private bool[] BC000E2_n166ProjectManagerId ;
      private long[] BC000E2_A102ProjectId ;
      private long[] BC000E10_A102ProjectId ;
      private string[] BC000E13_A167ProjectManagerName ;
      private string[] BC000E13_A176ProjectManagerEmail ;
      private bool[] BC000E13_A177ProjectManagerIsActive ;
      private long[] BC000E14_A106EmployeeId ;
      private long[] BC000E14_A102ProjectId ;
      private string[] BC000E15_A103ProjectName ;
      private string[] BC000E15_A104ProjectDescription ;
      private string[] BC000E15_A105ProjectStatus ;
      private string[] BC000E15_A167ProjectManagerName ;
      private string[] BC000E15_A176ProjectManagerEmail ;
      private bool[] BC000E15_A177ProjectManagerIsActive ;
      private long[] BC000E15_A166ProjectManagerId ;
      private bool[] BC000E15_n166ProjectManagerId ;
      private long[] BC000E15_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class project_bc__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class project_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000E6;
        prmBC000E6 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E5;
        prmBC000E5 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E7;
        prmBC000E7 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E4;
        prmBC000E4 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000E8;
        prmBC000E8 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E3;
        prmBC000E3 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E2;
        prmBC000E2 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E9;
        prmBC000E9 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectDescription",GXType.VarChar,200,0) ,
        new ParDef("ProjectStatus",GXType.Char,20,0) ,
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000E10;
        prmBC000E10 = new Object[] {
        };
        Object[] prmBC000E11;
        prmBC000E11 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectDescription",GXType.VarChar,200,0) ,
        new ParDef("ProjectStatus",GXType.Char,20,0) ,
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E12;
        prmBC000E12 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E13;
        prmBC000E13 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000E14;
        prmBC000E14 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000E15;
        prmBC000E15 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000E2", "SELECT ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId, ProjectId FROM Project WHERE ProjectId = :ProjectId  FOR UPDATE OF Project",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E3", "SELECT ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId, ProjectId FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E4", "SELECT EmployeeName AS ProjectManagerName, EmployeeEmail AS ProjectManagerEmail, EmployeeIsActive AS ProjectManagerIsActive FROM Employee WHERE EmployeeId = :ProjectManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E5", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E6", "SELECT TM1.ProjectName, TM1.ProjectDescription, TM1.ProjectStatus, T2.EmployeeName AS ProjectManagerName, T2.EmployeeEmail AS ProjectManagerEmail, T2.EmployeeIsActive AS ProjectManagerIsActive, TM1.ProjectManagerId AS ProjectManagerId, TM1.ProjectId FROM (Project TM1 LEFT JOIN Employee T2 ON T2.EmployeeId = TM1.ProjectManagerId) WHERE TM1.ProjectId = :ProjectId ORDER BY TM1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E7", "SELECT ProjectName FROM Project WHERE (ProjectName = :ProjectName) AND (Not ( ProjectId = :ProjectId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E8", "SELECT ProjectId FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E9", "SAVEPOINT gxupdate;INSERT INTO Project(ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId) VALUES(:ProjectName, :ProjectDescription, :ProjectStatus, :ProjectManagerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E9)
           ,new CursorDef("BC000E10", "SELECT currval('ProjectId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E11", "SAVEPOINT gxupdate;UPDATE Project SET ProjectName=:ProjectName, ProjectDescription=:ProjectDescription, ProjectStatus=:ProjectStatus, ProjectManagerId=:ProjectManagerId  WHERE ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E11)
           ,new CursorDef("BC000E12", "SAVEPOINT gxupdate;DELETE FROM Project  WHERE ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E12)
           ,new CursorDef("BC000E13", "SELECT EmployeeName AS ProjectManagerName, EmployeeEmail AS ProjectManagerEmail, EmployeeIsActive AS ProjectManagerIsActive FROM Employee WHERE EmployeeId = :ProjectManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E14", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E15", "SELECT TM1.ProjectName, TM1.ProjectDescription, TM1.ProjectStatus, T2.EmployeeName AS ProjectManagerName, T2.EmployeeEmail AS ProjectManagerEmail, T2.EmployeeIsActive AS ProjectManagerIsActive, TM1.ProjectManagerId AS ProjectManagerId, TM1.ProjectId FROM (Project TM1 LEFT JOIN Employee T2 ON T2.EmployeeId = TM1.ProjectManagerId) WHERE TM1.ProjectId = :ProjectId ORDER BY TM1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
     }
  }

}

}
