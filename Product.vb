Public Class Product
    Public Property Name As String
    Public Property Description As String
    Public Property Price As Double
    Public Property Types As String

    Public Sub New(name As String, description As String, price As Double, types As String)
        Me.Name = name
        Me.Description = description
        Me.Price = price
        Me.Types = types
    End Sub
End Class
