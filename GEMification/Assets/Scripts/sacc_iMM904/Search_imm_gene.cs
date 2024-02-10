using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Search_gene : MonoBehaviour
{
    public ReadInput code;
    public TextMeshProUGUI output;

    private float startTime;
    private float endTime;
    public Slider LoadingBar;

    // Start is called before the first frame update
    public void search()
    {
        // Record time that it takes for the event to happen
        startTime = Time.time;
        UnityEngine.Debug.Log(startTime);

        var gene = code.input;
        string url = $"https://www.uniprot.org/uniprotkb?query={gene}&facets=model_organism%3A559292";

        Process.Start(url);

        var psi = new ProcessStartInfo();


        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"python_files/python.exe";

        //var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\find_reactions.py";
        var script = @"python_files/find_reactions.py";
        psi.Arguments = $"\"{script}\" \"{gene}\"";


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

        endTime = Time.time;
        UnityEngine.Debug.Log(endTime);

        output.text = results;

    }
}
