﻿using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Helpers;
using MotoBikeShop.ViewModels;
namespace MotoBikeShop.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          var cart = HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
            return View("CartPanel", new CartModel
            {
                Quantity = cart.Sum(p=>p.SoLuong),
                Total = cart.Sum(p=>p.ThanhTien)
            });
        }
    }
}
