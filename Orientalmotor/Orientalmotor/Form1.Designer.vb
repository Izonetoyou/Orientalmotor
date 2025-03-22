<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnJogN = New System.Windows.Forms.Button()
        Me.btnJogP = New System.Windows.Forms.Button()
        Me.lbPosition = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtAcc = New System.Windows.Forms.TextBox()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.txtbrakes = New System.Windows.Forms.TextBox()
        Me.cb_acc = New System.Windows.Forms.ComboBox()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnFWPos = New System.Windows.Forms.Button()
        Me.btnRVPos = New System.Windows.Forms.Button()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.txtP1 = New System.Windows.Forms.TextBox()
        Me.txtP2 = New System.Windows.Forms.TextBox()
        Me.btnPTP = New System.Windows.Forms.Button()
        Me.cbShowposition = New System.Windows.Forms.CheckBox()
        Me.btnLoop = New System.Windows.Forms.Button()
        Me.btNoOff = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnJogN
        '
        Me.btnJogN.Location = New System.Drawing.Point(188, 91)
        Me.btnJogN.Name = "btnJogN"
        Me.btnJogN.Size = New System.Drawing.Size(75, 23)
        Me.btnJogN.TabIndex = 0
        Me.btnJogN.Text = "Jog -"
        Me.btnJogN.UseVisualStyleBackColor = True
        '
        'btnJogP
        '
        Me.btnJogP.Location = New System.Drawing.Point(188, 130)
        Me.btnJogP.Name = "btnJogP"
        Me.btnJogP.Size = New System.Drawing.Size(75, 23)
        Me.btnJogP.TabIndex = 3
        Me.btnJogP.Text = "Jog +"
        Me.btnJogP.UseVisualStyleBackColor = True
        '
        'lbPosition
        '
        Me.lbPosition.AutoSize = True
        Me.lbPosition.Location = New System.Drawing.Point(58, 24)
        Me.lbPosition.Name = "lbPosition"
        Me.lbPosition.Size = New System.Drawing.Size(44, 13)
        Me.lbPosition.TabIndex = 4
        Me.lbPosition.Text = "Position"
        '
        'Timer1
        '
        Me.Timer1.Interval = 80
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(52, 52)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 5
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(52, 78)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtAcc.TabIndex = 6
        Me.txtAcc.Text = "10000"
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(52, 104)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(100, 20)
        Me.txtSpeed.TabIndex = 7
        Me.txtSpeed.Text = "10000"
        '
        'txtbrakes
        '
        Me.txtbrakes.Location = New System.Drawing.Point(52, 131)
        Me.txtbrakes.Name = "txtbrakes"
        Me.txtbrakes.Size = New System.Drawing.Size(100, 20)
        Me.txtbrakes.TabIndex = 8
        Me.txtbrakes.Text = "10000"
        '
        'cb_acc
        '
        Me.cb_acc.FormattingEnabled = True
        Me.cb_acc.Items.AddRange(New Object() {"1", "2", "5", "10", "20", "50", "100"})
        Me.cb_acc.Location = New System.Drawing.Point(188, 52)
        Me.cb_acc.Name = "cb_acc"
        Me.cb_acc.Size = New System.Drawing.Size(75, 21)
        Me.cb_acc.TabIndex = 9
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(188, 168)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(75, 23)
        Me.btnHome.TabIndex = 10
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnFWPos
        '
        Me.btnFWPos.Location = New System.Drawing.Point(287, 128)
        Me.btnFWPos.Name = "btnFWPos"
        Me.btnFWPos.Size = New System.Drawing.Size(75, 23)
        Me.btnFWPos.TabIndex = 11
        Me.btnFWPos.Text = "FWPos"
        Me.btnFWPos.UseVisualStyleBackColor = True
        '
        'btnRVPos
        '
        Me.btnRVPos.Location = New System.Drawing.Point(287, 91)
        Me.btnRVPos.Name = "btnRVPos"
        Me.btnRVPos.Size = New System.Drawing.Size(75, 23)
        Me.btnRVPos.TabIndex = 12
        Me.btnRVPos.Text = "RVPos"
        Me.btnRVPos.UseVisualStyleBackColor = True
        '
        'btnreset
        '
        Me.btnreset.Location = New System.Drawing.Point(52, 168)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(75, 23)
        Me.btnreset.TabIndex = 13
        Me.btnreset.Text = "Reset"
        Me.btnreset.UseVisualStyleBackColor = True
        '
        'txtP1
        '
        Me.txtP1.Location = New System.Drawing.Point(52, 220)
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(50, 20)
        Me.txtP1.TabIndex = 14
        Me.txtP1.Text = "10"
        '
        'txtP2
        '
        Me.txtP2.Location = New System.Drawing.Point(108, 220)
        Me.txtP2.Name = "txtP2"
        Me.txtP2.Size = New System.Drawing.Size(53, 20)
        Me.txtP2.TabIndex = 15
        Me.txtP2.Text = "1000"
        '
        'btnPTP
        '
        Me.btnPTP.Location = New System.Drawing.Point(167, 218)
        Me.btnPTP.Name = "btnPTP"
        Me.btnPTP.Size = New System.Drawing.Size(75, 23)
        Me.btnPTP.TabIndex = 16
        Me.btnPTP.Text = "P1"
        Me.btnPTP.UseVisualStyleBackColor = True
        '
        'cbShowposition
        '
        Me.cbShowposition.AutoSize = True
        Me.cbShowposition.Location = New System.Drawing.Point(134, 24)
        Me.cbShowposition.Name = "cbShowposition"
        Me.cbShowposition.Size = New System.Drawing.Size(53, 17)
        Me.cbShowposition.TabIndex = 17
        Me.cbShowposition.Text = "Show"
        Me.cbShowposition.UseVisualStyleBackColor = True
        '
        'btnLoop
        '
        Me.btnLoop.Location = New System.Drawing.Point(268, 217)
        Me.btnLoop.Name = "btnLoop"
        Me.btnLoop.Size = New System.Drawing.Size(75, 23)
        Me.btnLoop.TabIndex = 18
        Me.btnLoop.Text = "Loop"
        Me.btnLoop.UseVisualStyleBackColor = True
        '
        'btNoOff
        '
        Me.btNoOff.Location = New System.Drawing.Point(287, 168)
        Me.btNoOff.Name = "btNoOff"
        Me.btNoOff.Size = New System.Drawing.Size(75, 23)
        Me.btNoOff.TabIndex = 19
        Me.btNoOff.Text = "OFF"
        Me.btNoOff.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 264)
        Me.Controls.Add(Me.btNoOff)
        Me.Controls.Add(Me.btnLoop)
        Me.Controls.Add(Me.cbShowposition)
        Me.Controls.Add(Me.btnPTP)
        Me.Controls.Add(Me.txtP2)
        Me.Controls.Add(Me.txtP1)
        Me.Controls.Add(Me.btnreset)
        Me.Controls.Add(Me.btnRVPos)
        Me.Controls.Add(Me.btnFWPos)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.cb_acc)
        Me.Controls.Add(Me.txtbrakes)
        Me.Controls.Add(Me.txtSpeed)
        Me.Controls.Add(Me.txtAcc)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbPosition)
        Me.Controls.Add(Me.btnJogP)
        Me.Controls.Add(Me.btnJogN)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnJogN As Button
    Friend WithEvents btnJogP As Button
    Friend WithEvents lbPosition As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtAcc As TextBox
    Friend WithEvents txtSpeed As TextBox
    Friend WithEvents txtbrakes As TextBox
    Friend WithEvents cb_acc As ComboBox
    Friend WithEvents btnHome As Button
    Friend WithEvents btnFWPos As Button
    Friend WithEvents btnRVPos As Button
    Friend WithEvents btnreset As Button
    Friend WithEvents txtP1 As TextBox
    Friend WithEvents txtP2 As TextBox
    Friend WithEvents btnPTP As Button
    Friend WithEvents cbShowposition As CheckBox
    Friend WithEvents btnLoop As Button
    Friend WithEvents btNoOff As Button
End Class
