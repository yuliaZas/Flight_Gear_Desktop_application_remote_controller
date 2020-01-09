# FlightGear - desktop application
A remote controller application

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
This project enable you to control the flying commands simulator and get the info of the flight path simulator. 
Inorder to connect to the simulator - click on "Setting" button and check if the communication deatils are correct,
if they are updated click on the "Connect" button.

<img width="507" alt="simulator screen" src="https://user-images.githubusercontent.com/45918656/72072644-13e05000-32f7-11ea-9308-df0c607b5a36.png">

Now the run the flight simulator - run the .exe file of the filghtgear simulation you have been downloaded and press on "fly" button.

![start screen after connection](https://user-images.githubusercontent.com/45918656/72072738-40946780-32f7-11ea-94ec-8d637411fada.png)

**Flying the  aircraft**

In the simulator press on "Autostart" for warming the engieen, afterwards you have to move the throtle -
You can do it thoghout the simulator or throgh the application. 


In the App you can choose how to send the commands - by manual or by auto pilot:

- **By manual :**

![insert trothel](https://user-images.githubusercontent.com/45918656/72072847-6faad900-32f7-11ea-9811-3de54ac27e6b.png)

- **By auto pilot:**
```
After typing the commands - press the send in order to send the simulator commands.
In order to see the possible set commands you can check the attache xml file : generic_small.xml
```

![changing the throttle by auto command](https://user-images.githubusercontent.com/45918656/72072992-b7316500-32f7-11ea-8f8a-507a13b23af3.png)

- The screen will look like this after sending the command:

![update auto command of throttle](https://user-images.githubusercontent.com/45918656/72073075-da5c1480-32f7-11ea-8868-d885c7040df2.png)

- On the right side of the app you can see the path, while you flying the aircraft.

<img width="462" alt="flightboard screen" src="https://user-images.githubusercontent.com/45918656/72073144-011a4b00-32f8-11ea-85fa-0bd44d40ac05.png">

- Now fly the aircraft with the joystick and try not to crash.

<img width="464" alt="flying the simulator" src="https://user-images.githubusercontent.com/45918656/72073198-1e4f1980-32f8-11ea-9e54-706a6a6be59b.png">
