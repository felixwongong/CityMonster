using Script.Core;
using UnityEngine;

namespace Script.Monster
{
    /// <summary>
    ///  Script hold by in-game monster, which is responsible for spawning monsters model in runtime
    /// </summary>
    public class Monster : MonoBehaviour
    {
        public void SpawnChildMonster(GameObject monster)
        {
            Instantiate(monster, transform);
        }
    }
}