using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerV2 : MonoBehaviour {
    [Header("Untuk Jenis Rambu Larangan")]
    public Text HasilAkhirLaranganText;
    public Text PointLaranganGambarText;
    public Text PointLaranganNamaText;
    [Header("Untuk Jenis Rambu Peringatan")]
    public Text HasilAkhirPeringatanText;
    public Text PointPeringatanGambarText;
    public Text PointPeringatanNamaText;
    [Header("Untuk Jenis Rambu Petunjuk")]
    public Text HasilAkhirPetunjukText;
    public Text PointPetunjukGambarText;
    public Text PointPetunjukNamaText;

    int laranganGambar, laranganNama, peringatanGambar, peringatanNama, petunjukGambar, petunjukNama;
    [Header("Kata2 Bijak")]
    public string KataBijak_1;
    public string KataBijak_2;
    public string KataBijak_3;
    public string KataBijak_4;
    public string KataBijak_5;
    private void Start()
    {
        ShowFinalScore();
    }

    public void ShowFinalScore()
    {
        GetPlayerScore();
        SetPlayerScoreToText();
    }

    public void GetPlayerScore()
    {
        laranganGambar = PlayerPrefs.GetInt("Larangan_Vgambar");
        laranganNama = PlayerPrefs.GetInt("Larangan_Vsoal");

        peringatanGambar = PlayerPrefs.GetInt("Peringatan_Vgambar");
        peringatanNama = PlayerPrefs.GetInt("Peringatan_Vsoal");

        petunjukGambar = PlayerPrefs.GetInt("Petunjuk_Vgambar");
        petunjukGambar = PlayerPrefs.GetInt("Petunjuk_Vsoal");
    }
    public void SetPlayerScoreToText()
    {
        PointLaranganGambarText.text = laranganGambar.ToString();
        PointLaranganNamaText.text = laranganNama.ToString();
        GetHasilAkhir(HasilAkhirLaranganText, laranganGambar + laranganNama);

        PointPeringatanGambarText.text = peringatanGambar.ToString();
        PointPeringatanNamaText.text = peringatanNama.ToString();
        GetHasilAkhir(HasilAkhirPeringatanText, peringatanGambar + peringatanNama);

        PointPetunjukGambarText.text = petunjukGambar.ToString();
        PointPetunjukNamaText.text = petunjukNama.ToString();
        GetHasilAkhir(HasilAkhirPetunjukText, petunjukGambar + petunjukNama);
    }
   
    public void GetHasilAkhir(Text HasilAkhir, int Score)
    {
        if (Score > 0 && Score <= 20)
        {
            HasilAkhir.text = KataBijak_1;
        }
        else
            if (Score > 20 && Score <= 40)
        {
            HasilAkhir.text = KataBijak_2;
        }
        else
             if (Score > 40 && Score <= 60)
        {
            HasilAkhir.text = KataBijak_3;
        }
        else
            if (Score > 60 && Score <= 80)
        {
            HasilAkhir.text = KataBijak_4;
        }
        else
            if (Score > 80 && Score <= 100)
        {
            HasilAkhir.text = KataBijak_5;
        }
    }
}
