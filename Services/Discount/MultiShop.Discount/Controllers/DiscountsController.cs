﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.CouponDtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;

        public DiscountsController(IDiscountService DiscountService)
        {
            _DiscountService = DiscountService;
        }


        [HttpGet]
        public async Task<IActionResult> CouponListAsync()
        {
            var values = await _DiscountService.GetAllCouponAsync();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
        {
            var value = await _DiscountService.GetByIdCouponAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var values = await _DiscountService.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _DiscountService.CreateCouponAsync(createCouponDto);
            return Ok("Ekleme İşlemi Tamamlandı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCouponAsync(int id)
        {
            await _DiscountService.DeleteCouponAsync(id);
            return Ok("Silme İşlemi Tamamlandı");
        }
        [HttpGet("GetDiscountCouponCountRate")]
        public IActionResult GetDiscountCouponCountRate(string code)
        {
            var values = _DiscountService.GetDiscountCouponCountRate(code);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _DiscountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Güncelleme İşlemi Tamamlandı");
        }


        [HttpGet("GetDiscountCouponCountAsync")]
        public async Task<IActionResult> GetDiscountCouponCountAsync()
        {
            var values =await _DiscountService.GetDiscountCouponCountAsync();
            return Ok(values);
        }


    }
}
