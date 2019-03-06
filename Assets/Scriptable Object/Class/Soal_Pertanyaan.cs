using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Soal Pertanyaan" , menuName = "Soal Baru/Soal Pertanyaan")]
public class Soal_Pertanyaan : ScriptableObject {
    [Header("Soal Dalam Bentuk Text")]
    public string TextPertanyaan;
    [Header("Gambar Jawaban Yang Benar")]
    public Sprite GambarJawabanBenar;
    [Header("Gambar Jawaban Yang Salah Minimal 3")]
    public Sprite[] GambarjawabanSalah;

}
