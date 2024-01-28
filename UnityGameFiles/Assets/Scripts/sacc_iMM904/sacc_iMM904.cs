using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;

public class sacc_iMM904 : MonoBehaviour
{
    public void loadEscherMap ()
 
    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        //psi.FileName = @"/bin/python3";
        psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";

        // 2) Provide script and arguments

        var script = @"C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\sacc_iMM904.py";

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

        Console.WriteLine("ERRORS:");
        Console.WriteLine(errors);
        Console.WriteLine();
        Console.WriteLine("Results:");
        Console.WriteLine(results);



        Console.ReadLine();


        
    }
}
