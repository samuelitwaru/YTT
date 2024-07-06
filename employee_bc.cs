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
   public class employee_bc : GxSilentTrn, IGxSilentTrn
   {
      public employee_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employee_bc( IGxContext context )
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
         ReadRow0F16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F16( ) ;
         standaloneModal( ) ;
         AddRow0F16( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z106EmployeeId = A106EmployeeId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F16( 23) ;
               }
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0F28( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode16;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
         }
      }

      protected void CONFIRM_0F28( )
      {
         nGXsfl_28_idx = 0;
         while ( nGXsfl_28_idx < bcEmployee.gxTpr_Project.Count )
         {
            ReadRow0F28( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound28 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_28 != 0 ) )
            {
               GetKey0F28( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound28 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0F28( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0F28( 25) ;
                        }
                        CloseExtendedTableCursors0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound28 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0F28( ) ;
                        Load0F28( ) ;
                        BeforeValidate0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F28( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_28 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0F28( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F28( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0F28( 25) ;
                              }
                              CloseExtendedTableCursors0F28( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow28( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_28_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120F2( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z100CompanyId = A100CompanyId;
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z101CompanyName = A101CompanyName;
         }
         if ( GX_JID == -21 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV32Pgmname = "Employee_BC";
         Gx_date = DateTimeUtil.Today( context);
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         GXt_boolean1 = false;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean1) ;
         if ( GXt_boolean1 )
         {
            GXt_int2 = A100CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int2) ;
            A100CompanyId = GXt_int2;
         }
         if ( IsIns( )  && (false==A112EmployeeIsActive) && ( Gx_BScreen == 0 ) )
         {
            A112EmployeeIsActive = false;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A146EmployeeVactionDays) && ( Gx_BScreen == 0 ) )
         {
            A146EmployeeVactionDays = (decimal)(21);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000F7 */
            pr_default.execute(5, new Object[] {A100CompanyId});
            A101CompanyName = BC000F7_A101CompanyName[0];
            pr_default.close(5);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor BC000F8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound16 = 1;
            A148EmployeeName = BC000F8_A148EmployeeName[0];
            A111GAMUserGUID = BC000F8_A111GAMUserGUID[0];
            A147EmployeeBalance = BC000F8_A147EmployeeBalance[0];
            A107EmployeeFirstName = BC000F8_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F8_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F8_A109EmployeeEmail[0];
            A101CompanyName = BC000F8_A101CompanyName[0];
            A110EmployeeIsManager = BC000F8_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F8_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F8_A146EmployeeVactionDays[0];
            A100CompanyId = BC000F8_A100CompanyId[0];
            ZM0F16( -21) ;
         }
         pr_default.close(6);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
         if ( IsIns( )  && (Convert.ToDecimal(0)==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            A147EmployeeBalance = A146EmployeeVactionDays;
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               A147EmployeeBalance = A146EmployeeVactionDays;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  GXt_decimal3 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_decimal3) ;
                  A147EmployeeBalance = (decimal)(A146EmployeeVactionDays-GXt_decimal3);
               }
            }
         }
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000F9 */
         pr_default.execute(7, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         nIsDirty_16 = 1;
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee First Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108EmployeeLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Last Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+A109EmployeeEmail_Internalname,  "true",  ""), 0, "");
         }
         /* Using cursor BC000F7 */
         pr_default.execute(5, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
         }
         A101CompanyName = BC000F7_A101CompanyName[0];
         pr_default.close(5);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_16 = 1;
            A147EmployeeBalance = A146EmployeeVactionDays;
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               nIsDirty_16 = 1;
               A147EmployeeBalance = A146EmployeeVactionDays;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  nIsDirty_16 = 1;
                  GXt_decimal3 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_decimal3) ;
                  A147EmployeeBalance = (decimal)(A146EmployeeVactionDays-GXt_decimal3);
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor BC000F10 */
         pr_default.execute(8, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0F16( 21) ;
            RcdFound16 = 1;
            A106EmployeeId = BC000F6_A106EmployeeId[0];
            A148EmployeeName = BC000F6_A148EmployeeName[0];
            A111GAMUserGUID = BC000F6_A111GAMUserGUID[0];
            A147EmployeeBalance = BC000F6_A147EmployeeBalance[0];
            A107EmployeeFirstName = BC000F6_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F6_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F6_A109EmployeeEmail[0];
            A110EmployeeIsManager = BC000F6_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F6_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F6_A146EmployeeVactionDays[0];
            A100CompanyId = BC000F6_A100CompanyId[0];
            Z106EmployeeId = A106EmployeeId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_0F0( ) ;
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

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F5 */
            pr_default.execute(3, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z148EmployeeName, BC000F5_A148EmployeeName[0]) != 0 ) || ( StringUtil.StrCmp(Z111GAMUserGUID, BC000F5_A111GAMUserGUID[0]) != 0 ) || ( Z147EmployeeBalance != BC000F5_A147EmployeeBalance[0] ) || ( StringUtil.StrCmp(Z107EmployeeFirstName, BC000F5_A107EmployeeFirstName[0]) != 0 ) || ( StringUtil.StrCmp(Z108EmployeeLastName, BC000F5_A108EmployeeLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z109EmployeeEmail, BC000F5_A109EmployeeEmail[0]) != 0 ) || ( Z110EmployeeIsManager != BC000F5_A110EmployeeIsManager[0] ) || ( Z112EmployeeIsActive != BC000F5_A112EmployeeIsActive[0] ) || ( Z146EmployeeVactionDays != BC000F5_A146EmployeeVactionDays[0] ) || ( Z100CompanyId != BC000F5_A100CompanyId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F11 */
                     pr_default.execute(9, new Object[] {A148EmployeeName, A111GAMUserGUID, A147EmployeeBalance, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A100CompanyId});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000F12 */
                     pr_default.execute(10);
                     A106EmployeeId = BC000F12_A106EmployeeId[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F13 */
                     pr_default.execute(11, new Object[] {A148EmployeeName, A111GAMUserGUID, A147EmployeeBalance, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A100CompanyId, A106EmployeeId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        new employeestatuscheck(context ).execute(  A106EmployeeId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0F28( ) ;
                  while ( RcdFound28 != 0 )
                  {
                     getByPrimaryKey0F28( ) ;
                     Delete0F28( ) ;
                     ScanKeyNext0F28( ) ;
                  }
                  ScanKeyEnd0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F14 */
                     pr_default.execute(12, new Object[] {A106EmployeeId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
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
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F15 */
            pr_default.execute(13, new Object[] {A100CompanyId});
            A101CompanyName = BC000F15_A101CompanyName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F16 */
            pr_default.execute(14, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000F17 */
            pr_default.execute(15, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Support Request"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000F18 */
            pr_default.execute(16, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000F19 */
            pr_default.execute(17, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WorkHourLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0F28( )
      {
         nGXsfl_28_idx = 0;
         while ( nGXsfl_28_idx < bcEmployee.gxTpr_Project.Count )
         {
            ReadRow0F28( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound28 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_28 != 0 ) )
            {
               standaloneNotModal0F28( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0F28( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0F28( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0F28( ) ;
                  }
               }
            }
            KeyVarsToRow28( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_28_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_28_idx = 0;
            while ( nGXsfl_28_idx < bcEmployee.gxTpr_Project.Count )
            {
               ReadRow0F28( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound28 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcEmployee.gxTpr_Project.RemoveElement(nGXsfl_28_idx);
                  nGXsfl_28_idx = (int)(nGXsfl_28_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0F28( ) ;
                  VarsToRow28( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_28_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F28( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_28 = 0;
         nIsMod_28 = 0;
         Gxremove28 = 0;
      }

      protected void ProcessLevel0F16( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0F28( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         /* ' Update level parameters */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
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

      public void ScanKeyStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor BC000F20 */
         pr_default.execute(18, new Object[] {A106EmployeeId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = BC000F20_A106EmployeeId[0];
            A148EmployeeName = BC000F20_A148EmployeeName[0];
            A111GAMUserGUID = BC000F20_A111GAMUserGUID[0];
            A147EmployeeBalance = BC000F20_A147EmployeeBalance[0];
            A107EmployeeFirstName = BC000F20_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F20_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F20_A109EmployeeEmail[0];
            A101CompanyName = BC000F20_A101CompanyName[0];
            A110EmployeeIsManager = BC000F20_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F20_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F20_A146EmployeeVactionDays[0];
            A100CompanyId = BC000F20_A100CompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound16 = 0;
         ScanKeyLoad0F16( ) ;
      }

      protected void ScanKeyLoad0F16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = BC000F20_A106EmployeeId[0];
            A148EmployeeName = BC000F20_A148EmployeeName[0];
            A111GAMUserGUID = BC000F20_A111GAMUserGUID[0];
            A147EmployeeBalance = BC000F20_A147EmployeeBalance[0];
            A107EmployeeFirstName = BC000F20_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F20_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F20_A109EmployeeEmail[0];
            A101CompanyName = BC000F20_A101CompanyName[0];
            A110EmployeeIsManager = BC000F20_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F20_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F20_A146EmployeeVactionDays[0];
            A100CompanyId = BC000F20_A100CompanyId[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0F16( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
      }

      protected void ZM0F28( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            Z103ProjectName = A103ProjectName;
         }
         if ( GX_JID == -24 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal0F28( )
      {
      }

      protected void standaloneModal0F28( )
      {
      }

      protected void Load0F28( )
      {
         /* Using cursor BC000F21 */
         pr_default.execute(19, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound28 = 1;
            A103ProjectName = BC000F21_A103ProjectName[0];
            ZM0F28( -24) ;
         }
         pr_default.close(19);
         OnLoadActions0F28( ) ;
      }

      protected void OnLoadActions0F28( )
      {
      }

      protected void CheckExtendedTable0F28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         standaloneModal0F28( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
         }
         A103ProjectName = BC000F4_A103ProjectName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0F28( )
      {
      }

      protected void GetKey0F28( )
      {
         /* Using cursor BC000F22 */
         pr_default.execute(20, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0F28( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F28( 24) ;
            RcdFound28 = 1;
            InitializeNonKey0F28( ) ;
            A102ProjectId = BC000F3_A102ProjectId[0];
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F28( ) ;
            Load0F28( ) ;
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0F28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F28( ) ;
            Gx_mode = sMode28;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F28( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeProject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F28( )
      {
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F28( 0) ;
            CheckOptimisticConcurrency0F28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F23 */
                     pr_default.execute(21, new Object[] {A106EmployeeId, A102ProjectId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                     if ( (pr_default.getStatus(21) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0F28( ) ;
            }
            EndLevel0F28( ) ;
         }
         CloseExtendedTableCursors0F28( ) ;
      }

      protected void Update0F28( )
      {
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table EmployeeProject */
                     DeferredUpdate0F28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0F28( ) ;
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
            EndLevel0F28( ) ;
         }
         CloseExtendedTableCursors0F28( ) ;
      }

      protected void DeferredUpdate0F28( )
      {
      }

      protected void Delete0F28( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F28( ) ;
            AfterConfirm0F28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F24 */
                  pr_default.execute(22, new Object[] {A106EmployeeId, A102ProjectId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0F28( )
      {
         standaloneModal0F28( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F25 */
            pr_default.execute(23, new Object[] {A102ProjectId});
            A103ProjectName = BC000F25_A103ProjectName[0];
            pr_default.close(23);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F26 */
            pr_default.execute(24, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC000F27 */
            pr_default.execute(25, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WorkHourLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel0F28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0F28( )
      {
         /* Scan By routine */
         /* Using cursor BC000F28 */
         pr_default.execute(26, new Object[] {A106EmployeeId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound28 = 1;
            A103ProjectName = BC000F28_A103ProjectName[0];
            A102ProjectId = BC000F28_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F28( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound28 = 0;
         ScanKeyLoad0F28( ) ;
      }

      protected void ScanKeyLoad0F28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound28 = 1;
            A103ProjectName = BC000F28_A103ProjectName[0];
            A102ProjectId = BC000F28_A102ProjectId[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0F28( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0F28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F28( )
      {
      }

      protected void send_integrity_lvl_hashes0F28( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void AddRow0F16( )
      {
         VarsToRow16( bcEmployee) ;
      }

      protected void ReadRow0F16( )
      {
         RowToVars16( bcEmployee, 1) ;
      }

      protected void AddRow0F28( )
      {
         SdtEmployee_Project obj28;
         obj28 = new SdtEmployee_Project(context);
         VarsToRow28( obj28) ;
         bcEmployee.gxTpr_Project.Add(obj28, 0);
         obj28.gxTpr_Mode = "UPD";
         obj28.gxTpr_Modified = 0;
      }

      protected void ReadRow0F28( )
      {
         nGXsfl_28_idx = (int)(nGXsfl_28_idx+1);
         RowToVars28( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_28_idx)), 1) ;
      }

      protected void InitializeNonKey0F16( )
      {
         A148EmployeeName = "";
         A100CompanyId = 0;
         A111GAMUserGUID = "";
         AV24Password = "";
         A147EmployeeBalance = 0;
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A110EmployeeIsManager = false;
         A112EmployeeIsActive = false;
         A146EmployeeVactionDays = (decimal)(21);
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z147EmployeeBalance = 0;
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         Z110EmployeeIsManager = false;
         Z112EmployeeIsActive = false;
         Z146EmployeeVactionDays = 0;
         Z100CompanyId = 0;
      }

      protected void InitAll0F16( )
      {
         A106EmployeeId = 0;
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A100CompanyId = i100CompanyId;
         A112EmployeeIsActive = i112EmployeeIsActive;
         A146EmployeeVactionDays = i146EmployeeVactionDays;
      }

      protected void InitializeNonKey0F28( )
      {
         A103ProjectName = "";
      }

      protected void InitAll0F28( )
      {
         A102ProjectId = 0;
         InitializeNonKey0F28( ) ;
      }

      protected void StandaloneModalInsert0F28( )
      {
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

      public void VarsToRow16( SdtEmployee obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Employeename = A148EmployeeName;
         obj16.gxTpr_Companyid = A100CompanyId;
         obj16.gxTpr_Gamuserguid = A111GAMUserGUID;
         obj16.gxTpr_Employeebalance = A147EmployeeBalance;
         obj16.gxTpr_Employeefirstname = A107EmployeeFirstName;
         obj16.gxTpr_Employeelastname = A108EmployeeLastName;
         obj16.gxTpr_Employeeemail = A109EmployeeEmail;
         obj16.gxTpr_Companyname = A101CompanyName;
         obj16.gxTpr_Employeeismanager = A110EmployeeIsManager;
         obj16.gxTpr_Employeeisactive = A112EmployeeIsActive;
         obj16.gxTpr_Employeevactiondays = A146EmployeeVactionDays;
         obj16.gxTpr_Employeeid = A106EmployeeId;
         obj16.gxTpr_Employeeid_Z = Z106EmployeeId;
         obj16.gxTpr_Employeefirstname_Z = Z107EmployeeFirstName;
         obj16.gxTpr_Employeelastname_Z = Z108EmployeeLastName;
         obj16.gxTpr_Employeename_Z = Z148EmployeeName;
         obj16.gxTpr_Employeeemail_Z = Z109EmployeeEmail;
         obj16.gxTpr_Companyid_Z = Z100CompanyId;
         obj16.gxTpr_Companyname_Z = Z101CompanyName;
         obj16.gxTpr_Employeeismanager_Z = Z110EmployeeIsManager;
         obj16.gxTpr_Gamuserguid_Z = Z111GAMUserGUID;
         obj16.gxTpr_Employeeisactive_Z = Z112EmployeeIsActive;
         obj16.gxTpr_Employeevactiondays_Z = Z146EmployeeVactionDays;
         obj16.gxTpr_Employeebalance_Z = Z147EmployeeBalance;
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtEmployee obj16 )
      {
         obj16.gxTpr_Employeeid = A106EmployeeId;
         return  ;
      }

      public void RowToVars16( SdtEmployee obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A148EmployeeName = obj16.gxTpr_Employeename;
         if ( ! ( new userhasrole(context).executeUdp(  "Manager") ) || ( forceLoad == 1 ) )
         {
            A100CompanyId = obj16.gxTpr_Companyid;
         }
         A111GAMUserGUID = obj16.gxTpr_Gamuserguid;
         A147EmployeeBalance = obj16.gxTpr_Employeebalance;
         A107EmployeeFirstName = obj16.gxTpr_Employeefirstname;
         A108EmployeeLastName = obj16.gxTpr_Employeelastname;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A109EmployeeEmail = obj16.gxTpr_Employeeemail;
         }
         A101CompanyName = obj16.gxTpr_Companyname;
         A110EmployeeIsManager = obj16.gxTpr_Employeeismanager;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A112EmployeeIsActive = obj16.gxTpr_Employeeisactive;
         }
         A146EmployeeVactionDays = obj16.gxTpr_Employeevactiondays;
         A106EmployeeId = obj16.gxTpr_Employeeid;
         Z106EmployeeId = obj16.gxTpr_Employeeid_Z;
         Z107EmployeeFirstName = obj16.gxTpr_Employeefirstname_Z;
         Z108EmployeeLastName = obj16.gxTpr_Employeelastname_Z;
         Z148EmployeeName = obj16.gxTpr_Employeename_Z;
         Z109EmployeeEmail = obj16.gxTpr_Employeeemail_Z;
         Z100CompanyId = obj16.gxTpr_Companyid_Z;
         Z101CompanyName = obj16.gxTpr_Companyname_Z;
         Z110EmployeeIsManager = obj16.gxTpr_Employeeismanager_Z;
         Z111GAMUserGUID = obj16.gxTpr_Gamuserguid_Z;
         Z112EmployeeIsActive = obj16.gxTpr_Employeeisactive_Z;
         Z146EmployeeVactionDays = obj16.gxTpr_Employeevactiondays_Z;
         Z147EmployeeBalance = obj16.gxTpr_Employeebalance_Z;
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow28( SdtEmployee_Project obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Projectname = A103ProjectName;
         obj28.gxTpr_Projectid = A102ProjectId;
         obj28.gxTpr_Projectid_Z = Z102ProjectId;
         obj28.gxTpr_Projectname_Z = Z103ProjectName;
         obj28.gxTpr_Modified = nIsMod_28;
         return  ;
      }

      public void KeyVarsToRow28( SdtEmployee_Project obj28 )
      {
         obj28.gxTpr_Projectid = A102ProjectId;
         return  ;
      }

      public void RowToVars28( SdtEmployee_Project obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A103ProjectName = obj28.gxTpr_Projectname;
         A102ProjectId = obj28.gxTpr_Projectid;
         Z102ProjectId = obj28.gxTpr_Projectid_Z;
         Z103ProjectName = obj28.gxTpr_Projectname_Z;
         nIsMod_28 = obj28.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A106EmployeeId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F16( ) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106EmployeeId = A106EmployeeId;
         }
         ZM0F16( -21) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         bcEmployee.gxTpr_Project.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F28( ) ;
            nGXsfl_28_idx = 1;
            while ( RcdFound28 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z102ProjectId = A102ProjectId;
               ZM0F28( -24) ;
               OnLoadActions0F28( ) ;
               nRcdExists_28 = 1;
               nIsMod_28 = 0;
               AddRow0F28( ) ;
               nGXsfl_28_idx = (int)(nGXsfl_28_idx+1);
               ScanKeyNext0F28( ) ;
            }
            ScanKeyEnd0F28( ) ;
         }
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcEmployee, 0) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106EmployeeId = A106EmployeeId;
         }
         ZM0F16( -21) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         bcEmployee.gxTpr_Project.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F28( ) ;
            nGXsfl_28_idx = 1;
            while ( RcdFound28 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z102ProjectId = A102ProjectId;
               ZM0F28( -24) ;
               OnLoadActions0F28( ) ;
               nRcdExists_28 = 1;
               nIsMod_28 = 0;
               AddRow0F28( ) ;
               nGXsfl_28_idx = (int)(nGXsfl_28_idx+1);
               ScanKeyNext0F28( ) ;
            }
            ScanKeyEnd0F28( ) ;
         }
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  A106EmployeeId = Z106EmployeeId;
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
                  Update0F16( ) ;
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
                  if ( A106EmployeeId != Z106EmployeeId )
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
                        Insert0F16( ) ;
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
                        Insert0F16( ) ;
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
         RowToVars16( bcEmployee, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcEmployee) ;
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
         RowToVars16( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcEmployee) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcEmployee) ;
         }
         else
         {
            SdtEmployee auxBC = new SdtEmployee(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A106EmployeeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmployee);
               auxBC.Save();
               bcEmployee.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars16( bcEmployee, 1) ;
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
         RowToVars16( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
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
               VarsToRow16( bcEmployee) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcEmployee) ;
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
         RowToVars16( bcEmployee, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0F16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A106EmployeeId != Z106EmployeeId )
            {
               A106EmployeeId = Z106EmployeeId;
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
            if ( A106EmployeeId != Z106EmployeeId )
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
         context.RollbackDataStores("employee_bc",pr_default);
         VarsToRow16( bcEmployee) ;
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
         Gx_mode = bcEmployee.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmployee.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmployee )
         {
            bcEmployee = (SdtEmployee)(sdt);
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcEmployee) ;
            }
            else
            {
               RowToVars16( bcEmployee, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcEmployee, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEmployee Employee_BC
      {
         get {
            return bcEmployee ;
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
            return "employee_Execute" ;
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
         pr_default.close(23);
         pr_default.close(4);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode16 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV32Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z148EmployeeName = "";
         A148EmployeeName = "";
         Z111GAMUserGUID = "";
         A111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         A107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         A108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         A109EmployeeEmail = "";
         Z101CompanyName = "";
         A101CompanyName = "";
         Gx_date = DateTime.MinValue;
         BC000F7_A101CompanyName = new string[] {""} ;
         BC000F8_A106EmployeeId = new long[1] ;
         BC000F8_A148EmployeeName = new string[] {""} ;
         BC000F8_A111GAMUserGUID = new string[] {""} ;
         BC000F8_A147EmployeeBalance = new decimal[1] ;
         BC000F8_A107EmployeeFirstName = new string[] {""} ;
         BC000F8_A108EmployeeLastName = new string[] {""} ;
         BC000F8_A109EmployeeEmail = new string[] {""} ;
         BC000F8_A101CompanyName = new string[] {""} ;
         BC000F8_A110EmployeeIsManager = new bool[] {false} ;
         BC000F8_A112EmployeeIsActive = new bool[] {false} ;
         BC000F8_A146EmployeeVactionDays = new decimal[1] ;
         BC000F8_A100CompanyId = new long[1] ;
         BC000F9_A109EmployeeEmail = new string[] {""} ;
         A109EmployeeEmail_Internalname = "";
         BC000F10_A106EmployeeId = new long[1] ;
         BC000F6_A106EmployeeId = new long[1] ;
         BC000F6_A148EmployeeName = new string[] {""} ;
         BC000F6_A111GAMUserGUID = new string[] {""} ;
         BC000F6_A147EmployeeBalance = new decimal[1] ;
         BC000F6_A107EmployeeFirstName = new string[] {""} ;
         BC000F6_A108EmployeeLastName = new string[] {""} ;
         BC000F6_A109EmployeeEmail = new string[] {""} ;
         BC000F6_A110EmployeeIsManager = new bool[] {false} ;
         BC000F6_A112EmployeeIsActive = new bool[] {false} ;
         BC000F6_A146EmployeeVactionDays = new decimal[1] ;
         BC000F6_A100CompanyId = new long[1] ;
         BC000F5_A106EmployeeId = new long[1] ;
         BC000F5_A148EmployeeName = new string[] {""} ;
         BC000F5_A111GAMUserGUID = new string[] {""} ;
         BC000F5_A147EmployeeBalance = new decimal[1] ;
         BC000F5_A107EmployeeFirstName = new string[] {""} ;
         BC000F5_A108EmployeeLastName = new string[] {""} ;
         BC000F5_A109EmployeeEmail = new string[] {""} ;
         BC000F5_A110EmployeeIsManager = new bool[] {false} ;
         BC000F5_A112EmployeeIsActive = new bool[] {false} ;
         BC000F5_A146EmployeeVactionDays = new decimal[1] ;
         BC000F5_A100CompanyId = new long[1] ;
         BC000F12_A106EmployeeId = new long[1] ;
         BC000F15_A101CompanyName = new string[] {""} ;
         BC000F16_A102ProjectId = new long[1] ;
         BC000F17_A172SupportRequestId = new long[1] ;
         BC000F18_A127LeaveRequestId = new long[1] ;
         BC000F19_A118WorkHourLogId = new long[1] ;
         BC000F20_A106EmployeeId = new long[1] ;
         BC000F20_A148EmployeeName = new string[] {""} ;
         BC000F20_A111GAMUserGUID = new string[] {""} ;
         BC000F20_A147EmployeeBalance = new decimal[1] ;
         BC000F20_A107EmployeeFirstName = new string[] {""} ;
         BC000F20_A108EmployeeLastName = new string[] {""} ;
         BC000F20_A109EmployeeEmail = new string[] {""} ;
         BC000F20_A101CompanyName = new string[] {""} ;
         BC000F20_A110EmployeeIsManager = new bool[] {false} ;
         BC000F20_A112EmployeeIsActive = new bool[] {false} ;
         BC000F20_A146EmployeeVactionDays = new decimal[1] ;
         BC000F20_A100CompanyId = new long[1] ;
         AV24Password = "";
         Z103ProjectName = "";
         A103ProjectName = "";
         BC000F21_A106EmployeeId = new long[1] ;
         BC000F21_A103ProjectName = new string[] {""} ;
         BC000F21_A102ProjectId = new long[1] ;
         BC000F4_A103ProjectName = new string[] {""} ;
         BC000F22_A106EmployeeId = new long[1] ;
         BC000F22_A102ProjectId = new long[1] ;
         BC000F3_A106EmployeeId = new long[1] ;
         BC000F3_A102ProjectId = new long[1] ;
         sMode28 = "";
         BC000F2_A106EmployeeId = new long[1] ;
         BC000F2_A102ProjectId = new long[1] ;
         BC000F25_A103ProjectName = new string[] {""} ;
         BC000F26_A102ProjectId = new long[1] ;
         BC000F27_A118WorkHourLogId = new long[1] ;
         BC000F28_A106EmployeeId = new long[1] ;
         BC000F28_A103ProjectName = new string[] {""} ;
         BC000F28_A102ProjectId = new long[1] ;
         N109EmployeeEmail = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.employee_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A106EmployeeId, BC000F2_A102ProjectId
               }
               , new Object[] {
               BC000F3_A106EmployeeId, BC000F3_A102ProjectId
               }
               , new Object[] {
               BC000F4_A103ProjectName
               }
               , new Object[] {
               BC000F5_A106EmployeeId, BC000F5_A148EmployeeName, BC000F5_A111GAMUserGUID, BC000F5_A147EmployeeBalance, BC000F5_A107EmployeeFirstName, BC000F5_A108EmployeeLastName, BC000F5_A109EmployeeEmail, BC000F5_A110EmployeeIsManager, BC000F5_A112EmployeeIsActive, BC000F5_A146EmployeeVactionDays,
               BC000F5_A100CompanyId
               }
               , new Object[] {
               BC000F6_A106EmployeeId, BC000F6_A148EmployeeName, BC000F6_A111GAMUserGUID, BC000F6_A147EmployeeBalance, BC000F6_A107EmployeeFirstName, BC000F6_A108EmployeeLastName, BC000F6_A109EmployeeEmail, BC000F6_A110EmployeeIsManager, BC000F6_A112EmployeeIsActive, BC000F6_A146EmployeeVactionDays,
               BC000F6_A100CompanyId
               }
               , new Object[] {
               BC000F7_A101CompanyName
               }
               , new Object[] {
               BC000F8_A106EmployeeId, BC000F8_A148EmployeeName, BC000F8_A111GAMUserGUID, BC000F8_A147EmployeeBalance, BC000F8_A107EmployeeFirstName, BC000F8_A108EmployeeLastName, BC000F8_A109EmployeeEmail, BC000F8_A101CompanyName, BC000F8_A110EmployeeIsManager, BC000F8_A112EmployeeIsActive,
               BC000F8_A146EmployeeVactionDays, BC000F8_A100CompanyId
               }
               , new Object[] {
               BC000F9_A109EmployeeEmail
               }
               , new Object[] {
               BC000F10_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F12_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F15_A101CompanyName
               }
               , new Object[] {
               BC000F16_A102ProjectId
               }
               , new Object[] {
               BC000F17_A172SupportRequestId
               }
               , new Object[] {
               BC000F18_A127LeaveRequestId
               }
               , new Object[] {
               BC000F19_A118WorkHourLogId
               }
               , new Object[] {
               BC000F20_A106EmployeeId, BC000F20_A148EmployeeName, BC000F20_A111GAMUserGUID, BC000F20_A147EmployeeBalance, BC000F20_A107EmployeeFirstName, BC000F20_A108EmployeeLastName, BC000F20_A109EmployeeEmail, BC000F20_A101CompanyName, BC000F20_A110EmployeeIsManager, BC000F20_A112EmployeeIsActive,
               BC000F20_A146EmployeeVactionDays, BC000F20_A100CompanyId
               }
               , new Object[] {
               BC000F21_A106EmployeeId, BC000F21_A103ProjectName, BC000F21_A102ProjectId
               }
               , new Object[] {
               BC000F22_A106EmployeeId, BC000F22_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F25_A103ProjectName
               }
               , new Object[] {
               BC000F26_A102ProjectId
               }
               , new Object[] {
               BC000F27_A118WorkHourLogId
               }
               , new Object[] {
               BC000F28_A106EmployeeId, BC000F28_A103ProjectName, BC000F28_A102ProjectId
               }
            }
         );
         AV32Pgmname = "Employee_BC";
         Gx_date = DateTimeUtil.Today( context);
         Z146EmployeeVactionDays = (decimal)(21);
         A146EmployeeVactionDays = (decimal)(21);
         i146EmployeeVactionDays = (decimal)(21);
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         Z147EmployeeBalance = 0;
         A147EmployeeBalance = 0;
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_28 ;
      private short RcdFound28 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nIsDirty_16 ;
      private short nRcdExists_28 ;
      private short Gxremove28 ;
      private short nIsDirty_28 ;
      private int trnEnded ;
      private int nGXsfl_28_idx=1 ;
      private int AV33GXV1 ;
      private long Z106EmployeeId ;
      private long A106EmployeeId ;
      private long AV13Insert_CompanyId ;
      private long Z100CompanyId ;
      private long A100CompanyId ;
      private long GXt_int2 ;
      private long Z102ProjectId ;
      private long A102ProjectId ;
      private long i100CompanyId ;
      private decimal Z147EmployeeBalance ;
      private decimal A147EmployeeBalance ;
      private decimal Z146EmployeeVactionDays ;
      private decimal A146EmployeeVactionDays ;
      private decimal GXt_decimal3 ;
      private decimal i146EmployeeVactionDays ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private string AV32Pgmname ;
      private string Z148EmployeeName ;
      private string A148EmployeeName ;
      private string Z107EmployeeFirstName ;
      private string A107EmployeeFirstName ;
      private string Z108EmployeeLastName ;
      private string A108EmployeeLastName ;
      private string Z101CompanyName ;
      private string A101CompanyName ;
      private string A109EmployeeEmail_Internalname ;
      private string AV24Password ;
      private string Z103ProjectName ;
      private string A103ProjectName ;
      private string sMode28 ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool Z110EmployeeIsManager ;
      private bool A110EmployeeIsManager ;
      private bool Z112EmployeeIsActive ;
      private bool A112EmployeeIsActive ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool i112EmployeeIsActive ;
      private bool mustCommit ;
      private string Z111GAMUserGUID ;
      private string A111GAMUserGUID ;
      private string Z109EmployeeEmail ;
      private string A109EmployeeEmail ;
      private string N109EmployeeEmail ;
      private IGxSession AV12WebSession ;
      private SdtEmployee bcEmployee ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000F7_A101CompanyName ;
      private long[] BC000F8_A106EmployeeId ;
      private string[] BC000F8_A148EmployeeName ;
      private string[] BC000F8_A111GAMUserGUID ;
      private decimal[] BC000F8_A147EmployeeBalance ;
      private string[] BC000F8_A107EmployeeFirstName ;
      private string[] BC000F8_A108EmployeeLastName ;
      private string[] BC000F8_A109EmployeeEmail ;
      private string[] BC000F8_A101CompanyName ;
      private bool[] BC000F8_A110EmployeeIsManager ;
      private bool[] BC000F8_A112EmployeeIsActive ;
      private decimal[] BC000F8_A146EmployeeVactionDays ;
      private long[] BC000F8_A100CompanyId ;
      private string[] BC000F9_A109EmployeeEmail ;
      private long[] BC000F10_A106EmployeeId ;
      private long[] BC000F6_A106EmployeeId ;
      private string[] BC000F6_A148EmployeeName ;
      private string[] BC000F6_A111GAMUserGUID ;
      private decimal[] BC000F6_A147EmployeeBalance ;
      private string[] BC000F6_A107EmployeeFirstName ;
      private string[] BC000F6_A108EmployeeLastName ;
      private string[] BC000F6_A109EmployeeEmail ;
      private bool[] BC000F6_A110EmployeeIsManager ;
      private bool[] BC000F6_A112EmployeeIsActive ;
      private decimal[] BC000F6_A146EmployeeVactionDays ;
      private long[] BC000F6_A100CompanyId ;
      private long[] BC000F5_A106EmployeeId ;
      private string[] BC000F5_A148EmployeeName ;
      private string[] BC000F5_A111GAMUserGUID ;
      private decimal[] BC000F5_A147EmployeeBalance ;
      private string[] BC000F5_A107EmployeeFirstName ;
      private string[] BC000F5_A108EmployeeLastName ;
      private string[] BC000F5_A109EmployeeEmail ;
      private bool[] BC000F5_A110EmployeeIsManager ;
      private bool[] BC000F5_A112EmployeeIsActive ;
      private decimal[] BC000F5_A146EmployeeVactionDays ;
      private long[] BC000F5_A100CompanyId ;
      private long[] BC000F12_A106EmployeeId ;
      private string[] BC000F15_A101CompanyName ;
      private long[] BC000F16_A102ProjectId ;
      private long[] BC000F17_A172SupportRequestId ;
      private long[] BC000F18_A127LeaveRequestId ;
      private long[] BC000F19_A118WorkHourLogId ;
      private long[] BC000F20_A106EmployeeId ;
      private string[] BC000F20_A148EmployeeName ;
      private string[] BC000F20_A111GAMUserGUID ;
      private decimal[] BC000F20_A147EmployeeBalance ;
      private string[] BC000F20_A107EmployeeFirstName ;
      private string[] BC000F20_A108EmployeeLastName ;
      private string[] BC000F20_A109EmployeeEmail ;
      private string[] BC000F20_A101CompanyName ;
      private bool[] BC000F20_A110EmployeeIsManager ;
      private bool[] BC000F20_A112EmployeeIsActive ;
      private decimal[] BC000F20_A146EmployeeVactionDays ;
      private long[] BC000F20_A100CompanyId ;
      private long[] BC000F21_A106EmployeeId ;
      private string[] BC000F21_A103ProjectName ;
      private long[] BC000F21_A102ProjectId ;
      private string[] BC000F4_A103ProjectName ;
      private long[] BC000F22_A106EmployeeId ;
      private long[] BC000F22_A102ProjectId ;
      private long[] BC000F3_A106EmployeeId ;
      private long[] BC000F3_A102ProjectId ;
      private long[] BC000F2_A106EmployeeId ;
      private long[] BC000F2_A102ProjectId ;
      private string[] BC000F25_A103ProjectName ;
      private long[] BC000F26_A102ProjectId ;
      private long[] BC000F27_A118WorkHourLogId ;
      private long[] BC000F28_A106EmployeeId ;
      private string[] BC000F28_A103ProjectName ;
      private long[] BC000F28_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class employee_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class employee_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F11;
        prmBC000F11 = new Object[] {
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F12;
        prmBC000F12 = new Object[] {
        };
        Object[] prmBC000F13;
        prmBC000F13 = new Object[] {
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F14;
        prmBC000F14 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F15;
        prmBC000F15 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F16;
        prmBC000F16 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F17;
        prmBC000F17 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F18;
        prmBC000F18 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F19;
        prmBC000F19 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F20;
        prmBC000F20 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F21;
        prmBC000F21 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F22;
        prmBC000F22 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F23;
        prmBC000F23 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F24;
        prmBC000F24 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F25;
        prmBC000F25 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F26;
        prmBC000F26 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F27;
        prmBC000F27 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F28;
        prmBC000F28 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId  FOR UPDATE OF EmployeeProject",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT EmployeeId, EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "SELECT EmployeeId, EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F7", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F8", "SELECT TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeBalance, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F9", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F10", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F11", "SAVEPOINT gxupdate;INSERT INTO Employee(EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId) VALUES(:EmployeeName, :GAMUserGUID, :EmployeeBalance, :EmployeeFirstName, :EmployeeLastName, :EmployeeEmail, :EmployeeIsManager, :EmployeeIsActive, :EmployeeVactionDays, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F11)
           ,new CursorDef("BC000F12", "SELECT currval('EmployeeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F13", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeName=:EmployeeName, GAMUserGUID=:GAMUserGUID, EmployeeBalance=:EmployeeBalance, EmployeeFirstName=:EmployeeFirstName, EmployeeLastName=:EmployeeLastName, EmployeeEmail=:EmployeeEmail, EmployeeIsManager=:EmployeeIsManager, EmployeeIsActive=:EmployeeIsActive, EmployeeVactionDays=:EmployeeVactionDays, CompanyId=:CompanyId  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F13)
           ,new CursorDef("BC000F14", "SAVEPOINT gxupdate;DELETE FROM Employee  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F14)
           ,new CursorDef("BC000F15", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F16", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F17", "SELECT SupportRequestId FROM SupportRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F18", "SELECT LeaveRequestId FROM LeaveRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F19", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F20", "SELECT TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeBalance, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F21", "SELECT T1.EmployeeId, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId and T1.ProjectId = :ProjectId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F22", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F23", "SAVEPOINT gxupdate;INSERT INTO EmployeeProject(EmployeeId, ProjectId) VALUES(:EmployeeId, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F23)
           ,new CursorDef("BC000F24", "SAVEPOINT gxupdate;DELETE FROM EmployeeProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F24)
           ,new CursorDef("BC000F25", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F26", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F27", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F28", "SELECT T1.EmployeeId, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F28,11, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
