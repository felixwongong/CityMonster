﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CM.Battle.Core
{
    public class GameMode : MonoBehaviour
    {
        public static EBattleState curBattleState = EBattleState.START;
    }
}