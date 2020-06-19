import pyodbc
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
   cursor.execute("INSERT INTO ImageDetails(FileName,FileContent) VALUES(?,?) ", ("sayyedtest",None))
   cnxn.commit()