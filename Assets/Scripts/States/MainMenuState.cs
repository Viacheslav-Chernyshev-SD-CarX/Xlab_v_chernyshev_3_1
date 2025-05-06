using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {
        public GameState gamePlayState;
        public LevelController levelController;
        public TMP_Text scoreText;

        public void PlayGame()
        {
            Exit();
            gamePlayState.Enter();
            SoundManager.Instance.PlayGameStartStinger();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            scoreText.text = $"HScore : {levelController.hightScore}";
        }

        /* public override void Enter()
         {
             base.Enter();
         }
        */
    }
}
