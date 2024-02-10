using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;
using TMPro;

public class GRModed : MonoBehaviour
{
    // create the oublic variable to choose the output text
    public TextMeshProUGUI output;

    public void runGrowthRate()

    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"GEMification/python_files/python.exe";

        // 2) Provide script and arguments

        // var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\CompleteER.py";
        var script = @"GEMification/python_files/CompleteER.py";

        psi.Arguments = $"\"{script}\"";

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

