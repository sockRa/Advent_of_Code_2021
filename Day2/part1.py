
input = open("Day2\input.txt", "r")

horizontalPos = 0
depth = 0

# Foreach row
for action in input:
    split = action.split(' ')
    action = split[0]
    distance = int(split[1])

    if action == 'forward':
        horizontalPos += distance
    elif action == 'down':
        depth += distance
    else:
        depth -= distance

# loop complete
print(horizontalPos * depth)