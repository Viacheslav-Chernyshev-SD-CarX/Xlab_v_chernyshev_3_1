using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Golf
{
	public abstract class GameState : MonoBehaviour
	{
        public List<GameObject> views;

        private void OnEnable()
        {
            foreach (var items in views)
            {
                items.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (var items in views)
            {
                items.SetActive(false);
            }

        }
    }
}