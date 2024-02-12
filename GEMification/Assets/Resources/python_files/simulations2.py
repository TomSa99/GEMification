from escher import Builder
from mewpy.simulation import get_simulator
import cobra
import sys

def simul(json_model_path,conditions):
    #create the model, with the same model file as the builder, to use in mewpy
    model = cobra.io.load_json_model(json_model_path)
    # build a phenotype simulation
    simul = get_simulator(model)

    # Initialize an empty dictionary
    conditions_dict = {}

    # Iterate through the list in steps of 3
    for i in range(0, len(conditions), 3):
        key = conditions[i]
        values = (conditions[i + 1], conditions[i + 2])
        conditions_dict[key] = values
    
    for id, (uptake, downtake) in conditions_dict.items():
        # create the environment condition
        envcond = {id:(uptake, downtake)}
        # create a new simulation with the environment condition
        new_simul = get_simulator(model, envcond=envcond)
        
    # simulate growth rate
    print(new_simul.simulate(method = 'FBA'))


# conditions = ['EX_glc__D_e', -10, 0, 'EX_o2_e', -20, 0]

# json_model_path = r'C:\Users\toma_\OneDrive\Área de Trabalho\escher_python\e_coli_core.json'

# simul(json_model_path,conditions)
