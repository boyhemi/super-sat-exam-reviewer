using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ExplosionTriggerScript : MonoBehaviour
{
    [SerializeField] VideoPlayer explosionVideo;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEinsteinExplosion()
    {
        explosionVideo.gameObject.SetActive(true);
        explosionVideo.Play();
    }

    public void StopEinsteinExplosion()
    {
        explosionVideo.gameObject.SetActive(false);
        explosionVideo.Stop();
    }
}
