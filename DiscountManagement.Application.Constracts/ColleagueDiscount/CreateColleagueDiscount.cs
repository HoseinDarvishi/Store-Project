﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Application.Constracts.ColleagueDiscount
{
    public class CreateColleagueDiscount
    {
        public long ProductId  { get; set; }

        public int DiscountPercent { get; set; }
    }

    public class EditColleagueDiscount : CreateColleagueDiscount
    {

    }
}
