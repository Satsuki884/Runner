using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace Runner
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private GameObject _settingPanel;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _closeSettingsButton;
        private string QualityLevel = "QualityLevel";
        private string Music = "Music";

        [Header("Audio")]
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private AudioMixer _audioMixer;

        private void Start()
        {
            AddEventListeners();
            SetBetweenSession();
            CloseSettings();
        }

        public void AddEventListeners()
        {
            _openSettingsButton.onClick.RemoveAllListeners();
            _closeSettingsButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListeners();
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _closeSettingsButton.onClick.AddListener(CloseSettings);

            _volumeSlider.onValueChanged.AddListener(SetVolumeMusic);

            _qualityDropdown.onValueChanged.AddListener(SetQuality);
            _qualityDropdown.onValueChanged.AddListener(SetQuality);
        }

        public void SetBetweenSession()
        {
            if (PlayerPrefs.HasKey(QualityLevel))
            {
                int savedQualityLevel = PlayerPrefs.GetInt(QualityLevel);
                _qualityDropdown.value = savedQualityLevel;
                QualitySettings.SetQualityLevel(savedQualityLevel);
            }
            if (PlayerPrefs.HasKey(Music))
            {
                // Debug.Log(Music);
                float savedVolume = PlayerPrefs.GetFloat(Music);
                _volumeSlider.value = savedVolume;
                _audioMixer.SetFloat(Music, savedVolume);
            }

        }

        private void OpenSettings()
        {
            _settingPanel.SetActive(true);
        }

        private void CloseSettings()
        {
            _settingPanel.SetActive(false);
        }



        public void SetVolumeMusic(float volume)
        {
            Debug.Log(volume);
            _audioMixer.SetFloat(Music, volume);
            PlayerPrefs.SetFloat(Music, volume);
            PlayerPrefs.Save();
        }

        [SerializeField] private TMP_Dropdown _qualityDropdown;

        public void SetQuality(int qualityLevel)
        {
            // Debug.Log(qualityLevel);
            QualitySettings.SetQualityLevel(qualityLevel);
            PlayerPrefs.SetInt(QualityLevel, qualityLevel);
            PlayerPrefs.Save();
        }
    }
}