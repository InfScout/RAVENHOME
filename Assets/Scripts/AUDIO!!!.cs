using UnityEngine;

public class AUDIO : MonoBehaviour
{
    [SerializeField]public AudioSource Sfx;
    [SerializeField]public AudioClip walk;
    [SerializeField]public AudioClip blockdrop;
    [SerializeField]public AudioClip button;
    [SerializeField]public AudioClip checkpoint;
    [SerializeField]public AudioClip death;
    [SerializeField]public AudioClip door;
    private static AUDIO _instance;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AUDIO GetInstance()
    {
        return _instance;
    }

    public void PlaySound(AudioClip clip)
    {
        Sfx.PlayOneShot(clip);
    }
}
