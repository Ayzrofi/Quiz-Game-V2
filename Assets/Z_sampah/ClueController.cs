using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueController : MonoBehaviour {

    [SerializeField]
    Animator clueAnimasi;
    [SerializeField]
    GameObject ButtonsJawaban;
    bool isOpen;
    [SerializeField]
    AudioClip ClueSFX;
    [SerializeField]
    AudioSource AudioSrc;

    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();

        if (clueAnimasi == null)
            clueAnimasi = GameObject.FindGameObjectWithTag("Clue").GetComponent<Animator>();

        ButtonsJawaban.SetActive(false);
    }

    public void PlayAnim()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            ButtonsJawaban.SetActive(true);
            clueAnimasi.SetBool("isOpen", true);
        }
        else if(!isOpen)
        {
            ButtonsJawaban.SetActive(false);
            clueAnimasi.SetBool("isOpen", false);
        }
        AudioSrc.PlayOneShot(ClueSFX);
    }

}
