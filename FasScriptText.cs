using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FasScriptText : MonoBehaviour
{
    public static int FasNummer;
    public Text Fas;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fas.text = "Phase: " + FasNummer.ToString();
    }
}
