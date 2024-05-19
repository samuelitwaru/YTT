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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class asendcontactusemail : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new asendcontactusemail().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         string aP0_supportsubject = new string(' ',0)  ;
         string aP1_supportdescription = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_supportsubject=((string)(args[0]));
         }
         else
         {
            aP0_supportsubject="";
         }
         if ( 1 < args.Length )
         {
            aP1_supportdescription=((string)(args[1]));
         }
         else
         {
            aP1_supportdescription="";
         }
         execute(aP0_supportsubject, aP1_supportdescription);
         return GX.GXRuntime.ExitCode ;
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

      public asendcontactusemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asendcontactusemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_supportsubject ,
                           string aP1_supportdescription )
      {
         this.AV11supportsubject = aP0_supportsubject;
         this.AV12supportdescription = aP1_supportdescription;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_supportsubject ,
                                 string aP1_supportdescription )
      {
         asendcontactusemail objasendcontactusemail;
         objasendcontactusemail = new asendcontactusemail();
         objasendcontactusemail.AV11supportsubject = aP0_supportsubject;
         objasendcontactusemail.AV12supportdescription = aP1_supportdescription;
         objasendcontactusemail.context.SetSubmitInitialConfig(context);
         objasendcontactusemail.initialize();
         Submit( executePrivateCatch,objasendcontactusemail);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asendcontactusemail)stateInfo).executePrivate();
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
         new getloggedinuser(context ).execute( out  AV14GAMUser, out  AV13employee) ;
         AV8SMTPSession.Host = "timetracker.yukon.software";
         AV8SMTPSession.Port = 465;
         AV8SMTPSession.Authentication = 0;
         AV8SMTPSession.AuthenticationMethod = "";
         AV8SMTPSession.UserName = "redfu@timetracker.yukon.software";
         AV8SMTPSession.Password = "3Vzo5oOFuxkquz+e";
         AV8SMTPSession.Secure = 1;
         AV8SMTPSession.Sender.Address = "redfu@timetracker.yukon.software";
         AV8SMTPSession.Sender.Name = "Yukon Time Tracker";
         AV9MailRecipient.Address = "timetracker@yukon.software";
         AV9MailRecipient.Name = "Time Tracker Support";
         AV10MailMessage.Subject = AV11supportsubject;
         AV10MailMessage.HTMLText = "<p> Hi support,</p>"+"<p>"+AV13employee.gxTpr_Employeeemail+"</p>"+"<p>has sent the following support request:</p>"+"<p>"+AV12supportdescription+"</p>";
         AV10MailMessage.To.Add(AV9MailRecipient);
         AV8SMTPSession.Login();
         if ( AV8SMTPSession.ErrCode == 0 )
         {
            AV8SMTPSession.Send(AV10MailMessage);
            AV8SMTPSession.Logout();
         }
         else
         {
            GX_msglist.addItem(AV8SMTPSession.ErrDescription);
         }
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
         AV14GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV13employee = new SdtEmployee(context);
         AV8SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV10MailMessage = new GeneXus.Mail.GXMailMessage();
         /* GeneXus formulas. */
      }

      private string AV11supportsubject ;
      private string AV12supportdescription ;
      private GeneXus.Mail.GXMailMessage AV10MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV9MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV8SMTPSession ;
      private SdtEmployee AV13employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GAMUser ;
   }

}
