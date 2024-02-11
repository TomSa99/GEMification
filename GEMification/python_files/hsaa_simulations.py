from simulations import simul
import sys

# json_model_path = r'/home/toms/escher_python/RECON1.json' # eventually will be an sys.argv
json_model_path = r'python_files\RECON1.json'
id = sys.argv[1] # using the second argument [1] from psi.Arguments
uptake = float(sys.argv[2]) # using the third argument [2] from psi.Arguments
downtake = float(sys.argv[3]) # using the fourth argument [3] from psi.Arguments

#id = 'EX_glc__D_e'
#uptake = 0.0
#downtake = 0.0

simul(json_model_path,id,uptake,downtake)