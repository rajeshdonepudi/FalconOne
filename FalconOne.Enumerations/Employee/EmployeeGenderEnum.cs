

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Enumerations.Employee
{
    public enum EmployeeGenderEnum
    {
        NotSpecified = 0,
        Male,
        Female,
    }

    public enum AddressTypeEnum
    {
        NotSpecified,
        Permanent,
        Current,
    }

    public enum LocationTypeEnum
    {
        NotSpecified,
        Work,
        Home,
        FriendsOrFamily,
        Others
    }

    public enum MaritalStatusEnum
    {
        [Display(Name = "N/A")]
        NotSpecified,
        Single,
        Married,
        Divorced,
        Widowed,
        Separated
    }

    public enum EmploymentTypeEnum
    {
        NotSpecified,
        FullTime,
        PartTime,
        SelfEmployed,
        Freelance,
        Internship,
        Trainee,
    }

    public enum EmployeeBandEnum
    {
        [Display(Name = "N/A")]
        NotSpecified,
        [Display(Name = "Executive Band")]
        [Description("This band typically includes top-level executives, such as CEOs, CFOs, and other C-suite executives. They hold significant decision-making authority and often have responsibilities for strategic planning and overall company management")]
        ExecutiveBand,
        [Display(Name = "Managerial Band")]
        [Description(" Employees in this band have supervisory roles and are responsible for managing a team or department within the organization. They oversee the work of other employees and play a key role in executing the company's objectives")]
        ManagerialBand,
        [Display(Name = "Professional Band")]
        [Description("This band includes employees who hold specialized professional roles within the organization. Examples may include doctors, lawyers, engineers, architects, scientists, or other highly skilled individuals who require specific qualifications or certifications for their positions")]
        ProfessionalBand,
        [Display(Name = "Technical Band")]
        [Description("Employees in the technical band typically have technical expertise and are involved in areas such as information technology, software development, engineering, research and development, or other specialized technical roles")]
        TechnicalBand,
        [Display(Name = "Administrative Band")]
        [Description("This band includes employees who provide administrative support to various functions within the organization. They may perform tasks such as clerical work, data entry, scheduling, record keeping, or other administrative duties")]
        AdministrativeBand,
        [Display(Name = "Support Staff Band")]
        [Description("This band encompasses employees who provide essential support services to the organization but are not directly involved in core business operations. It may include roles such as receptionists, maintenance staff, janitors, security personnel, or other support positions.")]
        SupportStaffBand
    } 

    public enum WeekDayEnum
    {
        [Display(Name = "N/A")]
        NotSpecified,
        [Display(Name = "Monday")]
        Monday,
        [Display(Name = "Tuesday")]
        Tuesday,
        [Display(Name = "Wednesday")]
        Wednesday,
        [Display(Name = "Thursday")]
        Thursday,
        [Display(Name = "Friday")]
        Friday,
    }

    public enum DayOfWeekEnum
    {
        [Display(Name = "N/A")]
        NotSpecified = 0,
        [Display(Name = "Sunday")]
        Sunday = 1,
        [Display(Name = "Monday")]
        Monday,
        [Display(Name = "Tuesday")]
        Tuesday,
        [Display(Name = "Wednesday")]
        Wednesday,
        [Display(Name = "Thursday")]
        Thursday,
        [Display(Name = "Friday")]
        Friday,
        [Display(Name = "Saturday")]
        Saturday
    }


    public enum AttendanceCaptureMethodTypeEnum
    {
        [Description("Attendance capture using biometric identification, such as fingerprint or facial recognition")]
        Biometric,
        [Description("Attendance capture using a physical time clock or punch clock system")]
        TimeClock,
        [Description(" Attendance capture through a mobile application on a smartphone or tablet")]
        MobileApp,
        [Description("Attendance capture through a web-based portal or application")]
        WebPortal,
        [Description("Attendance capture through manual entry, where employees enter their attendance data manually")]
        ManualEntry,
        [Description("Attendance capture using Near Field Communication (NFC) technology")]
        NFC,
        [Description("Attendance capture based on the location of the employee using Global Positioning System (GPS) technology")]
        GPS,
        [Description("Attendance capture using QR code scanning")]
        QRCode
    }


    public enum OvertimeCalculationMethodEnum
    {
        Weekly,
        Daily,
        Both
    }

    public enum ShiftTypeEnum
    {
        NotSpecified,
        MorningShift,
        EveningShift,
        NightShift
    }

    public enum EmployeePayGradeEnum
    {
        [Display(Name = "N/A")]
        NotSpecified,
        [Display(Name = "Pay Grade A")]
        [Description("Entry-level or junior positions with minimal experience or qualifications")]
        A,
        [Display(Name = "Pay Grade B")]
        [Description("Positions that require some experience or specific skills but are still considered relatively junior")]
        B,
        [Display(Name = "Pay Grade C")]
        [Description("Mid-level positions with moderate experience, responsibilities, and skill requirements")]
        C,
        [Display(Name = "Pay Grade D")]
        [Description(" Positions that require significant experience, expertise, and more complex responsibilities")]
        D,
        [Display(Name = "Pay Grade E")]
        [Description(" Senior-level or managerial positions with extensive experience, leadership responsibilities, and strategic decision-making authority")]
        E,
        [Display(Name = "Pay Grade F")]
        [Description("Executive-level positions such as top-level executives, such as CEOs, CFOs, or other C-suite roles")]
        F
    }

    public enum TimeTypeEnum
    {
        NotSpecified,
        [Display(Name = "Full-time")]
        [Description("Full-time employees typically work a standard number of hours per week, which is typically around 35 to 40 hours. They are considered regular, permanent employees and are entitled to full employment benefits provided by the company")]
        FullTime,
        [Display(Name = "Part-time")]
        [Description("Part-time employees work fewer hours per week compared to full-time employees. The exact number of hours can vary but is generally less than the standard full-time hours. Part-time employees may receive some employment benefits, but they typically have fewer entitlements compared to full-time employees")]
        PartTime,
        [Display(Name = "Casual/Intermittent")]
        [Description("Casual or intermittent employees do not have a fixed schedule or guaranteed minimum number of hours. They work on an as-needed basis, often filling in for absent employees or handling temporary workload fluctuations. Casual employees may not have the same benefits and entitlements as regular employees")]
        CasualOrIntermittent,
        [Display(Name = "Shift/Rotation")]
        [Description("Shift or rotational employees work in shifts that cover different time periods throughout the day or week. This is common in industries that require 24-hour operations, such as healthcare, manufacturing, or customer service. Shift workers may have varying schedules and may receive additional compensation or benefits for working during certain shifts, such as night shifts")]
        ShiftOrRotation,
        [Display(Name = "Flex-time")]
        [Description("Flex-time allows employees to have more control over their work schedules within certain parameters defined by the employer. They may have core hours during which they need to be present, but they can choose the start and end times of their workday. This arrangement provides greater flexibility for employees to manage their personal obligations while still meeting work requirements")]
        FlexTime,
        [Display(Name = "Compressed Workweek")]
        [Description("A compressed workweek allows employees to work a full-time schedule in fewer than the standard number of days. For example, instead of working five eight-hour days, an employee may work four ten-hour days. This arrangement gives employees longer weekends or additional time off during the week")]
        CompressedWorkweek
    }

    public enum WorkerTypeEnum
    {
        NotSpecified,
        [Display(Name = "Permanent/Full-time Employee")]
        [Description("A worker who is employed on a permanent basis and typically works a standard number of hours per week. They are entitled to benefits and job security.")]
        Permanent,
        [Display(Name = "Temporary Employee")]
        [Description(" A worker who is hired for a specific period or project and is not expected to remain with the company long-term. They may be employed directly by the company or through a temporary staffing agency")]
        TemporaryEmployee,
        [Display(Name = "Contract Worker/Independent Contractor")]
        [Description("An individual who provides services to a company under a contractual agreement. They are usually self-employed and are responsible for their own taxes and benefits. Contracts can be short-term or long-term")]
        ContractWorkerOrIndependentContractor,
        [Display(Name = "Freelancer")]
        [Description(" Similar to a contract worker, a freelancer is self-employed and typically works on a project basis for multiple clients. They have more flexibility in choosing their projects and clients.")]
        Freelancer,
        [Display(Name = "Part-time Employee")]
        [Description("A worker who works fewer hours than a full-time employee, typically less than 30-35 hours per week. They may receive some benefits but generally have fewer entitlements compared to full-time employees")]
        PartTimeEmployee,
        [Display(Name = "Seasonal Employee")]
        [Description("A worker who is hired to meet the demands of a specific season or period, such as during holidays or peak business times. They are usually temporary and often work in industries like retail, tourism, or agriculture")]
        SeasonalEmployee,
        [Display(Name = "Intern")]
        [Description("A student or recent graduate who works in a company to gain practical experience in their field of study. Internships can be paid or unpaid and have a set duration")]
        Intern,
        [Display(Name = "Remote/Telecommuting Worker")]
        [Description("A worker who performs their job duties from a location other than the company's physical office, often working from home or another remote location. This arrangement has become more common with advancements in technology")]
        RemoteOrTelecommutingWorker,
        [Display(Name = "On-call Employee")]
        [Description("A worker who is available to work when needed but may not have set hours or a regular schedule. They are typically called in to cover shifts or handle unexpected work demands")]
        OnCallEmployee
    }

    public enum WorkLocationType
    {
        NotSpecified,
        OnSite,
        Hybrid,
        Remote
    }

    public enum MetadataGroupTypeClassificationEnum
    {
        NotSpecified,
        IdentityInformation,
        Relations
    }

    public enum MediaTypeEnum
    {
        HyperLink,
        Photo
    }

    public enum BloodGroupTypeEnum
    {
        [Display(Name = "N/A")]
        [Description("N/A")]
        NotSpecified,
        [Description("O positive (O+)")]
        OPositive,
        [Description("O negative (O-)")]
        ONegative,
        [Description("A positive (A+)")]
        APositive,
        [Description("A negative (A-)")]
        ANegative,
        [Description("B positive (B+)")]
        BPositive,
        [Description("B negative (B-)")]
        BNegative,
        [Description("AB positive (AB+)")]
        ABPositive,
        [Description("AB negative (AB-)")]
        ABNegative,
    }
}
