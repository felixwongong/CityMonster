using System;
using UnityEngine;

namespace CM.Battle.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Controller : MonoBehaviour
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void LookToTarget(GameObject target)
        {
            var direction = target.transform.position - transform.position;
            direction.y = 0;
            var targetRot = Quaternion.LookRotation(direction);
            rb.MoveRotation(targetRot);
        } 
    }
}