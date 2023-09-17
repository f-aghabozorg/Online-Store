﻿using System.ComponentModel.DataAnnotations;

namespace Online_Store.Domain.Entities.Orders
{
    public enum OrderState
    {
        [Display(Name = "در حال پردازش")]
        Processing = 0,
        [Display(Name = "لغو شده")]
        Canceled = 1,
        [Display(Name = "تحویل شده")]
        Delivered = 2,
        [Display(Name = "در حال پردازش از سوی درگاه پرداخت")]
        PayProcessing = 3,
    }

}
