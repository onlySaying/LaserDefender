using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float basefiringRate = 0.2f;

    [Header("Ai")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimunFiringRate = 0.1f;

    [HideInInspector]public bool isFireing;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFireing = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFireing && firingCoroutine == null) 
        {
            firingCoroutine =  StartCoroutine(FireContinuosly());
        }
        else if(!isFireing && firingCoroutine != null)
        {
            //    StopAllCoroutines();
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);

            float timeToNextProjextile = Random.Range(basefiringRate - firingRateVariance, basefiringRate + firingRateVariance);

            timeToNextProjextile = Mathf.Clamp(timeToNextProjextile, minimunFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjextile);  
           
        }
    }
}
