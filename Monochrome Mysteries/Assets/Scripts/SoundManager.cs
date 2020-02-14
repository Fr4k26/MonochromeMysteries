using UnityEngine;

public class SoundManager : MonoBehaviour
{

    Audiosource MusicManager;
 
    // Start is called before the first frame update
    void Start()
    {
        MusicManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
