using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nametext;
    public void SetName()
    {
        if (JsonClass.instance.UserName == "" || JsonClass.instance.UserName == null)
        {
            Debug.Log(nametext.text);
            JsonClass.instance.UserName = "BAD NAME";
        }
        else
        {
            JsonClass.instance.UserName = nametext.text;
        }

        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
