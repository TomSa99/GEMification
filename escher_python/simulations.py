from escher import Builder
from mewpy.simulation import get_simulator
import cobra
import sys

def simul(json_model_path,reactions,upperbound,lowerbound,goal):
    #create the model, with the same model file as the builder, to use in mewpy
    model = cobra.io.load_json_model(json_model_path)
    # create the environment condition
    envcond = {}
    for reaction in range(len(reactions)):
        envcond[reactions[reaction]] = (lowerbound[reaction], upperbound[reaction])
    # create a new simulation with the environment condition
    new_simul = get_simulator(model, envcond=envcond)
    # set the objective function
    new_simul.objective = goal
    # simulate growth rate
    new_result = new_simul.simulate(method = 'pFBA')
    return new_result