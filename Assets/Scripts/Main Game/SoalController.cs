using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoalController : MonoBehaviour {
    private static SoalController Sc;
    public static SoalController TheInstanceOfSoalController
    {
        get
        {
            if(Sc == null)
            {
                Sc = FindObjectOfType<SoalController>();
            }
            return Sc;
        }
    }
    [Header ("Audio Component")]
    public AudioSource AudioSrc;
    public AudioClip SfxBenar;
    public AudioClip SfxSalah;
    [Header("Soal Gambar Pada Level")]
    public Image GambarSoal;
    [Header("Semua Button Jawaban")]
    public Button Jawaban_1;
    public Button Jawaban_2;
    public Button Jawaban_3;
    [Header("Semua Text Jawaban Pada Buttons")]
    public Text textjawaban_1;
    public Text textjawaban_2;
    public Text textjawaban_3;
    [Header("Scriptable Object Soal")]
    public List<Soal_Gambar> TheSoal;

    int Rand_1, Rand_2, Rand_3;

    private void Start()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();

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

            GambarSoal.sprite = TheSoal[RandomSoal].GambarSoal;

            int RandomJawaban = Random.Range(1, 4);
            // jawaban 1
            if (RandomJawaban == 1)
            {
                textjawaban_1.text = TheSoal[RandomSoal].JawabanBenar;
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_1 == Rand_2 || Rand_1 == Rand_3)
                {
                    Rand_1 = Random.Range(0, TheSoal[RandomSoal].JawabanSalah.Length);
                }

                textjawaban_1.text = TheSoal[RandomSoal].JawabanSalah[Rand_1];
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => Salah());
            }
            // jawaban 2
            if (RandomJawaban == 2)
            {
                textjawaban_2.text = TheSoal[RandomSoal].JawabanBenar;
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_2 == Rand_1 || Rand_2 == Rand_3)
                {
                    Rand_2 = Random.Range(0, TheSoal[RandomSoal].JawabanSalah.Length);
                }

                textjawaban_2.text = TheSoal[RandomSoal].JawabanSalah[Rand_2];
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => Salah());
            }
            // jawaban 3
            if (RandomJawaban == 3)
            {
                textjawaban_3.text = TheSoal[RandomSoal].JawabanBenar;
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => Benar());
            }
            else
            {
                while (Rand_3 == Rand_1 || Rand_3 == Rand_2)
                {
                    Rand_3 = Random.Range(0, TheSoal[RandomSoal].JawabanSalah.Length);
                }

                textjawaban_3.text = TheSoal[RandomSoal].JawabanSalah[Rand_3];
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => Salah());
            }

            // Remove Soal Dari List
            TheSoal.RemoveAt(RandomSoal);
        }
        else
        if (TheSoal.Count <= 0 )
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

