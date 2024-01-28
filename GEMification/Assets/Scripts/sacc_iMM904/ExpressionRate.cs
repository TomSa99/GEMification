using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class ExpressionRate : MonoBehaviour
{
    public ReadInput gene;
    public ReadInput value;
    public TextMeshProUGUI output;

    public void calculate()
    {

        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";

        var script = @"C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\ExpressionRate.py";
        var reaction = gene.input;
        var Value = value.num1;

        psi.Arguments = $"\"{script}\" \"{reaction}\" \"{Value}\"";

        //3) Process configurationc

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        // 4) Execute process and get output

        var errors = "";
        var results = "";

        using (var process = Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();
        }

        // 5) Display output

        UnityEngine.Debug.Log(results);
        UnityEngine.Debug.Log(errors);

        output.text = results;

    }

}
