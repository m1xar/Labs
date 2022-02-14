def writeFile(name1):#функція заповнення нового файлу, або додавання до старого
    print("Create new file = 1")
    print("Edit file = 2")
    value = int(input())
    key = chr(7)
    if value == 1:
        with open(name1, 'w') as file:
            str = input("Enter the strings.\n" + "Press CTRL + G to end the file.'\n")
            while str[0] != key:
                file.write(str + '\n')
                str = input()
    elif value == 2:
        with open(name1, 'a') as file:
            str = input("Enter the strings.\n" +  "Press CTRL + G to end the file.\n")
            while str[0] != key:
                file.write(str + '\n')
                str = input()

def createSFile(name1, name2): #створення другого файлу
    file1 = open(name1, 'r')
    file2 = open(name2, 'w')
    for i in file1:
        line = i.split()
        for j in range(len(line)):
            if line[j] == '=':
                file2.write(line[j-1] + "\n")
    file1.close()
    file2.close()

def outputFile(name): #виведення вмісту файлу в консоль
    with open(name) as file:
        for line in file:
            print(line, end = "")

name1 = "FirstFile.txt"
name2 = "SecondFile.txt"
writeFile(name1)
createSFile(name1, name2)
print("First file:")
outputFile(name1)
print("Second file:")
outputFile(name2)