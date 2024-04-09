using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoint;

/// <summary>
/// List Orders
/// </summary>
public class OrderListEndpoint : IEndpoint<IResult, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public OrderListEndpoint(IUriComposer uriComposer, IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders-list",
            async (IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(orderRepository);
            })
           .Produces<ListOrdersResponse>()
           .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> orderRepository)
    {
        var response = new ListOrdersResponse();

        var items = await orderRepository.ListAsync();

        response.Orders.AddRange(items.Select(_mapper.Map<OrderDto>));

        return Results.Ok(response);
    }
}
