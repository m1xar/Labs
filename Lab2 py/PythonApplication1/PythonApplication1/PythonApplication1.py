def set_file(n, file_name):
    value = int(input("Press 1 to created new file, or 2 to edit an existing one: "))
    i = 0
    books = []
    while i < n:
        c_book = []
        name = input("Input name of book: ")
        date = input("Input writing date of book: ")
        pub_year = input("Input year of publication: ")
        c_book.append(name)
        c_book.append(date)
        c_book.append(pub_year)
        books.append(c_book)
        i += 1
    if value == 1:
        with open(file_name, 'wb') as file:
            for i in books:
                file.write((' '.join(i)+ '\n').encode())
    elif value == 2:
        with open(file_name, 'ab') as file:
            for i in books:
                file.write((' '.join(i)+ '\n').encode())


def output_file(file_name):
    with open(file_name, 'rb') as file:
        for line in file:
            line_utf = line.decode('utf-8')
            print(line_utf, end = '')

def winter_books(file_name):
    with open(file_name, 'rb') as file:
        num = 0
        for i in file:
            i_utf = i.decode('utf-8')
            line = i_utf.split(' ')
            date = line[1].split('.')
            if int(date[1][1]) == 2 or (int(date[1][0]) == 0 and int(date[1][1]) == 1):
                num +=1
        print("Number of winter books is equal to: ", num)

def create_file(fileName1, fileName2):
    with open(fileName1, 'rb') as file1:
        with open(fileName2, 'wb') as file2:
            for i in file1:
                i_utf = i.decode('utf-8')
                line = i_utf.split(' ')
                if line[2] <= '2000':
                    file2.write((' '.join(line)).encode())
    
n = int(input("Input number of books: "))
fileName1 = "FirstFile.txt"
fileName2 = "SecondFile.txt"
set_file(n, fileName1)
print("First file:")
output_file(fileName1)
winter_books(fileName1)
create_file(fileName1, fileName2)
print("Second file:")
output_file(fileName2)