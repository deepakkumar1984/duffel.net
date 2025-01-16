using System.Threading.Tasks;
using Duffel.Api.Types;

    public class Payments : Resource
    {
        /// <summary>
        /// Endpoint path
        /// </summary>
        private readonly string _path;

        public Payments(Client client) : base(client)
        {
            _path = "air/payments";
        }

        /// <summary>
        /// Creates a payment for an existing pay later order.
        /// An order can be paid for up to the time limit indicated in `payment_required_by`, after which the space held for the order will be released and you will have to create a new order.
        /// </summary>
        /// <param name="options">Payment creation parameters</param>
        /// <returns>The created payment</returns>
        public async Task<DuffelResponse<Payment>> CreateAsync(CreatePayment options)
        {
            return await RequestAsync<DuffelResponse<Payment>>(new Request
            {
                Method = HttpMethod.Post,
                Path = _path,
                Data = options
            });
        }
    }
