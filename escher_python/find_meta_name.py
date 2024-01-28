from mewpy.simulation import get_simulator
import cobra
import sys

model = cobra.io.load_json_model(r'C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\iMM904.json')

metabolite = sys.argv[1]
# metabolite = 'glu__L_c'

simul = get_simulator(model)

print(simul.find_metabolites(metabolite)['name'][0])
