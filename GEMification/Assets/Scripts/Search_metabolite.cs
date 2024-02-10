using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Search_metabolite : MonoBehaviour
{
    public ReadInput code;
    public TextMeshProUGUI output;

    // Start is called before the first frame update
    public void search()
    {
        var metabolite = code.input;
        string url = $"http://bigg.ucsd.edu/models/iMM904/metabolites/{metabolite}";

        Process.Start(url);

        var psi = new ProcessStartInfo();

        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"GEMification/python_files/python.exe";

        // var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\find_meta_name.py";
        var script = @"GEMification/python_files/find_meta_name.py";
        psi.Arguments = $"\"{script}\" \"{metabolite}\"";


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
