using UnityEngine;

namespace cln.Sources.Services
{
    public enum Clip
    {
        Jump,
        Grounded,
        Die,
    }

    public class AudioService : IService
    {
        private AudioDictionary _audioDictionary;
        private AudioSource _audioSource;

        public AudioService()
        {
            _audioSource = new GameObject().AddComponent<AudioSource>();
        }

        public void Initialize()
        {
            _audioDictionary = Resources.Load<AudioDictionary>("AudioDictionary");
        }

        public void Play(Clip name)
        {
            _audioSource.PlayOneShot(_audioDictionary.GetAudioClips()[name]);
        }
    }
}