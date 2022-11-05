using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(.1f, 1f)] public float volume;
    [Range(.3f, 3f)] public float pitch;
}
