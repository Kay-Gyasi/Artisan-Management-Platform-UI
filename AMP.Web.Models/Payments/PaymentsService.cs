using AMP.Web.Models.Commands;
using AMP.Web.Models.Services.HttpServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayStack.Net;
using System;
using System.Threading.Tasks;

namespace AMP.Web.Models.Payments
{
    // TODO:: If error occurs in production check if from ILogger injection
    public class PaymentsService : IPaymentService
    {
        public const string VerifySuccessMessage = "success";
        public const string InvalidAmount = "Invalid Amount Sent";
        private readonly IConfiguration _configuration;
        private readonly ILogger<PaymentsService> _logger;
        private readonly PaymentService _paymentService;

        private PayStackApi PayStack { get; }

        public PaymentsService(IConfiguration configuration, ILogger<PaymentsService> logger, PaymentService paymentService)
        {
            _configuration = configuration;
            _logger = logger;
            _paymentService = paymentService;
            var secretKey = configuration["PaystackTest:SecretKey"];
            //var secretKey = configuration["PaystackLive:SecretKey"];
            PayStack = new PayStackApi(secretKey);
        }

        public async Task<string> InitializeTransaction(PaymentCommand command, string email)
        {
            var request = new TransactionInitializeRequest
            {
                AmountInKobo = Convert.ToInt32(command.AmountPaid * 100), // converting to GHS
                TransactionCharge = 1, // review
                Email = email,
                Reference = Generate().ToString(),
                Currency = "GHS",
                CallbackUrl = $"{_configuration["LiveCallbackUrl"]}/{command.OrderId}"
                //CallbackUrl = $"{_configuration["DevCallbackUrl"]}/{command.OrderId}"
            };

            var response = PayStack.Transactions.Initialize(request);
            if (!response.Status)
            {
                _logger.LogError(response.Message);
                return response.Message;
            }

            // Save to database
            command.Reference = response.Data.Reference;
            var savePayment = await _paymentService.Save(command);
            return savePayment.IsComplete ? response.Data.AuthorizationUrl : savePayment.Message;
        }

        public async Task<string> VerifyTransaction(VerifyPaymentCommand command)
        {
            var response = PayStack.Transactions.Verify(command.Reference);
            if (response.Data.Status != "success")
            {
                _logger.LogError(response.Data.GatewayResponse);
                return response.Data.GatewayResponse;
            }
            var request = await _paymentService.Verify(command);
            return request.IsComplete ? "success" : request.Message;
        }

        private static int Generate()
        {
            var rand = new Random((int)DateTime.UtcNow.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}