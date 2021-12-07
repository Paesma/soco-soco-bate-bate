using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject AudioLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(AudioLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
