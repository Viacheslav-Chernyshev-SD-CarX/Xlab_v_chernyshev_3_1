using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        public Transform helper;


        private Vector3 m_lastPosition;

        private bool m_isDown = false;

        public float range = 40f;

        public float speed = 500f;

        public float power = 20f;

        private void Update()
        {
            m_lastPosition = helper.position;

            m_isDown = Input.GetMouseButtonUp(0);

            Quaternion rot = stick.localRotation;

            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);

            rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);

            stick.localRotation = rot;


        }


        public void OnColloisionStick(Collider collider)    
        {
            if (collider.TryGetComponent(out Rigidbody stone))
            {
               // var dir = m_isDown ? stick.right : -stick.right;
                var dir = (helper.position - m_lastPosition).normalized;
                stone.AddForce(dir * power, ForceMode.Impulse);
            }

            Debug.Log(collider, this);
        }
    }
}

