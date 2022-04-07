using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundManager : MonoBehaviour
{
    public static TestSoundManager Instance;
    [SerializeField] private AudioSource _musicSouce, _effectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
}
