using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.Types;

namespace WebServices.Models.External
{
    public abstract class LifePolicy : Policy
    {
        public Text PolicyNo { get; }
        public Text ApplyNo { get; }
        public Text ReceiveDate { get; }
        public Text IssueDate { get; }
        public Text EndDate { get; }
        public Text SalesNo { get; }
        public Text SalesName { get; }
        public Text InsurerCode { get; }

        public Text PolHolderNo { get; }
        public Text PolHolderName { get; }
        public Text PolHolderBirthday { get; }
        public Text PolHolderGender { get; }
        public Text PolHolderCountry { get; }
        public Text PolHolderPhone { get; }
        public Text PolHolderPostCode { get; }
        public Text PolHolderAddr { get; }

        public Text PaymentType { get; }
        public uint TotalNTDPremium { get; }
        public Text Remark { get; }
        public Text Invest { get; }
        public Text SNO { get; }
        public Text PremiumPayType { get; }

        public Text InsuredID { get; }
        public Text InsuredName { get; }
        public Text InsuredBirthday { get; }
        public Text InsuredGender { get; }
        public Text InsuredPhone { get; }
        public Text InsuredPostCode { get; }
        public Text InsuredAddr { get; }
        public Text InsuredCountry { get; }

        public byte[] PDF { get; }
        public Text Path { get; }
        public Text PDFFileName { get; }

        public List<Plan> Plans { get; }

    }
}
