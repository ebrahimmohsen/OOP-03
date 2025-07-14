using System.Globalization;

namespace OOP_03
{
    #region Q1 Design and implement a Class for the employees in a company

    enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer
    }
    #endregion
    internal class Program
    {
        #region Q1 Design and implement a Class for the employees in a company

        class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }

            private char gender;
            public char Gender
            {
                get => gender;
                set
                {
                    if (value == 'M' || value == 'F')
                        gender = value;
                    else
                        throw new ArgumentException("Gender must be 'M' or 'F'.");
                }
            }

            public SecurityLevel Security { get; set; }

            private decimal salary;
            public decimal Salary
            {
                get => salary;
                set
                {
                    if (value >= 0)
                        salary = value;
                    else
                        throw new ArgumentException("Salary must be non-negative.");
                }
            }

            public override string ToString()
            {
                return $"ID: {ID}, Name: {Name}, Gender: {Gender}, Security: {Security}, " +
                       $"Salary: {string.Format(CultureInfo.CurrentCulture, "{0:C}", Salary)}";
            }

            public Employee(int id, string name, char gender, SecurityLevel security, decimal salary)
            {
                ID = id;
                Name = name;
                Gender = gender;
                Security = security;
                Salary = salary;
            }
        }
        #endregion

        #region Q2 Develop a Class to represent the Hiring Date Data
        class HireDate
        {
            private int day, month, year;

            public int Day
            {
                get => day;
                set
                {
                    if (value >= 1 && value <= 31)
                        day = value;
                    else
                        throw new ArgumentException("Day must be between 1 and 31.");
                }
            }

            public int Month
            {
                get => month;
                set
                {
                    if (value >= 1 && value <= 12)
                        month = value;
                    else
                        throw new ArgumentException("Month must be between 1 and 12.");
                }
            }

            public int Year
            {
                get => year;
                set
                {
                    if (value >= 1900 && value <= DateTime.Now.Year)
                        year = value;
                    else
                        throw new ArgumentException("Invalid year.");
                }
            }

            public HireDate(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Day:00}/{Month:00}/{Year}";
            }

            public DateTime ToDateTime()
            {
                return new DateTime(Year, Month, Day);
            }
        }
        #endregion


        #region Q3 Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions
        enum AccessLevel
        {
            Guest,
            Developer,
            Secretary,
            DBA,
            SecurityOfficer
        }

        class JobStartDate
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }

            public JobStartDate(int day, int month, int year)
            {
                Day = (day >= 1 && day <= 31) ? day : throw new ArgumentException("Invalid day");
                Month = (month >= 1 && month <= 12) ? month : throw new ArgumentException("Invalid month");
                Year = (year >= 1900 && year <= DateTime.Now.Year) ? year : throw new ArgumentException("Invalid year");
            }

            public override string ToString() => $"{Day:00}/{Month:00}/{Year}";
            public DateTime ToDateTime() => new DateTime(Year, Month, Day);
        }

        class StaffMember
        {
            public int ID { get; set; }
            public string Name { get; set; }

            private char gender;
            public char Gender
            {
                get => gender;
                set
                {
                    if (value == 'M' || value == 'F')
                        gender = value;
                    else
                        throw new ArgumentException("Gender must be 'M' or 'F'");
                }
            }

            public AccessLevel Role { get; set; }

            private decimal salary;
            public decimal Salary
            {
                get => salary;
                set
                {
                    if (value >= 0)
                        salary = value;
                    else
                        throw new ArgumentException("Salary must be non-negative.");
                }
            }

            public JobStartDate StartDate { get; set; }

            public StaffMember(int id, string name, char gender, AccessLevel role, decimal salary, JobStartDate startDate)
            {
                ID = id;
                Name = name;
                Gender = gender;
                Role = role;
                Salary = salary;
                StartDate = startDate;
            }

            public override string ToString()
            {
                return $"ID: {ID}, Name: {Name}, Gender: {Gender}, Role: {Role}, " +
                       $"Salary: {Salary:C}, Start Date: {StartDate}";
            }
            #endregion
        }
        static void Main(string[] args)
        {
            #region Q1 Design and implement a Class for the employees in a company:

            Employee emp = new Employee(1, "Alice", 'F', SecurityLevel.Developer, 8500);
            Console.WriteLine(emp);
            #endregion

            #region Q2 Develop a Class to represent the Hiring Date Data
            HireDate date = new HireDate(15, 5, 2021);
            Console.WriteLine("Hire Date: " + date);
            #endregion

            #region Q3 Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions
            StaffMember[] staffArray = new StaffMember[3];

            staffArray[0] = new StaffMember(1, "Sarah", 'F', AccessLevel.DBA, 12000m, new JobStartDate(1, 1, 2020));
            staffArray[1] = new StaffMember(2, "Mark", 'M', AccessLevel.Guest, 6000m, new JobStartDate(15, 4, 2023));
            staffArray[2] = new StaffMember(3, "Adam", 'M', AccessLevel.SecurityOfficer, 15000m, new JobStartDate(20, 8, 2018));

            Console.WriteLine("=== Staff List ===");
            foreach (var staff in staffArray)
                Console.WriteLine(staff);
            #endregion
        }
    }
}
