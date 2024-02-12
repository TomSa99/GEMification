import mewpy
from mewpy.simulation import get_simulator
import cobra
import pandas as pd

# model = cobra.io.load_json_model(r'/home/toms/escher_python/e_coli_core.json')
model = cobra.io.load_json_model(r'Assets/Resources/python_files/e_coli_core.json')


simul = get_simulator(model)

pd.set_option('display.max_rows', None)
pd.set_option('display.max_columns', None)
pd.set_option('display.width', None)
pd.set_option('display.max_colwidth', None)

print(simul.find_genes())