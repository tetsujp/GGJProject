using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

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
    public void PlaySmileSound()
    {
        audio.Play();
    }
}
