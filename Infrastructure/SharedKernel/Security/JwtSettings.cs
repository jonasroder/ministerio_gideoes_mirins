﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SharedKernel.Security
{
    public class JwtSettings
    {
        public string Secret { get; init; } = null!;
        public int ExpirationMinutes { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
