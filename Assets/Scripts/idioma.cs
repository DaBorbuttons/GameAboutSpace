using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class idioma : MonoBehaviour
{
    private string lenguaje;
    public string español, ingles;
    private Text texto;
    void Start()
    {
        texto = GetComponent<Text>();
        lenguaje = Application.systemLanguage.ToString();
        Debug.Log(lenguaje);

    }
    
    // Update is called once per frame
    void Update()
    {
       
        switch (lenguaje)
        {
            case "Spanish":
                texto.text = español;
               
                break;
            case "English":
                texto.text = ingles;
                break;
        }
    }
}
