﻿Imports TouchlessLib
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
        Touchless.CurrentCamera = camera1
        'Touchless.CurrentCamera.CaptureHeight = 480
        'Touchless.CurrentCamera.CaptureWidth = 640
        camera1.FpsLimit = 25
        camera1.CaptureHeight = 480
        camera1.CaptureWidth = 640
        camera1.RotateFlip = RotateFlipType.RotateNoneFlipXY

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        PictureBox1.Image = camera1.GetCurrentImage

        'PictureBox1.Image = Touchless.CurrentCamera.GetCurrentImage()

        Dim bt As Bitmap = Touchless.CurrentCamera.GetCurrentImage()

        Dim g As Graphics = PictureBox1.CreateGraphics()

        'Dim t As Single = 0.6F

        'Dim ptsArray()() As Single = {
        'New Single() {1, 0, 0, 0, 0},
        'New Single() {0, 1, 0, 0, 0},
        'New Single() {0, 0, 1, 0, 0},
        'New Single() {0, 0, 0, t, 0},
        'New Single() {0, 0, 0, 0, 1}
        '}
        'Dim clrMatrix As New ColorMatrix(ptsArray)
        'Dim imgAttributes As New ImageAttributes()
        'imgAttributes.SetColorMatrix(clrMatrix,
        '                             ColorMatrixFlag.Default,
        '                             ColorAdjustType.Bitmap)


        'g.DrawImage(bt, New Rectangle(0, 0, bt.Size.Width, bt.Size.Height),
        '           0, 0, bt.Size.Width, bt.Size.Height, GraphicsUnit.Pixel, imgAttributes)

        g.FillRectangle(Brushes.Red, 30, 40, 10, 10)
        g.DrawLine(Pens.Red, 60, 60, 80, 80)


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        camera1.ShowPropertiesDialog(Me.Handle)
        'MsgBox(camera1.ToString())
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        camera1.CaptureHeight = 768
        camera1.CaptureWidth = 1024
        Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        camera1.CaptureHeight = 480
        camera1.CaptureWidth = 640
        Me.Size = New System.Drawing.Size(camera1.CaptureWidth + 60, camera1.CaptureHeight + 120)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        g.FillRectangle(Brushes.Red, 30, 40, 1, 1)
        g.DrawLine(Pens.Red, 60, 60, 80, 80)

    End Sub
End Class
