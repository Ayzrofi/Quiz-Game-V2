using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuPopUpManajer : MonoBehaviour {
    [Header("Refrensi Untuk Semua Game Object dalam Scene")]
    public GameObject AllGameObject;
    [Header("Animasi Pop Up Menu")]
    public Animator MenuJwabanBenar;
    public Animator MenuJawabanSalah;
    [Header("Bintang Untuk Score")]
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    [Header("Text Untuk Score Akhir")]
    public Text ScoreJawabanBenar;
    public Text ScoreJawabanSalah;

    public void JawabanAndaBenar(int CurrentHealth, int YourScore)
    {
       
        MenuJwabanBenar.SetTrigger("Fallen");
        ScoreJawabanBenar.text = YourScore.ToString();
        AllGameObject.SetActive(false);
        switch (CurrentHealth)
        {
            case 1:
                Star1.SetActive(true);
                Star2.SetActive(false);
                Star3.SetActive(false);
                break;
            case 2:
                Star1.SetActive(false);
                Star2.SetActive(true);
                Star3.SetActive(false);
                break;
            case 3:
                Star1.SetActive(false);
                Star2.SetActive(false);
                Star3.SetActive(true);
                break;
        }
    }

    public void JawabanAndaSalah(int YourScore)
    {
       
        MenuJawabanSalah.SetTrigger("Fallen");
        ScoreJawabanSalah.text = YourScore.ToString();
        AllGameObject.SetActive(false);
    }

}
