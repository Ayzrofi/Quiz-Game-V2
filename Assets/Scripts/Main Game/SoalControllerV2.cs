using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SoalControllerV2 : MonoBehaviour {
    private static SoalControllerV2 Sc;
    public static SoalControllerV2 TheInstanceOfSoalControllerV2
    {
        get
        {
            if (Sc == null)
            {
                Sc = FindObjectOfType<SoalControllerV2>();
            }
            return Sc;
        }
    }
    [Header("Audio Component")]
    public AudioSource AudioSrc;
    public AudioClip SfxBenar;
    public AudioClip SfxSalah;
    [Header("Soal Gambar Pada Level")]
    public Text TextSoal;
    [Header("Semua Button Jawaban")]
    public Button Jawaban_1;
    public Button Jawaban_2;
    public Button Jawaban_3;
    [Header("Semua Text Jawaban Pada Buttons")]
    public Image Gambarjawaban_1;
    public Image Gambarjawaban_2;
    public Image Gambarjawaban_3;
    [Header("Scriptable Object Soal")]
    public List<Soal_Pertanyaan> TheSoal;

    int Rand_1, Rand_2, Rand_3;

    private void Start()
    {
        CreateSoal();
    }

    private void Update()
    {
        if (Jawaban.TheInstanceOfJawaban.PlayerCurrentHealth <= 0)
            SceneManager.LoadScene("Score Scene Vhardcore");
    }

    [ContextMenu("Create Soal")]
    public void CreateSoal()
    {
        if (TheSoal.Count > 0)
        {
            int RandomSoal = Random.Range(0, TheSoal.Count);

            //GambarSoal.sprite = TheSoal[RandomSoal].GambarSoal;
            TextSoal.text = TheSoal[RandomSoal].TextPertanyaan;

            int RandomJawaban = Random.Range(1, 4);
            // jawaban 1
            if (RandomJawaban == 1)
            {
                //textjawaban_1.text = TheSoal[RandomSoal].JawabanBenar;
                Gambarjawaban_1.sprite = TheSoal[RandomSoal].GambarJawabanBenar;
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_1 == Rand_2 || Rand_1 == Rand_3)
                {
                    Rand_1 = Random.Range(0, TheSoal[RandomSoal].GambarjawabanSalah.Length);
                }

                //textjawaban_1.text = TheSoal[RandomSoal].JawabanSalah[Rand_1];
                Gambarjawaban_1.sprite = TheSoal[RandomSoal].GambarjawabanSalah[Rand_1];
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => Salah());
            }
            // jawaban 2
            if (RandomJawaban == 2)
            {
                //textjawaban_1.text = TheSoal[RandomSoal].JawabanBenar;
                Gambarjawaban_2.sprite = TheSoal[RandomSoal].GambarJawabanBenar;
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_2 == Rand_1 || Rand_2 == Rand_3)
                {
                    Rand_2 = Random.Range(0, TheSoal[RandomSoal].GambarjawabanSalah.Length);
                }

                Gambarjawaban_2.sprite = TheSoal[RandomSoal].GambarjawabanSalah[Rand_2];
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => Salah());
            }
            // jawaban 3
            if (RandomJawaban == 3)
            {
                Gambarjawaban_3.sprite = TheSoal[RandomSoal].GambarJawabanBenar;
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_3 == Rand_2 || Rand_3 == Rand_1)
                {
                    Rand_3 = Random.Range(0, TheSoal[RandomSoal].GambarjawabanSalah.Length);
                }

                Gambarjawaban_3.sprite = TheSoal[RandomSoal].GambarjawabanSalah[Rand_3];
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => Salah());
            }

            // Remove Soal Dari List
            TheSoal.RemoveAt(RandomSoal);
        }
        else
        if (TheSoal.Count <= 0)
        {
            SceneManager.LoadScene("Score Scene Vhardcore");
        }

    }

    public void Benar()
    {
        Debug.Log("you Win Njenk");
        PlaySfx(SfxBenar);
        Jawaban.TheInstanceOfJawaban.JawabanBenar();
    }

    public void Salah()
    {
        Debug.Log("Loe Kalah Asuu");
        PlaySfx(SfxSalah);
        Jawaban.TheInstanceOfJawaban.JawabanSalah();
    }

    public void PlaySfx(AudioClip clip)
    {
        AudioSrc.PlayOneShot(clip);
    }
}