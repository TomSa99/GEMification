import escher
from escher import Builder
import mewpy
import cobra
import sys

model = cobra.io.load_json_model(r'C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\iMM904.json')

from mewpy.simulation import get_simulator
simul = get_simulator(model)

result = simul.simulate(method='FBA')
# print(result)

# genes = sys.argv[1]
# values = sys.argv[2]

# Tryptophan
genes = ['YKL211C','YJR105W', 'YOL126C', 'YDR127W', 'YDR050C'] 
# genes = ['YOR095C', 'YDR380W', 'YCR032W', 'YJR057W', 'YPR074C', 'YIL010W']

# Phenylalanine
# genes = ['YMR011W', 'YLR348C', 'YGR185C', 'YDL015C', 'YGL202W', 'YDR536W']

# Tryptophan
values = [32, 0, 0, 4, 0.5]
# values = [16, 0, 0, 0, 4, 0]

# Phenylalanine
# values = [0, 0, 0, 0, 16, 0]

constraints = {}

for gene in genes:
    for reaction in simul.find_genes(gene)['reactions'][0]:
        vi = result.fluxes[reaction]
        p = values[genes.index(gene)]
        result.fluxes[reaction] = result.fluxes[reaction]*p
        new_value = result.fluxes[reaction]
        # print(gene, reaction, new_value)
        if p < 1 and vi > 0:
            constraints[reaction] = (0.0, new_value)
        elif p < 1 and vi < 0:
            constraints[reaction] = (new_value,0.0)
        elif p > 1 and vi > 0:
            constraints[reaction] = (new_value, 999999.0)
        elif p > 1 and vi < 0:
            constraints[reaction] = (-999999.0, new_value)
        else:
            constraints[reaction] = (0.0, 0.0)

print(constraints)

new_simul = get_simulator(model, constraints=constraints)

new_result = new_simul.simulate(method='pFBA')
print(new_result)