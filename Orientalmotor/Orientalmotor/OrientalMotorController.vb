Imports EasyModbus

Public Class OrientalMotorController
    Private modbusClient As ModbusClient

    Public Sub New(port As String, baudrate As Integer, unitID As Byte)
        Try
            modbusClient = New ModbusClient(port)
            modbusClient.Baudrate = baudrate
            modbusClient.Parity = System.IO.Ports.Parity.Even
            modbusClient.StopBits = System.IO.Ports.StopBits.One
            modbusClient.UnitIdentifier = unitID
            modbusClient.Connect()
            Console.WriteLine("Modbus Connected!")
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub Disconnect()
        modbusClient.Disconnect()
    End Sub

    Public Function ReadFeedbackPosition() As Integer
        Try
            Dim feedbackPosition As Integer() = modbusClient.ReadHoldingRegisters(289, 2)
            Return feedbackPosition(0)
        Catch ex As Exception
            Console.WriteLine("Error reading feedback position: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Sub StartJOG(position As Integer, acc As Integer, speed As Integer, brakes As Integer)
        Try
            modbusClient.WriteMultipleRegisters(&H1800, {0, 1})
            modbusClient.WriteMultipleRegisters(&H1802, {0, position})
            modbusClient.WriteMultipleRegisters(&H1804, {0, acc})
            modbusClient.WriteMultipleRegisters(&H1806, {0, speed})
            modbusClient.WriteMultipleRegisters(&H1808, {0, brakes})
            modbusClient.WriteMultipleRegisters(&H7C, {0, 8})
            modbusClient.WriteMultipleRegisters(&H7C, {0, 0})
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub ZHome()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H10)
        Catch ex As Exception
            Console.WriteLine("Error sending ZHOME ON command: " & ex.Message)
        End Try
    End Sub

    Public Sub ResetAlarm()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H30C0)
            modbusClient.WriteSingleRegister(&H7D, &H4000)
        Catch ex As Exception
            Console.WriteLine("Error resetting alarm: " & ex.Message)
        End Try
    End Sub

    Public Sub TurnFWPosOn()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H4000)
        Catch ex As Exception
            Console.WriteLine("Error sending FW-POS ON command: " & ex.Message)
        End Try
    End Sub

    Public Sub StopFWPos()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H0)
        Catch ex As Exception
            Console.WriteLine("Error sending FW-POS OFF command: " & ex.Message)
        End Try
    End Sub

    Public Sub TurnRVPosOn()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H8000)
        Catch ex As Exception
            Console.WriteLine("Error sending RV-POS ON command: " & ex.Message)
        End Try
    End Sub

    Public Sub StopRVPos()
        Try
            modbusClient.WriteSingleRegister(&H7D, &H0)
        Catch ex As Exception
            Console.WriteLine("Error sending RV-POS OFF command: " & ex.Message)
        End Try
    End Sub
    Public Sub ControlMotor(isOn As Boolean)
        Try
            Dim address As Integer = &H7D
            Dim value As Integer = If(isOn, &H1, &H0) ' 0x01 for ON, 0x00 for OFF

            ' Write to Modbus register
            modbusClient.WriteSingleRegister(address, value)
            modbusClient.WriteSingleRegister(address, &H4000)
            ' Confirm the write by reading the register
            Dim response As Integer() = modbusClient.ReadHoldingRegisters(address, 1)
            Console.WriteLine("Motor Control Register Value: " & Hex(response(0)))

            If isOn Then
                Console.WriteLine("Motor turned ON.")
            Else
                Console.WriteLine("Motor turned OFF.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error controlling motor: " & ex.Message)
        End Try
    End Sub

End Class
