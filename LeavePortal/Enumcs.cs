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


}