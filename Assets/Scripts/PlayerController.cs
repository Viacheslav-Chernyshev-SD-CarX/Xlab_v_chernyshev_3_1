using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void Update()
        {
            player.SetDown(Input.GetMouseButton(0));
        }

        private void Start()
        {
            if (player == null)
            {
                Debug.Log("Player is null!");
            }

        }
    }
}
