using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GraduationProject.Models
{
    public class HighlightedMenuAttribute : ActionFilterAttribute
    {
        public HighlightedMenuAttribute(Menu currentMenu)
        {
            CurrentMenu = currentMenu;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewData[nameof(CurrentMenu)] = CurrentMenu;
        }

        public Menu CurrentMenu { get; set; }
    }

    public enum Menu
    {
        AddProduct,
        Products,
        Profile,
        Map,
        Search,
        Cart,
        Inbox
    }
}