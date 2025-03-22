# 🚗 Oriental Motor Control System (VB.NET)

This project allows control of the Oriental Motor using VB.NET. The system provides functionalities like Jog, Home, Reset Alarm, and Forward/Reverse Position control through Modbus communication.

---

### 📋 **Features**

- **Jogging**: Move motor position in positive/negative direction
- **Home**: Move motor to its home position
- **Reset Alarm**: Reset the motor alarm
- **Forward/Reverse Position Control**: Control motor position using buttons
- **Real-time Position**: Display the motor position in real-time
- **Control Motor ON/OFF**: Toggle motor control ON or OFF
- **Modbus Communication**: Communicates with the motor over Modbus protocol (via COM port)

---

### 💾 **Installation**

1. Clone the repository.
2. Open the project in Visual Studio.
3. Ensure you have .NET Framework 4.5 installed.
4. Build and run the project.

---

### ⚙️ **Configuration**

Edit the `Config.ini` file (or your code) to match the correct COM port and baud rate settings for your motor connection.

---

### 💡 **Usage**

1. **Connect**: Establish a connection to the motor using the COM port.
2. **Jog**: Use the `Jog` buttons to move the motor in positive or negative direction.
3. **Home**: Use the `Home` button to reset the motor to its home position.
4. **Reset Alarm**: Press the `Reset Alarm` button to clear any alarms.
5. **Forward/Reverse Position**: Hold the `Forward` or `Reverse` button to move the motor in the desired direction.
6. **Control Motor ON/OFF**: Toggle the motor control ON or OFF with the `ON/OFF` button.
7. **Real-time Position Display**: The motor position will be updated every second.

---

### 🛠 **Code Explanation**

- The code uses the `EasyModbus` library to communicate with the Oriental Motor via Modbus over the COM port.
- The `OrientalMotorController` class encapsulates the Modbus communication, allowing the motor to be controlled using commands like `StartJOG`, `ZHome`, and `ResetAlarm`.
- The `Form1` contains the UI controls for jogging, resetting alarms, and monitoring motor status.

---

### 🛑 **Troubleshooting**

- **COM port connection issue**: Make sure the correct COM port is configured in the code and that the motor is connected to the specified port.
- **Motor not responding**: Ensure the motor is powered on and properly connected to the system.
- **Modbus communication error**: Double-check your Modbus connection settings (baud rate, stop bits, parity).

---

### 📞 **Contact**

For support, feel free to reach out to **Nitikorn Todting** at [https://nitikorn-todting.web.app/](https://nitikorn-todting.web.app/).
