from imm_simulations import new_result
from escher import Builder
import cobra
import pandas as pd
import webbrowser
import os
import sys
from simulations import simul

map_name = 'iMM904.Central carbon metabolism'
model_name = 'iMM904'
json_model_path = r'Assets/Resources/python_files/iMM904.json'
map_html = 'iMM904_moded.html'

reactions = sys.argv[1] # using the second argument [1] from psi.Arguments
reactions = reactions.split(', ')
# reactions = ['ANS', 'IGPS', 'ADNK1', 'MDH', 'DHQS', 'DHQTi', 'PSCVT','SHK3Dr','SHKK', 'TPI']

upperbound = sys.argv[2] # using the third argument [2] from psi.Arguments
upperbound = upperbound.split(', ')
upperbound = [float(i) for i in upperbound]
# upperbound = [999999.0, 999999.0, 0.0, 0.0, 999999.0, 999999.0, 999999.0, 999999.0, 999999.0, 4.4588847236047355, 0.2878657037040496]

perc = sys.argv[5] # using the sixth argument [5] from psi.Arguments
perc = float(perc.replace(',','.'))
# perc = 0.50
biomass_down = 0.2616123515269731 * perc

lowerbound = sys.argv[3] # using the fourth argument [3] from psi.Arguments
lowerbound = lowerbound.split(', ')
lowerbound = [float(i) for i in lowerbound]
# lowerbound = [0.2616123515269731, 0.2616123515269731, 0.0, 0.0, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, -999999.0, biomass_down]

goal = sys.argv[4] # using the fifth argument [4] from psi.Arguments
goal = goal.split(',')
# goal = 'EX_trp__L_e'

new_result = simul(json_model_path,reactions,upperbound,lowerbound,goal)

builder = Builder(
    map_name = map_name,
    model_name = model_name
)

#create the model, with the same model file as the builder, to use in mewpy
model = cobra.io.load_json_model(json_model_path)

df = pd.DataFrame(new_result.fluxes, index=['flux']).T

builder.reaction_data = df

# save the map as html
builder.save_html(map_html) # change to a variable instead of writing the file

# open the map in a browser
webbrowser.open('file://' + os.path.realpath(map_html))

