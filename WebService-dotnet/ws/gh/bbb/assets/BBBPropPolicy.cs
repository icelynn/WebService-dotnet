using System;
using System.Collections.Generic;
using System.IO;
using WebServices.Models.External;
using WebServices.Types;

namespace WebServices.ws.gh.bbb.assets {
    public class BBBPropPolicy : PropPolicy
    {

#region Base fileds

        public new Text PolicyNo { get; }
        public new Text ApplyNo { get; }
        public new Text ReceiveDate { get; }
        public new Text IssueDate { get; }
        public new Text EndDate { get; }
        public new Text SalesNo { get; }
        public new Text SalesName { get; }
        public new Text InsurerCode { get; }

        public new Text PolHolderNo { get; }
        public new Text PolHolderName { get; }
        public new Text PolHolderBirthday { get; }
        public new Text PolHolderGender { get; }
        public new Text PolHolderCountry { get; }
        public new Text PolHolderPhone { get; }
        public new Text PolHolderPostCode { get; }
        public new Text PolHolderAddr { get; }

        public new Text PaymentType { get; }
        public new uint TotalNTDPremium { get; }
        public new Text Remark { get; }
        public new Text Invest { get; }
        public new Text SNO { get; }
        public new Text PremiumPayType { get; }

        // Nullable fields
        public new Text LicenseNo { get; }
        public new Text DateOfIssue { get; }
        public new Text DateOfBuilt { get; }
        public new Text VIN { get; }

        public new Text InsuredID { get; }
        public new Text InsuredName { get; }
        public new Text InsuredBirthday { get; }
        public new Text InsuredGender { get; }
        public new Text InsuredPhone { get; }
        public new Text InsuredPostCode { get; }
        public new Text InsuredAddr { get; }
        public new Text InsuredCountry { get; }

        // PDF binary
        public new byte[] PDF { get; }
        public new static Text Path { get; }
        public new Text PDFFileName { get; }

        public new List<Plan> Plans { get; }

#endregion

        static BBBPropPolicy()
        {
            Path = (Text)@"D:\Projects\WebServices\PDFs\original";
        }

        public BBBPropPolicy()
        {
            DateTime time = DateTime.Now;
            string timeString = time.ToString("yyyyMMdd_HHmmss");
            PDFFileName = timeString + (string)ApplyNo;
            ConvertToPDF();
        }

        public override void ConvertToPDF()
        {
            File.WriteAllBytes((string)Path, this.PDF);
        }

    }
}