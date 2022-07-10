using System.Collections;
using System.Collections.Generic;
using cofydev.util.StateMachine;
using Script.Battle.Core;
using UnityEngine;

namespace CM.Battle.Session
{
    public class SpawnState : MonoBehaviour, IStateContext
    {
        public IEnumerator StartContext(IStateMachine sm)
        {
            var monsterHandler = GameObject.FindGameObjectWithTag("GameMode").GetComponent<BattleMonsterHandler>();
            var spawner = GameObject.FindGameObjectWithTag("Spawner");
            var monsterSpawner = spawner.GetComponent<MonsterSpawner>();


            List<GameObject> redSideMonsters = monsterHandler.GetSideMonsters(EBattleSide.RED);
            if (redSideMonsters != null)
                monsterSpawner.Spawn(redSideMonsters);    
            
            List<GameObject> blueSideMonsters = monsterHandler.GetSideMonsters(EBattleSide.BLUE);
            if (blueSideMonsters != null)
                monsterSpawner.Spawn(blueSideMonsters);    
            
            
            yield return null;
        }
    }
}