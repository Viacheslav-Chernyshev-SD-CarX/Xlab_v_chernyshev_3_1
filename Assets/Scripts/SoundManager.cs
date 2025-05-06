using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [System.Serializable]
        public class SoundCategory
        {
            public string name;
            public AudioClip[] clips;
        }

        [Header("Ударные звуки")]
        public SoundCategory[] hitSoundCategories; // Категории звуков ударов

        [Header("Звуки камней")]
        public SoundCategory[] stoneSoundCategories;

        [Header("Звуки взмахов")]
        public SoundCategory[] swingSoundCategories;

        [Header("Стингеры")]
        public AudioClip gameStartStinger; // При Play
        public AudioClip gameOverStinger;  // При GameOver
        public AudioClip restartStinger;   // При Restart

        private AudioSource stingerSource; // Отдельный источник для стингеров
        private bool isPlayingStinger;     // Флаг воспроизведения

        //private AudioSource musicSource;
        private AudioSource sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                SetupAudioSources();

            }
            else
            {
                Destroy(gameObject);
            }

        }

        private void SetupAudioSources()
        {
           // musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

          //  musicSource.loop = true;
            sfxSource.loop = false;

            stingerSource = gameObject.AddComponent<AudioSource>();
            stingerSource.loop = false;
        }

        // Выбирает случайный звук из случайной категории
        private AudioClip GetRandomSoundFromCategories(SoundCategory[] categories)
        {
            if (categories == null || categories.Length == 0) return null;

            // Выбираем случайную категорию
            SoundCategory randomCategory = categories[Random.Range(0, categories.Length)];

            // Выбираем случайный звук из этой категории
            if (randomCategory.clips.Length > 0)
            {
                return randomCategory.clips[Random.Range(0, randomCategory.clips.Length)];
            }

            return null;
        }

        public void PlayRandomHitSound()
        {
            AudioClip clip = GetRandomSoundFromCategories(hitSoundCategories);
            if (clip != null) sfxSource.PlayOneShot(clip);
        }

        public void PlayRandomStoneSound()
        {
            AudioClip clip = GetRandomSoundFromCategories(stoneSoundCategories);
            if (clip != null) sfxSource.PlayOneShot(clip);
        }

        public void PlayRandomSwingSound()
        {
            AudioClip clip = GetRandomSoundFromCategories(swingSoundCategories);
            if (clip != null) sfxSource.PlayOneShot(clip);
        }

        // Остальные методы для музыки...
        /*
        public void PlayMusic1() => PlayMusic(music1);
        public void PlayMusic2() => PlayMusic(music2);
        public void PlayMusic3() => PlayMusic(music3);
        
        private void PlayMusic(AudioClip clip)
        {
            if (clip == null) return;
            musicSource.clip = clip;
            musicSource.Play();
        }*/



        // === Методы для стингеров ===
        public void PlayGameStartStinger()
        {
            PlayStingerOnce(gameStartStinger);
        }

        public void PlayGameOverStinger()
        {
            PlayStingerOnce(gameOverStinger);
        }

        public void PlayRestartStinger()
        {
            PlayStingerOnce(restartStinger);
        }

        private void PlayStingerOnce(AudioClip clip)
        {
            if (clip == null || isPlayingStinger) return;

            isPlayingStinger = true;
            stingerSource.PlayOneShot(clip);

            // Сброс флага после завершения звука
            Invoke(nameof(ResetStingerFlag), clip.length);
        }

        private void ResetStingerFlag()
        {
            isPlayingStinger = false;
        }
    }
}

