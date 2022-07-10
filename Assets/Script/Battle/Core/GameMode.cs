using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Script.Battle.Core
{
    public class GameMode : MonoBehaviour
    {
        public EBattleState curBattleState = EBattleState.START;
    }
}