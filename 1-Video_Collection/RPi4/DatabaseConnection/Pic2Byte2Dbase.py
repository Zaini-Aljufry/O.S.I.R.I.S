from picamera import PiCamera
from time import sleep
import pyodbc
import os
from datetime import datetime

## Set Up database connection##
user='OSIRIS'
password='Abc123!@#'
database='OSIRIS'
port='1433'
TDS_Version='8.0'
server='192.168.43.171\IVAN-PC\MSSQLSERVER2;'
driver='FreeTDS'

con_string='UID=%s;PWD=%s;DATABASE=%s;PORT=%s;TDS=%s;SERVER=%s;driver=%s' % (user,password, database,port,TDS_Version,server,driver)
cnxn=pyodbc.connect(con_string)
cursor=cnxn.cursor()


##Camera Start ##
curTime = datetime.now().strftime("%d%m%Y%H:%M:%S")
location = '/home/pi/Desktop/'
filename = curTime +'.jpg'
PicDirec = location + filename

camera = PiCamera()
camera.capture(PicDirec)

## Send to database ##
with open(PicDirec, "rb") as image:
    #f = image.read()
    #b = bytearray(f)
    b = bytearray(image.read())
cursor.execute("INSERT INTO ImageDetails(FileName,FileContent) VALUES(?,?) ", (filename,b))

## Delete pictures ## 
os.remove(location + name)

##database connection terminate ##
cnxn.commit()