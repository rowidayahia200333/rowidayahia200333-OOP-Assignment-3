//namespace rowidayahia200333_OOP_Assignment_3.Refactoring.part_01;



    //shipping carrier

    public interface IShippingCarrier
    {
        string Carrier { get; }
        decimal CalculateCost(decimal weightKg);
    }


    public class AramexCarrier : IShippingCarrier
    {
        public string Carrier => "Aramex";
        public decimal CalculateCost(decimal weightKg) => weightKg * 12m;
    }

    public class FedExCarrier : IShippingCarrier
    {
        public string Carrier => "FedEx";
        public decimal CalculateCost(decimal weightKg) => weightKg * 15m;
    }

    public class DHLCarrier : IShippingCarrier
    {
        public string Carrier => "DHL";
        public decimal CalculateCost(decimal weightKg) => weightKg * 18m;
    }


    public class ShippingCostCalculator
    {
        public decimal Calculate(IShippingCarrier carrier, decimal weightKg)
        {
            if (carrier == null)
                throw new ArgumentNullException(nameof(carrier));

            return carrier.CalculateCost(weightKg);
        }
    }
	public class UPSCarrier : IShippingCarrier
	{
		public string Carrier => "UPS";
		public decimal CalculateCost(decimal weightKg) => weightKg * 18m;
	}

	//order proceccing

	public interface IOrderRepository
	{
		void Save(int orderId, DateTime processedAt);
	}

	public interface IEmailSender
	{
		void Send(string to, string body);
	}

	public class SqlOrderRepository : IOrderRepository
	{
		public void Save(int orderId, DateTime processedAt) =>
			Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
	}

	public class SmtpEmailSender : IEmailSender
	{
		public void Send(string to, string body) =>
			Console.WriteLine($"[SMTP] to={to} body={body}");
	}

	
	public class OrderProcessor
	{
		private readonly IOrderRepository _repository;
		private readonly IEmailSender _emailSender;

		public OrderProcessor(IOrderRepository repository, IEmailSender emailSender)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
		}

		public void Process(int orderId, string customerEmail)
		{
			_repository.Save(orderId, DateTime.Now);
			_emailSender.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}");
		}
	}

	//Notifications

	public interface INotificationChannel
	{
		void Send(string to, string message);
	}

	
	public class EmailChannel : INotificationChannel
	{
		public void Send(string to, string message) =>
			Console.WriteLine($"[email] {to}: {message}");
	}

	public class SmsChannel : INotificationChannel
	{
		public void Send(string to, string message) =>
			Console.WriteLine($"[sms] {to}: {message}");
	}
	public class TelegramChannel : INotificationChannel
	{
		public void Send(string to, string message)=>
			Console.WriteLine($"[telegram] {to}: {message}");
	}



	public class UrgentNotificationDecorator : INotificationChannel
	{
		private readonly INotificationChannel _channel;

		public UrgentNotificationDecorator(INotificationChannel channel)
		{
			_channel = channel ?? throw new ArgumentNullException(nameof(channel));
		}

		public void Send(string to, string message)
		{
			_channel.Send(to, $"[URGENT] {message}");
		}
	}


	public class ScheduledNotificationDecorator : INotificationChannel
	{
		private readonly INotificationChannel _channel;
		public DateTime SendAt { get; set; }

		public ScheduledNotificationDecorator(INotificationChannel channel, DateTime sendAt)
		{
			_channel = channel ?? throw new ArgumentNullException(nameof(channel));
			SendAt = sendAt;
		}

		public void Send(string to, string message)
		{
			_channel.Send(to, message);
		}
	}
