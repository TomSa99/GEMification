using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModelLoade : MonoBehaviour
{

    public TMPro.TMP_Dropdown myDrop;
    
    public void ChooseModel()
    {
        if (myDrop.value == 1) {
            SceneManager.LoadScene(6);
        }
        else if (myDrop.value == 2) {
            SceneManager.LoadScene(7);
        }
        else if (myDrop.value == 3) {
            SceneManager.LoadScene(8);
        }
    }

}
