with open ('c:/repo/homeworks/FS_Python/practice_4/berries.txt', 'r') as source:
    bed = source.read()
bed = bed.replace(' ','').split(',')
bed = [int(i) for i in bed]
print(f"На грядке есть такие кусты {bed}")
size = len(bed)
current = 0
max = bed[0] + bed[size-1] + bed[size-2]
max_index = 0
for i in range(1, size-1):
    current = bed[i-1] + bed[i] + bed[i+1]
    if current > max:
        max = current
        max_index = i+1

print(f"Большего всего ягод можно собрать при подхое к {max_index} кусту \nЭто {max} ягоды")