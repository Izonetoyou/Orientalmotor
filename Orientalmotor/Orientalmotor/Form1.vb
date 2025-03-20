Imports EasyModbus

Public Class Form1
    Private modbusClient As ModbusClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize Modbus RTU Client
            modbusClient = New ModbusClient("COM9") ' Change to your COM port
            modbusClient.Baudrate = 115200
            modbusClient.Parity = System.IO.Ports.Parity.Even
            modbusClient.StopBits = System.IO.Ports.StopBits.One
            modbusClient.UnitIdentifier = 1 ' Slave ID of the motor driver
            modbusClient.Connect()
            Timer1.Enabled = True
            MessageBox.Show("Modbus Connected!")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try


    End Sub

    ' Function to read feedback position from register 0x00CC (204 in decimal)
    Private Sub ReadFeedbackPosition()
        Try
            ' Read 2 registers from address 0x00CC (204 in decimal)
            Dim feedbackPosition As Integer() = modbusClient.ReadHoldingRegisters(289, 2)

            ' Assuming the feedback position is stored in 2 registers
            Dim position As Integer = feedbackPosition(0) ' This is the feedback position

            ' Display the feedback position in a message box
            lbPosition.Text = (position)
            'MessageBox.Show("Feedback Position: " & position)
        Catch ex As Exception
            Debug.Print("Error reading feedback position: " & ex.Message)
            'MessageBox.Show("Error reading feedback position: " & ex.Message)
        End Try
    End Sub


    Sub PrintResponse(modbusClient As ModbusClient, size As Integer)
        Try
            Dim response As Integer() = modbusClient.ReadHoldingRegisters(&H1800, size)
            Console.Write("Response: ")
            For Each value As Integer In response
                'Console.Write(Hex(value) & " ")
                ' Print Decimal representation
                Console.Write(value.ToString() & " ")
            Next
            Console.WriteLine()
        Catch ex As Exception
            Console.WriteLine("No Response from Modbus Slave!")
        End Try
    End Sub



    Private Sub btnJogP_Click(sender As Object, e As EventArgs) Handles btnJogP.Click
        Dim n As Integer = 0
        n = CInt(lbPosition.Text) + CInt(cb_acc.Text)
        If n <= 1199 Then
            StartJOG(n, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
        End If
    End Sub
    Private Sub btnJogN_Click(sender As Object, e As EventArgs) Handles btnJogN.Click
        Dim n As Integer = 0
        n = CInt(lbPosition.Text) - CInt(cb_acc.Text)
        If n >= 0 Then
            StartJOG(n, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
        End If

    End Sub
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ZHome()
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        ResetAlarm()
    End Sub
    Private Sub btnFWPos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFWPos.MouseDown
        TurnFWPosOn()
    End Sub

    Private Sub btnFWPos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnFWPos.MouseUp
        StopFWPos()
    End Sub

    Private Sub btnRVPos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRVPos.MouseDown
        TurnRVPosOn()
    End Sub

    Private Sub btnRVPos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRVPos.MouseUp
        StopRVPos()
    End Sub

    ' Close connection on Form close
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        modbusClient.Disconnect()
    End Sub

    ' Function to Start JOG Motion
    Private Sub StartJOG(position As Integer, acc As Integer, speed As Integer, brakes As Integer)
        Try
            ' Open the Modbus Serial Connection


            ' Command 1: Write to register (0x1800) with value (0x0002) Mode 1=PTP 2=P+P 3=P+P
            Dim command1 As Integer() = {0, 1}
            modbusClient.WriteMultipleRegisters(&H1800, command1)
            PrintResponse(modbusClient, 16)

            ' Command 2: Write to register (0x1802) with value (0x2134) position
            Dim command2 As Integer() = {0, CInt(position)}
            modbusClient.WriteMultipleRegisters(&H1802, command2)
            PrintResponse(modbusClient, 16)

            ' Command 3: Write to register (0x1804) with value (0x07D0) acc
            Dim command3 As Integer() = {0, CInt(acc)}
            modbusClient.WriteMultipleRegisters(&H1804, command3)
            PrintResponse(modbusClient, 16)

            ' Command 4: Write to register (0x1806) with value (0x05DC) speed
            Dim command4 As Integer() = {0, CInt(speed)}
            modbusClient.WriteMultipleRegisters(&H1806, command4)
            PrintResponse(modbusClient, 16)

            ' Command 5: Write to register (0x1808) with value (0x05DC)  Brakes
            Dim command5 As Integer() = {0, CInt(brakes)}
            modbusClient.WriteMultipleRegisters(&H1808, command5)
            PrintResponse(modbusClient, 16)
            ' Command 7: Write to register (0x007C) with value (0x0000) to start
            Dim command6 As Integer() = {0, 8}
            modbusClient.WriteMultipleRegisters(&H7C, command6)
            PrintResponse(modbusClient, 16)
            ' Command 7: Write to register (0x007C) with value (0x0000) to stop
            Dim command7 As Integer() = {0, 0}
            modbusClient.WriteMultipleRegisters(&H7C, command7)
            PrintResponse(modbusClient, 16)

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        ReadFeedbackPosition()

        Timer1.Enabled = True
    End Sub

    Public Sub ZHome()
        Try
            Dim address As Integer = &H7D ' Register address (0x007D)
            Dim value As Integer = &H10   ' Value to turn ZHOME ON (0x0010)

            ' Write to a single Modbus holding register (0x007D) with value 0x0010
            modbusClient.WriteSingleRegister(address, value)

            ' Print response to verify the write operation
            PrintResponse(modbusClient, 1)

            Console.WriteLine("ZHOME ON command sent successfully.")
        Catch ex As Exception
            Console.WriteLine("Error sending ZHOME ON command: " & ex.Message)
        End Try
    End Sub
    Public Sub ResetAlarm()
        Try
            Dim address As Integer = &H7D ' Register 0x0180 (384)
            Dim value As Integer = &H30C0 ' 0x30C0 (12480)

            ' Write to Modbus register
            modbusClient.WriteSingleRegister(address, value)
            value = &H4000
            modbusClient.WriteSingleRegister(address, value)
            ' Confirm the write
            Dim response As Integer() = modbusClient.ReadHoldingRegisters(address, 1)
            Console.WriteLine("Alarm Reset Register Value: " & Hex(response(0)))

        Catch ex As Exception
            Console.WriteLine("Error resetting alarm: " & ex.Message)
        End Try
    End Sub

    Public Sub TurnFWPosOn()
        Try
            Dim address As Integer = &H7D ' Register address (0x007D)
            Dim value As Integer = &H4000 ' Value to turn FW-POS ON (0x4000)

            ' Write to a single Modbus holding register (0x007D) with value 0x4000
            modbusClient.WriteSingleRegister(address, value)

            ' Print response to verify the write operation
            PrintResponse(modbusClient, 1)

            Console.WriteLine("FW-POS ON command sent successfully.")
        Catch ex As Exception
            Console.WriteLine("Error sending FW-POS ON command: " & ex.Message)
        End Try
    End Sub
    Public Sub StopFWPos()
        Try
            Dim address As Integer = &H7D ' Register address (0x007D)
            Dim value As Integer = &H0 ' Value to turn FW-POS OFF (0x0000)

            ' Write to a single Modbus holding register (0x007D) with value 0x0000
            modbusClient.WriteSingleRegister(address, value)

            ' Print response to verify the write operation
            PrintResponse(modbusClient, 1)

            Console.WriteLine("FW-POS OFF command sent successfully. Motor stopping.")
        Catch ex As Exception
            Console.WriteLine("Error sending FW-POS OFF command: " & ex.Message)
        End Try
    End Sub

    Public Sub TurnRVPosOn()
        Try
            Dim address As Integer = &H7D ' Register address (0x007D)
            Dim value As Integer = &H8000 ' RV-POS ON (0x2000)

            ' Write to Modbus register
            modbusClient.WriteSingleRegister(address, value)

            ' Print response to verify the write operation
            PrintResponse(modbusClient, 1)

            Console.WriteLine("RV-POS ON command sent successfully. Motor moving in reverse.")
        Catch ex As Exception
            Console.WriteLine("Error sending RV-POS ON command: " & ex.Message)
        End Try
    End Sub

    Public Sub StopRVPos()
        Try
            Dim address As Integer = &H7D ' Register address (0x007D)
            Dim value As Integer = &H0 ' RV-POS OFF (0x0000)

            ' Write to Modbus register
            modbusClient.WriteSingleRegister(address, value)

            ' Print response to verify the write operation
            PrintResponse(modbusClient, 1)

            Console.WriteLine("RV-POS OFF command sent successfully. Motor stopping.")
        Catch ex As Exception
            Console.WriteLine("Error sending RV-POS OFF command: " & ex.Message)
        End Try
    End Sub


End Class
