using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class loadtext : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textstartMenu;

    
    void Start()
    {
        textstartMenu = GetComponent<TextMeshProUGUI>();

        JsonClass.DataGame data = JsonClass.instance.CheckSavedData();
        textstartMenu.text = "Best score: "+  data.Name + " " + data.score;
    }

}
