from mewpy.simulation import get_simulator
import cobra

model = cobra.io.load_json_model(r'C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\iMM904.json')

simul = get_simulator(model)

result = simul.simulate(method='pFBA')

print('EX_trp__L_e flux before modification:',result.fluxes['EX_trp__L_e'])

# works
# Tryptophan
genes = ['YKL211C','YJR105W', 'YOL126C', 'YDR127W', 'YDR050C']
values = [32, 0, 0, 4, 0.5]

# genes = ['YKL211C', 'YJR105W', 'YDR127W', 'YDR050C', 'YAL060W', 'YBL015W']
# values = [32, 0, 4, 0.5, 0.1250, 0]

# not working
# Tryptophan
# genes = ['YOR095C', 'YDR380W', 'YCR032W', 'YJR057W', 'YPR074C']
# values = [16, 0, 0, 0, 4]

# genes = ['YOR095C', 'YCR032W', 'YJR057W', 'YNL169C', 'YPR074C', 'YOR136W']
# values = [16, 0, 0, 0, 8, 0]

# genes = ['YMR011W', 'YLR348C', 'YDL168W', 'YEL038W', 'YGL202W', 'YKR097W']
# values = [0, 0, 0, 0, 32, 0]

constraints = {}

for gene in genes:
    for reaction in simul.find_genes(gene)['reactions'][0]:
        vi = result.fluxes[reaction]
        p = values[genes.index(gene)]
        result.fluxes[reaction] = result.fluxes[reaction]*p
        new_value = result.fluxes[reaction]
        print(gene, reaction, new_value)
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

# new_simul.objective = 'EX_trp__L_e'

new_result = new_simul.simulate(method='pFBA')
print(new_result)

print('EX_trp__L_e flux after modification:',new_result.fluxes['EX_trp__L_e'])