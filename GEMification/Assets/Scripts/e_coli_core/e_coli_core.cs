using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;

public class e_coli_core : MonoBehaviour
{
    public void loadEscherMap ()

    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        //psi.FileName = @"/bin/python3";
        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"python_files/python.exe";

        // 2) Provide script and arguments

        //var script = @"/home/toms/escher_python/e_coli_core.py";
        // var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\e_coli_core.py";
        var script = @"python_files/e_coli_core.py";

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
        
        // Split the results string into lines
        string[] lines = results.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        // Get the last line
        string lastLine = lines[lines.Length - 1];

        // Print the last line using UnityEngine.Debug.Log
        UnityEngine.Debug.Log(lastLine);
        //UnityEngine.Debug.Log(errors);
        //UnityEngine.Debug.Log(results);

        Console.ReadLine();




        
    }
}
