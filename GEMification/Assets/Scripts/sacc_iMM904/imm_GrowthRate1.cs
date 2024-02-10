using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class imm_GrowthRate1 : MonoBehaviour
{
    public ReadInput id;
    public ReadInput uptake;
    public ReadInput downtake;
    public ReadInput objective;
    public SaveBTNValues grperc;

    // create the oublic variable to choose the output text
    public TextMeshProUGUI output;
    
    public void runSimulations ()

    {
        // 1) Create Process Info

        var psi = new ProcessStartInfo();
        // psi.FileName = @"C:\Users\toma_\AppData\Local\Programs\Python\Python39\python.exe";
        psi.FileName = @"GEMification/python_files/python.exe";

	    if (string.IsNullOrEmpty(id.input)) // tenho de mudar isto porque agora a string n�o fica nula, fica [,]
	    {
           // 2) Provide script and arguments
        
           //var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\imm_growthrate.py";
           var script = @"GEMification/python_files/imm_growthrate.py";

           psi.Arguments = $"\"{script}\"";
        }
        else
        {
           // var script = @"C:\Users\toma_\OneDrive\�rea de Trabalho\escher_python\imm_simulations.py";
           var script = @"GEMification/python_files/imm_simulations.py";
           var ID = id.input;
           var UpTake = uptake.num1;
           var DownTake = downtake.num2;
           var Goal = objective.input;
           var GrPerc = grperc.value;
           
           psi.Arguments = $"\"{script}\" \"{ID}\" \"{UpTake}\" \"{DownTake}\" \"{Goal}\" \"{GrPerc}\"";
           UnityEngine.Debug.Log($"ID: {ID}, uptake: {UpTake}, downtake: {DownTake}, objective: {Goal}, growth percentage: {GrPerc}");
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
