################################################################################
#Desc: unit test for sending files in 1 folder (/home/pi/Rail Defects)
#      to database (Ivan's computer). Only works when all devices are connected 
#      to same network in this case, tethering/hot spot from Yi Feng's Phone
#
#   https://www.raspberrypi.org/forums/viewtopic.php?t=172498
#   https://tryolabs.com/blog/2012/06/25/connecting-sql-server-database-python-under-ubuntu/
#   may need sudo nano /etc/freetds/freetds.conf, to edit file
#
#   https://stackoverflow.com/questions/10377998/how-can-i-iterate-over-files-in-a-given-directory
################################################################################
import pyodbc #for connection and communication with database
import os #file accessing

########## Database Connection #################
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
#to send single file
#cursor.execute("INSERT INTO ImageDetails(FileName,FileContent) VALUES(?,?) ", (filename,b))
#send multiple, eg shows 2 files
#cursor.executemany("INSERT INTO ImageDetails(FileName,FileContent) VALUES(?,?) ", [(filename,b), filename2,b2)])


########## Accessing File #################
location = "/home/pi/Rail Defects"
directory = os.fsencode(location) #get location

#loop through all files in directory, 
#nvr check for format, can add as safe guard if 
#if filename.endswith(".jpg")
for pict in os.listdir(directory): 
    filename = os.fsdecode(pict)
    addfloc = location + '/' + filename
    with open(addfloc, "rb") as image:
        f = image.read() 
        b = bytearray(f) #set to bytearray for database storage
    cursor.execute("INSERT INTO ImageDetails(FileName,FileContent) VALUES(?,?) ", (filename,b))

cnxn.commit()