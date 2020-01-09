# FlightGear - desktop application
A remote controller

## Discription
Creating a remote control for FlightGear Simulator which allow the user:
- Connect and disconnect to simulator.
- Send commands.
- Control and fly the aircraft.

## Prerequisites
**Configuration set-up:**

**Env.requirements :**

- Download the simulator from : http://home.flightgear.org/
- Confing setting of the flightgear simulator :
```
--generic=socket,out,10,127.0.0.1,5400,tcp,generic_small
--telnet=socket,in,10,127.0.0.1,5402,tcp
```
- upload the generic_small.xml file your path :
```
[file of the flightgear app on our comupter] \data\Protocol
```

## About the application
This project enable you to control the flying commands simulator and get info of the flight path simulator. 
Inorder to connect to the simulator - click on "Setting" button and check if the communication deatils are correct,
if they are updated click on the "Connect" button.

<img width="507" alt="simulator screen" src="https://user-images.githubusercontent.com/45918656/72072644-13e05000-32f7-11ea-9308-df0c607b5a36.png">

now the run the flight simulator - run the .exe file of the filghtgear simulation you have been downloaded and press on "fly" button.

![start screen after connection](https://user-images.githubusercontent.com/45918656/72072738-40946780-32f7-11ea-94ec-8d637411fada.png)

**Fying plane**

in simulator press on "Autostart" for warming the engieen, afterwards you have to push the throtle.
you can do it thoghout the simulator or throgh my application . 
In the App you can choose how to send the commands - by manual or by auto pilot.

- by manual :

![insert trothel](https://user-images.githubusercontent.com/45918656/72072847-6faad900-32f7-11ea-9811-3de54ac27e6b.png)

- by auto pilot , after typing the commands - press the send in order to send the simulator commands.
```
in order to see the possible set commands you can check the attache xml file : generic_small.xml
```

![changing the throttle by auto command](https://user-images.githubusercontent.com/45918656/72072992-b7316500-32f7-11ea-8f8a-507a13b23af3.png)

- screen after sending the command :

### update command of throttle- image

- on the right side of the app you can see the path of the plane while you flying the aircraft.

### flightboard screen- image

- Now fly the plane with the joystick and try not to crash.

### flying the simulator- image
