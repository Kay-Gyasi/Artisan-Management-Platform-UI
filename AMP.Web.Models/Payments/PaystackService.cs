using System;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.Extensions;
using Microsoft.Extensions.Configuration;
using PayStack.Net;

namespace AMP.Web.Models.Payments
{
    public class PaystackService
    {
        private readonly IConfiguration _configuration;
        private readonly string _secretKey;

        private PayStackApi PayStack { get; set; }

        public PaystackService(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretKey = _configuration["PaystackTest:SecretKey"];
            PayStack = new PayStackApi(_secretKey);
        }

        public string InitializeTransaction(PaymentCommand command, string email)
        {
            var request = new TransactionInitializeRequest
            {
                AmountInKobo = Convert.ToInt32(command.AmountPaid), // Convert
                Email = email,
                Reference = Generate().ToString(),
                Currency = "GHS",
                CallbackUrl = $"http://artisan-management-platform.com/payment/{command.OrderId}"
            };

            var response = PayStack.Transactions.Initialize(request);
            if (!response.Status) return response.Message;
            
            // Save to database
            return response.Data.AuthorizationUrl;

        }

        public string VerifyTransaction(string reference)
        {
            var response = PayStack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                // update payment entry in db and redirect to payments page
                return "success";
            }

            return response.Data.GatewayResponse;
        }

        private static int Generate()
        {
            var rand = new Random((int) DateTime.UtcNow.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}