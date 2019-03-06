using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneController : MonoBehaviour {
    [SerializeField]
    Animator AnimasiTransisi;
    [SerializeField]
    AudioSource AudioSrc;
   
    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ExitGame());
        }
    }

   
    public void PlaySFX(AudioClip Clip)
    {
        AudioSrc.PlayOneShot(Clip);
    }

    public void LoadScene(string SceneName)
    {
        StartCoroutine(SceneEnum(SceneName));
    }

	IEnumerator SceneEnum(string scene)
    {
        AnimasiTransisi.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
        Debug.Log("Nyahoi");
    }

    public void Exit()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        AnimasiTransisi.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        Application.Quit();
        Debug.Log("Nyaaa Seee");
    }

    [ContextMenu("Delete All Data")]
    public void DeleteAllPlayerData()
    {
        PlayerPrefs.DeleteAll();
    }
}
