
using System;
using rowidayahia200333_OOP_Assignment_3.Refactoring;

namespace rowidayahia200333_OOP_Assignment_3.Refactoring
{
    internal class program
    {
        static void Main(string[] args)
        {
            //IShippingCarrier aramex = new AramexCarrier();
            //IShippingCarrier fedex = new FedExCarrier();
            //IShippingCarrier ups = new UPSCarrier(); 

            //Console.WriteLine($"Aramex Cost: {aramex.CalculateCost(2m)}");
            //Console.WriteLine($"FedEx Cost: {fedex.CalculateCost(2m)}");
            //Console.WriteLine($"UPS Cost: {ups.CalculateCost(2m)}");
            //Console.WriteLine();


            //IOrderRepository repo = new SqlOrderRepository();
            //IEmailSender emailSender = new SmtpEmailSender();
            //OrderProcessor processor = new OrderProcessor(repo, emailSender);
            //processor.Process(1001, "customer@example.com");
            //Console.WriteLine();


            //INotificationChannel email = new EmailChannel();
            //INotificationChannel urgentScheduledEmail = new ScheduledNotificationDecorator(
            //    new UrgentNotificationDecorator(email),
            //    DateTime.Today.AddHours(18)
            //);

            //urgentScheduledEmail.Send("customer@example.com", "Your order ships tomorrow");


            //INotificationChannel telegram = new ScheduledNotificationDecorator(
            //    new UrgentNotificationDecorator(new TelegramChannel()),
            //    DateTime.Now
            //);
            //telegram.Send("@rowida_user", "Your package is ready!");


            //part2

            //var enrollmentFacade = new StudentEnrollmentFacade();
            //enrollmentFacade.EnrollStudent("S123", "CS101", 500m);


            //part3

            Console.WriteLine("=== Blocked users ===");
            const int blockedCount = 50_000;
            const int requestCount = 5_000;
            var blockedIds = BlockedUserChecker.BuildBlockedIds(blockedCount);
            var requestIds = BlockedUserChecker.BuildRequestIds(requestCount, blockedCount);
            var ms = BlockedUserChecker.MeasureMs(blockedIds, requestIds, out var found);
            Console.WriteLine($"blockedIds={blockedCount}, requests={requestCount}, found={found}, time={ms} ms");
            Console.WriteLine();

            Console.WriteLine("=== Students (1_000_000) ===");
            var printed = 0;
            foreach (var student in StudentCatalog.GetAllStudents())
            {
                Console.WriteLine($"{student.Id}: {student.Name}");
                printed++;
                if (printed == 3)
                    break;
            }
            Console.WriteLine($"printed={printed}");
        }


    }
}
