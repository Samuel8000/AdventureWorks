
Public Class Customer
    Inherits CommonBase

    Sub New()
        MyBase.New()

        CustomerId = 1
    End Sub

    Public Property CustomerId As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property CompanyName As String

    Protected Overrides Function GetClassData() As String
        Dim sb As New Text.StringBuilder(1024)

        sb.AppendLine("Customer Id: " + CustomerId.ToString())
        sb.AppendLine("Company Name: " + CompanyName)
        sb.AppendLine("First Name: " + FirstName)
        sb.AppendLine("Last Name: " + LastName)
        sb.AppendLine(MyBase.GetClassData())

        Return sb.ToString()
    End Function
End Class
