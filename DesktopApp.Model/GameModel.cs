﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Model
{
    public class GameModel
    {
        public GameTypeModel GameType { get; set; }
        public PlayerModel PlayerOne { get; set; }
        public PlayerModel PlayerTwo { get; set; }
    }
}
