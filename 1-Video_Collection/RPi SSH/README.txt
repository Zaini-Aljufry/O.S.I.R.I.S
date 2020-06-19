starting fresh 
-download Rasbian OS 
	@ https://www.raspberrypi.org/downloads/raspbian/
-download Etcher, to flash rasbian into SDCard
	@ https://www.balena.io/etcher/
	may need SD card formatter @ https://www.sdcard.org/downloads/formatter/
-install etcher, unzip Rasbian 
	flash content into SD card by choosing Rasbian

SSH starting
https://www.youtube.com/watch?v=uLwj4Wj7pRI&feature=youtu.be
If you set it up before, skip to step 4 to ssh to computer screen
1) boot drive on SSD card, create new text file 
	name it ssh and remove txt format (if cant see, view >> File name extension. check it)
	format should just be file
2) edit file "wpa_supplicant.conf" with wifi's name and password
	under ssid and psk 
	IMPORTANT to ensure computer is connected to same network
	copy to boot folder 
3) plug in memory card to RPi and power on
4) start "Advanced_IP_Scanner_", and run in portable mode (cause only need ONCE)
	copy your IPv4 address to Advance_IP_Scanner search bar (to get Ip addresscmd prompt >> ipconfig)
	change last few digits to 1-254 and run
	get RaspberryPi's IP address(right click copy)
5) run putty 
	copy RPi IP address to "Host Name"
	Port 22, Close window on exit>>Only on clean exit
6) login - should have a "login as:", default logins are
	user: Pi
	password: raspberry 
7) set up ssh
	type in "sudo raspi-config"
	Interfacing Options >> SSH >> enable 
	Interfacing Options >> VNC >> enable 
	(tab to go to exit button)
8) start VNC viewer
	paste RPi IP Address(from Advanced IP scanner) to space
	enter. it will pop up RPi screen