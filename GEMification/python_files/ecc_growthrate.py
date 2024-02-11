from growthrate import growth_rate

# json_model_path = r'/home/toms/escher_python/e_coli_core.json'
json_model_path = r'python_files\e_coli_core.json'
method = "FBA"

growth_rate(json_model_path, method)