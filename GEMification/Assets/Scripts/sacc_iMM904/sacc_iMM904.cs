using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor;
using UnityEngine;

public class sacc_iMM904 : MonoBehaviour
{
    public void loadEscherMap ()
 
    {
        //System.IO.Directory.SetCurrentDirectory("GEMification/GEMification");

        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        //psi.FileName = @"/bin/python3";
        // psi.FileName = @"Assets/Resources/python_files/python.exe";
        psi.FileName = Application.dataPath + "/Resources/python_files/python.exe";
        // psi.FileName = @"C:/Users/toma_/OneDrive/Área de Trabalho/GEMification/GEMification/Assets/Resources/python_files/python.exe";


        // 2) Provide script and arguments

        // var script = @"Assets/Resources/python_files/sacc_iMM904.py";
        var script = Application.dataPath + "/Resources/python_files/sacc_iMM904.py";
        // var script = @"C:/Users/toma_/OneDrive/Área de Trabalho/GEMification/GEMification/Assets/Resources/python_files/sacc_iMM904.py";

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

        UnityEngine.Debug.Log(psi.FileName) ;

        Console.ReadLine();


        
    }
}
