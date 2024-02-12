from mewpy.simulation import get_simulator
import cobra
import sys

model = cobra.io.load_json_model(r'Assets/Resources/python_files/iMM904.json')

metabolite = sys.argv[1]
# metabolite = 'glu__L_c'

simul = get_simulator(model)

print(simul.find_metabolites(metabolite)['name'][0])
