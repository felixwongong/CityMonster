using System.Collections;
using System.Collections.Generic;
using cofydev.util.StateMachine;
using UnityEngine;

namespace CM.Battle.Session
{
public class DialogueState : MonoBehaviour, IStateContext
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator StartContext(IStateMachine sm)
    {
        print("Now in Dialogue State");
        yield return new WaitForSeconds(3f);
        sm.GoToNextState(GetComponent<SpawnState>());
    }
}
}