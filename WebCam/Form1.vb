Imports TouchlessLib
Imports System.Drawing.Imaging

Public Class Form1
    'Dim pic As New Drawing.Bitmap(640, 480)
    Dim Touchless As New TouchlessLib.TouchlessMgr
    'Dim Marker As New TouchlessLib.Marker
    Dim camera1 As TouchlessLib.Camera = Touchless.Cameras.ElementAt(0)
    Dim EA As TouchlessLib.CameraEventArgs

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'PictureBox1.Image = camera1.GetCurrentImage
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Size = New System.Drawing.Size(700, 600)

        Touchless.CurrentCamera = camera1
        camera1.FpsLimit = 25
        camera1.CaptureHeight = 480
        camera1.CaptureWidth = 640
        camera1.RotateFlip = RotateFlipType.RotateNoneFlipXY
        'camera1.RotateFlip = RotateFlipType.Rotate180FlipXY



    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'camera1.RotateFlip = ComboBox1.SelectedIndex

        Dim bmpCamera As Bitmap = New Bitmap(camera1.GetCurrentImage())

        Dim btHeight As Integer = bmpCamera.Height
        Dim btWidth As Integer = bmpCamera.Width

        For x As Integer = 0 To btWidth - 1
            bmpCamera.SetPixel(x, btHeight / 2, Color.FromArgb(0, 0, 0))
        Next


        For y As Integer = 0 To btHeight - 1
            bmpCamera.SetPixel(btWidth / 2, y, Color.FromArgb(0, 0, 0))
        Next

        PictureBox1.Image = bmpCamera


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        camera1.ShowPropertiesDialog(Me.Handle)
        'MsgBox(camera1.ToString())
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox(Me.Touchless.Cameras.Count)
        camera1.CaptureHeight = 1536
        camera1.CaptureWidth = 2048
        Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
    End Sub

    Private Sub CurrentCamera_OnImaheCaptured(ByVal sender As System.Object, ByVal e As CameraEventArgs)
        Me.PictureBox1.Image = e.Image
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Timer1.Enabled = False
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        camera1.Dispose()
    End Sub

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        camera1.CaptureHeight = Me.Size.Height - 120
        camera1.CaptureWidth = Me.Size.Width - 60

        PictureBox1.Size = New System.Drawing.Size(camera1.CaptureWidth, camera1.CaptureHeight)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        camera1.CaptureHeight = 768
        camera1.CaptureWidth = 1024
        Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        camera1.CaptureHeight = 480
        camera1.CaptureWidth = 640
        Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'PictureBox1.Image.Save("tmp2.jpg", ImageFormat.Jpeg)
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        '
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If (ComboBox1.SelectedIndex = 0) Then
            camera1.CaptureHeight = 480
            camera1.CaptureWidth = 640
            Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
        End If

        If (ComboBox1.SelectedIndex = 1) Then
            camera1.CaptureHeight = 768
            camera1.CaptureWidth = 1024
            Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        Touchless.CurrentCamera.RotateFlip = ComboBox2.SelectedIndex

    End Sub
End Class
