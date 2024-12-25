using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class CompanyDate : Base
    {
       
        #region Private Fields  
       
        private string _CMst;
        private string _CName;
        private string _CAddress1;
        private string _CAddress2;
        private string _CAddress3;
        private string _City;
        private string _PCode;
        private DateTime? _RunDate;
        private int? _ICP;
        private bool _fColRep;
        private bool _fPayRep;
        private bool _fTBRep;
        private int _LstSTCNo;
        private string _PEditCh;
        private string _RefundPass;
        private string _SecurityPass;
        private string _HighSecurityPass;
        private string _RegSecurity;
        private string _Phone;
        private string _Fax;
        private string _EMail;
        private DateTime? _FyStDt;
        private DateTime? _FyEdDT;
        private bool? _DBClose;
        private double _AuthCap;
        private double _PaidupCap;
        private int _NoOfEmp;
        private string _ChrmnPW;
        private string _ContactPrsn;
        private string _ContactPhone;
        private string _TrChallanNote;
        private int? _LastTAXChallanNo;
        private string _ChallanPrefix;
       
        #endregion
        #region Public Properties  
      
        public string CMst { get { return _CMst; } set { _CMst = value; } }
        public string? CName { get { return _CName; } set { _CName = value; } }
        public string? CAddress1 { get { return _CAddress1; } set { _CAddress1 = value; } }
        public string? CAddress2 { get { return _CAddress2; } set { _CAddress2 = value; } }
        public string? CAddress3 { get { return _CAddress3; } set { _CAddress3 = value; } }
        public string? City { get { return _City; } set { _City = value; } }
        public string? PCode { get { return _PCode; } set { _PCode = value; } }
        public DateTime? RunDate { get { return _RunDate; } set { _RunDate = value; } }
        public int? ICP { get { return _ICP; } set { _ICP = value; } }
        public bool fColRep { get { return _fColRep; } set { _fColRep = value; } }
        public bool fPayRep { get { return _fPayRep; } set { _fPayRep = value; } }
        public bool fTBRep { get { return _fTBRep; } set { _fTBRep = value; } }
        public int LstSTCNo { get { return _LstSTCNo; } set { _LstSTCNo = value; } }
        public string? PEditCh { get { return _PEditCh; } set { _PEditCh = value; } }
        public string? RefundPass { get { return _RefundPass; } set { _RefundPass = value; } }
        public string? SecurityPass { get { return _SecurityPass; } set { _SecurityPass = value; } }
        public string? HighSecurityPass { get { return _HighSecurityPass; } set { _HighSecurityPass = value; } }
        public string? RegSecurity { get { return _RegSecurity; } set { _RegSecurity = value; } }
        public string? Phone { get { return _Phone; } set { _Phone = value; } }
        public string? Fax { get { return _Fax; } set { _Fax = value; } }
        public string? EMail { get { return _EMail; } set { _EMail = value; } }
        public DateTime? FyStDt { get { return _FyStDt; } set { _FyStDt = value; } }
        public DateTime? FyEdDT { get { return _FyEdDT; } set { _FyEdDT = value; } }
        public bool? DBClose { get { return _DBClose; } set { _DBClose = value; } }
        public double AuthCap { get { return _AuthCap; } set { _AuthCap = value; } }
        public double PaidupCap { get { return _PaidupCap; } set { _PaidupCap = value; } }
        public int NoOfEmp { get { return _NoOfEmp; } set { _NoOfEmp = value; } }
        public string? ChrmnPW { get { return _ChrmnPW; } set { _ChrmnPW = value; } }
        public string? ContactPrsn { get { return _ContactPrsn; } set { _ContactPrsn = value; } }
        public string? ContactPhone { get { return _ContactPhone; } set { _ContactPhone = value; } }
        public string? TrChallanNote { get { return _TrChallanNote; } set { _TrChallanNote = value; } }
        public int? LastTAXChallanNo { get { return _LastTAXChallanNo; } set { _LastTAXChallanNo = value; } }
        public string? ChallanPrefix { get { return _ChallanPrefix; } set { _ChallanPrefix = value; } }

        public int Validity { get; set; }

        #endregion
    }
}
