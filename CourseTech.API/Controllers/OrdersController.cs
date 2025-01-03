﻿using CourseTech.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService service) : CustomBaseController
    {
        [HttpPost("from-basket/{basketId:guid}")]
        public async Task<IActionResult> CreateOrderFromBasket(Guid basketId)
        {
            var result = await service.CreateOrderFromBasketAsync(basketId);
            return CreateActionResult(result);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var result = await service.GetOrderByIdAsync(orderId);
            return CreateActionResult(result);
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        {
            var result = await service.GetOrdersByUserIdAsync(userId);
            return CreateActionResult(result);
        }
    }
}