#https://stackoverflow.com/questions/22351254/python-script-to-convert-image-into-byte-array/22351973

pic = "lisa2.jpg"
with open(pic, "rb") as image:
  f = image.read()
  b = bytearray(f)
  print(b)

textfile = open('test.txt', 'wb')
textfile.write(b)
textfile.close()

