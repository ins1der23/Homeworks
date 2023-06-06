# new_list = ['1', '57', '45', 'gh', 'e6', 'e2',
#             '688', '24', '12', '32', 'fghj', '235', 'r6']
# print(new_list)
# filtered_list = list(filter(lambda x: x.isdigit(), new_list))
# print(filtered_list)
# mapped_list = list(map(lambda x: int(x), filtered_list))
# print(mapped_list)
# mapped_list.sort(key=lambda x: x % 2 == 0, reverse=1)
# print(mapped_list)


current_list = [[10,6,9],[0, 14, 16, 80],[8, 12, 30, 44]]
print(current_list)
sorted_list = lambda x: (sorted(i) for i in x)
second_largest = lambda x, func: [y[len(y)-2] for y in func(x)]

result = second_largest(current_list, sorted_list)
print(result)