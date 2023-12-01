using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class aprendizaje : MonoBehaviour
{
    public TextMeshProUGUI learn;
    public int aprendizajePorcent;
    public float ultimoframe = 0;
    public static aprendizaje Instance;

    // Start is called before the first frame update
    void Start()
    {
    }
    public int Porcentaje()
    { return aprendizajePorcent; }

    // Update is called once per frame
    void Update()
    {
        learn.text ="Aprendizaje: " + aprendizajePorcent.ToString() +"%";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ultimoframe += Time.deltaTime;
        if (ultimoframe > 2)
        {
            aprendizajePorcent += 5;
            PlayerPrefs.SetInt("Aprendizaje", aprendizajePorcent);
            PlayerPrefs.Save();
            ultimoframe = 0f;
        }
    }

}
