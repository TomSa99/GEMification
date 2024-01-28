using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    
    public string input;
    public string num1;
    public string num2;

    public List<string> inputList = new List<string>();
    public List<string> num1List = new List<string>();
    public List<string> num2List = new List<string>();

    public void ReadStringInput (string s)
    {
       
       input = s;
       inputList.Add(s);
       input = string.Join(", ", inputList);
       Debug.Log(input);

    }
    
    public void ReadIntInput (string s)
    {
        num1 = s;
        num1List.Add(num1);
        num1 = string.Join(", ", num1List);
        Debug.Log(num1);       
    
    }
    
    public void ReadIntInput2 (string s)
    {

        num2 = s;
        num2List.Add(num2);
        num2 = string.Join(", ", num2List);
        Debug.Log(num2);       
    
    }

    public void ResetInputs()
    {
        inputList.Clear();
        num1List.Clear();
        num2List.Clear();
    }

}
