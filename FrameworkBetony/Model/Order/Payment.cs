﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkBetony.Model.Order
{
    enum Payment
    {
        FakturaPrzelew, 
        FakturaGotowka,
        Gotowka,
        Przedplata,
        Zaplacono,
        GotowkaWKasie,
        NieDotyczy
    }
}
