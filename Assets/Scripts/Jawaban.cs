using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Jawaban : MonoBehaviour {
   
    public int PlayerHealth;
    int PlayerCurrentHealth;
    bool gameOver = false;
    [SerializeField]
    GameObject[] HealthImage;

    [SerializeField]
    string NextLevel;

    [SerializeField]
    AudioClip answerClip;
    [SerializeField]
    AudioSource AudioSrc;

    [SerializeField]
    MenuPopUpManajer PopUpMenu;

    private void Awake()
    {
        if(AudioSrc == null)
             AudioSrc = GetComponent<AudioSource>();

        if (PopUpMenu == null)
            PopUpMenu = GetComponent<MenuPopUpManajer>();

        PlayerCurrentHealth = PlayerHealth;
    }

    public void PlayerAnswerInput(bool JawabanIniBenar)
    {
        AudioSrc.PlayOneShot(answerClip);
        if (JawabanIniBenar)
            JawabanBenar();
        else
            JawabanSalah();
    }

    // function yang akan di panggil ketika jawaban player "Salah"
    private void JawabanSalah()
    {
        if(PlayerCurrentHealth > 0 && !gameOver)
        {
            PlayerCurrentHealth--;
            Debug.Log(PlayerCurrentHealth);
            HealthImage[PlayerCurrentHealth ].SetActive(false);
            Debug.Log("Anda salah asuu");
        }

        if(PlayerCurrentHealth <= 0)
        {
            GameOver();
        }
    }

   
    // function yang akan di panggil ketika jawaban player "Benar"
    private void JawabanBenar()
    {
        WinGame();
    }
    // Game Over Conditions
    private void GameOver()
    {
        gameOver = true;
        PopUpMenu.JawabanAndaSalah(0);
        Debug.Log("Loe Kalah Su");
    }
    // win Game Conditions
    public void WinGame()
    {
        PopUpMenu.JawabanAndaBenar(PlayerCurrentHealth, 10);
        Debug.Log("Anda Benar Cuk");
        Debug.Log(PlayerCurrentHealth);
    }
}
