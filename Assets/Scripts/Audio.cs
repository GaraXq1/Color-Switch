using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] songs;
    public float volume;

    [SerializeField] private float songsPlayed;
    [SerializeField] private bool[] beenPlayed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        beenPlayed = new bool[songs.Length];


        if(!audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    void Update()
    {
        audioSource.volume = volume;

        if(!audioSource.isPlaying || Input.GetKeyDown(KeyCode.C))
        {
            ChangeSong(Random.Range(0, songs.Length));
        }

        if(songsPlayed == songs.Length)
        {
            songsPlayed = 0;
            for(int i = 0;i < songs.Length ; i++)
            {
                if(i == songs.Length)
                {
                    break;
                }
                else
                {
                    beenPlayed[i] = false;
                }
            }
        }

    }

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    public void ChangeSong(int songPicked)
    {
        if (!beenPlayed[songPicked])
        {
            songsPlayed++;
            beenPlayed[songPicked] = true;
            audioSource.clip = songs[songPicked];
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

    }

}
