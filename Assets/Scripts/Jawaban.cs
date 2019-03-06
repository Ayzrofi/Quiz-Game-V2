using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Jawaban : MonoBehaviour {
    private static Jawaban Jwb;
    public static Jawaban TheInstanceOfJawaban
    {
        get
        {
            if (Jwb == null)
                Jwb = FindObjectOfType<Jawaban>();

            return Jwb;
        }
    }

    public int PlayerHealth;
    [HideInInspector]
    public int PlayerCurrentHealth;
    bool gameOver = false;
    [SerializeField]
    GameObject[] HealthImage;

    //[SerializeField]
    //string NextLevel;

    //[SerializeField]
    //AudioClip answerClip;
    //[SerializeField]
    //AudioSource AudioSrc;

    [SerializeField]
    MenuPopUpManajer PopUpMenu;

    public int PlayerScore;
    private void Awake()
    {
        //if(AudioSrc == null)
        //     AudioSrc = GetComponent<AudioSource>();

        if (PopUpMenu == null)
            PopUpMenu = GetComponent<MenuPopUpManajer>();

        PlayerCurrentHealth = PlayerHealth;
        Debug.Log(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name));
    }

    //public void PlayerAnswerInput(bool JawabanIniBenar)
    //{
    //    AudioSrc.PlayOneShot(answerClip);
    //    if (JawabanIniBenar)
    //        JawabanBenar();
    //    else
    //        JawabanSalah();
    //}

    // function yang akan di panggil ketika jawaban player "Salah"
    public void JawabanSalah()
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
    public void JawabanBenar()
    {
        WinGame();
    }
    // Game Over Conditions
    private void GameOver()
    {
        gameOver = true;
        PopUpMenu.JawabanAndaSalah(PlayerScore);
        Debug.Log("Loe Kalah Su");
    }
    // win Game Conditions
    public void WinGame()
    {
        PlayerScore += 10;
        if (ScoreController.TheScore != null)
        {
            ScoreController.TheScore = PlayerScore;
        }

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, PlayerScore);
        
        PopUpMenu.JawabanAndaBenar(PlayerCurrentHealth, PlayerScore);
        Debug.Log("Anda Benar Cuk");
        Debug.Log(PlayerCurrentHealth);
    }
}
