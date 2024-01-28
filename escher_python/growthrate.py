from escher import Builder
from mewpy.simulation import get_simulator
import cobra
import sys


def growth_rate(json_model_path, method):

    #create the model, with the same model file as the builder, to use in mewpy
    model = cobra.io.load_json_model(json_model_path)

    # build a phenotype simulation
    simul = get_simulator(model)

    # simulate growth rate
    print(simul.simulate(method = method))