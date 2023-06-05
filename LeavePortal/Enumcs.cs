using System.ComponentModel;

namespace LeavePortal.Common
{
    public enum Test
    {
        [Description("DEMO")]
        DEMO = 1,
    }

    public enum UserStatus
    {
        [Description("New User")]
        NewUser = 1,

        [Description("Active")]
        Active = 2,

        [Description("Password Reset")]
        PasswordReset = 3,

        [Description("Auto Inactive")]
        AutoInactive = 4,

        [Description("Inactive")]
        Inactive = 5
    }

    public enum Status
    {
        [Description("--Select--")]
        Select = 0,
        Active = 1,
        Inactive = 2
    }

    public enum sex
    {
        Male = 1,
        Female = 2,
        Other
    }

    public enum userType
    {  Admin = 1,
       User  =2
    }

    public enum LeaveDayMode
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Full Day")]
        Fullday = 1,

        [Description("Half Day")]
        Halfday = 2,

        Both = 3,
        Hourly = 4
    }

    public enum DayMode
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Full Day")]
        FullDay = 1,

        [Description("Half Day")]
        HalfDay = 2,

        Both = 3,
        Hourly = 4
    }
    public enum LeaveEntitlemant
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Not Used")]
        NotUse = 1,

        [Description("Weekly")]
        Weekly = 2,

        [Description("Monthly")]
        Monthly = 3,

        [Description("Annually")]
        Annually = 4,

        [Description("Occasionally")]
        Occasionally = 5,

        [Description("Quarterly End")]
        Quarterly = 6,

        [Description("Yearly End")]
        Yearly = 7
    }

    public enum LeaveTypeIsDeductFromQuota
    {
        [Description("--Select--")]
        Select =0,
        Yes = 1,
        No = 2
    }

    public enum LeaveAccrualType
    {
        [Description("--Select--")]
        Select = 0,
        [Description("First Year")]
        FirstYear = 1,

        [Description("Second Year")]
        SecondYear = 2,

        [Description("Third Year Onwards")]
        ThirdYearOnwards = 3
    }


    public enum YesNo
    {
        [Description("--Select--")]
        Select = 0,
        Yes = 1,
        No = 2
    }

    public enum LeaveGeneratedBy
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Joined Date")]
        JoinedDate = 1,

        [Description("Confirmation Date")]
        ConfirmationDate = 2
    }
    public enum ProrateType
    {
        [Description("--Select--")]
        Select = 0,
        Quarterly = 1,
        Monthly = 2
    }

    public enum Quarter
    {
        [Description("--Select--")]
        Select = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        [Description("--Select--")]
        Select = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}