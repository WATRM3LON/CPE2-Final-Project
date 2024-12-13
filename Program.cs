using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ProjectProposal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mainmenu mainmenu = new Mainmenu();
            Appointment appointment = new Appointment();
            Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders();
            Console.Clear();
            mainmenu.PMainmenu();

        }
    }


    interface Info
    {
        string Name { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        string ContactInfo { get; set; }
        string Location { get; set; }
    }

    public abstract class Register
    {
        public abstract void Login_Register();
        public abstract void AccountRegister();
        public abstract void AccountLogin();
        public abstract void Successful();
        public abstract void Loaders();

    }
    public class Appointment : Register
    {
        public override void Login_Register() { }
        public override void AccountRegister() { }
        public override void AccountLogin() { }
        public override void Successful() { }
        public override void Loaders()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
        }
        public void CFacilityAppoinmentSchedule(string servicecategory, string service, string ServiceFacilityEmailAddress, string clientInput, string EmailAddress)
        {
            int choice, numbering = 0, Fnumbering = 0;
            Console.Clear();

            string CRAppointment = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Request Appoinment.txt");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(CRAppointment); Console.ForegroundColor = ConsoleColor.White;
            Appointment appointment = new Appointment();
            Mainmenu mainmenu = new Mainmenu();
            string timeslot = string.Empty;
            string servicefacility = string.Empty, timetols = "", timelots="", times="", nextDayTime = "";
            string readText = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Appointment.txt");
            string mites = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt");
            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string CAllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string CPendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string[] CAllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string[] CPendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");



            Console.WriteLine(mites);
            Console.WriteLine(readText);

            string content = "", contents = "", lots = "", nextDayTimeSlot = "", timestamp="", tims = "";
            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt";
            string[] timer = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt");
            string path = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Appointment.txt";
            string[] Lappointment = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Appointment.txt");

            string[] line = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt");



            do
            {
                try
                {
                    Console.SetCursorPosition(22, 3); Console.WriteLine("  ");
                    Console.SetCursorPosition(22, 3); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(70, 3); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine($"{nextDayTimeSlot} schedule is no longer available");

                    if (choice > 0 && choice < 6)
                    {
                        lots = line[choice + 1];
                        string[] lott = lots.Split("]");
                        timelots = lott[1];
                        timelots = timelots.TrimStart();
                        DateTime now = DateTime.Now;
                        bool loginSuccessful = false;
                        bool registerSucceful = false;

                        timestamp = now.ToString("yyyyMMdd_HHmmss");
                        //times = now.ToString("yyyyMMdd_HH");
                        string[] timeslots = timelots.Split(';');
                        string dayOfWeekstring = timeslots[0];
                        dayOfWeekstring.Trim();
                        DateTime currentDate = DateTime.Now;
                        DayOfWeek dayOfWeek;

                        if (Enum.TryParse(dayOfWeekstring, out dayOfWeek))
                        {
                            int daysUntilNextDay = ((int)dayOfWeek - (int)currentDate.DayOfWeek + 7) % 7;
                            DateTime nextDay = currentDate.AddDays(daysUntilNextDay);
                            nextDayTimeSlot = $"{nextDay:yyyy-MM-dd}, {dayOfWeekstring}, {timeslots[1].Trim()}";
                            //Console.WriteLine(nextDayTimeSlot);
                        }
                        for (int i = 0; i < PendingAppointments.Length; i += 8)
                        {
                            tims = PendingAppointments[i + 6];
                            string[] tim = tims.Split(":");
                            times = tim[1];
                            times = times.TrimStart();
                            string[] nd = nextDayTimeSlot.Split(":");
                            nextDayTime = nd[0];

                            if (nextDayTime == times)
                            {
                                loginSuccessful = true;
                                break;
                            }
                        }
                        for (int i = 0; i < AllAppointments.Length; i += 8)
                        {
                            tims = AllAppointments[i + 6];
                            string[] tim = tims.Split(":");
                            times = tim[1];
                            times = times.TrimStart();
                            string[] nd = nextDayTimeSlot.Split(":");
                            nextDayTime = nd[0];

                            if (nextDayTime == times)
                            {
                                loginSuccessful = true;
                                break;
                            }
                        }
                        for (int i = 0; i < CPendingAppointments.Length; i += 8)
                        {
                            tims = CPendingAppointments[i + 6];
                            string[] tim = tims.Split(":");
                            times = tim[1];
                            times = times.TrimStart();
                            string[] nd = nextDayTimeSlot.Split(":");
                            nextDayTime = nd[0];

                            if (nextDayTime == times)
                            {
                                loginSuccessful = true;
                                break;
                            }
                        }
                        for (int i = 0; i < CAllAppointments.Length; i += 8)
                        {
                            tims = CAllAppointments[i + 6];
                            string[] tim = tims.Split(":");
                            times = tim[1];
                            times = times.TrimStart();
                            string[] nd = nextDayTimeSlot.Split(":");
                            nextDayTime = nd[0];

                            if (nextDayTime == times)
                            {
                                loginSuccessful = true;
                                break;
                            }
                        }
                        if (loginSuccessful)
                        {
                            Console.SetCursorPosition(80, 3); Console.WriteLine("                                                                                 ");
                            Console.SetCursorPosition(70, 3); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{nextDayTimeSlot} schedule is no longer available"); Console.ForegroundColor = ConsoleColor.Black;
                            //Console.SetCursorPosition(70, 2); appointment.Loaders(); appointment.Loaders();
                            continue;
                        }
                        else
                        {
                            Console.SetCursorPosition(80, 3); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 5.", choice); Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        
                    }
                    Console.SetCursorPosition(80, 3); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 3); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 5.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 3); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 3); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(22, 3); Console.WriteLine("  ");
            } while (true);

            Console.Clear();
            string readTexty = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Appointment.txt");

            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(CRAppointment); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mites);
            Console.WriteLine(readTexty);

            try
            {
                

                if (choice > 0 && choice <= line.Length)
                {
                    Console.SetCursorPosition(25, 29); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(nextDayTimeSlot); Console.ForegroundColor = ConsoleColor.White;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            try
            {
                string[] lines = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Facility Profile.txt");

                if (choice > 0 && choice <= lines.Length)
                {
                    servicefacility = lines[3 - 2];
                    Console.SetCursorPosition(25, 28); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(servicefacility); Console.ForegroundColor = ConsoleColor.White;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            bool[] selectedservices = new bool[6];

            for (int nservice = 0; nservice < 3; nservice++)
            {

                do
                {
                    try
                    {
                        Console.SetCursorPosition(1 + nservice + 18, 13); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 6)
                        {
                            if (selectedservices[choice])
                            {
                                Console.SetCursorPosition(80, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} has already been selected. Please select another service.", choice);
                                Console.SetCursorPosition(1 + nservice + 18, 13); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("  ");
                                Console.ForegroundColor = ConsoleColor.Black; appointment.Loaders(); Console.SetCursorPosition(80, 13); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("{0} has already been selected. Please select another service.", choice);
                                continue;
                            }
                            selectedservices[choice] = true;
                            break;
                        }
                        Console.SetCursorPosition(80, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 5.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.ForegroundColor = ConsoleColor.Black; appointment.Loaders();
                    Console.SetCursorPosition(18, 13); Console.WriteLine("     ");
                    Console.SetCursorPosition(80, 13); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 5.", choice);
                } while (true);


                if (nservice < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(3, 23); Console.WriteLine("Add more service? ");
                    char yorn;

                    do
                    {
                        try
                        {

                            Console.SetCursorPosition(21, 23); Console.ForegroundColor = ConsoleColor.White; yorn = char.Parse(Console.ReadLine());

                            if (yorn == 'y' || yorn == 'n')
                            {
                                break;
                            }
                            Console.SetCursorPosition(80, 23); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(80, 23); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose y for yes and n for no.", yorn);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(80, 23); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(80, 23); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a char.");

                        }
                        Console.SetCursorPosition(80, 22); Console.ForegroundColor = ConsoleColor.Black; appointment.Loaders();
                        Console.SetCursorPosition(80, 23); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("{0} is not a valid choice. Please choose y for yes and n for no."); Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(21, 23); Console.WriteLine("                           ");

                    } while (true);

                    if (yorn == 'y')
                    {
                        Console.SetCursorPosition(80, 23); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("{0} is not a valid choice. Please choose y for yes and n for no.", yorn);
                        Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(3, 23); Console.WriteLine("Add more service?     ");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            double totalprice = 0, totalduration = 0;
            int x = 25;
            string serve ="";
            StringBuilder allServices = new StringBuilder();

            for (int i = 1; i < selectedservices.Length; i++)
            {
                if (selectedservices[i])
                {
                    string[] readTexts = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Services offered.txt");
                    string services = readTexts[i - 1];
                    serve += services;

                    Console.SetCursorPosition(x, 30); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(services + " | "); Console.ForegroundColor = ConsoleColor.White;
                    string Price = readTexts[i + 4];

                    double price = Convert.ToDouble(Price);
                    totalprice += price;

                    string duration = readTexts[i + 9];
                    double durats = Convert.ToDouble(duration);
                    totalduration += durats;
                    x += services.Length + 3;

                }

            }
            Console.SetCursorPosition(25, 32); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("PHP " + totalprice); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 31); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(totalduration + " mins"); Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, 34); Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 35); Console.WriteLine("   [1] Confirm Appointment");
            Console.SetCursorPosition(0, 36); Console.WriteLine("   [2] Edit Appointment");
            Console.SetCursorPosition(0, 37); Console.WriteLine("   [3] Return");

            do
            {
                try
                {
                    Console.SetCursorPosition(45, 34); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        break;
                    }
                    Console.SetCursorPosition(80, 34); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 34); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 34); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 34); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(45, 34); Console.WriteLine("  ");
            } while (true);

            string[] ClientAccoutns = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt");

            string CContactnumber = "", FContactnumber = "", FLocation ="";
            for (int i = 0; i < ClientAccoutns.Length; i += 6)
            {
                string ClientsEmailAddress = ClientAccoutns[i + 1];
                

                if (EmailAddress == ClientsEmailAddress)
                {
                    CContactnumber = ClientAccoutns[i + 3];

                    break;
                }
            }

            string[] FacilityAccount = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt");

            for (int i = 0; i < FacilityAccount.Length; i += 7)
            {
                string ServiceFacilityEmailAddresss = FacilityAccount[i + 1];
                
                if (ServiceFacilityEmailAddress == ServiceFacilityEmailAddresss)
                {
                    FContactnumber = FacilityAccount[i + 4];
                    FLocation = FacilityAccount[i + 5];
                    break;
                }
            }

            if (choice == 1)
            {
                Console.Clear();
                for (int i = 0; i <= PendingAppointments.Length; i += 8)
                {
                    numbering++;
                }
                string[] FPendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
                for (int i = 0; i <= FPendingAppointments.Length; i += 8)
                {
                    Fnumbering++;
                }

                Console.ForegroundColor = ConsoleColor.White;
                //Client Pending
                string AppendTextnumbering = numbering.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt", Environment.NewLine + "==========================================================================" + Environment.NewLine + $"{AppendTextnumbering}. [PENDING]");
                string AppendindAppId = timestamp; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt", Environment.NewLine + "\t\t  Application ID:     " + AppendindAppId + Environment.NewLine);
                string AppendTextservicefacility = servicefacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt","                Service Facility:     " + AppendTextservicefacility + Environment.NewLine);
                string AppendTextservice = service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt", "                         Service:     " + AppendTextservice + Environment.NewLine);
                string AppendTextDaynTime = nextDayTimeSlot; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt", "                    Day and Time:     " + AppendTextDaynTime + Environment.NewLine);
                string AppendTextAmount = totalprice.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt", "                      Total Cost:     PHP " + AppendTextAmount + Environment.NewLine);

                string CAppoinmentDetails = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt";

                string CfolderPath = Path.GetDirectoryName(CAppoinmentDetails);
                if (!Directory.Exists(CfolderPath))
                {
                    Directory.CreateDirectory(CfolderPath);
                }

                if (!File.Exists(CAppoinmentDetails))
                {
                    File.WriteAllText(CAppoinmentDetails, "");
                }

                string status = "PENDING";
                
                string CAppendindAppId = timestamp; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", Environment.NewLine + "\t\t\t\t\t\t\t  Appointment ID:\t" + CAppendindAppId + Environment.NewLine);
                string Cstatus = status; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", Environment.NewLine + "\t\t\t\t\t\t\t          Status:       " + Cstatus + Environment.NewLine + Environment.NewLine);
                string CAppendTextservicefacility = servicefacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\tService Facility:       " + CAppendTextservicefacility + Environment.NewLine);
                string CAppendTextservice = service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t\tCategory:       " + CAppendTextservice + Environment.NewLine);
                string CAppendTextDaynTime = nextDayTimeSlot; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t     Date & Time:       " + CAppendTextDaynTime + Environment.NewLine);
                string CAppendServices = serve; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t      Service(s):       " + CAppendServices + Environment.NewLine);
                string CAppendTextAmount = totalprice.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t  Price Estimate:       PHP " + CAppendTextAmount + Environment.NewLine + Environment.NewLine);
                string CAppendContact = FContactnumber; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t  Contact Number:       " + CAppendContact + Environment.NewLine);
                string CAppendLocation = FLocation; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t        Location:       " + CAppendLocation + Environment.NewLine);

                //Service Facility Pending
                string AppendTextFnumbering = Fnumbering.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", Environment.NewLine + "==========================================================================" + Environment.NewLine + $"{AppendTextFnumbering}. [PENDING]");
                string AppendindFAppId = timestamp; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", Environment.NewLine + "\t\t  Application ID:     " + AppendindFAppId + Environment.NewLine);
                string AppendTextFEmailAddress = EmailAddress; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", "                  Client's Email:     " + AppendTextFEmailAddress + Environment.NewLine);
                string AppendTextFservice = service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", "                         Service:     " + AppendTextFservice + Environment.NewLine);
                string AppendTextFDaynTime = nextDayTimeSlot; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", "                    Day and Time:     " + AppendTextFDaynTime + Environment.NewLine);
                string AppendTextFAmount = totalprice.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt", "                      Total Cost:     PHP " + AppendTextFAmount + Environment.NewLine);

                string FAppoinmentDetails = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt";
               
                string folderPath = Path.GetDirectoryName(FAppoinmentDetails);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!File.Exists(FAppoinmentDetails))
                {
                    File.WriteAllText(FAppoinmentDetails, "");
                }

                string FAppendindAppId = timestamp; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", Environment.NewLine + "\t\t\t\t\t\t\t  Appointment ID:\t" + FAppendindAppId + Environment.NewLine);
                string Fstatus = status; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", Environment.NewLine + "\t\t\t\t\t\t\t          Status:       " + Fstatus + Environment.NewLine + Environment.NewLine);
                string FAppendTextEmailAdd = EmailAddress; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t  Client's Email Address:       " + FAppendTextEmailAdd + Environment.NewLine);
                string FAppendContactnumber = CContactnumber; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t Client's Contact Number:       " + FAppendContactnumber + Environment.NewLine);
                string FAppendTextDaynTime = nextDayTimeSlot; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t     Date & Time:       " + FAppendTextDaynTime + Environment.NewLine);
                string FAppendServices = serve; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t      Service(s):       " + FAppendServices + Environment.NewLine);
                string FAppendTextAmount = totalprice.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {timestamp}.txt", "\t\t\t\t\t\t\t  Price Estimate:       PHP " + CAppendTextAmount + Environment.NewLine);

                appointment.CAppointmentConfirmation(nextDayTimeSlot, servicefacility, EmailAddress);
            }
            else if (choice == 2)
            {
                Console.Clear();
                appointment.CFacilityAppoinmentSchedule(servicecategory, service, ServiceFacilityEmailAddress, clientInput, EmailAddress);

            }
            else if (choice == 3)
            {
                Console.Clear();
                mainmenu.C3MainMenu(ServiceFacilityEmailAddress, servicecategory, service, clientInput, EmailAddress);


            }

        }
        public void CAppointmentConfirmation(string nextDayTimeSlot, string servicefacility, string EmailAddress)
        {
            Console.Clear();
            int choice;
            Appointment appointment = new Appointment();
            Mainmenu mainmenu = new Mainmenu();

            string readText = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Confirmation.txt");

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\n\n\n" + readText); Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\n\n\n\t\tYour appointment with {servicefacility} for Service you want has been scheduled for {nextDayTimeSlot}.\r\n\r\n\n\n\t\t\t\t\t\t\t   Thank you for using QuickConnect!");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

            do
            {
                try
                {
                    Console.SetCursorPosition(88, 21);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    choice = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;

                    if (choice == 0)
                    {
                        break;
                    }

                    Console.SetCursorPosition(53, 23);
                    Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(53, 23);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(50, 23);
                    Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(59, 23);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("INVALID INPUT. Please enter a number.");
                }

                Console.WriteLine();
                Console.SetCursorPosition(88, 21);
                Console.WriteLine("                        ");
            } while (true);

            if (choice == 0)
            {
                mainmenu.C1MainMenu(EmailAddress);
            }
            


        }
        public void CAppointmentScheduled(string EmailAddress)
        {
            Console.Clear();

            Mainmenu mainmenu = new Mainmenu();
            Appointment appointment = new Appointment();
            int choice, numbering = 0, number, number1;
            string status = "", sting = "";
            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\AllAppointments.txt");

            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
            string[] ConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string[] CompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string CompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string ConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
            string filepath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt";

            int AllAppointmentss = PendingAppointments.Length + CancelledAppointments.Length + ConfirmedAppointments.Length + CompletedAppointments.Length;
            string[] AllAppointmenter = new string[PendingAppointments.Length + ConfirmedAppointments.Length + CancelledAppointments.Length + CompletedAppointments.Length];

            for (int i = 0; i < PendingAppointments.Length; i++)
            { AllAppointmenter[i] = PendingAppointments[i]; }
            for (int i = 0; i < ConfirmedAppointments.Length; i++)
            { AllAppointmenter[i] = ConfirmedAppointments[i]; }
            for (int i = 0; i < CancelledAppointments.Length; i++)
            { AllAppointmenter[i] = CancelledAppointments[i]; }
            for (int i = 0; i < CompletedAppointments.Length; i++)
            { AllAppointmenter[i] = CompletedAppointments[i]; }

            Array.Copy(PendingAppointments, AllAppointmenter, PendingAppointments.Length);
            Array.Copy(ConfirmedAppointments, 0, AllAppointmenter, PendingAppointments.Length, ConfirmedAppointments.Length);
            Array.Copy(CancelledAppointments, 0, AllAppointmenter, PendingAppointments.Length + ConfirmedAppointments.Length, CancelledAppointments.Length);
            Array.Copy(CompletedAppointments, 0, AllAppointmenter, PendingAppointments.Length + ConfirmedAppointments.Length + CancelledAppointments.Length, CompletedAppointments.Length);
            File.WriteAllLines(filepath, AllAppointmenter);

            for (int i = 0; i < AllAppointmenter.Length; i += 8)
            {
                numbering++;
            }
            for (int i = 0; i < numbering; i++)
            {
                number = i * 8;
                number1 = number + 2;
                sting = AllAppointmenter[number1];
                string[] filet = sting.Split('.');
                status = filet[1];
                status.Trim();

                AllAppointmenter[number1] = (i + 1).ToString() + ($". {status}");

            }
            File.WriteAllLines(filepath, AllAppointmenter);

            string Headings = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string MenuAppointments = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Menu Appointment.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Headings); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(MenuAppointments);

            do
            {
                try
                {
                    Console.SetCursorPosition(100, 8); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < 7)
                    {
                        break;
                    }
                    Console.SetCursorPosition(46, 18); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(46, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 6.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(46, 18); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(58, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(100, 8); Console.WriteLine("                                ");
            } while (true);

            if (choice == 1)
            {
                Console.Clear();
                appointment.CPendingAppointments(EmailAddress);
            }
            else if (choice == 2)
            {
                Console.Clear();
                appointment.CConfirmedAppointments(EmailAddress);

            }
            else if (choice == 3)
            {
                Console.Clear();
                appointment.CCancelledAppointments(EmailAddress);

            }
            else if (choice == 4)
            {
                Console.Clear();
                appointment.CCompletedAppointments(EmailAddress);

            }
            else if (choice == 5)
            {
                Console.Clear();
                appointment.CAllAppointments(EmailAddress);

            }
            else if (choice == 6)
            {
                Console.Clear();
                mainmenu.C1MainMenu(EmailAddress);

            }
        }
        public void CAllAppointments(string EmailAddress)
        {
            int choice, numbering = 0, number, number1;
            string status = "", sting = "";
            Appointment appointment = new Appointment();
            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\AllAppointments.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
            string[] ConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string[] CompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string CompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string ConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
            string filepath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt";

            int AllAppointmentss = PendingAppointments.Length + CancelledAppointments.Length + ConfirmedAppointments.Length + CompletedAppointments.Length;
            

            if (AllAppointmentss == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tYou have no appointments scheduled yet...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        choice = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }

                        Console.SetCursorPosition(53, 20);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("INVALID INPUT. Please enter a number.");
                    }

                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17);
                    Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
            else
            {
                
                Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
                Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] View Appointment Details");
                Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return");
                Console.WriteLine(AllAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(44, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice > 0 && choice < 3)
                        {
                            Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                            break;
                        }
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(44, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 1)
                {
                    appointment.CAppointmentDetails(EmailAddress);
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    appointment.CAppointmentScheduled(EmailAddress);
                }

            }
        }
        public void CPendingAppointments(string EmailAddress)
        {
            Console.Clear();
            int choice;
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");

            string[] Heading1s = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string[] Heading2s = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");

            if (PendingAppointments.Length <= 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t     You currently have no Pending Appointments..."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
            else
            {
                Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
                Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Cancel an Appointment");
                Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return");
                Console.SetCursorPosition(0, 15); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("   Note: To reschedule an appointment, you can cancel the existing appointment and book a new one."); Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine(PendingAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(44, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice > 0 && choice < 3)
                        {
                            Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                            break;
                        }
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(44, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 1)
                {
                    appointment.CRescheduledCancelAppointment(EmailAddress);
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
        }
        public void CConfirmedAppointments(string EmailAddress)
        {
            int choice;
            string status = "CONFIRMED";
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\ConfirmedAppointments.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] ConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string ConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");

            if (ConfirmedAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t    You currently have no Confirmed Appointments...."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
            else
            {
                Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine(ConfirmedAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 11); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
        }
        public void CCancelledAppointments(string EmailAddress)
        {
            int choice;
            string status = "CANCELLED";
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\CancelledAppointments.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
            string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");

            if (CancelledAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t  There are no canceled appointments in your records...."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
            else
            {
                Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine(CancelledAppointment);
                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 11); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }

            }
        }
        public void CCompletedAppointments(string EmailAddress)
        {
            int choice, number, number1, numbering = 0;
            string status = "COMPLETED";
            int bufferHeight = Console.BufferHeight;

            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\CompletedAppointments.txt");

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] CompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string CompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string filepath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt";

            if (CompletedAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tYou have no Completed Appointments yet..."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
            else
            {
                Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine(CompletedAppointment);

                string[] CompletedAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
                for (int i = 0; i < CompletedAppointments.Length; i += 8)
                {
                    numbering++;
                }

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 11); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.CAppointmentScheduled(EmailAddress);
                }
            }
        }

        public void CRescheduledCancelAppointment(string EmailAddress)
        {
            int choice, number, number1, number2, numbering = 0, numberings = 0, Fnumberings = 0, Fnumbering = 0;
            string Lines = "", ServiceFacility = "", Service = "", DaynTime = "", TotalCost = "", REmail = "", Email = "", ServiceFac = "", ServiceFacilityEmailAddress = "", servicecategory = "", service = "", filee = "", timeslots="";

            Appointment appointment = new Appointment();

            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Cancel an Appointment");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return");
            Console.SetCursorPosition(0, 15); Console.WriteLine("   Note: To reschedule an appointment, you can cancel the existing appointment and book a new one."); Console.ForegroundColor = ConsoleColor.White;

            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
            for (int i = 0; i < PendingAppointments.Length; i += 8)
            {
                numbering++;
            }

            bool Find = false;
            string[] Accounts = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt");

            string[] read = PendingAppointment.Split(':');
            REmail = read[2];

            string[] filer = REmail.Split('\n');
            ServiceFac = filer[0];
            ServiceFac = ServiceFac.Trim();

            for (int i = 0; i < Accounts.Length; i += 7)
            {
                string ServiceFacilityName = Accounts[i + 3];

                if (ServiceFacilityName == ServiceFac)
                {
                    ServiceFacilityEmailAddress = Accounts[i + 1];
                    Find = true;
                    break;
                }
            }

            string fileName = ServiceFacilityEmailAddress + "; Facility Profile";
            string[] files = Directory.GetFiles("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES", "*.txt", SearchOption.AllDirectories);
            bool fileFound = false;

            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    string readText = File.ReadAllText(file);
                    filee = file;
                    fileFound = true;
                    break;
                }
            }


            string[] filet = filee.Split('\\');
            string readTexty = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}; Facility Profile.txt";
            servicecategory = filet[4];
            service = filet[5];

            string[] FPendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string FPendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string FCancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string[] FCancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string filePathy = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt";



            Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: ");

            do
            {
                try
                {
                    Console.SetCursorPosition(70, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(70, 11); Console.WriteLine("        ");
            } while (true);

            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Are you sure you want to cancel this appointment(y/n): "); Console.ForegroundColor = ConsoleColor.White;
            char choices;

            do
            {
                try
                {
                    Console.SetCursorPosition(55, 11); Console.ForegroundColor = ConsoleColor.Cyan; choices = char.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choices == 'y' || choices == 'n')
                    {
                        Console.SetCursorPosition(55, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose between y and n.", choices);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a letter.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(55, 11); Console.WriteLine("    ");
            } while (true);

            if (choices == 'y')
            {
                try
                {
                    //CLIENT
                    string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
                    string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
                    for (int i = 0; i <= CancelledAppointments.Length; i += 8)
                    {
                        numberings++;
                    }

                    Console.SetCursorPosition(72, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Cancelling");
                    Console.SetCursorPosition(83, 13); appointment.Loaders();
                    Console.SetCursorPosition(83, 13); Console.Write("     "); Console.SetCursorPosition(83, 13); appointment.Loaders();
                    Console.ForegroundColor = ConsoleColor.White;
                    string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt";


                    Console.Clear();

                    number = choice * 8 - 7;
                    number1 = (choice + 1) * 8 - 7;
                    number2 = (choice + 2) * 8 - 7;

                    string AppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number]);
                    string AppendNumber = numberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + AppendNumber + ". [CANCELLED by Client]");
                    string AppendAppID = timeslots; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 2]);
                    string AppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 3]);
                    string AppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 4]);
                    string AppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 5]);
                    string AppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 6] + Environment.NewLine);

                    for (int i = 1; i < numbering; i++)
                    {
                        if (number1 + 2 < PendingAppointments.Length)
                        {
                            PendingAppointments[number + 2] = PendingAppointments[number1 + 2]; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 3] = PendingAppointments[number1 + 3]; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 4] = PendingAppointments[number1 + 4]; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 5] = PendingAppointments[number1 + 5]; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 6] = PendingAppointments[number1 + 6]; File.WriteAllLines(filePath, PendingAppointments);
                        }
                        else
                        {
                            PendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                            PendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        }
                    }

                    string[] newLines = new string[PendingAppointments.Length - 8];
                    string[] newlins = new string[PendingAppointments.Length];
                    int[] lines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6 };
                    int newIndex = 0;

                    for (int j = 0; j < newlins.Length; j++)
                    {
                        try
                        {
                            if (!lines.Contains(j))
                            {
                                newLines[newIndex] = PendingAppointments[j];
                                newIndex++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }


                    }
                    File.WriteAllLines(filePath, newLines);
                    string[] PendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
                    for (int i = 0; i < numbering - 1; i++)
                    {
                        number = i * 8;
                        number1 = number + 2;

                        PendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                    }
                    File.WriteAllLines(filePath, PendingAppointmentss);

                    //SERVICE FACILITY

                    for (int i = 0; i < FPendingAppointments.Length; i += 8)
                    {
                        Fnumbering++;
                    }
                    for (int i = 0; i <= FCancelledAppointments.Length; i += 8)
                    {
                        Fnumberings++;
                    }

                    number = Fnumberings * 8 - 7;
                    number1 = (Fnumberings + 1) * 8 - 7;
                    number2 = (Fnumberings + 2) * 8 - 7;

                    string FAppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + FPendingAppointments[number]);
                    string FAppendNumber = Fnumberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + FAppendNumber + ". [CANCELLED by Client]");
                    string FAppendAppID = timeslots; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 2]);
                    string FAppendServiceFacility = EmailAddress; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + "                  Client's Email:     " + FAppendServiceFacility + Environment.NewLine);
                    string FAppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 4]);
                    string FAppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 5]);
                    string FAppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 6] + Environment.NewLine);

                    for (int i = 1; i < Fnumbering; i++)
                    {
                        if (number1 + 2 < FPendingAppointments.Length)
                        {
                            FPendingAppointments[number + 2] = FPendingAppointments[number1 + 2]; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 3] = FPendingAppointments[number1 + 3]; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 4] = FPendingAppointments[number1 + 4]; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 5] = FPendingAppointments[number1 + 5]; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 6] = FPendingAppointments[number1 + 6]; File.WriteAllLines(filePathy, FPendingAppointments);
                        }
                        else
                        {
                            FPendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                            FPendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePathy, FPendingAppointments);
                        }
                    }

                    string[] FnewLines = new string[FPendingAppointments.Length - 8];
                    string[] Fnewlins = new string[FPendingAppointments.Length];
                    int[] Flines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6 };
                    int FnewIndex = 0;

                    for (int j = 0; j < Fnewlins.Length; j++)
                    {
                        try
                        {
                            if (!Flines.Contains(j))
                            {
                                FnewLines[FnewIndex] = FPendingAppointments[j];
                                FnewIndex++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }


                    }

                    File.WriteAllLines(filePathy, FnewLines);
                    string[] FPendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");

                    for (int i = 0; i < Fnumbering - 1; i++)
                    {
                        number = i * 8;
                        number1 = number + 2;

                        FPendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                    }
                    File.WriteAllLines(filePathy, FPendingAppointmentss);

                    Console.Clear();
                    string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\My Appointments.txt");
                    string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");

                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\t\t   Your appointment has been successfully canceled."); Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                    do
                    {
                        try
                        {
                            Console.SetCursorPosition(88, 14); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                            if (choice == 0)
                            {
                                break;
                            }
                            Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(88, 14); Console.WriteLine("                                              ");
                    } while (true);

                    if (choice == 0)
                    {
                        appointment.CPendingAppointments(EmailAddress);
                    }


                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                    appointment.CPendingAppointments(EmailAddress);
                }
                
            }
            else
            {
                Console.Clear();
                appointment.CPendingAppointments(EmailAddress);
            }

        }

        public void CAppointmentDetails(string EmailAddress)
        {
            int choice, numbering=0;
            string status = "", AppId = "", ServiceFacility="", category = "", DnT = "", services = "", price = "", Contactnum = "", Location = "";

            Appointment appointment = new Appointment();
            string CAppointmentDetails = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Details.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");
            string[] CAppointmentDetail = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Details.txt");
            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt");


            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] View Appointment Details");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return"); Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < AllAppointments.Length; i += 8)
            {
                numbering++;
            }


            Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to view: ");

            do
            {
                try
                {
                    Console.SetCursorPosition(70, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.SetCursorPosition(70, 11); Console.WriteLine("        ");
            } while (true);

            status = AllAppointments[choice * 8 - 6];
            AppId = AllAppointments[choice * 8 - 5];
            string[] appid = AppId.Split(":");
            string[] stat = status.Split(".");
            status = stat[1];
            status = status.Trim();
            AppId = appid[1];
            AppId = AppId.Trim();

            string Appdetails = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {AppId}.txt");
            string[] Appdetail = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {AppId}.txt");
            
            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {AppId}.txt";

            string content = Environment.NewLine +
                             Appdetail[1] + Environment.NewLine + Environment.NewLine +
                             "\t\t\t\t\t\t\t          Status:       " + status + Environment.NewLine + Environment.NewLine +
                             Appdetail[5] + Environment.NewLine +
                             Appdetail[6] + Environment.NewLine +
                             Appdetail[7] + Environment.NewLine +
                             Appdetail[8] + Environment.NewLine +
                             Appdetail[9] + Environment.NewLine + Environment.NewLine +
                             Appdetail[11] + Environment.NewLine +
                             Appdetail[12] + Environment.NewLine;

            File.WriteAllText(filePath, content);
            string Appdetailss = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\My Appointments\\{EmailAddress}; {AppId}.txt");
            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); 
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(CAppointmentDetails); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");
            Console.WriteLine(); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Appdetailss); Console.ForegroundColor = ConsoleColor.White;
            do
            {
                try
                {
                    Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        break;
                    }
                    Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(88, 11); Console.WriteLine("                                              ");
            } while (true);

            if (choice == 0)
            {
                Console.Clear();
                appointment.CAllAppointments(EmailAddress);
            }
            
        }

        public void FAppoinmentMenu(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            Console.Clear();

            ServiceFacility serviceFacility = new ServiceFacility();
            Appointment appointment = new Appointment();
            int choice, numbering = 0, number, number1;
            string status = "", sting = "";

            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string[] ConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string[] CompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");
            string CompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");
            string ConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string filepath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt";

            int AllAppointmentss = PendingAppointments.Length + CancelledAppointments.Length + ConfirmedAppointments.Length + CompletedAppointments.Length;
            string[] AllAppointmenter = new string[PendingAppointments.Length + ConfirmedAppointments.Length + CancelledAppointments.Length + CompletedAppointments.Length];

            for (int i = 0; i < PendingAppointments.Length; i++)
            { AllAppointmenter[i] = PendingAppointments[i]; }
            for (int i = 0; i < ConfirmedAppointments.Length; i++)
            { AllAppointmenter[i] = ConfirmedAppointments[i]; }
            for (int i = 0; i < CancelledAppointments.Length; i++)
            { AllAppointmenter[i] = CancelledAppointments[i]; }
            for (int i = 0; i < CompletedAppointments.Length; i++)
            { AllAppointmenter[i] = CompletedAppointments[i]; }

            Array.Copy(PendingAppointments, AllAppointmenter, PendingAppointments.Length);
            Array.Copy(ConfirmedAppointments, 0, AllAppointmenter, PendingAppointments.Length, ConfirmedAppointments.Length);
            Array.Copy(CancelledAppointments, 0, AllAppointmenter, PendingAppointments.Length + ConfirmedAppointments.Length, CancelledAppointments.Length);
            Array.Copy(CompletedAppointments, 0, AllAppointmenter, PendingAppointments.Length + ConfirmedAppointments.Length + CancelledAppointments.Length, CompletedAppointments.Length);
            File.WriteAllLines(filepath, AllAppointmenter);
            for (int i = 0; i < AllAppointmenter.Length; i += 8)
            {
                numbering++;
            }
            for (int i = 0; i < numbering; i++)
            {
                number = i * 8;
                number1 = number + 2;
                sting = AllAppointmenter[number1];
                string[] filet = sting.Split('.');
                status = filet[1];
                status.Trim();

                AllAppointmenter[number1] = (i + 1).ToString() + ($". {status}");

            }
            File.WriteAllLines(filepath, AllAppointmenter);

            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Menu.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            do
            {
                try
                {
                    Console.SetCursorPosition(100, 8); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < 7)
                    {
                        break;
                    }
                    Console.SetCursorPosition(46, 18); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(46, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 6.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(46, 18); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(58, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(100, 8); Console.WriteLine("                                ");
            } while (true);

            if (choice == 1)
            {
                Console.Clear();
                appointment.FPendingAppointments(servicecategory, service, ServiceFacilityEmailAddress);
            }
            else if (choice == 2)
            {
                Console.Clear();
                appointment.FConfirmedAppointments(servicecategory, service, ServiceFacilityEmailAddress);

            }
            else if (choice == 3)
            {
                Console.Clear();
                appointment.FCancelledAppointments(servicecategory, service, ServiceFacilityEmailAddress);

            }
            else if (choice == 4)
            {
                Console.Clear();
                appointment.FCompletedAppointments(servicecategory, service, ServiceFacilityEmailAddress);

            }
            else if (choice == 5)
            {
                Console.Clear();
                appointment.FAllAppointments(servicecategory, service, ServiceFacilityEmailAddress);

            }
            else if (choice == 6)
            {
                Console.Clear();
                serviceFacility.FacilityProfile(servicecategory, service, ServiceFacilityEmailAddress);

            }
        }
        public void FAllAppointments(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice;
            Appointment appointment = new Appointment();
            string Heading1 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\AllAppointments.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;
            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");


            if (AllAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tYou have no appointments scheduled yet..."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
            else
            {

                Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
                Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] View Appointment Details");
                Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return"); Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(); Console.WriteLine(AllAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(44, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice > 0 && choice < 3)
                        {
                            Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                            break;
                        }
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(44, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 1)
                {
                    //Console.Clear();
                    appointment.FAppointmentDetails(servicecategory, service, ServiceFacilityEmailAddress);
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
        }
        public void FPendingAppointments(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice;
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");


            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;


            if (PendingAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t     You currently have no Pending Appointments..."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
            else
            {

                Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Please select one of the following options: ");
                Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Confirm an Appointment");
                Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Reject an Appointment");
                Console.SetCursorPosition(0, 14); Console.WriteLine("   [3] Return");

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(PendingAppointment);
                do
                {
                    try
                    {
                        Console.SetCursorPosition(44, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice > 0 && choice < 4)
                        {
                            Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                            break;
                        }
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(44, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 1)
                {
                    appointment.FConfirmAppointment(servicecategory, service, ServiceFacilityEmailAddress);
                }
                else if (choice == 2)
                {
                    appointment.FRejectAppointment(servicecategory, service, ServiceFacilityEmailAddress);
                }
                else
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }

            }
        }

        public void FConfirmedAppointments(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice;

            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\ConfirmedAppointments.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] ConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string ConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");

            if (ConfirmedAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t    You currently have no Confirmed Appointments...."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
            else
            {
                Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
                Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Complete/Finish an Appointment");
                Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return");

                Console.WriteLine(ConfirmedAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(44, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice > 0 && choice < 3)
                        {
                            Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                            break;
                        }
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(44, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 1)
                {
                    appointment.FCompleteAppointment(servicecategory, service, ServiceFacilityEmailAddress);
                }
                else if (choice == 2)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }

            }
        }
        public void FCancelledAppointments(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice;
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\CancelledAppointments.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] CancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string CancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");


            if (CancelledAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t  There are no canceled appointments in your records...."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
            else
            {

                Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(CancelledAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
        }
        public void FCompletedAppointments(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice;
            Appointment appointment = new Appointment();

            string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
            string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\CompletedAppointments.txt");

            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

            string[] CompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");
            string CompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");


            if (CompletedAppointments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tYou have no Completed Appointments yet..."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 17); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 17); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
            else
            {

                Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(CompletedAppointment);

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 11); Console.WriteLine("                        ");
                } while (true);

                if (choice == 0)
                {
                    appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                }
            }
        }

        public void FConfirmAppointment(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice, number, number1, number2, numbering = 0, numberings = 0, Cnumberings = 0, Cnumbering = 0;
            string Lines = "", ServiceFacility = "", Service = "", DaynTime = "", TotalCost = "", EmailAddress = "", REmailAddress = "", AppId="";

            Appointment appointment = new Appointment();

            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Confirm an Appointment");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Reject an Appointment");
            Console.SetCursorPosition(0, 14); Console.WriteLine("   [3] Return");
            Console.ForegroundColor = ConsoleColor.White;

            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string FConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string[] FConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt";

            string[] file = PendingAppointment.Split(':');
            for (int i = 0; i < PendingAppointments.Length; i += 8)
            {
                numbering++;
            }

            REmailAddress = file[2];
            string[] filer = REmailAddress.Split('\n');
            EmailAddress = filer[0];
            EmailAddress = EmailAddress.Trim();

            Console.SetCursorPosition(0, 11); Console.Write("Please select the number of the appointment you would like to"); Console.ForegroundColor = ConsoleColor.Green; Console.Write(" CONFIRM"); Console.ForegroundColor = ConsoleColor.White; Console.Write(":");

            do
            {
                try
                {
                    Console.SetCursorPosition(71, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("    ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(71, 11); Console.WriteLine("      ");
            } while (true);

            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Are you sure you want to CONFIRM this appointment(y/n): "); Console.ForegroundColor = ConsoleColor.White;
            char choices;

            do
            {
                try
                {
                    Console.SetCursorPosition(56, 11); Console.ForegroundColor = ConsoleColor.Cyan; choices = char.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choices == 'y' || choices == 'n')
                    {
                        Console.SetCursorPosition(55, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose between y and n.", choices);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a letter.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(56, 11); Console.WriteLine("    ");
            } while (true);

            if (choices == 'y')
            {
                //SERVICE FACILITY

                Console.SetCursorPosition(72, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("CONFIRMING");
                Console.SetCursorPosition(83, 13); appointment.Loaders();
                Console.SetCursorPosition(83, 13); Console.Write("     "); Console.SetCursorPosition(83, 13); appointment.Loaders(); Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                for (int i = 0; i <= FConfirmedAppointments.Length; i += 8)
                {
                    numberings++;
                }

                number = choice * 8 - 7;
                number1 = (choice + 1) * 8 - 7;
                number2 = (choice + 2) * 8 - 7;

                string AppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number]);
                string AppendNumber = numberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + AppendNumber + ". [CONFIRMED]");
                string AppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number + 2]);
                string AppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number + 3]);
                string AppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number + 4]);
                string AppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number + 5]);
                string AppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt", Environment.NewLine + PendingAppointments[number + 6] + Environment.NewLine);

                EmailAddress = PendingAppointments[number + 2 + 1];
                string[] emailadd = EmailAddress.Split(":");
                EmailAddress = emailadd[1];
                EmailAddress = EmailAddress.Trim();
                for (int i = 1; i < numbering; i++)
                {
                    if (number1 + 2 < PendingAppointments.Length)
                    {
                        PendingAppointments[number + 2] = PendingAppointments[number1 + 2]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 3] = PendingAppointments[number1 + 3]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 4] = PendingAppointments[number1 + 4]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 5] = PendingAppointments[number1 + 5]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 6] = PendingAppointments[number1 + 6]; File.WriteAllLines(filePath, PendingAppointments);
                    }
                    else
                    {
                        PendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                    }
                }

                string[] newLines = new string[PendingAppointments.Length - 8];
                string[] newlins = new string[PendingAppointments.Length];
                int[] lines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6};
                int newIndex = 0;

                for (int j = 0; j < newlins.Length; j++)
                {
                    try
                    {
                        if (!lines.Contains(j))
                        {
                            newLines[newIndex] = PendingAppointments[j];
                            newIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }


                }

                File.WriteAllLines(filePath, newLines);
                string[] PendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");

                for (int i = 0; i < numbering - 1; i++)
                {
                    number = i * 8;
                    number1 = number + 2;

                    PendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                }
                File.WriteAllLines(filePath, PendingAppointmentss);

                //CLIENTS

                string[] CPendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
                string CPendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
                string[] CConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
                string CConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
                string filePathy = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt";

                for (int i = 0; i < CPendingAppointments.Length; i += 8)
                {
                    Cnumbering++;
                }
                for (int i = 0; i <= CConfirmedAppointments.Length; i += 8)
                {
                    Cnumberings++;
                }

                number = Cnumbering * 8 - 7;
                number1 = (Cnumbering + 1) * 8 - 7;
                number2 = (Cnumbering + 2) * 8 - 7;

                string CAppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number]);
                string CAppendNumber = Cnumberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CAppendNumber + ". [CONFIRMED]");
                string CAppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number + 2]);
                string CAppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number + 3]);
                string CAppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number + 4]);
                string CAppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number + 5]);
                string CAppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt", Environment.NewLine + CPendingAppointments[number + 6] + Environment.NewLine);

                for (int i = 1; i < Cnumbering; i++)
                {
                    if (number1 + 2 < CPendingAppointments.Length)
                    {
                        CPendingAppointments[number + 2] = CPendingAppointments[number1 + 2]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 3] = CPendingAppointments[number1 + 3]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 4] = CPendingAppointments[number1 + 4]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 5] = CPendingAppointments[number1 + 5]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 6] = CPendingAppointments[number1 + 6]; File.WriteAllLines(filePathy, CPendingAppointments);
                    }
                    else
                    {
                        CPendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                    }
                }

                string[] CNLines = new string[CPendingAppointments.Length - 8];
                string[] Cnewlins = new string[CPendingAppointments.Length];
                int[] Clines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6 };
                int CnewIndex = 0;

                for (int j = 0; j < Cnewlins.Length; j++)
                {
                    try
                    {
                        if (!Clines.Contains(j))
                        {
                            CNLines[CnewIndex] = CPendingAppointments[j];
                            CnewIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }

                }

                File.WriteAllLines(filePathy, CNLines);
                string[] CPendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");

                for (int i = 0; i < Cnumbering - 1; i++)
                {
                    number = i * 8;
                    number1 = number + 2;

                    CPendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                }
                File.WriteAllLines(filePathy, CPendingAppointmentss);

                Console.Clear();
                string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
                string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");

                Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\t\t   The appointment has been successfully confirmed."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 14); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 14); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    Console.Clear();
                    appointment.FPendingAppointments(servicecategory, service, ServiceFacilityEmailAddress);
                }

            }
            else
            {
                Console.Clear();
                appointment.FPendingAppointments(servicecategory, service, ServiceFacilityEmailAddress);
            }

        }
        public void FRejectAppointment(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice, number, number1, number2, numbering = 0, numberings = 0, Cnumberings = 0, Cnumbering = 0;
            string Lines = "", ServiceFacility = "", Service = "", DaynTime = "", TotalCost = "", EmailAddress = "", REmailAddress = "", AppId="";

            Appointment appointment = new Appointment();

            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Confirm an Appointment");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Reject an Appointment");
            Console.SetCursorPosition(0, 14); Console.WriteLine("   [3] Return");
            Console.ForegroundColor = ConsoleColor.White;

            string[] PendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string PendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");
            string FCancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string[] FCancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt");
            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt";

            string[] file = PendingAppointment.Split(':');
            for (int i = 0; i < PendingAppointments.Length; i += 8)
            {
                numbering++;
            }

            REmailAddress = file[2];
            string[] filer = REmailAddress.Split('\n');
            EmailAddress = filer[0];
            EmailAddress = EmailAddress.Trim();


            Console.SetCursorPosition(0, 11); Console.Write("Please select the number of the appointment you would like to"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write(" REJECT"); Console.ForegroundColor = ConsoleColor.White; Console.Write(":");

            do
            {
                try
                {
                    Console.SetCursorPosition(71, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("    ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(71, 11); Console.WriteLine("      ");
            } while (true);

            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Are you sure you want to REJECT this appointment(y/n): "); Console.ForegroundColor = ConsoleColor.White;
            char choices;

            do
            {
                try
                {
                    Console.SetCursorPosition(56, 11); Console.ForegroundColor = ConsoleColor.Cyan; choices = char.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choices == 'y' || choices == 'n')
                    {
                        Console.SetCursorPosition(55, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose between y and n.", choices);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a letter.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(56, 11); Console.WriteLine("    ");
            } while (true);

            if (choices == 'y')
            {
                //SERVICE FACILITY

                Console.SetCursorPosition(72, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("CANCELLING");
                Console.SetCursorPosition(83, 13); appointment.Loaders();
                Console.SetCursorPosition(83, 13); Console.Write("     "); Console.SetCursorPosition(83, 13); appointment.Loaders(); Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                for (int i = 0; i <= FCancelledAppointments.Length; i += 8)
                {
                    numberings++;
                }

                number = choice * 8 - 7;
                number1 = (choice + 1) * 8 - 7;
                number2 = (choice + 2) * 8 - 7;

                string AppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number]);
                string AppendNumber = numberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + AppendNumber + ". [CANCELLED by Facility]");
                string AppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 2]);
                string AppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 3]);
                string AppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 4]);
                string AppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 5]);
                string AppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt", Environment.NewLine + PendingAppointments[number + 6] + Environment.NewLine);

                EmailAddress = PendingAppointments[number + 2 + 1];
                string[] emailadd = EmailAddress.Split(":");
                EmailAddress = emailadd[1];
                EmailAddress = EmailAddress.Trim();

                for (int i = 1; i < numbering; i++)
                {
                    if (number1 + 2 < PendingAppointments.Length)
                    {
                        PendingAppointments[number + 2] = PendingAppointments[number1 + 2]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 3] = PendingAppointments[number1 + 3]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 4] = PendingAppointments[number1 + 4]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 5] = PendingAppointments[number1 + 5]; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 6] = PendingAppointments[number1 + 6]; File.WriteAllLines(filePath, PendingAppointments);
                    }
                
                    else
                    {
                        PendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                        PendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePath, PendingAppointments);
                    }
                }

                string[] newLines = new string[PendingAppointments.Length - 8];
                string[] newlins = new string[PendingAppointments.Length];
                int[] lines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6};
                int newIndex = 0;

                for (int j = 0; j < newlins.Length; j++)
                {
                    try
                    {
                        if (!lines.Contains(j))
                        {
                            newLines[newIndex] = PendingAppointments[j];
                            newIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }


                }

                File.WriteAllLines(filePath, newLines);
                string[] PendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt");

                for (int i = 0; i < numbering - 1; i++)
                {
                    number = i * 7;
                    number1 = number + 2;

                    PendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";
                }
                File.WriteAllLines(filePath, PendingAppointmentss);

                //CLIENTS


                string[] CPendingAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
                string CPendingAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");
                string[] CCancelledAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
                string CCancelledAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt");
                string filePathy = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt";

                for (int i = 0; i < CPendingAppointments.Length; i += 8)
                {
                    Cnumbering++;
                }
                for (int i = 0; i <= CCancelledAppointments.Length; i += 8)
                {
                    Cnumberings++;
                }

                number = Cnumbering * 8 - 7;
                number1 = (Cnumbering + 1) * 8 - 7;
                number2 = (Cnumbering + 2) * 8 - 7;

                string CAppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number]);
                string CAppendNumber = Cnumberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CAppendNumber + ". [CANCELLED by Facility]");
                string CAppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number + 2]);
                string CAppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number + 3]);
                string CAppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number + 4]);
                string CAppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number + 5]);
                string CAppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt", Environment.NewLine + CPendingAppointments[number + 6] + Environment.NewLine);

                for (int i = 1; i < Cnumbering; i++)
                {
                    if (number1 + 2 < CPendingAppointments.Length)
                    {
                        CPendingAppointments[number + 2] = CPendingAppointments[number1 + 2]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 3] = CPendingAppointments[number1 + 3]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 4] = CPendingAppointments[number1 + 4]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 5] = CPendingAppointments[number1 + 5]; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 6] = CPendingAppointments[number1 + 6]; File.WriteAllLines(filePathy, CPendingAppointments);
                    }
                    else
                    {
                        CPendingAppointments[number] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                        CPendingAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePathy, CPendingAppointments);
                    }
                }

                string[] CNLines = new string[CPendingAppointments.Length - 6];
                string[] Cnewlins = new string[CPendingAppointments.Length];
                int[] Clines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6};
                int CnewIndex = 0;

                for (int j = 0; j < Cnewlins.Length; j++)
                {
                    try
                    {
                        if (!Clines.Contains(j))
                        {
                            CNLines[CnewIndex] = CPendingAppointments[j];
                            CnewIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }

                }

                File.WriteAllLines(filePathy, CNLines);
                string[] CPendingAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt");

                for (int i = 0; i < Cnumbering - 1; i++)
                {
                    number = i * 8;
                    number1 = number + 2;

                    CPendingAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                }
                File.WriteAllLines(filePathy, CPendingAppointmentss);

                Console.Clear();
                string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
                string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\PAppoinments.txt");

                Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\t\t   The appointment has been successfully cancelled."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 14); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 14); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    Console.Clear();
                    appointment.FPendingAppointments(servicecategory, service, ServiceFacilityEmailAddress);
                }

            }
            else
            {
                Console.Clear();
                appointment.FPendingAppointments(servicecategory, service, ServiceFacilityEmailAddress);
            }
        }
        public void FCompleteAppointment(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice, number, number1, number2, numbering = 0, numberings = 0, Cnumberings = 0, Cnumbering = 0;
            string Lines = "", ServiceFacility = "", Service = "", DaynTime = "", TotalCost = "", EmailAddress = "", REmailAddress = "", AppId = "";

            Appointment appointment = new Appointment();

            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] Complete/Finish an Appointment");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return");
            Console.ForegroundColor = ConsoleColor.White;

            string[] FConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string FConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");
            string FCompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");
            string[] FCompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt");
            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt";

            string[] file = FConfirmedAppointment.Split(':');
            for (int i = 0; i < FConfirmedAppointments.Length; i += 8)
            {
                numbering++;
            }

            REmailAddress = file[1];
            string[] filer = REmailAddress.Split('\n');
            EmailAddress = filer[0];
            EmailAddress = EmailAddress.Trim();

            string[] CConfirmedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string CConfirmedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");
            string[] CCompletedAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string CCompletedAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt");
            string filePathy = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt";

            Console.SetCursorPosition(0, 11); Console.Write("Please select the number of the appointment you would like to"); Console.ForegroundColor = ConsoleColor.Green; Console.Write(" COMPLETE"); Console.ForegroundColor = ConsoleColor.White; Console.Write(":");

            do
            {
                try
                {
                    Console.SetCursorPosition(72, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("    ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(72, 11); Console.WriteLine("      ");
            } while (true);

            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Are you sure you want to COMPLETE this appointment(y/n): "); Console.ForegroundColor = ConsoleColor.White;
            char choices;

            do
            {
                try
                {
                    Console.SetCursorPosition(57, 11); Console.ForegroundColor = ConsoleColor.Cyan; choices = char.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choices == 'y' || choices == 'n')
                    {
                        Console.SetCursorPosition(55, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose between y and n.", choices);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a letter.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(57, 11); Console.WriteLine("    ");
            } while (true);

            if (choices == 'y')
            {
                //SERVICE FACILITY

                Console.SetCursorPosition(72, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("COMPLETING");
                Console.SetCursorPosition(83, 13); appointment.Loaders();
                Console.SetCursorPosition(83, 13); Console.Write("     "); Console.SetCursorPosition(83, 13); appointment.Loaders(); Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                for (int i = 0; i <= FCompletedAppointments.Length; i += 8)
                {
                    numberings++;
                }

                number = choice * 8 - 7;
                number1 = (choice + 1) * 8 - 7;
                number2 = (choice + 2) * 8 - 7;

                string AppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number]);
                string AppendNumber = numberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + AppendNumber + ". [COMPLETED]");
                string AppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number + 2]);
                string AppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number + 3]);
                string AppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number + 4]);
                string AppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number + 5]);
                string AppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt", Environment.NewLine + FConfirmedAppointments[number + 6] + Environment.NewLine);

                for (int i = 1; i < numbering; i++)
                {
                    if (number1 + 2 < FConfirmedAppointments.Length)
                    {
                        FConfirmedAppointments[number + 2] = FConfirmedAppointments[number1 + 2]; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 3] = FConfirmedAppointments[number1 + 3]; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 4] = FConfirmedAppointments[number1 + 4]; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 5] = FConfirmedAppointments[number1 + 5]; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 6] = FConfirmedAppointments[number1 + 6]; File.WriteAllLines(filePath, FConfirmedAppointments);
                    }
                    else
                    {
                        FConfirmedAppointments[number] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                        FConfirmedAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePath, FConfirmedAppointments);
                    }
                }

                string[] newLines = new string[FConfirmedAppointments.Length - 6];
                string[] newlins = new string[FConfirmedAppointments.Length];
                int[] lines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5 , number1 + 5 };
                int newIndex = 0;

                for (int j = 0; j < newlins.Length; j++)
                {
                    try
                    {
                        if (!lines.Contains(j))
                        {
                            newLines[newIndex] = FConfirmedAppointments[j];
                            newIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }


                }

                File.WriteAllLines(filePath, newLines);
                string[] FConfirmedAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt");

                for (int i = 0; i < numbering - 1; i++)
                {
                    number = i * 8;
                    number1 = number + 2;

                    FConfirmedAppointmentss[number1] = (i + 1).ToString() + ". [CONFIRMED]";

                }
                File.WriteAllLines(filePath, FConfirmedAppointmentss);

                //CLIENTS
                for (int i = 0; i < CConfirmedAppointments.Length; i += 8)
                {
                    Cnumbering++;
                }
                for (int i = 0; i <= CCompletedAppointments.Length; i += 8)
                {
                    Cnumberings++;
                }

                number = choice * 8 - 7;
                number1 = (choice + 1) * 8 - 7;
                number2 = (choice + 2) * 8 - 7;

                string CAppendLines = Lines; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number]);
                string CAppendNumber = Cnumberings.ToString(); File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CAppendNumber + ". [COMPLETED]");
                string CAppendServiceFacility = ServiceFacility; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number + 2]);
                string CAppendAppId = AppId; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number + 3]);
                string CAppendService = Service; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number + 4]);
                string CAppendDaynTime = DaynTime; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number + 5]);
                string CAppendTotalCost = TotalCost; File.AppendAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt", Environment.NewLine + CConfirmedAppointments[number + 6] + Environment.NewLine);

                for (int i = 1; i < Cnumbering; i++)
                {
                    if (number1 + 2 < CConfirmedAppointments.Length)
                    {
                        CConfirmedAppointments[number + 2] = CConfirmedAppointments[number1 + 2]; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 3] = CConfirmedAppointments[number1 + 3]; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 4] = CConfirmedAppointments[number1 + 4]; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 5] = CConfirmedAppointments[number1 + 5]; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 6] = CConfirmedAppointments[number1 + 6]; File.WriteAllLines(filePathy, CConfirmedAppointments);
                    }
                    else
                    {
                        CConfirmedAppointments[number] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 1] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 2] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 3] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 4] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 5] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                        CConfirmedAppointments[number + 6] = Environment.NewLine; File.WriteAllLines(filePathy, CConfirmedAppointments);
                    }
                }

                string[] CNLines = new string[CConfirmedAppointments.Length - 8];
                string[] Cnewlins = new string[CConfirmedAppointments.Length];
                int[] Clines = new int[] { number1 - 1, number1, number1 + 1, number1 + 2, number1 + 3, number1 + 4, number1 + 5, number1 + 6 };
                int CnewIndex = 0;

                for (int j = 0; j < Cnewlins.Length; j++)
                {
                    try
                    {
                        if (!Clines.Contains(j))
                        {
                            CNLines[CnewIndex] = CConfirmedAppointments[j];
                            CnewIndex++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }

                }

                File.WriteAllLines(filePathy, CNLines);
                string[] CConfirmedAppointmentss = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt");

                for (int i = 0; i < Cnumbering - 1; i++)
                {
                    number = i * 8;
                    number1 = number + 2;

                    CConfirmedAppointmentss[number1] = (i + 1).ToString() + ". [PENDING]";

                }
                File.WriteAllLines(filePathy, CConfirmedAppointmentss);

                Console.Clear();
                string Heading1 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Dashboard.txt");
                string Heading2 = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\ConfirmedAppointments.txt");

                Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(Heading1); Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(Heading2); Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, 11); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\t\t   The appointment has been successfully completed."); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t[Press 0 to Return...]");

                do
                {
                    try
                    {
                        Console.SetCursorPosition(88, 14); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                        if (choice == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(53, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(53, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(50, 20); Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(59, 20); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(88, 14); Console.WriteLine("                                              ");
                } while (true);

                if (choice == 0)
                {
                    Console.Clear();
                    appointment.FConfirmedAppointments(servicecategory, service, ServiceFacilityEmailAddress);
                }

            }
            else
            {
                Console.Clear();
                appointment.FConfirmedAppointments(servicecategory, service, ServiceFacilityEmailAddress);
            }

        }
        public void FAppointmentDetails(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            int choice, numbering = 0;
            string status = "", AppId = "", ServiceFacility = "", category = "", DnT = "", services = "", price = "", Contactnum = "", Location = "", EmailAddress="";

            Appointment appointment = new Appointment();
            string CAppointmentDetails = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Details.txt");
            string AllAppointment = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");
            string[] CAppointmentDetail = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment Details.txt");
            string[] AllAppointments = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt");


            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(0, 12); Console.WriteLine("   [1] View Appointment Details");
            Console.SetCursorPosition(0, 13); Console.WriteLine("   [2] Return"); Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < AllAppointments.Length; i += 8)
            {
                numbering++;
            }


            Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to view: ");

            do
            {
                try
                {
                    Console.SetCursorPosition(70, 11); Console.ForegroundColor = ConsoleColor.Cyan; choice = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.White;

                    if (choice > 0 && choice < numbering + 1)
                    {
                        Console.SetCursorPosition(70, 11); Console.WriteLine("      ");
                        Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                        break;
                    }
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {numbering}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 11); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }

                Console.SetCursorPosition(70, 11); Console.WriteLine("        ");
            } while (true);

            status = AllAppointments[choice * 8 - 6];
            AppId = AllAppointments[choice * 8 - 5];
            EmailAddress = AllAppointments[choice * 8 - 4];
            string[] appid = AppId.Split(":");
            string[] stat = status.Split(".");
            string[] emailadd = EmailAddress.Split(":");
            status = stat[1];
            status = status.Trim();
            AppId = appid[1];
            AppId = AppId.Trim();
            EmailAddress = emailadd[1];
            EmailAddress = EmailAddress.Trim();

            string Appdetails = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {AppId}.txt");
            string[] Appdetail = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {AppId}.txt");

            string filePath = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {AppId}.txt";

            string content = Environment.NewLine +
                             Appdetail[1] + Environment.NewLine + Environment.NewLine +
                             "\t\t\t\t\t\t\t          Status:       " + status + Environment.NewLine + Environment.NewLine +
                             Appdetail[5] + Environment.NewLine +
                             Appdetail[6] + Environment.NewLine +
                             Appdetail[7] + Environment.NewLine +
                             Appdetail[8] + Environment.NewLine +
                             Appdetail[9] + Environment.NewLine + Environment.NewLine;

            File.WriteAllText(filePath, content);
            string Appdetailss = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\Client Appointments\\{EmailAddress}; {AppId}.txt");
            Console.SetCursorPosition(80, 11); Console.WriteLine("                                                                      ");
            Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(0, 11); Console.WriteLine("Please select the number of the appointment you would like to cancel: "); Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(CAppointmentDetails); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 11); Console.WriteLine("\t\t\t\t\t\t\t\t[Press 0 to Return...]");
            Console.WriteLine(); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(Appdetailss); Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(CancelledAppointment);
            do
            {
                try
                {
                    Console.SetCursorPosition(88, 11); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        break;
                    }
                    Console.SetCursorPosition(53, 13); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(53, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose 0 to Return.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(50, 13); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(59, 13); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(88, 11); Console.WriteLine("                                              ");
            } while (true);

            if (choice == 0)
            {
                Console.Clear();
                appointment.FAllAppointments(servicecategory, service, ServiceFacilityEmailAddress);
            }

        }


    }

    public class Mainmenu : Register
    {
        string clientInput, service;

        public override void Login_Register()
        {

        }
        public override void AccountRegister()
        {

        }
        public override void AccountLogin()
        {

        }
        public override void Successful()
        {

        }
        public override void Loaders()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
        }

        public void PMainmenu()
        {
            Console.Clear();
            int choice;
            Console.ForegroundColor = ConsoleColor.White;

            string readText = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\QuickConnect.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(readText); Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.SetCursorPosition(68, 13); Console.WriteLine("Welcome to QuickConnect");
            Console.SetCursorPosition(65, 14); Console.WriteLine("Your Service Facility Locator");

            Console.WriteLine(); Console.WriteLine();
            Console.SetCursorPosition(58, 19); Console.WriteLine("Please select one of the following options: ");
            Console.SetCursorPosition(70, 20); Console.WriteLine("[1] Client");
            Console.SetCursorPosition(70, 21); Console.WriteLine("[2] Service Facility");
            Console.SetCursorPosition(70, 22); Console.WriteLine("[3] Exit");


            do
            {
                try
                {
                    Console.SetCursorPosition(102, 19); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        break;
                    }
                    Console.SetCursorPosition(49, 32); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(49, 32); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(49, 32); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(62, 32); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(102, 19); Console.WriteLine("  ");
            } while (true);

            Mainmenu mainmenu = new Mainmenu();

            if (choice == 1)
            {
                Console.Clear();
                Client client = new Client();
                client.Login_Register();
            }
            else if (choice == 2)
            {
                Console.Clear();
                ServiceFacility facility = new ServiceFacility();
                facility.Login_Register();

            }
            else if (choice == 3)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 15); Console.WriteLine(readText);
                Console.SetCursorPosition(50, 15); Console.WriteLine("  ");
            }
        }

        public void C1MainMenu(string EmailAddress)
        {
            Mainmenu mainmenu = new Mainmenu();
            Appointment appointment = new Appointment();
            Console.Clear();
            string C1Menu = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Service Selection.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(C1Menu); Console.ForegroundColor = ConsoleColor.White;

            string readText = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\FACILITIES.txt");
            Console.WriteLine(readText);

            do
            {
                Console.ForegroundColor = ConsoleColor.White; Console.SetCursorPosition(107, 6); clientInput = Console.ReadLine().ToUpper();

                var services = new Dictionary<string, string>
               {
                    { "1A", "Barbershops ; Hair Salons" }, { "1B", "Nail Salons" }, { "1C", "Spa & Massage Centers" }, { "1D", "Tattoo and Piercing Parlors" },
                    { "2A", "Animal Clinics"}, { "2B", "Dentists"},
                    { "3A", "Appliance Repair"}, { "3B", "Car ; Motorcycle Repair Shops"}, { "3C", "Electronics Repair"},
                    { "4A", "Funeral Homes"}, { "4B", "Tailoring Services"},
                    { "5A", "Appointment"}, { "5B", "Exit"}
               };

                if (services.TryGetValue(clientInput, out service))
                {
                    Console.SetCursorPosition(49, 40); Console.WriteLine("                                                                          ");
                    if (clientInput == "6B" || clientInput == "6A")
                    {
                        Console.SetCursorPosition(73, 40); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Loading");
                        Console.SetCursorPosition(81, 40); mainmenu.Loaders();
                        Console.SetCursorPosition(81, 40); Console.Write("     "); Console.SetCursorPosition(81, 40); mainmenu.Loaders();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(72, 40); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Searching");
                        Console.SetCursorPosition(81, 40); mainmenu.Loaders();
                        Console.SetCursorPosition(81, 40); Console.Write("     "); Console.SetCursorPosition(81, 40); mainmenu.Loaders();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                }

                Console.SetCursorPosition(49, 40); Console.WriteLine("                                                                           ");
                Console.SetCursorPosition(55, 40); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("INVALID INPUT. Please enter a number and a letter.");
                Console.SetCursorPosition(107, 6); Console.WriteLine("     ");
            } while (true);

            if (clientInput == "5B")
            {
                mainmenu.PMainmenu();
            }
            else if (clientInput == "5A")
            {
                appointment.CAppointmentScheduled(EmailAddress);
            }
            else
            {
                Console.Clear();
                mainmenu.C2MainMenu(service, clientInput, EmailAddress);
            }
        }

        public void C2MainMenu(string service, string clientInput, string EmailAddress)
        {
            int choice;
            string servicecategory;
            Mainmenu mainmenu = new Mainmenu();
            Console.Clear();

            string C2Menu = File.ReadAllText(@"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Service Facility Profiles.txt");
            Console.Title = C2Menu;

            if (clientInput == "1A" || clientInput == "1B" || clientInput == "1C" || clientInput == "1D") { servicecategory = "Personal Care & Beauty"; }
            else if (clientInput == "2A" || clientInput == "2B") { servicecategory = "Health & Medical Services"; }
            else if (clientInput == "3A" || clientInput == "3B" || clientInput == "3C") { servicecategory = "Repair & Technical Services"; }
            else { servicecategory = "Miscellaneous Services"; }

            string fileName = service;

            string[] files = Directory.GetFiles("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES", "*.txt", SearchOption.AllDirectories);
            bool fileFound = false;
            string[] liner = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\Emails.txt");

            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine($"Please choose the service facility (1-{liner.Length}, 0 to Return): "); Console.ForegroundColor = ConsoleColor.White;

            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    string readText = File.ReadAllText(file);
                    Console.WriteLine(readText);
                    fileFound = true;
                    break;
                }
            }

            if (!fileFound)
            {
                Console.WriteLine("No matching file found for the selected service.");
            }

            do
            {
                try
                {
                    Console.SetCursorPosition(56, 0); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice >= 0 && choice < liner.Length + 1)
                    {
                        break;
                    }
                    Console.SetCursorPosition(80, 0); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 0); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 0 and {liner.Length}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(80, 0); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(80, 0); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(56, 0); Console.WriteLine("    ");
            } while (true);

            if (choice == 0)
            {
                mainmenu.C1MainMenu(EmailAddress);
            }
            else
            {
                Console.Clear();
                string ServiceFacilityEmailAddress = liner[choice - 1];
                mainmenu.C3MainMenu(ServiceFacilityEmailAddress, servicecategory, service, clientInput, EmailAddress);
            }
        }
        public void C3MainMenu(string ServiceFacilityEmailAddress, string servicecategory, string service, string clientInput, string EmailAddress)
        {
            Appointment appointment = new Appointment();
            Mainmenu mainmenu = new Mainmenu();
            Console.Clear();
            string C3Menu = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\TFacility Profile.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(C3Menu); Console.ForegroundColor = ConsoleColor.White;

            int choice;

                try
                {
                    string readText = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Facility Profile.txt");
                    Console.WriteLine(readText);
                    Console.SetCursorPosition(0, 42); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Please choose an option: "); Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 43); Console.WriteLine("     1. Book an Appointment");
                    Console.SetCursorPosition(0, 44); Console.WriteLine("     2. Return");

                    do
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 42); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                break;
                            }
                            Console.SetCursorPosition(0, 46); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(0, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(0, 46); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(0, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(25, 42); Console.WriteLine("  ");
                    } while (true);

                    if (choice == 1)
                    {
                        appointment.CFacilityAppoinmentSchedule(servicecategory, service, ServiceFacilityEmailAddress, clientInput, EmailAddress);
                    }
                    else
                    {
                        mainmenu.C2MainMenu(service, clientInput, EmailAddress);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("This Service Facility is no longer available"); Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders(); mainmenu.Loaders(); Console.ForegroundColor = ConsoleColor.White;
                    mainmenu.C2MainMenu(service, clientInput, EmailAddress);
                }
            
            
        }
    }
    public class Client : Register, Info
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }

        public int choice;

        Mainmenu mainmenu = new Mainmenu();

        public override void Loaders()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
        }

        public override void Login_Register()
        {
            Client clients = new Client();
            Console.Clear();
            string CLoginRegister = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Client LoginRegister.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n\n" + CLoginRegister); Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(66, 15); Console.WriteLine("Please choose an option: ");
            Console.SetCursorPosition(66, 17); Console.WriteLine("     [1] Log In");
            Console.SetCursorPosition(66, 18); Console.WriteLine("     [2] Register");
            Console.SetCursorPosition(66, 19); Console.WriteLine("     [3] Exit");

            do
            {
                try
                {
                    Console.SetCursorPosition(91, 15); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        break;
                    }
                    Console.SetCursorPosition(49, 25); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(49, 25); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(49, 25); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(62, 25); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(90, 15); Console.WriteLine("  ");
            } while (true);

            if (choice == 1)
            {
                clients.AccountLogin();
            }
            else if (choice == 2)
            {
                clients.AccountRegister();
            }
            else
            {
                mainmenu.PMainmenu();
            }

        }

        public override void AccountRegister()
        {
            Client clients = new Client();
            Console.Clear();
            string CRegister = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Client Register.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n" + CRegister); Console.ForegroundColor = ConsoleColor.White;
            
            Console.SetCursorPosition(50, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("CLIENT INFORMATION");
            Console.SetCursorPosition(56, 17); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Enter Name: ");
            Console.SetCursorPosition(56, 18); Console.WriteLine("Enter Email Address: ");
            Console.SetCursorPosition(56, 19); Console.WriteLine("Enter Password: ");
            Console.SetCursorPosition(56, 20); Console.WriteLine("Enter Contact Number: ");
            Console.SetCursorPosition(56, 21); Console.WriteLine("Enter Location: ");


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(83, 17); string Name = Console.ReadLine();
            string AppendTextName = Name; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt", AppendTextName + Environment.NewLine);

            Console.SetCursorPosition(83, 18); string EmailAddress = Console.ReadLine();
            string AppendTextEmailAdd = EmailAddress; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt", AppendTextEmailAdd + Environment.NewLine);

            Console.SetCursorPosition(83, 19); string Password = Console.ReadLine();
            string AppendTextPassword = Password; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt", AppendTextPassword + Environment.NewLine);

            Console.SetCursorPosition(83, 20); double ContactNumber = double.Parse(Console.ReadLine());
            string AppendTextContactNumber = ContactNumber.ToString(); File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt", AppendTextContactNumber + Environment.NewLine);

            Console.SetCursorPosition(83, 21); string Location = Console.ReadLine();
            string AppendTextLocation = Location; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt", AppendTextLocation + Environment.NewLine + Environment.NewLine);

            Directory.CreateDirectory($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}");

            string AllAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\All Appointments.txt";
            string CAllAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; All Appointments.txt";
            string MenuAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Menu Appointments.txt";
            string CMenuAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Menu Appointment.txt";
            string PendingAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Pending Appointments.txt";
            string CPendingAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Pending Appointments.txt";
            string ConfirmedAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Confirmed Appointments.txt";
            string CConfirmedAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Confirmed Appointments.txt";
            string CancelledAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Cancelled Appointments.txt";
            string CCancelledAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Cancelled Appointments.txt";
            string CompletedAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Completed Appointments.txt";
            string CCompletedAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\{EmailAddress}\\{EmailAddress}; Completed Appointments.txt";

            File.Copy(AllAppointments, CAllAppointments, true);
            File.Copy(MenuAppointments, CMenuAppointments, true);
            File.Copy(PendingAppointments, CPendingAppointments, true);
            File.Copy(ConfirmedAppointments, CConfirmedAppointments, true);
            File.Copy(CancelledAppointments, CCancelledAppointments, true);
            File.Copy(CompletedAppointments, CCompletedAppointments, true);

            clients.Successful();
            mainmenu.C1MainMenu(EmailAddress);
        }

        public override void AccountLogin()
        {
            int choice;
            Client load = new Client(); Console.Clear();

            do
            {
                string CLogin = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Client Login.txt");
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n" + CLogin); Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(58, 12); Console.Write("Enter email address: ");
                Console.SetCursorPosition(58, 13); Console.Write("Enter password: ");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.SetCursorPosition(82, 12); string EmailAddress = Console.ReadLine();
                Console.SetCursorPosition(82, 13); string Password = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.White;

                bool loginSuccessful = false;
                string[] lines = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\CLIENTS ACCOUNT.txt");

                for (int i = 0; i < lines.Length; i += 6)
                {
                    string ClientsEmailAddress = lines[i + 1];
                    string ClientsPassword = lines[i + 2];

                    if (EmailAddress == ClientsEmailAddress && Password == ClientsPassword)
                    {
                        loginSuccessful = true;
                        break;
                    }
                }

                if (loginSuccessful)
                {
                    Console.SetCursorPosition(71, 18); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Login successful!"); Console.ForegroundColor = ConsoleColor.White; load.Loaders();
                    mainmenu.C1MainMenu(EmailAddress);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(67, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Invalid email or password."); Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(64, 22); Console.WriteLine("Please choose: ");
                    Console.SetCursorPosition(72, 24); Console.WriteLine("1. Continue");
                    Console.SetCursorPosition(72, 25); Console.WriteLine("2. Exit");

                    do
                    {
                        try
                        {
                            Console.SetCursorPosition(81, 22); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                break;
                            }
                            Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(49, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(62, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(81, 22); Console.WriteLine("  ");

                    } while (true);

                    if (choice == 1)
                    {
                        load.AccountLogin();
                        break;
                    }
                    else if (choice == 2)
                    {
                        load.Login_Register();
                        break;
                    }
                }

            } while (true);

        }

        public override void Successful()
        {
            Client load = new Client();
            Console.Clear();
            Console.SetCursorPosition(68, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Register Successful!!");
            Console.ForegroundColor = ConsoleColor.Black; load.Loaders();

            Console.SetCursorPosition(45, 17); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Please wait as we locate the service facilities near your location");

            Console.SetCursorPosition(72, 20); Console.WriteLine("Searching");

            Console.SetCursorPosition(81, 20); load.Loaders();
            Console.SetCursorPosition(81, 20); Console.Write("     "); Console.SetCursorPosition(81, 20); load.Loaders();

            mainmenu.C1MainMenu(EmailAddress);
        }

    }

    public class ServiceFacility : Register, Info
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }
        private string servicecategory { get; set; }
        private string service { get; set; }

        Mainmenu mainmenu = new Mainmenu();

        public override void Loaders()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
        }

        public override void Login_Register()
        {
            int choice;
            ServiceFacility serviceFacility = new ServiceFacility();

            Console.Clear();

            string FLoginRegister = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Service Facility LoginRegister.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n" + FLoginRegister); Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(66, 15); Console.WriteLine("Please choose an option: ");
            Console.SetCursorPosition(66, 17); Console.WriteLine("     [1] Log In");
            Console.SetCursorPosition(66, 18); Console.WriteLine("     [2] Register");
            Console.SetCursorPosition(66, 19); Console.WriteLine("     [3] Exit");

            do
            {
                try
                {
                    Console.SetCursorPosition(91, 15); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        break;
                    }
                    Console.SetCursorPosition(49, 25); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(49, 25); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(49, 25); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(62, 25); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(90, 15); Console.WriteLine("  ");
            } while (true);

            if (choice == 1)
            {
                serviceFacility.AccountLogin();
            }
            else if (choice == 2)
            {
                serviceFacility.AccountRegister();
            }
            else
            {
                mainmenu.PMainmenu();
            }
        }

        public override void AccountRegister()
        {
            int choice, choice1;
            string servicecategory, service, services, servicecombo, fileread, Facilityname;
            ServiceFacility serviceFacility = new ServiceFacility();
            string readText = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\Service Category.txt");
            Console.Clear();

            string FRegister = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Service Facility Register.txt");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n" + FRegister); Console.ForegroundColor = ConsoleColor.White; ;

            Console.SetCursorPosition(50, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("SERVICE FACILITY INFORMATION");
            Console.SetCursorPosition(56, 17); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Enter Name: ");
            Console.SetCursorPosition(56, 18); Console.WriteLine("Enter Email Address: ");
            Console.SetCursorPosition(56, 19); Console.WriteLine("Enter Password: ");
            Console.SetCursorPosition(56, 20); Console.WriteLine("Facility Name: ");
            Console.SetCursorPosition(56, 21); Console.WriteLine("Enter Contact Number: ");
            Console.SetCursorPosition(56, 22); Console.WriteLine("Enter Location: ");
            Console.SetCursorPosition(56, 23); Console.WriteLine("Services: ");
            Console.SetCursorPosition(56, 24); Console.WriteLine("Service Category: ");


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(83, 17); string Name = Console.ReadLine();
            string AppendTextName = Name; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendTextName + Environment.NewLine);

            Console.SetCursorPosition(83, 18); string EmailAddress = Console.ReadLine();
            string AppendTextEmailAdd = EmailAddress; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendTextEmailAdd + Environment.NewLine);

            Console.SetCursorPosition(83, 19); string Password = Console.ReadLine();
            string AppendTextPassword = Password; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendTextPassword + Environment.NewLine);

            Console.SetCursorPosition(83, 20); string facname = Console.ReadLine();
            string AppendFaiclityname = facname; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendFaiclityname + Environment.NewLine);

            Console.SetCursorPosition(83, 21); double ContactNumber = double.Parse(Console.ReadLine());
            string AppendTextContactNumber = ContactNumber.ToString(); File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendTextContactNumber + Environment.NewLine);

            Console.SetCursorPosition(83, 22); string Location = Console.ReadLine();
            string AppendTextLocation = Location; File.AppendAllText("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt", AppendTextLocation + Environment.NewLine + Environment.NewLine);

            Console.SetCursorPosition(65, 36); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Please choose an option: "); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(readText); Console.ForegroundColor = ConsoleColor.White;
            do
            {
                try
                {
                    Console.SetCursorPosition(90, 36); Console.ForegroundColor = ConsoleColor.White; choice1 = int.Parse(Console.ReadLine());

                    if (choice1 > 0 && choice1 < 6)
                    {
                        if (choice1 == 1) { servicecategory = "Personal Care & Beauty"; }
                        else if (choice1 == 2) { servicecategory = "Health & Medical Services"; }
                        else if (choice1 == 3) { servicecategory = "Repair & Technical Services"; }
                        else if (choice1 == 4) { servicecategory = "Food & Beverages Services"; }
                        else { servicecategory = "Miscellaneous Services"; }

                        break;
                    }
                    Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(49, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 5.", choice1);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(62, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(90, 36); Console.WriteLine("  ");
            } while (true);
            Console.ForegroundColor = ConsoleColor.Cyan; Console.SetCursorPosition(83, 23); Console.WriteLine($"{servicecategory}"); Console.ForegroundColor = ConsoleColor.White;

            string fileName = servicecategory;

            string[] files = Directory.GetFiles("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES", "*.txt", SearchOption.AllDirectories);
            bool fileFound = false;
            string[] liner = File.ReadAllLines($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{servicecategory}.txt");

            Console.SetCursorPosition(65, 36); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please choose an option: "); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine(readText); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(65, 36); Console.WriteLine("Please choose an option: ");
            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    fileread = File.ReadAllText(file);
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(fileread); Console.ForegroundColor = ConsoleColor.White;
                    fileFound = true;
                    break;
                }
            }

            if (!fileFound)
            {
                Console.WriteLine("No matching file found for the selected service.");
            }

            do
            {
                try
                {
                    Console.SetCursorPosition(90, 36); Console.WriteLine("  ");
                    Console.SetCursorPosition(90, 36); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < liner.Length)
                    {
                        if (choice == 1) { servicecombo = $"{choice1}A"; }
                        else if (choice == 2) { servicecombo = $"{choice1}B"; }
                        else if (choice == 3) { servicecombo = $"{choice1}C"; }
                        else { servicecombo = $"{choice1}D"; }

                        //Console.WriteLine($"{servicecombo}");
                        var serviced = new Dictionary<string, string>
                        {
                            { "1A", "Barbershops ; Hair Salons" }, { "1B", "Nail Salons" }, { "1C", "Spa & Massage Centers" }, { "1D", "Tattoo and Piercing Parlors" },
                            { "2A", "Animal Clinics"}, { "2B", "Dentists"}, { "2C", "Hospitals"}, { "2D", "Laboratories"},
                            { "3A", "Appliance Repair"}, { "3B", "Car / Motorcycle Repair Shops"}, { "3C", "Electronics Repair"},
                            { "4A", "Cafes & Coffee Shops and Bakeries"}, { "4B", "Restaurants"}, { "4C", "Supermarkets"},
                            { "5A", "Funeral Homes"}, { "5B", "Hotels / Motels"}, { "5C", "Laundry Shops / Tailoring Services"},
                        };

                        if (serviced.TryGetValue(servicecombo, out service))
                        {
                            break;
                        }
                        //break;
                    }
                    Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(49, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{choice} is not a valid choice. Please choose a number between 1 and {liner.Length - 1}.");
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                    Console.SetCursorPosition(62, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                }
                Console.WriteLine();
                Console.SetCursorPosition(90, 36); Console.WriteLine("  ");
            } while (true);
            Console.SetCursorPosition(90, 36); Console.WriteLine("  ");
            Console.SetCursorPosition(65, 36); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Please choose an option: ");
            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    fileread = File.ReadAllText(file);
                    Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine(fileread); Console.ForegroundColor = ConsoleColor.White;
                    fileFound = true;
                    break;
                }
            }
            Console.SetCursorPosition(83, 24); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"{service}"); Console.ForegroundColor = ConsoleColor.White;

            ServiceFacility serviceFacility1 = new ServiceFacility();
            Console.ForegroundColor = ConsoleColor.Black; serviceFacility1.Loaders(); serviceFacility1.Loaders(); Console.ForegroundColor = ConsoleColor.White;
            serviceFacility.Successful();
            serviceFacility.FacilityProfileFormat(servicecategory, service, EmailAddress, ContactNumber);

        }

        public override void AccountLogin()
        {
            int choice;

            ServiceFacility load = new ServiceFacility(); Console.Clear();
            do
            {
                string FLogin = File.ReadAllText("D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Service Facility Login.txt");
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n" + FLogin); Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(58, 12); Console.Write("Enter email address: ");
                Console.SetCursorPosition(58, 13); Console.Write("Enter password: ");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.SetCursorPosition(82, 12); string EmailAddress = Console.ReadLine();
                Console.SetCursorPosition(82, 13); string Password = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.White;

                bool loginSuccessful = false;
                string[] lines = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt");

                for (int i = 0; i < lines.Length; i += 7)
                {
                    string ServiceFacilityEmailAddress = lines[i + 1];
                    string ServiceFacilityPassword = lines[i + 2];

                    if (EmailAddress == ServiceFacilityEmailAddress && Password == ServiceFacilityPassword)
                    {
                        loginSuccessful = true;
                        break;
                    }
                }

                if (loginSuccessful)
                {
                    Console.SetCursorPosition(71, 18); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Login successful!"); Console.ForegroundColor = ConsoleColor.White; load.Loaders();
                    load.FacilityProfile(servicecategory, service, EmailAddress);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(67, 18); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Invalid email or password."); Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(64, 22); Console.WriteLine("Please choose: ");
                    Console.SetCursorPosition(72, 24); Console.WriteLine("1. Continue");
                    Console.SetCursorPosition(72, 25); Console.WriteLine("2. Exit");

                    do
                    {
                        try
                        {
                            Console.SetCursorPosition(81, 22); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                break;
                            }
                            Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(49, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 2.", choice);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(49, 30); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(62, 30); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(81, 22); Console.WriteLine("  ");


                    } while (true);

                    if (choice == 1)
                    {
                        load.AccountLogin();
                        break;
                    }
                    else if (choice == 2)
                    {
                        load.Login_Register();
                        break;
                    }
                }

            } while (true);

        }

        public override void Successful()
        {
            Client load = new Client();
            Console.Clear();
            Console.SetCursorPosition(69, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Register Successful!!");
            Console.ForegroundColor = ConsoleColor.Black; load.Loaders();

            Console.SetCursorPosition(52, 17); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Please wait as we prepare your service facility profile");

            Console.SetCursorPosition(73, 20); Console.WriteLine("Creating");

            Console.SetCursorPosition(82, 20); load.Loaders();
            Console.SetCursorPosition(82, 20); Console.Write("     "); Console.SetCursorPosition(82, 20); load.Loaders();

            ServiceFacility serviceFacility = new ServiceFacility();

        }


        public void FacilityProfile(string servicecategory, string service, string ServiceFacilityEmailAddress)
        {
            Mainmenu mainmenu = new Mainmenu();
            Appointment appointment = new Appointment();
            ServiceFacility serviceFacility = new ServiceFacility();
            Console.Clear();
            int choice;
            string filee = "";

            try
            {
                string fileName = ServiceFacilityEmailAddress + "; Facility Profile";
                string[] files = Directory.GetFiles("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES", "*.txt", SearchOption.AllDirectories);
                bool fileFound = false;

                foreach (string file in files)
                {
                    if (Path.GetFileNameWithoutExtension(file).Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        string readText = File.ReadAllText(file);
                        Console.WriteLine(readText);
                        filee = file;
                        fileFound = true;
                        break;
                    }
                }


                string[] filet = filee.Split('\\');
                string readTexty = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}; Facility Profile.txt";
                servicecategory = filet[4];
                service = filet[5];

                if (fileFound == true)
                {

                    Console.SetCursorPosition(0, 41); Console.WriteLine("Please choose an option: ");
                    Console.SetCursorPosition(0, 42); Console.WriteLine("     [1]  Go to Appointment");
                    Console.SetCursorPosition(0, 43); Console.WriteLine("     [2]  Delete Account");
                    Console.SetCursorPosition(0, 44); Console.WriteLine("     [3]  Logout Account");

                    do
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 41); Console.ForegroundColor = ConsoleColor.White; choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 4)
                            {
                                break;
                            }
                            Console.SetCursorPosition(0, 46); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(0, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose a number between 1 and 3.", choice);
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(0, 46); Console.WriteLine("                                                                      ");
                            Console.SetCursorPosition(0, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a number.");

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(25, 41); Console.WriteLine("  ");
                    } while (true);

                    if (choice == 1)
                    {
                        appointment.FAppoinmentMenu(servicecategory, service, ServiceFacilityEmailAddress);
                    }
                    else if (choice == 3)
                    {
                        mainmenu.PMainmenu();

                    }
                    else
                    {
                        Console.SetCursorPosition(25, 41); Console.WriteLine("  ");
                        Console.SetCursorPosition(0, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Are you sure you want to delete this account(y/n): "); Console.ForegroundColor = ConsoleColor.White;
                        char choices;
                        do
                        {
                            try
                            {
                                Console.SetCursorPosition(51, 46); Console.ForegroundColor = ConsoleColor.White; choices = char.Parse(Console.ReadLine());

                                if (choices == 'y' || choices == 'n')
                                {
                                    Console.SetCursorPosition(25, 41); Console.WriteLine("  ");
                                    break;
                                }
                                Console.SetCursorPosition(80, 46); Console.WriteLine("                                                                      ");
                                Console.SetCursorPosition(80, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("{0} is not a valid choice. Please choose between y and n.", choices);
                            }
                            catch (FormatException)
                            {
                                Console.SetCursorPosition(80, 46); Console.WriteLine("                                                                      ");
                                Console.SetCursorPosition(80, 46); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("INVALID INPUT. Please enter a letter.");

                            }
                            Console.WriteLine();
                            Console.SetCursorPosition(51, 46); Console.WriteLine("  ");
                        } while (true);

                        if (choices == 'y')
                        {
                            string filerName = ServiceFacilityEmailAddress + "; Facility Profile";
                            string[] file = Directory.GetFiles("D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES", "*.txt", SearchOption.AllDirectories);
                            bool filerFound = false;

                            foreach (string filer in files)
                            {
                                if (Path.GetFileNameWithoutExtension(filer).Equals(filerName, StringComparison.OrdinalIgnoreCase))
                                {
                                    string readText = File.ReadAllText(filer);
                                    using (var Streamreader = File.OpenRead(filer)) { }
                                    fileFound = true;
                                    File.Delete(filer);

                                    mainmenu.PMainmenu();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            serviceFacility.FacilityProfile(servicecategory, service, ServiceFacilityEmailAddress);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This Service Facility is no longer available"); Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders(); mainmenu.Loaders(); Console.ForegroundColor = ConsoleColor.White;
                    mainmenu.PMainmenu();
                }

            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("This Service Facility is no longer available"); Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders(); mainmenu.Loaders(); Console.ForegroundColor = ConsoleColor.White;
                mainmenu.PMainmenu();
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("This Service Facility is no longer available"); Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders(); mainmenu.Loaders(); Console.ForegroundColor = ConsoleColor.White;
                mainmenu.PMainmenu();
            }
        }

        public void FacilityProfileFormat(string servicecategory, string service, string ServiceFacilityEmailAddress, double ContactNumber)
        {
            Console.Clear();
            string location = "", ContactNum = "";

            Directory.CreateDirectory($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}");

            string readText = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}; Facility Profile.txt";

            string AllAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\All Appointments.txt";
            string FAllAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; All Appointments.txt";
            string MenuAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Menu Appointments.txt";
            string FMenuAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Menu Appointment.txt";
            string PendingAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Pending Appointments.txt";
            string FPendingAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Pending Appointments.txt";
            string ConfirmedAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Confirmed Appointments.txt";
            string FConfirmedAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Confirmed Appointments.txt";
            string CancelledAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Cancelled Appointments.txt";
            string FCancelledAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Cancelled Appointments.txt";
            string CompletedAppointments = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\CLIENTS\\Completed Appointments.txt";
            string FCompletedAppointments = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Completed Appointments.txt";
            string Appointment = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Appointment.txt";
            string ServicesOffred = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Services offered.txt";
            string Timeslots = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Time Slots.txt";
            string FAppointment = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Appointment.txt";
            string FServicesOffred = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Services offered.txt";
            string FTimeslots = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt";

            File.Copy(AllAppointments, FAllAppointments, true);
            File.Copy(MenuAppointments, FMenuAppointments, true);
            File.Copy(PendingAppointments, FPendingAppointments, true);
            File.Copy(ConfirmedAppointments, FConfirmedAppointments, true);
            File.Copy(CancelledAppointments, FCancelledAppointments, true);
            File.Copy(CompletedAppointments, FCompletedAppointments, true);
            File.Copy(Appointment, FAppointment, true);
            File.Copy(ServicesOffred, FServicesOffred, true);
            File.Copy(Timeslots, FTimeslots, true);
            using (var Streamwriter = File.Create(readText)) { }
            string copyfile = "D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\Facility Profile.txt";
            string readTexty = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Facility Profile.txt";
            File.Copy(copyfile, readTexty, true);

            Console.Write(readTexty);
            Mainmenu mainmenu = new Mainmenu();

            string[] lines = File.ReadAllLines("D:\\CPE261_PROJECT PROPOSAL\\Accounts\\SERVICE FACILITIES ACCOUNT.txt");
            for (int i = 0; i < lines.Length; i += 7)
            {
                ContactNum = lines[i + 3];
                location = lines[i + 5];

            }

            Console.Clear();
            string mites = File.ReadAllText($"D:\\CPE261_PROJECT PROPOSAL\\Filers\\FILES\\Profile setup.txt");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(mites); Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Your Facility Name: ");
            string facilityName = Console.ReadLine();

            Console.Write("Enter Business Hours (e.g., 9 AM - 6 PM, Monday to Sunday): ");
            string businessHours = Console.ReadLine();

            Console.Write("Enter Facility Rating (e.g., 4.5): ");
            string rating = Console.ReadLine();

            Console.WriteLine("\nServices Offered:");
            Console.WriteLine("Enter details for services. Type 'done' to stop adding services.");

            string servicesOffered = "Service Name\t\t\tDescription\t\t\t\t\t\tPrice (PHP)\t\tDuration\n";
            int serviceNumber = 1;

            while (true)
            {
                Console.Write($"[{serviceNumber}] Enter Service Name: ");
                string serviceName = Console.ReadLine();
                if (serviceName.ToLower() == "done") break;

                Console.Write("   Enter Description: ");
                string description = Console.ReadLine();

                Console.Write("   Enter Price (PHP): ");
                string price = Console.ReadLine();

                Console.Write("   Enter Duration (e.g., 30 mins): ");
                string duration = Console.ReadLine();

                servicesOffered += $"[{serviceNumber}] {serviceName}\t\t\t{description}\t\t\tPHP {price}\t\t{duration}\n";
                serviceNumber++;
            }
            Console.WriteLine("\nContact Information:");

            string profileContent = $@"
{facilityName}

    Service Category:    {service}	
    Business Hours:      {businessHours}
    Ratings:             {rating}

Services Offered

    {servicesOffered}

Contact Information

    Phone Number:   {ContactNum}
    Email Address:  {ServiceFacilityEmailAddress}
    Website:        www.{facilityName.ToLower().Trim()}.com
    Social Media:   Facebook, Instagram

Location

    {location}
                                        ";

            File.WriteAllText(readTexty, profileContent);

            Console.Clear();
            Console.SetCursorPosition(69, 13); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Register Successful!!");
            Console.ForegroundColor = ConsoleColor.Black; mainmenu.Loaders();

            Console.SetCursorPosition(52, 17); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Please wait as we prepare your service facility profile");

            Console.SetCursorPosition(73, 20); Console.WriteLine("Creating");

            Console.SetCursorPosition(82, 20); mainmenu.Loaders();
            Console.SetCursorPosition(82, 20); Console.Write("     "); Console.SetCursorPosition(82, 20); mainmenu.Loaders();


            ServiceFacility serviceFacility = new ServiceFacility();
            mainmenu.PMainmenu();
            serviceFacility.FacilityProfile(servicecategory, service, ServiceFacilityEmailAddress);

        }
        
        public static void CheckAndGenerateTimeSlots(string servicecategory, string service, string ServiceFacilityEmailAddress, double ContactNumber)
        {
            ServiceFacility serviceFacility = new ServiceFacility();
            string FTimeslots = $"D:\\CPE261_PROJECT PROPOSAL\\Filers\\SERVICE FACILITIES\\{servicecategory}\\{service}\\{ServiceFacilityEmailAddress}\\{ServiceFacilityEmailAddress}; Time Slots.txt";

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

                string[] timeRanges =
                {
                "9:00 AM - 10:00 AM",
                "10:00 AM - 11:00 AM",
                "11:00 AM - 12:00 PM",
                "1:00 PM - 2:00 PM",
                "2:00 PM - 3:00 PM",
                "3:00 PM - 4:00 PM",
                "4:00 PM - 5:00 PM"
            };
                Random random = new Random();
                HashSet<string> uniqueSlots = new HashSet<string>();

                while (uniqueSlots.Count < 5)
                {
                    string day = days[random.Next(days.Length)];
                    string time = timeRanges[random.Next(timeRanges.Length)];

                    string timeSlot = $"{day}; {time}";

                    uniqueSlots.Add(timeSlot);
                }
                File.WriteAllLines(FTimeslots, new List<string>(uniqueSlots));

            }
            else
            {
                serviceFacility.FacilityProfile(servicecategory, service, ServiceFacilityEmailAddress);
            }

            serviceFacility.FacilityProfile(servicecategory, service, ServiceFacilityEmailAddress);
        }
    }
}
