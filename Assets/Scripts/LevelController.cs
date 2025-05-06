using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        private float m_delay = 0.5f;

       // public float delay = 0.5f;
       // public bool isGameOver = false;

       //  private List<GameObject> m_stones = new List<GameObject>(16);

        private float m_lastSpawnedTime = 0;

        public int score = 0;
        public int hightScore = 0;

        private List<GameObject> m_stones = new List<GameObject>(16);
        
        private void Start()
        {
           // StartCoroutine(StartStoneProc());

            m_lastSpawnedTime = Time.time;
            RefreshDelay();
           // Stone.onCollisionStone += GameOver;
        }

        private void OnStickHit()
        {

            score++;
            hightScore = Mathf.Max(hightScore, score);
            Debug.Log($"score: {score} - hightScore: {hightScore}");
        }

        private void OnEnable()
        {
            //Stone.onCollisionStone += GameOver;
            //GameEvents.onCollisionStone += GameOver;
            GameEvents.onStickHit += OnStickHit;
            score = 0;

        }

        private void OnDisable()
        {
            //Stone.onCollisionStone -= GameOver;
            //GameEvents.onCollisionStone -= GameOver;
            GameEvents.onStickHit -= OnStickHit;
        }

        private void GameOver()
        {
            Debug.Log("Game Over");
           // isGameOver = true;
           enabled = false;
        }

        public void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }
            m_stones.Clear();
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

        private void Update()
        {
            //if (isGameOver)
            //{
                if(Time.time >= m_lastSpawnedTime + m_delay)
                {
                //    spawner.Spawn();
                var stone = spawner.Spawn();
                m_stones.Add(stone);

                m_lastSpawnedTime = Time.time;
                RefreshDelay();
                }
            //}
        }

        /*
        private IEnumerator StartStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);
                spawner.Spawn();
            }
            while (!isGameOver);
        }
        */
    }
}

