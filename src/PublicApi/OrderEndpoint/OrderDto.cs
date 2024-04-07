using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoint;

public class OrderDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total {  get; set; }
}
