using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

using UnityEngine;
using TMPro;

public class ecc_GrowthRate : MonoBehaviour
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
        psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";

        if (string.IsNullOrEmpty(id.input))
	{
           // 2) Provide script and arguments
        
           //var script = @"/home/toms/escher_python/ecc_growthrate.py";
           var script = @"C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\ecc_growthrate.py";
           psi.Arguments = $"\"{script}\"";
        }
        else
        {
           //var script = @"/home/toms/escher_python/ecc_simulations.py";
           var script = @"C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\ecc_simulations.py";
           List<object> condition = new List<object>();
           var ID = id.input;
           var UpTake = uptake.num1;
           var DownTake = downtake.num2;
           condition.Add(ID); 
           condition.Add(UpTake);
           condition.Add(DownTake);

           // Serialize the condition list to JSON using JSON.NET
           string conditionJson = JsonConvert.SerializeObject(condition);

           psi.Arguments = $"\"{script}\" \"{conditionJson}\"";

           UnityEngine.Debug.Log(conditionJson);

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
