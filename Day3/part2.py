from os import remove


input = open("Day3/input.txt", "r")

co2Raiting = 0
oxygenGeneratorRating = 0
x = 0
i = 0
zeroCount = 0
oneCount = 0

allRows = input.readlines()
rowLength = len(allRows[0]) - 1
    
oxygenList = allRows.copy()
co2List = allRows.copy()

# loop through the list row length times
while x < rowLength:

    # get each row and check if zero or one occurs more often in that column
    for row in oxygenList:
        if(row[x] == "0"):
            zeroCount += 1
        else:
            oneCount += 1

    removeOnes = False

    if(zeroCount > oneCount):
        removeOnes = True

    tempOxygenRows = oxygenList.copy()
    # determine which rows to save
    for row in tempOxygenRows:
        digit = row[x]
        if((removeOnes and digit == "1") or (not removeOnes and digit == "0")):
            oxygenList.remove(row)

    if(len(oxygenList) == 1):
        oxygenGeneratorRating = int(oxygenList[0], 2)
        break

    x += 1
    zeroCount = 0
    oneCount = 0

x = 0
while x < rowLength:

    for row in co2List:
        if(row[x] == "0"):
            zeroCount += 1
        else:
            oneCount += 1
    
    removeOnes = False

    if(zeroCount > oneCount):
        removeOnes = True

    tempCo2Rows = co2List.copy()
    for row in tempCo2Rows:
        digit = row[x]
        if((removeOnes and digit == "0") or (not removeOnes and digit == "1")):
            co2List.remove(row)

    if(len(co2List) == 1):
        co2Raiting = int(co2List[0], 2)
        break

    x += 1
    zeroCount = 0
    oneCount = 0

print(co2Raiting * oxygenGeneratorRating)