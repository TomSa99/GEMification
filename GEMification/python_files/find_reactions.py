import mewpy
from mewpy.simulation import get_simulator
import cobra
import sys
import webbrowser


model = cobra.io.load_json_model(r'python_files\iMM904.json')

nome = sys.argv[1]
# gene = 'b2296'
# nome = 'TRP3'

simul = get_simulator(model)

for idx, gene in enumerate(simul.find_genes()['name']):
    if gene == nome:
        gene_id = simul.find_genes()['name'].index[idx]
        print(f'Gene ID: {gene_id}')

reactions = simul.find_genes(gene_id)['reactions'][0]
# print(reactions)

result = simul.simulate(method='pFBA')
listToStr = ' '.join(map(str, reactions))

print('Reactions:')
for reaction in reactions:
    value = result.fluxes[reaction]
    print(f'{reaction}: {value}')