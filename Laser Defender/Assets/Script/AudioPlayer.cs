using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f,1f)] float shootingVolume = 1f;

    [Header("damaged")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;

  /*  public AudioPlayer GetInstance()
    {
        return instance;
    }
  */

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCnt = FindObjectsOfType(GetType()).Length;
        //if(instanceCnt > 1 ) { }
        if (instance != null) 
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance= this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        playClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
       playClip(damageClip, damageVolume);
    }

    private void playClip(AudioClip clip, float volume) 
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
