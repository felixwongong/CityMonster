using System.Collections.Generic;
using UnityEngine;

namespace Script.Battle.Core
{
    public class MonsterSpawner : MonoBehaviour
    {
           
        public void Spawn(List<GameObject> monsters)
        {
            foreach (var monster in monsters)
            {
                Instantiate(monster);
            }
        } 
    }
}