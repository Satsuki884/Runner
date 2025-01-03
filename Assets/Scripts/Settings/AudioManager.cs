using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("Audio Clips Music")]
        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] private AudioClip _LevelMusic;

        [Header("Audio Clips SFX")]
        [SerializeField] private AudioClip _deadMusic;
        [SerializeField] private AudioClip _saleMusic;
        [SerializeField] private AudioClip _buttonClick;
        [SerializeField] private AudioClip _coinPickup;

        [Header("Scenes")]
        [SerializeField] private string _menuScene;
        [SerializeField] private string _levelScene;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == _menuScene)
            {
                _musicSource.clip = _backgroundMusic;
            }
            else if (SceneManager.GetActiveScene().name == _levelScene)
            {
                _musicSource.clip = _LevelMusic;
            }
            _musicSource.Play();
        }

        public string ButtonClick = "buttonClick";
        public string SaleMusic = "saleMusic";
        public string DeadMusic = "deadMusic";
        public string CoinPickup = "coinPickup";

        public void PlaySFX(string clipName)
        {
            // Debug.Log("Playing SFX: " + clipName);
            switch (clipName)
            {
                case "buttonClick":
                    _sfxSource.PlayOneShot(_buttonClick);
                    break;
                case "deadMusic":
                    _sfxSource.PlayOneShot(_deadMusic);
                    break;
                case "saleMusic":
                    _sfxSource.PlayOneShot(_saleMusic);
                    break;
                case "coinPickup":
                    _sfxSource.PlayOneShot(_coinPickup);
                    break;
            }
        }
    }
}