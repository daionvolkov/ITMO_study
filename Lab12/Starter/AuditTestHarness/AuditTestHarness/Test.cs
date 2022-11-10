namespace AuditTestHarness
{
    using System;
    using Banking;

    public class Test
    {
        public static void Main()
        {
            Audit testAudit = new Audit("AuditTrail.dat");
            BankTransaction testTran = new BankTransaction(500);
            AuditEventArgs testArg = new AuditEventArgs(testTran);
            testAudit.RecordTransaction(null, testArg);

            BankTransaction testTran2 = new BankTransaction(-200);
            AuditEventArgs testArg2 = new AuditEventArgs(testTran2);
            testAudit.RecordTransaction(null, testArg2);


            


        testAudit.Close();

            public delegate void AuditEventHandler(Object sender, AuditEventArgs data);
        
         public void AddOnAuditingTransaction(AuditEventHandler handler)
        {
            this.AuditingTransaction += handler;
        }
        public void RemoveOnAuditingTransaction(AuditEventHandler handler)
        {
            this.AuditingTransaction -= handler;
        }

        
    }
    }

