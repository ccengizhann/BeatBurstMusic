﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Domain.Common
{
    public interface IDeletedOn
    {
        public DateTime? DeletedOn { get; set; }
    }
}