using AutoMapper;
using Basket.API.Data.Entities;
using Basket.API.Entities;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Transports;
using System;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public class EventService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public EventService(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async void PublishEvent(ShoppingCart basket, BasketCheckout basketCheckout)
        {
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout); // event obj to send to RabbitMQ.
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish(eventMessage); // publishing Event as message to RabbitMQ.
        }
    }
}
