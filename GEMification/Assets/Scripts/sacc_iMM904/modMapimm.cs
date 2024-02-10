using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;

public class modMapimm : MonoBehaviour
{
    public ReadInput id;
    public ReadInput uptake;
    public ReadInput downtake;
    public ReadInput objective;
    public SaveBTNValues grperc;

    public void loadMap () 
    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        //psi.FileName = @"/bin/python3";
        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"GEMification/python_files/python.exe";

        // 2) Provide script and arguments

        // var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\map_imm_simulations.py";
        var script = @"GEMification/python_files/map_imm_simulations.py";
        var ID = id.input;
        var UpTake = uptake.num1;
        var DownTake = downtake.num2;
        var Goal = objective.input;
        var GrPerc = grperc.value;


        psi.Arguments = $"\"{script}\" \"{ID}\" \"{UpTake}\" \"{DownTake}\" \"{Goal}\" \"{GrPerc}\"";

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
    }

}
