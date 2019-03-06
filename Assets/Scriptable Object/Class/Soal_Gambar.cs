using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Soal Gambar", menuName = "Soal Baru/Soal Gambar" )]
public class Soal_Gambar : ScriptableObject{
    [Header("Soal Dalam Bentuk Gambar")]
    public Sprite GambarSoal;
    [Header("Jawaban Yang Benar")]
    public string JawabanBenar;
    [Header("Jawaban Yang Salah Minimal 3")]
    public string[] JawabanSalah;
}
