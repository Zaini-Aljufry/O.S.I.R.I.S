#https://stackoverflow.com/questions/45890700/how-to-convert-byte-array-to-picture
with open("test.txt", "rb") as binary_file:
        #Read the whole file at once
        data = bytearray(binary_file.read())
        
print(data)

#has to be jpg, if want modular, need to read first few byte to determine file format
qw = open('testwrite.jpg', 'wb')
qw.write(bytearray(data))
qw.close()
