using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.LIBS
{
    public static class SiteKey
    {
        public static string TallyURL
        {
            get { return "http://43.240.64.88:15830/"; }
        }

        public static string ReportingManagerDSE
        {
            get { return "22,23,19"; }
        }


        public static string ReportingManagerSM
        {
            get { return "23,24,25"; }
        }

        public static string ReportingManagerGM
        {
            get { return "24,25"; }
        }

        public static string ReportingManagerCEO
        {
            get { return "25"; }
        }


        public static string DomainName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DomainName"]; }
        }

        public static DateTime AsperRunningHour
        {
            get { return new DateTime(1971,1,1); }
        }
        public enum MessageType
        {
            info,
            warning,
            danger,
            success
        }

        public enum OptionShow
        {
            SendCouponWa = 1,
            SendCouponEmail = 2,
            PrintCoupon = 3,
        }


     


        public enum scheduletype
        {
            Monthly=1,
            Quarterly = 2,
            HalfYearly=3,
            Yearly=4
        }

        public enum BookingStatus
        {
            Request = 1,
            Recommed = 2,
            Reject = 3,
            Approve = 4
        }

        public enum MasterParent
        {
            PaymentMothod = 1,
            InsuranceCoupon = 2,
            ECoupon = 9,
            
        }

        public enum MainExamType
        {
            TearmOne = 1,
            TearmTwo = 2,
            NoTearm = 3,
            
        }







        public enum SmsType
        {
            unicode,
            english,
        }


        public enum UserRole
        {
            Admin = 1,
            Teacher = 2,
            Employee = 3,
            Student = 4,
            Visitor = 5,
            FeesCollecoter = 6,
            Principle = 7,
            Other = 8,
            VicePrincipal = 9,
            Director = 10,
            Librarian = 11,
            Lecture = 12,



        }

        public enum AttendanceMeting
        {
            FirstMeeting = 1,
            SecondMeeting = 2,
        }

        public enum AttendanceType
        {
            Precent = 1,
            Absent = 2,
        }



        public static bool Positive()
        {
            return true;
            
        }

        public static bool Nagitive()
        {
            return false;

        }
      
        public enum ReportType
        {
            Schedule = 1,
            Maintenance = 2,
            
        }


        public enum InstallmentMode
        {
            Monthly = 1,
            OneTime = 2,
            HalfYearly = 3
        }

        public enum AgentType
        {
            Fix = 1,
            NonFix = 2
        }

        public enum VichelWhat
        {
            New = 0,
            Old = 1
        }


        public enum UserRoleEnum
        {
            Administrator = 3,
            Agent = 4,
            Customer = 5,

        }

        public enum AccountHead
        {
            AdvancePayChallan = 1,
            LrPayment = 2,
            InvoiceReceive = 3

        }
        public enum AccountType
        {
            Credit = 1,
            Debit = 0
           

        }





        #region Installment Plans
        public enum RequestEnum
        {
            Store = 3,
            Project = 2,
            Admin = 1,

        }
        public enum RequestStatus
        {
            Pending = 1,
            Complete = 2,
            Waiting = 3,
            Reject = 4
        }

        public enum PaymentMode
        {
            Cash = 1,
            Cheque = 2
        }
        #endregion


    }
}