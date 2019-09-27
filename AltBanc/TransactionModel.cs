using System;


namespace AltBanc
{
    public class TransactionModel
    {
        private DateTime _transactionDate;
        private string _transactionType;
        private decimal _transactionAmount;
        private Guid _transactionID;

        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                //value = GetTheDate();
                _transactionDate = value;
            }
        }

        public Guid TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
            }
        }

        public decimal TransactionAmount
        {
            get
            {
                return _transactionAmount;
            }
            set
            {
                _transactionAmount = value;
            }
        }

        public string TransactionType
        {
            get
            {
                return _transactionType;
            }
            set
            {
                _transactionType = value;
            }
        }

        private DateTime GetTheDate()
        {
            return DateTime.Now;
        }

        private Guid GetGuid()
        {
            return Guid.NewGuid();
        }

        public TransactionModel(string transactionType, decimal transactionAmount)
        {
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
            TransactionDate = GetTheDate();
            TransactionID = GetGuid();
        }

        //Override to allow Transaction History to print.
        public override string ToString()
        {
            return string.Format("\t______________________________________________________________________\n" +
                                 "\t| Date:               | Transaction Type:\n" +
                                 "\t| {0}  | {1}\n" +
                                 "\t|---------------------------------------------------| Amount:\n" +
                                 "\t|---------------------------------------------------| {2:C}\n" +
                                 "\t| Transaction ID:\n" +
                                 "\t| {3}\n" +
                                 "\t|_____________________________________________________________________", TransactionDate, TransactionType, TransactionAmount, TransactionID);
        }
    }
}
