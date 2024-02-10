using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;
using TMPro;

public class hsaa_GrowthRate : MonoBehaviour
{
    public ReadInput id;
    public ReadInput uptake;
    public ReadInput downtake;

    // create the oublic variable to choose the output text
    public TextMeshProUGUI output;
    
    public void runSimulations ()

    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        //psi.FileName = @"/bin/python3";
        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"GEMification/python_files/python.exe";

	if (string.IsNullOrEmpty(id.input))
	{
            // 2) Provide script and arguments

            //var script = @"/home/toms/escher_python/hsaa_growthrate.py";
            //var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\hsaa_growthrate.py";
            var script = @"GEMification/python_files/hsaa_growthrate.py";

            psi.Arguments = $"\"{script}\"";
        }
        else
        {
            //var script = @"/home/toms/escher_python/hsaa_simulations.py";
            //var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\hsaa_simulations.py";
            var script = @"GEMification/python_files/hsaa_simulations.py";
            var ID = id.input;
            var UpTake = uptake.num1;
            var DownTake = downtake.num2;
           
            psi.Arguments = $"\"{script}\" \"{ID}\" \"{UpTake}\" \"{DownTake}\"";
            UnityEngine.Debug.Log($"ID: {id.input}, uptake: {UpTake}, downtake: {DownTake}");
        }

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
