input = open("Day3/input.txt", "r")

gammaRate = ""
epsilonRate = ""
# Gamma * Epsilon
powerConsumption = 0

allRows = input.readlines()
rowLength = len(allRows[0]) - 1
i = 0
zeroCount = 0
oneCount = 0

# Loop through each row, length of one row times
while i < rowLength:
    # Get each row
    for rows in allRows:
        digit = rows[i]

        if(digit == "0"):
            zeroCount += 1
        else:
            oneCount += 1
    
    if(zeroCount > oneCount):
        gammaRate += "0"
        epsilonRate += "1"
    else:
        gammaRate += "1"
        epsilonRate += "0"
    
    i += 1
    zeroCount = 0
    oneCount = 0


# Convert strings to digits
gammaRate = int(gammaRate, 2)
epsilonRate = int(epsilonRate, 2)

print(gammaRate * epsilonRate)
