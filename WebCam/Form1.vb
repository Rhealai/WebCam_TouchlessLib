Imports TouchlessLib
Public Class Form1
    Dim pic As New Drawing.Bitmap(500, 400)
    Dim Touchless As New TouchlessLib.TouchlessMgr
    Dim camera1 As TouchlessLib.Camera = Touchless.Cameras.ElementAt(0)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Image = camera1.GetCurrentImage
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Touchless.CurrentCamera = camera1
        Touchless.CurrentCamera.CaptureHeight = 200
        Touchless.CurrentCamera.CaptureWidth = 300
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Image = camera1.GetCurrentImage
    End Sub
End Class
