import sys
import json
import random
import re
import math
from shapely.geometry import Polygon, Point
from operator import itemgetter 

def get_random_point_in_polygon(poly):
     minx, miny, maxx, maxy = poly.bounds
     while True:
         p = Point(random.uniform(minx, maxx), random.uniform(miny, maxy))
         if poly.contains(p):
             return p


# p = Polygon([(0, 0), (0, 2), (1, 1), (2, 2), (2, 0), (1, 1), (0, 0)])
# point_in_poly = get_random_point_in_polygon(p)

mc_list = []
res_list = []
shopCount = 6355

with open('C:/Dev/hackaton/praha_areas.json', encoding='utf-8') as json_file:
	data = json.load(json_file)
	for f in data['features']:
		p = f['properties']
		mc = p['NAZEV_MC']

		coords_list = []
		mc_polygon_coords = f['geometry']['coordinates'][0]
		
		for c in mc_polygon_coords:
			c_tuple = tuple(c)
			coords_list.append(c_tuple)

		mc_polygon = Polygon(coords_list)
		
		shortId = ''
		x = re.search(r'\d+', mc)
		if x is not None: 
			shortId = int(x.group())
		else: 
			shortId = int(ord(mc[6]))

		mc_dict = {
			"id": shortId,
			"prague_part": mc,
			"polygon": mc_polygon,
			"coefficient": 0
		}

		mc_list.append(mc_dict)

ordered_mc_list = sorted(mc_list, key=itemgetter("id"))

d = 49
ordered_mc_list[0]['coefficient'] = 0.2

for i in range(1,8):
	ordered_mc_list[i]['coefficient'] = 0.1

min_coef = 0.1/sum(range(48))

for i in range(8, 57):
	ordered_mc_list[i]['coefficient'] = d * min_coef
	d -= 1

for i in ordered_mc_list:
	# print(i["prague_part"])
	# print(i["coefficient"])
	i['shop_num'] = math.ceil(shopCount * i['coefficient'])

ordered_mc_list[0]['shop_num'] -= sum([i['shop_num'] for i in ordered_mc_list]) - shopCount

for i in ordered_mc_list:
	shops_coords = []

	for j in range(i['shop_num']):
		shop_point = get_random_point_in_polygon(i['polygon'])
		shops_coords.append(shop_point.coords[:][0])

	i['shops_coords'] = shops_coords

d = 0 
for idx, i in enumerate(ordered_mc_list):
	i['id'] = idx
	d += 1
	del i['polygon']
	del i['coefficient']

result = {
	"test": "test",
	"result": ordered_mc_list
}

with open('shop_points.json', 'w') as result_file: 
	json.dump(result, result_file)
