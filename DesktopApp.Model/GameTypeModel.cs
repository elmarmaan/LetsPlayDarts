﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace DesktopApp.Model
{
    public class GameTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public GameTypeTypes Type { get; set; }
    }
}
