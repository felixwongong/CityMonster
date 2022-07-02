using System.Collections;
using cofydev.util.StateMachine;
using UnityEngine;

namespace CM.Battle.Session
{
    public class SpawnState : MonoBehaviour, IStateContext
    {
        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public IEnumerator StartContext(IStateMachine sm)
        {
            print("Now in spawn state");
            yield return null;
        }
    }
}