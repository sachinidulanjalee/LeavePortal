using System.ComponentModel;

namespace LeavePortal.Common
{
    public enum Test
    {
        [Description("DEMO")]
        DEMO = 1,
    }


    public enum DocumentSubmitted
    {
        Yes = 2,
        No = 1
    }

    public enum AutharizationLevel
    {
        [Description("Authorization Level 1")]
        AuthorizationLevel1 = 1,

        [Description("Authorization Level 2")]
        AuthorizationLevel2 = 2,

        [Description("Authorization Level 3")]
        AuthorizationLevel3 = 3,

        [Description("Authorization Level 4")]
        AuthorizationLevel4 = 4,

        [Description("Finance Authorization")]
        FinanceAuthorization = 5
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
        [Description("--Select--")]
        Select = 0,
        Male = 1,
        Female = 2,
        Other
    }

    public enum userType
    {
        [Description("--Select--")]
        Select = 0,
        Admin = 1,
       User  =2
    }
    public enum SerialNosMode
    {
        ACNO = 1,
        LCNO = 2,
        EANO = 3
    }
    public enum LeaveRequestDayMode1
    {
        [Description("Full Day")]
        Fullday = 1,

        [Description("Half Day")]
        Halfday = 2
    }

    public enum LeaveRequestDayMode2
    {
        [Description("Short Leave")]
        ShortLeave = 4
    }

    public enum LeaveRequestDayMode3
    {
        [Description("Full Day")]
        Fullday = 1
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

    public enum Selction
    {
        [Description("--Select--")]
        Select = 0,
        [Description("AllEmployee")]
        AllEmployee = 1,
    }

    public enum LeaveAllocationPeriod
    {
        [Description("--Select--")]
        Select = 0,
        Calendar_Year = 1,
        Joined_Year = 2
    }

    public enum Title
    {
        [Description("--Select--")]
        Select = 0,
        Mr = 1,
        Ms = 2,
        Miss = 3,
        Mrs = 4,
        Dr = 5,
        Rev = 6,
        Prof = 7
    }

    public enum LeaveApprovelMode
    {
        Auto = 1,
        Manual = 2,
    }

    public enum LeaveStatus
    {
        Pending = 1,
        Approved = 2,
        Denied = 3,
        Cancel = 4,
        Validate = 5,
        DoubleDeduction = 6
    }

    public enum Gender
    {
        [Description("--Select--")]
        Select = 0,
        Male = 1,
        Female = 2
    }
    public enum CivilStatus
    {
        [Description("--Select--")]
        Select = 0,
        Married = 1,
        Unmarried = 2
    }


    public enum LabourAct
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Shop And Office Act")]
        ShopAndOfficeAct = 1,

        [Description("Wages Boards Ordinance")]
        WagesBoardsOrdinance = 2
    }
    public enum Religion
    {
        [Description("--Select--")]
        Select = 0,
        [Description("Buddhist")]
        Buddhist = 1,

        [Description("Roman Catholic")]
        RomanCatholic = 2,

        [Description("Islam")]
        Islam = 3,

        [Description("Hindu")]
        Hindu = 4,

        [Description("Christian")]
        Christian = 5,

        [Description("Anglican")]
        Anglican = 6,

        [Description("Other")]
        Other
    }

    public enum Nationality
    {
        [Description("--Select--")]
        Select = 0,
        SriLankan = 1,
        American,
        British,
        Indian,
        Afghanistan,
        Albania,
        Algeria,
        Andorra,
        Angola,
        AntiguaandBarbuda,
        Argentina,
        Armenia,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bolivia,
        BosniaandHerzegovina,
        Botswana,
        Brazil,
        Brunei,
        Bulgaria,
        BurkinaFaso,
        Burundi,
        CôtedIvoire,
        CaboVerde,
        Cambodia,
        Cameroon,
        Canada,
        CentralAfricanRepublic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo,
        CostaRica,
        Croatia,
        Cuba,
        Cyprus,
        Czechia,
        DemocraticRepublicoftheCongo,
        Denmark,
        Djibouti,
        Dominica,
        DominicanRepublic,
        Ecuador,
        Egypt,
        ElSalvador,
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Eswatini,
        Ethiopia,
        Fiji,
        Finland,
        France,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Grenada,
        Guatemala,
        Guinea,
        GuineaBissau,
        Guyana,
        Haiti,
        HolySee,
        Honduras,
        Hungary,
        Iceland,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        MarshallIslands,
        Mauritania,
        Mauritius,
        Mexico,
        Micronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        NewZealand,
        Nicaragua,
        Niger,
        Nigeria,
        NorthKorea,
        NorthMacedonia,
        Norway,
        Oman,
        Pakistan,
        Palau,
        PalestineState,
        Panama,
        PapuaNewGuinea,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,
        Romania,
        Russia,
        Rwanda,
        SaintKittsandNevis,
        SaintLucia,
        SaintVincentandtheGrenadines,
        Samoa,
        SanMarino,
        SaoTomeandPrincipe,
        SaudiArabia,
        Senegal,
        Serbia,
        Seychelles,
        SierraLeone,
        Singapore,
        Slovakia,
        Slovenia,
        SolomonIslands,
        Somalia,
        SouthAfrica,
        SouthKorea,
        SouthSudan,
        Spain,
        Sudan,
        Suriname,
        Sweden,
        Switzerland,
        Syria,
        Tajikistan,
        Tanzania,
        Thailand,
        TimorLeste,
        Togo,
        Tonga,
        TrinidadandTobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        Tuvalu,
        Uganda,
        Ukraine,
        UnitedArabEmirates,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        Vietnam,
        Yemen,
        Zambia,
        Zimbabwe
    }

    public enum WhichHalf
    {
        [Description("Not Applicable")]
        NotApplicable = 0,

        [Description("First Half")]
        FirstHalf = 1,

        [Description("Second Half")]
        SecondHalf = 2
    }


}