Imports System.IO.Ports
Imports System.Text

Public Class ModbusRTUExample
    Dim serialPort As SerialPort
    Dim size As Integer = 16 ' Set the size as per your needs

    Public Sub ConnectAndSendCommands()
        Try
            ' Set up the serial port for RTU communication
            serialPort = New SerialPort("COM9", 115200, Parity.Even, 8, StopBits.One)
            serialPort.ReadTimeout = 10 ' Set the timeout to 10 ms (similar to 0.01s in Python)
            serialPort.Open()

            ' Display the port name
            Console.WriteLine("Port Name: " & serialPort.PortName)

            ' First command
            Dim commando As String = "\x01\x10\x18\x00\x00\x02\x04\x00\x00\x00\x02\xd8\x6e"
            serialPort.Write(commando)



            ' Fourth command (Fix: Split &H5DC into two bytes: &H5, &HDC)
            commando = "\x01\x10\x18\x02\x00\x02\x04\x00\x00\x21\x34\xc1\xf1"
            serialPort.Write(commando)


            ' Fifth command (Fix: Split &H5DC into two bytes: &H5, &HDC)
            commando = "\x01\x10\x18\x04\x00\x02\x04\x00\x00\x07\xd0\x5b\xf0"
            serialPort.Write(commando)


            ' Sixth command (Fix: Split &H8F5 into two bytes: &H8, &HF5)
            commando = "\x01\x10\x18\x06\x00\x02\x04\x00\x00\x05\xdc\xdb\x4c"
            serialPort.Write(commando)


            ' Seventh command (Fix: Split &HF4DE into two bytes: &HF4, &HDE)
            commando = "\x01\x10\x18\x08\x00\x02\x04\x00\x00\x05\xdc\x5a\xc0"
            serialPort.Write(commando)


            ' Second command
            commando = "\x01\x10\x00\x7c\x00\x02\x04\x00\x00\x00\x08\xf5\x18"
            serialPort.Write(commando)


            ' Third command (Fix: Split &H7D0 into two bytes: &H7, &HD0)
            commando = "\x01\x10\x00\x7c\x00\x02\x04\x00\x00\x00\x00\xf4\xde"
            serialPort.Write(commando)


        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        Finally
            ' Close the serial port
            If serialPort IsNot Nothing AndAlso serialPort.IsOpen Then
                serialPort.Close()
            End If
        End Try
    End Sub

    ' Read the result after sending a command
    Private Function ReadResult() As Byte()
        Dim buffer(size - 1) As Byte
        serialPort.Read(buffer, 0, size)
        Return buffer
    End Function

    ' Print the result in hexadecimal format
    Private Sub PrintResult(result As Byte())
        Dim resultString As String = BitConverter.ToString(result).Replace("-", " ")
        Console.WriteLine("Result: " & resultString)
    End Sub
End Class
