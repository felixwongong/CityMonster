using System.Collections.Generic;
using UnityEngine;

namespace CM.Battle.Session
{
    public class BattleStateMachine : MonoBehaviour, IStateMachine
    {
        [SerializeField] private List<IStateContext> statesInclude;
    }
}