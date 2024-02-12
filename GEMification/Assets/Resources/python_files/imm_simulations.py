from simulations import simul
import sys

json_model_path = r'Assets/Resources/python_files/iMM904.json'

reactions = sys.argv[1] # using the second argument [1] from psi.Arguments
reactions = reactions.split(', ')
reactions.append('BIOMASS_SC5_notrace')
# reactions = ['ANS', 'IGPS', 'ADNK1', 'MDH', 'DHQS', 'DHQTi', 'PSCVT','SHK3Dr','SHKK', 'TPI','BIOMASS_SC5_notrace']

upperbound = sys.argv[2] # using the third argument [2] from psi.Arguments
upperbound = upperbound.split(', ')
upperbound = [float(i) for i in upperbound]
upperbound.append(0.2878657037040496)
# upperbound = [999999.0, 999999.0, 0.0, 0.0, 999999.0, 999999.0, 999999.0, 999999.0, 999999.0, 4.4588847236047355, 0.2878657037040496]

perc = sys.argv[5] # using the sixth argument [5] from psi.Arguments
perc = float(perc.replace(',','.'))
# perc = 0.50
biomass_down = 0.2616123515269731 * perc

lowerbound = sys.argv[3] # using the fourth argument [3] from psi.Arguments
lowerbound = lowerbound.split(', ')
lowerbound = [float(i) for i in lowerbound]
lowerbound.append(biomass_down)
# lowerbound = [0.2616123515269731, 0.2616123515269731, 0.0, 0.0, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, 0.30433162195677366, -999999.0, biomass_down]

goal = sys.argv[4] # using the fifth argument [4] from psi.Arguments
# goal = 'EX_trp__L_e'

new_result = simul(json_model_path,reactions,upperbound,lowerbound,goal)
print(new_result)
print('EX_trp__L_e:', new_result.fluxes['EX_trp__L_e'])
print('BIOMASS_SC5_notrace:',new_result.fluxes['BIOMASS_SC5_notrace'])
