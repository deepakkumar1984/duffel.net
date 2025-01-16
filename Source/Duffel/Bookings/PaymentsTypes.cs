using System;

namespace Duffel.Api.Types
{
    /// <summary>
    /// To pay for an unpaid order you've previously created, you'll need to create a payment for it.
    /// </summary>
    /// <link>https:/duffel.com/docs/api/payments/schema</link>
    public class Payment
    {
        /// <summary>
        /// The amount of the payment.
        /// This should be the same as the `total_amount` of the offer specified in `selected_offers` for an instant order or the `total_amount` of the previously created pay later order specified in `order_id`, plus the `total_amount` of all the services specified in services.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// The currency of the amount, as an ISO 4217 currency code.
        /// For an instant order, this should be the same as the `total_currency` of the offer specified in selected_offers.
        /// For a pay later order, this should be the same as the `total_currency` of the previously created order specified in `order_id`.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// The ISO 8601 datetime at which the payment was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the payment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The type of payment you want to apply to the order.
        /// </summary>
        public PaymentType Type { get; set; }
    }

    public class CreatePayment
    {
        /// <summary>
        /// The `id` of the order you want to pay for.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// The payment details to use to pay for the order.
        /// </summary>
        public Payment Payment { get; set; }
    }
}
