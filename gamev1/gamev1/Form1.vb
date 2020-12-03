Public Class Form1
    Dim r As New Random
    Dim score As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Sub Randmove(p As PictureBox)
        Dim x As Integer
        Dim y As Integer
        x = r.Next(-25, 25)
        y = r.Next(-25, 25)
        MoveTo(p, x, y)

    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                MoveTo(PictureBox1, 0, -25)
            Case Keys.Down
                MoveTo(PictureBox1, 0, 25)
            Case Keys.Left
                MoveTo(PictureBox1, -25, 0)
            Case Keys.Right
                MoveTo(PictureBox1, 25, 0)
            Case Keys.D
                bullet.Visible = True
                bullet.Location = PictureBox1.Location
                Timer2.Enabled = True
            Case Keys.A
                bullet2.Visible = True
                bullet2.Location = PictureBox1.Location
                Timer3.Enabled = True
            Case Keys.S
                bullet3.Visible = True
                bullet3.Location = PictureBox1.Location
                Timer4.Enabled = True
            Case Keys.W
                bullet4.Visible = True
                bullet4.Location = PictureBox1.Location
                Timer5.Enabled = True
            Case Keys.R
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)
                Me.Refresh()
        End Select
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'move(PictureBox2, 10, 5)
        chase(bunny1)
        chase(bunny2)
        Randmove(bunny3)
        chase(bunny4)
        chase(bunny5)
        Randmove(bunny6)
        chase(bunny7)
        chase(bunny8)
        Randmove(bunny9)
        chase(bunny10)
        chase(bunny11)
        Randmove(bunny12)
        chase(bunny13)
        chase(bunny14)
        chase(bunny15)
        Randmove(bunny16)
        chase(bunny17)
        Randmove(bunny18)
        chase(bunny19)
        chase(bunny20)
        Randmove(bunny21)
        chase(bunny22)
        chase(bunny23)
        Randmove(bunny24)
        chase(bunny25)
        Randmove(bunny26)
        chase(bunny27)
        chase(bunny28)
        chase(bunny29)
        Randmove(bunny30)
        chase(bunny31)
        chase(bunny32)
        chase(bunny33)
        Randmove(bunny34)
        chase(bunny35)
        chase(bunny36)
        Randmove(bunny37)
        chase(bunny38)
        chase(bunny39)
        Randmove(bunny40)
        chase(bunny41)
        chase(bunny42)
        Randmove(bunny43)
        chase(bunny44)
        Randmove(bunny45)
        chase(bunny46)
        Randmove(bunny47)
        chase(bunny48)
        chase(bunny49)
        chase(bunny50)
        Randmove(bunny51)
        Randmove(bunny52)
        chase(bunny53)
        chase(bunny54)
        Randmove(bunny55)
        chase(bunny56)
        Randmove(bunny57)
        Randmove(bunny58)
        chase(bunny59)
        chase(bunny60)

    End Sub
    Sub Move(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x,
                                          p.Location.Y + y)

        If p.Name = "bullet2" And Collision(bullet2, "bunny") Then
            bunny1.Visible = False
            score = score + 1
            If score = 60 Then

            End If
            Return

        End If

        If Collision(p, "wall1") Then
            MsgBox("gameover")
            score = score + 1

        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click


    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > PictureBox1.Location.X Then
            x = -1
        Else
            x = 1
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox1.Location.Y Then
            y = 2
        Else
            y = -2
        End If
        MoveTo(p, x, y)
    End Sub



    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col



        If p.Name.Contains("bunny") And Collision(p, "Picturebox1", other) Then
            MsgBox("gameover")
        End If

    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "WIN", other) Then
            other.visible = False
            Return
        End If
        If p.Name.Contains("bullet") And Collision(p, "bunny", other) Then
            other.visible = False
            PictureBox1.Visible = True
            score = score + 1
            If score = 60 Then

                Me.Visible = False
                Dim f As New Form2
                f.ShowDialog()
                Me.Visible = True
            End If
            Return
        End If

        If p.Name.Contains("bunny") And Collision(p, "PictureBox1", other) Then
            PictureBox1.Visible = False
            gameoverscreen.Visible = True
        End If
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        MoveTo(bullet, 50, 0)
        If bullet.Location.X < 0 Then
            bdir = 5
        Else
        End If
        If bullet.Location.X > 300 Then
            bdir = -5
        End If
        scorelabel.Text = score
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        MoveTo(bullet2, -50, 0)
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        MoveTo(bullet3, 0, 50)
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        MoveTo(bullet4, 0, -50)
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick


    End Sub
    Dim bdir As Integer = 5

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles wall19.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles wall21.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles wall9.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles wall11.Click

    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles bunny41.Click
    End Sub
End Class


































