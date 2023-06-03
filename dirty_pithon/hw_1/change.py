from random import randint

some_number = str(randint(100,10000))
print(some_number)
temp_list = []
for i in range (len(some_number)):
    temp_list.append(some_number[i])
print(temp_list)
temp_list[0],temp_list[-1] = temp_list[-1], temp_list[0]
print(temp_list)
some_number= ''
for item in temp_list:
    some_number += item
print(some_number)
