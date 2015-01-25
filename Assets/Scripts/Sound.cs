using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    AudioSource[] audioSet;
    protected static Sound instance;
    public static Sound Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (Sound)FindObjectOfType(typeof(Sound));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");
                }
            }

            return instance;
        }
    }
    void Start()
    {
        audioSet = GetComponents<AudioSource>();
    }

    public void PlaySmileSound()
    {
        audioSet[0].Play();
    }
    public void KillSount()
    {
        audioSet[1].Play();
    }
    public void MissSound()
    {
        audioSet[2].Play();
    }
}
