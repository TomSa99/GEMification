from simulations2 import simul
import sys
import json

# json_model_path = r'/home/toms/escher_python/e_coli_core.json' # eventually will be an sys.argv
json_model_path = r'Assets/Resources/python_files/e_coli_core.json'
# id = sys.argv[1] # using the second argument [1] from psi.Arguments
# uptake = float(sys.argv[2]) # using the third argument [2] from psi.Arguments
# downtake = float(sys.argv[3]) # using the fourth argument [3] from psi.Arguments

conditions = sys.argv[1] # using all arguments from psi.Arguments
# Deserialize the JSON string into a Python list
conditions = json.loads(conditions)

# conditions = ['EX_glc__D_e', 0, 0]
# print(conditions)
simul(json_model_path,conditions)