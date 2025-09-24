using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models
{
    public record PaymentRequest
    {
        //init: C# 9.0 ile gelen nesne ilk oluşturulurken yazılan ve daha sonra değiştirilemez olan (private için readonly) güvenli mülkler oluşur.
        [Required]
        public string Provider { get; init; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; init; }

        [Required]
        public string Currency { get; init; } = "TRY";

        [Required]
        public string OrderId { get; init; } = string.Empty;

        public string? Description { get; init; }

        public CustomerInfo? Customer { get; init; }
        public Dictionary<string, object>? ProviderSpecificData { get; init; }
    }

    public record CustomerInfo
    {
        public string? Email { get; init; }
        public string? Firstname { get; init; }
        public string? Lastname { get; init; }
        public string? Phone { get; init; }
        public AddressInfo? Address { get; init; }
    }

    public record AddressInfo
    {
        public string? Street { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? PostalCode { get; init; }
        public string? Country { get; init; }
    }

    public record RefundRequest
    {
        [Required]
        public string Provider { get; init; } = string.Empty;

        [Required]
        public string TransactionId { get; init; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal? Amount { get; init; }

        public string? Reason { get; init; }
    }

    public enum PaymentStatus { Pending, Completed, Failed, Cancelled, Refunded, PartiallyRefunded }
    public record PaymentResponse
    {
        public bool Success { get; init; }
        public string? TransactionId { get; init; }
        public string? PaymentUrl { get; init; }
        public PaymentStatus Status { get; init; }
        public string? ErrorMessage { get; init; }
        public Dictionary<string, object>? ProviderData { get; init; }
    }

    public record RefundResponse
    {
        public bool Success { get; init; }
        public string? RefundId { get; init; }
        public string? ErrorMessage { get; init; }
        public decimal RefundedAmount { get; set; }
    }
}
