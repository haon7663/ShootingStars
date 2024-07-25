using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Inst;
    public AudioClip[] effect;
    AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        Inst = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SoundEffect(0);
        }
    }

    public void SoundEffect(int index)
    {
        audioSource.PlayOneShot(effect[index]);
    }
}
