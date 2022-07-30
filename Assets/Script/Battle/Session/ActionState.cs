using System.Collections;
using cofydev.util.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace CM.Battle.Session
{
    public class ActionState : MonoBehaviour, IStateContext
    {
        [SerializeField] private GameObject ActionBtnParent;
        
        private void Awake()
        {
            ActionBtnParent.SetActive(false);
        }
        
        public IEnumerator StartContext(IStateMachine sm)
        {
            Debug.Log("Now in Action State");
            ActionBtnParent.SetActive(true);
            
            yield return null;
        }
    }
}