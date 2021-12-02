
input = open("Day2/input.txt", "r")
print(input)
horizontalPos = 0
depth = 0
aim = 0

for action in input:
    split = action.split(' ')
    action = split[0]
    distance = int(split[1])

    if action == 'forward':
        horizontalPos += distance
        depth += aim * distance
    elif action == 'down':
        aim += distance
    else:
        aim -= distance

print(horizontalPos * depth)