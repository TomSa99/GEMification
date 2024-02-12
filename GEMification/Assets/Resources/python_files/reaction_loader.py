import escher
from escher import Builder
import mewpy
from mewpy.simulation import get_simulator
import cobra
import pandas as pd
import webbrowser
import os

builder = Builder(
    map_name='e_coli_core.Core metabolism',
    model_name='e_coli_core',
)

model = cobra.io.load_json_model(r'Assets/Resources/python_files/e_coli_core.json')

simul = get_simulator(model)

envcond = {'RPI': (0,0)}

simul_ethanol = get_simulator(model,envcond=envcond)

result_ethanol = simul_ethanol.simulate(method='FBA')

df = pd.DataFrame(result_ethanol.fluxes, index=['flux']).T

builder.reaction_data = df

builder.save_html('reactions_ethanol.html')

webbrowser.open('file://' + os.path.realpath('reactions_ethanol.html'))


def builder_map (map_name, model_name, json_model_path, id, uptake, downtake, map_html):
    # create the builder with escher with the map name and model name
    builder = Builder(
        map_name = map_name,
        model_name = model_name
    )

    #create the model, with the same model file as the builder, to use in mewpy
    model = cobra.io.load_json_model(json_model_path)

    envcond = {id:(uptake, downtake)}

    # build a phenotype simulation
    simul = get_simulator(model, envcond=envcond)

    result = simul.simulate(method='FBA')

    df = pd.DataFrame(result.fluxes, index=['flux']).T

    builder.reaction_data = df

    # save the map as html
    builder.save_html(map_html) # change to a variable instead of writing the file

    # open the map in a browser
    # builder.display_in_browser() only works in Jupyter Notebook
    webbrowser.open('file://' + os.path.realpath(map_html)) # change to a variable instead of writing the file