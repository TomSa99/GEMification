# import subprocess

# subprocess.run(['pip', 'install', 'escher'])
# subprocess.run(['pip', 'install', 'markupsafe == 1.1.1'])

# import markupsafe
# print(markupsafe.__version__)


from escher import Builder
from mewpy.simulation import get_simulator
import cobra
import webbrowser
import os
import pandas as pd


def builder_map (map_name, model_name, json_model_path, map_html):
    # create the builder with escher with the map name and model name
    builder = Builder(
        map_name = map_name,
        model_name = model_name
    )

    #create the model, with the same model file as the builder, to use in mewpy
    model = cobra.io.load_json_model(json_model_path)

    # build a phenotype simulation
    simul = get_simulator(model)

    result = simul.simulate(method = 'pFBA')

    df = pd.DataFrame(result.fluxes, index=['flux']).T

    builder.reaction_data = df

    # save the map as html
    builder.save_html(map_html) 

    # open the map in a browser
    # builder.display_in_browser() only works in Jupyter Notebook
    webbrowser.open('file://' + os.path.realpath(map_html)) 

    print('done!')
