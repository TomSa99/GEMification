using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    public ReadInput readInputScript;

    public void printInput()
    {
        // Access the 'input' variable from the 'ReadInput' script
        string inputValue = readInputScript.input;
        Debug.Log("Value from ReadInput script: " + inputValue);
    }
}

