using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Golf
{
    public class GamePlayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        public TMP_Text scoreText;


        protected override void OnEnable()
        {
            base.OnEnable();

            levelController.enabled = true;
            playerController.enabled = true;

            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.onStickHit += OnStickHit;

        }
        private void OnStickHit()
        {

            scoreText.text = $"Score : {levelController.score}";
                                    
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();

        }
        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStone -= OnGameOver;
            SoundManager.Instance.PlayGameOverStinger();


            levelController.enabled = false;
            playerController.enabled = false;
           

        }

    }
}
