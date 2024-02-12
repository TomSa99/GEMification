import escher
from escher import Builder
import mewpy
import cobra
import sys


model = cobra.io.load_json_model(r'Assets/Resources/python_files/iMM904.json')

from mewpy.simulation import get_simulator
simul = get_simulator(model)

result = simul.simulate(method='pFBA')


# Tryptophan
# reactions = ['ANS', 'IGPS', 'ADNK1', 'MDH', 'DHQS', 'DHQTi', 'PSCVT', 'SHK3Dr', 'SHKK', 'TPI']
# genes = ['YKL211C','YJR105W', 'YOL126C', 'YDR127W', 'YDR050C']
# genes = ['YOR095C', 'YDR380W', 'YCR032W', 'YJR057W', 'YPR074C', 'YIL010W']

genes = sys.argv[1]
genes = genes.split(', ')
# print(genes)

# # Tryptophan
# values = [32, 32, 0, 0, 4, 4, 4, 4, 4, 0.5]
# values = [32, 0, 0, 4, 0.5]
# values = [16, 0, 0, 0, 4, 0]

values = sys.argv[2]
values = values.split(', ')
values = [float(i) for i in values]
# print(values)


# for reaction in reactions:
for gene in genes:
    for reaction in simul.find_genes(gene)['reactions'][0]:
        vi = result.fluxes[reaction]
        p = values[genes.index(gene)]
        result.fluxes[reaction] = result.fluxes[reaction]*p
        new_value = result.fluxes[reaction]
        print(f"{gene} / {reaction} / {new_value}")