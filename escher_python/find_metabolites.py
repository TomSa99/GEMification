from mewpy.simulation import get_simulator
import cobra
import sys

model = cobra.io.load_json_model(r'C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\iMM904.json')

reaction = sys.argv[1]
# reaction = 'ANS'

simul = get_simulator(model)

print(simul.find_reactions(reaction)['name'][0])
print(simul.find_reactions(reaction)['stoichiometry'][0])
