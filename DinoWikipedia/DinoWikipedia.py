import re

with open('List_of_dinosaur_genera.xml', mode='r', encoding='utf-8') as dinosaur_xml:
    dinosaur_xml_content = dinosaur_xml.read()
    
genera_pattern = re.compile(r'\* (?:"|'')\[\[([A-Z][a-z]+)\]\](?:"|'')')
dinosaur_genera_list = genera_pattern.findall(dinosaur_xml_content)
dinosaur_genera_joined = ',\n'.join(dinosaur_genera_list)

with open('List_of_dinosaur_genera.output', mode='w', encoding='utf-8') as dinosaur_output:
    dinosaur_output.write(dinosaur_genera_joined)