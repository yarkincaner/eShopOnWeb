using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.AllOrders;

public class GetAllOrders : IRequest<IEnumerable<OrderViewModel>>
{
}
